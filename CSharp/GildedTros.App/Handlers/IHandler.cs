namespace GildedTros.App.Handlers;

public interface IHandler
{
    /// <summary>
    /// Handles the UpdateQuality for a specific item.
    /// </summary>
    /// <param name="item">The item that needs to be updated.</param>
    void Handle(Item item);
}