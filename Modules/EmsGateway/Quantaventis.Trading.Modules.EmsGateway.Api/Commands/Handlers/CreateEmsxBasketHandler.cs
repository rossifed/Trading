using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class CreateEmsxBasketHandler : ICommandHandler<CreateEmsxBasket>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxGatewayService { get; }



        private ILogger<CreateEmsxBasketHandler> Logger { get; }


        public CreateEmsxBasketHandler(
            IEmsxGatewayService wmsxGatewayService,
            IMessageBroker messageBroker,
            ILogger<CreateEmsxBasketHandler> logger)
        {
            this.EmsxGatewayService = wmsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(CreateEmsxBasket command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Creating Basket...");
            await EmsxGatewayService.CreateBasketAsync(command.BasketName, command.OrderRefIds);

        }

    }

}
