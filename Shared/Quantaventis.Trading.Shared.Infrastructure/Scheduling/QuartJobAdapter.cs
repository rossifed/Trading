using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Infrastructure.Scheduling
{
    [DisallowConcurrentExecution]
    internal class QuartJobAdapter<TJob> : IJob where TJob : IScheduledTask
    {
        private TJob Job { get; }

        public QuartJobAdapter(TJob job)
        {
            Job = job;
        }

        public async Task Execute(IJobExecutionContext context)
        {
           await  Job.ExecuteAsync();
        }
    }
}
