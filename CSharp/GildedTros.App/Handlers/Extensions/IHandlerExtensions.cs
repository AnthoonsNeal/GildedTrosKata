using GildedTros.App.Handlers.Decorators;

namespace GildedTros.App.Handlers.Extensions;

public static class IHandlerExtensions
{
    public static IHandler CapQualityMinMax(this IHandler handler) =>
        new QualityCapHandler(handler, Constants.MIN_QUALITY, Constants.MAX_QUALITY);

    public static IHandler DecrementSellIn(this IHandler handler) =>
        new DecrementSellInHandler(handler);
}