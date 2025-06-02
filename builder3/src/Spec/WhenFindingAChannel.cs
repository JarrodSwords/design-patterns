using DesignPatterns.Builder3.Infrastructure.Read;
using FluentAssertions;
using FluentAssertions.Execution;

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
    public void ThenChannelIsPopulated()
    {
        using var scope = new AssertionScope();

        _channel.Should().NotBeEmpty();
        _channel.Should().HaveCount(58);
    }

    [Fact]
    public void ThenMessagesAreInAscendingOrder() => _channel.Should().BeInAscendingOrder();

    #endregion
}
