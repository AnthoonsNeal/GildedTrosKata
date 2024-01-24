namespace GildedTros.App.Handlers.Decorators;

public class QualityCapHandler : IHandler
{
    private readonly IHandler _delegatingHandler;
    private readonly int _minimumValue;
    private readonly int _maximumValue;
    
    public QualityCapHandler(
        IHandler delegatingHandler,
        int minimumValue,
        int maximumValue)
    {
        _delegatingHandler = delegatingHandler;
        _minimumValue = minimumValue;
        _maximumValue = maximumValue;
    }
    
    public void Handle(Item item)
    {
        _delegatingHandler.Handle(item);

        if (item.Quality < _minimumValue)
        {
            item.Quality = _minimumValue;
        }

        if (item.Quality > _maximumValue)
        {
            item.Quality = _maximumValue;
        }
    }
}