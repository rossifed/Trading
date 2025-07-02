using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal class OrderSubscriptionMessage : ISubscriptionMessage
    {

        public CorrelationID CorrelationID { get; }
        public EmsxOrderDto EmsxOrder { get; }
        public DateTime TimeReceived { get; }
        internal OrderSubscriptionMessage(
            CorrelationID correlationID,
            DateTime timeReceived,
            EmsxOrderDto emsxOrder)
        {
            this.CorrelationID = correlationID;
            this.TimeReceived = timeReceived;
            this.EmsxOrder = emsxOrder;
        }

    }
}
