using Examples.SocialMedia.Infrastructure.Read;
using FluentAssertions;
using Thread = Examples.SocialMedia.Infrastructure.Read.Thread;

namespace Examples.SocialMedia.Spec;

[Collection("sqlite")]
public class WhenFindingAThread
{
    #region Setup

    private readonly Thread _thread = new();

    public WhenFindingAThread(SqliteContext sqliteContext)
    {
        var builder = new Comment.Builder(_thread);
        var findDiscussion = new FindDiscussion(2000, builder);
        var handler = new FindDiscussionHandler(sqliteContext);

        handler.Execute(findDiscussion);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenCommentsAreInAscendingOrder() => _thread.Should().BeInAscendingOrder();

    [Fact]
    public void ThenThreadHasExpectedTopLevelComments() => _thread.Should().HaveCount(13);

    [Fact]
    public void ThenThreadIsPopulated() => _thread.Should().NotBeEmpty();

    #endregion
}

public class WhenBat
{
    #region Requirements

    [Fact]
    public void WithEvenCount_ThenBazIsTrue()
    {
        var foo = new Foo();
        var bar = new Bar(126);

        foo.Bat(bar);

        bar.Count = 125;

        //foo.Bat(bar);

        foo.Baz.Should().BeTrue();
    }

    #endregion
}

public class Foo
{
    private Bar _bar;

    public bool Baz => _bar.Count % 2 == 0;

    public void Bat(Bar bar)
    {
        _bar = bar;
    }
}

public class Bar
{
    public Bar(int count)
    {
        Count = count;
    }

    public int Count { get; set; }
}

public class WhenAdding
{
    #region Requirements

    [Theory]
    [InlineData(1, 3, 4)]
    [InlineData(6, 23594, 23600)]
    public void ThenReturnSum(int left, int right, int expected)
    {
        var calculator = new Calculator();

        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);
        calculator.Add(left, right);

        calculator.Sum.Should().Be(expected);
    }

    #endregion
}

public class Calculator
{
    public int Sum { get; private set; }

    public void Add(int left, int right)
    {
        Sum = left + right;
    }
}
