using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Message = Bloomberglp.Blpapi.Message;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;


namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers
{
    internal class OrderMessageParser : ISubscriptionMessageParser<OrderSubscriptionMessage>
    {
        public OrderSubscriptionMessage Parse(Message msg)
        {
            CorrelationID correlationID = msg.CorrelationID;
            DateTime timeReceived = msg.TimeReceived;
            EmsxOrderDto emsxOrder = new EmsxOrderDto()
            {

                ApiSeqNum = msg.GetAsLongOrDefault(API_SEQ_NUM),
                Account = msg.GetAsStringOrDefault(EMSX_ACCOUNT),
                Amount = msg.GetAsIntOrDefault(EMSX_AMOUNT),
                ArrivalPrice = msg.GetAsDoubleOrDefault(EMSX_ARRIVAL_PRICE),
                AssetClass = msg.GetAsStringOrDefault(EMSX_ASSET_CLASS),
                AssignedTrader = msg.GetAsStringOrDefault(EMSX_ASSIGNED_TRADER),
                AvgPrice = msg.GetAsDoubleOrDefault(EMSX_AVG_PRICE),
                BasketName = msg.GetAsStringOrDefault(EMSX_BASKET_NAME),
                BasketNum = msg.GetAsIntOrDefault(EMSX_BASKET_NUM),
                Broker = msg.GetAsStringOrDefault(EMSX_BROKER),
                BrokerComm = msg.GetAsDoubleOrDefault(EMSX_BROKER_COMM),
                BseAvgPrice = msg.GetAsDoubleOrDefault(EMSX_BSE_AVG_PRICE),
                BseFilled = msg.GetAsIntOrDefault(EMSX_BSE_FILLED),
                CfdFlag = msg.GetAsStringOrDefault(EMSX_CFD_FLAG),
                CommDiffFlag = msg.GetAsStringOrDefault(EMSX_COMM_DIFF_FLAG),
                CommRate = msg.GetAsDoubleOrDefault(EMSX_COMM_RATE),
                CurrencyPair = msg.GetAsStringOrDefault(EMSX_CURRENCY_PAIR),
                Date = msg.GetAsDateTimeOrDefault(EMSX_DATE, "yyyyMMdd"),
                DayAvgPrice = msg.GetAsDoubleOrDefault(EMSX_DAY_AVG_PRICE),
                DayFill = msg.GetAsIntOrDefault(EMSX_DAY_FILL),
                DirBrokerFlag = msg.GetAsStringOrDefault(EMSX_DIR_BROKER_FLAG),
                Exchange = msg.GetAsStringOrDefault(EMSX_EXCHANGE),
                ExchangeDestination = msg.GetAsStringOrDefault(EMSX_EXCHANGE_DESTINATION),
                ExecInstruction = msg.GetAsStringOrDefault(EMSX_EXEC_INSTRUCTION),
                FillId = msg.GetAsIntOrDefault(EMSX_FILL_ID),
                Filled = msg.GetAsIntOrDefault(EMSX_FILLED),
                CustomNote1 = msg.GetAsStringOrDefault(EMSX_CUSTOM_NOTE1),
                CustomNote2 = msg.GetAsStringOrDefault(EMSX_CUSTOM_NOTE2),
                CustomNote3 = msg.GetAsStringOrDefault(EMSX_CUSTOM_NOTE3),
                CustomNote4 = msg.GetAsStringOrDefault(EMSX_CUSTOM_NOTE4),
                GtdDate = msg.GetAsDateTimeOrDefault(EMSX_GTD_DATE, "yyyyMMdd"),
                HandInstruction = msg.GetAsStringOrDefault(EMSX_HAND_INSTRUCTION),
                IdleAmount = msg.GetAsIntOrDefault(EMSX_IDLE_AMOUNT),
                InvestorId = msg.GetAsStringOrDefault(EMSX_INVESTOR_ID),
                Isin = msg.GetAsStringOrDefault(EMSX_ISIN),
                LimitPrice = msg.GetAsDoubleOrDefault(EMSX_LIMIT_PRICE),
                Notes = msg.GetAsStringOrDefault(EMSX_NOTES),
                NseAvgPrice = msg.GetAsDoubleOrDefault(EMSX_NSE_AVG_PRICE),
                NseFilled = msg.GetAsIntOrDefault(EMSX_NSE_FILLED),
                OrderRefId = msg.GetAsStringOrDefault(EMSX_ORD_REF_ID),
                OrderType = msg.GetAsStringOrDefault(EMSX_ORDER_TYPE),
                OriginateTrader = msg.GetAsStringOrDefault(EMSX_ORIGINATE_TRADER),
                OriginateTraderFirm = msg.GetAsStringOrDefault(EMSX_ORIGINATE_TRADER_FIRM),
                PercentRemain = msg.GetAsDoubleOrDefault(EMSX_PERCENT_REMAIN),
                PmUuid = msg.GetAsIntOrDefault(EMSX_PM_UUID),
                PortMgr = msg.GetAsStringOrDefault(EMSX_PORT_MGR),
                PortName = msg.GetAsStringOrDefault(EMSX_PORT_NAME),
                PortNum = msg.GetAsIntOrDefault(EMSX_PORT_NUM),
                Position = msg.GetAsStringOrDefault(EMSX_POSITION),
                Principal = msg.GetAsDoubleOrDefault(EMSX_PRINCIPAL),
                Product = msg.GetAsStringOrDefault(EMSX_PRODUCT),
                QueuedDate = msg.GetAsIntOrDefault(EMSX_QUEUED_DATE),
                QueuedTime = msg.GetAsIntOrDefault(EMSX_QUEUED_TIME),
                ReasonCode = msg.GetAsStringOrDefault(EMSX_REASON_CODE),
                ReasonDescription = msg.GetAsStringOrDefault(EMSX_REASON_DESC),
                RemainBalance = msg.GetAsDoubleOrDefault(EMSX_REMAIN_BALANCE),
                RouteId = msg.GetAsIntOrDefault(EMSX_ROUTE_ID),
                RouteRefId = msg.GetAsStringOrDefault(EMSX_ROUTE_REF_ID),
                RoutePrice = msg.GetAsDoubleOrDefault(EMSX_ROUTE_PRICE),
                SecName = msg.GetAsStringOrDefault(EMSX_SEC_NAME),
                Sedol = msg.GetAsStringOrDefault(EMSX_SEDOL),
                Sequence = msg.GetAsIntOrDefault(EMSX_SEQUENCE),
                SettleAmount = msg.GetAsDoubleOrDefault(EMSX_SETTLE_AMOUNT),
                SettleDate = msg.GetAsDateTimeOrDefault(EMSX_SETTLE_DATE, "yyyyMMdd"),
                Side = msg.GetAsStringOrDefault(EMSX_SIDE),
                StartAmount = msg.GetAsIntOrDefault(EMSX_START_AMOUNT),
                Status = msg.GetAsStringOrDefault(EMSX_STATUS),
                StepOutBrooker = msg.GetAsStringOrDefault(EMSX_STEP_OUT_BROKER),
                StopPrice = msg.GetAsDoubleOrDefault(EMSX_STOP_PRICE),
                StrategyEndTime = msg.GetAsIntOrDefault(EMSX_STRATEGY_END_TIME),
                StrategyPartRate1 = msg.GetAsDoubleOrDefault(EMSX_STRATEGY_PART_RATE1),
                StrategyPartRate2 = msg.GetAsDoubleOrDefault(EMSX_STRATEGY_PART_RATE2),
                StrategyStartTime = msg.GetAsIntOrDefault(EMSX_STRATEGY_START_TIME),
                StrategyStyle = msg.GetAsStringOrDefault(EMSX_STRATEGY_STYLE),
                StrategyType = msg.GetAsStringOrDefault(EMSX_STRATEGY_TYPE),
                Ticker = msg.GetAsStringOrDefault(EMSX_TICKER),
                TimeInForce = msg.GetAsStringOrDefault(EMSX_TIF),
                TimeStamp = msg.GetAsTimeSpanOrDefaultFromSecond(EMSX_TIME_STAMP),
                TraderUuid = msg.GetAsIntOrDefault(EMSX_TRAD_UUID),
                TradeDesk = msg.GetAsStringOrDefault(EMSX_TRADE_DESK),
                Trader = msg.GetAsStringOrDefault(EMSX_TRADER),
                TraderNotes = msg.GetAsStringOrDefault(EMSX_TRADER_NOTES),
                TsOrdNum = msg.GetAsIntOrDefault(EMSX_TS_ORDNUM),
                Type = msg.GetAsStringOrDefault(EMSX_TYPE),
                UnderlyingTicker = msg.GetAsStringOrDefault(EMSX_UNDERLYING_TICKER),
                UserCommAmount = msg.GetAsDoubleOrDefault(EMSX_USER_COMM_AMOUNT),
                UserCommRate = msg.GetAsDoubleOrDefault(EMSX_USER_COMM_RATE),
                UserFees = msg.GetAsDoubleOrDefault(EMSX_USER_FEES),
                UserNetMoney = msg.GetAsDoubleOrDefault(EMSX_USER_NET_MONEY),
                UserWorkPrice = msg.GetAsDoubleOrDefault(EMSX_WORK_PRICE),
                Working = msg.GetAsIntOrDefault(EMSX_WORKING),
                YellowKey = msg.GetAsStringOrDefault(EMSX_YELLOW_KEY),
            };

            return new OrderSubscriptionMessage(correlationID, timeReceived, emsxOrder);
        }
    }
}
