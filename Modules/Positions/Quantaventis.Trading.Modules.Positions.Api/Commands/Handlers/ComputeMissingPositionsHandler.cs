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
    internal class ComputeMissingPositionsHandler : ICommandHandler<ComputeMissingPositions>
    {

        private IPositionKeepingService PositionKeepingService { get; }
        private ILogger<ComputeMissingPositionsHandler> Logger { get; }

        public ComputeMissingPositionsHandler(
            IPositionKeepingService positionKeepingService,
            ILogger<ComputeMissingPositionsHandler> logger)
        {
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }

        public async Task HandleAsync(ComputeMissingPositions command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received...");
            await PositionKeepingService.ComputeMissingPositionsAsync(command.PortfolioId);
        }
    }
}
