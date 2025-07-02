using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
namespace Quantaventis.Trading.Modules.Instruments.Domain.Repositories
{
    internal interface IFutureContractRepository
    {

        Task<IEnumerable<FutureContract>> GetByGenericFutureIdAsync(int id);

        Task<FutureContract> AddAsync(FutureContract futureContract);
    }
}
