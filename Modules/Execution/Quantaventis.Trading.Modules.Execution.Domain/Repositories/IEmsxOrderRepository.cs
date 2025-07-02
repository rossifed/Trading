using Quantaventis.Trading.Modules.Execution.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Execution.Domain.Repositories
{
    internal interface IEmsxOrderRepository
    {

        Task<EmsxOrder?> GetByOrderIdAsync(int orderId);
        Task UpdateAsync(EmsxOrder emsxOrder);

        Task UpsertAsync(IEnumerable<EmsxOrder> emsxOrders);
        Task<EmsxOrder> AddAsync(EmsxOrder emsxOrder);
    }
}
