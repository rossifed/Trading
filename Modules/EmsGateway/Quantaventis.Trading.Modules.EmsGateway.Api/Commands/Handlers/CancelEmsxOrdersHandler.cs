using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal class CancelEmsxOrdersHandler : ICommandHandler<CancelEmsxOrders>
    {

        private IMessageBroker MessageBroker { get; }
        private IEmsxGatewayService EmsxService { get; }



        private ILogger<CancelEmsxOrderByRebalIdHandler> Logger { get; }


        public CancelEmsxOrdersHandler(
            IEmsxGatewayService emsxService,
            IMessageBroker messageBroker,
            ILogger<CancelEmsxOrderByRebalIdHandler> logger)
        {
            this.EmsxService = emsxService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(CancelEmsxOrders command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Canceling {command.OrderRefIds.Count()} EmsxOrders OrderRefId...");
            await EmsxService.CancelEmsxOrdersByRefIdAsync(command.OrderRefIds);

        }

    }

}
