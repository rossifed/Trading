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
    internal class CorrectTradeHandler : ICommandHandler<CorrectTrade>
    {

        private ITradeCorrectionService TradeCorrectionService { get; }

        public CorrectTradeHandler(ITradeCorrectionService tradeCorrectionService)
        {
            this.TradeCorrectionService = tradeCorrectionService;
        }

        public async Task HandleAsync(CorrectTrade command, CancellationToken cancellationToken = default)
        {
            await TradeCorrectionService.CorrectTradeAsync(command.TradeId, command.TradeCorrection);
        }
    }
}
