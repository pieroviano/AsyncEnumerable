using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class AsyncEnumeratorTests
{
    [Test]
    public void RaceConditionOnEndOfEnumeration()
    {
        DoRaceConditionOnEndOfEnumeration().Wait();
    }

    [Test]
    public void DisposeAfterPartialEnumeration()
    {
        new Func<Task>(DoDisposeAfterPartialEnumeration).Run().Wait();
    }

    [Test]
    public void DisposeByGCAfterPartialEnumeration()
    {
        DoDisposeByGCAfterPartialEnumeration().Wait();
    }

    [Test]
    public void DisposeWaitsForFinalization()
    {
        DoDisposeWaitsForFinalization().Wait();
    }

    [Test]
    public void EnumerationMustEndAfterDispose()
    {
        DoEnumerationMustEndAfterDispose().Wait();
    }

    [Test]
    public void YieldBreak()
    {
        DoYieldBreak().Wait();
    }
}