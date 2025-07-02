using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class ModifyOrderResponseHandler : AbstractResponseHandler<ModifyOrderRequest,ModifyOrderResponse>
    {

        public ModifyOrderResponseHandler(IEmsxEventHandler messageEventDispatcher, ModifyOrderRequest request)
            : base(messageEventDispatcher, request)
        {

        }


        protected override ModifyOrderResponse CreateResponse(Message msg)
        {
            int emsx_sequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            String message = msg.GetElementAsString(MESSAGE);
            return new ModifyOrderResponse(emsx_sequence, message, Request);
        }
    }
}
