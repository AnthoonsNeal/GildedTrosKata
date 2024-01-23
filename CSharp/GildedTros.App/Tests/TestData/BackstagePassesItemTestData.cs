using Xunit;

namespace GildedTros.App.Tests.TestData;

public static class BackstagePassesItemTestData
{    
    public static TheoryData<Item> BackstagePassesItemsBeforeThreshold1()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateBackstagePassesForRefactor(Constants.BACKSTAGE_PASSES_THRESHOLD_1 + 5, 5) },
            { ItemFactory.CreateBackstagePassesForHaxx(Constants.BACKSTAGE_PASSES_THRESHOLD_1 + 1, 10) }
        };
    }
    
    public static TheoryData<Item> BackstagePassesItemsInBetweenThresholds()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateBackstagePassesForRefactor(Constants.BACKSTAGE_PASSES_THRESHOLD_1 - 3, 5) },
            { ItemFactory.CreateBackstagePassesForHaxx(Constants.BACKSTAGE_PASSES_THRESHOLD_1 - 1, 10) }
        };
    }
    
    public static TheoryData<Item> BackstagePassesAfterThreshold2()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateBackstagePassesForRefactor(Constants.BACKSTAGE_PASSES_THRESHOLD_2 - 3, 5) },
            { ItemFactory.CreateBackstagePassesForHaxx(Constants.BACKSTAGE_PASSES_THRESHOLD_2 - 1, 10) }
        };
    }
    
    public static TheoryData<Item> BackstagePassesAfterSellIn()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateBackstagePassesForRefactor(-3, 5) },
            { ItemFactory.CreateBackstagePassesForHaxx(-1, 10) }
        };
    }
}