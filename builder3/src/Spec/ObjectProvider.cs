using DesignPatterns.Builder3.Domain;
using DesignPatterns.Builder3.Infrastructure.Write;
using Comment = DesignPatterns.Builder3.Infrastructure.Write.Comment;

namespace DesignPatterns.Builder3.Spec;

public class ObjectProvider
{
    public static ICommentRepository CreateCommentRepository(bool seed = true) =>
        seed
            ? new CommentRepository().Seed(GetSampleComments())
            : new CommentRepository();

    public static IEnumerable<Comment> GetSampleComments()
    {
        yield return new(10, null, 2000, 10, 300, "Lorem ipsum dolor sit amet elit.", new(2025, 01, 01, 0, 1, 0));
        yield return new(11, 10, 2000, 10, 301, "Ex sapien vitae pellentesque sem in id.", new(2025, 01, 01, 0, 5, 0));
        yield return new(12, 11, 2000, 10, 300, "Pretium tellus duis convallis leo eu.", new(2025, 01, 01, 0, 10, 0));
        yield return new(13, 10, 2000, 10, 302, "Urna tempor pulvinar vivamus lacus nec.", new(2025, 01, 01, 0, 8, 0));
        yield return new(14, 13, 2000, 10, 300, "Iaculis nisl lacinia integer nunc.", new(2025, 01, 01, 0, 19, 0));
        yield return new(15, 14, 2000, 10, 304, "Semper class aptent taciti sociosqu.", new(2025, 01, 01, 0, 25, 0));
        yield return new(16, 13, 2000, 10, 305, "Conubia nostra inceptos orci varius.", new(2025, 01, 01, 0, 26, 0));
        yield return new(17, 10, 2000, 10, 303, "Dis montes nascetur ridiculus mus.", new(2025, 01, 01, 0, 12, 0));
        yield return new(18, 17, 2000, 10, 306, "Nulla molestie mattis maximus eget.", new(2025, 01, 01, 0, 30, 0));
        yield return new(19, 17, 2000, 10, 307, "Purus est efficitur laoreet mauris.", new(2025, 01, 01, 0, 35, 0));
    }
}
