namespace Quantaventis.Trading.Modules.Execution.Domain.Model
{
    internal class EmsxOrder
    {
        public EmsxOrder()
        {
        }

        internal int EmsxOrderId { get; set; }
        internal int Amount { get; set; }
        internal string? Broker { get; set; }
        internal string? HandInstruction { get; set; }
        internal string? OrderType { get; set; }
        internal string? Ticker { get; set; }
        internal string? TimeInForce { get; set; }
        internal string? OrderOrigin { get; set; }

        internal bool IsCfd => CfdFlag.Trim().ToUpper() == "Y";
        internal long? ApiSeqNum { get; set; }

        internal int? OrderNumber { get; set; }




        internal string? Side { get; set; }

        internal string? Account { get; set; }

        internal string? BasketName { get; set; }


        internal string? Strategy { get; set; }



        internal string? ClearingAccount { get; set; }

        internal string? ClearingFirm { get; set; }

        internal string? CustomNote1 { get; set; }
        internal string? CustomNote2 { get; set; }
        internal string? CustomNote3 { get; set; }

        internal string? CustomNote4 { get; set; }

        internal string? CustomNote5 { get; set; }
        internal string? ExchangeDestination { get; set; }

        internal string? ExecInstruction { get; set; }

        internal string? Warnings { get; set; }

        internal DateTime? GtdDate { get; set; }

        internal string? InvestorId { get; set; }

        internal decimal? LimitPrice { get; set; }

        internal string? LocateBroker { get; set; }
        internal string? LocateId { get; set; }
        internal string? LocateRequest { get; set; }

        internal string? Notes { get; set; }
        internal int? OddLot { get; set; }

        internal string? OrderRefId { get; set; }

        internal TimeSpan? ReleaseTime { get; set; }

        internal int? RequestSequence { get; set; }

        internal string? SettlementCurrency { get; set; }
        internal DateTime? SettlementDate { get; set; }

        internal string? SettlementType { get; set; }
        internal decimal? SettlementPrice { get; set; }

        internal decimal? StopPrice { get; set; }

        internal int? TraderUuid { get; set; }


        internal decimal? ArrivalPrice { get; set; }
        internal string? AssetClass { get; set; }
        internal string? AssignedTrader { get; set; }
        internal decimal? AvgPrice { get; set; }

        internal int? BasketNum { get; set; }

        internal decimal? BrokerComm { get; set; }
        internal decimal? BseAvgPrice { get; set; }
        internal int? BseFilled { get; set; }
        internal string CfdFlag { get; set; }
        internal string? CommDiffFlag { get; set; }
        internal decimal? CommRate { get; set; }
        internal string? CurrencyPair { get; set; }
        internal DateTime? Date { get; set; }
        internal decimal? DayAvgPrice { get; set; }
        internal int? DayFill { get; set; }
        internal string? DirBrokerFlag { get; set; }
        internal string? Exchange { get; set; }

        internal int? FillId { get; set; }
        internal int? Filled { get; set; }

        internal int? IdleAmount { get; set; }

        internal string? Isin { get; set; }

        internal decimal? NseAvgPrice { get; set; }
        internal int? NseFilled { get; set; }

        internal string? OriginateTrader { get; set; }
        internal string? OriginateTraderFirm { get; set; }
        internal decimal? PercentRemain { get; set; }
        internal int? PmUuid { get; set; }
        internal string? PortMgr { get; set; }
        internal string? PortName { get; set; }
        internal int? PortNum { get; set; }
        internal string? Position { get; set; }
        internal decimal? Principal { get; set; }
        internal string? Product { get; set; }
        internal int? QueuedDate { get; set; }
        internal int? QueuedTime { get; set; }
        internal string? ReasonCode { get; set; }
        internal string? ReasonDescription { get; set; }
        internal decimal? RemainBalance { get; set; }
        internal int? RouteId { get; set; }
        internal decimal? RoutePrice { get; set; }
        internal string? SecName { get; set; }
        internal string? Sedol { get; set; }

        internal decimal? SettleAmount { get; set; }
        internal DateTime? SettleDate { get; set; }

        internal int? StartAmount { get; set; }
        internal string Status { get; set; }
        internal string? StepOutBrooker { get; set; }

        internal int? StrategyEndTime { get; set; }
        internal decimal? StrategyPartRate1 { get; set; }
        internal decimal? StrategyPartRate2 { get; set; }
        internal int? StrategyStartTime { get; set; }
        internal string? StrategyStyle { get; set; }
        internal string? StrategyType { get; set; }
        internal TimeSpan? TimeStamp { get; set; }

        internal string? TradeDesk { get; set; }
        internal string? Trader { get; set; }
        internal string? TraderNotes { get; set; }
        internal int? TsOrdNum { get; set; }
        internal string? Type { get; set; }
        internal string? UnderlyingTicker { get; set; }
        internal decimal? UserCommAmount { get; set; }
        internal decimal? UserCommRate { get; set; }
        internal decimal? UserFees { get; set; }
        internal decimal? UserNetMoney { get; set; }
        internal decimal? UserWorkPrice { get; set; }
        internal int? Working { get; set; }
        internal string? YellowKey { get; set; }

        internal string? BookName { get; set; }

        internal string? LocateReq { get; set; }

        internal int? Pa { get; set; }

        internal string? RouteRefId { get; set; }

        internal bool IsPartiallyFilled => Status == "PARTFILL";


        internal bool IsFilled => Status == "FILLED";
        internal bool IsExecuted => IsPartiallyFilled || IsFilled;

        public override string? ToString()
        {
            return $"{Side} {Amount} {Ticker} {Status} EmsxOrderId:{EmsxOrderId}";
        }

