using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal abstract class AbstractMessageProcessor : IMessageProcessor
    {
        public abstract void ProcessMessage(Message msg, Session session);
    
        public void ProcessMessages(IEnumerable<Message> messages, Session session)
        {
         
            foreach (Message msg in messages)
            {
                ProcessMessage(msg, session);
            }
        }
    }
}
