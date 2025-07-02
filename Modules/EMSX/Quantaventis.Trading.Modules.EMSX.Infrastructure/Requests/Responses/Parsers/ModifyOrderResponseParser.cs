using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers
{
    internal class ModifyOrderResponseParser : IMessageParser<ModifyOrderResponse>
    {
        public ModifyOrderResponse Parse(Message msg)
        {
            int emsx_sequence = msg.GetElementAsInt32(EMSX_SEQUENCE);
            String message = msg.GetElementAsString(MESSAGE);
            return new ModifyOrderResponse(emsx_sequence, message);
        }
    }
}
