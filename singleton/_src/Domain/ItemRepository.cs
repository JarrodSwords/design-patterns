using System.Collections.Generic;

namespace CreationalPatterns.Singleton.Domain
{
    /// <summary>
    ///     Singleton
    /// </summary>
    public class ItemRepository
    {
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

        public static ItemRepository Instance { get; } = new ItemRepository();

        public Item Find(string name)
        {
            return _items.Find(x => x.Name == name).Clone();
        }
    }
}
