using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.In;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class TradeBookedHandler : IEventHandler<TradeBooked>
    {

  

        private IBookedTradeAllocationDao BookedTradeAllocationDao { get; }

        private IPositionUpdateService PositionUpdateService { get; }
        private ILogger<TradesBookedHandler> Logger { get; }
        private IMessageBroker MessageBroker { get; }

        public TradeBookedHandler(IBookedTradeAllocationDao bookedTradeAllocationDao,
            IPositionUpdateService positionUpdateService, 
            ILogger<TradesBookedHandler> logger, 
            IMessageBroker messageBroker)
        {
            BookedTradeAllocationDao = bookedTradeAllocationDao;
            PositionUpdateService = positionUpdateService;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task HandleAsync(TradeBooked @event, CancellationToken cancellationToken = default)
        {

            Logger.LogInformation($"{@event} received....");
            await BookedTradeAllocationDao.UpsertRangeAsync(@event.Trade.Map());
           // await PositionUpdateService.ComputePositions(1);
        }

    }

}
