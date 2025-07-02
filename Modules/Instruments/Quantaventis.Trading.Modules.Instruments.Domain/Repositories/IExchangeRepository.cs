using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Repositories
{
    internal interface IExchangeRepository
    {

        Task<IEnumerable<Exchange>> GetAllAsync();
    }
}
