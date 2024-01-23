using Xunit;

namespace GildedTros.App.Tests.TestData;

public static class NormalItemsTestData
{    
    public static TheoryData<Item> NormalItemsBeforeSellIn()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateRingOfCleansening(5, 10) },
            { ItemFactory.CreateElixirOfTheSolid(5, 8) }
        };
    }
    
    public static TheoryData<Item> NormalItemsAfterSellIn()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateRingOfCleansening(0, 82) },
            { ItemFactory.CreateElixirOfTheSolid(-8, 54) }
        };
    }
    
    public static TheoryData<Item> NormalItemsWithZeroQualityAfterUpdate()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateRingOfCleansening(-2, 1) },
            { ItemFactory.CreateElixirOfTheSolid(5, 0) }
        };
    }
}