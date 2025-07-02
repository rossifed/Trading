using Quantaventis.Trading.Modules.Booking.Api.Commands.In;
using Quantaventis.Trading.Modules.Booking.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Booking.Api.Commands.Handlers
{
    internal class BookNonBookedTradesHandler : ICommandHandler<BookNonBookedTrades>
    {

        private ITradeBookingService TradeBookingService { get; }

        public BookNonBookedTradesHandler(ITradeBookingService tradeBookingService)
        {
            this.TradeBookingService = tradeBookingService;
        }

        public async Task HandleAsync(BookNonBookedTrades command, CancellationToken cancellationToken = default)
        {
            await TradeBookingService.BookNonBookedTradesAsync();
        }
    }
}
