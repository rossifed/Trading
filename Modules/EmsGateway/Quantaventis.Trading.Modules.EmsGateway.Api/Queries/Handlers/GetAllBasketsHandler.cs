using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.Handlers
{
    internal sealed class GetAllBasketsHandler : IQueryHandler<GetAllBaskets, IEnumerable<string>>
    {
       private IEmsxGatewayService EmsxOrderManagementService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetAllBasketsHandler> Logger { get; }
        public GetAllBasketsHandler(IEmsxGatewayService emsxOrderManagementService,
            IMessageBroker messageBroker,
            ILogger<GetAllBasketsHandler> logger) {

            this.EmsxOrderManagementService = emsxOrderManagementService;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<IEnumerable<string>> HandleAsync(GetAllBaskets query, CancellationToken cancellationToken = default)
        {
            return await EmsxOrderManagementService.GetAllBasketsAsync();

        }
    }
}
