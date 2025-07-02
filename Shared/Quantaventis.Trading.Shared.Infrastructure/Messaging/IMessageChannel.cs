using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;
namespace Quantaventis.Trading.Shared.Infrastructure.Messaging
{
    internal interface IMessageChannel
    {

        ChannelReader<MessageEnvelope>  Reader { get; }
        ChannelWriter<MessageEnvelope> Writer { get; }
    }

   
}
