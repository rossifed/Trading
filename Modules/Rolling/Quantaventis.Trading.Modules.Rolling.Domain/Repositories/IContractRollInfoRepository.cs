using Quantaventis.Trading.Modules.Rolling.Domain.Model;
namespace Quantaventis.Trading.Modules.Rolling.Domain.Repositories
{
    internal interface IContractRollInfoRepository
    {
        Task<IEnumerable<ContractRollInfo>> GetAllAsync();

    }
}
