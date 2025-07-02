using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
namespace Quantaventis.Trading.Modules.Orders.Domain.Repositories
{
    internal interface IInstrumentRepository
    {
        Task AddAsync(Instrument instrument);
        Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> instrumentIds);
    }
}
