namespace DesignPatterns.Prototype.Domain
{
    public class Purchasable<T>
    {
        #region Core

        public Purchasable(T good, int price)
        {
            Good = good;
            Price = price;
        }

        #endregion

        #region Public Interface

        public T Good { get; }
        public int Price { get; }

        #endregion
    }
}
