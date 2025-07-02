using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers
{
    internal interface ISubscriptionMessageParser<TSubscriptionMessage> where TSubscriptionMessage:ISubscriptionMessage
    {
        TSubscriptionMessage Parse(Message msg);
    }
}
