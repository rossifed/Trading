using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class RouteEmsxBasketOrdersHandler : ICommandHandler<RouteEmsxBasketOrders>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxGatewayService { get; }



        private ILogger<RouteEmsxBasketOrdersHandler> Logger { get; }


        public RouteEmsxBasketOrdersHandler(
            IEmsxGatewayService emsxGatewayService,
            IMessageBroker messageBroker,
            ILogger<RouteEmsxBasketOrdersHandler> logger)
        {
            this.EmsxGatewayService = emsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(RouteEmsxBasketOrders command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Routing Basket {command.BasketName}...");
           // await EmsxGatewayService.RouteBasketAsync(command.BasketName);

        }

    }

}
