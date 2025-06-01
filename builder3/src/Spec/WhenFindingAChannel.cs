using DesignPatterns.Builder3.Infrastructure.Read;
using FluentAssertions;

namespace DesignPatterns.Builder3.Spec;

[Collection("sqlite")]
public class WhenFindingAChannel
{
    #region Setup

    private readonly Channel _channel = new();

    public WhenFindingAChannel(SqliteContext sqliteContext)
    {
        var findDiscussion = new FindDiscussion(2000, _channel);
        var handler = new FindDiscussionHandler(sqliteContext);

        handler.Execute(findDiscussion);
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenChannelIsPopulated() => _channel.Should().NotBeEmpty();

    [Fact]
    public void ThenMessagesAreInAscendingOrder() => _channel.Should().BeInAscendingOrder();

    #endregion
}
