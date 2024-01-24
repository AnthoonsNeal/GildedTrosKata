namespace GildedTros.App.Handlers.Decorators;

public class DecrementSellInHandler : IHandler
{
    private readonly IHandler _delegatingHandler;

    public DecrementSellInHandler(IHandler delegatingHandler)
    {
        _delegatingHandler = delegatingHandler;
    }

    public void Handle(Item item)
    {
        item.SellIn--;
        _delegatingHandler.Handle(item);
    }
}