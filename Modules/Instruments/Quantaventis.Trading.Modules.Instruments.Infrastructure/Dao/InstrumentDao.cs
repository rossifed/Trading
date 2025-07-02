using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IInstrumentDao
    {
        Task<Instrument?> GetBySymbolAsync(string symbol);
        Task<IEnumerable<Instrument>> GetBySymbolsAsync(IEnumerable<string> symbols);
        Task<IEnumerable<Instrument>> SaveAsync(IEnumerable<Instrument> instruments);
        Task<IEnumerable<Instrument>> GetAllAsync();
        Task<IEnumerable<Instrument>> CreateAsync(IEnumerable<Instrument> instruments);
        Task<Instrument> SaveAsync(Instrument instrument);
    }
    internal class InstrumentDao : IInstrumentDao
    {
        private InstrumentsDbContext DbContext { get; }

        public InstrumentDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<Instrument>> GetAllAsync()
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Include(x => x.InstrumentType)
                              .Include(x => x.Currency)
                              .Include(x => x.Exchange)
                              .Include(x => x.MarketSector)
                              .Distinct()
                              .ToListAsync();
        }

        public async Task<IEnumerable<Instrument>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Where(x => symbols.Contains(x.Symbol))
                              .Include(x=>x.InstrumentType)
                              .Include(x=>x.Currency)
                              .Include(x => x.Exchange)
                              .Include(x => x.MarketSector)
                              .Distinct()
                              .ToListAsync();
        }
        public async Task<Instrument?> GetBySymbolAsync(string symbol)
        {
            return await DbContext.Instruments
                              .AsNoTracking()
                              .Where(x => x.Symbol == symbol.Trim())
                              .Include(x => x.InstrumentType)
                              .Include(x => x.Currency)
                              .Include(x => x.Exchange)
                              .Include(x => x.MarketSector)
                              .Distinct()
                              .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Instrument>> CreateAsync(IEnumerable<Instrument> instruments)
        {         
             //  await  DbContext.AddRangeAsync(instruments);
     
            foreach (Instrument entity in instruments)
            {
                 DbContext.Add(entity);
                var entityEntry = DbContext.Entry(entity);
            }
            await DbContext.SaveChangesAsync();
            return instruments;
        }
        public async Task<IEnumerable<Instrument>> SaveAsync(IEnumerable<Instrument> instruments)
        {
            Func<Instrument, bool> condition = x => x.InstrumentId <= 0;
            IEnumerable<Instrument> toCreate = instruments.Where(condition);
            IEnumerable<Instrument> toUpdate = instruments.Where(x => !condition(x));
            if (toCreate.Any()) {
                foreach (Instrument entity in toCreate)
                {
                    await  DbContext.AddAsync(entity);
                }
            }
            if (toUpdate.Any())
                DbContext.UpdateRange(toUpdate);

            await DbContext.SaveChangesAsync();

      
            return instruments;
        }
        public async Task<Instrument> SaveAsync(Instrument entity)
        {
            if (entity.InstrumentId <= 0)
                await DbContext.AddAsync(entity);
            else
                DbContext.UpdateRange(entity);

            await DbContext.SaveChangesAsync();
            return entity;

        }
    }
}
