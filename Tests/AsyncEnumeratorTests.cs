using NUnit.Framework;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using CoreLibrary;

namespace Tests
{
    public partial class AsyncEnumeratorTests
    {
        private class TestDisposable : IDisposable
        {
            public bool HasDisposed { get; private set; }
            public void Dispose()
            {
                HasDisposed = true;
            }
        }

        [Test]
        public void CancelEnumeration()
        {
            var cts = new CancellationTokenSource();
            cts.Cancel();

            var enumerable = new AsyncEnumerable<int>(async yield =>
            {
                await TaskEx.Yield();
                yield.CancellationToken.ThrowIfCancellationRequested();
            });
#if NET35 || NET40
            var task = new Action(() =>
            {
                enumerable.ToListAsync(cts.Token);
            }).RunDelegateWithCompletionSource();
            Assert.Throws<TaskCanceledException>(()=>task.WaitForTask());
#else
            Assert.ThrowsAsync<TaskCanceledException>(() => enumerable.ToListAsync(cts.Token));
#endif
        }


        [Test]
        public void OnDisposeActionIsCalled()
        {
            // ARRANGE

            var testDisposable = new TestDisposable();

            var enumerator = new AsyncEnumerator<int>(async yield =>
                {
                    await yield.ReturnAsync(1);
                },
                onDispose: () => testDisposable.Dispose());

            // ACT

            enumerator.Dispose();

            // ASSERT

            Assert.IsTrue(testDisposable.HasDisposed);
        }

        [Test]
        public void OnDisposeMustBeCalledOnGcWhenEnumerationHasNotBeenStarted()
        {
            // ARRANGE

            var testDisposable = new TestDisposable();

            void CreateEnumerator()
            {
                var enumerator = new AsyncEnumerator<int>(async yield =>
                    {
                        await yield.ReturnAsync(1);
                    },
                    onDispose: () => testDisposable.Dispose());
            }

            // ACT

            CreateEnumerator();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced
#if !NET40 && !NET35
                , blocking: true
#endif
            );
            Thread.Sleep(16);

            // ASSERT

            Assert.IsTrue(testDisposable.HasDisposed);
        }

    }
}
