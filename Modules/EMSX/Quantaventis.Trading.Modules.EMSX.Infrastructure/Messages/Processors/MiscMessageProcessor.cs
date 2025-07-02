using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal interface IMiscMessageProcessor : IMessageProcessor { };
    internal class MiscMessageProcessor : AbstractMessageProcessor, IMiscMessageProcessor
    {
        private IEnumerable<IMiscMessageHandler> MiscMessageHandlers { get; }


        public MiscMessageProcessor(
            IEnumerable<IMiscMessageHandler> miscMessageHandlers)
        {
            MiscMessageHandlers = miscMessageHandlers;
        
        }

        public override void ProcessMessage(Message msg, Session session)
        {
            foreach (var handler in MiscMessageHandlers)
            {
                handler.OnMiscMessage(msg, session);
            }          
        }
    }
}
