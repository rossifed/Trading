using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Risk.Infrastructure.Dao
{
    internal interface IInstrumentDao
    {
 

        Task CreateAsync(Instrument entity);

        Task UpdateAsync(Instrument entity);
    }

    internal class InstrumentDao : IInstrumentDao
    {
        private RiskDbContext DbContext { get; }

        public InstrumentDao(RiskDbContext dbContext) {

            this.DbContext = dbContext;
        }


        public async Task CreateAsync(Instrument entity)
        {

            await DbContext.AddAsync(entity);
           await DbContext.SaveChangesAsync();
            
        }

        public async Task UpdateAsync(Instrument entity)
        {
             DbContext.Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }

}
