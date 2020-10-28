namespace DesignPatterns.Singleton.Domain
{
    public class Item
    {
        #region Core

        public Item(string name)
        {
            Name = name;
        }

        private Item(Item source)
        {
            Name = source.Name;
        }

        #endregion

        #region Public Interface

        public string Name { get; }

        public Item Clone()
        {
            return new Item(this);
        }

        #endregion
    }
}
