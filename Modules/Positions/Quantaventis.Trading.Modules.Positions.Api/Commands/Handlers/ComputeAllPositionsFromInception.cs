using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Positions.Api.Commands.In;
using Quantaventis.Trading.Modules.Positions.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Positions.Api.Commands.Handlers
{
    internal class ComputeAllPositionsFromInceptionHandler : ICommandHandler<ComputeAllPositionsFromInception>
    {

        private IPositionKeepingService PositionKeepingService { get; }
        private ILogger<ComputeAllPositionsFromInceptionHandler> Logger { get; }

        public ComputeAllPositionsFromInceptionHandler(
            IPositionKeepingService positionKeepingService,
            ILogger<ComputeAllPositionsFromInceptionHandler> logger)
        {
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }

        public async Task HandleAsync(ComputeAllPositionsFromInception command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received...");
            await PositionKeepingService.ComputeAllPositionsFromInceptionAsync(command.PortfolioId);
        }
    }
}
