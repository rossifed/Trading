using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Execution.Api.Options
{
    internal class QuartzSchedulerOptions
    {

        public Dictionary<string, QuartzJobOptions> Jobs { get; set; }
    }

    public class QuartzJobOptions
    {
        public string CronExpression { get; set; }
        // You can add more properties here if needed, such as JobType, etc.

        public string JobTypeName { get; set; }
    }
}
