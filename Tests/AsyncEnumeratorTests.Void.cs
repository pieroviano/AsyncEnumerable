using System;
using System.Threading.Tasks;
using CoreLibrary;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class AsyncEnumeratorTests
{
    [Test]
    public void RaceConditionOnEndOfEnumeration()
    {
        DoRaceConditionOnEndOfEnumeration().WaitForTask();
    }

    [Test]
    public void DisposeAfterPartialEnumeration()
    {
        new Func<Task>(DoDisposeAfterPartialEnumeration).Run().WaitForTask();
    }

    [Test]
    public void DisposeByGCAfterPartialEnumeration()
    {
        DoDisposeByGCAfterPartialEnumeration().WaitForTask();
    }

    [Test]
    public void DisposeWaitsForFinalization()
    {
        DoDisposeWaitsForFinalization().WaitForTask();
    }

    [Test]
    public void EnumerationMustEndAfterDispose()
    {
        DoEnumerationMustEndAfterDispose().WaitForTask();
    }

    [Test]
    public void YieldBreak()
    {
        DoYieldBreak().WaitForTask();
    }
}