namespace CreationalPatterns.Prototype.Domain
{
    public class Purchasable<T>
    {
        public Purchasable(T good, int price)
        {
            Good = good;
            Price = price;
        }

        public T Good { get; }
        public int Price { get; }
    }
}
