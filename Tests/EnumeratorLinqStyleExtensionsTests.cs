using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class EnumeratorLinqStyleExtensionsTests
{
    [Test]
    public async Task Select()
    {
        await DoSelect();
    }

    private static async Task DoSelect()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Select(x => x.ToString()).ToArrayAsync();
        var expectedResult = new string[] { "1", "2", "3" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task SelectWithIndex()
    {
        await DoSelectWithIndex();
    }

    private static async Task DoSelectWithIndex()
    {
        var collection = new int[] { 1, 1, 1 }.GetAsyncEnumerator();
        var actualResult = await collection.Select((x, i) => x + i).ToArrayAsync();
        var expectedResult = new long[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task First()
    {
        await DoFirst();
    }

    private static async Task DoFirst()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstAsync();
        Assert.AreEqual(1, actualResult);
    }

    [Test]
    public void First_Empty()
    {
        var collection = AsyncEnumerable<int>.Empty;
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.FirstAsync());
    }

    [Test]
    public async Task First_Predicate()
    {
        await DoFirst_Predicate();
    }

    private static async Task DoFirst_Predicate()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstAsync(x => x > 1);
        Assert.AreEqual(2, actualResult);
    }

    [Test]
    public void First_Predicate_Empty()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.FirstAsync(x => x > 3));
    }

    [Test]
    public async Task FirstOrDefault()
    {
        await DoFirstOrDefault();
    }

    private static async Task DoFirstOrDefault()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstAsync();
        Assert.AreEqual(1, actualResult);
    }

    [Test]
    public async Task FirstOrDefault_Empty()
    {
        await DoFirstOrDefault_Empty();
    }

    private static async Task DoFirstOrDefault_Empty()
    {
        var collection = AsyncEnumerable<int>.Empty;
        var actualResult = await collection.FirstOrDefaultAsync();
        Assert.AreEqual(0, actualResult);
    }

    [Test]
    public async Task FirstOrDefault_Predicate()
    {
        await DoFirstOrDefault_Predicate();
    }

    private static async Task DoFirstOrDefault_Predicate()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstOrDefaultAsync(x => x > 1);
        Assert.AreEqual(2, actualResult);
    }

    [Test]
    public async Task FirstOrDefault_Predicate_Empty()
    {
        await DoFirstOrDefault_Predicate_Empty();
    }

    private static async Task DoFirstOrDefault_Predicate_Empty()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstOrDefaultAsync(x => x > 3);
        Assert.AreEqual(0, actualResult);
    }

    [Test]
    public async Task Take()
    {
        await DoTake();
    }

    private static async Task DoTake()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Take(2).ToArrayAsync();
        var expectedResult = new int[] { 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Take_Zero()
    {
        await DoTake_Zero();
    }

    private static async Task DoTake_Zero()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Take(0).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Take_More()
    {
        await DoTake_More();
    }

    private static async Task DoTake_More()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Take(int.MaxValue).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task TakeWhile()
    {
        await DoTakeWhile();
    }

    private static async Task DoTakeWhile()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.TakeWhile(x => x < 3).ToArrayAsync();
        var expectedResult = new int[] { 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task TakeWhile_None()
    {
        await DoTakeWhile_None();
    }

    private static async Task DoTakeWhile_None()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.TakeWhile(x => x < 1).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task TakeWhile_All()
    {
        await DoTakeWhile_All();
    }

    private static async Task DoTakeWhile_All()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.TakeWhile(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Skip()
    {
        await DoSkip();
    }

    private static async Task DoSkip()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Skip(2).ToArrayAsync();
        var expectedResult = new int[] { 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Skip_Zero()
    {
        await DoSkip_Zero();
    }

    private static async Task DoSkip_Zero()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Skip(0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Skip_More()
    {
        await DoSkip_More();
    }

    private static async Task DoSkip_More()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Skip(1000).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task SkipWhile()
    {
        await DoSkipWhile();
    }

    private static async Task DoSkipWhile()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.SkipWhile(x => x < 3).ToArrayAsync();
        var expectedResult = new int[] { 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task SkipWhile_None()
    {
        await DoSkipWhile_None();
    }

    private static async Task DoSkipWhile_None()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.SkipWhile(x => x > 3).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task SkipWhile_All()
    {
        await DoSkipWhile_All();
    }

    private static async Task DoSkipWhile_All()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.SkipWhile(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Where()
    {
        await DoWhere();
    }

    private static async Task DoWhere()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Where(x => x != 2).ToArrayAsync();
        var expectedResult = new int[] { 1, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Where_None()
    {
        await DoWhere_None();
    }

    private static async Task DoWhere_None()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Where(x => x > 3).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Where_All()
    {
        await DoWhere_All();
    }

    private static async Task DoWhere_All()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Where(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task WhereWithIndex()
    {
        await DoWhereWithIndex();
    }

    private static async Task DoWhereWithIndex()
    {
        var collection = new int[] { 1, 2, 1 }.GetAsyncEnumerator();
        var actualResult = await collection.Where((x, i) => (x + i) != 3).ToArrayAsync();
        var expectedResult = new int[] { 1 };
        Assert.AreEqual(expectedResult, actualResult);
    }
}