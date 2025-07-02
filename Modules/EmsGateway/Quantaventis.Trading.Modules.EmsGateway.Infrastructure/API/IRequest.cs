using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
   public  interface IRequest<ResponseType>
    {
         String RequestType { get; }
         CorrelationID CorrelationID { get; }
         Request CreateRequest(Service service);
         IResponseEventHandler<ResponseType> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher);

    }
}
