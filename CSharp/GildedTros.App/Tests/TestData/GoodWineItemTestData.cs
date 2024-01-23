using Xunit;

namespace GildedTros.App.Tests.TestData;

public static class GoodWineItemTestData
{    
    public static TheoryData<Item> GoodWineItemsWithMaxQualityAfterUpdate()
    {
        return new TheoryData<Item>
        {
            { ItemFactory.CreateGoodWine(5, 50) },
            { ItemFactory.CreateGoodWine(-2, 49) }
        };
    }
}