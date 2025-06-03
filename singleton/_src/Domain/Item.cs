namespace CreationalPatterns.Singleton.Domain
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }

        private Item(Item source)
        {
            Name = source.Name;
        }

        public string Name { get; }

        public Item Clone() => new Item(this);
    }
}
