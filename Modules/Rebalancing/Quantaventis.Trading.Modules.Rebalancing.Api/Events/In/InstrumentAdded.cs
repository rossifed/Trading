using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Events.In
{
    internal record InstrumentAdded(InstrumentDto Instrument) : IEvent;

}
