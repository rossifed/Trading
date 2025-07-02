using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class CancelEmsxOrderByRebalIdHandler : ICommandHandler<CancelEmsxOrderByRebalId>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxService { get; }



        private ILogger<CancelEmsxOrderByRebalIdHandler> Logger { get; }


        public CancelEmsxOrderByRebalIdHandler(
            IEmsxGatewayService emsxService,
            IMessageBroker messageBroker,
            ILogger<CancelEmsxOrderByRebalIdHandler> logger)
        {
            this.EmsxService = emsxService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(CancelEmsxOrderByRebalId command, CancellationToken cancellationToken = default)
        {
            await EmsxService.CancelEmsxOrderByRebalancingIdAsync(command.RebalancingSessionId);
        }

    }

}
