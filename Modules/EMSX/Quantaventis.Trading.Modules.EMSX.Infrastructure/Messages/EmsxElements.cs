using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages
{
    internal static class EmsxElements
    {
        public static Name ERROR_CODE = new Name("ERROR_CODE");
        public static Name ERROR_MESSAGE = new Name("ERROR_MESSAGE");
        public static Name API_SEQ_NUM = new("API_SEQ_NUM");
        public static Name EMSX_ACCOUNT = new("EMSX_ACCOUNT");
        public static Name EMSX_ALL_SUCCESS = new("EMSX_ALL_SUCCESS");
        public static Name EMSX_AMOUNT = new("EMSX_AMOUNT");
        public static Name EMSX_ARRIVAL_PRICE = new("EMSX_ARRIVAL_PRICE");
        public static Name EMSX_ASSET_CLASS = new("EMSX_ASSET_CLASS");
        public static Name EMSX_ASSIGNED_TRADER = new("EMSX_ASSIGNED_TRADER");
        public static Name EMSX_ASSIGNEE_TRADER_UUID = new("EMSX_ASSIGNEE_TRADER_UUID");
        public static Name EMSX_ASSIGN_TRADER_FAILED_ORDERS = new("EMSX_ASSIGN_TRADER_FAILED_ORDERS");
        public static Name EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS = new("EMSX_ASSIGN_TRADER_SUCCESSFUL_ORDERS");
        public static Name EMSX_AVG_PRICE = new("EMSX_AVG_PRICE");
        public static Name EMSX_BASKET_NAME = new("EMSX_BASKET_NAME");
        public static Name EMSX_BASKET_NUM = new("EMSX_BASKET_NUM");
        public static Name EMSX_BOOKNAME = new("EMSX_BOOKNAME");
        public static Name EMSX_BROKER = new("EMSX_BROKER");
        public static Name EMSX_BROKER_COMM = new("EMSX_BROKER_COMM");
        public static Name EMSX_BSE_AVG_PRICE = new("EMSX_BSE_AVG_PRICE");
        public static Name EMSX_BSE_FILLED = new("EMSX_BSE_FILLED");
        public static Name EMSX_CFD_FLAG = new("EMSX_CFD_FLAG");
        public static Name EMSX_CLEARING_ACCOUNT = new("EMSX_CLEARING_ACCOUNT");
        public static Name EMSX_CLEARING_FIRM = new("EMSX_CLEARING_FIRM");
        public static Name EMSX_COMM_DIFF_FLAG = new("EMSX_COMM_DIFF_FLAG");
        public static Name EMSX_COMM_RATE = new("EMSX_COMM_RATE");
        public static Name EMSX_CURRENCY_PAIR = new("EMSX_CURRENCY_PAIR");
        public static Name EMSX_CUSTOM_ACCOUNT = new("EMSX_CUSTOM_ACCOUNT");
        public static Name EMSX_CUSTOM_NOTE1 = new("EMSX_CUSTOM_NOTE1");
        public static Name EMSX_CUSTOM_NOTE2 = new("EMSX_CUSTOM_NOTE2");
        public static Name EMSX_CUSTOM_NOTE3 = new("EMSX_CUSTOM_NOTE3");
        public static Name EMSX_CUSTOM_NOTE4 = new("EMSX_CUSTOM_NOTE4");
        public static Name EMSX_CUSTOM_NOTE5 = new("EMSX_CUSTOM_NOTE5");
        public static Name EMSX_DATE = new("EMSX_DATE");
        public static Name EMSX_DAY_AVG_PRICE = new("EMSX_DAY_AVG_PRICE");
        public static Name EMSX_DAY_FILL = new("EMSX_DAY_FILL");
        public static Name EMSX_DIR_BROKER_FLAG = new("EMSX_DIR_BROKER_FLAG");
        public static Name EMSX_EXECUTE_BROKER = new("EMSX_EXECUTE_BROKER");
        public static Name EMSX_EXCHANGE = new("EMSX_EXCHANGE");
        public static Name EMSX_EXCHANGE_DESTINATION = new("EMSX_EXCHANGE_DESTINATION");
        public static Name EMSX_EXEC_INSTRUCTION = new("EMSX_EXEC_INSTRUCTION");
        public static Name EMSX_FIELD_DATA = new("EMSX_FIELD_DATA");
        public static Name EMSX_FIELD_INDICATOR = new("EMSX_FIELD_INDICATOR");
        public static Name EMSX_FILL_ID = new("EMSX_FILL_ID");
        public static Name EMSX_FILLED = new("EMSX_FILLED");
        public static Name EMSX_GET_WARNINGS = new("EMSX_GET_WARNINGS");
        public static Name EMSX_GTD_DATE = new("EMSX_GTD_DATE");
        public static Name EMSX_HAND_INSTRUCTION = new("EMSX_HAND_INSTRUCTION");
        public static Name EMSX_IDLE_AMOUNT = new("EMSX_IDLE_AMOUNT");
        public static Name EMSX_INVESTOR_ID = new("EMSX_INVESTOR_ID");
        public static Name EMSX_ISIN = new("EMSX_ISIN");
        public static Name EMSX_IS_MANUAL_ROUTE = new("EMSX_IS_MANUAL_ROUTE");
        public static Name EMSX_LAST_FILL_DATE = new("EMSX_LAST_FILL_DATE");
        public static Name EMSX_LAST_FILL_TIME = new("EMSX_LAST_FILL_TIME");
        public static Name EMSX_LAST_MARKET = new("EMSX_LAST_MARKET");
        public static Name EMSX_LAST_PRICE = new("EMSX_LAST_PRICE");
        public static Name EMSX_LAST_SHARES = new("EMSX_LAST_SHARES");
        public static Name EMSX_LIMIT_PRICE = new("EMSX_LIMIT_PRICE");
        public static Name EMSX_LOCATE_BROKER = new("EMSX_LOCATE_BROKER");
        public static Name EMSX_LOCATE_ID = new("EMSX_LOCATE_ID");
        public static Name EMSX_LOCATE_REQ = new("EMSX_LOCATE_REQ");
        public static Name EMSX_ML_LEG_QUANTITY = new("EMSX_ML_LEG_QUANTITY");
        public static Name EMSX_ML_NUM_LEGS = new("EMSX_ML_NUM_LEGS");
        public static Name EMSX_ML_PERCENT_FILLED = new("EMSX_ML_PERCENT_FILLED");
        public static Name EMSX_ML_RATIO = new("EMSX_ML_RATIO");
        public static Name EMSX_ML_REMAIN_BALANCE = new("EMSX_ML_REMAIN_BALANCE");
        public static Name EMSX_ML_STRATEGY = new("EMSX_ML_STRATEGY");
        public static Name EMSX_ML_TOTAL_QUANTITY = new("EMSX_ML_TOTAL_QUANTITY");
        public static Name EMSX_MISC_FEES = new("EMSX_MISC_FEES");
        public static Name EMSX_NOTES = new("EMSX_NOTES");
        public static Name EMSX_NSE_AVG_PRICE = new("EMSX_NSE_AVG_PRICE");
        public static Name EMSX_NSE_FILLED = new("EMSX_NSE_FILLED");
        public static Name EMSX_ODD_LOT = new("EMSX_ODD_LOT");
        public static Name EMSX_ORDER_ORIGIN = new("EMSX_ORDER_ORIGIN");
        public static Name EMSX_ORDER_REF_ID = new("EMSX_ORDER_REF_ID");
        public static Name EMSX_ORDER_TYPE = new("EMSX_ORDER_TYPE");
        public static Name EMSX_ORIGINATE_TRADER = new("EMSX_ORIGINATE_TRADER");
        public static Name EMSX_ORIGINATE_TRADER_FIRM = new("EMSX_ORIGINATE_TRADER_FIRM");
        public static Name EMSX_P_A = new("EMSX_P_A");
        public static Name EMSX_PERCENT_REMAIN = new("EMSX_PERCENT_REMAIN");
        public static Name EMSX_PM_UUID = new("EMSX_PM_UUID");
        public static Name EMSX_PORT_MGR = new("EMSX_PORT_MGR");
        public static Name EMSX_PORT_NAME = new("EMSX_PORT_NAME");
        public static Name EMSX_PORT_NUM = new("EMSX_PORT_NUM");
        public static Name EMSX_POSITION = new("EMSX_POSITION");
        public static Name EMSX_PRINCIPAL = new("EMSX_PRINCIPAL");
        public static Name EMSX_PRODUCT = new("EMSX_PRODUCT");
        public static Name EMSX_QUEUED_DATE = new("EMSX_QUEUED_DATE");
        public static Name EMSX_QUEUED_TIME = new("EMSX_QUEUED_TIME");
        public static Name EMSX_REASON_CODE = new("EMSX_REASON_CODE");
        public static Name EMSX_REASON_DESC = new("EMSX_REASON_DESC");
        public static Name EMSX_REMAIN_BALANCE = new("EMSX_REMAIN_BALANCE");
        public static Name EMSX_ROUTE_ID = new("EMSX_ROUTE_ID");
        public static Name EMSX_ROUTE_PRICE = new("EMSX_ROUTE_PRICE");
        public static Name EMSX_SEC_NAME = new("EMSX_SEC_NAME");
        public static Name EMSX_SEDOL = new("EMSX_SEDOL");
        public static Name EMSX_SEQUENCE = new("EMSX_SEQUENCE");
        public static Name EMSX_SETTLE_AMOUNT_LOCAL = new("EMSX_SETTLE_AMOUNT_LOCAL");
        public static Name EMSX_SETTLE_AMOUNT_USD = new("EMSX_SETTLE_AMOUNT_USD");
        public static Name EMSX_SETTLE_DATE = new("EMSX_SETTLE_DATE");
        public static Name EMSX_SIDE = new("EMSX_SIDE");
        public static Name EMSX_SOD_NET = new("EMSX_SOD_NET");
        public static Name EMSX_SOD_NET_DIFF = new("EMSX_SOD_NET_DIFF");
        public static Name EMSX_STATUS = new("EMSX_STATUS");
        public static Name EMSX_STOP_PRICE = new("EMSX_STOP_PRICE");
        public static Name EMSX_STRATEGY_END_TIME = new("EMSX_STRATEGY_END_TIME");
        public static Name EMSX_STRATEGY_PART_RATE1 = new("EMSX_STRATEGY_PART_RATE1");
        public static Name EMSX_STRATEGY_PART_RATE2 = new("EMSX_STRATEGY_PART_RATE2");
        public static Name EMSX_STRATEGY_PART_RATE3 = new("EMSX_STRATEGY_PART_RATE3");
        public static Name EMSX_STRATEGY_PART_RATE4 = new("EMSX_STRATEGY_PART_RATE4");
        public static Name EMSX_STRATEGY_PART_START1 = new("EMSX_STRATEGY_PART_START1");
        public static Name EMSX_STRATEGY_PART_START2 = new("EMSX_STRATEGY_PART_START2");
        public static Name EMSX_STRATEGY_PART_START3 = new("EMSX_STRATEGY_PART_START3");
        public static Name EMSX_STRATEGY_PART_START4 = new("EMSX_STRATEGY_PART_START4");
        public static Name EMSX_STRATEGY_PREMIUM = new("EMSX_STRATEGY_PREMIUM");
        public static Name EMSX_STRATEGY_STYLE = new("EMSX_STRATEGY_STYLE");
        public static Name EMSX_STRATEGY_TYPE = new("EMSX_STRATEGY_TYPE");
        public static Name EMSX_TICKER = new("EMSX_TICKER");
        public static Name EMSX_TIF = new("EMSX_TIF");
        public static Name EMSX_TIME_STAMP = new("EMSX_TIME_STAMP");
        public static Name EMSX_TOTAL_FEES = new("EMSX_TOTAL_FEES");
        public static Name EMSX_TRAD_UUID = new("EMSX_TRAD_UUID");
        public static Name EMSX_TRADER_NOTES = new("EMSX_TRADER_NOTES");
        public static Name EMSX_TRADER_UUID = new("EMSX_TRADER_UUID");
        public static Name EMSX_TRADING_DESK = new("EMSX_TRADING_DESK");
        public static Name EMSX_TRANSACTION_REPORTING_MIC = new("EMSX_TRANSACTION_REPORTING_MIC");
        public static Name EMSX_TYPE = new("EMSX_TYPE");
        public static Name EMSX_UNDERLYING_TICKER = new("EMSX_UNDERLYING_TICKER");
        public static Name EMSX_USER_COMM_AMOUNT_USD = new("EMSX_USER_COMM_AMOUNT_USD");
        public static Name EMSX_USER_FEES = new("EMSX_USER_FEES");
        public static Name EMSX_USER_NET_AMOUNT_USD = new("EMSX_USER_NET_AMOUNT_USD");
        public static Name EMSX_USER_RATE = new("EMSX_USER_RATE");
        public static Name EMSX_USER_SETTLE_CURRENCY = new("EMSX_USER_SETTLE_CURRENCY");
        public static Name EMSX_VWAP_MKT_VOLUME = new("EMSX_VWAP_MKT_VOLUME");
        public static Name EMSX_VWAP_PRICE = new("EMSX_VWAP_PRICE");
        public static Name EMSX_VWAP_VOLUME = new("EMSX_VWAP_VOLUME");
        public static Name EMSX_WORK_PRICE = new("EMSX_WORK_PRICE");
        public static Name EMSX_WORKING = new("EMSX_WORKING");

        public static Name EMSX_URGENCY_LEVEL = new("EMSX_URGENCY_LEVEL");


        public static Name EMSX_ROUTE_REF_ID = new("EMSX_ROUTE_REF_ID");

        public static Name ROUTES = new("ROUTES");

        public static Name STATUS = new("STATUS");
        public static Name MESSAGE = new("MESSAGE");

        public static Name EMSX_ORD_REF_ID = new("EMSX_ORD_REF_ID");

        public static Name EMSX_SETTLE_AMOUNT = new("EMSX_SETTLE_AMOUNT");

        public static Name EMSX_START_AMOUNT = new("EMSX_START_AMOUNT");

        public static Name EMSX_STEP_OUT_BROKER = new("EMSX_STEP_OUT_BROKER");

        public static Name EMSX_STRATEGY_START_TIME = new("EMSX_STRATEGY_START_TIME");

        public static Name EMSX_TRADE_DESK = new("EMSX_TRADE_DESK");
        public static Name EMSX_TRADER = new("EMSX_TRADER");

        public static Name EMSX_TS_ORDNUM = new("EMSX_TS_ORDNUM");

        public static Name EMSX_USER_COMM_AMOUNT = new("EMSX_USER_COMM_AMOUNT");
        public static Name EMSX_USER_COMM_RATE = new("EMSX_USER_COMM_RATE");

        public static Name EMSX_USER_NET_MONEY = new("EMSX_USER_NET_MONEY");

        public static Name EMSX_YELLOW_KEY = new("EMSX_YELLOW_KEY");

        public static Name EMSX_STRATEGY_PARAMS = new("EMSX_STRATEGY_PARAMS");



        public static Name EMSX_RELEASE_TIME = new("EMSX_RELEASE_TIME");
        public static Name EMSX_REQUEST_SEQ = new("EMSX_REQUEST_SEQ");
        public static Name EMSX_SETTLE_CURRENCY = new("EMSX_SETTLE_CURRENCY");

        public static Name EMSX_SETTLE_TYPE = new("EMSX_SETTLE_TYPE");


        public static Name EMSX_STRATEGY_NAME = new("EMSX_STRATEGY_NAME");
        public static Name EMSX_STRATEGY_FIELD_INDICATORS = new("EMSX_STRATEGY_FIELD_INDICATORS");

        public static Name EMSX_STRATEGY_FIELDS = new("EMSX_STRATEGY_FIELDS");


        public static Name EMSX_ROUTE_CREATE_DATE = new("EMSX_ROUTE_CREATE_DATE");

        public static Name EMSX_ROUTE_CREATE_TIME = new("EMSX_ROUTE_CREATE_TIME");


        public static Name EMSX_ROUTE_LAST_UPDATE_TIME = new("EMSX_ROUTE_LAST_UPDATE_TIME");

    }
}
