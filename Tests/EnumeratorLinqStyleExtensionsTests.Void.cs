using System.Threading.Tasks;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public partial class EnumeratorLinqStyleExtensionsTests
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
}