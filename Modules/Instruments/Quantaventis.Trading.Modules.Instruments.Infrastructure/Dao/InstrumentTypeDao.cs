using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IInstrumentTypeDao
    {
        Task<InstrumentType?> GetByMnemonicAsync(string mnemonic);
        Task<IEnumerable<InstrumentType>> GetAllAsync();
        Task<InstrumentType> SaveAsync(InstrumentType entity);

    }
    internal class InstrumentTypeDao : IInstrumentTypeDao
    {
        private InstrumentsDbContext DbContext { get; }

        public InstrumentTypeDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     

       public async Task<IEnumerable<InstrumentType>> GetAllAsync()
        {
            return await DbContext.InstrumentTypes
                    .ToListAsync();
        }

       public async Task<InstrumentType> SaveAsync(InstrumentType entity)
        {
            if (entity.InstrumentTypeId <= 0)
                await DbContext.AddAsync(entity);
            else
                DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<InstrumentType?> GetByMnemonicAsync(string mnemonic)
        {
            return await DbContext.InstrumentTypes
                .Where(x=>x.Mnemonic == mnemonic)
                .FirstOrDefaultAsync();
        }
    }
}
