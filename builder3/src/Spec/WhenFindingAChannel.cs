using DesignPatterns.Builder3.Infrastructure.Read;
using FluentAssertions;

namespace DesignPatterns.Builder3.Spec;

[Collection("database")]
public class WhenFindingAChannel
{
    #region Setup

    private readonly Channel _channel;
    private readonly DatabaseContext _context;
    private readonly IQueryHandler<FindDiscussion> _handler = new FindDiscussionHandler();

    public WhenFindingAChannel(DatabaseContext context)
    {
        _context = context;

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
