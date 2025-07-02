using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Modules.Rebalancing.Api.Mappers;
using Quantaventis.Trading.Modules.Rebalancing.Api.Queries.In;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Rebalancing.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Queries.Handlers
{
    internal sealed class GetRebalancingSessionByIdHandler : IQueryHandler<GetRebalancingSessionById, RebalancingSessionDto?>
    {
        private IRebalancingSessionRepository RebalancingSessionRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetRebalancingSessionByIdHandler> Logger { get; }
        public GetRebalancingSessionByIdHandler(IRebalancingSessionRepository rebalancingSessionRepository,
            IMessageBroker messageBroker,
            ILogger<GetRebalancingSessionByIdHandler> logger) {

            this.RebalancingSessionRepository = rebalancingSessionRepository;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<RebalancingSessionDto?> HandleAsync(GetRebalancingSessionById query, CancellationToken cancellationToken = default)
        {
            var entity = await RebalancingSessionRepository.GetByIdAsync(query.RebalancingSessionId);
            return entity?.Map();
        }
    }
}
