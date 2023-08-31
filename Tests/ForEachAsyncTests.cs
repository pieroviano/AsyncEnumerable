﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Tests;

[TestFixture]
public partial class ForEachAsyncTests
{
    [Test]
    public void SimpleSyncForEach()
    {
        IAsyncEnumerable<int> enumerable = new AsyncEnumerable<int>(
            async yield =>
            {
                for (int i = 0; i < 5; i++)
                    await yield.ReturnAsync(i);
            });

#pragma warning disable CS0612 // Type or member is obsolete
        int counter = 0;
        foreach (var number in enumerable.ToEnumerable())
        {
            Assert.AreEqual(counter, number);
            counter++;
        }
#pragma warning restore CS0612 // Type or member is obsolete
    }

    [Test]
    public async Task SimpleAsyncForEachWithSyncBreak()
    {
        await DoSimpleAsyncForEachWithSyncBreak();
    }

    private static async Task DoSimpleAsyncForEachWithSyncBreak()
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

    [Test]
    public async Task SimpleAsyncForEachWithAsyncBreak()
    {
        await DoSimpleAsyncForEachWithAsyncBreak();
    }

    private static async Task DoSimpleAsyncForEachWithAsyncBreak()
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

    [Test]
    public async Task SimpleAsyncForEach()
    {
        await DoSimpleAsyncForEach();
    }

    private static async Task DoSimpleAsyncForEach()
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

    [Test]
    public async Task RethrowProducerException()
    {
        await DoRethrowProducerException();
    }

    private static async Task DoRethrowProducerException()
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

    [Test]
    public async Task RethrowConsumerException()
    {
        await DoRethrowConsumerException();
    }

    private static async Task DoRethrowConsumerException()
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