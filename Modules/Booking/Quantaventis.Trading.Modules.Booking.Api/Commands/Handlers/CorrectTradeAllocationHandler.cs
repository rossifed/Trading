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
    internal class CorrectTradeAllocationHandler : ICommandHandler<CorrectTradeAllocation>
    {

        private ITradeCorrectionService TradeCorrectionService { get; }

        public CorrectTradeAllocationHandler(ITradeCorrectionService tradeCorrectionService)
        {
            this.TradeCorrectionService = tradeCorrectionService;
        }

        public async Task HandleAsync(CorrectTradeAllocation command, CancellationToken cancellationToken = default)
        {
            await TradeCorrectionService.CorrectTradeAllocationAsync(command.TradeAllocationId, command.TradeAllocationCorrection);
        }
    }
}
