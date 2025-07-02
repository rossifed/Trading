using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Events.Out
{
    internal record InstrumentAdded(InstrumentDto Instrument) : IEvent;

}
