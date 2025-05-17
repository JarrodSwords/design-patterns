namespace DesignPatterns.Builder3.Blog.Infrastructure.Read;

public interface ICommentBuilder
{
    ICommentBuilder Add(Database.Comment record);
}