        public override bool Equals(object? obj)
        {
            return obj is EmsxOrder order &&
                   EmsxOrderId == order.EmsxOrderId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmsxOrderId);
        }

        internal EmsxOrder UpdateFrom(EmsxOrder emsxOrder)
        {
            return new EmsxOrder()
            {
                //The following info are constaint and are not update. that because emsx api can send them with null or bad values depending on the satatus. 
                EmsxOrderId = EmsxOrderId,
                AssetClass = AssetClass,
                AssignedTrader = AssignedTrader,
                BookName = BookName,
                BrokerComm = BrokerComm,
                BseAvgPrice = BseAvgPrice,
                BseFilled = BseFilled,
                ClearingAccount = ClearingAccount,
                ClearingFirm = ClearingFirm,
                CommDiffFlag = CommDiffFlag,
                CommRate = CommRate,
                CurrencyPair = CurrencyPair,
                Exchange = Exchange,
                ExecInstruction = ExecInstruction,
                GtdDate = GtdDate,
                InvestorId = InvestorId,
                Isin = Isin,
                LocateBroker = LocateBroker,
                LocateId = LocateId,
                LocateReq = LocateReq,
                LocateRequest = LocateRequest,
                NseAvgPrice = NseAvgPrice,
                NseFilled = NseFilled,
                OddLot = OddLot,
                OrderNumber = OrderNumber,
                OrderOrigin = OrderOrigin,
                OrderRefId = OrderRefId,
                OriginateTrader = OriginateTrader,
                OriginateTraderFirm = OriginateTraderFirm,
                PercentRemain = PercentRemain,
                PmUuid = PmUuid,
                PortMgr = PortMgr,
                Product = Product,
                QueuedDate = QueuedDate,
                QueuedTime = QueuedTime,
                ReasonCode = ReasonCode,
                ReasonDescription = ReasonDescription,
                ReleaseTime = ReleaseTime,
                RequestSequence = RequestSequence,
                SecName = SecName,
                Sedol = Sedol,
                SettlementCurrency = SettlementCurrency,
                SettlementDate = SettlementDate,
                SettlementPrice = SettlementPrice,
                SettlementType = SettlementType,
                Side = Side,
                StartAmount = StartAmount,
                StepOutBrooker = StepOutBrooker,
                Strategy = Strategy,
                Ticker = Ticker,
                TsOrdNum = TsOrdNum,
                Warnings = Warnings,
                YellowKey = YellowKey,



                //Only the following fiels must be updated. 
                Amount = emsxOrder.Amount,
                Broker = emsxOrder.Broker,
                HandInstruction = emsxOrder.HandInstruction,
                OrderType = emsxOrder.OrderType,
                TimeInForce = emsxOrder.TimeInForce,
                ApiSeqNum = emsxOrder.ApiSeqNum,
                Account = emsxOrder.Account,
                BasketName = emsxOrder.BasketName,
                CustomNote1 = emsxOrder.CustomNote1,
                CustomNote2 = emsxOrder.CustomNote2,
                CustomNote3 = emsxOrder.CustomNote3,
                CustomNote4 = emsxOrder.CustomNote4,
                CustomNote5 = emsxOrder.CustomNote5,
                ExchangeDestination = emsxOrder.ExchangeDestination,
                LimitPrice = emsxOrder.LimitPrice,
                Notes = emsxOrder.Notes,
                StopPrice = emsxOrder.StopPrice,
                TraderUuid = emsxOrder.TraderUuid,
                ArrivalPrice = emsxOrder.ArrivalPrice,
                AvgPrice = emsxOrder.AvgPrice,
                BasketNum = emsxOrder.BasketNum,
                CfdFlag = emsxOrder.CfdFlag,
                Date = emsxOrder.Date,
                DayAvgPrice = emsxOrder.DayAvgPrice,
                DayFill = emsxOrder.DayFill,
                DirBrokerFlag = emsxOrder.DirBrokerFlag,
                FillId = emsxOrder.FillId,
                Filled = emsxOrder.Filled,
                IdleAmount = emsxOrder.IdleAmount,
                PortName = emsxOrder.PortName,
                PortNum = emsxOrder.PortNum,
                Position = emsxOrder.Position,
                Principal = emsxOrder.Principal,
                RemainBalance = emsxOrder.RemainBalance,
                RouteId = emsxOrder.RouteId,
                RoutePrice = emsxOrder.RoutePrice,
                SettleAmount = emsxOrder.SettleAmount,
                SettleDate = emsxOrder.SettleDate,
                Status = emsxOrder.Status,
                StrategyEndTime = emsxOrder.StrategyEndTime,
                StrategyPartRate1 = emsxOrder.StrategyPartRate1,
                StrategyPartRate2 = emsxOrder.StrategyPartRate2,
                StrategyStartTime = emsxOrder.StrategyStartTime,
                StrategyStyle = emsxOrder.StrategyStyle,
                StrategyType = emsxOrder.StrategyType,
                TimeStamp = emsxOrder.TimeStamp,
                TradeDesk = emsxOrder.TradeDesk,
                Trader = emsxOrder.Trader,
                TraderNotes = emsxOrder.TraderNotes,
                Type = emsxOrder.Type,
                UnderlyingTicker = emsxOrder.UnderlyingTicker,
                UserCommAmount = emsxOrder.UserCommAmount,
                UserCommRate = emsxOrder.UserCommRate,
                UserFees = emsxOrder.UserFees,
                UserNetMoney = emsxOrder.UserNetMoney,
                UserWorkPrice = emsxOrder.UserWorkPrice,
                Working = emsxOrder.Working,
                Pa = emsxOrder.Pa,
                RouteRefId = emsxOrder.RouteRefId
            };
        }


    }
}
