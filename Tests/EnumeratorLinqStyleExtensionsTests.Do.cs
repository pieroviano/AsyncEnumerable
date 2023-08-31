using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

public partial class EnumeratorLinqStyleExtensionsTests
{
    public static async Task DoSelect()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Select(x => x.ToString()).ToArrayAsync();
        var expectedResult = new string[] { "1", "2", "3" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSelectWithIndex()
    {
        var collection = new int[] { 1, 1, 1 }.GetAsyncEnumerator();
        var actualResult = await collection.Select((x, i) => x + i).ToArrayAsync();
        var expectedResult = new long[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoFirst()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstAsync();
        Assert.AreEqual(1, actualResult);
    }

    public static async Task DoFirst_Predicate()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstAsync(x => x > 1);
        Assert.AreEqual(2, actualResult);
    }

    public static async Task DoFirstOrDefault()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstAsync();
        Assert.AreEqual(1, actualResult);
    }

    public static async Task DoFirstOrDefault_Empty()
    {
        var collection = AsyncEnumerable<int>.Empty;
        var actualResult = await collection.FirstOrDefaultAsync();
        Assert.AreEqual(0, actualResult);
    }

    public static async Task DoFirstOrDefault_Predicate()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstOrDefaultAsync(x => x > 1);
        Assert.AreEqual(2, actualResult);
    }

    public static async Task DoFirstOrDefault_Predicate_Empty()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.FirstOrDefaultAsync(x => x > 3);
        Assert.AreEqual(0, actualResult);
    }

    public static async Task DoTake()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Take(2).ToArrayAsync();
        var expectedResult = new int[] { 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTake_Zero()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Take(0).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTake_More()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Take(int.MaxValue).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTakeWhile()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.TakeWhile(x => x < 3).ToArrayAsync();
        var expectedResult = new int[] { 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTakeWhile_None()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.TakeWhile(x => x < 1).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTakeWhile_All()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.TakeWhile(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkip()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Skip(2).ToArrayAsync();
        var expectedResult = new int[] { 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkip_Zero()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Skip(0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkip_More()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Skip(1000).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkipWhile()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.SkipWhile(x => x < 3).ToArrayAsync();
        var expectedResult = new int[] { 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkipWhile_None()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.SkipWhile(x => x > 3).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkipWhile_All()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.SkipWhile(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhere()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Where(x => x != 2).ToArrayAsync();
        var expectedResult = new int[] { 1, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhere_None()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Where(x => x > 3).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhere_All()
    {
        var collection = new int[] { 1, 2, 3 }.GetAsyncEnumerator();
        var actualResult = await collection.Where(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhereWithIndex()
    {
        var collection = new int[] { 1, 2, 1 }.GetAsyncEnumerator();
        var actualResult = await collection.Where((x, i) => (x + i) != 3).ToArrayAsync();
        var expectedResult = new int[] { 1 };
        Assert.AreEqual(expectedResult, actualResult);
    }
}