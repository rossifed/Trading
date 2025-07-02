using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Api.Commands.In;
using Quantaventis.Trading.Modules.Booking.Api.Services;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Booking.Api.Commands.Handlers
{
    internal class BookTradeHandler : ICommandHandler<BookTrade>
    {

        private ITradeBookingService TradeBookingService { get; }

        public BookTradeHandler(ITradeBookingService tradeBookingService)
        {
            this.TradeBookingService = tradeBookingService;
        }

        public async Task HandleAsync(BookTrade command, CancellationToken cancellationToken = default)
        {
            await TradeBookingService.BookTradeAsync(command.TradeId, command.ForceRebook, command.FlagAsCorrected);
        }
    }
}
