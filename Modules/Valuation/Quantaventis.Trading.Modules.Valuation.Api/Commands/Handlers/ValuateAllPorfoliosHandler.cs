using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Valuation.Api.Commands.Handlers
{
    internal class ValuateAllPortfolioHandler : ICommandHandler<ValuateAllPortfolios>
    {
        private ILogger<ValuateAllPortfolioHandler> Logger { get; }
        private IPortfolioValuationService PortfolioValuationService { get; }
        public ValuateAllPortfolioHandler(
            IPortfolioValuationService portfolioValuationService,
            ILogger<ValuateAllPortfolioHandler> logger)
        {

            this.PortfolioValuationService = portfolioValuationService;
            this.Logger = logger;
        }


        public async Task HandleAsync(ValuateAllPortfolios command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Received Command {command}");
            await PortfolioValuationService.ValuateAllPortfolioAync();
        }

    }

}
