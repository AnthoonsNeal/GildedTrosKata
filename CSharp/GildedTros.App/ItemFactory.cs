using System;

namespace GildedTros.App;

public static class ItemFactory
{
    public static Item CreateRingOfCleansening(int sellIn, int quality)
        => CreateItem(Constants.RING_OF_CLEANSENING_CODE, sellIn, quality);

    public static Item CreateGoodWine(int sellIn, int quality)
        => CreateItem(Constants.GOOD_WINE, sellIn, quality);

    public static Item CreateElixirOfTheSolid(int sellIn, int quality)
        => CreateItem(Constants.ELIXIR_OF_THE_SOLID, sellIn, quality);

    public static Item CreateBDawgKeyChain(int sellIn, int quality)
        => CreateItem(Constants.B_DAWG_KEYCHAIN, sellIn, quality);

    public static Item CreateBackstagePassesForRefactor(int sellIn, int quality)
        => CreateItem(Constants.BACKSTAGE_PASSES_REFACTOR, sellIn, quality);

    public static Item CreateBackstagePassesForHaxx(int sellIn, int quality)
        => CreateItem(Constants.BACKSTAGE_PASSES_HAXX, sellIn, quality);

    public static Item CreateDuplicateCode(int sellIn, int quality)
        => CreateItem(Constants.DUPLICATE_CODE, sellIn, quality);
    
    public static Item CreateLongMethods(int sellIn, int quality)
        => CreateItem(Constants.LONG_METHODS, sellIn, quality);
    
    public static Item CreateUglyVariableNames(int sellIn, int quality)
        => CreateItem(Constants.UGLY_VARIABLE_NAMES, sellIn, quality);
    
    private static Item CreateItem(string name, int sellIn, int quality)
        => new()
        {
            Name = name,
            SellIn = sellIn,
            Quality = quality
        };
}