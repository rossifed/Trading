using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers
{
    internal class CreateBasketResponseParser : IMessageParser<CreateBasketResponse>
    {
        public CreateBasketResponse Parse(Message msg)
        {
            String message = msg.GetElementAsString(MESSAGE);
            return new CreateBasketResponse(message);
        }
    }
}
