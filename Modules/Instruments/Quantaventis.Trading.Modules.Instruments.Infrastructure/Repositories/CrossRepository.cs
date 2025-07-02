using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Quantaventis.Trading.Modules.Instruments.Domain.Repositories;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Mappers;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Repositories
{
    internal class CurrencyPairRepository : ICurrencyPairRepository
    {
        private ICurrencyPairDao CurrencyPairDao { get; }
        private IFxForwardDao FxForwardDao { get; }

        private IInstrumentDao InstrumentDao { get; }

        private IUnitOfWork UnitOfWork { get; }
        public CurrencyPairRepository(ICurrencyPairDao CurrencyPairDao, 
            IFxForwardDao FxForwardDao, 
            IInstrumentDao instrumentDao,
            IUnitOfWork unitOfWork)
        {
            CurrencyPairDao = CurrencyPairDao;
            FxForwardDao = FxForwardDao;
            InstrumentDao = instrumentDao;
            UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CurrencyPair>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {
            var entities = await CurrencyPairDao.GetBySymbolsAsync(symbols);
            IEnumerable<CurrencyPair> CurrencyPaires = entities.Map();
            return CurrencyPaires;
        }

        public async Task<IEnumerable<CurrencyPair>> AddAsync(IEnumerable<CurrencyPair> CurrencyPaires)
        {
            List<CurrencyPair> savedCurrencyPaires = new List<CurrencyPair>();
            async Task CreateAsync()
            {

                foreach (CurrencyPair CurrencyPair in CurrencyPaires)
                {

                    var savedCurrencyPair= await AddAsync(CurrencyPair);
                    savedCurrencyPaires.Add(savedCurrencyPair);

                }
            }

            await UnitOfWork.ExecuteAsync(CreateAsync);

            return savedCurrencyPaires;
        }

        public async Task<CurrencyPair> AddAsync(CurrencyPair CurrencyPair)
        {
    
            async Task<CurrencyPair> CreateAsync()
            {

                var savedInstrument = await InstrumentDao.SaveAsync(CurrencyPair.Instrument.Map());
                var CurrencyPairEntity = CurrencyPair.Map();
                CurrencyPairEntity.CurrencyPairId = savedInstrument.InstrumentId;
                var savedEntity = await CurrencyPairDao.CreateAsync(CurrencyPairEntity);
                return CurrencyPair.WithId(savedEntity.CurrencyPairId);
            }
            return await UnitOfWork.ExecuteAsync<CurrencyPair>(CreateAsync);

        }

    }
}
