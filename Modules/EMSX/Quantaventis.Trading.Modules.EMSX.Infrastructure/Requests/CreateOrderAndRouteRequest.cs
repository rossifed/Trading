using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class CreateOrderAndRouteRequest : AbstracRequest<CreateOrderAndRouteResponse>
    {

        private EmsxOrderDto Order { get; }
        public CreateOrderAndRouteRequest(EmsxOrderDto order) : base("CreateOrderAndRoute")
        {
            Order = order;

        }
        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<CreateOrderAndRouteResponse> taskCompletionSource)
        {
            return new ResponseHandler<CreateOrderAndRouteRequest, CreateOrderAndRouteResponse>(
                "CreateOrderAndRoute",
                RequestId,
                new CreateOrderAndRouteResponseParser(),
                taskCompletionSource);
        }

        protected override Request BuildRequest(Request request)
        {

            request.Set(EMSX_TICKER, Order.Ticker);
            request.Set(EMSX_AMOUNT, Order.Amount);
            request.Set(EMSX_ORDER_TYPE, Order.OrderType);
            request.Set(EMSX_ORDER_REF_ID, Order.OrderRefId);
            request.Set(EMSX_TIF, Order.TimeInForce);
            request.SetIfNotNullOrEmpty(EMSX_HAND_INSTRUCTION, Order.HandInstruction);
            request.Set(EMSX_SIDE, Order.Side);
            request.SetIfNotNullOrEmpty(EMSX_ACCOUNT, Order.Account);

            request.SetIfNotNullOrEmpty(EMSX_BASKET_NAME, Order.BasketName);

            request.SetIfNotNullOrEmpty(EMSX_BROKER, Order.Broker);
            request.Set(EMSX_CFD_FLAG, Order.CfdFlag);
            request.SetIfNotNullOrEmpty(EMSX_CLEARING_ACCOUNT, Order.ClearingAccount);
            request.SetIfNotNullOrEmpty(EMSX_CLEARING_FIRM, Order.ClearingFirm);
            request.SetIfNotNullOrEmpty(EMSX_EXCHANGE_DESTINATION, Order.ExchangeDestination);
            request.SetIfNotNullOrEmpty(EMSX_EXEC_INSTRUCTION, Order.ExecInstruction);
            request.SetIfNotNullOrEmpty(EMSX_GET_WARNINGS, Order.Warnings);
            request.SetIfNotNull(EMSX_GTD_DATE, Order.GtdDate, "yyyyMMdd");
            request.SetIfNotNullOrEmpty(EMSX_INVESTOR_ID, Order.InvestorId);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE1, Order.CustomNote1);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE2, Order.CustomNote2);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE3, Order.CustomNote3);
            request.SetIfNotNullOrEmpty(EMSX_CUSTOM_NOTE4, Order.CustomNote4);
            request.SetIfNotNull(EMSX_LIMIT_PRICE, Order.LimitPrice);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_BROKER, Order.Broker);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_ID, Order.LocateId);
            request.SetIfNotNullOrEmpty(EMSX_LOCATE_REQ, Order.LocateRequest);
            request.SetIfNotNullOrEmpty(EMSX_NOTES, Order.Notes);
            request.SetIfNotNull(EMSX_SETTLE_DATE, Order.SettlementDate, "yyyyMMdd");
            request.SetIfNotNullOrEmpty(EMSX_SETTLE_TYPE, Order.SettlementType);
            request.SetIfNotNull(EMSX_STOP_PRICE, Order.StopPrice);
            request.SetIfNotNullOrEmpty(EMSX_SETTLE_CURRENCY, Order.SettlementCurrency);
            request.SetIfNotNull(EMSX_ODD_LOT, Order.OddLot);
            request.SetIfNotNull(EMSX_RELEASE_TIME, Order.ReleaseTime, "hh:mm:ss");
            request.SetIfNotNull(EMSX_REQUEST_SEQ, Order.RequestSequence);
            SetStrategyElement(request);

            return request;
        }
        private void SetStrategyElement(Request request)
        {
            Element strategy = request.GetElement(EMSX_STRATEGY_PARAMS);
            strategy.SetElement(EMSX_STRATEGY_NAME, Order.Strategy);
            Element indicators = strategy.GetElement(EMSX_STRATEGY_FIELD_INDICATORS);
            Element fields = strategy.GetElement(EMSX_STRATEGY_FIELDS);
            foreach (string parameter in Order.StrategyParameters)
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
