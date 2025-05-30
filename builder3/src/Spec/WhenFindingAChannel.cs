using DesignPatterns.Builder3.Infrastructure.Read;
using DesignPatterns.Builder3.Infrastructure.Write;
using FluentAssertions;

namespace DesignPatterns.Builder3.Spec;

[Collection("database")]
public class WhenFindingAChannel
{
    #region Setup

    private readonly Channel _channel;
    private readonly IQueryHandler<FindDiscussion> _handler;
    private readonly SqliteContext _sqliteContext;

    public WhenFindingAChannel(SqliteContext sqliteContext)
    {
        _sqliteContext = sqliteContext;

        _handler = new FindDiscussionHandler(
            _sqliteContext,
            new MessageRepository(_sqliteContext.GetContext())
        );

        var builder = new Channel.Builder();
        var findDiscussion = new FindDiscussion(10, builder);

        _handler.Execute(findDiscussion);

        _channel = builder.GetChannel();
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenMessagesAreInAscendingOrder() => _channel.Should().BeInAscendingOrder();

    #endregion
}
