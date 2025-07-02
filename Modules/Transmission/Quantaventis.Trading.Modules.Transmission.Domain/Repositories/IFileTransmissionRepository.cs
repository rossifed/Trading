using Quantaventis.Trading.Modules.Transmission.Domain.Model;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Repositories
{
    internal interface IFileTransmissionRepository
    {
        Task AddAsync(FileTransmission fileTransmission);
    }
}
