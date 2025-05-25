namespace DesignPatterns.Builder3.Infrastructure.Read.Database;

public record Message(
    uint Id,
    uint? ParentId,
    uint PostId,
    uint RootId,
    uint UserId,
    string Text,
    DateTime Timestamp
);
