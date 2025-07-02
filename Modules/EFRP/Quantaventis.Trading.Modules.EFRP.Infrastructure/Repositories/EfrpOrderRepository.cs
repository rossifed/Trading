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
    internal class EfrpOrderRepository : IEfrpOrderRepository
    {
        private IEfrpOrderDao EfrpOrderDao { get;}

        public EfrpOrderRepository(IEfrpOrderDao efrpOrderDao)
        {
            EfrpOrderDao = efrpOrderDao;
        }


        public async Task AddAsync(IEnumerable<EfrpOrder> efrpOrders)
        {
            var entities = efrpOrders.Map();
            await EfrpOrderDao.CreateAsync(entities);
        }
    }
}
