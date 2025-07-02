using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Valuation.Api.Events.In
{
    internal record InstrumentsUpdated(DateTime UpdateDateTimeUtc) : IEvent;

}
