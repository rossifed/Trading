
using Entities = Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Portfolios.Domain.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Mappers
{
    internal static class Extensions
    {



       

        //internal static Entities.Position Map(this Position position)
        //{

        //    return new Entities.Position()
        //    {
        //        PositionId= position.Id,
        //        PortfolioId = position.PortfolioId,
        //        InstrumentId = position.Instrument.Id,
        //        Quantity = (int) position.Quantity,
        //        AvgEntryPrice = (decimal)position.AverageEntryPrice.Amount,
        //         LastTradeDate = position.LastTradeDate

        //    };
        //}
    
        internal static Entities.Portfolio Map(this Portfolio portfolio)
        {

            return new Entities.Portfolio()
            {
                PortfolioId = portfolio.Id,
                Name = portfolio.Name,
                Mnemonic = portfolio.Mnemonic,

            };
        }
        internal static Instrument Map(this Entities.Instrument entity)
        {


            return new Instrument( entity.InstrumentId);
        }

      
        //internal static Position Map(this Entities.Position position)
        //{


        //    return new Position(
        //        position.PositionId,
        //        position.PortfolioId,
        //        position.Instrument.Map(),
        //        position.Quantity,
        //        new Money (position.AvgEntryPrice, position.Instrument.Currency),
        //        position.LastTradeDate);
        //}
        internal static Portfolio Map(this Entities.Portfolio entity, IEnumerable<Position> positions)
        {


            return new Portfolio(entity.PortfolioId, entity.Name, entity.Mnemonic, entity.Currency, positions);
        }
    }
}
