using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Conversion.Domain.Model;
namespace Quantaventis.Trading.Modules.Conversion.Domain.Repositories
{
    internal interface IContractConversionRuleRepository { 
    

        Task<IEnumerable<IContractConversionRule>> GetByPortfolioIdAsync(byte portfolioId);
    }
}
