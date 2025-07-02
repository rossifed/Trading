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
    internal class FxForwardRepository : IFxForwardRepository
    {
        private ICurrencyPairDao CurrencyPairDao { get; }
        private IFxForwardDao FxForwardDao { get; }

        private IInstrumentDao InstrumentDao { get; }

        private IUnitOfWork UnitOfWork { get; }
        public FxForwardRepository(ICurrencyPairDao CurrencyPairDao, 
            IFxForwardDao FxForwardDao, 
            IInstrumentDao instrumentDao,
            IUnitOfWork unitOfWork)
        {
            CurrencyPairDao = CurrencyPairDao;
            FxForwardDao = FxForwardDao;
            InstrumentDao = instrumentDao;
            UnitOfWork = unitOfWork;
        }

       


        public async Task<IEnumerable<FxForward>> AddAsync(IEnumerable<FxForward> FxForwards, int CurrencyPairId)
        {
            IDictionary<string, FxForward> fwdBySymbol = FxForwards.ToDictionary(x => x.Symbol);
            IDictionary<Entities.FxForward, Entities.Instrument> forwardInstrumentPairs = FxForwards.ToDictionary(x => x.Map(), x => x.Instrument.Map());
            var savedInstruments = await InstrumentDao.SaveAsync(forwardInstrumentPairs.Values);
            foreach (var pair in forwardInstrumentPairs)
            {
                pair.Key.CurrencyPairId = CurrencyPairId;
                pair.Key.FxForwardId = pair.Value.InstrumentId;
            }
            await FxForwardDao.CreateAsync(forwardInstrumentPairs.Keys);


            return savedInstruments.Select(x => fwdBySymbol[x.Symbol].WithId(x.InstrumentId));
        }

        public async Task<IEnumerable<FxForward>> GetByCurrencyPairAsync(CurrencyPair CurrencyPair)
        {
            var entities = await FxForwardDao.GetByCurrencyPairIdAsync(CurrencyPair.Id);
            return entities.Map();
        }

        public async Task<FxForward> AddAsync(FxForward FxForward)
        {
            async Task<FxForward> CreateAsync()
            {
                var savedInstrument = await InstrumentDao.SaveAsync(FxForward.Instrument.Map());
                var FxForwardWithId = FxForward.WithId(savedInstrument.InstrumentId);
                var savedForwardContract = await FxForwardDao.CreateAsync(FxForwardWithId.Map());
                return FxForwardWithId;
            }
            return await UnitOfWork.ExecuteAsync<FxForward>(CreateAsync);
        }
    }
}
