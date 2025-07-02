using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Modules.EFRP.Api.Mappers;
using Quantaventis.Trading.Modules.EFRP.Api.Queries.In;
using Quantaventis.Trading.Modules.EFRP.Api.Services;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.EFRP.Api.Queries.Handlers
{
    internal sealed class GetEfrpConversionInfoHandler : IQueryHandler<GetEfrpConversionInfo, IEnumerable<EfrpConversionInfoDto>>
    {
 
        private IEfrpConversionService EfrpConversionService { get; }
        private ILogger<GetEfrpConversionInfoHandler> Logger { get; }
        public GetEfrpConversionInfoHandler(
            IEfrpConversionService efrpConversionService,
            ILogger<GetEfrpConversionInfoHandler> logger) {
            this.Logger= logger;
            this.EfrpConversionService = efrpConversionService;
        }
        public async Task<IEnumerable<EfrpConversionInfoDto>> HandleAsync(GetEfrpConversionInfo query, CancellationToken cancellationToken = default)
        {
            var efrpCandidateDtos = query.EfrpCandidates;
            IEnumerable<IEfrpCandidate> efrpCandidates = efrpCandidateDtos.Map();
            var entities = await EfrpConversionService.GetEfrpConversionInfosAsync(efrpCandidates);
            return entities.Map();
        }

       
    }
}
