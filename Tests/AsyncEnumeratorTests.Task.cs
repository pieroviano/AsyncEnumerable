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

    [Test]
    public async Task DisposeAfterPartialEnumeration()
    {
        await DoDisposeAfterPartialEnumeration();
    }

    [Test]
    public async Task DisposeByGCAfterPartialEnumeration()
    {
        await DoDisposeByGCAfterPartialEnumeration();
    }

    [Test]
    public async Task DisposeWaitsForFinalization()
    {
        await DoDisposeWaitsForFinalization();
    }

    [Test]
    public async Task EnumerationMustEndAfterDispose()
    {
        await DoEnumerationMustEndAfterDispose();
    }

    [Test]
    public async Task YieldBreak()
    {
        await DoYieldBreak();
    }
}