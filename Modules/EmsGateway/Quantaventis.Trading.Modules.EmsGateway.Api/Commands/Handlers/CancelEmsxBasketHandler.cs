using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class CancelEmsxBasketHandler : ICommandHandler<CancelEmsxBasket>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxOrderManagementService { get; }



        private ILogger<CancelEmsxBasketHandler> Logger { get; }


        public CancelEmsxBasketHandler(
            IEmsxGatewayService emsxOrderManagementService,
            IMessageBroker messageBroker,
            ILogger<CancelEmsxBasketHandler> logger)
        {
            this.EmsxOrderManagementService = emsxOrderManagementService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(CancelEmsxBasket command, CancellationToken cancellationToken = default)
        {

            await EmsxOrderManagementService.CancelBasketAsync(command.BasketName);

        }

    }

}
