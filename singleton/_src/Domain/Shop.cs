using System.Collections.Generic;
using System.Linq;

namespace CreationalPatterns.Singleton.Domain
{
    public class Shop
    {
        private readonly List<Item> _inventory;
        private readonly string _location;
        private string _name;

        public Shop(ShopBuilder builder)
        {
            _location = builder.Location;
            _inventory = builder.Items.ToList();
        }

        public IReadOnlyCollection<Item> Inventory => _inventory;

        public string Name => _name ??= $"{_location} Item Shop";
    }
}
