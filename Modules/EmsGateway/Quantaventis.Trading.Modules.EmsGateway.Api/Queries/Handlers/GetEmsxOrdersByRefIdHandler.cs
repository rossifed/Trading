using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.Handlers
{
    internal sealed class GetEmsxOrdersByRefIdHandler : IQueryHandler<GetEmsxOrdersByRefId, IEnumerable<EmsxOrderDto>>
    {
       private IEmsxGatewayService EmsxGatewayService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetEmsxOrdersByRefIdHandler> Logger { get; }
        public GetEmsxOrdersByRefIdHandler(IEmsxGatewayService emsxGatewayService,
            IMessageBroker messageBroker,
            ILogger<GetEmsxOrdersByRefIdHandler> logger) {

            this.EmsxGatewayService = emsxGatewayService;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<IEnumerable<EmsxOrderDto>> HandleAsync(GetEmsxOrdersByRefId query, CancellationToken cancellationToken = default)
        {
            var emsxOrder = await EmsxGatewayService.GetEmsxOrdersByRefIdAsync(query.OrderRefIds);
            return emsxOrder.Map();
        }
    }
}
