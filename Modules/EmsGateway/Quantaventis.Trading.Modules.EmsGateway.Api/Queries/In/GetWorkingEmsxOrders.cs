using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In
{
    internal record GetWorkingEmsxOrders() : IQuery<IEnumerable<EmsxOrderDto>>
    {

    }
}
