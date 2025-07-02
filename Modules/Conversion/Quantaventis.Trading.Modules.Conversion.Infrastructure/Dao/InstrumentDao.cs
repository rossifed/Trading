using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao
{
    internal interface IInstrumentDao
    {
 

        Task CreateAsync(Instrument entity);

        Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> ids);
    }

    internal class InstrumentDao : IInstrumentDao
    {
        private ConversionDbContext DbContext { get; }

        public InstrumentDao(ConversionDbContext dbContext) {

            this.DbContext = dbContext;
        }


        public async Task CreateAsync(Instrument entity)
        {

            await DbContext.AddAsync(entity);
           await DbContext.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Instrument>> GetByIdsAsync(IEnumerable<int> ids)
        {

            int batchSize = 2000; // less than 2100 to stay safe
            var allInstruments = new List<Instrument>();

            for (int i = 0; i < ids.Count(); i += batchSize)
            {
                var currentBatch = ids.Skip(i).Take(batchSize).ToList();

                var instrumentsFromBatch = await DbContext.Instruments
                    .Where(x => currentBatch.Contains(x.InstrumentId))
                    .ToListAsync();

                allInstruments.AddRange(instrumentsFromBatch);
            }

            return allInstruments;
         
        }
    }

}
