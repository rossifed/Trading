using Bloomberglp.Blpapi;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal class RouteSubscription : AbstractSubscription
    {
        public CorrelationID SubscriptionId { get; }

        public RouteSubscription()
        {
            SubscriptionId = new CorrelationID();
        }
        private string AppendFields(string routeTopic)
        {
            routeTopic = routeTopic + $"{API_SEQ_NUM},";
            routeTopic = routeTopic + $"{EMSX_ACCOUNT},";
            routeTopic = routeTopic + $"{EMSX_AMOUNT},";
            routeTopic = routeTopic + $"{EMSX_AVG_PRICE},";
            routeTopic = routeTopic + $"{EMSX_BROKER},";
            routeTopic = routeTopic + $"{EMSX_BROKER_COMM},";
            routeTopic = routeTopic + $"{EMSX_BSE_AVG_PRICE},";
            routeTopic = routeTopic + $"{EMSX_BSE_FILLED},";
            routeTopic = routeTopic + $"{EMSX_CLEARING_ACCOUNT},";
            routeTopic = routeTopic + $"{EMSX_CLEARING_FIRM},";
            routeTopic = routeTopic + $"{EMSX_COMM_DIFF_FLAG},";
            routeTopic = routeTopic + $"{EMSX_COMM_RATE},";
            routeTopic = routeTopic + $"{EMSX_CURRENCY_PAIR},";
            routeTopic = routeTopic + $"{EMSX_CUSTOM_ACCOUNT},";
            routeTopic = routeTopic + $"{EMSX_DAY_AVG_PRICE},";
            routeTopic = routeTopic + $"{EMSX_DAY_FILL},";
            routeTopic = routeTopic + $"{EMSX_EXCHANGE_DESTINATION},";
            routeTopic = routeTopic + $"{EMSX_EXEC_INSTRUCTION},";
            routeTopic = routeTopic + $"{EMSX_EXECUTE_BROKER},";
            routeTopic = routeTopic + $"{EMSX_FILL_ID},";
            routeTopic = routeTopic + $"{EMSX_FILLED},";
            routeTopic = routeTopic + $"{EMSX_GTD_DATE},";
            routeTopic = routeTopic + $"{EMSX_HAND_INSTRUCTION},";
            routeTopic = routeTopic + $"{EMSX_IS_MANUAL_ROUTE},";
            routeTopic = routeTopic + $"{EMSX_LAST_FILL_DATE},";
            routeTopic = routeTopic + $"{EMSX_LAST_FILL_TIME},";
            routeTopic = routeTopic + $"{EMSX_LAST_MARKET},";
            routeTopic = routeTopic + $"{EMSX_LAST_PRICE},";
            routeTopic = routeTopic + $"{EMSX_LAST_SHARES},";
            routeTopic = routeTopic + $"{EMSX_LIMIT_PRICE},";
            routeTopic = routeTopic + $"{EMSX_MISC_FEES},";
            routeTopic = routeTopic + $"{EMSX_ML_LEG_QUANTITY},";
            routeTopic = routeTopic + $"{EMSX_ML_NUM_LEGS},";
            routeTopic = routeTopic + $"{EMSX_ML_PERCENT_FILLED},";
            routeTopic = routeTopic + $"{EMSX_ML_RATIO},";
            routeTopic = routeTopic + $"{EMSX_ML_REMAIN_BALANCE},";
            routeTopic = routeTopic + $"{EMSX_ML_STRATEGY},";
            routeTopic = routeTopic + $"{EMSX_ML_TOTAL_QUANTITY},";
            routeTopic = routeTopic + $"{EMSX_NOTES},";
            routeTopic = routeTopic + $"{EMSX_NSE_AVG_PRICE},";
            routeTopic = routeTopic + $"{EMSX_NSE_FILLED},";
            routeTopic = routeTopic + $"{EMSX_ORDER_TYPE},";
            routeTopic = routeTopic + $"{EMSX_P_A},";
            routeTopic = routeTopic + $"{EMSX_PERCENT_REMAIN},";
            routeTopic = routeTopic + $"{EMSX_PRINCIPAL},";
            routeTopic = routeTopic + $"{EMSX_QUEUED_DATE},";
            routeTopic = routeTopic + $"{EMSX_QUEUED_TIME},";
            routeTopic = routeTopic + $"{EMSX_REASON_CODE},";
            routeTopic = routeTopic + $"{EMSX_REASON_DESC},";
            routeTopic = routeTopic + $"{EMSX_REMAIN_BALANCE},";
            routeTopic = routeTopic + $"{EMSX_ROUTE_CREATE_DATE},";
            routeTopic = routeTopic + $"{EMSX_ROUTE_CREATE_TIME},";
            routeTopic = routeTopic + $"{EMSX_ROUTE_ID},";
            routeTopic = routeTopic + $"{EMSX_ROUTE_REF_ID},";
            routeTopic = routeTopic + $"{EMSX_ROUTE_LAST_UPDATE_TIME},";
            routeTopic = routeTopic + $"{EMSX_ROUTE_PRICE},";
            routeTopic = routeTopic + $"{EMSX_SEQUENCE},";
            routeTopic = routeTopic + $"{EMSX_SETTLE_AMOUNT},";
            routeTopic = routeTopic + $"{EMSX_SETTLE_DATE},";
            routeTopic = routeTopic + $"{EMSX_STATUS},";
            routeTopic = routeTopic + $"{EMSX_STOP_PRICE},";
            routeTopic = routeTopic + $"{EMSX_STRATEGY_END_TIME},";
            routeTopic = routeTopic + $"{EMSX_STRATEGY_PART_RATE1},";
            routeTopic = routeTopic + $"{EMSX_STRATEGY_PART_RATE2},";
            routeTopic = routeTopic + $"{EMSX_STRATEGY_START_TIME},";
            routeTopic = routeTopic + $"{EMSX_STRATEGY_STYLE},";
            routeTopic = routeTopic + $"{EMSX_STRATEGY_TYPE},";
            routeTopic = routeTopic + $"{EMSX_TIF},";
            routeTopic = routeTopic + $"{EMSX_TIME_STAMP},";
            routeTopic = routeTopic + $"{EMSX_TYPE},";
            routeTopic = routeTopic + $"{EMSX_URGENCY_LEVEL},";
            routeTopic = routeTopic + $"{EMSX_USER_COMM_AMOUNT},";
            routeTopic = routeTopic + $"{EMSX_USER_COMM_RATE},";
            routeTopic = routeTopic + $"{EMSX_USER_FEES},";
            routeTopic = routeTopic + $"{EMSX_USER_NET_MONEY},";
            routeTopic = routeTopic + $"{EMSX_WORKING}";
            return routeTopic;

        }
        protected override String BuildString(string serviceName)
        {
            String routeTopic = serviceName + "/route?fields=";
            return AppendFields(routeTopic);

          
        }

        protected override string BuildString(string serviceName, string teamName)
        {
            String routeTopic = $"{serviceName}/route;team={teamName}?fields=";
            return AppendFields(routeTopic);
        }
    }
}
