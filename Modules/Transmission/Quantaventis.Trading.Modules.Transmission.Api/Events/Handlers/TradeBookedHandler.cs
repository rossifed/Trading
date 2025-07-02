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
    internal class TradeBookedHandler : IEventHandler<TradeBooked>
    {
        private IBookedTradeAllocationDao BookedTradeAllocationDao { get; }
        private ILogger<TradeBookedHandler> Logger { get; }
 
        public TradeBookedHandler(
            IBookedTradeAllocationDao bokedTradeAllocationDao,
            ILogger<TradeBookedHandler> logger)              
        {
            this.Logger = logger;
            this.BookedTradeAllocationDao = bokedTradeAllocationDao;
        }

     
        public async Task HandleAsync(TradeBooked @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");
            await BookedTradeAllocationDao.UpsertRangeAsync(@event.Trade.Map());
        }

    }

}
