using System.Linq;
using CreationalPatterns.Prototype.Domain;
using FluentAssertions;
using Xunit;

namespace CreationalPatterns.Prototype
{
    public class ShopTest
    {
        #region Requirements

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
