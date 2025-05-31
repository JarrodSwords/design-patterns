using DesignPatterns.Builder3.Infrastructure.Read;
using FluentAssertions;

namespace DesignPatterns.Builder3.Spec;

[Collection("sqlite")]
public class WhenFindingAChannel
{
    #region Setup

    private readonly Channel _channel;

    public WhenFindingAChannel(SqliteContext sqliteContext)
    {
        IQueryHandler<FindDiscussion> handler = new FindDiscussionHandler(sqliteContext);

        var builder = new Channel.Builder();
        var findDiscussion = new FindDiscussion(2000, builder);

        handler.Execute(findDiscussion);

        _channel = builder.GetChannel();
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenMessagesAreInAscendingOrder() => _channel.Should().BeInAscendingOrder();

    #endregion
}
