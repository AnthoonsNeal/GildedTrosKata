using System.Collections.Generic;
using GildedTros.App.Tests.TestData;
using Xunit;

namespace GildedTros.App.Tests
{
    public class SmellyItemsTests
    {
        [Theory]
        [MemberData(nameof(SmellyItemsTestData.SmellyItemsBeforeSellIn), MemberType = typeof(SmellyItemsTestData))]
        public void UpdateQuality_SmellyItemsBeforeSellIn_LowersQualityWithTwo(Item item)
        {
            // Arrange
            int qualityBeforeUpdate = item.Quality;
            IList<Item> items = new List<Item> { item };
            var app = new GildedTros(items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            Assert.Equal(item.Quality, qualityBeforeUpdate - 2);
        }

        [Theory]
        [MemberData(nameof(SmellyItemsTestData.SmellyItemsAfterSellIn), MemberType = typeof(SmellyItemsTestData))]
        public void UpdateQuality_NormalItemsAfterSellIn_LowersQualityWithFour(Item item)
        {
            // Arrange
            int qualityBeforeUpdate = item.Quality;
            IList<Item> items = new List<Item> { item };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(item.Quality, qualityBeforeUpdate - 4);
        }

        [Theory]
        [MemberData(nameof(SmellyItemsTestData.SmellyItemsWithZeroQualityAfterUpdate), MemberType = typeof(SmellyItemsTestData))]
        public void UpdateQuality_NormalItems_DoesntLowerQualityUnderZero(Item item)
        {
            // Arrange
            IList<Item> items = new List<Item> { item };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(Constants.MIN_QUALITY, item.Quality);
        }
        
        [Theory]
        [MemberData(nameof(SmellyItemsTestData.SmellyItemsBeforeSellIn), MemberType = typeof(SmellyItemsTestData))]
        [MemberData(nameof(SmellyItemsTestData.SmellyItemsAfterSellIn), MemberType = typeof(SmellyItemsTestData))]
        [MemberData(nameof(SmellyItemsTestData.SmellyItemsWithZeroQualityAfterUpdate), MemberType = typeof(SmellyItemsTestData))]
        public void UpdateQuality_NormalItemsBeforeAndAfterSellIn_LowersSellInWithOne(Item item)
        {
            // Arrange
            int sellInBeforeUpdate = item.SellIn;
            IList<Item> items = new List<Item> { item };
            var app = new GildedTros(items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            Assert.Equal(item.SellIn, sellInBeforeUpdate - 1);
        }
    }
}