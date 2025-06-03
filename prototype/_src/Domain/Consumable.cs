namespace CreationalPatterns.Prototype.Domain
{
    /// <summary>
    ///     Concrete Prototype
    /// </summary>
    public class Consumable : Item
    {
        public Consumable(string name) : base(name)
        {
        }

        private Consumable(Consumable source) : this(source.Name)
        {
        }

        public override Item Clone() => new Consumable(this);
    }
}
