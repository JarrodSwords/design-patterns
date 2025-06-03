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
