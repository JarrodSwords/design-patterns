using System.Collections.Generic;
using System.Linq;

namespace CreationalPatterns.Singleton.Domain
{
    public class ShopBuilder
    {
        private List<Item> _items;
        public IReadOnlyCollection<Item> Items => _items ??= new List<Item>();

        public string Location { get; private set; }

        public Shop Build() => new Shop(this);

        public ShopBuilder ForLocation(string location)
        {
            Location = location;
            return this;
        }

        public ShopBuilder WithInventory(string[] itemNames)
        {
            _items = itemNames.Select(itemName => ItemRepository.Instance.Find(itemName)).ToList();
            return this;
        }
    }
}
