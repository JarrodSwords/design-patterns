namespace DesignPatterns.Prototype.Domain
{
    /// <summary>
    ///     Concrete Prototype
    /// </summary>
    public class Armor : Equipment
    {
        #region Core

        public Armor(string name, CompatibleCharacters compatibleCharacters) : base(name, compatibleCharacters)
        {
        }

        public Armor(Armor source) : this(source.Name, source.CompatibleCharacters)
        {
        }

        #endregion

        #region Public Interface

        public override Item Clone()
        {
            return new Armor(this);
        }

        #endregion
    }
}
