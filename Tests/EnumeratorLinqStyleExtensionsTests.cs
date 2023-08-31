using NUnit.Framework;
using System;
using System.Collections;

namespace Tests;

public partial class EnumeratorLinqStyleExtensionsTests
{
    [Test]
    public void First_Empty()
    {
        var collection = AsyncEnumerable<int>.Empty;
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.FirstAsync());
    }

    [Test]
    public void First_Predicate_Empty()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.FirstAsync(x => x > 3));
    }

}