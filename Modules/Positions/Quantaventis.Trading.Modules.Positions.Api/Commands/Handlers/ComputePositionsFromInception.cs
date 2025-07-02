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
    internal class ComputePositionsFromInceptionHandler : ICommandHandler<ComputePositionsFromInception>
    {

       private IPositionKeepingService PositionKeepingService { get; }
        private ILogger<ComputePositionsFromInceptionHandler> Logger { get; }

        public ComputePositionsFromInceptionHandler(
            IPositionKeepingService positionKeepingService, 
            ILogger<ComputePositionsFromInceptionHandler> logger)
        {
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }

        public async Task HandleAsync(ComputePositionsFromInception command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received...");
           await  PositionKeepingService.ComputePositionsFromInceptionAsync(command.PortfolioId, command.InstrumentId, command.IsSwap);
        }
    }
}
