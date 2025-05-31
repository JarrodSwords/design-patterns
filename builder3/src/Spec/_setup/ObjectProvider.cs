using DesignPatterns.Builder3.Domain;
using User = DesignPatterns.Builder3.Infrastructure.Write.User;

namespace DesignPatterns.Builder3.Spec;

public class ObjectProvider
{
    public static IEnumerable<Message> GetMessages()
    {
        yield return new(10, 2000, 300, "Lorem ipsum dolor sit amet elit.", new(2025, 01, 01, 0, 1, 0));
        yield return new(11, 2000, 301, "Ex sapien vitae pellentesque sem in id.", new(2025, 01, 01, 0, 5, 0), 10);
        yield return new(12, 2000, 300, "Pretium tellus duis convallis leo eu.", new(2025, 01, 01, 0, 10, 0), 11);
        yield return new(13, 2000, 302, "Urna tempor pulvinar vivamus lacus nec.", new(2025, 01, 01, 0, 8, 0), 10);
        yield return new(14, 2000, 300, "Iaculis nisl lacinia integer nunc.", new(2025, 01, 01, 0, 19, 0), 13);
        yield return new(15, 2000, 304, "Semper class aptent taciti sociosqu.", new(2025, 01, 01, 0, 25, 0), 14);
        yield return new(16, 2000, 305, "Conubia nostra inceptos orci varius.", new(2025, 01, 01, 0, 26, 0), 13);
        yield return new(17, 2000, 303, "Dis montes nascetur ridiculus mus.", new(2025, 01, 01, 0, 12, 0), 10);
        yield return new(18, 2000, 306, "Nulla molestie mattis maximus eget.", new(2025, 01, 01, 0, 30, 0), 17);
        yield return new(19, 2000, 307, "Purus est efficitur laoreet mauris.", new(2025, 01, 01, 0, 35, 0), 17);
    }

    public static IEnumerable<User> GetUsers()
    {
        yield return new(300, "JohnDoe");
        yield return new(301, "JaneDoe");
        yield return new(302, "JeffDoe");
        yield return new(303, "JessDoe");
        yield return new(304, "JimDoe");
        yield return new(305, "JanDoe");
        yield return new(306, "JoanDoe");
        yield return new(307, "JerryDoe");
    }
}
