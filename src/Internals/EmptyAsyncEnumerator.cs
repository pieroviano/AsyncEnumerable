using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Collections.Internals;

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

#if NET40 || NET35
    public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(()=>false);

    public Task DisposeAsync() => AsyncTask.Completed;
#else
        public ValueTask<bool> MoveNextAsync() => new ValueTask<bool>(false);

        public ValueTask DisposeAsync() => new ValueTask();
#endif
    public void Dispose() { }
}