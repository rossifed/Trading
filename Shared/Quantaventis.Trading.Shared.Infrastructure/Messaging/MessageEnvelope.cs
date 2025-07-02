using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
namespace Quantaventis.Trading.Shared.Infrastructure.Messaging
{
    internal record MessageEnvelope(IMessage message);
}
