using System.Linq;
using DesignPatterns.Prototype.Domain;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Prototype
{
    public class ShopTest
    {
        #region Test Methods

        [Theory]
        [InlineData(0, "Honey Syrup")]
        [InlineData(3, "Shirt")]
        public void WhenSellingAnItem_CloneItemToPlayerInventory(int index, string expectedItemName)
        {
            var player = new Player();
            var shop = new MushroomKingdomShop();

            shop.SelectItem(index);
            shop.MakeSale(player);

            player.Inventory.Should().Contain(x => x.Name == expectedItemName);

            var purchasedItem = player.Inventory.First(x => x.Name == expectedItemName);
            purchasedItem.Should().NotBeSameAs(shop.SelectedItem);
        }

        #endregion
    }
}
