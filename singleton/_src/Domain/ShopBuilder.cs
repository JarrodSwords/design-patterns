using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Singleton.Domain
{
    public class ShopBuilder
    {
        #region Core

        private List<Item> _items;

        #endregion

        #region Public Interface

        public string Location { get; private set; }
        public IReadOnlyCollection<Item> Items => _items ??= new List<Item>();

        public Shop Build()
        {
            return new Shop(this);
        }

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

        #endregion
    }
}
