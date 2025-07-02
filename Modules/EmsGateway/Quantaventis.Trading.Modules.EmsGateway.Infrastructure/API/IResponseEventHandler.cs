using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public interface IResponseEventHandler<ResponseType>
    {
        CorrelationID RequestId { get; }

        void Handle(Message evt);

        Task<ResponseType> GetResponseAsync();


        ResponseType GetResponse();
    }
}
