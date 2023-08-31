using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Tests;

[TestFixture]
public partial class ForEachAsyncTests
{
    [Test]
    public void SimpleAsyncForEachWithSyncBreak()
    {
        DoSimpleAsyncForEachWithSyncBreak().Wait();
    }

    [Test]
    public void SimpleAsyncForEachWithAsyncBreak()
    {
        DoSimpleAsyncForEachWithAsyncBreak().Wait();
    }

    [Test]
    public void SimpleAsyncForEach()
    {
        DoSimpleAsyncForEach().Wait();
    }

    [Test]
    public void RethrowProducerException()
    {
        DoRethrowProducerException().Wait();
    }

    [Test]
    public void RethrowConsumerException()
    {
        DoRethrowConsumerException().Wait();
    }
}