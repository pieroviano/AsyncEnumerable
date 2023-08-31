using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class EnumerableLinqStyleExtensionsTests
{
    [Test]
    public void Select()
    {
        DoSelect().Wait();
    }

    [Test]
    public void SelectWithIndex()
    {
        DoSelectWithIndex().Wait();
    }

    [Test]
    public void First()
    {
        DoFirst().Wait();
    }

    [Test]
    public void First_Predicate()
    {
        DoFirst_Predicate().Wait();
    }

    [Test]
    public void FirstOrDefault()
    {
        DoFirstOrDefault().Wait();
    }

    [Test]
    public void FirstOrDefault_Empty()
    {
        DoFirstOrDefault_Empty().Wait();
    }

    [Test]
    public void FirstOrDefault_Predicate()
    {
        DoFirstOrDefault_Predicate().Wait();
    }

    [Test]
    public void FirstOrDefault_Predicate_Empty()
    {
        DoFirstOrDefault_Predicate_Empty().Wait();
    }

    [Test]
    public void Take()
    {
        DoTake().Wait();
    }

    [Test]
    public void Take_Zero()
    {
        DoTake_Zero().Wait();
    }

    [Test]
    public void Take_More()
    {
        DoTake_More().Wait();
    }

    [Test]
    public void TakeWhile()
    {
        DoTakeWhile().Wait();
    }

    [Test]
    public void TakeWhile_None()
    {
        DoTakeWhile_None().Wait();
    }

    [Test]
    public void TakeWhile_All()
    {
        DoTakeWhile_All().Wait();
    }

    [Test]
    public void Skip()
    {
        DoSkip().Wait();
    }

    [Test]
    public void Skip_Zero()
    {
        DoSkip_Zero().Wait();
    }

    [Test]
    public void Skip_More()
    {
        DoSkip_More().Wait();
    }

    [Test]
    public void SkipWhile()
    {
        DoSkipWhile().Wait();
    }

    [Test]
    public void SkipWhile_None()
    {
        DoSkipWhile_None().Wait();
    }

    [Test]
    public void SkipWhile_All()
    {
        DoSkipWhile_All().Wait();
    }

    [Test]
    public void Where()
    {
        DoWhere().Wait();
    }

    [Test]
    public void Where_None()
    {
        DoWhere_None().Wait();
    }

    [Test]
    public void Where_All()
    {
        DoWhere_All().Wait();
    }

    [Test]
    public void WhereWithIndex()
    {
        DoWhereWithIndex().Wait();
    }

    [Test]
    public void SelectMany_Async()
    {
        DoSelectMany_Async().Wait();
    }

    [Test]
    public void SelectMany_Async_Transform()
    {
        DoSelectMany_Async_Transform().Wait();
    }

    [Test]
    public void SelectMany_Sync()
    {
        DoSelectMany_Sync().Wait();
    }

    [Test]
    public void SelectMany_Sync_Transform()
    {
        DoSelectMany_Sync_Transform().Wait();
    }

    [Test]
    public void Append()
    {
        DoAppend().Wait();
    }

    [Test]
    public void Prepend()
    {
        DoPrepend().Wait();
    }

#if !NETSTANDARD2_1 && !NETSTANDARD2_0 && !NET461
        [Test]
        public void OfType()
        {
            DoOfType().Wait();
        }

#endif

    [Test]
    public void Concat()
    {
        DoConcat().Wait();
    }

    [Test]
    public void ToDictionary()
    {
        DoToDictionary().Wait();
    }

    [Test]
    public void ToDictionary_ValueSelector()
    {
        DoToDictionary_ValueSelector().Wait();
    }

    [Test]
    public void ToDictionary_ValueSelector_WithComparer()
    {
        DoToDictionary_ValueSelector_WithComparer().Wait();
    }

    [Test]
    public void Distinct()
    {
        DoDistinct().Wait();
    }

    [Test]
    public void Distinct_WithComparer()
    {
        DoDistinct_WithComparer().Wait();
    }

    [Test]
    public void Aggregate()
    {
        DoAggregate().Wait();
    }

    [Test]
    public void Aggregate_Seed()
    {
        DoAggregate_Seed().Wait();
    }

    [Test]
    public void Aggregate_Seed_ResultSelector()
    {
        DoAggregate_Seed_ResultSelector().Wait();
    }

    [Test]
    public void ToLookup()
    {
        DoToLookup().Wait();
    }

    [Test]
    public void ToLookup_ValueSelector()
    {
        DoToLookup_ValueSelector().Wait();
    }

    [Test]
    public void ToLookup_ValueSelector_WithComparer()
    {
        DoToLookup_ValueSelector_WithComparer().Wait();
    }

    [Test]
    public void All_NoElements()
    {
        DoAll_NoElements().Wait();
    }

    [Test]
    public void All_False()
    {
        DoAll_False().Wait();
    }

    [Test]
    public void All_True()
    {
        DoAll_True().Wait();
    }

    [Test]
    public void Any_NoElements()
    {
        DoAny_NoElements().Wait();
    }

    [Test]
    public void Any_True()
    {
        DoAny_True().Wait();
    }

    [Test]
    public void Any_False()
    {
        DoAny_False().Wait();
    }
}