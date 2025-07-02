using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Commands.Handlers
{
    internal class ForceCancelHandler : ICommandHandler<ForceCancel>
    {

        private IMessageBroker MessageBroker { get; }


        private IRebalancingService RebalancingService { get; }

        private ILogger<ForceCancelHandler> Logger { get; }


        public ForceCancelHandler(
            IRebalancingService rebalancingService,
            IMessageBroker messageBroker,
            ILogger<ForceCancelHandler> logger)
        {
            this.RebalancingService = rebalancingService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }

     
        public async Task HandleAsync(ForceCancel command, CancellationToken cancellationToken = default)
        {

           await RebalancingService.ConfirmRebalancingCancelled(command.RebalancingSessionId);
        }

    }

}
