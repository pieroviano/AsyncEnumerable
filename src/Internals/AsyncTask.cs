using System.Threading.Tasks;

namespace System.Collections.Internals;

internal static class AsyncTask
{
    public static readonly Task<bool> True;
    public static readonly Task<bool> False;
    public static readonly Task Completed =
#if NETFX4_5 || NETFX4_5_2
        True;
#elif NET40 || NET35
        TaskEx.CompletedTask;
#else
        Task.CompletedTask;
#endif

    static AsyncTask()
    {
        var @true = new Task<bool>(() => true);
        @true.Start();
        True = @true;
        var @false = new Task<bool>(() => false);
        @false.Start();
        False = @false;
    }

    public static Task<T> FromException<T>(Exception ex)
    {
#if NETFX4_5 || NETFX4_5_2
        var tcs = new TaskCompletionSource<T>();
        tcs.SetException(ex);
        return tcs.Task;
#else
#if NET40|| NET35
        var fromException = new Task<T>(() => throw ex);
        fromException.Start();
        return fromException;
#else
        return Task.FromException<T>(ex);
#endif
#endif
    }
}