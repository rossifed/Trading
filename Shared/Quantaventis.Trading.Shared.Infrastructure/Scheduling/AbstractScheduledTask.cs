using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Infrastructure.Scheduling
{
    public abstract class AbstractScheduledTask : IScheduledTask
    {
        public string CronExpression { get; }
 

        public AbstractScheduledTask(string cronExpression)
        {
            CronExpression = cronExpression;
        }
        public AbstractScheduledTask(ScheduledTaskOptions options):this(options.CronExpression) {
        }
        public abstract Task ExecuteAsync();
    }
}
