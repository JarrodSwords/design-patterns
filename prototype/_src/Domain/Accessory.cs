namespace CreationalPatterns.Prototype.Domain
{
    /// <summary>
    ///     Concrete Prototype
    /// </summary>
    public class Accessory : Equipment
    {
        public Accessory(string name, CompatibleCharacters compatibleCharacters) : base(name, compatibleCharacters)
        {
        }

        private Accessory(Accessory source) : this(source.Name, source.CompatibleCharacters)
        {
        }

        public override Item Clone() => new Accessory(this);
    }
}
