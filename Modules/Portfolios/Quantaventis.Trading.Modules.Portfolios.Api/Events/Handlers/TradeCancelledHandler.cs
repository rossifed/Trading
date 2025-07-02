using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.In;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class TradeCancelledHandler : IEventHandler<TradeCancelled>
    {

  

        private IBookedTradeAllocationDao BookedTradeAllocationDao { get; }

        private IPositionUpdateService PositionUpdateService { get; }
        private ILogger<TradeCancelledHandler> Logger { get; }
        private IMessageBroker MessageBroker { get; }

        public TradeCancelledHandler(IBookedTradeAllocationDao bookedTradeAllocationDao,
            IPositionUpdateService positionUpdateService, 
            ILogger<TradeCancelledHandler> logger, 
            IMessageBroker messageBroker)
        {
            BookedTradeAllocationDao = bookedTradeAllocationDao;
            PositionUpdateService = positionUpdateService;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task HandleAsync(TradeCancelled @event, CancellationToken cancellationToken = default)
        {

            Logger.LogInformation($"{@event} received....");

            await BookedTradeAllocationDao.DeleteByTradeIdAsync(@event.Trade.TradeId);
  
        }

    }

}
