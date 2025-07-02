using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Events.Out;
using Quantaventis.Trading.Modules.Transmission.Api.Events.In;
using Quantaventis.Trading.Modules.Transmission.Api.Events.Out;
using Quantaventis.Trading.Modules.Transmission.Api.Mappers;
using Quantaventis.Trading.Modules.Transmission.Api.Services;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using System.Reflection;

namespace Quantaventis.Trading.Modules.Transmission.Api.Events.Handlers
{
    internal class TradeCancelledHandler : IEventHandler<TradeCancelled>
    {
        private IBookedTradeAllocationDao BookedTradeAllocationDao { get; }
        private ILogger<TradeCancelledHandler> Logger { get; }
 
        public TradeCancelledHandler(
            IBookedTradeAllocationDao bokedTradeAllocationDao,
            ILogger<TradeCancelledHandler> logger)              
        {
            this.Logger = logger;
            this.BookedTradeAllocationDao = bokedTradeAllocationDao;
        }

     
        public async Task HandleAsync(TradeCancelled @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");
            await BookedTradeAllocationDao.UpsertRangeAsync(@event.Trade.Map());
        }

    }

}
