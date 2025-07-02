using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Commands.Handlers
{
    internal class StartRebalancingHandler : ICommandHandler<StartRebalancing>
    {

        private IMessageBroker MessageBroker { get; }


        private IRebalancingService RebalancingService { get; }

        private ILogger<StartRebalancingHandler> Logger { get; }


        public StartRebalancingHandler(
            IRebalancingService rebalancingService,
            IMessageBroker messageBroker,
            ILogger<StartRebalancingHandler> logger)
        {
            this.RebalancingService = rebalancingService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }

     
        public async Task HandleAsync(StartRebalancing command, CancellationToken cancellationToken = default)
        {

           await RebalancingService.StartRebalancing();
        }

    }

}
