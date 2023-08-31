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

    [Test]
    public async Task SelectWithIndex()
    {
        await DoSelectWithIndex();
    }

    [Test]
    public async Task First()
    {
        await DoFirst();
    }

    [Test]
    public async Task First_Predicate()
    {
        await DoFirst_Predicate();
    }

    [Test]
    public async Task FirstOrDefault()
    {
        await DoFirstOrDefault();
    }

    [Test]
    public async Task FirstOrDefault_Empty()
    {
        await DoFirstOrDefault_Empty();
    }

    [Test]
    public async Task FirstOrDefault_Predicate()
    {
        await DoFirstOrDefault_Predicate();
    }

    [Test]
    public async Task FirstOrDefault_Predicate_Empty()
    {
        await DoFirstOrDefault_Predicate_Empty();
    }

    [Test]
    public async Task Take()
    {
        await DoTake();
    }

    [Test]
    public async Task Take_Zero()
    {
        await DoTake_Zero();
    }

    [Test]
    public async Task Take_More()
    {
        await DoTake_More();
    }

    [Test]
    public async Task TakeWhile()
    {
        await DoTakeWhile();
    }

    [Test]
    public async Task TakeWhile_None()
    {
        await DoTakeWhile_None();
    }

    [Test]
    public async Task TakeWhile_All()
    {
        await DoTakeWhile_All();
    }

    [Test]
    public async Task Skip()
    {
        await DoSkip();
    }

    [Test]
    public async Task Skip_Zero()
    {
        await DoSkip_Zero();
    }

    [Test]
    public async Task Skip_More()
    {
        await DoSkip_More();
    }

    [Test]
    public async Task SkipWhile()
    {
        await DoSkipWhile();
    }

    [Test]
    public async Task SkipWhile_None()
    {
        await DoSkipWhile_None();
    }

    [Test]
    public async Task SkipWhile_All()
    {
        await DoSkipWhile_All();
    }

    [Test]
    public async Task Where()
    {
        await DoWhere();
    }

    [Test]
    public async Task Where_None()
    {
        await DoWhere_None();
    }

    [Test]
    public async Task Where_All()
    {
        await DoWhere_All();
    }

    [Test]
    public async Task WhereWithIndex()
    {
        await DoWhereWithIndex();
    }

    [Test]
    public async Task SelectMany_Async()
    {
        await DoSelectMany_Async();
    }

    [Test]
    public async Task SelectMany_Async_Transform()
    {
        await DoSelectMany_Async_Transform();
    }

    [Test]
    public async Task SelectMany_Sync()
    {
        await DoSelectMany_Sync();
    }

    [Test]
    public async Task SelectMany_Sync_Transform()
    {
        await DoSelectMany_Sync_Transform();
    }

    [Test]
    public async Task Append()
    {
        await DoAppend();
    }

    [Test]
    public async Task Prepend()
    {
        await DoPrepend();
    }

#if !NETSTANDARD2_1 && !NETSTANDARD2_0 && !NET461
        [Test]
        public async Task OfType()
        {
            await DoOfType();
        }

#endif

    [Test]
    public async Task Concat()
    {
        await DoConcat();
    }

    [Test]
    public async Task ToDictionary()
    {
        await DoToDictionary();
    }

    [Test]
    public async Task ToDictionary_ValueSelector()
    {
        await DoToDictionary_ValueSelector();
    }

    [Test]
    public async Task ToDictionary_ValueSelector_WithComparer()
    {
        await DoToDictionary_ValueSelector_WithComparer();
    }

    [Test]
    public async Task Distinct()
    {
        await DoDistinct();
    }

    [Test]
    public async Task Distinct_WithComparer()
    {
        await DoDistinct_WithComparer();
    }

    [Test]
    public async Task Aggregate()
    {
        await DoAggregate();
    }

    [Test]
    public async Task Aggregate_Seed()
    {
        await DoAggregate_Seed();
    }

    [Test]
    public async Task Aggregate_Seed_ResultSelector()
    {
        await DoAggregate_Seed_ResultSelector();
    }

    [Test]
    public async Task ToLookup()
    {
        await DoToLookup();
    }

    [Test]
    public async Task ToLookup_ValueSelector()
    {
        await DoToLookup_ValueSelector();
    }

    [Test]
    public async Task ToLookup_ValueSelector_WithComparer()
    {
        await DoToLookup_ValueSelector_WithComparer();
    }

    [Test]
    public async Task All_NoElements()
    {
        await DoAll_NoElements();
    }

    [Test]
    public async Task All_False()
    {
        await DoAll_False();
    }

    [Test]
    public async Task All_True()
    {
        await DoAll_True();
    }

    [Test]
    public async Task Any_NoElements()
    {
        await DoAny_NoElements();
    }

    [Test]
    public async Task Any_True()
    {
        await DoAny_True();
    }

    [Test]
    public async Task Any_False()
    {
        await DoAny_False();
    }
}