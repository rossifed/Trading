using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Positions.Api.Commands.In;
using Quantaventis.Trading.Modules.Positions.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Positions.Api.Commands.Handlers
{
    internal class ComputePositionsFromDateHandler : ICommandHandler<ComputePositionsFromDate>
    {

        private IPositionKeepingService PositionKeepingService { get; }
        private ILogger<ComputePositionsFromDateHandler> Logger { get; }

        public ComputePositionsFromDateHandler(
            IPositionKeepingService positionKeepingService,
            ILogger<ComputePositionsFromDateHandler> logger)
        {
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }

        public async Task HandleAsync(ComputePositionsFromDate command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received...");
            await PositionKeepingService.ComputePositionsFromDateAsync(command.PortfolioId, command.InstrumentId, command.IsSwap, command.FromDate);
        }
    }
}
