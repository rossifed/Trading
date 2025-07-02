using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Repositories;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Repositories
{

    internal class FileTransmissionRepository : IFileTransmissionRepository
    {
        private IFileTransmissionDao FileTransmissionDao { get; }

        public FileTransmissionRepository(IFileTransmissionDao fileTransmissionDao)
        {
            FileTransmissionDao = fileTransmissionDao;
        }


        public async Task AddAsync(FileTransmission fileTransmission)
        {
            Entities.FileTransmission entity = fileTransmission.Map();
           await  FileTransmissionDao.CreateAsync(entity);

        }
    }
}
