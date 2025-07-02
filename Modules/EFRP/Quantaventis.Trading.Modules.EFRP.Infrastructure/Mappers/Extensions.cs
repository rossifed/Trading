using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dto;
using System.Globalization;
namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Mappers
{
    internal static class Extensions
    {
        public static Entities.FutureContract Map(this FutureContract futureContract)
        {
            return new Entities.FutureContract()
            {
                FutureContractId = futureContract.Id,
                GenericFutureId = futureContract.GenericFuture.Id,
                LastTradeDate = futureContract.LastTradeDate.ToDateTime(TimeOnly.MinValue),
                Symbol = futureContract.Symbol
            };
        }

        public static IEnumerable<FutureContract> Map(this IEnumerable<Entities.FutureContract> entities)
        {
            return entities.Select(x=>x.Map());

        }

        public static GenericFuture Map(this Entities.GenericFuture entity)
        {
            return new GenericFuture(
                entity.GenericFutureId,
                entity.Symbol,
                (double)entity.ContractSize,
                entity.PointValue);

        }
        public static FutureContract Map(this Entities.FutureContract entity)
        {
            return new FutureContract(
                entity.FutureContractId,
                entity.Symbol,
                entity.GenericFuture.Map(),
                DateOnly.FromDateTime(entity.LastTradeDate));

        }
        public static IEnumerable<Entities.FutureContract> Map(this IEnumerable<FutureContract> entities)
        {
            return entities.Select(x => x.Map());

        }
        public static IEnumerable<Entities.EfrpOrder> Map(this IEnumerable<EfrpOrder> entities)
        {
            return entities.Select(x => x.Map());

        }
        public static Entities.EfrpOrder Map(this EfrpOrder efrpOrder)
        {
            return new Entities.EfrpOrder()
            {
                EfrpOrderId = efrpOrder.Id,
                OriginalOrderId = efrpOrder.OriginalOrderId,
                BaseCurrency = efrpOrder.FxForwardOrder.BaseCurrency,
                QuoteCurrency = efrpOrder.QuoteCurrency,
                MaturityDate = efrpOrder.ValueDate.ToDateTime(TimeOnly.MinValue),
                FxForwardSymbol = efrpOrder.FxForwardSymbol
            };
        }

   
        public static Entities.EfrpConversionRule Map(this EfrpConversionRule rule)
        {
            return new Entities.EfrpConversionRule()
            {
                BaseCurrency = rule.BaseCurrency,
                QuoteCurrency = rule.QuoteCurrency,
                CmeClearportTicker = rule.CmeClearPortTicker,
                IsActive = rule.IsActive
            };
        }
        public static IEnumerable<Entities.EfrpConversionRule> Map(this IEnumerable<EfrpConversionRule> entities)
        {
            return entities.Select(x => x.Map());

        }
        public static IEnumerable<EfrpConversionRule> Map(this IEnumerable<Entities.EfrpConversionRule> entities)
        {
            return entities.Select(x => x.Map());

        }

        public static Broker Map(this Entities.Broker entity)
        {
            return new Broker(entity.BrokerId);
        }
        public static EfrpConversionRule Map(this Entities.EfrpConversionRule entity)
        {
            return new EfrpConversionRule(
                new CurrencyPair(entity.BaseCurrency, entity.QuoteCurrency),
                entity.Broker.Map(),
                entity.GenericFuture.Map(),
                entity.CmeClearportTicker,
                entity.IsActive);
        }


        public static IEnumerable<TradeAffirmFutureItem> Map(this IEnumerable<MsTradeAffirmItemDto> efrpOrders)
        {
        
            return efrpOrders.Where(x=>x.IsFutureItem).Select(x => x.Map()).ToList();
        }
        public static TradeAffirmFutureItem Map(this MsTradeAffirmItemDto dto)
        {          
                return new TradeAffirmFutureItem(
            
                    exchange: dto.Type,
                    bloombergSymbol: dto.Ccy1Side,
                    exchangeSymbol: dto.Ccy1,
                    clientSide: dto.Ccy1Amt,
                    quantity: Convert.ToInt32(dto.Ccy2Side),
                    ccy1: dto.Ccy2,
                    ccy1Amount: Convert.ToDecimal(dto.Ccy2Amt),
                    futureRate: Convert.ToDecimal(dto.SpotRate),
                    tradeDate: DateOnly.ParseExact(dto.TradeDate, "d-MMM-yy", CultureInfo.InvariantCulture),
                    entryUser: dto.ValueDate,
                    lastUpdateTimeUtc: DateTime.ParseExact(dto.EntryUser, "dd-MMM-yyyy HH:mm:ss UTC", CultureInfo.InvariantCulture),
                    dealEntryTimeUtc: DateTime.ParseExact(dto.DealID, "dd-MMM-yyyy HH:mm:ss UTC", CultureInfo.InvariantCulture)
                    );
            }
        }
    
}
