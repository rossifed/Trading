//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;

using Quantaventis.Trading.Modules.EMSX.Api.Dto;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests;

namespace Quantaventis.Trading.Modules.EMSX.Api.Mappers
{
    internal static class Extensions
    {
        internal static AssignTraderRequest Map(this AssignTraderRequestDto dto)
        {

            return new AssignTraderRequest(dto.Sequences, dto.AssigneeTraderUuid);
        }
        internal static CancelOrderRequest Map(this CancelOrderRequestDto dto)
        {

            return new CancelOrderRequest(dto.Sequences);
        }
        internal static CancelRouteRequest Map(this CancelRouteRequestDto dto)
        {

            return new CancelRouteRequest(dto.Sequence, dto.RouteId);
        }
        internal static CreateBasketRequest Map(this CreateBasketRequestDto dto)
        {

            return new CreateBasketRequest(dto.BasketName, dto.Sequences);
        }
        internal static RouteOrderRequest Map(this RouteOrderRequestDto dto)
        {

            return new RouteOrderRequest(
                dto.Sequence,
                dto.Amount,
                dto.Broker,
                dto.HandInstruction,
                dto.OrderType,
                dto.Ticker,
                dto.TimeInForce)
            {
                RouteRefId = dto.RouteRefId,
                StopPrice = dto.StopPrice,
                RequestSequence = dto.RequestSequence,
                Account = dto.Account,
                CfdFlag = dto.CfdFlag,
                ClearingAccount = dto.ClearingAccount,
                ClearingFirm = dto.ClearingFirm,
                ExecInstruction = dto.ExecInstruction,
                GtdDate = dto.GtdDate,
                LimitPrice = dto.LimitPrice,
                Warnings = dto.Warnings,
                LocateId = dto.LocateId,
                LocateRequest = dto.LocateRequest,
                Notes = dto.Notes,
                OddLot = dto.OddLot,
                Pa = dto.Pa,
                ReleaseTime = dto.ReleaseTime,
                TraderUuid = dto.TraderUuid,
                Strategy = dto.Strategy,
                LocateBroker = dto.LocateBroker,
                StrategyParameters = dto.StrategyParameters
            };
        }
        internal static ModifyOrderRequest Map(this ModifyOrderRequestDto dto)
        {

            return new ModifyOrderRequest(dto.Sequence, dto.Amount, dto.OrderType) {
                LimitPrice = dto.LimitPrice,
                TimeInForce = dto.TimeInForce,
                HandInstruction = dto.HandInstruction,
                Account = dto.Account,
                CfdFlag = dto.CfdFlag,
                ExecInstruction = dto.ExecInstruction,
                GtdDate = dto.GtdDate,
                InvestorId = dto.InvestorId,
                Notes = dto.Notes,
                Warnings = dto.Warnings,
                RequestSequence = dto.RequestSequence,
                StopPrice = dto.StopPrice,
                TraderUuid = dto.TraderUuid
            };
        }
        internal static CreateOrderRequest Map(this CreateOrderRequestDto dto)
        {

            return   new CreateOrderRequest(dto.Ticker, dto.Amount, dto.OrderType,dto.TimeInForce, dto.HandInstruction, dto.Side)
            {
                Account = dto.Account,
                BasketName = dto.BasketName,
                Broker = dto.Broker,
                CfdFlag = dto.CfdFlag,
                ClearingAccount = dto.ClearingAccount,
                ClearingFirm = dto.ClearingFirm,
                CustomNote1 = dto.CustomNote1,
                CustomNote2 = dto.CustomNote2,
                CustomNote3 = dto.CustomNote3,
                CustomNote4 = dto.CustomNote4,
                CustomNote5 = dto.CustomNote5,
                ExchangeDestination = dto.ExchangeDestination,
                ExecInstruction = dto.ExecInstruction,
                Warnings = dto.Warnings,
                GtdDate = dto.GtdDate,
                InvestorId = dto.InvestorId,
                LimitPrice = dto.LimitPrice,
                LocateId = dto.LocateId,
                LocateRequest = dto.LocateRequest,
                Notes = dto.Notes,
                OddLot = dto.OddLot,
                OrderOrigin = dto.OrderOrigin,
                OrderRefId = dto.OrderRefId,
                Pa = dto.Pa,
                ReleaseTime = dto.ReleaseTime,
                RequestSequence = dto.RequestSequence,
                SettlementCurrency = dto.SettlementCurrency,
                SettlementDate = dto.SettlementDate,
                SettlementType = dto.SettlementType,
                StopPrice = dto.StopPrice,
                LocateBroker = dto.LocateBroker
            }; ;
        }

