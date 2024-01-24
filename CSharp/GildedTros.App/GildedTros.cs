using System.Collections.Generic;
using ApprovalUtilities.Utilities;
using GildedTros.App.Handlers;
using GildedTros.App.Handlers.Chain;
using GildedTros.App.Handlers.Extensions;

namespace GildedTros.App
{
    public class GildedTros
    {
        private readonly ItemHandlerChain _chainOfResponsibilityItemHandler = new();
        IList<Item> Items;

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
            SetUpHandler();
        }
        
        private void SetUpHandler()
        {
            _chainOfResponsibilityItemHandler
                .AddItemHandler(Constants.RING_OF_CLEANSENING_CODE, () =>
                    StandardItemHandler.Create(-1, -1)
                        .CapQualityMinMax()
                        .DecrementSellIn())
                .AddItemHandler(Constants.ELIXIR_OF_THE_SOLID, () =>
                    StandardItemHandler.Create(-1, -1)
                        .CapQualityMinMax()
                        .DecrementSellIn())
                .AddItemHandler(Constants.GOOD_WINE, () =>
                    StandardItemHandler.Create(1, 1)
                        .CapQualityMinMax()
                        .DecrementSellIn())
                .AddItemHandler(Constants.BACKSTAGE_PASSES_REFACTOR, () =>
                    BackstagePassesItemHandler.Create()
                        .CapQualityMinMax()
                        .DecrementSellIn())
                .AddItemHandler(Constants.BACKSTAGE_PASSES_HAXX, () =>
                    BackstagePassesItemHandler.Create()
                        .CapQualityMinMax()
                        .DecrementSellIn())
                .AddItemHandler(Constants.LONG_METHODS, () =>
                    StandardItemHandler.Create(-2, -2)
                        .CapQualityMinMax()
                        .DecrementSellIn())
                .AddItemHandler(Constants.DUPLICATE_CODE, () =>
                    StandardItemHandler.Create(-2, -2)
                        .CapQualityMinMax()
                        .DecrementSellIn())
                .AddItemHandler(Constants.UGLY_VARIABLE_NAMES, () =>
                    StandardItemHandler.Create(-2, -2)
                        .CapQualityMinMax()
                        .DecrementSellIn());
        }

        public void UpdateQuality() => Items.ForEach(item => _chainOfResponsibilityItemHandler.Handle(item));
    }
}