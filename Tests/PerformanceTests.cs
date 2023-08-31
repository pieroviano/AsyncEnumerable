using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class PerformanceTests
{
    [Test]
    public async Task MeasureEnumerationTime()
    {
        await DoMeasureEnumerationTime();
    }
}