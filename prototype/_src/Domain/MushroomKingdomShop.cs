using System.Collections.Generic;

namespace CreationalPatterns.Prototype.Domain
{
    /// <summary>
    ///     Client
    /// </summary>
    public class MushroomKingdomShop
    {
        private readonly List<Purchasable<Item>> _inventory;

        public MushroomKingdomShop()
        {
            _inventory = new List<Purchasable<Item>>
            {
                new Purchasable<Item>(new Consumable("Honey Syrup"), 10),
                new Purchasable<Item>(new Consumable("Pick Me Up"), 5),
                new Purchasable<Item>(new Consumable("Able Juice"), 4),
                new Purchasable<Item>(new Armor("Shirt", CompatibleCharacters.Mario), 7),
                new Purchasable<Item>(new Armor("Pants", CompatibleCharacters.Mallow), 7),
                new Purchasable<Item>(new Accessory("Jump Shoes", CompatibleCharacters.Mario), 30),
                new Purchasable<Item>(new Accessory("Antidote Pin", CompatibleCharacters.All), 28)
            };
        }

        public IReadOnlyCollection<Purchasable<Item>> Inventory => _inventory;

        public Purchasable<Item> SelectedItem { get; private set; }

        public void MakeSale(Player player)
        {
            var purchasedItem = SelectedItem.Good.Clone();
            player.Inventory.Add(purchasedItem);
        }

        public void SelectItem(int index)
        {
            SelectedItem = _inventory[index];
        }
    }
}
