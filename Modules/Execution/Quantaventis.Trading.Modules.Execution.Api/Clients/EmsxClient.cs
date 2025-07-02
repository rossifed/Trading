using Quantaventis.Trading.Modules.Execution.Api.Dto;
using Quantaventis.Trading.Modules.Execution.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Modules;

namespace Quantaventis.Trading.Modules.Execution.Api.Clients
{
    internal interface IEmsxClient
    {

        Task<IEnumerable<EmsxFillDto>> GetEmxFillsByOrderId(int orderId);
    }

    internal class EmsxClient : IEmsxClient
    {
        private IModuleClient ModuleClient { get; }
        public EmsxClient(IModuleClient moduleClient)
        {
            ModuleClient = moduleClient;
        }

        public async Task<IEnumerable<EmsxFillDto>> GetEmxFillsByOrderId(int orderId)
                  => await ModuleClient.SendAsync<IEnumerable<EmsxFillDto>>("EMSX/GetFillsByOrderId", new GetEmsxFillsByOrderId(orderId));

    }
}

