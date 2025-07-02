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
    internal class CreateManualTradeHandler : ICommandHandler<CreateManualTrade>
    {

        private IManualTradeCaptureService ManualTradeCaptureService { get; }

        public CreateManualTradeHandler(IManualTradeCaptureService manualTradeCaptureService)
        {
            this.ManualTradeCaptureService = manualTradeCaptureService;
        }

        public async Task HandleAsync(CreateManualTrade command, CancellationToken cancellationToken = default)
        {
            await ManualTradeCaptureService.CaptureManualTradeAsync(command.ManualTrade);
        }
    }
}
