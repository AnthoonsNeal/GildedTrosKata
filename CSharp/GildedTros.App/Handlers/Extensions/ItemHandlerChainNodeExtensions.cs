using System;
using GildedTros.App.Handlers.Chain;
using GildedTros.App.Handlers.Decorators;

namespace GildedTros.App.Handlers.Extensions;

public static class ItemHandlerChainNodeExtensions
{
    public static ItemHandlerChain AddItemHandler(this ItemHandlerChain chain, string itemName, Func<IHandler> handler)
    {
        chain.AddHandler(ItemHandler.Create(itemName, handler.Invoke()));
        return chain;
    }
}