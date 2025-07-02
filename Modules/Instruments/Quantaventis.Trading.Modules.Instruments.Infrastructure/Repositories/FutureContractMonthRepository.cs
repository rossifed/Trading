using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Quantaventis.Trading.Modules.Instruments.Domain.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Repositories
{
    internal class FutureContractMonthRepository : IFutureContractMonthRepository
    {
        private IFutureContractMonthDao FutureContractMonthDao { get; }

        public FutureContractMonthRepository(IFutureContractMonthDao futureContractMonthDao)
        {
            FutureContractMonthDao = futureContractMonthDao;
        }


        public async Task<IEnumerable<FutureContractMonth>> GetAllAsync()
        {
            IEnumerable<Entities.FutureContractMonth> entities = await FutureContractMonthDao.GetAllAsync();
            IEnumerable<FutureContractMonth> futureContractMonths = entities.Map();
            return futureContractMonths;
        }
    }
}
