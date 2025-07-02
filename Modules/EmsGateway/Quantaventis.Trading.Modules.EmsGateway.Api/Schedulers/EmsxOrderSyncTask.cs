using Quantaventis.Trading.Modules.EmsGateway.Api.Options;
using Quantaventis.Trading.Modules.EmsGateway.Api.Services;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Schedulers
{
    internal class EmsxOrderSyncTask : AbstractScheduledTask
    {      
        private IEmsxGatewayService EmsxGatewayService { get; }
        public EmsxOrderSyncTask(IEmsxGatewayService emsxGatewayService,
            EmsxOrderSyncTaskOptions scheduledTaskOptions
            ):base(scheduledTaskOptions)
        {   
            this.EmsxGatewayService = emsxGatewayService;
        }

  
        public override async Task ExecuteAsync()
        {
 
            await EmsxGatewayService.TriggerEmsxOrdersSyncEvent();
        }
    }
}
