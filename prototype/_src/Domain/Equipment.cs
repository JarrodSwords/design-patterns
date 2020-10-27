namespace DesignPatterns.Prototype.Domain
{
    public abstract class Equipment : Item
    {
        #region Core

        protected Equipment(string name, CompatibleCharacters compatibleCharacters) : base(name)
        {
            CompatibleCharacters = compatibleCharacters;
        }

        #endregion

        #region Public Interface

        public CompatibleCharacters CompatibleCharacters { get; }

        #endregion
    }
}
