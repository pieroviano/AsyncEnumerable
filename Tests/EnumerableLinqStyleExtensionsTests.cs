﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary;

namespace Tests;

public partial class EnumerableLinqStyleExtensionsTests
{
    [Test]
    public void First_Empty()
    {
        var collection = AsyncEnumerable<int>.Empty;
#if NET35 || NET40
        Assert.Throws<InvalidOperationException>(() => collection.FirstAsync().WaitForTask());
#else
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.FirstAsync());
#endif
    }

    [Test]
    public void First_Predicate_Empty()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
#if NET35 || NET40
        Assert.Throws<InvalidOperationException>(() => collection.FirstAsync(x => x > 3).WaitForTask());
#else
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.FirstAsync(x => x > 3));
#endif
    }

    [Test]
    public void Aggregate_NoElements()
    {
        var collection = new int[0].ToAsyncEnumerable();
#if NET35 || NET40
        Assert.Throws<InvalidOperationException>(() => collection.AggregateAsync((a, b) => a + b).WaitForTask());
#else
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.AggregateAsync((a, b) => a + b));
#endif
    }
}