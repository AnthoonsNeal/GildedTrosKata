using System.Collections.Generic;
using GildedTros.App.Tests.TestData;
using Xunit;

namespace GildedTros.App.Tests;

public class BackstagePassesItemTests
{
    [Theory]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesItemsBeforeThreshold1), MemberType = typeof(BackstagePassesItemTestData))]
    public void UpdateQuality_BackstagePassesBeforeThreshold1_IncrementsQualityWithOne(Item item)
    {
        // Arrange
        int qualityBeforeUpdate = item.Quality;
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.Quality, qualityBeforeUpdate + 1);
    }
    
    [Theory]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesItemsInBetweenThresholds), MemberType = typeof(BackstagePassesItemTestData))]
    public void UpdateQuality_BackstagePassesInBetweenThresholds_IncrementsQualityWithTwo(Item item)
    {
        // Arrange
        int qualityBeforeUpdate = item.Quality;
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.Quality, qualityBeforeUpdate + 2);
    }
    
    [Theory]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesAfterThreshold2), MemberType = typeof(BackstagePassesItemTestData))]
    public void UpdateQuality_BackstagePassesAfterThreshold2_IncrementsQualityWithThree(Item item)
    {
        // Arrange
        int qualityBeforeUpdate = item.Quality;
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.Quality, qualityBeforeUpdate + 3);
    }
    
    [Theory]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesAfterSellIn), MemberType = typeof(BackstagePassesItemTestData))]
    public void UpdateQuality_BackstagePassesAfterSellIn_SetsQualityToZero(Item item)
    {
        // Arrange
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(0,item.Quality);
    }
    
    [Theory]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesItemsBeforeThreshold1), MemberType = typeof(BackstagePassesItemTestData))]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesItemsInBetweenThresholds), MemberType = typeof(BackstagePassesItemTestData))]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesAfterThreshold2), MemberType = typeof(BackstagePassesItemTestData))]
    [MemberData(nameof(BackstagePassesItemTestData.BackstagePassesAfterSellIn), MemberType = typeof(BackstagePassesItemTestData))]
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