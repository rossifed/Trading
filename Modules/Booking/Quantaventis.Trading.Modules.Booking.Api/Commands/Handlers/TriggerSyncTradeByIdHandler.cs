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
    internal class TriggerSyncTradeByIdHandler : ICommandHandler<TriggerSyncTradeById>
    {

        private ITradeSynchronizationService TradeSynchronizationService { get; }

        public TriggerSyncTradeByIdHandler(ITradeSynchronizationService tradeSynchronizationService)
        {
            this.TradeSynchronizationService = tradeSynchronizationService;
        }

        public async Task HandleAsync(TriggerSyncTradeById command, CancellationToken cancellationToken = default)
        {
            await TradeSynchronizationService.TriggerSyncTradeById(command.TradeId);
        }
    }
}
