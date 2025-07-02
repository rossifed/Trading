using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Commands.Handlers
{
    internal class CancelRebalancingHandler : ICommandHandler<CancelRebalancing>
    {

        private IMessageBroker MessageBroker { get; }


        private IRebalancingService RebalancingService { get; }

        private ILogger<CancelRebalancingHandler> Logger { get; }


        public CancelRebalancingHandler(
            IRebalancingService rebalancingService,
            IMessageBroker messageBroker,
            ILogger<CancelRebalancingHandler> logger)
        {
            this.RebalancingService = rebalancingService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }

     
        public async Task HandleAsync(CancelRebalancing command, CancellationToken cancellationToken = default)
        {
            
           await RebalancingService.StartRebalancingCancellation(command.RebalancingSessionId);
        }

    }

}
