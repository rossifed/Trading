using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Booking.Api.Events.In;
using Quantaventis.Trading.Modules.Booking.Api.Services;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Api.Events.Handlers
{
    internal class EfrpTradeReceivedHandler : IEventHandler<EfrpTradeReceived>
    {

  
       
        private IEfrpTradeCaptureService EfrpTradeCaptureService { get; }
        private ITradeBookingService TradeBookingService { get; }
        private ILogger<EfrpTradeReceivedHandler> Logger { get; }

        public EfrpTradeReceivedHandler(IEfrpTradeCaptureService efrpTradeCaptureService,
            ITradeBookingService tradeBookingService, 
            ILogger<EfrpTradeReceivedHandler> logger)
        {
            EfrpTradeCaptureService = efrpTradeCaptureService;
            TradeBookingService = tradeBookingService;
            Logger = logger;
        }

        public async Task HandleAsync(EfrpTradeReceived @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"{@event} received..");
          RawTrade capturedTrade =  await EfrpTradeCaptureService.CaptureTradeAsync(@event.PortfolioId,@event.EfrpTrade);
           await  TradeBookingService.BookTradeAsync(capturedTrade);
        }

    }

}
