using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Dao
{
    internal interface IInstrumentDao
    {
 

        Task CreateAsync(Instrument entity);

        Task<IEnumerable<Instrument>> GetBySymbolsAsync(IEnumerable<string> symbol);
    }

    internal class InstrumentDao : IInstrumentDao
    {
        private WeightsDbContext DbContext { get; }

        public InstrumentDao(WeightsDbContext dbContext) {

            this.DbContext = dbContext;
        }


        public async Task CreateAsync(Instrument entity)
        {

            await DbContext.AddAsync(entity);
           await DbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Instrument>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {
            return await DbContext
                .Instruments
                .Where(x => symbols.Select(x=>x.Trim()).Contains(x.Symbol.Trim()))//TODO: not good we dont know if BBG is case sensitive. hack to correct the lowercase yellow cases found in the file. correction should be done in the file
                .ToListAsync();
        }
    }

}
