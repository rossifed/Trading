using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Execution.Domain.Model;
namespace Quantaventis.Trading.Modules.Execution.Domain.Repositories
{
    internal interface IFillRepository
    {

        Task UpsertAsync(IEnumerable<EmsxFill> fills);

        Task<IEnumerable<EmsxFill>> GetByOrderIdAsync(int orderId);
    }
}
