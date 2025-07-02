using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Shared.Infrastructure.Messaging
{
    internal class MessageChannel : IMessageChannel
    {
        private Channel<MessageEnvelope> Messages = Channel.CreateUnbounded<MessageEnvelope>();
        public ChannelReader<MessageEnvelope> Reader => Messages.Reader;

        public ChannelWriter<MessageEnvelope> Writer => Messages.Writer;
    }
}
