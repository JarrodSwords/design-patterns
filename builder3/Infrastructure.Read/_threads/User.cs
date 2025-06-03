namespace Examples.SocialMedia.Infrastructure.Read;

public record User(uint Id, string Name)
{
    public static implicit operator User(Database.User source) => new(source.Id, source.Name);
}
