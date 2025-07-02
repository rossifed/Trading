using Quantaventis.Trading.Modules.Instruments.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Instruments.Domain.Model;
using System.Net;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;

namespace Quantaventis.Trading.Modules.Instruments.Api.Mappers
{
    internal static class Extensions
    {


        internal static IEnumerable<FutureContractDto> Map(this IEnumerable<FutureContract> futureContracts)
         => futureContracts.Select(x => x.Map());
        internal static IEnumerable<InstrumentDto> Map(this IEnumerable<Instrument> futureContracts)
            => futureContracts.Select(x => x.Map());
        internal static InstrumentDto Map(this Instrument instrument)
        {
            return new InstrumentDto
            {
                Id = instrument.Id,
                Symbol = instrument.Symbol,
                Currency = instrument.Currency.Code,
                CurrencyId = instrument.Currency.Id,
                Exchange = instrument.Exchange?.Code,
                ExchangeId = instrument.Exchange?.Id,
                InstrumentType = instrument.InstrumentType.Mnemonic,
                InstrumentTypeId = instrument.InstrumentType.Id,
                MarketSector = instrument.MarketSector.Mnemonic,
                MarketSectorId = instrument.MarketSector.Id,
                Name = instrument.Name
            };
        }

        internal static T Map<T>(this Instrument instrument) where T : InstrumentDto, new()
        {
            return new T
            {
                Id = instrument.Id,
                Symbol = instrument.Symbol,
                Currency = instrument.Currency.Code,
                CurrencyId = instrument.Currency.Id,
                Exchange = instrument.Exchange?.Code,
                ExchangeId = instrument.Exchange?.Id,
                InstrumentType = instrument.InstrumentType.Mnemonic,
                InstrumentTypeId = instrument.InstrumentType.Id,
                MarketSector = instrument.MarketSector.Mnemonic,
                MarketSectorId = instrument.MarketSector.Id,
                Name = instrument.Name
            };
        }
        internal static FutureContractDto Map(this FutureContract futureContract)
        {
            var dto = futureContract.Instrument.Map<FutureContractDto>();
            dto.FirstNoticeDate = futureContract.FirstNoticeDate;
            dto.LastTradeDate = futureContract.LastTradeDate;
            dto.Month = futureContract.FutureContractMonth.Code;
            dto.Year = futureContract.Year;

            return dto;
        }
 
        internal static GenericFutureDto Map(this GenericFuture genericFuture)
        {
            var dto = genericFuture.Instrument.Map<GenericFutureDto>();
            dto.RootSymbol = genericFuture.RootSymbol;
            dto.ContractSize = (decimal) genericFuture.ContractSize;
            dto.PointValue = (decimal)genericFuture.PointValue;
            dto.TickValue = (decimal)genericFuture.TickValue;
            dto.TickSize = (decimal)genericFuture.TickSize;
            return dto;
        }

        internal static T Map<T>(this Entities.Instrument instrument) where T : InstrumentDto, new()
        {
            return new T
            {
                Id = instrument.InstrumentId,
                Symbol = instrument.Symbol,
                Currency = instrument.Currency.Code,
                CurrencyId = instrument.CurrencyId,
                Exchange = instrument.Exchange?.Code,
                ExchangeId = instrument.ExchangeId,
                InstrumentType = instrument.InstrumentType.Mnemonic,
                InstrumentTypeId = instrument.InstrumentTypeId,
                MarketSector = instrument.MarketSector?.Mnemonic,
                MarketSectorId = instrument.MarketSectorId,
                Name = instrument.Name
            };
        }
        internal static FutureContractDto Map(this Entities.FutureContract futureContract)
        {
            var dto = futureContract.FutureContractNavigation.Map<FutureContractDto>();
            dto.FirstNoticeDate = DateOnly.FromDateTime(futureContract.FirstNoticeDate);
            dto.LastTradeDate = DateOnly.FromDateTime(futureContract.LastTradeDate);
            dto.Month = futureContract.FutureContractMonth.Code;
            dto.Year = futureContract.ContractYear;

            return dto;
        }
        internal static IEnumerable<FutureContractDto> Map(this IEnumerable<Entities.FutureContract> futureContract)
                 => futureContract.Select(x => x.Map()).ToList();
        internal static GenericFutureDto Map(this Entities.GenericFuture genericFuture)
        {
            var dto = genericFuture.GenericFutureNavigation.Map<GenericFutureDto>();
            dto.RootSymbol = genericFuture.RootSymbol;
            dto.ContractSize =  genericFuture.ContractSize;
            dto.PointValue = genericFuture.PointValue;
            dto.TickValue = genericFuture.TickValue;
            dto.TickSize = genericFuture.TickSize;
            return dto;
        }

      
        internal static IEnumerable<GenericFutureDto> Map(this IEnumerable<GenericFuture> FxForwards)
             => FxForwards.Select(x => x.Map());

