using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CancelOrderResponseHandler : AbstractResponseHandler<CancelOrderRequest, CancelOrderResponse>
    {
        public CancelOrderResponseHandler(
            IEmsxEventHandler messageEventDispatcher, 
            CancelOrderRequest request) 
            : base(messageEventDispatcher, request)
        {

        }


        protected override CancelOrderResponse CreateResponse(Message msg)
        {
            int status = msg.GetElementAsInt32(STATUS);
            String message = msg.GetElementAsString(MESSAGE);
            return new CancelOrderResponse(status, message, Request);
        }

       
    }
}