        internal static DeleteOrderRequest Map(this DeleteOrderRequestDto dto)
        {

            return new DeleteOrderRequest(dto.EmsxSequences);
        }
        //public static string[] Map(this IEnumerable<ExecutionAlgoParamDto> executionAlgoParamDtos)
        //{

        //    return executionAlgoParamDtos.Select(x => x.Value).ToArray();

        //}
        //public static EmsxOrder Map(this EmsxOrderDto dto)
        //{
        //    return new EmsxOrder
        //    {
        //        Ticker = dto.Ticker,
        //        Amount = dto.Amount,
        //        OrderType = dto.OrderType,
        //        TimeInForce = dto.TimeInForce,
        //        Strategy = dto.Strategy,
        //        HandInstruction = dto.HandInstruction,
        //        Side = dto.Side,
        //        Account = dto.Account,
        //        BasketName = dto.BasketName,
        //        Broker = dto.Broker,

        //        ClearingAccount = dto.ClearingAccount,
        //        ClearingFirm = dto.ClearingFirm,
        //        CustomNote1 = dto.CustomNote1,
        //        CustomNote2 = dto.CustomNote2,
        //        CustomNote3 = dto.CustomNote3,
        //        CustomNote4 = dto.CustomNote4,
        //        ExchangeDestination = dto.ExchangeDestination,
        //        ExecInstruction = dto.ExecInstruction,
        //        Warnings = dto.Warnings,
        //        GtdDate = dto.GtdDate,
        //        InvestorId = dto.InvestorId,
        //        LimitPrice = dto.LimitPrice,
        //        LocateBroker = dto.LocateBroker,
        //        LocateId = dto.LocateId,
        //        LocateRequest = dto.LocateRequest,
        //        Notes = dto.Notes,
        //        OddLot = dto.OddLot,
        //        OrderRefId = dto.OrderRefId,
        //        ReleaseTime = dto.ReleaseTime,
        //        RequestSequence = dto.RequestSequence,
        //        SettlementCurrency = dto.SettlementCurrency,
        //        SettlementDate = dto.SettlementDate,
        //        SettlementType = dto.SettlementType,
        //        SettlementPrice = dto.SettlementPrice,
        //        StopPrice = dto.StopPrice,
        //        TraderUuid = dto.TraderUuid,
        //        ArrivalPrice = dto.ArrivalPrice,
        //        AssetClass = dto.AssetClass,
        //        AssignedTrader = dto.AssignedTrader,
        //        AvgPrice = dto.AvgPrice,
        //        BasketNum = dto.BasketNum,
        //        BrokerComm = dto.BrokerComm,
        //        BseAvgPrice = dto.BseAvgPrice,
        //        BseFilled = dto.BseFilled,
        //        CfdFlag = dto.CfdFlag??"N",
        //        CommDiffFlag = dto.CommDiffFlag,
        //        CommRate = dto.CommRate,
        //        CurrencyPair = dto.CurrencyPair,
        //        Date = dto.Date,
        //        DayAvgPrice = dto.DayAvgPrice,
        //        DayFill = dto.DayFill,
        //        DirBrokerFlag = dto.DirBrokerFlag,
        //        Exchange = dto.Exchange,
        //        FillId = dto.FillId,
        //        Filled = dto.Filled,
        //        IdleAmount = dto.IdleAmount,
        //        Isin = dto.Isin,
        //        NseAvgPrice = dto.NseAvgPrice,
        //        NseFilled = dto.NseFilled,
        //        OriginateTrader = dto.OriginateTrader,
        //        OriginateTraderFirm = dto.OriginateTraderFirm,
        //        PercentRemain = dto.PercentRemain,
        //        PmUuid = dto.PmUuid,
        //        PortMgr = dto.PortMgr,
        //        PortName = dto.PortName,
        //        PortNum = dto.PortNum,
        //        Position = dto.Position,
        //        Principal = dto.Principal,
        //        Product = dto.Product,
        //        QueuedDate = dto.QueuedDate,
        //        QueuedTime = dto.QueuedTime,
        //        ReasonCode = dto.ReasonCode,
        //        ReasonDescription = dto.ReasonDescription,
        //        RemainBalance = dto.RemainBalance,
        //        RouteId = dto.RouteId,
        //        RoutePrice = dto.RoutePrice,
        //        SecName = dto.SecName,
        //        Sedol = dto.Sedol,
        //        Sequence = dto.Sequence,
        //        SettleAmount = dto.SettleAmount,
        //        SettleDate = dto.SettleDate,
        //        StartAmount = dto.StartAmount,
        //        Status = dto.Status,
        //        StepOutBrooker = dto.StepOutBrooker,
        //        StrategyEndTime = dto.StrategyEndTime,
        //        StrategyPartRate1 = dto.StrategyPartRate1,
        //        StrategyPartRate2 = dto.StrategyPartRate2,
        //        StrategyStartTime = dto.StrategyStartTime,
        //        StrategyStyle = dto.StrategyStyle,
        //        StrategyType = dto.StrategyType,
        //        TimeStamp = dto.TimeStamp,
        //        TradeDesk = dto.TradeDesk,
        //        Trader = dto.Trader,
        //        TraderNotes = dto.TraderNotes,
        //        TsOrdNum = dto.TsOrdNum,
        //        Type = dto.Type,
        //        UnderlyingTicker = dto.UnderlyingTicker,
        //        UserCommAmount = dto.UserCommAmount,
        //        UserCommRate = dto.UserCommRate,
        //        UserFees = dto.UserFees,
        //        UserNetMoney = dto.UserNetMoney,
        //        UserWorkPrice = dto.UserWorkPrice,
        //        Working = dto.Working,
        //        YellowKey = dto.YellowKey,
        //        BookName = dto.BookName,
        //        LocateReq = dto.LocateReq,
        //        Pa = dto.Pa,


