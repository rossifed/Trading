using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CancelRouteResponseHandler : AbstractResponseHandler<CancelRouteRequest, CancelRouteResponse>
    {

        public CancelRouteResponseHandler(IEmsxEventHandler messageEventDispatcher,
            CancelRouteRequest request)
            : base(messageEventDispatcher, request)
        {

        }

        protected override CancelRouteResponse CreateResponse(Message msg)
        {
            int status = msg.GetElementAsInt32(STATUS);
            String message = msg.GetElementAsString(MESSAGE);
            return new CancelRouteResponse(status, message, Request);
        }
    }
}
