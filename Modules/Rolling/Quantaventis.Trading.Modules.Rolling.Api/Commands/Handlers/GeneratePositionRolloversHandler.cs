using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Pricing.Api.Commands;
using Quantaventis.Trading.Modules.Rolling.Domain.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rolling.Api.Events.Handlers
{
    internal class GeneratePositionRolloverHandler : ICommandHandler<GeneratePositionRollovers>
    {

        private IPositionRollingService PositionRollingService { get; }

        private ILogger<GeneratePositionRolloverHandler> Logger { get; }
        public GeneratePositionRolloverHandler(IPositionRollingService positionRollingService,
            IMessageBroker messageBroker,
            ILogger<GeneratePositionRolloverHandler> logger) { 
            this.PositionRollingService = positionRollingService;
            this.Logger = logger;

        
        }
        public async Task HandleAsync(GeneratePositionRollovers command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received..");
            await PositionRollingService.GenerateRolloversAsync();
            Logger.LogInformation($"Command {command} Handled");
        }
    }
}
