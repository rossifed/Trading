using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal class RouteSubscriptionMessage :ISubscriptionMessage
    {
        public CorrelationID CorrelationID { get; }
        public EmsxRouteDto EmsxRoute { get; }
        public DateTime TimeReceived { get; }
        internal RouteSubscriptionMessage(
            CorrelationID correlationID,
            DateTime timeReceived,
            EmsxRouteDto emsxRoute)
        {
            this.CorrelationID = correlationID;
            this.TimeReceived = timeReceived;
            this.EmsxRoute = emsxRoute;
        }
    }
}
