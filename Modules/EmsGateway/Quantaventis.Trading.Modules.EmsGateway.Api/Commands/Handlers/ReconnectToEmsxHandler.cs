using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class ReconnectToEmsxHandler : ICommandHandler<ReconnectToEmsx>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxOrderManagementService { get; }



        private ILogger<ReconnectToEmsxHandler> Logger { get; }


        public ReconnectToEmsxHandler(
            IEmsxGatewayService emsxOrderManagementService,
            IMessageBroker messageBroker,
            ILogger<ReconnectToEmsxHandler> logger)
        {
            this.EmsxOrderManagementService = emsxOrderManagementService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(ReconnectToEmsx command, CancellationToken cancellationToken = default)
        {

             EmsxOrderManagementService.ReconnectToEmsx();

        }

    }

}
