using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Events.Out;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using System.Linq;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class TriggerEmsxOrdersSyncEventHandler : ICommandHandler<TriggerEmsxOrdersSync>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxGatewayService { get; }



        private ILogger<TriggerEmsxOrdersSyncEventHandler> Logger { get; }


        public TriggerEmsxOrdersSyncEventHandler(
            IEmsxGatewayService emsxGatewayService,
            IMessageBroker messageBroker,
            ILogger<TriggerEmsxOrdersSyncEventHandler> logger)
        {
            this.EmsxGatewayService = emsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(TriggerEmsxOrdersSync command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Received command {command}");
            await EmsxGatewayService.TriggerEmsxOrdersSyncEvent();
      
        }

    }

}
