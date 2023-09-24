using System.Threading.Tasks;
using CoreLibrary;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class EnumeratorLinqStyleExtensionsTests
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
}