using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class ModifyOrderRequest : AbstractRequest<ModifyOrderResponse>
    {
        private EmsxOrder Order { get; }
        public ModifyOrderRequest(EmsxOrder order) : base("ModifyOrderEx")
        {
            this.Order = order;

        }

        protected override Request BuildRequest(Request request)
        {
            request.Set(EMSX_SEQUENCE, Order.Sequence);//must be specified in case of order modification
            request.Set(EMSX_AMOUNT, Order.Amount);
            request.Set(EMSX_ORDER_TYPE, Order.OrderType);
            // Note: When changing order type to a LMT order, you will need to provide the EMSX_LIMIT_PRICE value.
            //       When changing order type away from LMT order, you will need to reset the EMSX_LIMIT_PRICE value
            //       by setting the content to -99999

            if (Order.OrderType == OrderType.Limit)
            {
                request.Set(EMSX_LIMIT_PRICE, Order.LimitPrice.Value);//Must be specified if ordertype = limit
            }
            else
            {
                request.Set(EMSX_LIMIT_PRICE, -99999);
            }

            request.Set(EMSX_TIF, Order.TimeInForce);

            // The fields below are optional
            request.SetIfNotNullOrEmpty(EMSX_HAND_INSTRUCTION, Order.HandInstruction);
            request.SetIfNotNullOrEmpty(EMSX_ACCOUNT, Order.Account);
            request.SetIfNotNullOrEmpty(EMSX_CFD_FLAG, Order.CfdFlag);
            request.SetIfNotNullOrEmpty(EMSX_EXEC_INSTRUCTION, Order.ExecInstruction);
            request.SetIfNotNullOrEmpty(EMSX_GET_WARNINGS, Order.Warnings);
            request.SetIfNotNull(EMSX_GTD_DATE, Order.GtdDate, "yyyMMdd");
            request.SetIfNotNullOrEmpty(EMSX_INVESTOR_ID, Order.InvestorId);
            request.SetIfNotNull(EMSX_LIMIT_PRICE, Order.LimitPrice);
            request.SetIfNotNullOrEmpty(EMSX_NOTES, Order.Notes);
            request.SetIfNotNull(EMSX_REQUEST_SEQ, Order.RequestSequence);
            if (Order.StopPrice == null || Order.StopPrice <= 0)
                request.Set(EMSX_STOP_PRICE, -1);
            else
                request.SetIfNotNull(EMSX_STOP_PRICE, Order.StopPrice);
            request.SetIfNotNull(EMSX_TRADER_UUID, Order.TraderUuid);

            // Note: To clear down the stop price, set the content to -1

            //request.Set("EMSX_TRADER_UUID", 1234567);
            return request;
        }

        public override IResponseEventHandler<ModifyOrderResponse> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher)
                => new ModifyOrderResponseHandler(messageEventDispatcher, this);
    }
}
