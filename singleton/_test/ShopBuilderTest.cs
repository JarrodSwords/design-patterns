using System.Linq;
using DesignPatterns.Singleton.Domain;
using FluentAssertions;
using Xunit;

namespace DesignPatterns.Singleton
{
    public class ShopBuilderTest
    {
        #region Test Methods

        [Theory]
        [InlineData(
            "Mushroom Kingdom",
            "Honey Syrup",
            "Pick Me Up",
            "Able Juice",
            "Shirt",
            "Pants",
            "Jump Shoes",
            "Antidote Pin"
        )]
        [InlineData(
            "Rose Town",
            "Mushroom",
            "Honey Syrup",
            "Pick Me Up",
            "Able Juice",
            "Thick Shirt",
            "Thick Pants",
            "Jump Shoes",
            "Antidote Pin",
            "Wake Up Pin",
            "Trueform Pin",
            "Fearless Pin"
        )]
        public void WhenBuildingShop_WithLocationAndInventory_NameAndInventoryAreSet(
            string locationName,
            params string[] inventory
        )
        {
            var shop = new ShopBuilder()
                .ForLocation(locationName)
                .WithInventory(inventory)
                .Build();

            shop.Name.Should().Be($"{locationName} Item Shop");
            shop.Inventory.Select(x => x.Name).Should().BeEquivalentTo(inventory);
        }

        [Fact]
        public void WhenCreatingMultipleItemRepositories_ItemRepositoriesAreTheSameInstance()
        {
            var itemRepository1 = ItemRepository.Instance;
            var itemRepository2 = ItemRepository.Instance;

            itemRepository2.Should().BeSameAs(itemRepository1);
        }

        #endregion
    }
}
