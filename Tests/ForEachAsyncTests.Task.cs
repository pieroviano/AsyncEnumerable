using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Tests;

[TestFixture]
public partial class ForEachAsyncTests
{
    [Test]
    public async Task SimpleAsyncForEachWithSyncBreak()
    {
        await DoSimpleAsyncForEachWithSyncBreak();
    }

    [Test]
    public async Task SimpleAsyncForEachWithAsyncBreak()
    {
        await DoSimpleAsyncForEachWithAsyncBreak();
    }

    [Test]
    public async Task SimpleAsyncForEach()
    {
        await DoSimpleAsyncForEach();
    }

    [Test]
    public async Task RethrowProducerException()
    {
        await DoRethrowProducerException();
    }

    [Test]
    public async Task RethrowConsumerException()
    {
        await DoRethrowConsumerException();
    }
}