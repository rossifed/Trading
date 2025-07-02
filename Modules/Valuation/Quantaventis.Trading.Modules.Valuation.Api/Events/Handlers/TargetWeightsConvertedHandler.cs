using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Events.In;
using Quantaventis.Trading.Modules.Valuation.Api.Mappers;
using Quantaventis.Trading.Modules.Valuation.Api.Services;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Entities = Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Valuation.Api.Events.Handlers
{
    internal class TargetWeightsConvertedHandler : IEventHandler<TargetWeightsConverted>
    {
        private ITargetAllocationDao TargetAllocationDao { get; }
       private ITargetAllocationValuationService TargetAllocationValuationService { get; }
        private ICommandDispatcher CommandDispatcher { get; }

        private ILogger<TargetWeightsConvertedHandler> Logger { get; }
        public TargetWeightsConvertedHandler(ITargetAllocationDao targetAllocationDao,
            ITargetAllocationValuationService targetAllocationValuationService,
            ILogger<TargetWeightsConvertedHandler> logger) { 
            this.TargetAllocationDao = targetAllocationDao;
            this.TargetAllocationValuationService = targetAllocationValuationService;
            this.Logger = logger;
     

        
        }
        public async Task HandleAsync(TargetWeightsConverted @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");
            var entities = @event.ConvertedTargetWeights.Map();
            Entities.TargetAllocation entity = new Entities.TargetAllocation()
            {
                TargetAllocationId = @event.TargetAllocationId,
                PortfolioId = @event.PortfolioId,
                GeneratedOn = @event.GeneratedOn
            };
            @event.ConvertedTargetWeights.ToList().ForEach(x => entity.TargetWeights.Add(x.Map()));
            await TargetAllocationDao.ReplaceAsync(entity);

            await TargetAllocationValuationService.ValuateTargetAllocationAsync(entity.PortfolioId);
    
        }
    }
}
