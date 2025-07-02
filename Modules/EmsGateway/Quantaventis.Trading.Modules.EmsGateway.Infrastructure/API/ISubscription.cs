using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Service = Bloomberglp.Blpapi.Service;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public interface ISubscription<EventType>
    {
        string CreateTopic(Service service);
        ISubscriptionEventHandler<EventType> CreateSubscriptionEventHandler(CorrelationID correlationId, IEmsxEventHandler eventHandler, Action<CorrelationID, EventType> onEventAction);
    }

}
