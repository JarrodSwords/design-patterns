namespace CreationalPatterns.AbstractFactory.Domain
{
    public class Contract
    {
        public Contract(Source source)
        {
            Source = source;
        }

        public Source Source { get; }
    }
}
