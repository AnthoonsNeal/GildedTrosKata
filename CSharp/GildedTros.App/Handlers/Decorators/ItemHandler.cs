namespace GildedTros.App.Handlers.Decorators;

public class ItemHandler : IHandler
{
    private readonly IHandler _handler;

    public ItemHandler(string itemName, IHandler handler)
    {
        _handler = handler;
        ItemName = itemName;
    }

    public string ItemName { get; set; }

    public virtual void Handle(Item item) => _handler.Handle(item);
}