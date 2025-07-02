using Message = Bloomberglp.Blpapi.Message;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages
{
    internal interface IMessageParser<TParsedMessage>
    {
        TParsedMessage Parse(Message msg);
    }
}
