using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Module.EFRP.Infrastructure.Events.In
{
   public record  FileWatcherEvent(string EventType, 
       string Topic, 
       string FolderPath, 
       string FilePath, 
       Dictionary<string, string> Metadata) : IEvent;

}
