using Quantaventis.Trading.Modules.Rolling.Domain.Model;
using Quantaventis.Trading.Modules.Rolling.Domain.Repositories;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Repositories
{
    internal class ContractRollInfoRepository : IContractRollInfoRepository
    {
        private IFutureRollInfoDao FutureRollInfoDao { get; }
        private IFxForwardRollInfoDao FxForwardRollInfoDao { get; }
        public ContractRollInfoRepository(IFutureRollInfoDao futureRollInfoDao, IFxForwardRollInfoDao fxForwardRollInfoDao)
        {
            FutureRollInfoDao = futureRollInfoDao;
            FxForwardRollInfoDao = fxForwardRollInfoDao;
        }

        public async Task<IEnumerable<ContractRollInfo>> GetAllAsync()
        {
            var futureRollInfos = await FutureRollInfoDao.GetAllAsync();
            var fwdRollInfos = await FxForwardRollInfoDao.GetAllAsync();

            return futureRollInfos.Map().Union(fwdRollInfos.Map());
        }
    }
}
