using DesignPatterns.Builder3.Infrastructure.Read;
using FluentAssertions;
using Thread = DesignPatterns.Builder3.Infrastructure.Read.Thread;

namespace DesignPatterns.Builder3.Spec;

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
    public void ThenThreadIsPopulated() => _thread.Should().NotBeEmpty();

    #endregion
}
