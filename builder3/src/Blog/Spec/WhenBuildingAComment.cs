using DesignPatterns.Builder3.Blog.Domain;
using DesignPatterns.Builder3.Blog.Infrastructure;
using FluentAssertions;
using FluentAssertions.Execution;
using Comment = DesignPatterns.Builder3.Blog.Domain.Comment;

namespace DesignPatterns.Builder3.Blog.Spec;

public class WhenBuildingAComment
{
    #region Implementation

    private IEnumerable<Infrastructure.Comment> GetSeed()
    {
        yield return new(10, null, 2000, 10, 300, "Lorem ipsum dolor sit amet adipiscing elit.", new(2025, 01, 01));
        yield return new(11, 10, 2000, 10, 301, "Ex sapien vitae pellentesque sem placerat in id.", new(2025, 01, 01));
        yield return new(12, 11, 2000, 10, 300, "Pretium tellus duis convallis tempus leo eu.", new(2025, 01, 01));
        yield return new(13, 10, 2000, 10, 302, "Urna tempor pulvinar vivamus lacus nec metus.", new(2025, 01, 01));
        yield return new(14, 13, 2000, 10, 300, "Iaculis massa nisl lacinia integer nunc posuere.", new(2025, 01, 01));
        yield return new(15, 14, 2000, 10, 304, "Semper vel class aptent taciti sociosqu ad.", new(2025, 01, 01));
        yield return new(16, 13, 2000, 10, 305, "Conubia nostra inceptos orci varius penatibus.", new(2025, 01, 01));
        yield return new(17, 10, 2000, 10, 303, "Dis montes nascetur ridiculus mus donec rhoncus.", new(2025, 01, 01));
        yield return new(18, 17, 2000, 10, 306, "Nulla molestie mattis maximus eget fermentum.", new(2025, 01, 01));
        yield return new(19, 17, 2000, 10, 307, "Purus est efficitur laoreet mauris pharetra.", new(2025, 01, 01));
    }

    #endregion

    #region Requirements

    [Fact]
    public void ThenTheCommentIsFullyAssembled()
    {
        var builder = new Comment.Builder();

        new CommentRepository()
            .Seed(GetSeed())
            .Configure(builder)
            .Find((CommentId) 10);

        var comment = builder.GetComment();

        using var scope = new AssertionScope();
        comment.Descendants.Should().Be(9);
        comment.Height.Should().Be(4);
    }

    #endregion
}
