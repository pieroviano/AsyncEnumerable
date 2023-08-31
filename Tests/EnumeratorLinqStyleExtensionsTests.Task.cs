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
}