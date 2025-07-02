using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal class OrderSubscription :AbstractSubscription
    {
        public CorrelationID SubscriptionId { get; }

        public OrderSubscription()
        {
            SubscriptionId = new CorrelationID();
        }

   
        protected override String BuildString(string serviceName)
        {
            String orderTopic = serviceName + "/order?fields=";
            return AppendFields(orderTopic);
            
        }
        private  string AppendFields(string orderTopic)
        {
            orderTopic = orderTopic + API_SEQ_NUM + ",";
            orderTopic = orderTopic + EMSX_ACCOUNT + ",";
            orderTopic = orderTopic + EMSX_AMOUNT + ",";
            orderTopic = orderTopic + EMSX_ARRIVAL_PRICE + ",";
            orderTopic = orderTopic + EMSX_ASSET_CLASS + ",";
            orderTopic = orderTopic + EMSX_ASSIGNED_TRADER + ",";
            orderTopic = orderTopic + EMSX_AVG_PRICE + ",";
            orderTopic = orderTopic + EMSX_BASKET_NAME + ",";
            orderTopic = orderTopic + EMSX_BASKET_NUM + ",";
            orderTopic = orderTopic + EMSX_BROKER + ",";
            orderTopic = orderTopic + EMSX_BROKER_COMM + ",";
            orderTopic = orderTopic + EMSX_BSE_AVG_PRICE + ",";
            orderTopic = orderTopic + EMSX_BSE_FILLED + ",";
            orderTopic = orderTopic + EMSX_CFD_FLAG + ",";
            orderTopic = orderTopic + EMSX_COMM_DIFF_FLAG + ",";
            orderTopic = orderTopic + EMSX_COMM_RATE + ",";
            orderTopic = orderTopic + EMSX_CURRENCY_PAIR + ",";
            orderTopic = orderTopic + EMSX_DATE + ",";
            orderTopic = orderTopic + EMSX_DAY_AVG_PRICE + ",";
            orderTopic = orderTopic + EMSX_DAY_FILL + ",";
            orderTopic = orderTopic + EMSX_DIR_BROKER_FLAG + ",";
            orderTopic = orderTopic + EMSX_EXCHANGE + ",";
            orderTopic = orderTopic + EMSX_EXCHANGE_DESTINATION + ",";
            orderTopic = orderTopic + EMSX_EXEC_INSTRUCTION + ",";
            orderTopic = orderTopic + EMSX_FILL_ID + ",";
            orderTopic = orderTopic + EMSX_FILLED + ",";
            orderTopic = orderTopic + EMSX_GTD_DATE + ",";
            orderTopic = orderTopic + EMSX_HAND_INSTRUCTION + ",";
            orderTopic = orderTopic + EMSX_IDLE_AMOUNT + ",";
            orderTopic = orderTopic + EMSX_INVESTOR_ID + ",";
            orderTopic = orderTopic + EMSX_ISIN + ",";
            orderTopic = orderTopic + EMSX_LIMIT_PRICE + ",";
            orderTopic = orderTopic + EMSX_NOTES + ",";
            orderTopic = orderTopic + EMSX_NSE_AVG_PRICE + ",";
            orderTopic = orderTopic + EMSX_NSE_FILLED + ",";
            orderTopic = orderTopic + EMSX_ORD_REF_ID + ",";
            orderTopic = orderTopic + EMSX_ORDER_TYPE + ",";
            orderTopic = orderTopic + EMSX_ORIGINATE_TRADER + ",";
            orderTopic = orderTopic + EMSX_ORIGINATE_TRADER_FIRM + ",";
            orderTopic = orderTopic + EMSX_PERCENT_REMAIN + ",";
            orderTopic = orderTopic + EMSX_PM_UUID + ",";
            orderTopic = orderTopic + EMSX_PORT_MGR + ",";
            orderTopic = orderTopic + EMSX_PORT_NAME + ",";
            orderTopic = orderTopic + EMSX_PORT_NUM + ",";
            orderTopic = orderTopic + EMSX_POSITION + ",";
            orderTopic = orderTopic + EMSX_PRINCIPAL + ",";
            orderTopic = orderTopic + EMSX_PRODUCT + ",";
            orderTopic = orderTopic + EMSX_QUEUED_DATE + ",";
            orderTopic = orderTopic + EMSX_QUEUED_TIME + ",";
            orderTopic = orderTopic + EMSX_REASON_CODE + ",";
            orderTopic = orderTopic + EMSX_REASON_DESC + ",";
            orderTopic = orderTopic + EMSX_REMAIN_BALANCE + ",";
            orderTopic = orderTopic + EMSX_ROUTE_ID + ",";
            orderTopic = orderTopic + EMSX_ROUTE_PRICE + ",";
            orderTopic = orderTopic + EMSX_SEC_NAME + ",";
            orderTopic = orderTopic + EMSX_SEDOL + ",";
            orderTopic = orderTopic + EMSX_SEQUENCE + ",";
            orderTopic = orderTopic + EMSX_SETTLE_AMOUNT + ",";
            orderTopic = orderTopic + EMSX_SETTLE_DATE + ",";
            orderTopic = orderTopic + EMSX_SIDE + ",";
            orderTopic = orderTopic + EMSX_START_AMOUNT + ",";
            orderTopic = orderTopic + EMSX_STATUS + ",";
            orderTopic = orderTopic + EMSX_STEP_OUT_BROKER + ",";
            orderTopic = orderTopic + EMSX_STOP_PRICE + ",";
            orderTopic = orderTopic + EMSX_STRATEGY_END_TIME + ",";
            orderTopic = orderTopic + EMSX_STRATEGY_PART_RATE1 + ",";
            orderTopic = orderTopic + EMSX_STRATEGY_PART_RATE2 + ",";
            orderTopic = orderTopic + EMSX_STRATEGY_START_TIME + ",";
            orderTopic = orderTopic + EMSX_STRATEGY_STYLE + ",";
            orderTopic = orderTopic + EMSX_STRATEGY_TYPE + ",";
            orderTopic = orderTopic + EMSX_TICKER + ",";
            orderTopic = orderTopic + EMSX_TIF + ",";
            orderTopic = orderTopic + EMSX_TIME_STAMP + ",";
            orderTopic = orderTopic + EMSX_TRAD_UUID + ",";
            orderTopic = orderTopic + EMSX_TRADE_DESK + ",";
            orderTopic = orderTopic + EMSX_TRADER + ",";
            orderTopic = orderTopic + EMSX_TRADER_NOTES + ",";
            orderTopic = orderTopic + EMSX_TS_ORDNUM + ",";
            orderTopic = orderTopic + EMSX_TYPE + ",";
            orderTopic = orderTopic + EMSX_UNDERLYING_TICKER + ",";
            orderTopic = orderTopic + EMSX_USER_COMM_AMOUNT + ",";
            orderTopic = orderTopic + EMSX_USER_COMM_RATE + ",";
            orderTopic = orderTopic + EMSX_USER_FEES + ",";
            orderTopic = orderTopic + EMSX_USER_NET_MONEY + ",";
            orderTopic = orderTopic + EMSX_WORK_PRICE + ",";
            orderTopic = orderTopic + EMSX_WORKING + ",";
            orderTopic = orderTopic + EMSX_CUSTOM_NOTE1 + ",";
            orderTopic = orderTopic + EMSX_CUSTOM_NOTE2 + ",";
            orderTopic = orderTopic + EMSX_CUSTOM_NOTE3 + ",";
            orderTopic = orderTopic + EMSX_CUSTOM_NOTE4 + ",";
            return orderTopic;

        }
        protected override string BuildString(string serviceName, string teamName)
        {
            String orderTopic = $"{serviceName}/order;team={teamName}?fields=";
            return AppendFields(orderTopic);

        }
    }
}
