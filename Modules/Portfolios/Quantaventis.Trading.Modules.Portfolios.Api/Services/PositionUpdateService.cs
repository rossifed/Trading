using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.Out;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Entities = Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Services
{
    internal interface IPositionUpdateService
    {
         Task ComputeDailyPositions();
        Task ComputePositionsAll();
        Task ComputePositions(byte daysBack);
        Task UpdatePositionsAsync(IEnumerable<TradeDto> tradeDtos);
    }
    internal class PositionUpdateService : IPositionUpdateService
    {
        private IPositionUpdateRepository PositionUpdateRepository { get; }
        private IVwPositionDao PositionDao { get; }
        private ITradeAllocationDao TradeAllocationDao { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<PositionUpdateService> Logger { get; }
   
        public PositionUpdateService(
            ITradeAllocationDao tradeAllocationDao,
            IPositionUpdateRepository positionUpdateRepository,
            IVwPositionDao positionDao,
            IMessageBroker messageBroker,
            ILogger<PositionUpdateService> logger)
        {
            PositionDao = positionDao;
            MessageBroker = messageBroker;
            Logger = logger;
            TradeAllocationDao = tradeAllocationDao;
            PositionUpdateRepository = positionUpdateRepository;
        }

    

        private async Task SaveTradeAllocationsAsync(IEnumerable<TradeDto> tradeDtos)
        {
            IEnumerable<Entities.TradeAllocation> entities = tradeDtos.SelectMany(x => x.TradeAllocations.Map(x));
            await TradeAllocationDao.UpsertAsync(entities);
        }
        public async Task UpdatePositionsAsync(IEnumerable<TradeDto> tradeDtos)
        {
            await SaveTradeAllocationsAsync(tradeDtos);
            await PositionUpdateRepository.UpdatePositionsAsync();
            await PositionUpdateRepository.PropagateUpdatePositionsAsync();
            await MessageBroker.PublishAsync(new PositionsUpdated());
        }

        public async Task ComputePositionsAll()
        {
            Logger.LogInformation("Recompute All Positions From Inception...");
            await PositionUpdateRepository.ComputePositionsAll();
            Logger.LogInformation("End...");
        }
        public async Task ComputeDailyPositions()
        {
            Logger.LogInformation($"Computing  Daily Positions...");
            await PositionUpdateRepository.ComputeMissingPositions();
        }
        public async Task ComputePositions(byte daysBack)
        {
            Logger.LogInformation($"Computing  Positions From {daysBack} day back...");
            await PositionUpdateRepository.ComputePositions(daysBack);
        }
    }
}
