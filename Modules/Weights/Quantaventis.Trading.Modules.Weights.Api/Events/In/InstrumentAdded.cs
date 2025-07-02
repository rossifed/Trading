using Quantaventis.Trading.Modules.Weights.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Weights.Api.Events.Out
{
    internal record InstrumentAdded(InstrumentDto Instrument) : IEvent;

}
