using System.Collections.Generic;
using GildedTros.App.Tests.TestData;
using Xunit;

namespace GildedTros.App.Tests
{
    public class NormalItemsTests
    {
        [Theory]
        [MemberData(nameof(NormalItemsTestData.NormalItemsBeforeSellIn), MemberType = typeof(NormalItemsTestData))]
        public void UpdateQuality_NormalItemsBeforeSellIn_LowersQualityWithOne(Item item)
        {
            // Arrange
            int qualityBeforeUpdate = item.Quality;
            IList<Item> items = new List<Item> { item };
            var app = new GildedTros(items);
            
            // Act
            app.UpdateQuality();
            
            // Assert
            Assert.Equal(item.Quality, qualityBeforeUpdate - 1);
        }

        [Theory]
        [MemberData(nameof(NormalItemsTestData.NormalItemsAfterSellIn), MemberType = typeof(NormalItemsTestData))]
        public void UpdateQuality_NormalItemsAfterSellIn_LowersQualityWithTwo(Item item)
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
        [MemberData(nameof(NormalItemsTestData.NormalItemsWithZeroQualityAfterUpdate), MemberType = typeof(NormalItemsTestData))]
        public void UpdateQuality_NormalItems_DoesntLowerQualityUnderZero(Item item)
        {
            // Arrange
            int qualityBeforeUpdate = item.Quality;
            IList<Item> items = new List<Item> { item };
            var app = new GildedTros(items);

            // Act
            app.UpdateQuality();

            // Assert
            Assert.Equal(Constants.MIN_QUALITY, item.Quality);
        }
        
        [Theory]
        [MemberData(nameof(NormalItemsTestData.NormalItemsBeforeSellIn), MemberType = typeof(NormalItemsTestData))]
        [MemberData(nameof(NormalItemsTestData.NormalItemsAfterSellIn), MemberType = typeof(NormalItemsTestData))]
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