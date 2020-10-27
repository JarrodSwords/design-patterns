namespace DesignPatterns.Prototype.Domain
{
    /// <summary>
    ///     Concrete Prototype
    /// </summary>
    public class Consumable : Item
    {
        #region Core

        public Consumable(string name) : base(name)
        {
        }

        private Consumable(Consumable source) : this(source.Name)
        {
        }

        #endregion

        #region Public Interface

        public override Item Clone()
        {
            return new Consumable(this);
        }

        #endregion
    }
}
