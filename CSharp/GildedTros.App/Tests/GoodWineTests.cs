using System.Collections.Generic;
using GildedTros.App.Tests.TestData;
using Xunit;

namespace GildedTros.App.Tests;

public class GoodWineTests
{
    [Fact]
    public void UpdateQuality_GoodWineItemBeforeSellIn_IncrementsQualityWithOne()
    {
        // Arrange
        int qualityBeforeUpdate = 5;
        Item item = ItemFactory.CreateGoodWine(5, qualityBeforeUpdate);
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.Quality, qualityBeforeUpdate + 1);
    }
    
    [Fact]
    public void UpdateQuality_GoodWineItemAfterSellIn_IncrementsQualityWithTwo()
    {
        // Arrange
        int qualityBeforeUpdate = 5;
        Item item = ItemFactory.CreateGoodWine(-2, qualityBeforeUpdate);
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.Quality, qualityBeforeUpdate + 2);
    }
    
    
    [Theory]
    [MemberData(nameof(GoodWineItemTestData.GoodWineItemsWithMaxQualityAfterUpdate), MemberType = typeof(GoodWineItemTestData))]
    public void UpdateQuality_GoodWineItem_DoesntIncrementOverMaxQuality(Item item)
    {
        // Arrange
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.Quality, Constants.MAX_QUALITY);
    }
    
    [Fact]
    public void UpdateQuality_GoodWineItemBeforeAndAfterSellIn_LowersSellInWithOne()
    {
        // Arrange
        int sellInBeforeUpdate = 5;
        Item item = ItemFactory.CreateGoodWine(sellInBeforeUpdate, 5);
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.SellIn, sellInBeforeUpdate - 1);
    }
}