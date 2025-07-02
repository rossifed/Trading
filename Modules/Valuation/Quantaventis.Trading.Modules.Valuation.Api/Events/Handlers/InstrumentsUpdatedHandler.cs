using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Events.In;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Valuation.Api.Commands.Handlers
{
    internal class InstrumentsUpdatedHandler : IEventHandler<InstrumentsUpdated>
    {

        private ILogger<InstrumentsUpdatedHandler> Logger { get; }

       private IPortfolioValuationService PortfolioValuationService { get; }
        private ITargetAllocationValuationService TargetAllocationValuationService { get; }
        public InstrumentsUpdatedHandler(
            IPortfolioValuationService portfolioValuationService,
            ITargetAllocationValuationService targetAllocationValuationService,
            ILogger<InstrumentsUpdatedHandler> logger)
        {

            this.Logger = logger;
            this.PortfolioValuationService = portfolioValuationService;
            this.TargetAllocationValuationService = targetAllocationValuationService;
        }


        public async Task HandleAsync(InstrumentsUpdated command, CancellationToken cancellationToken = default)
        {
            //TargetAllocationValuationService.ValuateTargetAllocationAync();
            //PortfolioValuationService.ValuatePortfolioAync();

        }

   
    }

}
