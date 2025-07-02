using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Repositories;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Repositories
{
    internal class TransmissionProfileRepository : ITransmissionProfileRepository
    {

        private ITransmissionProfileDao TransmissionProfileDao;

        public TransmissionProfileRepository(ITransmissionProfileDao transmissionProfileDao)
        {
            TransmissionProfileDao = transmissionProfileDao;
        }

        public async Task<IEnumerable<TransmissionProfile>> GetAllEnabledAsync()
        {
            IEnumerable<Entities.TransmissionProfile> entities = await TransmissionProfileDao.GetAllEnabledAsync();
            return entities.Map();
        }

        public async Task<TransmissionProfile?> GetByIdAsync(int id)
        {
            Entities.TransmissionProfile? entity = await TransmissionProfileDao.GetByIdAsync(id);
            return entity?.Map();
        }
    }
}
