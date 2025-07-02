using Bloomberglp.Blpapi;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateOrderRequest : AbstractRequest<CreateOrderResponse>
    {
        public Ticker Ticker { get; private set; }
        public int Amount { get; private set; }
        public OrderType OrderType { get; private set; }
        public TimeInForce TimeInForce { get; private set; }
        public HandlingInstruction HandInstruction { get; private set; }
        public OrderSide Side { get; private set; }
        public string? Account { get; set; }
        public string? BasketName { get; set; }
        public string? Broker { get; set; }
        public string? CfdFlag { get; set; }
        public string? ClearingAccount { get; set; }
        public string? ClearingFirm { get; set; }
        public string? CustomNote1 { get; set; }
        public string? CustomNote2 { get; set; }
        public string? CustomNote3 { get; set; }
        public string? CustomNote4 { get; set; }
        public string? CustomNote5 { get; set; }
        public string? ExchangeDestination { get; set; }
        public string? ExecInstruction { get; set; }
        public string? Warnings { get; set; }
        public DateTime? GtdDate { get; set; }
        public string? InvestorId { get; set; }
        public double? LimitPrice { get; set; }
        public string? LocateId { get; set; }
        public string? LocateRequest { get; set; }
        public string? Notes { get; set; }
        public double? OddLot { get; set; }
        public string? OrderOrigin { get; set; }
        public string? OrderRefId { get; set; }
        public double? Pa { get; set; }
        public TimeSpan? ReleaseTime { get; set; }
        public int? RequestSequence { get; set; }
        public string? SettlementCurrency { get; set; }
        public DateTime? SettlementDate { get; set; }
        public string? SettlementType { get; set; }
        public double? StopPrice { get; set; }
        public string? LocateBroker { get; set; }
        public CreateOrderRequest(EmsxOrder order) : this(order.Ticker,
            order.Amount,
            order.OrderType,
            order.TimeInForce,
            order.HandInstruction,
            order.Side)
        {
            Account = order.Account;
            BasketName = order.BasketName;
            Broker = order.Broker;
            CfdFlag = order.CfdFlag;
            ClearingAccount = order.ClearingAccount;
            ClearingFirm = order.ClearingFirm;
            CustomNote1 = order.CustomNote1;
            CustomNote2 = order.CustomNote2;
            CustomNote3 = order.CustomNote3;
            CustomNote4 = order.CustomNote4;
            CustomNote5 = order.CustomNote5;
            ExchangeDestination = order.ExchangeDestination;
            ExecInstruction = order.ExecInstruction;
            Warnings = order.Warnings;
            GtdDate = order.GtdDate;
            InvestorId = order.InvestorId;
            LimitPrice = order.LimitPrice;
            LocateId = order.LocateId;
            LocateRequest = order.LocateRequest;
            Notes = order.Notes;
            OddLot = order.OddLot;
            OrderOrigin = order.OrderOrigin;
            OrderRefId = order.OrderRefId;
            Pa = order.Pa;
            ReleaseTime = order.ReleaseTime;
            RequestSequence = order.RequestSequence;
            SettlementCurrency = order.SettlementCurrency;
            SettlementDate = order.SettlementDate;
            SettlementType = order.SettlementType;
            StopPrice = order.StopPrice;
            LocateBroker = order.LocateBroker;
        }
        public CreateOrderRequest(Ticker ticker,
          int amount,
         OrderType orderType,
         TimeInForce timeInForce,
         HandlingInstruction handInstruction,
         OrderSide side) : base("CreateOrder")
        {
            this.Ticker = ticker;
            this.Amount = amount;
            this.OrderType = orderType;
            this.TimeInForce = timeInForce;
            this.HandInstruction = handInstruction;
            this.Side = side;

        }

        protected override Request BuildRequest(Request request)
        {
            //Madatory fields
            request.Set(EMSX_TICKER, Ticker);
            request.Set(EMSX_AMOUNT, Amount);
            request.Set(EMSX_ORDER_TYPE, OrderType);
            request.Set(EMSX_TIF, TimeInForce);
            request.SetIfNotNullOrEmpty(EMSX_HAND_INSTRUCTION, HandInstruction);
            request.Set(EMSX_SIDE, Side);

            //optionals
            request.SetIfNotNullOrEmpty(EMSX_ACCOUNT, Account);

            request.SetIfNotNullOrEmpty(EMSX_BASKET_NAME, BasketName);

            request.SetIfNotNullOrEmpty(EMSX_BROKER, Broker);
            request.Set(EMSX_CFD_FLAG, CfdFlag);
            request.SetIfNotNullOrEmpty(EMSX_CLEARING_ACCOUNT, ClearingAccount);
            request.SetIfNotNullOrEmpty(EMSX_CLEARING_FIRM, ClearingFirm);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE1, CustomNote1);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE2, CustomNote2);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE3, CustomNote3);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE4, CustomNote4);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE5, CustomNote5);
            request.SetIfNotNullOrEmpty(EMSX_EXCHANGE_DESTINATION, ExchangeDestination);
            request.SetIfNotNullOrEmpty(EMSX_EXEC_INSTRUCTION, ExecInstruction);
            request.SetIfNotNullOrEmpty(EMSX_GET_WARNINGS, Warnings);
            request.SetIfNotNull(EMSX_GTD_DATE, GtdDate, "yyyyMMdd");
            request.SetIfNotNullOrEmpty(EMSX_INVESTOR_ID, InvestorId);
            request.SetIfNotNull(EMSX_LIMIT_PRICE, LimitPrice);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_BROKER, LocateBroker);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_ID, LocateId);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_REQ, LocateRequest);
            request.SetIfNotNullOrEmpty(EMSX_NOTES, Notes);
            request.SetIfNotNull(EMSX_ODD_LOT, OddLot);
            request.SetIfNotNullOrEmpty(EMSX_ORDER_ORIGIN, OrderOrigin);
            request.Set(EMSX_ORDER_REF_ID, OrderRefId);
            request.SetIfNotNull(EMSX_P_A, Pa);
            request.SetIfNotNull(EMSX_RELEASE_TIME, ReleaseTime, "hh:mm:ss");
            request.SetIfNotNull(EMSX_REQUEST_SEQ, RequestSequence);
            request.SetIfNotNullOrEmpty(EMSX_SETTLE_CURRENCY, SettlementCurrency);
            request.SetIfNotNull(EMSX_SETTLE_DATE, SettlementDate, "yyyyMMdd");
            request.SetIfNotNullOrEmpty(EMSX_SETTLE_TYPE, SettlementType);
            request.SetIfNotNull(EMSX_STOP_PRICE, StopPrice);
            return request;
        }

        public override IResponseEventHandler<CreateOrderResponse> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher)
               => new CreateOrderResponseHandler(messageEventDispatcher, this);
    }
}
