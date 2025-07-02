using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal interface ISubscriptionMessage
    {
        public CorrelationID CorrelationID { get; }
        public DateTime TimeReceived { get; }
    }
}
