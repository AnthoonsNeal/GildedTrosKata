using Xunit;

namespace GildedTros.App.Tests.TestData;

public static class SmellyItemsTestData
{    
    public static TheoryData<Item> SmellyItemsBeforeSellIn()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateDuplicateCode(5, 10) },
            { ItemFactory.CreateLongMethods(5, 8) },
            { ItemFactory.CreateUglyVariableNames(7, 18) }
        };
    }
    
    public static TheoryData<Item> SmellyItemsAfterSellIn()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateDuplicateCode(-5, 10) },
            { ItemFactory.CreateLongMethods(-1, 8) },
            { ItemFactory.CreateUglyVariableNames(0, 18) }
        };
    }
    
    public static TheoryData<Item> SmellyItemsWithZeroQualityAfterUpdate()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateDuplicateCode(5, 1) },
            { ItemFactory.CreateLongMethods(-10, 3) },
            { ItemFactory.CreateUglyVariableNames(-7, 0) }
        };
    }
}