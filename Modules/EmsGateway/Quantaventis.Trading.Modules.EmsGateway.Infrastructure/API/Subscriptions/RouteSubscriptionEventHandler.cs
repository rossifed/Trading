using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Subscriptions
{
    public class RouteSubscriptionEventHandler : AbstractSubscriptionEventHandler<RouteSubscriptionResponse>
    {


        public RouteSubscriptionEventHandler(CorrelationID correlationID, IEmsxEventHandler messageEventDispatcher, Action<CorrelationID, RouteSubscriptionResponse> onEventAction) : base(correlationID, messageEventDispatcher, onEventAction)
        {

        }

        protected override RouteSubscriptionResponse CreateResponse(Message msg)
        {
            return new RouteSubscriptionResponse(msg);
        }

    }



}
