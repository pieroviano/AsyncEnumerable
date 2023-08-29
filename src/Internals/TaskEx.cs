using System;
using System.Threading.Tasks;

namespace Dasync.Collections.Internals
{
    internal static class TaskEx
    {
        public static readonly Task<bool> True;
        public static readonly Task<bool> False;
        public static readonly Task Completed =
#if NETFX4_5 || NETFX4_5_2
            True;
#elif NET40

            System.Threading.Tasks.TaskEx.CompletedTask;
#else
            System.Threading.Tasks.Task.CompletedTask;
#endif

        static TaskEx()
        {
            var @true = new Task<bool>(()=>true);
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
#if NET40
            var fromException = new Task<T>(()=>throw ex);
            fromException.Start();
            return fromException;
#else
            return Task.FromException<T>(ex);
#endif
#endif
        }
    }
}