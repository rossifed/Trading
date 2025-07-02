using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    internal static class EmsxElements
    {
        public const string API_SEQ_NUM = "API_SEQ_NUM";
        public const string EMSX_ACCOUNT = "EMSX_ACCOUNT";
        public const string EMSX_ALL_SUCCESS = "EMSX_ALL_SUCCESS";
        public const string EMSX_AMOUNT = "EMSX_AMOUNT";
        public const string EMSX_ARRIVAL_PRICE = "EMSX_ARRIVAL_PRICE";
        public const string EMSX_ASSET_CLASS = "EMSX_ASSET_CLASS";
        public const string EMSX_ASSIGNED_TRADER = "EMSX_ASSIGNED_TRADER";
        public const string EMSX_ASSIGNEE_TRADER_UUID = "EMSX_ASSIGNEE_TRADER_UUID";
        public const string EMSX_ASSIGN_TRADER_FAILED_ORDERS = "EMSX_ASSIGN_TRADER_FAILED_ORDERS";
        public const string EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS = "EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS";
        public const string EMSX_AVG_PRICE = "EMSX_AVG_PRICE";
        public const string EMSX_BASKET_NAME = "EMSX_BASKET_NAME";
        public const string EMSX_BASKET_NUM = "EMSX_BASKET_NUM";
        public const string EMSX_BOOKNAME = "EMSX_BOOKNAME";
        public const string EMSX_BROKER = "EMSX_BROKER";
        public const string EMSX_BROKER_COMM = "EMSX_BROKER_COMM";
        public const string EMSX_BSE_AVG_PRICE = "EMSX_BSE_AVG_PRICE";
        public const string EMSX_BSE_FILLED = "EMSX_BSE_FILLED";
        public const string EMSX_CFD_FLAG = "EMSX_CFD_FLAG";
        public const string EMSX_CLEARING_ACCOUNT = "EMSX_CLEARING_ACCOUNT";
        public const string EMSX_CLEARING_FIRM = "EMSX_CLEARING_FIRM";
        public const string EMSX_COMM_DIFF_FLAG = "EMSX_COMM_DIFF_FLAG";
        public const string EMSX_COMM_RATE = "EMSX_COMM_RATE";
        public const string EMSX_CURRENCY_PAIR = "EMSX_CURRENCY_PAIR";
        public const string EMSX_CUSTOM_ACCOUNT = "EMSX_CUSTOM_ACCOUNT";
        public const string EMSX_CUSTOM_NOTE1 = "EMSX_CUSTOM_NOTE1";
        public const string EMSX_CUSTOM_NOTE2 = "EMSX_CUSTOM_NOTE2";
        public const string EMSX_CUSTOM_NOTE3 = "EMSX_CUSTOM_NOTE3";
        public const string EMSX_CUSTOM_NOTE4 = "EMSX_CUSTOM_NOTE4";
        public const string EMSX_CUSTOM_NOTE5 = "EMSX_CUSTOM_NOTE5";
        public const string EMSX_DATE = "EMSX_DATE";
        public const string EMSX_DAY_AVG_PRICE = "EMSX_DAY_AVG_PRICE";
        public const string EMSX_DAY_FILL = "EMSX_DAY_FILL";
        public const string EMSX_DIR_BROKER_FLAG = "EMSX_DIR_BROKER_FLAG";
        public const string EMSX_EXECUTE_BROKER = "EMSX_EXECUTE_BROKER";
        public const string EMSX_EXCHANGE = "EMSX_EXCHANGE";
        public const string EMSX_EXCHANGE_DESTINATION = "EMSX_EXCHANGE_DESTINATION";
        public const string EMSX_EXEC_INSTRUCTION = "EMSX_EXEC_INSTRUCTION";
        public const string EMSX_FIELD_DATA = "EMSX_FIELD_DATA";
        public const string EMSX_FIELD_INDICATOR = "EMSX_FIELD_INDICATOR";
        public const string EMSX_FILL_ID = "EMSX_FILL_ID";
        public const string EMSX_FILLED = "EMSX_FILLED";
        public const string EMSX_GET_WARNINGS = "EMSX_GET_WARNINGS";
        public const string EMSX_GTD_DATE = "EMSX_GTD_DATE";
        public const string EMSX_HAND_INSTRUCTION = "EMSX_HAND_INSTRUCTION";
        public const string EMSX_IDLE_AMOUNT = "EMSX_IDLE_AMOUNT";
        public const string EMSX_INVESTOR_ID = "EMSX_INVESTOR_ID";
        public const string EMSX_ISIN = "EMSX_ISIN";
        public const string EMSX_IS_MANUAL_ROUTE = "EMSX_IS_MANUAL_ROUTE";
        public const string EMSX_LAST_FILL_DATE = "EMSX_LAST_FILL_DATE";
        public const string EMSX_LAST_FILL_TIME = "EMSX_LAST_FILL_TIME";
        public const string EMSX_LAST_MARKET = "EMSX_LAST_MARKET";
        public const string EMSX_LAST_PRICE = "EMSX_LAST_PRICE";
        public const string EMSX_LAST_SHARES = "EMSX_LAST_SHARES";
        public const string EMSX_LIMIT_PRICE = "EMSX_LIMIT_PRICE";
        public const string EMSX_LOCATE_BROKER = "EMSX_LOCATE_BROKER";
        public const string EMSX_LOCATE_ID = "EMSX_LOCATE_ID";
        public const string EMSX_LOCATE_REQ = "EMSX_LOCATE_REQ";
        public const string EMSX_ML_LEG_QUANTITY = "EMSX_ML_LEG_QUANTITY";
        public const string EMSX_ML_NUM_LEGS = "EMSX_ML_NUM_LEGS";
        public const string EMSX_ML_PERCENT_FILLED = "EMSX_ML_PERCENT_FILLED";
        public const string EMSX_ML_RATIO = "EMSX_ML_RATIO";
        public const string EMSX_ML_REMAIN_BALANCE = "EMSX_ML_REMAIN_BALANCE";
        public const string EMSX_ML_STRATEGY = "EMSX_ML_STRATEGY";
        public const string EMSX_ML_TOTAL_QUANTITY = "EMSX_ML_TOTAL_QUANTITY";
        public const string EMSX_MISC_FEES = "EMSX_MISC_FEES";
        public const string EMSX_NOTES = "EMSX_NOTES";
        public const string EMSX_NSE_AVG_PRICE = "EMSX_NSE_AVG_PRICE";
        public const string EMSX_NSE_FILLED = "EMSX_NSE_FILLED";
        public const string EMSX_ODD_LOT = "EMSX_ODD_LOT";
        public const string EMSX_ORDER_ORIGIN = "EMSX_ORDER_ORIGIN";
        public const string EMSX_ORDER_REF_ID = "EMSX_ORDER_REF_ID";
        public const string EMSX_ORDER_TYPE = "EMSX_ORDER_TYPE";
        public const string EMSX_ORIGINATE_TRADER = "EMSX_ORIGINATE_TRADER";
        public const string EMSX_ORIGINATE_TRADER_FIRM = "EMSX_ORIGINATE_TRADER_FIRM";
        public const string EMSX_P_A = "EMSX_P_A";
        public const string EMSX_PERCENT_REMAIN = "EMSX_PERCENT_REMAIN";
        public const string EMSX_PM_UUID = "EMSX_PM_UUID";
        public const string EMSX_PORT_MGR = "EMSX_PORT_MGR";
        public const string EMSX_PORT_NAME = "EMSX_PORT_NAME";
        public const string EMSX_PORT_NUM = "EMSX_PORT_NUM";
        public const string EMSX_POSITION = "EMSX_POSITION";
        public const string EMSX_PRINCIPAL = "EMSX_PRINCIPAL";
        public const string EMSX_PRODUCT = "EMSX_PRODUCT";
        public const string EMSX_QUEUED_DATE = "EMSX_QUEUED_DATE";
        public const string EMSX_QUEUED_TIME = "EMSX_QUEUED_TIME";
        public const string EMSX_REASON_CODE = "EMSX_REASON_CODE";
        public const string EMSX_REASON_DESC = "EMSX_REASON_DESC";
        public const string EMSX_REMAIN_BALANCE = "EMSX_REMAIN_BALANCE";
        public const string EMSX_ROUTE_ID = "EMSX_ROUTE_ID";
        public const string EMSX_ROUTE_PRICE = "EMSX_ROUTE_PRICE";
        public const string EMSX_SEC_NAME = "EMSX_SEC_NAME";
        public const string EMSX_SEDOL = "EMSX_SEDOL";
        public const string EMSX_SEQUENCE = "EMSX_SEQUENCE";
        public const string EMSX_SETTLE_AMOUNT_LOCAL = "EMSX_SETTLE_AMOUNT_LOCAL";
        public const string EMSX_SETTLE_AMOUNT_USD = "EMSX_SETTLE_AMOUNT_USD";
        public const string EMSX_SETTLE_DATE = "EMSX_SETTLE_DATE";
        public const string EMSX_SIDE = "EMSX_SIDE";
        public const string EMSX_SOD_NET = "EMSX_SOD_NET";
        public const string EMSX_SOD_NET_DIFF = "EMSX_SOD_NET_DIFF";
        public const string EMSX_STATUS = "EMSX_STATUS";
        public const string EMSX_STOP_PRICE = "EMSX_STOP_PRICE";
        public const string EMSX_STRATEGY_END_TIME = "EMSX_STRATEGY_END_TIME";
        public const string EMSX_STRATEGY_PART_RATE1 = "EMSX_STRATEGY_PART_RATE1";
        public const string EMSX_STRATEGY_PART_RATE2 = "EMSX_STRATEGY_PART_RATE2";
        public const string EMSX_STRATEGY_PART_RATE3 = "EMSX_STRATEGY_PART_RATE3";
        public const string EMSX_STRATEGY_PART_RATE4 = "EMSX_STRATEGY_PART_RATE4";
        public const string EMSX_STRATEGY_PART_START1 = "EMSX_STRATEGY_PART_START1";
        public const string EMSX_STRATEGY_PART_START2 = "EMSX_STRATEGY_PART_START2";
        public const string EMSX_STRATEGY_PART_START3 = "EMSX_STRATEGY_PART_START3";
        public const string EMSX_STRATEGY_PART_START4 = "EMSX_STRATEGY_PART_START4";
        public const string EMSX_STRATEGY_PREMIUM = "EMSX_STRATEGY_PREMIUM";
        public const string EMSX_STRATEGY_STYLE = "EMSX_STRATEGY_STYLE";
        public const string EMSX_STRATEGY_TYPE = "EMSX_STRATEGY_TYPE";
        public const string EMSX_TICKER = "EMSX_TICKER";
        public const string EMSX_TIF = "EMSX_TIF";
        public const string EMSX_TIME_STAMP = "EMSX_TIME_STAMP";
        public const string EMSX_TOTAL_FEES = "EMSX_TOTAL_FEES";
        public const string EMSX_TRAD_UUID = "EMSX_TRAD_UUID";
        public const string EMSX_TRADER_NOTES = "EMSX_TRADER_NOTES";
        public const string EMSX_TRADER_UUID = "EMSX_TRADER_UUID";
        public const string EMSX_TRADING_DESK = "EMSX_TRADING_DESK";
        public const string EMSX_TRANSACTION_REPORTING_MIC = "EMSX_TRANSACTION_REPORTING_MIC";
        public const string EMSX_TYPE = "EMSX_TYPE";
        public const string EMSX_UNDERLYING_TICKER = "EMSX_UNDERLYING_TICKER";
        public const string EMSX_USER_COMM_AMOUNT_USD = "EMSX_USER_COMM_AMOUNT_USD";
        public const string EMSX_USER_FEES = "EMSX_USER_FEES";
        public const string EMSX_USER_NET_AMOUNT_USD = "EMSX_USER_NET_AMOUNT_USD";
        public const string EMSX_USER_RATE = "EMSX_USER_RATE";
        public const string EMSX_USER_SETTLE_CURRENCY = "EMSX_USER_SETTLE_CURRENCY";
        public const string EMSX_VWAP_MKT_VOLUME = "EMSX_VWAP_MKT_VOLUME";
        public const string EMSX_VWAP_PRICE = "EMSX_VWAP_PRICE";
        public const string EMSX_VWAP_VOLUME = "EMSX_VWAP_VOLUME";
        public const string EMSX_WORK_PRICE = "EMSX_WORK_PRICE";
        public const string EMSX_WORKING = "EMSX_WORKING";

        public const string EMSX_URGENCY_LEVEL = "EMSX_URGENCY_LEVEL";
 

        public const string EMSX_ROUTE_REF_ID = "EMSX_ROUTE_REF_ID";
      
        public const string ROUTES = "ROUTES";

        public const string STATUS = "STATUS";
        public const string MESSAGE = "MESSAGE";
       
        public const string EMSX_ORD_REF_ID = "EMSX_ORD_REF_ID";
        
        public const string EMSX_SETTLE_AMOUNT = "EMSX_SETTLE_AMOUNT";
    
        public const string EMSX_START_AMOUNT = "EMSX_START_AMOUNT";
      
        public const string EMSX_STEP_OUT_BROKER = "EMSX_STEP_OUT_BROKER";
      
        public const string EMSX_STRATEGY_START_TIME = "EMSX_STRATEGY_START_TIME";
     
        public const string EMSX_TRADE_DESK = "EMSX_TRADE_DESK";
        public const string EMSX_TRADER = "EMSX_TRADER";
     
        public const string EMSX_TS_ORDNUM = "EMSX_TS_ORDNUM";

        public const string EMSX_USER_COMM_AMOUNT = "EMSX_USER_COMM_AMOUNT";
        public const string EMSX_USER_COMM_RATE = "EMSX_USER_COMM_RATE";
      
        public const string EMSX_USER_NET_MONEY = "EMSX_USER_NET_MONEY";

        public const string EMSX_YELLOW_KEY = "EMSX_YELLOW_KEY";
   
        public const string EMSX_STRATEGY_PARAMS = "EMSX_STRATEGY_PARAMS";
      

    
        public const string EMSX_RELEASE_TIME = "EMSX_RELEASE_TIME";
        public const string EMSX_REQUEST_SEQ = "EMSX_REQUEST_SEQ";
        public const string EMSX_SETTLE_CURRENCY = "EMSX_SETTLE_CURRENCY";

        public const string EMSX_SETTLE_TYPE = "EMSX_SETTLE_TYPE";

    
        public const string EMSX_STRATEGY_NAME = "EMSX_STRATEGY_NAME";
        public const string EMSX_STRATEGY_FIELD_INDICATORS = "EMSX_STRATEGY_FIELD_INDICATORS";

        public const string EMSX_STRATEGY_FIELDS = "EMSX_STRATEGY_FIELDS";


        public const string EMSX_ROUTE_CREATE_DATE = "EMSX_ROUTE_CREATE_DATE";

        public const string EMSX_ROUTE_CREATE_TIME = "EMSX_ROUTE_CREATE_TIME";


        public const string EMSX_ROUTE_LAST_UPDATE_TIME = "EMSX_ROUTE_LAST_UPDATE_TIME";

    }
}
