namespace CreationalPatterns.Prototype.Domain
{
    /// <summary>
    ///     Concrete Prototype
    /// </summary>
    public class Armor : Equipment
    {
        public Armor(string name, CompatibleCharacters compatibleCharacters) : base(name, compatibleCharacters)
        {
        }

        private Armor(Armor source) : this(source.Name, source.CompatibleCharacters)
        {
        }

        public override Item Clone() => new Armor(this);
    }
}
