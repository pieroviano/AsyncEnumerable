using System.Threading;

namespace System.Collections.Internals;

internal static class CancellationTokenEx
{
    public static readonly CancellationToken Canceled;

    static CancellationTokenEx()
    {
        var cts = new CancellationTokenSource();
        cts.Cancel();
        Canceled = cts.Token;
    }
}