using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.Handlers
{
    internal sealed class GetFilledEmsxOrdersHandler : IQueryHandler<GetFilledEmsxOrders, IEnumerable<EmsxOrderDto>>
    {
       private IEmsxGatewayService EmsxOrderManagementService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetFilledEmsxOrdersHandler> Logger { get; }
        public GetFilledEmsxOrdersHandler(IEmsxGatewayService emsxOrderManagementService,
            IMessageBroker messageBroker,
            ILogger<GetFilledEmsxOrdersHandler> logger) {

            this.EmsxOrderManagementService = emsxOrderManagementService;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<IEnumerable<EmsxOrderDto>> HandleAsync(GetFilledEmsxOrders query, CancellationToken cancellationToken = default)
        {
            var emsxOrders = await EmsxOrderManagementService.GetFilledEmsxOrdersAsync(query.IncludePartialFill);
            return emsxOrders.Map();
        }
    }
}
