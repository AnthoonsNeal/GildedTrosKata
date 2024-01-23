using System.Collections.Generic;
using GildedTros.App.Tests.TestData;
using Xunit;

namespace GildedTros.App.Tests;

public class BDawgKeychainTests
{
    [Theory]
    [InlineData(5, 10)]
    [InlineData(-5, 10)]
    [InlineData(0, 10)]
    public void UpdateQuality_BDawgKeyChainItem_NeverChangesQualityOrSellIn(int sellInBeforeUpdate, int qualityBeforeUpdate)
    {
        // Arrange
        Item item = ItemFactory.CreateBDawgKeyChain(sellInBeforeUpdate, qualityBeforeUpdate);
        IList<Item> items = new List<Item> { item };
        var app = new GildedTros(items);
            
        // Act
        app.UpdateQuality();
            
        // Assert
        Assert.Equal(item.Quality, qualityBeforeUpdate);
        Assert.Equal(item.SellIn, sellInBeforeUpdate);
    }
}