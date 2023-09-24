using System.Threading.Tasks;
using CoreLibrary;
using NUnit.Framework;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Tests;

[TestFixture]
public partial class ForEachAsyncTests
{
    [Test]
    public void SimpleAsyncForEachWithSyncBreak()
    {
        DoSimpleAsyncForEachWithSyncBreak().WaitForTask();
    }

    [Test]
    public void SimpleAsyncForEachWithAsyncBreak()
    {
        DoSimpleAsyncForEachWithAsyncBreak().WaitForTask();
    }

    [Test]
    public void SimpleAsyncForEach()
    {
        DoSimpleAsyncForEach().WaitForTask();
    }

    [Test]
    public void RethrowProducerException()
    {
        DoRethrowProducerException().WaitForTask();
    }

    [Test]
    public void RethrowConsumerException()
    {
        DoRethrowConsumerException().WaitForTask();
    }
}