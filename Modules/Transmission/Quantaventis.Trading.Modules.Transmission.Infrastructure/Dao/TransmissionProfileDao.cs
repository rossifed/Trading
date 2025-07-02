using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao
{
    internal interface ITransmissionProfileDao {
        Task<IEnumerable<TransmissionProfile>> GetAllEnabledAsync();
        Task<TransmissionProfile?> GetByIdAsync(int id);
    }
    internal class TransmissionProfileDao : ITransmissionProfileDao
    {

        private TransmissionDbContext DbContext { get; }

        public TransmissionProfileDao(TransmissionDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<TransmissionProfile>> GetAllEnabledAsync() {
           return await  DbContext
                .TransmissionProfiles
                .AsNoTracking()
                .Where(x => x.IsEnabled)

                .Include(x=>x.TransmissionScheduleType)
                .Include(x => x.CounterParty)
                .Include(x => x.EmailConfiguration)
                .Include(x => x.FileGenerationProfiles)
                .Include(x => x.FtpConfiguration)
                .Include(x => x.EncryptionProfile)
                .Include(x => x.FileContentType)
                .ToListAsync();       
        }

        public async Task<TransmissionProfile?> GetByIdAsync(int id)
        {
            return await DbContext
               .TransmissionProfiles
               .AsNoTracking()
               .Where(x => x.TransmissionProfileId ==id)
                .Include(x => x.TransmissionScheduleType)
                .Include(x => x.CounterParty)
                .Include(x => x.EmailConfiguration)
                  .Include(x => x.FileGenerationProfiles)
                .Include(x => x.FtpConfiguration)
                .Include(x => x.EncryptionProfile)
                .Include(x => x.FileContentType)
               .FirstOrDefaultAsync();
        }
    }
}
