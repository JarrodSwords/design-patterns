namespace DesignPatterns.Builder3.Infrastructure.Write;

public class User
{
    public User()
    {
    }

    public User(uint id, string name)
    {
        Id = id;
        Name = name;
    }

    public uint Id { get; set; }
    public string Name { get; set; }
}
