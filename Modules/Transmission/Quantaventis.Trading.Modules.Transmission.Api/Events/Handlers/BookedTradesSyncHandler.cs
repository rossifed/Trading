using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Events.Out;
using Quantaventis.Trading.Modules.Transmission.Api.Events.In;
using Quantaventis.Trading.Modules.Transmission.Api.Events.Out;
using Quantaventis.Trading.Modules.Transmission.Api.Mappers;
using Quantaventis.Trading.Modules.Transmission.Api.Services;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Transmission.Api.Events.Handlers
{
    internal class BookedTradesSyncHandler : IEventHandler<BookedTradesSync>
    {
        private IBookedTradeAllocationDao BookedTradeAllocationDao { get; }
        private ILogger<BookedTradesSyncHandler> Logger { get; }

        public BookedTradesSyncHandler(
            IBookedTradeAllocationDao bokedTradeAllocationDao,
            ILogger<BookedTradesSyncHandler> logger)
        {
            this.Logger = logger;
            this.BookedTradeAllocationDao = bokedTradeAllocationDao;
        }


        public async Task HandleAsync(BookedTradesSync @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received...");
            await BookedTradeAllocationDao.UpsertRangeAsync(@event.Trades.Map());
        }

    }

}
