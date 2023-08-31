using System.Collections.Generic;

namespace Tests;

public partial class PerformanceTests
{
    public static IEnumerable<int> EnumerateNumbers()
    {
        for (int i = 0; i < 1000000; i++)
            yield return 1;
    }
}