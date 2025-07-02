using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.Handlers
{
    internal sealed class GetCancelledEmsxOrdersHandler : IQueryHandler<GetCancelledEmsxOrders, IEnumerable<EmsxOrderDto>>
    {
       private IEmsxGatewayService EmsxOrderManagementService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetCancelledEmsxOrdersHandler> Logger { get; }
        public GetCancelledEmsxOrdersHandler(IEmsxGatewayService emsxOrderManagementService,
            IMessageBroker messageBroker,
            ILogger<GetCancelledEmsxOrdersHandler> logger) {

            this.EmsxOrderManagementService = emsxOrderManagementService;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<IEnumerable<EmsxOrderDto>> HandleAsync(GetCancelledEmsxOrders query, CancellationToken cancellationToken = default)
        {
            var emsxOrders = await EmsxOrderManagementService.GetCancelledEmsxOrdersAsync();
            return emsxOrders.Map();
        }
    }
}
