using Quantaventis.Trading.Modules.Risk.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Risk.Api.Events.Out
{
    internal record InstrumentAdded(InstrumentDto Instrument) : IEvent;

}
