using System.Collections.Generic;
using System.Linq;

namespace GildedTros.App.Handlers.Chain;

public class ItemHandlerChain : IHandler
{
    private readonly List<ItemHandler> _handlers = new();
    
    public void Handle(Item item)
    {
        ItemHandler itemHandler = _handlers.SingleOrDefault(h => h.ItemName == item.Name);
        itemHandler?.Handle(item);
    }

    public void AddHandler(ItemHandler handler) => _handlers.Add(handler);
}