using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dasync.Collections;

namespace Dasync.Collections.Internals
{
    internal sealed class AsyncEnumeratorWrapper<T> : IAsyncEnumerator, IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;
        private readonly bool _runSynchronously;

        public AsyncEnumeratorWrapper(IEnumerator<T> enumerator, bool runSynchronously)
        {
            _enumerator = enumerator;
            _runSynchronously = runSynchronously;
        }

        internal CancellationToken MasterCancellationToken;

        public T Current => _enumerator.Current;

        object IAsyncEnumerator.Current => Current;

        public ValueTask<bool> MoveNextAsync()
        {
            if (_runSynchronously)
            {
                try
                {
#if NET40
                    var moveNextAsync = new ValueTask<bool>(()=>_enumerator.MoveNext());
                    moveNextAsync.Start();
                    return moveNextAsync;
#else
                    return new ValueTask<bool>(_enumerator.MoveNext());
#endif
                }
                catch (Exception ex)
                {
                    var tcs = new TaskCompletionSource<bool>();
                    tcs.SetException(ex);
#if NET40
                    var moveNextAsync = new ValueTask<bool>(()=>tcs.Task.Result);
                    moveNextAsync.Start();
                    return moveNextAsync;
#else
                    return new ValueTask<bool>(tcs.Task);
#endif
                }
            }
            else
            {
#if NET40
                return new ValueTask<bool>(()=>
                {
                    var taskEx = new Task<bool>(() => _enumerator.MoveNext(), MasterCancellationToken);
                    taskEx.Start();
                    return taskEx.Result;
                });
#else
                return new ValueTask<bool>(Task.Run(() => _enumerator.MoveNext(), MasterCancellationToken));
#endif
            }
        }

        public void Dispose()
        {
            _enumerator.Dispose();
        }

#if NET40
        public Task DisposeAsync()
        {
            Dispose();
            return TaskEx.Completed;
        }
#else
        public ValueTask DisposeAsync()
        {
            Dispose();
            return new ValueTask();
        }
#endif
    }
}
