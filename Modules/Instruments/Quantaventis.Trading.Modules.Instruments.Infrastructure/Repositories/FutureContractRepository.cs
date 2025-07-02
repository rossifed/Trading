using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Quantaventis.Trading.Modules.Instruments.Domain.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Mappers;
using Quantaventis.Trading.Shared.Infrastructure.Database;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Repositories
{
    internal class FutureContractRepository : IFutureContractRepository
    {

        private IFutureContractDao FutureContractDao { get; }
        private IInstrumentDao InstrumentDao { get; }
        private IUnitOfWork UnitOfWork { get; }
        public FutureContractRepository(
            IFutureContractDao futureContractDao,
            IInstrumentDao instrumentDao,
            IUnitOfWork unitOfWork)
        {
            FutureContractDao = futureContractDao;
            InstrumentDao = instrumentDao;
            UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FutureContract>> GetByGenericFutureIdAsync(int genericFutureId)
        {
            var entities = await FutureContractDao.GetByGenericFutureIdAsync(genericFutureId);
            return entities.Map();
        }

        public async Task<FutureContract> AddAsync(FutureContract futureContract)
        {       async Task<FutureContract> CreateAsync()
            {
                var savedInstrument = await InstrumentDao.SaveAsync(futureContract.Instrument.Map());
                var futureContractWithId = futureContract.WithId(savedInstrument.InstrumentId);
                var savedFutureContract = await FutureContractDao.CreateAsync(futureContractWithId.Map());
                return futureContractWithId;
            }
            return await UnitOfWork.ExecuteAsync<FutureContract>(CreateAsync);
        }
    }
}