        internal static IEnumerable<FxForwardDto> Map(this IEnumerable<FxForward> FxForwards)
        => FxForwards.Select(x => x.Map());

        internal static FxForwardDto Map(this FxForward FxForward)
        {
            var dto = FxForward.Instrument.Map<FxForwardDto>();
            dto.BaseCurrency = FxForward.BaseCurrency.Code;
            dto.QuoteCurrency = FxForward.QuoteCurrency.Code;
            dto.MaturityDate = FxForward.MaturityDate;
            return dto;
        }

        internal static IEnumerable<FxForwardDto> Map(this IEnumerable<Entities.FxForward> CurrencyPaires)
       => CurrencyPaires.Select(x => x.Map()).ToList();
        internal static FxForwardDto Map(this Entities.FxForward FxForward)
        {
            var dto = FxForward.FxForwardNavigation.Map<FxForwardDto>();
            dto.CurrencyPair = FxForward.CurrencyPair.Map();
            dto.BaseCurrency = FxForward.CurrencyPair.BaseCurrency.Code;
            dto.QuoteCurrency = FxForward.CurrencyPair.QuoteCurrency.Code;
            dto.MaturityDate = DateOnly.FromDateTime( FxForward.MaturityDate);
            return dto;
        }
        internal static CurrencyPairDto Map(this Entities.CurrencyPair CurrencyPair)
        {
            var dto = CurrencyPair.CurrencyPairNavigation.Map<CurrencyPairDto>();
            dto.BaseCurrency = CurrencyPair.BaseCurrency.Code;
            dto.QuoteCurrency = CurrencyPair.QuoteCurrency.Code;
            return dto;
        }
        internal static CurrencyPairDto Map(this CurrencyPair CurrencyPair)
        {
            var dto = CurrencyPair.Instrument.Map<CurrencyPairDto>();
            dto.BaseCurrency = CurrencyPair.BaseCurrency.Code;
            dto.QuoteCurrency = CurrencyPair.QuoteCurrency.Code;
            return dto;
        }
        internal static IEnumerable<CurrencyPairDto> Map(this IEnumerable<CurrencyPair> CurrencyPaires)
         => CurrencyPaires.Select(x => x.Map());
        internal static IEnumerable<EquityDto> Map(this IEnumerable<Equity> equities)
            => equities.Select(x => x.Map());
        internal static EquityDto Map(this Equity equity)
         => equity.Instrument.Map<EquityDto>();

        internal static IEnumerable<InstrumentDto> Map(this IEnumerable<Entities.Instrument> equities)
            => equities.Select(x => x.Map()).ToList();
        internal static InstrumentDto Map(this Entities.Instrument entity)
          => new InstrumentDto()
          {
              Id = entity.InstrumentId,
              Symbol = entity.Symbol,
              Currency = entity.Currency.Code,
              CurrencyId = entity.CurrencyId,
              Exchange = entity.Exchange?.Code,
              ExchangeId = entity.ExchangeId,
              InstrumentType = entity.InstrumentType.Mnemonic,
              InstrumentTypeId = entity.InstrumentTypeId,
              MarketSector = entity.MarketSector?.Mnemonic,
              MarketSectorId = entity.MarketSectorId,
              Name = entity.Name
          };
    }
}
