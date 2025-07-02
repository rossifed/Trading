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
    internal sealed class GetBasketOrdersHandler : IQueryHandler<GetBasketOrders, IEnumerable<EmsxOrderDto>>
    {
       private IEmsxService EmsxService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetBasketOrdersHandler> Logger { get; }
        public GetBasketOrdersHandler(IEmsxService emsxService,
            IMessageBroker messageBroker,
            ILogger<GetBasketOrdersHandler> logger) {

            this.EmsxService = emsxService;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<IEnumerable<EmsxOrderDto>> HandleAsync(GetBasketOrders query, CancellationToken cancellationToken = default)
        {
            IEnumerable<EmsxOrder> emsxOrders = await EmsxService.GetOrdersByBasketAsync(query.BasketName);
            return emsxOrders.Map();
        }
    }
}
