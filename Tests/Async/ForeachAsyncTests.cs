#if NET45 || NET6_0
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests.Async;

[TestFixture]
public class ForeachAsyncTests
{

    [Test]
    public async Task TestForeachAsync()
    {
        var ints = new int[]{1,2,3,4,5};
        await ints.ToAsyncEnumerable().ForEachAsync((i) =>
        {
            ints[i - 1] = -i;
        });
        Assert.IsTrue(ints.All(i=>i<0));
    }
}
#endif