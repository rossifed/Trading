using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class RouteOrderRequest : AbstracRequest<RouteOrderResponse>
    {

        public int Sequence { get; }
        public int Amount { get; }
        public string Broker { get; }
        public string HandInstruction { get; }
        public string OrderType { get; }
        public string Ticker { get; }
        public string TimeInForce { get; }

        public RouteOrderRequest(int sequence,
            int amount,
            string broker,
            string handInstruction,
            string orderType,
            string ticker,
            string timeInForce) : base("RouteEx")
        {
            Sequence = sequence;
            Amount = amount;
            Broker = broker;
            HandInstruction = handInstruction;
            OrderType = orderType;
            Ticker = ticker;
            TimeInForce = timeInForce;
        }
        public RouteOrderRequest(EmsxOrderDto emsxOrder) : this(
                emsxOrder.Sequence,
                emsxOrder.Amount,
                emsxOrder.Broker,
                emsxOrder.HandInstruction,
                emsxOrder.OrderType,
                emsxOrder.Ticker,
                emsxOrder.TimeInForce

            )
        {
            Account = emsxOrder.Account;
            CfdFlag = emsxOrder.CfdFlag;
            ClearingAccount = emsxOrder.ClearingAccount;
            ClearingFirm = emsxOrder.ClearingFirm;
            ExecInstruction = emsxOrder.ExecInstruction;
            Warnings = emsxOrder.Warnings;
            GtdDate = emsxOrder.GtdDate;
            LimitPrice = emsxOrder.LimitPrice;
            LocateId = emsxOrder.LocateId;
            LocateRequest = emsxOrder.LocateRequest;
            Notes = emsxOrder.Notes;
            OddLot = emsxOrder.OddLot;
            Pa = emsxOrder.Pa;
            ReleaseTime = emsxOrder.ReleaseTime;
            RequestSequence = emsxOrder.RequestSequence;
            RouteRefId = emsxOrder.RouteRefId;
            StopPrice = emsxOrder.StopPrice;
            TraderUuid = emsxOrder.TraderUuid;
            Strategy = emsxOrder.Strategy;
            StrategyParameters = emsxOrder.StrategyParameters;
            LocateBroker = emsxOrder.LocateBroker;
        }
        public string? Account { get; set; }
        public string? CfdFlag { get; set; }
        public string? ClearingAccount { get; set; }
        public string? ClearingFirm { get; set; }
        public string? ExecInstruction { get; set; }
        public string? Warnings { get; set; }
        public DateTime? GtdDate { get; set; }
        public double? LimitPrice { get; set; }
        public string? LocateId { get; set; }
        public string? LocateRequest { get; set; }
        public string? Notes { get; set; }
        public int? OddLot { get; set; }
        public int? Pa { get; set; }
        public TimeSpan? ReleaseTime { get; set; }
        public int? RequestSequence { get; set; }
        public string? RouteRefId { get; set; }
        public double? StopPrice { get; set; }
        public int? TraderUuid { get; set; }
        public string? Strategy { get; set; }
        public string? LocateBroker { get; set; }
        public string[] StrategyParameters { get; set; } = new string[] { };

        protected override Request BuildRequest(Request request)
        {
            //madatory 
            request.Set(EMSX_SEQUENCE, Sequence);
            request.Set(EMSX_AMOUNT, Amount);
            request.Set(EMSX_BROKER, Broker);
            request.Set(EMSX_HAND_INSTRUCTION, HandInstruction);
            request.Set(EMSX_ORDER_TYPE, OrderType);
            request.Set(EMSX_TICKER, Ticker);
            request.Set(EMSX_TIF, TimeInForce);

            //Optional Fields  
            request.SetIfNotNullOrEmpty(EMSX_ACCOUNT, Account);
            request.SetIfNotNullOrEmpty(EMSX_CFD_FLAG, CfdFlag == "Y" ? "1" : "0");
            request.SetIfNotNullOrEmpty(EMSX_CLEARING_ACCOUNT, ClearingAccount);
            request.SetIfNotNullOrEmpty(EMSX_CLEARING_FIRM, ClearingFirm);
            request.SetIfNotNullOrEmpty(EMSX_EXEC_INSTRUCTION, ExecInstruction);
            request.SetIfNotNullOrEmpty(EMSX_GET_WARNINGS, Warnings);
            request.SetIfNotNull(EMSX_GTD_DATE, GtdDate, "yyyyMMdd");
            request.SetIfNotNull(EMSX_LIMIT_PRICE, LimitPrice);

            request.SetIfNotNullOrEmpty(EMSX_LOCATE_BROKER, LocateBroker);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_ID, LocateId);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_REQ, LocateRequest);
            request.SetIfNotNullOrEmpty(EMSX_NOTES, Notes);
            request.SetIfNotNull(EMSX_ODD_LOT, OddLot);
            request.SetIfNotNull(EMSX_P_A, Pa);
            request.SetIfNotNull(EMSX_RELEASE_TIME, ReleaseTime, "hh:mm:ss");
            request.SetIfNotNull(EMSX_REQUEST_SEQ, RequestSequence);
            request.SetIfNotNullOrEmpty(EMSX_ROUTE_REF_ID, RouteRefId);
            request.SetIfNotNull(EMSX_STOP_PRICE, StopPrice);
            request.SetIfNotNull(EMSX_TRADER_UUID, TraderUuid);

            SetStrategyElement(request);
            return request;
        }

        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<RouteOrderResponse> taskCompletionSource)
        {
            return new ResponseHandler<RouteOrderRequest, RouteOrderResponse>(
                "Route",//Exception in the emsx api where request type is different than response type received in the message
                RequestId,
                new RouteOrderResponseParser(),
                taskCompletionSource);
        }
        private void SetStrategyElement(Request request)
        {
            if (!string.IsNullOrEmpty(Strategy))
            {
                Element strategy = request.GetElement(EMSX_STRATEGY_PARAMS);
                strategy.SetElement(EMSX_STRATEGY_NAME, Strategy);
                Element indicators = strategy.GetElement(EMSX_STRATEGY_FIELD_INDICATORS);
                Element fields = strategy.GetElement(EMSX_STRATEGY_FIELDS);
                foreach (string parameter in StrategyParameters)
                {
                    if (string.IsNullOrEmpty(parameter))
                    {
                        fields.AppendElement().SetElement(EMSX_FIELD_DATA, "");
                        indicators.AppendElement().SetElement(EMSX_FIELD_INDICATOR, 1);
                    }
                    else
                    {
                        fields.AppendElement().SetElement(EMSX_FIELD_DATA, parameter);
                        indicators.AppendElement().SetElement(EMSX_FIELD_INDICATOR, 0);
                    }
                }
            }
        }


    }
}
