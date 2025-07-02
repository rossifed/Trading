using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Subscriptions
{
    public class OrderSubscriptionEventHandler : AbstractSubscriptionEventHandler<OrderSubscriptionResponse>
    {


        public OrderSubscriptionEventHandler(CorrelationID correlationID, IEmsxEventHandler messageEventDispatcher, Action<CorrelationID, OrderSubscriptionResponse> onEventAction) : base(correlationID, messageEventDispatcher, onEventAction)
        {

        }

        protected override OrderSubscriptionResponse CreateResponse(Message msg)
        {
            return new OrderSubscriptionResponse(msg);
        }

    }



}
