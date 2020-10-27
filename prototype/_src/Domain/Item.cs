namespace DesignPatterns.Prototype.Domain
{
    /// <summary>
    ///     Prototype
    /// </summary>
    public abstract class Item
    {
        #region Core

        protected Item(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public string Name { get; }

        public abstract Item Clone();

        #endregion
    }
}
