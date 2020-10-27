namespace DesignPatterns.Prototype.Domain
{
    /// <summary>
    ///     Concrete Prototype
    /// </summary>
    public class Accessory : Equipment
    {
        #region Core

        public Accessory(string name, CompatibleCharacters compatibleCharacters) : base(name, compatibleCharacters)
        {
        }

        private Accessory(Accessory source) : this(source.Name, source.CompatibleCharacters)
        {
        }

        #endregion

        #region Public Interface

        public override Item Clone()
        {
            return new Accessory(this);
        }

        #endregion
    }
}
