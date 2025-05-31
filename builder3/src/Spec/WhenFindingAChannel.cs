using DesignPatterns.Builder3.Infrastructure.Read;
using FluentAssertions;

namespace DesignPatterns.Builder3.Spec;

[Collection("sqlite")]
public class WhenFindingAChannel
{
    #region Setup

    private readonly Channel _channel;
    private readonly IQueryHandler<FindDiscussion> _handler;
    private readonly SqliteContext _sqliteContext;

    public WhenFindingAChannel(SqliteContext sqliteContext)
    {
        _sqliteContext = sqliteContext;

        _handler = new FindDiscussionHandler(_sqliteContext);

        var builder = new Channel.Builder();
        var findDiscussion = new FindDiscussion(2000, builder);

        _handler.Execute(findDiscussion);

        _channel = builder.GetChannel();
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenMessagesAreInAscendingOrder() => _channel.Should().BeInAscendingOrder();

    #endregion
}
