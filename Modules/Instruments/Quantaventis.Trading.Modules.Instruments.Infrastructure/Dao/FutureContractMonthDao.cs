using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IFutureContractMonthDao
    {
        Task<IEnumerable<FutureContractMonth>> GetAllAsync();

    }
    internal class FutureContractMonthDao : IFutureContractMonthDao
    {
        private InstrumentsDbContext DbContext { get; }

        public FutureContractMonthDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     

       public async Task<IEnumerable<FutureContractMonth>> GetAllAsync()
        {
            return await DbContext.FutureContractMonths.AsNoTracking()
                    .ToListAsync();
        }

   
    }
}
