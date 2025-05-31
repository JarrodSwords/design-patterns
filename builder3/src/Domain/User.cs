namespace DesignPatterns.Builder3.Domain;

public class User(UserId id, string name)
{
    public UserId Id { get; } = id;
    public string Name { get; } = name;
}
