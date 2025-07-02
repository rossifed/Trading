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
    internal class EquityRepository : IEquityRepository
    {
        private IInstrumentDao InstrumentDao { get; }
        private IUnitOfWork UnitOfWork { get; }
        public EquityRepository(IInstrumentDao instrumentDao, IUnitOfWork unitOfWork)
        {
            InstrumentDao = instrumentDao;
            UnitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Equity>> AddAsync(IEnumerable<Equity> equities)
        {
            List<Equity> savedEquities = new List<Equity>();
            async Task CreateAsync()
            {
                //Overkill to iterate year instead of calling directly addrange, but seems that entities are detached if saved in batch mode. This must be investigated...
                foreach (Equity equity in equities)
                {

                    var savedEquity = await AddAsync(equity);
                    savedEquities.Add(savedEquity);

                }
            }

            await UnitOfWork.ExecuteAsync(CreateAsync);

            return savedEquities;

        }
        public async Task<Equity> AddAsync(Equity equity)
        {

            var savedInstrument = await InstrumentDao.SaveAsync(equity.Instrument.Map());
            return equity.WithId(savedInstrument.InstrumentId);
        }

        //public async Task<IEnumerable<Equity>> AddAsync(IEnumerable<Equity> equities)
        //{
        //    IDictionary<string, Equity> equityBySymbol = equities.ToDictionary(x => x.Symbol);
        //    IEnumerable<Entities.Instrument> savedEquities = new List<Entities.Instrument>();
        //    async Task CreateAsync()
        //    {
        //        //Overkill to iterate year instead of calling directly addrange, but seems that entities are detached if saved in batch mode. This must be investigated...
        //        savedEquities = await InstrumentDao.CreateAsync(equities.Map());
        //    }

        //    await UnitOfWork.ExecuteAsync(CreateAsync);

        //    return savedEquities.Select(x => equityBySymbol[x.Symbol].WithId(x.InstrumentId));

        //}

        public async Task<IEnumerable<Equity>> GetBySymbolsAsync(IEnumerable<string> symbols)
        {
            IEnumerable<Entities.Instrument> entities = await InstrumentDao.GetBySymbolsAsync(symbols);
            IEnumerable<Equity> equities = entities.Map().Select(instrument => new Equity(instrument));
            return equities;
        }

        public Task<IEnumerable<Equity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(IEnumerable<Equity> equities)
        {
            var entities = equities.Map();
            await InstrumentDao.SaveAsync(entities);
        }

    }
}
