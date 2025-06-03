namespace Examples.SocialMedia.Infrastructure.Read.Database;

public class Message
{
    public uint Id { get; set; }
    public uint ContextId { get; set; }
    public uint? ParentId { get; set; }
    public uint UserId { get; set; }
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }
}
