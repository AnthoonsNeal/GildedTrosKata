using System.Collections.Generic;
using ApprovalUtilities.Utilities;
using GildedTros.App.Handlers;
using GildedTros.App.Handlers.Chain;
using GildedTros.App.Handlers.Decorators;

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
            var ringHandler = new ItemHandler(
                    Constants.RING_OF_CLEANSENING_CODE,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new StandardItemHandler(-1, -1)),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));
            
            var elixirHandler = new ItemHandler(
                    Constants.ELIXIR_OF_THE_SOLID,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new StandardItemHandler(-1, -1)),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));
            
            var goodWineHandler = new ItemHandler(
                    Constants.GOOD_WINE,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new StandardItemHandler(1, 1)),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));

            var backstagePassesRefactorHandler = new ItemHandler(
                    Constants.BACKSTAGE_PASSES_REFACTOR,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new BackstagePassesItemHandler()),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));
            
            var backstagePasseHaxxHandler = new ItemHandler(
                    Constants.BACKSTAGE_PASSES_HAXX,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new BackstagePassesItemHandler()),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));
            
            var duplicateCodeHandler = new ItemHandler(
                    Constants.DUPLICATE_CODE,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new StandardItemHandler(-2, -2)),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));
            
            var longMethodsHandler = new ItemHandler(
                    Constants.LONG_METHODS,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new StandardItemHandler(-2, -2)),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));
            
            var uglyVariableHandler = new ItemHandler(
                    Constants.UGLY_VARIABLE_NAMES,
                    new QualityCapHandler(
                        new DecrementSellInHandler(new StandardItemHandler(-2, -2)),
                        Constants.MIN_QUALITY,
                        Constants.MAX_QUALITY));

            _chainOfResponsibilityItemHandler
                .AddItemHandler(ringHandler)
                .AddItemHandler(elixirHandler)
                .AddItemHandler(goodWineHandler)
                .AddItemHandler(backstagePasseHaxxHandler)
                .AddItemHandler(backstagePassesRefactorHandler)
                .AddItemHandler(duplicateCodeHandler)
                .AddItemHandler(longMethodsHandler)
                .AddItemHandler(uglyVariableHandler);
        }

        public void UpdateQuality() => Items.ForEach(item => _chainOfResponsibilityItemHandler.Handle(item));
    }
}