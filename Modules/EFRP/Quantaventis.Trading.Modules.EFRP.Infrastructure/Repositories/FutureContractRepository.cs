using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Repositories
{
    internal class FutureContractRepository : IFutureContractRepository
    {
        private IFutureContractDao FutureContractDao { get;}

        public FutureContractRepository(IFutureContractDao futureContractDao)
        {
            FutureContractDao = futureContractDao;
        }

        public async Task<IEnumerable<FutureContract>> GetByIdsAsync(IEnumerable<int> instrumentIds)
        {
            var entities = await FutureContractDao.GetByIdsAsync(instrumentIds);
            return entities.Map();
        }

        public async Task<IEnumerable<FutureContract>> GetAllAsync()
        {
           var entities =await FutureContractDao.GetAllAsync();
            return entities.Map();
        }
    }
}
