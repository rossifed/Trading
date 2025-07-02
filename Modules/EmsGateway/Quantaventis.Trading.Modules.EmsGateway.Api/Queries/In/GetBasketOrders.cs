using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In
{
    internal record GetBasketOrders(string BasketName) : IQuery<IEnumerable<EmsxOrderDto>>
    {

    }
}
