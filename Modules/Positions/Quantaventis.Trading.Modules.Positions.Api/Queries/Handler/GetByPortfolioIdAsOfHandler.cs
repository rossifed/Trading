using Quantaventis.Trading.Modules.Positions.Api.Dto;
using Quantaventis.Trading.Modules.Positions.Api.Mappers;
using Quantaventis.Trading.Modules.Positions.Api.Queries.In;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.Positions.Api.Queries.Handler
{
    internal class GetByPortfolioIdAsOfHandler : IQueryHandler<GetByPortfolioIdAsOf, IEnumerable<PositionDto>>
    {
        private IPositionRepository PositionRepository { get; }

        public GetByPortfolioIdAsOfHandler(IPositionRepository positionRepository)
        {
            PositionRepository = positionRepository;
        }

        public async Task<IEnumerable<PositionDto>> HandleAsync(GetByPortfolioIdAsOf query, CancellationToken cancellationToken = default)
        {
          IEnumerable<Position> positions =await  PositionRepository.GetByPortfolioIdAsOfAsync(query.PortfolioId, query.AsOfDate);

            return positions.Map();
        }
    }
}
