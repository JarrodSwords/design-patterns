using DesignPatterns.Builder3.Blog.Domain;
using FluentAssertions;
using FluentAssertions.Execution;

namespace DesignPatterns.Builder3.Blog.Spec;

public class WhenBuildingAComment
{
    #region Setup

    private readonly Comment.Builder _builder = new();
    private readonly ICommentRepository _repository = ObjectProvider.CreateCommentRepository();

    #endregion

    #region Requirements

    [Fact]
    public void ThenTheCommentIsFullyAssembled()
    {
        _repository.Find(10, _builder);

        var comment = _builder.GetComment();

        using var scope = new AssertionScope();
        comment.Descendants.Should().Be(9);
        comment.Height.Should().Be(4);
    }

    #endregion
}
