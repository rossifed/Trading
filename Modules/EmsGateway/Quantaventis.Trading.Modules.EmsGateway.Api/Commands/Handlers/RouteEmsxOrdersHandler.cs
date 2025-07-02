using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Api.Events.Out;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class RouteEmsxOrdersHandler : ICommandHandler<RouteEmsxOrders>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxGatewayService { get; }



        private ILogger<RouteEmsxOrdersHandler> Logger { get; }


        public RouteEmsxOrdersHandler(
            IEmsxGatewayService emsxGatewayService,
            IMessageBroker messageBroker,
            ILogger<RouteEmsxOrdersHandler> logger)
        {
            this.EmsxGatewayService = emsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(RouteEmsxOrders command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Routing {command.OrderRefIds.Count()} EmsxOrders ...");
          //  await EmsxGatewayService.RouteEmsxOrdersByRefIdAsync(command.OrderRefIds);
        }

    }

}
