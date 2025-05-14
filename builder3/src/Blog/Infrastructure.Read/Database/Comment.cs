namespace DesignPatterns.Builder3.Blog.Infrastructure.Read.Database;

public record Comment(
    uint Id,
    uint? ParentId,
    uint PostId,
    uint RootId,
    uint UserId,
    string Text,
    DateTime Timestamp
);
