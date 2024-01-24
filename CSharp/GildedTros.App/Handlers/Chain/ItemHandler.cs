namespace GildedTros.App.Handlers.Chain;

public class ItemHandler : IHandler
{
    private readonly IHandler _handler;

    private ItemHandler(string itemName, IHandler handler)
    {
        _handler = handler;
        ItemName = itemName;
    }

    public static ItemHandler Create(string itemName, IHandler handler) => new(itemName, handler);

    public string ItemName { get; }

    public virtual void Handle(Item item) => _handler.Handle(item);
}