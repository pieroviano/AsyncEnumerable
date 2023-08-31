using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class EnumerableLinqStyleExtensionsTests
{
    [Test]
    public async Task Select()
    {
        await DoSelect();
    }

    private static async Task DoSelect()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 1, 1 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.FirstAsync(x => x > 1);
        Assert.AreEqual(2, actualResult);
    }

    [Test]
    public void First_Predicate_Empty()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.FirstAsync(x => x > 3));
    }

    [Test]
    public async Task FirstOrDefault()
    {
        await DoFirstOrDefault();
    }

    private static async Task DoFirstOrDefault()
    {
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 3 }.ToAsyncEnumerable();
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
        var collection = new int[] { 1, 2, 1 }.ToAsyncEnumerable();
        var actualResult = await collection.Where((x, i) => (x + i) != 3).ToArrayAsync();
        var expectedResult = new int[] { 1 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task SelectMany_Async()
    {
        await DoSelectMany_Async();
    }

    private static async Task DoSelectMany_Async()
    {
        var collection1 = new int[] { 1, 2 }.ToAsyncEnumerable();
        var collection2 = new int[0].ToAsyncEnumerable();
        var collection3 = new int[] { 3, 4, 5 }.ToAsyncEnumerable();
        var set = new[] { collection1, collection2, collection3 }.ToAsyncEnumerable();
        var actualResult = await set.SelectMany(collection => collection).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3, 4, 5 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task SelectMany_Async_Transform()
    {
        await DoSelectMany_Async_Transform();
    }

    private static async Task DoSelectMany_Async_Transform()
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

    [Test]
    public async Task SelectMany_Sync()
    {
        await DoSelectMany_Sync();
    }

    private static async Task DoSelectMany_Sync()
    {
        var collection1 = new int[] { 1, 2 };
        var collection2 = new int[0];
        var collection3 = new int[] { 3, 4, 5 };
        var set = new[] { collection1, collection2, collection3 }.ToAsyncEnumerable();
        var actualResult = await set.SelectMany(collection => collection).ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3, 4, 5 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task SelectMany_Sync_Transform()
    {
        await DoSelectMany_Sync_Transform();
    }

    private static async Task DoSelectMany_Sync_Transform()
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

    [Test]
    public async Task Append()
    {
        await DoAppend();
    }

    private static async Task DoAppend()
    {
        var collection = new int[] { 1, 2 }.ToAsyncEnumerable();
        var extendedCollection = collection.Append(3);
        var actualResult = await extendedCollection.ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Prepend()
    {
        await DoPrepend();
    }

    private static async Task DoPrepend()
    {
        var collection = new int[] { 1, 2 }.ToAsyncEnumerable();
        var extendedCollection = collection.Prepend(0);
        var actualResult = await extendedCollection.ToArrayAsync();
        var expectedResult = new int[] { 0, 1, 2 };
        Assert.AreEqual(expectedResult, actualResult);
    }

#if !NETSTANDARD2_1 && !NETSTANDARD2_0 && !NET461
        [Test]
        public async Task OfType()
        {
            await DoOfType();
        }

        private static async Task DoOfType()
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
#endif

    [Test]
    public async Task Concat()
    {
        await DoConcat();
    }

    private static async Task DoConcat()
    {
        var collection1 = new int[] { 1 }.ToAsyncEnumerable();
        var collection2 = new int[] { 2, 3 }.ToAsyncEnumerable();
        var resultCollection = collection1.Concat(collection2);
        var actualResult = await resultCollection.ToArrayAsync();
        var expectedResult = new int[] { 1, 2, 3 };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task ToDictionary()
    {
        await DoToDictionary();
    }

    private static async Task DoToDictionary()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b") };
        var asyncCollection = collection.ToAsyncEnumerable();
        var actualDictionary = await asyncCollection.ToDictionaryAsync(x => x.key);
        Assert.IsNotNull(actualDictionary);
        Assert.AreEqual(actualDictionary[1], collection[0]);
        Assert.AreEqual(actualDictionary[2], collection[1]);
    }

    [Test]
    public async Task ToDictionary_ValueSelector()
    {
        await DoToDictionary_ValueSelector();
    }

    private static async Task DoToDictionary_ValueSelector()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b") };
        var asyncCollection = collection.ToAsyncEnumerable();
        var actualDictionary = await asyncCollection.ToDictionaryAsync(x => x.key, x => x.value);
        Assert.IsNotNull(actualDictionary);
        Assert.AreEqual(actualDictionary[1], "a");
        Assert.AreEqual(actualDictionary[2], "b");
    }

    [Test]
    public async Task ToDictionary_ValueSelector_WithComparer()
    {
        await DoToDictionary_ValueSelector_WithComparer();
    }

    private static async Task DoToDictionary_ValueSelector_WithComparer()
    {
        var collection = new (string key, int value)[] { ("a", 1), ("b", 2) };
        var asyncCollection = collection.ToAsyncEnumerable();
        var actualDictionary =
            await asyncCollection.ToDictionaryAsync(x => x.key, x => x.value, StringComparer.OrdinalIgnoreCase);
        Assert.IsNotNull(actualDictionary);
        Assert.AreEqual(actualDictionary["A"], 1);
        Assert.AreEqual(actualDictionary["B"], 2);
    }

    [Test]
    public async Task Distinct()
    {
        await DoDistinct();
    }

    private static async Task DoDistinct()
    {
        var collection = new[] { "a", "a", "A", "a" }.ToAsyncEnumerable();
        var actualResult = await collection.Distinct().ToArrayAsync();
        var expectedResult = new[] { "a", "A" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Distinct_WithComparer()
    {
        await DoDistinct_WithComparer();
    }

    private static async Task DoDistinct_WithComparer()
    {
        var collection = new[] { "a", "a", "A", "a" }.ToAsyncEnumerable();
        var actualResult = await collection.Distinct(StringComparer.OrdinalIgnoreCase).ToArrayAsync();
        var expectedResult = new[] { "a" };
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void Aggregate_NoElements()
    {
        var collection = new int[0].ToAsyncEnumerable();
        Assert.ThrowsAsync<InvalidOperationException>(() => collection.AggregateAsync((a, b) => a + b));
    }

    [Test]
    public async Task Aggregate()
    {
        await DoAggregate();
    }

    private static async Task DoAggregate()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AggregateAsync((a, b) => a + b);
        var expectedResult = 6;
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Aggregate_Seed()
    {
        await DoAggregate_Seed();
    }

    private static async Task DoAggregate_Seed()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AggregateAsync(-10, (a, b) => a + b);
        var expectedResult = -4;
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task Aggregate_Seed_ResultSelector()
    {
        await DoAggregate_Seed_ResultSelector();
    }

    private static async Task DoAggregate_Seed_ResultSelector()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AggregateAsync(10, (a, b) => a + b, x => x.ToString());
        var expectedResult = "16";
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public async Task ToLookup()
    {
        await DoToLookup();
    }

    private static async Task DoToLookup()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b"), (1, "c") }.ToAsyncEnumerable();
        var actualLookup = await collection.ToLookupAsync(x => x.key);
        Assert.IsNotNull(actualLookup);
        Assert.AreEqual(new[] { (1, "a"), (1, "c") }, actualLookup[1]);
        Assert.AreEqual(new[] { (2, "b") }, actualLookup[2]);
    }

    [Test]
    public async Task ToLookup_ValueSelector()
    {
        await DoToLookup_ValueSelector();
    }

    private static async Task DoToLookup_ValueSelector()
    {
        var collection = new (int key, string value)[] { (1, "a"), (2, "b"), (1, "c") }.ToAsyncEnumerable();
        var actualLookup = await collection.ToLookupAsync(x => x.key, x => x.value);
        Assert.IsNotNull(actualLookup);
        Assert.AreEqual(new[] { "a", "c" }, actualLookup[1]);
        Assert.AreEqual(new[] { "b" }, actualLookup[2]);
    }

    [Test]
    public async Task ToLookup_ValueSelector_WithComparer()
    {
        await DoToLookup_ValueSelector_WithComparer();
    }

    private static async Task DoToLookup_ValueSelector_WithComparer()
    {
        var collection = new (string key, int value)[] { ("a", 1), ("b", 2), ("A", 3) }.ToAsyncEnumerable();
        var actualLookup = await collection.ToLookupAsync(x => x.key, x => x.value, StringComparer.OrdinalIgnoreCase);
        Assert.IsNotNull(actualLookup);
        Assert.AreEqual(new[] { 1, 3 }, actualLookup["A"]);
        Assert.AreEqual(new[] { 2 }, actualLookup["b"]);
    }

    [Test]
    public async Task All_NoElements()
    {
        await DoAll_NoElements();
    }

    private static async Task DoAll_NoElements()
    {
        var collection = new bool[0].ToAsyncEnumerable();
        var actualResult = await collection.AllAsync(x => x);
        Assert.IsTrue(actualResult);
    }

    [Test]
    public async Task All_False()
    {
        await DoAll_False();
    }

    private static async Task DoAll_False()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AllAsync(x => x > 2);
        Assert.IsFalse(actualResult);
    }

    [Test]
    public async Task All_True()
    {
        await DoAll_True();
    }

    private static async Task DoAll_True()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AllAsync(x => x > 0);
        Assert.IsTrue(actualResult);
    }

    [Test]
    public async Task Any_NoElements()
    {
        await DoAny_NoElements();
    }

    private static async Task DoAny_NoElements()
    {
        var collection = new bool[0].ToAsyncEnumerable();
        var actualResult = await collection.AnyAsync(x => x);
        Assert.IsFalse(actualResult);
    }

    [Test]
    public async Task Any_True()
    {
        await DoAny_True();
    }

    private static async Task DoAny_True()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AnyAsync(x => x > 2);
        Assert.IsTrue(actualResult);
    }

    [Test]
    public async Task Any_False()
    {
        await DoAny_False();
    }

    private static async Task DoAny_False()
    {
        var collection = new[] { 1, 2, 3 }.ToAsyncEnumerable();
        var actualResult = await collection.AnyAsync(x => x > 4);
        Assert.IsFalse(actualResult);
    }
}