using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Message = Bloomberglp.Blpapi.Message;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Parsers
{
    internal class RouteMessageParser : ISubscriptionMessageParser<RouteSubscriptionMessage>
    {
        public RouteSubscriptionMessage Parse(Message msg)
        {
            CorrelationID correlationID = msg.CorrelationID;
            DateTime timeReceived = msg.TimeReceived;
            EmsxRouteDto emsxRoute = new EmsxRouteDto()
            {
                ApiSeqNum = msg.GetAsLongOrDefault(API_SEQ_NUM),
                Account = msg.GetAsStringOrDefault(EMSX_ACCOUNT),
                Amount = msg.GetAsIntOrDefault(EMSX_AMOUNT),
                AvgPrice = msg.GetAsDoubleOrDefault(EMSX_AVG_PRICE),
                Broker = msg.GetAsStringOrDefault(EMSX_BROKER),
                BrokerComm = msg.GetAsDoubleOrDefault(EMSX_BROKER_COMM),
                BseAvgPrice = msg.GetAsDoubleOrDefault(EMSX_BSE_AVG_PRICE),
                BseFilled = msg.GetAsIntOrDefault(EMSX_BSE_FILLED),
                ClearingAccount = msg.GetAsStringOrDefault(EMSX_CLEARING_ACCOUNT),
                ClearingFirm = msg.GetAsStringOrDefault(EMSX_CLEARING_FIRM),
                CommDiffFlag = msg.GetAsStringOrDefault(EMSX_COMM_DIFF_FLAG),
                CommRate = msg.GetAsDoubleOrDefault(EMSX_COMM_RATE),
                CurrencyPair = msg.GetAsStringOrDefault(EMSX_CURRENCY_PAIR),
                CustomAccount = msg.GetAsStringOrDefault(EMSX_CUSTOM_ACCOUNT),
                DayAvgPrice = msg.GetAsDoubleOrDefault(EMSX_DAY_AVG_PRICE),
                DayFill = msg.GetAsIntOrDefault(EMSX_DAY_FILL),
                ExchangeDestination = msg.GetAsStringOrDefault(EMSX_EXCHANGE_DESTINATION),
                ExecInstruction = msg.GetAsStringOrDefault(EMSX_EXEC_INSTRUCTION),
                ExecuteBroker = msg.GetAsStringOrDefault(EMSX_EXECUTE_BROKER),
                FillId = msg.GetAsIntOrDefault(EMSX_FILL_ID),
                Filled = msg.GetAsIntOrDefault(EMSX_FILLED),
                GtdDate = msg.GetAsIntOrDefault(EMSX_GTD_DATE),
                HandInstruction = msg.GetAsStringOrDefault(EMSX_HAND_INSTRUCTION),
                IsManualRoute = msg.GetAsIntOrDefault(EMSX_IS_MANUAL_ROUTE),
                LastFillDate = msg.GetAsIntOrDefault(EMSX_LAST_FILL_DATE),
                LastFillTime = msg.GetAsIntOrDefault(EMSX_LAST_FILL_TIME),
                LastMarket = msg.GetAsStringOrDefault(EMSX_LAST_MARKET),
                LastPrice = msg.GetAsDoubleOrDefault(EMSX_LAST_PRICE),
                LastShares = msg.GetAsIntOrDefault(EMSX_LAST_SHARES),
                LimitPrice = msg.GetAsDoubleOrDefault(EMSX_LIMIT_PRICE),
                Misc_fees = msg.GetAsDoubleOrDefault(EMSX_MISC_FEES),
                MlLegQuantity = msg.GetAsIntOrDefault(EMSX_ML_LEG_QUANTITY),
                MlNumLegs = msg.GetAsIntOrDefault(EMSX_ML_NUM_LEGS),
                MlPercentFilled = msg.GetAsDoubleOrDefault(EMSX_ML_PERCENT_FILLED),
                MlRation = msg.GetAsDoubleOrDefault(EMSX_ML_RATIO),
                MlRemainBalance = msg.GetAsDoubleOrDefault(EMSX_ML_REMAIN_BALANCE),
                MlStrategy = msg.GetAsStringOrDefault(EMSX_ML_STRATEGY),
                MlTotalQuantity = msg.GetAsIntOrDefault(EMSX_ML_TOTAL_QUANTITY),
                Notes = msg.GetAsStringOrDefault(EMSX_NOTES),
                NseAvgPrice = msg.GetAsDoubleOrDefault(EMSX_NSE_AVG_PRICE),
                NseFilled = msg.GetAsIntOrDefault(EMSX_NSE_FILLED),
                OrderType = msg.GetAsStringOrDefault(EMSX_ORDER_TYPE),
                Pa = msg.GetAsStringOrDefault(EMSX_P_A),
                PercentRemain = msg.GetAsDoubleOrDefault(EMSX_PERCENT_REMAIN),
                Principal = msg.GetAsDoubleOrDefault(EMSX_PRINCIPAL),
                QueuedDate = msg.GetAsIntOrDefault(EMSX_QUEUED_DATE),
                QueuedTime = msg.GetAsIntOrDefault(EMSX_QUEUED_TIME),
                ReasonCode = msg.GetAsStringOrDefault(EMSX_REASON_CODE),
                ReasonDescription = msg.GetAsStringOrDefault(EMSX_REASON_DESC),
                RemainBalance = msg.GetAsDoubleOrDefault(EMSX_REMAIN_BALANCE),
                RouteCreateDate = msg.GetAsIntOrDefault(EMSX_ROUTE_CREATE_DATE),
                RouteCreateTime = msg.GetAsIntOrDefault(EMSX_ROUTE_CREATE_TIME),
                RouteId = msg.GetAsIntOrDefault(EMSX_ROUTE_ID),
                RouteRefId = msg.GetAsStringOrDefault(EMSX_ROUTE_REF_ID),
                RouteLastUpdateTime = msg.GetAsIntOrDefault(EMSX_ROUTE_LAST_UPDATE_TIME),
                RoutePrice = msg.GetAsDoubleOrDefault(EMSX_ROUTE_PRICE),
                Sequence = msg.GetAsIntOrDefault(EMSX_SEQUENCE),
                SettleAmount = msg.GetAsDoubleOrDefault(EMSX_SETTLE_AMOUNT),
                SettleDate = msg.GetAsIntOrDefault(EMSX_SETTLE_DATE),
                Status = msg.GetAsStringOrDefault(EMSX_STATUS),
                StopPrice = msg.GetAsDoubleOrDefault(EMSX_STOP_PRICE),
                StrategyEndTime = msg.GetAsIntOrDefault(EMSX_STRATEGY_END_TIME),
                StrategyPartRate1 = msg.GetAsDoubleOrDefault(EMSX_STRATEGY_PART_RATE1),
                StrategyPartRate2 = msg.GetAsDoubleOrDefault(EMSX_STRATEGY_PART_RATE2),
                StrategyStartTime = msg.GetAsIntOrDefault(EMSX_STRATEGY_START_TIME),
                StrategyStyle = msg.GetAsStringOrDefault(EMSX_STRATEGY_STYLE),
                StrategyType = msg.GetAsStringOrDefault(EMSX_STRATEGY_TYPE),
                Tif = msg.GetAsStringOrDefault(EMSX_TIF),
                TimeStamp = msg.GetAsIntOrDefault(EMSX_TIME_STAMP),
                Type = msg.GetAsStringOrDefault(EMSX_TYPE),
                UrgencyLevel = msg.GetAsIntOrDefault(EMSX_URGENCY_LEVEL),
                UserCommAmount = msg.GetAsDoubleOrDefault(EMSX_USER_COMM_AMOUNT),
                UserCommRate = msg.GetAsDoubleOrDefault(EMSX_USER_COMM_RATE),
                UserFees = msg.GetAsDoubleOrDefault(EMSX_USER_FEES),
                UserNetMoney = msg.GetAsDoubleOrDefault(EMSX_USER_NET_MONEY),
                Working = msg.GetAsIntOrDefault(EMSX_WORKING)
            };
            return new RouteSubscriptionMessage(correlationID, timeReceived, emsxRoute);
        }
    }
}
