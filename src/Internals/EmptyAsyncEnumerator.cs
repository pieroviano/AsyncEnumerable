using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dasync.Collections;

namespace Dasync.Collections.Internals
{
    internal sealed class EmptyAsyncEnumerator<T> : IAsyncEnumerator, IAsyncEnumerator<T>
    {
        public T Current
        {
            get
            {
                throw new InvalidOperationException("The enumerator has reached the end of the collection");
            }
        }

        object IAsyncEnumerator.Current => Current;

#if NET40
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(()=>false);

        public Task DisposeAsync() => TaskEx.Completed;
#else
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(false);

        public ValueTask DisposeAsync() => new ValueTask();
#endif
        public void Dispose() { }
    }
}
