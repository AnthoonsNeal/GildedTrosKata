namespace GildedTros.App.Handlers;

public class BackstagePassesItemHandler : IHandler
{
    private BackstagePassesItemHandler()
    {
    }

    public static BackstagePassesItemHandler Create() => new();
    
    public void Handle(Item item)
    {
        if (item.SellIn < Constants.MIN_QUALITY)
        {
            item.Quality = Constants.MIN_QUALITY;
            return;
        }
        
        item.Quality++;
        
        if (item.SellIn < Constants.BACKSTAGE_PASSES_THRESHOLD_1)
        {
            item.Quality++;
        }

        if (item.SellIn < Constants.BACKSTAGE_PASSES_THRESHOLD_2)
        {
            item.Quality++;
        }
    }
}