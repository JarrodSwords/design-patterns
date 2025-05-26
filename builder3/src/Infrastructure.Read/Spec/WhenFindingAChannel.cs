using FluentAssertions;

namespace DesignPatterns.Builder3.Infrastructure.Read.Spec;

public class WhenFindingAChannel
{
    #region Setup

    private readonly Channel _channel;
    private readonly IQueryHandler<FindDiscussion> _handler = new FindDiscussionHandler();

    public WhenFindingAChannel()
    {
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
