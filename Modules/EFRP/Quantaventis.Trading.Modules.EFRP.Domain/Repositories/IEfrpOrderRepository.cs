using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Repositories
{
    internal interface IEfrpOrderRepository
    {

        Task AddAsync(IEnumerable<EfrpOrder> efrpOrders);
    }
}
