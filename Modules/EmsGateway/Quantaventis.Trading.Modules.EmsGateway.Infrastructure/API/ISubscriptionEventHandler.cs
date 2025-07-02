using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public interface ISubscriptionEventHandler<ResponseType>
    {
        CorrelationID SubscriptionId { get; }

        void Handle(Message evt);
        Task<IEnumerable<ResponseType>> GetResponseAsync();


        IEnumerable<ResponseType> GetResponse();

    }
}
