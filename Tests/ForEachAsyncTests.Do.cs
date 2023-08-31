using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

public partial class ForEachAsyncTests
{
    public static async Task DoSimpleAsyncForEachWithSyncBreak()
    {
        IAsyncEnumerable<int> enumerable = new AsyncEnumerable<int>(
            async yield =>
            {
                for (int i = 0; i < 5; i++)
                    await yield.ReturnAsync(i);
            });

        int counter = 0;
        await enumerable.ForEachAsync(
            number =>
            {
                Assert.AreEqual(counter, number);
                counter++;
                if (counter == 3) ForEachAsync.Break();
            });

        Assert.AreEqual(3, counter);
    }

    public static async Task DoSimpleAsyncForEachWithAsyncBreak()
    {
        IAsyncEnumerable<int> enumerable = new AsyncEnumerable<int>(
            async yield =>
            {
                for (int i = 0; i < 5; i++)
                    await yield.ReturnAsync(i);
            });

        int counter = 0;
        await enumerable.ForEachAsync(
            async number =>
            {
                Assert.AreEqual(counter, number);
                counter++;
                if (counter == 2) ForEachAsync.Break();
            });

        Assert.AreEqual(2, counter);
    }

    public static async Task DoSimpleAsyncForEach()
    {
        IAsyncEnumerable<int> enumerable = new AsyncEnumerable<int>(
            async yield =>
            {
                for (int i = 0; i < 5; i++)
                    await yield.ReturnAsync(i);
            });

        int counter = 0;
        await enumerable.ForEachAsync(
            number =>
            {
                Assert.AreEqual(counter, number);
                counter++;
            });

        Assert.AreEqual(5, counter);
    }

    public static async Task DoRethrowProducerException()
    {
        IAsyncEnumerable<int> enumerable = new AsyncEnumerable<int>(
            async yield => { throw new ArgumentException("test"); });

        try
        {
            await enumerable.ForEachAsync(
                number => { Assert.Fail("must never be called due to the exception"); });
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }

        Assert.Fail("Expected an exception to be thrown");
    }

    public static async Task DoRethrowConsumerException()
    {
        IAsyncEnumerable<int> enumerable = new AsyncEnumerable<int>(
            async yield => { await yield.ReturnAsync(123); });

        try
        {
            await enumerable.ForEachAsync(
                number => { throw new ArgumentException("test"); });
        }
        catch (ArgumentException)
        {
            Assert.Pass();
        }

        Assert.Fail("Expected an exception to be thrown");
    }
}