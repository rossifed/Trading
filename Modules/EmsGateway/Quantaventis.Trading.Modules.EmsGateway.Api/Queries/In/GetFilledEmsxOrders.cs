using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In
{
    internal record GetFilledEmsxOrders(bool IncludePartialFill) : IQuery<IEnumerable<EmsxOrderDto>>
    {

    }
}
