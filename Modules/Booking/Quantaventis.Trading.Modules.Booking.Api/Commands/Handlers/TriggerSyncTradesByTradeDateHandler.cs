using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Api.Commands.In;
using Quantaventis.Trading.Modules.Booking.Api.Services;

using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Booking.Api.Commands.Handlers
{
    internal class TriggerSyncTradesByTradeDateHandler : ICommandHandler<TriggerSyncTradesByTradeDate>
    {

        private ITradeSynchronizationService TradeSynchronizationService { get; }

        public TriggerSyncTradesByTradeDateHandler(ITradeSynchronizationService tradeSynchronizationService)
        {
            this.TradeSynchronizationService = tradeSynchronizationService;
        }

        public async Task HandleAsync(TriggerSyncTradesByTradeDate command, CancellationToken cancellationToken = default)
        {
            await TradeSynchronizationService.TriggerSyncTradesByTradeDate(command.TradeDate);
        }
    }
}
