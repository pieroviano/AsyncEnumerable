using System.Threading.Tasks;
using CoreLibrary;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class EnumerableLinqStyleExtensionsTests
{
    [Test]
    public void Select()
    {
        DoSelect().WaitForTask();
    }

    [Test]
    public void SelectWithIndex()
    {
        DoSelectWithIndex().WaitForTask();
    }

    [Test]
    public void First()
    {
        DoFirst().WaitForTask();
    }

    [Test]
    public void First_Predicate()
    {
        DoFirst_Predicate().WaitForTask();
    }

    [Test]
    public void FirstOrDefault()
    {
        DoFirstOrDefault().WaitForTask();
    }

    [Test]
    public void FirstOrDefault_Empty()
    {
        DoFirstOrDefault_Empty().WaitForTask();
    }

    [Test]
    public void FirstOrDefault_Predicate()
    {
        DoFirstOrDefault_Predicate().WaitForTask();
    }

    [Test]
    public void FirstOrDefault_Predicate_Empty()
    {
        DoFirstOrDefault_Predicate_Empty().WaitForTask();
    }

    [Test]
    public void Take()
    {
        DoTake().WaitForTask();
    }

    [Test]
    public void Take_Zero()
    {
        DoTake_Zero().WaitForTask();
    }

    [Test]
    public void Take_More()
    {
        DoTake_More().WaitForTask();
    }

    [Test]
    public void TakeWhile()
    {
        DoTakeWhile().WaitForTask();
    }

    [Test]
    public void TakeWhile_None()
    {
        DoTakeWhile_None().WaitForTask();
    }

    [Test]
    public void TakeWhile_All()
    {
        DoTakeWhile_All().WaitForTask();
    }

    [Test]
    public void Skip()
    {
        DoSkip().WaitForTask();
    }

    [Test]
    public void Skip_Zero()
    {
        DoSkip_Zero().WaitForTask();
    }

    [Test]
    public void Skip_More()
    {
        DoSkip_More().WaitForTask();
    }

    [Test]
    public void SkipWhile()
    {
        DoSkipWhile().WaitForTask();
    }

    [Test]
    public void SkipWhile_None()
    {
        DoSkipWhile_None().WaitForTask();
    }

    [Test]
    public void SkipWhile_All()
    {
        DoSkipWhile_All().WaitForTask();
    }

    [Test]
    public void Where()
    {
        DoWhere().WaitForTask();
    }

    [Test]
    public void Where_None()
    {
        DoWhere_None().WaitForTask();
    }

    [Test]
    public void Where_All()
    {
        DoWhere_All().WaitForTask();
    }

    [Test]
    public void WhereWithIndex()
    {
        DoWhereWithIndex().WaitForTask();
    }

    [Test]
    public void SelectMany_Async()
    {
        DoSelectMany_Async().WaitForTask();
    }

    [Test]
    public void SelectMany_Async_Transform()
    {
        DoSelectMany_Async_Transform().WaitForTask();
    }

    [Test]
    public void SelectMany_Sync()
    {
        DoSelectMany_Sync().WaitForTask();
    }

    [Test]
    public void SelectMany_Sync_Transform()
    {
        DoSelectMany_Sync_Transform().WaitForTask();
    }

    [Test]
    public void Append()
    {
        DoAppend().WaitForTask();
    }

    [Test]
    public void Prepend()
    {
        DoPrepend().WaitForTask();
    }

#if !NETSTANDARD2_1 && !NETSTANDARD2_0 && !NET461
        [Test]
        public void OfType()
        {
            DoOfType().WaitForTask();
        }

#endif

    [Test]
    public void Concat()
    {
        DoConcat().WaitForTask();
    }

    [Test]
    public void ToDictionary()
    {
        DoToDictionary().WaitForTask();
    }

    [Test]
    public void ToDictionary_ValueSelector()
    {
        DoToDictionary_ValueSelector().WaitForTask();
    }

    [Test]
    public void ToDictionary_ValueSelector_WithComparer()
    {
        DoToDictionary_ValueSelector_WithComparer().WaitForTask();
    }

    [Test]
    public void Distinct()
    {
        DoDistinct().WaitForTask();
    }

    [Test]
    public void Distinct_WithComparer()
    {
        DoDistinct_WithComparer().WaitForTask();
    }

    [Test]
    public void Aggregate()
    {
        DoAggregate().WaitForTask();
    }

    [Test]
    public void Aggregate_Seed()
    {
        DoAggregate_Seed().WaitForTask();
    }

    [Test]
    public void Aggregate_Seed_ResultSelector()
    {
        DoAggregate_Seed_ResultSelector().WaitForTask();
    }

    [Test]
    public void ToLookup()
    {
        DoToLookup().WaitForTask();
    }

    [Test]
    public void ToLookup_ValueSelector()
    {
        DoToLookup_ValueSelector().WaitForTask();
    }

    [Test]
    public void ToLookup_ValueSelector_WithComparer()
    {
        DoToLookup_ValueSelector_WithComparer().WaitForTask();
    }

    [Test]
    public void All_NoElements()
    {
        DoAll_NoElements().WaitForTask();
    }

    [Test]
    public void All_False()
    {
        DoAll_False().WaitForTask();
    }

    [Test]
    public void All_True()
    {
        DoAll_True().WaitForTask();
    }

    [Test]
    public void Any_NoElements()
    {
        DoAny_NoElements().WaitForTask();
    }

    [Test]
    public void Any_True()
    {
        DoAny_True().WaitForTask();
    }

    [Test]
    public void Any_False()
    {
        DoAny_False().WaitForTask();
    }
}