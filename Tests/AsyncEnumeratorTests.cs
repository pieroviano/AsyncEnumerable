using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class AsyncEnumeratorTests
{
    [Test]
    public async Task RaceConditionOnEndOfEnumeration()
    {
        await DoRaceConditionOnEndOfEnumeration();
    }

    private static async Task DoRaceConditionOnEndOfEnumeration()
    {
        var enumerator = new AsyncEnumerator<int>(async yield =>
        {
            await TaskEx.Run(async () => { await yield.ReturnAsync(1); });
        });

        var moveResult1 = await enumerator.MoveNextAsync();
        var moveResult2 = await enumerator.MoveNextAsync();
        var moveResult3 = await enumerator.MoveNextAsync();

        Assert.IsTrue(moveResult1);
        Assert.IsFalse(moveResult2);
        Assert.IsFalse(moveResult3);
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

        Assert.ThrowsAsync<TaskCanceledException>(() => enumerable.ToListAsync(cts.Token));
    }

    [Test]
    public async Task DisposeAfterPartialEnumeration()
    {
        await DoDisposeAfterPartialEnumeration();
    }

    private static async Task DoDisposeAfterPartialEnumeration()
    {
        // ARRANGE

        var testDisposable = new TestDisposable();
        var enumerator = new AsyncEnumerator<int>(async yield =>
        {
            using (testDisposable)
            {
                await yield.ReturnAsync(1);
                await yield.ReturnAsync(2);
                await yield.ReturnAsync(3);
            }
        });

        // ACT

        await enumerator.MoveNextAsync();
        enumerator.Dispose();

        // ASSERT

        Assert.IsTrue(testDisposable.HasDisposed);
    }

    [Test]
    public async Task DisposeByGCAfterPartialEnumeration()
    {
        await DoDisposeByGCAfterPartialEnumeration();
    }

    private static async Task DoDisposeByGCAfterPartialEnumeration()
    {
        // ARRANGE

        var testDisposable = new TestDisposable();

        void CreateEnumeratorAndMoveNext()
        {
            var enumerator = new AsyncEnumerator<int>(async yield =>
            {
                using (testDisposable)
                {
                    await yield.ReturnAsync(1);
                    await yield.ReturnAsync(2);
                    await yield.ReturnAsync(3);
                }
            });

            // Do partial enumeration.
            enumerator.MoveNextAsync().GetAwaiter().GetResult();
        }

        // ACT
        CreateEnumeratorAndMoveNext();

        // Instead of calling enumerator.Dispose(), do garbage collection.
        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced
#if !NET40
            , blocking: true
#endif
        );

        // Give some time to other thread that does the disposal of the enumerator.
        // (see finalizer of the AsyncEnumerator for details)
        await TaskEx.Delay(16);

        // ASSERT

        Assert.IsTrue(testDisposable.HasDisposed);
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
#if !NET40
            , blocking: true
#endif
        );
        Thread.Sleep(16);

        // ASSERT

        Assert.IsTrue(testDisposable.HasDisposed);
    }

    [Test]
    public async Task DisposeWaitsForFinalization()
    {
        await DoDisposeWaitsForFinalization();
    }

    private static async Task DoDisposeWaitsForFinalization()
    {
        var tcs = new TaskCompletionSource<object>();
        var isFinalized = false;

        var enumerable = new AsyncEnumerable<int>(async yield =>
        {
            try
            {
                await yield.ReturnAsync(1);
                await yield.ReturnAsync(2);
            }
            finally
            {
                await tcs.Task;
                isFinalized = true;
            }
        });

        var enumerator = enumerable.GetAsyncEnumerator();
        await enumerator.MoveNextAsync();

        var disposeTask = enumerator.DisposeAsync();
        await TaskEx.Yield();
        Assert.IsFalse(disposeTask.IsCompleted);

        tcs.SetResult(null);
        await disposeTask;
        Assert.IsTrue(isFinalized);
    }

    private class TestDisposable : IDisposable
    {
        public bool HasDisposed { get; private set; }
        public void Dispose()
        {
            HasDisposed = true;
        }
    }

    [Test]
    public async Task EnumerationMustEndAfterDispose()
    {
        await DoEnumerationMustEndAfterDispose();
    }

    private static async Task DoEnumerationMustEndAfterDispose()
    {
        // ARRANGE

        var enumerator = new AsyncEnumerator<int>(async yield =>
        {
            await yield.ReturnAsync(1);
            await yield.ReturnAsync(2);
        });

        await enumerator.MoveNextAsync();

        // ACT

        enumerator.Dispose();
        bool moveNextResult = await enumerator.MoveNextAsync();
        int currentElement = enumerator.Current;

        // ASSERT

        Assert.IsFalse(moveNextResult, "MoveNextAsync must return False after Dispose");
        Assert.AreEqual(1, currentElement, "Current must not change after Dispose");
    }

    [Test]
    public async Task YieldBreak()
    {
        await DoYieldBreak();
    }

    private static async Task DoYieldBreak()
    {
        // ARRANGE

        var asyncEnumerationCanceledExceptionRaised = false;

        var enumerator = new AsyncEnumerator<int>(async yield =>
        {
            try
            {
                yield.Break();
            }
            catch (AsyncEnumerationCanceledException)
            {
                asyncEnumerationCanceledExceptionRaised = true;
            }

            await yield.ReturnAsync(1);
        });

        // ACT

        var result = await enumerator.MoveNextAsync();

        await TaskEx.Yield();

        // ASSERT

        Assert.IsFalse(result, "MoveNextAsync must return False due to Yield.Break");
        Assert.IsTrue(asyncEnumerationCanceledExceptionRaised,
            "Yield.Break must throw AsyncEnumerationCanceledException so the enumerator body can perform finalization");
    }
}