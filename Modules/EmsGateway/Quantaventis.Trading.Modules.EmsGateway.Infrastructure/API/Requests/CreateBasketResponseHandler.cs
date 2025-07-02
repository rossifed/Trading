using Bloomberglp.Blpapi;
using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateBasketResponseHandler : AbstractResponseHandler<CreateBasketRequest,CreateBasketResponse>
    {
        public CreateBasketResponseHandler(IEmsxEventHandler messageEventDispatcher, CreateBasketRequest createBasketRequest) : base(messageEventDispatcher, createBasketRequest)
        {

        }

        protected override CreateBasketResponse CreateResponse(Message msg)
        {
            String message = msg.GetElementAsString(MESSAGE);
            return new CreateBasketResponse( message, Request);
        }
    }
}
