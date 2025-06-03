namespace CreationalPatterns.Prototype.Domain
{
    public abstract class Equipment : Item
    {
        protected Equipment(string name, CompatibleCharacters compatibleCharacters) : base(name)
        {
            CompatibleCharacters = compatibleCharacters;
        }

        public CompatibleCharacters CompatibleCharacters { get; }
    }
}
