
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Microsoft.Identity.Client;
using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dto;
using System.Globalization;
using Entities = Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.EFRP.Api.Mappers
{
    internal static class Extensions
    {
        public static EfrpConversionInfoDto Map(this EfrpConversionInfo domain)
        {
            return new EfrpConversionInfoDto()
            {
                InstrumentId = domain.EfrpCandidate.InstrumentId,
                BrokerId = domain.EfrpCandidate.BrokerId,
                IsEfrp = domain.IsEfrp

            };
        }

        public static IEnumerable<EfrpConversionInfoDto> Map(this IEnumerable<EfrpConversionInfo> efrpConversionInfos)
        {
            return efrpConversionInfos.Select(x => x.Map());
        }
        public static EfrpCandidateDto Map(this IEfrpCandidate domain)
        {
            return new EfrpCandidateDto()
            {
                InstrumentId = domain.InstrumentId,
                BrokerId = domain.BrokerId,

            };

        }
        public static IEfrpCandidate Map(this EfrpCandidateDto dto)
        {
            return new EfrpCandidate(dto.InstrumentId, dto.BrokerId);
        }

        public static IEnumerable<IEfrpCandidate> Map(this IEnumerable<EfrpCandidateDto> dtos)
        {
            return dtos.Select(x => x.Map());
        }
        public static Entities.FutureContract Map(this FutureContractDto dto, int genericFutureId)
        {
            return new Entities.FutureContract()
            {
                FutureContractId = dto.Id,
                GenericFutureId = genericFutureId,
                Symbol = dto.Symbol,
                LastTradeDate = dto.LastTradeDate.ToDateTime(TimeOnly.MinValue)
            };
        }
        public static IEnumerable<Entities.FutureContract> Map(this IEnumerable<FutureContractDto> dtos, int genericFutureId)
        {
            return dtos.Select(x => x.Map(genericFutureId));
        }
        public static Entities.GenericFuture Map(this GenericFutureDto dto)
        {
            return new Entities.GenericFuture()
            {

                GenericFutureId = dto.Id,
                Symbol = dto.Symbol,
                ContractSize = (decimal)dto.ContractSize
            };
        }

        public static IEnumerable<Order> Map(this IEnumerable<OrderDto> dtos)
        {
            return dtos.Select(x => x.Map());
        }
        public static Order Map(this OrderDto dto)
        {
            if (dto.OrderAllocations.Count() != 1)
                throw new InvalidOperationException($"Usupported number of allocation. Order {dto.OrderId} has {dto.OrderAllocations.Count()}. Efrp Module only support single allocation.");
            OrderAllocationDto alloc = dto.OrderAllocations.Single();
            return new Order(
                dto.OrderId,
                dto.InstrumentId,
                dto.BrokerId,
                dto.Quantity,
                dto.TradingDesk,
                alloc.TradingAccount,//TODO:EFRP only accept individual orders for now. Add validation or support for multi alloc
                alloc.PortfolioId,
                dto.RebalancingSessionId,
                alloc.PositionSide,
                dto.OrderReason
                );
        }

        public static IEnumerable<EfrpOrderDto> Map(this IEnumerable<EfrpOrder> efrpOrders)
        {
            return efrpOrders.Select(x => x.Map()).ToList();
        }
        public static EfrpOrderDto Map(this EfrpOrder efrpOrder)
        {
            return new EfrpOrderDto()
            {
                OriginalOrderId = efrpOrder.OriginalOrderId,
                BaseCurrency = efrpOrder.FxForwardOrder.BaseCurrency,
                QuoteCurrency = efrpOrder.FxForwardOrder.QuoteCurrency,
                ValueDate = efrpOrder.FxForwardOrder.ValueDate,
                Quantity = efrpOrder.FxForwardOrder.Quantity,
                Symbol = efrpOrder.FxForwardOrder.Symbol,
                TradingAccount = efrpOrder.OriginalOrder.TradingAccount,
                TradingDesk = efrpOrder.TradingDesk,
                PortfolioId = efrpOrder.PortfolioId,
                RebalancingId = efrpOrder.RebalancingId,
                PositionSide = efrpOrder.PositionSide,
                OrderReason = efrpOrder.OrderReason
            };
        }


        public static IEnumerable<EfrpTradeDto> Map(this IEnumerable<EfrpTrade> efrpOrders)
        {
            return efrpOrders.Select(x => x.Map()).ToList();
        }
        public static EfrpTradeDto Map(this EfrpTrade efrpTrade)
        {

            return new EfrpTradeDto()
            {
                Quantity = efrpTrade.Quantity,
                TradeDate = efrpTrade.TradeDate,
                BloombergSymbol = efrpTrade.BloombergSymbol,
                Ccy1 = efrpTrade.Ccy1,
                Ccy1Amount = efrpTrade.Ccy1Amount,
                ClientSide = efrpTrade.ClientSide,
                AvgPrice = efrpTrade.AvgPrice,
                EfrpDeals = efrpTrade.EfrpDeals.Map(),
                FirstDealEntryTimeUtc = efrpTrade.FirstDealEntryTimeUtc,
                FutureContractId = efrpTrade.FutureContractId,
                LastDealEntryTimeUtc = efrpTrade.LastDealEntryTimeUtc,
                PointValue = efrpTrade.PointValue,
                MaxDealPrice = efrpTrade.MaxDealPrice,
                NumberOfDeals =  (byte)efrpTrade.NumberOfDeals,
                TradeValue = efrpTrade.TradeValue,
                Principal = efrpTrade.Principal,
                MinDealPrice = efrpTrade.MinDealPrice,
                Exchange = efrpTrade.Exchange,
                ExchangeSymbol = efrpTrade.ExchangeSymbol,
                FutureRate = efrpTrade.FutureRate,
                LastUpdateTimeUtc = efrpTrade.LastUpdateTimeUtc,


            };
        }

        public static IEnumerable<EfrpDealDto> Map(this IEnumerable<EfrpDeal> efrpOrders)
        {
            return efrpOrders.Select(x => x.Map()).ToList();
        }
        public static EfrpDealDto Map(this EfrpDeal efrpDeal)
        {

            return new EfrpDealDto()
            {
                Quantity = efrpDeal.Quantity,
                TradeDate = efrpDeal.TradeDate,
                BloombergSymbol = efrpDeal.BloombergSymbol,
                Ccy1 = efrpDeal.Currency,
                Ccy1Amount = efrpDeal.ForwardAmount,
                DealSide = efrpDeal.DealSide,
                DealEntryTimeUtc = efrpDeal.DealEntryTimeUtc,
                DealValue = efrpDeal.DealValue,
                Price = efrpDeal.Price,
                Principal = efrpDeal.Principal,
                PointValue = efrpDeal.PointValue,
                EntryUser = efrpDeal.EntryUser,
                Exchange = efrpDeal.Exchange,
                ExchangeSymbol = efrpDeal.ExchangeSymbol,
                FutureRate = efrpDeal.FutureRate,
                LastUpdateTimeUtc = efrpDeal.LastUpdateTimeUtc,
                ValeDate = efrpDeal.ValeDate

            };
        }
    }
}
