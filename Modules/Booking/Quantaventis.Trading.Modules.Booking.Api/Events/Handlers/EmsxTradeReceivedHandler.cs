using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Booking.Api.Events.In;
using Quantaventis.Trading.Modules.Booking.Api.Services;
namespace Quantaventis.Trading.Modules.Booking.Api.Events.Handlers
{
    internal class EmsxTradeReceivedHandler : IEventHandler<EmsxTradeReceived>
    {

        private ILogger<EmsxTradeReceivedHandler> Logger { get; }
        private ITradeBookingService TradeBookingService { get; }

        public EmsxTradeReceivedHandler(ITradeBookingService tradeBookingService, ILogger<EmsxTradeReceivedHandler> logger)
        {
            Logger = logger;
            TradeBookingService = tradeBookingService;
        }

        public async Task HandleAsync(EmsxTradeReceived @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"{@event} received..");
           await TradeBookingService.OnEmsxTradeReceived(@event.EmsxTrade);
        }

    }

}
