using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
namespace Quantaventis.Trading.Modules.Instruments.Domain.Repositories
{
    internal interface IFxForwardRepository
    {

        Task<IEnumerable<FxForward>> GetByCurrencyPairAsync(CurrencyPair CurrencyPair);


        Task<FxForward> AddAsync(FxForward CurrencyPair);
    }
}
