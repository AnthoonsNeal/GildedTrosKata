﻿namespace GildedTros.App.Handlers;

public class StandardItemHandler : IHandler
{
    private readonly int _standardQualityUpdate;
    private readonly int _qualityUpdateAfterSellIn;

    private StandardItemHandler(int standardQualityUpdate, int qualityUpdateAfterSellIn)
    {
        _standardQualityUpdate = standardQualityUpdate;
        _qualityUpdateAfterSellIn = qualityUpdateAfterSellIn;
    }

    public static StandardItemHandler Create(int standardQualityUpdate, int qualityUpdateAfterSellIn) =>
        new(standardQualityUpdate, qualityUpdateAfterSellIn);
    
    public void Handle(Item item)
    {
        item.Quality += _standardQualityUpdate;
        
        if (item.SellIn >= Constants.MIN_QUALITY)
            return;

        item.Quality += _qualityUpdateAfterSellIn;
    }
}