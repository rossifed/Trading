using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Valuation.Api.Commands.Handlers
{
    internal class ValuateTargetAllocationHandler : ICommandHandler<ValuateTargetAllocation>
    {
        private ILogger<ValuateTargetAllocationHandler> Logger { get; }
        private ITargetAllocationValuationService TargetAllocationValuationService { get; }
        public ValuateTargetAllocationHandler(
            ITargetAllocationValuationService targetAllocationValuationService,
            ILogger<ValuateTargetAllocationHandler> logger)
        {

            this.TargetAllocationValuationService = targetAllocationValuationService;
            this.Logger = logger;
        }

        public async Task HandleAsync(ValuateTargetAllocation command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Received command {command}...");
            var portfolioId = command.PortfolioId;
            await TargetAllocationValuationService.ValuateTargetAllocationAsync(portfolioId);
        }
    }
}
