using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Message = Bloomberglp.Blpapi.Message;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers
{

    internal class AssignTraderResponseParser : IMessageParser<AssignTraderResponse>
    {
        public AssignTraderResponse Parse(Message msg)
        {
            var successfullSequences = Enumerable.Empty<int>();
            var failedSequences = Enumerable.Empty<int>();
            if (msg.GetElementAsBool(EMSX_ALL_SUCCESS))
            {
                successfullSequences = GetSequences(msg, EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS);
            }
            else
            {
                if (msg.HasElement(EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS))
                    successfullSequences = GetSequences(msg, EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS);
                if (msg.HasElement(EMSX_ASSIGN_TRADER_FAILED_ORDERS))
                    failedSequences = GetSequences(msg, EMSX_ASSIGN_TRADER_FAILED_ORDERS);
            }
            return new AssignTraderResponse(successfullSequences, failedSequences);
        }
        private IEnumerable<int> GetSequences(Message msg, Name name)
        {
            Element successful = msg.GetElement(name);
            int numValues = successful.NumValues;
            return Enumerable.Range(0, numValues).Select(i => successful
                                                      .GetValueAsElement(i)
                                                      .GetElement(EMSX_SEQUENCE)
                                                      .GetValueAsInt32())
                                                      .ToList();
        }

        private AssignTraderStatus GetStatus(Message msg)
        {
            if (msg.GetElementAsBool(EMSX_ALL_SUCCESS))
            {
                return AssignTraderStatus.FullSuccess;


            }
            else
            {
                if (msg.HasElement(EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS))
                    return AssignTraderStatus.PartialSuccess;
                if (msg.HasElement(EMSX_ASSIGN_TRADER_FAILED_ORDERS))
                    return AssignTraderStatus.Failure;

            }
            return AssignTraderStatus.Unknown;
        }
    }
}