        //        RouteRefId = dto.RouteRefId
        //    };
        //}
        //public static IEnumerable<EmsxOrder> Map(this IEnumerable<EmsxOrderDto> dtos)
        //{
        //    return dtos.Select(x => x.Map());
        //}
        //public static EmsxOrderDto Map(this EmsxOrder order)
        //{
        //    return new EmsxOrderDto
        //    {
        //        Ticker = order.Ticker,
        //        Amount = order.Amount,
        //        OrderType = order.OrderType,
        //        TimeInForce = order.TimeInForce,
        //        Strategy = order.Strategy,
        //        HandInstruction = order.HandInstruction,
        //        Side = order.Side,
        //        Account = order.Account,
        //        BasketName = order.BasketName,
        //        Broker = order.Broker,

        //        ClearingAccount = order.ClearingAccount,
        //        ClearingFirm = order.ClearingFirm,
        //        CustomNote1 = order.CustomNote1,
        //        CustomNote2 = order.CustomNote2,
        //        CustomNote3 = order.CustomNote3,
        //        CustomNote4 = order.CustomNote4,
        //        CustomNote5 = order.CustomNote5,    
        //        OrderNumber = order.OrderNumber,
        //        ExchangeDestination = order.ExchangeDestination,
        //        ExecInstruction = order.ExecInstruction,
        //        Warnings = order.Warnings,
        //        GtdDate = order.GtdDate,
        //        InvestorId = order.InvestorId,
        //        LimitPrice = order.LimitPrice,
        //        LocateBroker = order.LocateBroker,
        //        LocateId = order.LocateId,
        //        LocateRequest = order.LocateRequest,
        //        Notes = order.Notes,
        //        OddLot = order.OddLot,
        //        OrderRefId = order.OrderRefId,
        //        ReleaseTime = order.ReleaseTime,
        //        RequestSequence = order.RequestSequence,
        //        SettlementCurrency = order.SettlementCurrency,
        //        SettlementDate = order.SettlementDate,
        //        SettlementType = order.SettlementType,
        //        SettlementPrice = order.SettlementPrice,
        //        StopPrice = order.StopPrice,
        //        TraderUuid = order.TraderUuid,
        //        ArrivalPrice = order.ArrivalPrice,
        //        AssetClass = order.AssetClass,
        //        AssignedTrader = order.AssignedTrader,
        //        AvgPrice = order.AvgPrice,
        //        BasketNum = order.BasketNum,
        //        BrokerComm = order.BrokerComm,
        //        BseAvgPrice = order.BseAvgPrice,
        //        BseFilled = order.BseFilled,
        //        CfdFlag = order.CfdFlag.ToString(),
        //        CommDiffFlag = order.CommDiffFlag,
        //        CommRate = order.CommRate,
        //        CurrencyPair = order.CurrencyPair,
        //        Date = order.Date,
        //        DayAvgPrice = order.DayAvgPrice,
        //        DayFill = order.DayFill,
        //        DirBrokerFlag = order.DirBrokerFlag,
        //        Exchange = order.Exchange,
        //        FillId = order.FillId,
        //        Filled = order.Filled,
        //        IdleAmount = order.IdleAmount,
        //        Isin = order.Isin,
        //        NseAvgPrice = order.NseAvgPrice,
        //        NseFilled = order.NseFilled,
        //        OriginateTrader = order.OriginateTrader,
        //        OriginateTraderFirm = order.OriginateTraderFirm,
        //        PercentRemain = order.PercentRemain,
        //        PmUuid = order.PmUuid,
        //        PortMgr = order.PortMgr,
        //        PortName = order.PortName,
        //        PortNum = order.PortNum,
        //        Position = order.Position,
        //        Principal = order.Principal,
        //        Product = order.Product,
        //        QueuedDate = order.QueuedDate,
        //        QueuedTime = order.QueuedTime,
        //        ReasonCode = order.ReasonCode,
        //        ReasonDescription = order.ReasonDescription,
        //        RemainBalance = order.RemainBalance,
        //        RouteId = order.RouteId,
        //        RoutePrice = order.RoutePrice,
        //        SecName = order.SecName,
        //        Sedol = order.Sedol,
        //        Sequence = order.Sequence,
        //        SettleAmount = order.SettleAmount,
        //        SettleDate = order.SettleDate,
        //        StartAmount = order.StartAmount,
        //        Status = order.Status,
        //        StepOutBrooker = order.StepOutBrooker,
        //        StrategyEndTime = order.StrategyEndTime,
        //        StrategyPartRate1 = order.StrategyPartRate1,
        //        StrategyPartRate2 = order.StrategyPartRate2,
        //        StrategyStartTime = order.StrategyStartTime,
        //        StrategyStyle = order.StrategyStyle,
        //        StrategyType = order.StrategyType,
        //        TimeStamp = order.TimeStamp,
        //        TradeDesk = order.TradeDesk,
        //        Trader = order.Trader,
        //        TraderNotes = order.TraderNotes,
        //        TsOrdNum = order.TsOrdNum,
        //        Type = order.Type,
        //        UnderlyingTicker = order.UnderlyingTicker,
        //        UserCommAmount = order.UserCommAmount,
        //        UserCommRate = order.UserCommRate,
        //        UserFees = order.UserFees,
        //        UserNetMoney = order.UserNetMoney,
        //        UserWorkPrice = order.UserWorkPrice,
        //        Working = order.Working,
        //        YellowKey = order.YellowKey,
        //        BookName = order.BookName,
        //        LocateReq = order.LocateReq,
        //        Pa = order.Pa,
        //        RouteRefId = order.RouteRefId
        //    };
        //}
        //public static IEnumerable<EmsxOrderDto> Map(this IEnumerable<EmsxOrder> dtos)
        //{
        //    return dtos.Select(x => x.Map());
        //}

