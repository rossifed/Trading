using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao
{
    internal interface ICurrencyPairConversionRuleDao
    {
 

        Task<IEnumerable<CurrencyPairConversionRule>> GetByPortfolioIdAsync(byte portfolioId);


    }

    internal class CurrencyPairConversionRuleDao : ICurrencyPairConversionRuleDao
    {
        private ConversionDbContext DbContext { get; }

        public CurrencyPairConversionRuleDao(ConversionDbContext dbContext) {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<CurrencyPairConversionRule>> GetByPortfolioIdAsync(byte portfolioId)
         => await DbContext.CurrencyPairConversionRules
            .Where(x =>x.PortfolioId == portfolioId || x.PortfolioId == null)
                .AsNoTracking()
                .ToListAsync();    
    }

}
