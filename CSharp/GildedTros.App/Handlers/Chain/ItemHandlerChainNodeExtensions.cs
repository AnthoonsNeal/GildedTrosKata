using GildedTros.App.Handlers.Decorators;

namespace GildedTros.App.Handlers.Chain;

public static class ItemHandlerChainNodeExtensions
{
    public static ItemHandlerChain AddItemHandler(this ItemHandlerChain chain, ItemHandler handler)
    {
        chain.AddHandler(handler);
        return chain;
    }
}