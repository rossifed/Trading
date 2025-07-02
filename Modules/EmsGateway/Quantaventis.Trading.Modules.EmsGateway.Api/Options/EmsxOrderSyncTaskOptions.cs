using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Options
{
    public class EmsxOrderSyncTaskOptions : ScheduledTaskOptions
    {
        public string CronExpression { get; set; }
       
    }


}