        //public static IEnumerable<Dto.EmsxFillDto> Map(this IEnumerable<Infrastructure.Model.EmsxFillDto> dtos)
        //{
        //    return dtos.Select(x => x.Map());
        //}
        //public static Dto.EmsxFillDto Map(this Infrastructure.Model.EmsxFillDto emsxFill)
        //{
        //    return new Dto.EmsxFillDto
        //    {
        //        Account = emsxFill.Account,
        //        Amount = emsxFill.Amount,
        //        AssetClass = emsxFill.AssetClass,
        //        BasketId = emsxFill.BasketId,
        //        Bbgid = emsxFill.Bbgid,
        //        BlockId = emsxFill.BlockId,
        //        Broker = emsxFill.Broker,
        //        ClearingAccount = emsxFill.ClearingAccount,
        //        ClearingFirm = emsxFill.ClearingFirm,
        //        ContractExpDate = emsxFill.ContractExpDate,
        //        CorrectedFillId = emsxFill.CorrectedFillId,
        //        Currency = emsxFill.Currency,
        //        Cusip = emsxFill.Cusip,
        //        DateTimeOfFill = emsxFill.DateTimeOfFill,
        //        Exchange = emsxFill.Exchange,
        //        ExecPrevSeqNo = emsxFill.ExecPrevSeqNo,
        //        ExecType = emsxFill.ExecType,
        //        ExecutingBroker = emsxFill.ExecutingBroker,
        //        FillId = emsxFill.FillId,
        //        FillPrice = emsxFill.FillPrice,
        //        FillShares = emsxFill.FillShares,
        //        InvestorId = emsxFill.InvestorId,
        //        IsCFD = emsxFill.IsCFD,
        //        Isin = emsxFill.Isin,
        //        IsLeg = emsxFill.IsLeg,
        //        LastCapacity = emsxFill.LastCapacity,
        //        LastMarket = emsxFill.LastMarket,
        //        LimitPrice = emsxFill.LimitPrice,
        //        Liquidity = emsxFill.Liquidity,
        //        LocalExchangeSymbol = emsxFill.LocalExchangeSymbol,
        //        LocateBroker = emsxFill.LocateBroker,
        //        LocateId = emsxFill.LocateId,
        //        LocateRequired = emsxFill.LocateRequired,
        //        MultiLedId = emsxFill.MultiLedId,
        //        OccSymbol = emsxFill.OccSymbol,
        //        OrderExecutionInstruction = emsxFill.OrderExecutionInstruction,
        //        OrderHandlingInstruction = emsxFill.OrderHandlingInstruction,
        //        OrderId = emsxFill.OrderId,
        //        OrderInstruction = emsxFill.OrderInstruction,
        //        OrderOrigin = emsxFill.OrderOrigin,
        //        OrderReferenceId = emsxFill.OrderReferenceId,
        //        OriginatingTraderUUId = emsxFill.OriginatingTraderUUId,
        //        ReroutedBroker = emsxFill.ReroutedBroker,
        //        RouteCommissionAmount = emsxFill.RouteCommissionAmount,
        //        RouteCommissionRate = emsxFill.RouteCommissionRate,
        //        RouteExecutionInstruction = emsxFill.RouteExecutionInstruction,
        //        RouteHandlingInstruction = emsxFill.RouteHandlingInstruction,
        //        RouteId = emsxFill.RouteId,
        //        RouteNetMoney = emsxFill.RouteNetMoney,
        //        RouteNotes = emsxFill.RouteNotes,
        //        RouteShares = emsxFill.RouteShares,
        //        SecurityName = emsxFill.SecurityName,
        //        Sedol = emsxFill.Sedol,
        //        SettlementDate = emsxFill.SettlementDate,
        //        Side = emsxFill.Side,
        //        StopPrice = emsxFill.StopPrice,
        //        StrategyType = emsxFill.StrategyType,
        //        Ticker = emsxFill.Ticker,
        //        Tif = emsxFill.Tif,
        //        TraderName = emsxFill.TraderName,
        //        TraderUUId = emsxFill.TraderUUId,
        //        Type = emsxFill.Type,
        //        UserCommissionAmount = emsxFill.UserCommissionAmount,
        //        UserCommissionRate = emsxFill.UserCommissionRate,
        //        UserFees = emsxFill.UserFees,
        //        UserNetMoney = emsxFill.UserNetMoney,
        //        YellowKey = emsxFill.YellowKey
        //    };
        //}
    }
}
