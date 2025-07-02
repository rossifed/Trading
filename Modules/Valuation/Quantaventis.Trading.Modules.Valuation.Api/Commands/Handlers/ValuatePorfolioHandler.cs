using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Modules.Valuation.Api.Commands.Handlers
{
    internal class ValuatePortfolioHandler : ICommandHandler<ValuatePortfolio>
    {
        private ILogger<ValuatePortfolioHandler> Logger { get; }
        private IPortfolioValuationService PortfolioValuationService { get; }
        public ValuatePortfolioHandler(
            IPortfolioValuationService portfolioValuationService,
            ILogger<ValuatePortfolioHandler> logger)
        {

            this.PortfolioValuationService = portfolioValuationService;
            this.Logger = logger;
        }


        public async Task HandleAsync(ValuatePortfolio command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Received Command {command}");
            var portfolioId = command.PortfolioId;
            await PortfolioValuationService.ValuatePortfolioAync(portfolioId);
        }

    }

}
