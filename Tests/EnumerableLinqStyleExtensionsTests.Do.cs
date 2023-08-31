using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

public partial class EnumerableLinqStyleExtensionsTests
{
    public static async Task DoSelect()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Select(x => x.ToString()).ToArrayAsync();
        var expectedResult = new string[] { "1", "2", "3" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSelectWithIndex()
    {
        var collection = new int[] { 1, 1, 1 }.ToAsyncEnumerable();
        var actualResult = await collection.Select((x, i) => x + i).ToArrayAsync();
        var expectedResult = new long[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoFirst()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.FirstAsync();
        Assert.AreEqual(1, actualResult);
    }

    public static async Task DoFirst_Predicate()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.FirstAsync(x => x > 1);
        Assert.AreEqual(2, actualResult);
    }

    public static async Task DoFirstOrDefault()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.FirstOrDefaultAsync(x => x > 1);
        Assert.AreEqual(2, actualResult);
    }

    public static async Task DoFirstOrDefault_Predicate_Empty()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.FirstOrDefaultAsync(x => x > 3);
        Assert.AreEqual(0, actualResult);
    }

    public static async Task DoTake()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Take(2).ToArrayAsync();
        var expectedResult = new int[] { 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTake_Zero()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Take(0).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTake_More()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Take(int.MaxValue).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTakeWhile()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.TakeWhile(x => x < 3).ToArrayAsync();
        var expectedResult = new int[] { 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTakeWhile_None()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.TakeWhile(x => x < 1).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoTakeWhile_All()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.TakeWhile(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkip()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Skip(2).ToArrayAsync();
        var expectedResult = new int[] { 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkip_Zero()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Skip(0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkip_More()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Skip(1000).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkipWhile()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.SkipWhile(x => x < 3).ToArrayAsync();
        var expectedResult = new int[] { 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkipWhile_None()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.SkipWhile(x => x > 3).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSkipWhile_All()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.SkipWhile(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhere()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Where(x => x != 2).ToArrayAsync();
        var expectedResult = new int[] { 1, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhere_None()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Where(x => x > 3).ToArrayAsync();
        var expectedResult = new int[] { };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhere_All()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.Where(x => x > 0).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoWhereWithIndex()
    {
        var collection = new int[] { 1, 2, 1 }.ToAsyncEnumerable();
        var actualResult = await collection.Where((x, i) => (x + i) != 3).ToArrayAsync();
        var expectedResult = new int[] { 1 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSelectMany_Async()
    {
        var collection1 = new int[] { 1, 2 }.ToAsyncEnumerable();
        var collection2 = new int[0].ToAsyncEnumerable();
        var collection3 = new int[] { 3, 4, 5 }.ToAsyncEnumerable();
        var set = new[] { collection1, collection2, collection3 }.ToAsyncEnumerable();
        var actualResult = await set.SelectMany(collection => collection).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3, 4, 5 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSelectMany_Async_Transform()
    {
        var collection1 = new int[] { 1, 2 }.ToAsyncEnumerable();
        var collection2 = new int[] { 3, 4, 5 }.ToAsyncEnumerable();
        var set = new[] { collection1, collection2 }.ToAsyncEnumerable();
        var actualResult = await set.SelectMany(
                collectionSelector: collection => collection,
                resultSelector: (collection, item) => item.ToString())
            .ToArrayAsync();
        var expectedResult = new[] { "1", "2", "3", "4", "5" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSelectMany_Sync()
    {
        var collection1 = new int[] { 1, 2 };
        var collection2 = new int[0];
        var collection3 = new int[] { 3, 4, 5 };
        var set = new[] { collection1, collection2, collection3 }.ToAsyncEnumerable();
        var actualResult = await set.SelectMany(collection => collection).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3, 4, 5 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoSelectMany_Sync_Transform()
    {
        var collection1 = new int[] { 1, 2 };
        var collection2 = new int[] { 3, 4, 5 };
        var set = new[] { collection1, collection2 }.ToAsyncEnumerable();
        var actualResult = await set.SelectMany(
                collectionSelector: collection => collection,
                resultSelector: (collection, item) => item.ToString())
            .ToArrayAsync();
        var expectedResult = new[] { "1", "2", "3", "4", "5" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoAppend()
    {
        var collection = new int[] { 1, 2 }.ToAsyncEnumerable();
        var extendedCollection = collection.Append(3);
        var actualResult = await extendedCollection.ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoPrepend()
    {
        var collection = new int[] { 1, 2 }.ToAsyncEnumerable();
        var extendedCollection = collection.Prepend(0);
        var actualResult = await extendedCollection.ToArrayAsync();
        var expectedResult = new int[] { 0, 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoOfType()
    {
        var collection = new object[] { "a", 1, "b", Guid.NewGuid() };
        var asyncCollection = (IAsyncEnumerable)collection.ToAsyncEnumerable();

        var filteredStringCollection = asyncCollection.OfType<string>();
        var actualStringResult = await filteredStringCollection.ToArrayAsync();
        var expectedStringResult = new[] { "a", "b" };
        Assert.AreEqual(expectedStringResult, actualStringResult);

        var filteredIntegerCollection = asyncCollection.OfType<int>();
        var actualIntegerResult = await filteredIntegerCollection.ToArrayAsync();
        var expectedIntegerResult = new[] { 1 };
        Assert.AreEqual(expectedIntegerResult, actualIntegerResult);

        var filteredUriCollection = asyncCollection.OfType<Uri>();
        var actualUriResult = await filteredUriCollection.ToArrayAsync();
        var expectedUriResult = new Uri[0];
        Assert.AreEqual(expectedUriResult, actualUriResult);

        var filteredObjectCollection = asyncCollection.OfType<object>();
        var actualObjectResult = await filteredObjectCollection.ToArrayAsync();
        var expectedObjectResult = collection;
        Assert.AreEqual(expectedObjectResult, actualObjectResult);
    }

    public static async Task DoConcat()
    {
        var collection1 = new int[] { 1 }.ToAsyncEnumerable();
        var collection2 = new int[] { 2, 3 }.ToAsyncEnumerable();
        var resultCollection = collection1.Concat(collection2);
        var actualResult = await resultCollection.ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoToDictionary()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b") };
        var asyncCollection = collection.ToAsyncEnumerable();
        var actualDictionary = await asyncCollection.ToDictionaryAsync(x => x.key);
        Assert.IsNotNull(actualDictionary);
        Assert.AreEqual(actualDictionary[1], collection[0]);
        Assert.AreEqual(actualDictionary[2], collection[1]);
    }

    public static async Task DoToDictionary_ValueSelector()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b") };
        var asyncCollection = collection.ToAsyncEnumerable();
        var actualDictionary = await asyncCollection.ToDictionaryAsync(x => x.key, x => x.value);
        Assert.IsNotNull(actualDictionary);
        Assert.AreEqual(actualDictionary[1], "a");
        Assert.AreEqual(actualDictionary[2], "b");
    }

    public static async Task DoToDictionary_ValueSelector_WithComparer()
    {
        var collection = new (string key, int value)[] { ("a", 1), ("b", 2) };
        var asyncCollection = collection.ToAsyncEnumerable();
        var actualDictionary =
            await asyncCollection.ToDictionaryAsync(x => x.key, x => x.value, StringComparer.OrdinalIgnoreCase);
        Assert.IsNotNull(actualDictionary);
        Assert.AreEqual(actualDictionary["A"], 1);
        Assert.AreEqual(actualDictionary["B"], 2);
    }

    public static async Task DoDistinct()
    {
        var collection = new[] { "a", "a", "A", "a" }.ToAsyncEnumerable();
        var actualResult = await collection.Distinct().ToArrayAsync();
        var expectedResult = new[] { "a", "A" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoDistinct_WithComparer()
    {
        var collection = new[] { "a", "a", "A", "a" }.ToAsyncEnumerable();
        var actualResult = await collection.Distinct(StringComparer.OrdinalIgnoreCase).ToArrayAsync();
        var expectedResult = new[] { "a" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoAggregate()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AggregateAsync((a, b) => a + b);
        var expectedResult = 6;
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoAggregate_Seed()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AggregateAsync(-10, (a, b) => a + b);
        var expectedResult = -4;
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoAggregate_Seed_ResultSelector()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AggregateAsync(10, (a, b) => a + b, x => x.ToString());
        var expectedResult = "16";
        Assert.AreEqual(expectedResult, actualResult);
    }

    public static async Task DoToLookup()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b"), (1, "c") }.ToAsyncEnumerable();
        var actualLookup = await collection.ToLookupAsync(x => x.key);
        Assert.IsNotNull(actualLookup);
        Assert.AreEqual(new[] { (1, "a"), (1, "c") }, actualLookup[1]);
        Assert.AreEqual(new[] { (2, "b") }, actualLookup[2]);
    }

    public static async Task DoToLookup_ValueSelector()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b"), (1, "c") }.ToAsyncEnumerable();
        var actualLookup = await collection.ToLookupAsync(x => x.key, x => x.value);
        Assert.IsNotNull(actualLookup);
        Assert.AreEqual(new[] { "a", "c" }, actualLookup[1]);
        Assert.AreEqual(new[] { "b" }, actualLookup[2]);
    }

    public static async Task DoToLookup_ValueSelector_WithComparer()
    {
        var collection = new (string key, int value)[] { ("a", 1), ("b", 2), ("A", 3) }.ToAsyncEnumerable();
        var actualLookup = await collection.ToLookupAsync(x => x.key, x => x.value, StringComparer.OrdinalIgnoreCase);
        Assert.IsNotNull(actualLookup);
        Assert.AreEqual(new[] { 1, 3 }, actualLookup["A"]);
        Assert.AreEqual(new[] { 2 }, actualLookup["b"]);
    }

    public static async Task DoAll_NoElements()
    {
        var collection = new bool[0].ToAsyncEnumerable();
        var actualResult = await collection.AllAsync(x => x);
        Assert.IsTrue(actualResult);
    }

    public static async Task DoAll_False()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AllAsync(x => x > 2);
        Assert.IsFalse(actualResult);
    }

    public static async Task DoAll_True()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AllAsync(x => x > 0);
        Assert.IsTrue(actualResult);
    }

    public static async Task DoAny_NoElements()
    {
        var collection = new bool[0].ToAsyncEnumerable();
        var actualResult = await collection.AnyAsync(x => x);
        Assert.IsFalse(actualResult);
    }

    public static async Task DoAny_True()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AnyAsync(x => x > 2);
        Assert.IsTrue(actualResult);
    }

    public static async Task DoAny_False()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AnyAsync(x => x > 4);
        Assert.IsFalse(actualResult);
    }
}