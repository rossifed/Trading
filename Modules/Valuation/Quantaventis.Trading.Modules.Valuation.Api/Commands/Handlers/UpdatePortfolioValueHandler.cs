using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Entities = Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Valuation.Api.Commands.Handlers
{
    internal class UpdatePortfolioValueHandler : ICommandHandler<UpdatePortfolioValue>
    {


        private ILogger<UpdatePortfolioValueHandler> Logger { get; }
        private IPortfolioDao PortfolioDao { get; }
        private IPortfolioValuationService PortfolioValuationService { get; }
        private ITargetAllocationValuationService TargetAllocationValuationService { get; }
        public UpdatePortfolioValueHandler(
            IPortfolioDao portfolioDao,
            IPortfolioValuationService portfolioValuationService,
            ITargetAllocationValuationService targetAllocationValuationService,
            ILogger<UpdatePortfolioValueHandler> logger)
        {
            this.PortfolioDao = portfolioDao;
            this.PortfolioValuationService = portfolioValuationService;
            this.TargetAllocationValuationService = targetAllocationValuationService;
            this.Logger = logger;
        }


        public async Task HandleAsync(UpdatePortfolioValue command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Received {command} command...");
            var portfolioId = command.PortfolioId;
            Entities.Portfolio? portfolioEntity = await PortfolioDao.GetByIdAsync(command.PortfolioId);
            if (portfolioEntity is null)
                throw new InvalidOperationException($"Portfolio {portfolioId} was not found. The value can't be updated.");
            portfolioEntity.TotalValue = command.Value;
            await PortfolioDao.UpdateAsync(portfolioEntity);
            await PortfolioValuationService.ValuatePortfolioAync(portfolioId);
            await TargetAllocationValuationService.ValuateTargetAllocationAsync(portfolioId);
        }

    }

}
