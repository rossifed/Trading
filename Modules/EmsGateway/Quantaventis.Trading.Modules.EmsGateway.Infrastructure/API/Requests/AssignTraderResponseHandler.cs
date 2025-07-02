using Element = Bloomberglp.Blpapi.Element;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class AssignTraderResponseHandler : AbstractResponseHandler<AssignTraderRequest, AssignTraderResponse>
    {
        public AssignTraderResponseHandler(IEmsxEventHandler messageEventDispatcher, AssignTraderRequest assignTraderRequest) : base(messageEventDispatcher, assignTraderRequest)
        {

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

        private IEnumerable<int> GetSequences(Message msg)
        {
            Element successful = msg.GetElement(EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS);
            int numValues = successful.NumValues;

            return Enumerable.Range(0, numValues).Select(i => successful
                                                      .GetValueAsElement(i)
                                                      .GetElement(EMSX_SEQUENCE)
                                                      .GetValueAsInt32())
                                                      .ToList();
        }

        protected override AssignTraderResponse CreateResponse(Message msg)
        {
            AssignTraderStatus status = GetStatus(msg);
            IEnumerable<int> sequences = GetSequences(msg);
            return new AssignTraderResponse(status, sequences, Request);
        }


    }
}
