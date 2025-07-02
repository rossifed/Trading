using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.EFRP.Api.Events.In
{
    internal record FutureContractChainCompleted(IEnumerable<FutureContractDto> FutureContracts, GenericFutureDto GenericFuture) : IEvent;

}
