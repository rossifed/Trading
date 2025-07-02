using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
using Quantaventis.Trading.Modules.Portfolios.Api.Queries.In;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Queries.Handlers
{
    internal sealed class GetAllPortfoliosHandler : IQueryHandler<GetAllPortfolios, IEnumerable<PortfolioDto>>
    {
       private IPortfolioDao PortfolioDao { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetAllPortfoliosHandler> Logger { get; }
        public GetAllPortfoliosHandler(IPortfolioDao portfolioDao,
            IMessageBroker messageBroker,
            ILogger<GetAllPortfoliosHandler> logger) {

            this.PortfolioDao = portfolioDao;
            this.MessageBroker = messageBroker;
            this.Logger= logger;
        }
        public async Task<IEnumerable<PortfolioDto>> HandleAsync(GetAllPortfolios query, CancellationToken cancellationToken = default)
        {
            var entities = await  PortfolioDao.GetAllAsync();
            return entities.Map();
        }
    }
}
