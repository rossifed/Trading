using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateOrderResponseHandler : AbstractResponseHandler<CreateOrderRequest, CreateOrderResponse>
    {

        public CreateOrderResponseHandler(
            IEmsxEventHandler messageEventDispatcher,
            CreateOrderRequest request)
            : base(messageEventDispatcher, request)
        {

        }


        protected override CreateOrderResponse CreateResponse(Message msg)
        {
            int emsx_sequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            String message = msg.GetElementAsString(MESSAGE);
            return new CreateOrderResponse(emsx_sequence, message, Request);
        }
    }
}
