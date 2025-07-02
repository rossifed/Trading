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
    internal class ForceAllocationHandler : ICommandHandler<ForceAllocation>
    {

        private ITradeAllocationService TradeAllocationService { get; }

        public ForceAllocationHandler(ITradeAllocationService tradeAllocationService)
        {
            this.TradeAllocationService = tradeAllocationService;
        }

        public async Task HandleAsync(ForceAllocation command, CancellationToken cancellationToken = default)
        {
            await TradeAllocationService.ForceAllocationAsync(command.TradeId, command.PortfolioId, command.positionSide);
        }
    }
}
