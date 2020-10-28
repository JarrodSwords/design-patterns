using System.Collections.Generic;

namespace DesignPatterns.Singleton.Domain
{
    /// <summary>
    ///     Singleton
    /// </summary>
    public class ItemRepository
    {
        #region Singleton

        public static ItemRepository Instance { get; } = new ItemRepository();

        #endregion

        #region Core

        private static List<Item> _items;

        private ItemRepository()
        {
            _items = new List<Item>
            {
                new Item("Honey Syrup"),
                new Item("Pick Me Up"),
                new Item("Able Juice"),
                new Item("Shirt"),
                new Item("Pants"),
                new Item("Jump Shoes"),
                new Item("Antidote Pin"),
                new Item("Mushroom"),
                new Item("Thick Shirt"),
                new Item("Thick Pants"),
                new Item("Wake Up Pin"),
                new Item("Trueform Pin"),
                new Item("Fearless Pin")
            };
        }

        #endregion

        #region Public Interface

        public Item Find(string name)
        {
            return _items.Find(x => x.Name == name).Clone();
        }

        #endregion
    }
}
