using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    internal interface IMessageProcessor
    {

        void ProcessMessages(IEnumerable<Message> messages, Session session);
        void ProcessMessage(Message msg, Session session);
    }
}
