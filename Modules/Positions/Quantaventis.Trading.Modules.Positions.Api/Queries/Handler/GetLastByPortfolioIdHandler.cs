using Quantaventis.Trading.Modules.Positions.Api.Dto;
using Quantaventis.Trading.Modules.Positions.Api.Mappers;
using Quantaventis.Trading.Modules.Positions.Api.Queries.In;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.Positions.Api.Queries.Handler
{
    internal class GetLastByPortfolioIdHandler : IQueryHandler<GetLastByPortfolioId, IEnumerable<PositionDto>>
    {
        private IPositionRepository PositionRepository { get; }

        public GetLastByPortfolioIdHandler(IPositionRepository positionRepository)
        {
            PositionRepository = positionRepository;
        }

        public async Task<IEnumerable<PositionDto>> HandleAsync(GetLastByPortfolioId query, CancellationToken cancellationToken = default)
        {
          IEnumerable<Position> positions =await  PositionRepository.GetLastByPortfolioIdAsync(query.PortfolioId);

            return positions.Map();
        }
    }
}
