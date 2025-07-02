using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface ICurrencyDao
    {
        Task<IEnumerable<Currency>> GetAllAsync();

    }
    internal class CurrencyDao : ICurrencyDao
    {
        private InstrumentsDbContext DbContext { get; }

        public CurrencyDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     

       public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            return await DbContext.Currencies.AsNoTracking()
                    .ToListAsync();
        }

   
    }
}
