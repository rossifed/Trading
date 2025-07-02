using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Queries.In;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Queries;
namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.Handlers
{
    internal sealed class GetEmsxFillsByOrderIdHandler : IQueryHandler<GetEmsxFillsByOrderId, IEnumerable<EmsxFillDto>>
    {
        private IFillHistoryService FillHistoryService { get; }

        private ILogger<GetEmsxFillsByOrderIdHandler> Logger { get; }
        public GetEmsxFillsByOrderIdHandler(IFillHistoryService fillHistoryService,
            ILogger<GetEmsxFillsByOrderIdHandler> logger)
        {

            this.FillHistoryService = fillHistoryService;

            this.Logger = logger;
        }

        public async Task<IEnumerable<EmsxFillDto>> HandleAsync(GetEmsxFillsByOrderId query, CancellationToken cancellationToken = default)
        {
          return await  FillHistoryService.GetFillsByOrderId(query.orderId);
        }
    }

}
