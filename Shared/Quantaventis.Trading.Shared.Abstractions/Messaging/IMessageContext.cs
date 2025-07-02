using System;
using Quantaventis.Trading.Shared.Abstractions.Contexts;

namespace Quantaventis.Trading.Shared.Abstractions.Messaging
{

    public interface IMessageContext
    {
        public Guid MessageId { get; }
        public IContext Context { get; }
    }
}
