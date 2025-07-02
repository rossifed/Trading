using Quantaventis.Trading.Modules.Transmission.Domain.Model;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Repositories
{
    internal interface ITransmissionProfileRepository
    {
        Task<IEnumerable<TransmissionProfile>> GetAllEnabledAsync();

        Task<TransmissionProfile?> GetByIdAsync(int id);
    }
}
