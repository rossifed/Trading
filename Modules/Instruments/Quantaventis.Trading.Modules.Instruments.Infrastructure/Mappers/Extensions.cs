using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using Entities = Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Mappers
{
    internal static class Extensions
    {

        internal static IEnumerable<Instrument> Map(this IEnumerable<InstrumentDto> instrumentDtos,
            IDictionary<string, InstrumentType> instrumentTypes,
            IDictionary<string, Exchange> exchanges,
            IDictionary<string, Currency> currencies,
             IDictionary<string, MarketSector> marketSectors)
        {

            return instrumentDtos.Select(x => x.Map(instrumentTypes, exchanges, currencies, marketSectors));
        }
        internal static Instrument Map(this InstrumentDto instrumentDto,
            IDictionary<string, InstrumentType> instrumentTypes,
            IDictionary<string, Exchange> exchanges,
            IDictionary<string, Currency> currencies,
            IDictionary<string, MarketSector> marketSectors)
        {

            return new Instrument(instrumentTypes[instrumentDto.InstrumentType],
                instrumentDto.Symbol,
                instrumentDto.Name,
                currencies[instrumentDto.Currency],
                exchanges[instrumentDto.Exchange],
                marketSectors[instrumentDto.MarketSector]
                );
        }

        internal static IEnumerable<Entities.Instrument> Map(this IEnumerable<Equity> equities)
            => equities.Select(x => x.Instrument.Map());

        internal static IEnumerable<Entities.Instrument> Map(this IEnumerable<Instrument> instruments)
         => instruments.Select(x => x.Map());
        internal static IEnumerable<Instrument> Map(this IEnumerable<Entities.Instrument> entities)
         => entities.Select(x => x.Map());
        internal static Entities.Instrument Map(this Instrument instrument)
        {

            return new Entities.Instrument()
            {
                InstrumentId = instrument.Id,
                Symbol = instrument.Symbol,
                Name = instrument.Name,
                InstrumentTypeId = instrument.InstrumentType.Id,
                MarketSectorId = instrument.MarketSector.Id,
                CurrencyId = instrument.Currency.Id,
                ExchangeId = instrument.Exchange?.Id

            };
        }

        internal static Instrument Map(this Entities.Instrument entity)
        {

            return new Instrument(entity.InstrumentType.Map(),
                entity.Symbol,
                entity.Name,
                entity.Currency.Map(),
                entity.Exchange?.Map(),
                entity.MarketSector.Map()
                );
        }
        internal static InstrumentType Map(this Entities.InstrumentType entity)
        {

            return new InstrumentType(entity.InstrumentTypeId, entity.Mnemonic);
        }
        internal static Exchange Map(this Entities.Exchange entity)
        {

            return new Exchange(entity.ExchangeId, entity.Code);
        }
        internal static Currency Map(this Entities.Currency entity)
        {

            return new Currency(entity.CurrencyId, entity.Code);
        }
        internal static Entities.Currency Map(this Currency currency)
        {

            return new Entities.Currency()
            {
                CurrencyId = currency.Id,
                Code = currency.Code,
            };
        }



        internal static IEnumerable<Entities.CurrencyPair> Map(this IEnumerable<CurrencyPair> CurrencyPaires)
             => CurrencyPaires.Select(x => x.Map());
        internal static Entities.CurrencyPair Map(this CurrencyPair CurrencyPair)
        {
            return new Entities.CurrencyPair()
            {
                CurrencyPairId = CurrencyPair.Id,
                BaseCurrencyId = CurrencyPair.BaseCurrency.Id,
                QuoteCurrencyId = CurrencyPair.QuoteCurrency.Id,
            };
        }

        internal static IEnumerable<Entities.Cfd> Map(this IEnumerable<Cfd> entities)
            => entities.Select(x => x.Map());
        internal static Entities.Cfd Map(this Cfd cfd)
        {
            return new Entities.Cfd()
            {
                CfdId = cfd.Id,
                UnderlyingInstrumentId = cfd.Underlying.Id
            };
        }
        internal static Entities.FxForward Map(this FxForward FxForward)
        {
            return new Entities.FxForward()
            {
                FxForwardId = FxForward.Id,
                CurrencyPairId = FxForward.CurrencyPairId,
                MaturityDate = FxForward.MaturityDate.ToDateTime(TimeOnly.MinValue)
            };
        }
        internal static FutureContractMonth Map(this Entities.FutureContractMonth entity)
        {
            return new FutureContractMonth(entity.FutureContractMonthId, entity.Code);
        }

        internal static IEnumerable<FutureContractMonth> Map(this IEnumerable<Entities.FutureContractMonth> entities)
         => entities.Select(x => x.Map());

        internal static MarketSector Map(this Entities.MarketSector entity)
        {
            return new MarketSector(entity.MarketSectorId, entity.Mnemonic);
        }
        internal static IEnumerable<MarketSector> Map(this IEnumerable<Entities.MarketSector> entities)
         => entities.Select(x => x.Map());

        internal static IEnumerable<Currency> Map(this IEnumerable<Entities.Currency> entities)
            => entities.Select(x => x.Map());
        internal static IEnumerable<Exchange> Map(this IEnumerable<Entities.Exchange> entities)
                => entities.Select(x => x.Map());
        internal static IEnumerable<InstrumentType> Map(this IEnumerable<Entities.InstrumentType> entities)
        => entities.Select(x => x.Map());
        internal static IEnumerable<Entities.FxForward> Map(this IEnumerable<FxForward> FxForwards)
            => FxForwards.Select(x => x.Map());

        internal static IEnumerable<Entities.Currency> Map(this IEnumerable<Currency> currencies)
            => currencies.Select(x => x.Map());
        internal static Entities.GenericFuture Map(this GenericFuture genericFuture)
        {
            var entity = new Entities.GenericFuture()
            {
                GenericFutureId = genericFuture.Id,
                RootSymbol = genericFuture.RootSymbol,
                ContractSize = (decimal)genericFuture.ContractSize,
                PointValue = (decimal)genericFuture.PointValue,
                TickSize = (decimal)genericFuture.TickSize,
                TickValue = (decimal)genericFuture.TickValue,
            };
            return entity;
        }


        internal static IEnumerable<Entities.GenericFuture> Map(this IEnumerable<GenericFuture> genericFutures)
        => genericFutures.Select(x => x.Map());

        internal static IEnumerable<GenericFuture> Map(this IEnumerable<Entities.GenericFuture> entities)
            => entities.Select(x => x.Map());
        internal static GenericFuture Map(this Entities.GenericFuture entity)
        {
            return new GenericFuture(entity.GenericFutureNavigation.Map(),
                entity.RootSymbol,
                (double)entity.ContractSize,
                new FutureTick(
                    (double)entity.TickSize,
                    (double)entity.TickValue,
                    (double)entity.PointValue)
                );

        }
    

        internal static IEnumerable<FutureContract> Map(this IEnumerable<Entities.FutureContract> entities)
               => entities.Select(x => x.Map());
        internal static FutureContract Map(this Entities.FutureContract entity)
        {
            return new FutureContract(entity.FutureContractNavigation.Map(),
                entity.GenericFutureId,
                entity.FutureContractMonth.Map(),
                entity.ContractYear,
                DateOnly.FromDateTime(entity.LastTradeDate),
                DateOnly.FromDateTime(entity.FirstNoticeDate)
                );

        }

        internal static FxForward Map(this Entities.FxForward entity)
        {
            return new FxForward(entity.FxForwardNavigation.Map(),
                entity.CurrencyPairId,
                new CurrencyPair(entity.CurrencyPair.CurrencyPairNavigation.Map(), entity.CurrencyPair.BaseCurrency.Map(), entity.CurrencyPair.QuoteCurrency.Map()),
               DateOnly.FromDateTime(entity.MaturityDate));

        }
        internal static IEnumerable<FxForward> Map(this IEnumerable<Entities.FxForward> entities)
            => entities.Select(x => x.Map());
        internal static CurrencyPair Map(this Entities.CurrencyPair entity)
        {
            return new CurrencyPair(entity.CurrencyPairNavigation.Map(), entity.BaseCurrency.Map(), entity.QuoteCurrency.Map());

        }
        internal static IEnumerable<CurrencyPair> Map(this IEnumerable<Entities.CurrencyPair> entities)
            => entities.Select(x => x.Map());
        internal static IEnumerable<Entities.FutureContract> Map(this IEnumerable<FutureContract> entities)
     => entities.Select(x => x.Map());
        internal static Entities.FutureContract Map(this FutureContract futureContract)
        {
            return new Entities.FutureContract()
            {
                FutureContractId = futureContract.Id,
                GenericFutureId = futureContract.GenericFutureId,
                FirstNoticeDate = futureContract.FirstNoticeDate.ToDateTime(TimeOnly.MinValue),
                LastTradeDate = futureContract.LastTradeDate.ToDateTime(TimeOnly.MinValue),
                FutureContractMonthId = futureContract.FutureContractMonth.Id,
                ContractYear = futureContract.Year,
            };
        }

    }
    }

