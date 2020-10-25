namespace DesignPatterns.Builder.Domain
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}
