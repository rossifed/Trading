using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Quantaventis.Trading.Modules.Instruments.Domain.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Mappers;
using Quantaventis.Trading.Shared.Infrastructure.Database;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Repositories
{
    internal class GenericFutureRepository : IGenericFutureRepository
    {
        private IGenericFutureDao GenericFutureDao { get; }
        private IFutureContractDao FutureContractDao { get; }
        private IInstrumentDao InstrumentDao { get; }
        private IUnitOfWork UnitOfWork { get; }
        public GenericFutureRepository(IGenericFutureDao genericFutureDao, 
            IFutureContractDao futureContractDao, 
            IInstrumentDao instrumentDao,
            IUnitOfWork unitOfWork)
        {
            GenericFutureDao = genericFutureDao;
            FutureContractDao = futureContractDao;
            InstrumentDao = instrumentDao;
            UnitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<GenericFuture>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {
            IEnumerable<Entities.GenericFuture> entities = await GenericFutureDao.GetBySymbolsAsync(symbols);
            IEnumerable<GenericFuture> genericFutures = entities.Map();
            return genericFutures;
        }

        public async Task UpdateAsync(IEnumerable<GenericFuture> genericFutures)
        {
            await GenericFutureDao.UpdateAsync(genericFutures.Map());
        }

        public async Task<IEnumerable<GenericFuture>> GetAllAsync()
        {
            var entities = await GenericFutureDao.GetAllAsync();
            return entities.Map();
        }


        public async Task<GenericFuture> AddAsync(GenericFuture genericFuture) {
            async Task<GenericFuture> CreateAsync()
            {

                var savedInstrument = await InstrumentDao.SaveAsync(genericFuture.Instrument.Map());
                var genericFutureEntity = genericFuture.Map();
                genericFutureEntity.GenericFutureId = savedInstrument.InstrumentId;
                var savedEntity = await GenericFutureDao.CreateAsync(genericFutureEntity);
                 return genericFuture.WithId(savedEntity.GenericFutureId);
            }
            return await UnitOfWork.ExecuteAsync<GenericFuture>(CreateAsync);
        }


        public async Task<GenericFuture?> GetBySymbolAsync(string symbol)
        {
            var entity = await GenericFutureDao.GetBySymbolAsync(symbol);
            return entity?.Map();
        }
    }
}
