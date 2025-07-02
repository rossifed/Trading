using Microsoft.EntityFrameworkCore.ChangeTracking;
using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Factories
{
    internal interface IInstrumentFactory {
        IEnumerable<Instrument> CreateInstruments(IEnumerable<Entities.Instrument> entities);
        Instrument CreateInstrument(Entities.Instrument entity);
    }
    internal class InstrumentFactory : IInstrumentFactory
    {
        public IEnumerable<Instrument> CreateInstruments(IEnumerable<Entities.Instrument> entities)
         => entities.Select(entity => CreateInstrument(entity));
        public Instrument CreateInstrument(Entities.Instrument entity)
        {
      
            var instrumentId = entity.InstrumentId;
            var symbol = entity.Symbol;
            var pricing = GetInstrumentPricing(entity);
            switch (entity.InstrumentType)
            {

                case "EQU": return new Equity(instrumentId);
                case "FUT": return new FutureContract(instrumentId, GetFutureContractPointValue(entity));
                case "CurrencyPairFWD": return new FxForward(instrumentId);
                default: throw new InvalidOperationException($"The Instrument type {entity.InstrumentType} associated to the instrument {entity.Symbol} is not recognized");
            }
        }
        private Money GetFutureContractPointValue(Entities.Instrument entity)
        { var futureContract = entity.FutureContract;
            if (futureContract == null) {
                throw new InvalidOperationException($"No future contract has been found for the Instrument {entity.Symbol}");
            }
           return new Money(futureContract.PointValue, entity.Currency);
        }
        private InstrumentPricing GetInstrumentPricing(Entities.Instrument entity) {
            var instrumentPricing = entity.InstrumentPricing;
            if (instrumentPricing == null)
            {
                throw new InvalidOperationException($"No pricing has been found for the Instrument {entity.Symbol}");
            }
            return instrumentPricing.Map();
        }
    }
}
