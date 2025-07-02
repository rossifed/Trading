using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao
{
    internal interface IFileTransmissionDao
    {
        Task<IEnumerable<FileTransmission>> GetByTransmissionDateAsync(DateOnly date);
        Task<FileTransmission> CreateAsync(FileTransmission fileTransmission);
    }
    internal class FileTransmissionDao : IFileTransmissionDao
    {

        private TransmissionDbContext DbContext { get; }

        public FileTransmissionDao(TransmissionDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<FileTransmission>> GetByTransmissionDateAsync(DateOnly date)
        {
            DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);
            return await DbContext
                 .FileTransmissions
                 .AsNoTracking()
                 .Where(x => x.TransmittedOn.GetValueOrDefault().Date == dateTime)
                 .ToListAsync();
        }

        public async Task<TransmissionProfile?> GetByIdAsync(int id)
        {
            return await DbContext
               .TransmissionProfiles
               .AsNoTracking()
               .Where(x => x.TransmissionProfileId == id)
               .Include(x => x.CounterParty)
               .Include(x => x.EmailConfiguration)
               .Include(x => x.FileGenerationProfiles)
               .Include(x => x.FtpConfiguration)
               .Include(x => x.EncryptionProfile)
               .FirstOrDefaultAsync();
        }

        public async Task<FileTransmission> CreateAsync(FileTransmission fileTransmission)
        {
            await DbContext.AddAsync(fileTransmission);
            await DbContext.SaveChangesAsync();
            return fileTransmission;
        }
    }
}
