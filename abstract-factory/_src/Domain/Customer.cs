namespace CreationalPatterns.AbstractFactory.Domain
{
    public class Customer
    {
        public Customer(Source source)
        {
            Source = source;
        }

        public Source Source { get; }
    }
}
