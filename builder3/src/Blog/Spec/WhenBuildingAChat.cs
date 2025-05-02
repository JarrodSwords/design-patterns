using DesignPatterns.Builder3.Blog.Domain;
using FluentAssertions;
using FluentAssertions.Execution;

namespace DesignPatterns.Builder3.Blog.Spec;

public class WhenBuildingAChat
{
    #region Setup

    private readonly Chat.Builder _builder = new();
    private readonly ICommentRepository _repository = ObjectProvider.CreateCommentRepository();

    #endregion

    #region Requirements

    [Fact]
    public void ThenTheChatIsFullyAssembled()
    {
        _repository.Find(10, _builder);

        var chat = _builder.GetChat();

        using var scope = new AssertionScope();
        chat.Messages.Should().HaveCount(10);
        chat.Messages.Should().BeInAscendingOrder(x => x.Timestamp);
    }

    #endregion
}
