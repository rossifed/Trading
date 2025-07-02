using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

using Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao
{
    internal interface IInstrumentMappingDao
    {
 

        Task<IEnumerable<InstrumentMapping>> GetAllAsync();
        Task<IEnumerable<InstrumentMapping>> GetByTypeAsync(string mappingType);

        Task<InstrumentMapping?> GetByFromInstrumentAndMappingTypeAsync(int fromInstrument,int mappingTypeId);
        Task<InstrumentMapping?> GetByToInstrumentAndMappingTypeAsync(int toInstrument, int mappingTypeId);
        Task CreateAsync(Entities.InstrumentMapping mapping);
        Task UpdateAsync(Entities.InstrumentMapping mapping);
    }

    internal class InstrumentMappingDao : IInstrumentMappingDao
    {
        private ConversionDbContext DbContext { get; }

        public InstrumentMappingDao(ConversionDbContext dbContext) {

            this.DbContext = dbContext;
        }
        public async Task<IEnumerable<InstrumentMapping>> GetByTypeAsync(string type)
      => await DbContext.InstrumentMappings
             .AsNoTracking()
             .Where(x => x.InstrumentMappingType.Mnemonic == type.ToUpper())
             .Include(x => x.InstrumentMappingType)
              .Include(x => x.FromInstrument)
                 .Include(x => x.ToInstrument)
             .ToListAsync();
        public async Task<IEnumerable<InstrumentMapping>> GetAllAsync()
         => await DbContext.InstrumentMappings
                .AsNoTracking()
                .Include(x =>x.InstrumentMappingType)
              .Include(x => x.FromInstrument)
                 .Include(x => x.ToInstrument)
                .ToListAsync();

        public async Task CreateAsync(InstrumentMapping mapping)
        {
           await DbContext.AddAsync(mapping);
           await DbContext.SaveChangesAsync();
        }

        public async Task<InstrumentMapping?> GetByFromInstrumentAndMappingTypeAsync(int fromInstrumentId, int mappingTypeId)
        {
           return await DbContext.InstrumentMappings
                .AsNoTracking()
                .Where(x => x.FromInstrumentId == fromInstrumentId && x.InstrumentMappingTypeId== mappingTypeId)
                .Include(x => x.InstrumentMappingType)
                  .Include(x => x.FromInstrument)
                 .Include(x => x.ToInstrument)
                .FirstOrDefaultAsync();
        }

        public async Task<InstrumentMapping?> GetByToInstrumentAndMappingTypeAsync(int toInstrumentId, int mappingTypeId)
        {
            return await DbContext.InstrumentMappings
                  .AsNoTracking()
                 .Where(x => x.ToInstrumentId == toInstrumentId && x.InstrumentMappingTypeId == mappingTypeId)
                 .Include(x => x.InstrumentMappingType)
                 .Include(x=>x.FromInstrument)
                 .Include(x=>x.ToInstrument)
                 .FirstOrDefaultAsync();
        }


        public async Task UpdateAsync(InstrumentMapping mapping)
        {
             DbContext.Update(mapping);
            await DbContext.SaveChangesAsync();
        }
    }

}
