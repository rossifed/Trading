using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Positions.Api.Commands.In;
using Quantaventis.Trading.Modules.Positions.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Positions.Api.Commands.Handlers
{
    internal class ComputeAllPositionsFromDateHandler : ICommandHandler<ComputeAllPositionsFromDate>
    {

        private IPositionKeepingService PositionKeepingService { get; }
        private ILogger<ComputeAllPositionsFromDateHandler> Logger { get; }

        public ComputeAllPositionsFromDateHandler(
            IPositionKeepingService positionKeepingService,
            ILogger<ComputeAllPositionsFromDateHandler> logger)
        {
            PositionKeepingService = positionKeepingService;
            Logger = logger;
        }

        public async Task HandleAsync(ComputeAllPositionsFromDate command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received...");
            await PositionKeepingService.ComputeAllPositionsFromDateAsync(command.PortfolioId, command.FromDate);
        }
    }
}
