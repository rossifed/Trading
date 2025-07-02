using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.Handlers
{
    internal sealed class GetEmsxOrdersByStatusHandler : IQueryHandler<GetEmsxOrdersByStatus, IEnumerable<EmsxOrderDto>>
    {
       private IEmsxGatewayService EmsxGatewayService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetEmsxOrdersByStatusHandler> Logger { get; }
        public GetEmsxOrdersByStatusHandler(IEmsxGatewayService emsxGatewayService,
            IMessageBroker messageBroker,
            ILogger<GetEmsxOrdersByStatusHandler> logger) {

            this.EmsxGatewayService = emsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<IEnumerable<EmsxOrderDto>> HandleAsync(GetEmsxOrdersByStatus query, CancellationToken cancellationToken = default)
        {
            IEnumerable<EmsxOrder> emsxOrders = await EmsxGatewayService.GetEmsxOrdersByStatusAsync(query.Status);
            return emsxOrders.Map();
        }
    }
}
