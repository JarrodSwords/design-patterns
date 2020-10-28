using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Singleton.Domain
{
    public class Shop
    {
        #region Core

        private readonly List<Item> _inventory;
        private readonly string _location;
        private string _name;

        public Shop(ShopBuilder builder)
        {
            _location = builder.Location;
            _inventory = builder.Items.ToList();
        }

        #endregion

        #region Public Interface

        public string Name => _name ??= $"{_location} Item Shop";
        public IReadOnlyCollection<Item> Inventory => _inventory;

        #endregion
    }
}
