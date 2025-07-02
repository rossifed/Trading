using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class DeleteOrderResponseHandler : AbstractResponseHandler<DeleteOrderRequest, DeleteOrderResponse>
    {

        public DeleteOrderResponseHandler(IEmsxEventHandler messageEventDispatcher, DeleteOrderRequest request) 
            : base(messageEventDispatcher, request)
        {

        }

        protected override DeleteOrderResponse CreateResponse(Message msg)
        {
            int emsx_sequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            String message = msg.GetElementAsString(MESSAGE);
            return new DeleteOrderResponse(emsx_sequence, message, Request);
        }
    }
}
