namespace CreationalPatterns.Prototype.Domain
{
    /// <summary>
    ///     Prototype
    /// </summary>
    public abstract class Item
    {
        protected Item(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract Item Clone();
    }
}
