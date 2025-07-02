using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses.Parsers;
using static Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.EmsxElements;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests
{
    internal class ModifyOrderRequest : AbstracRequest<ModifyOrderResponse>
    {

        internal int Sequence { get; }
        internal int Amount { get; }
        internal string OrderType { get; }
        internal double? LimitPrice { get; set; }

        internal string? TimeInForce { get; set; }

        internal string? HandInstruction { get; set; }
        internal string? Account { get; set; }
        internal string? CfdFlag { get; set; }

        internal string? ExecInstruction { get; set; }
        internal DateTime? GtdDate { get; set; }
        internal string? InvestorId { get; set; }
        internal string? Notes { get; set; }
        internal string? Warnings { get; set; }
        internal int? RequestSequence { get; set; }

        internal double? StopPrice { get; set; }
        internal int? TraderUuid { get; set; }

        public ModifyOrderRequest(int Sequence,
        int Amount,
        string OrderType) : base("ModifyOrderEx")
        {
            this.Sequence = Sequence;
            this.Amount = Amount;
            this.OrderType = OrderType;

        }

        protected override Request BuildRequest(Request request)
        {
            request.Set(EMSX_SEQUENCE, Sequence);//must be specified in case of order modification
            request.Set(EMSX_AMOUNT, Amount);
            request.Set(EMSX_ORDER_TYPE, OrderType);
            // Note: When changing order type to a LMT order, you will need to provide the EMSX_LIMIT_PRICE value.
            //       When changing order type away from LMT order, you will need to reset the EMSX_LIMIT_PRICE value
            //       by setting the content to -99999

            if (OrderType == "LMT")
            {
                if (LimitPrice == null || LimitPrice <= 0)
                    throw new Exception("Limit Price is mandatory for LMT orders");
                request.Set(EMSX_LIMIT_PRICE, LimitPrice.Value);//Must be specified if ordertype = limit

            }
            else
            {
                request.Set(EMSX_LIMIT_PRICE, -99999);
            }

            request.Set(EMSX_TIF, TimeInForce);

            // The fields below are optional
            request.SetIfNotNullOrEmpty(EMSX_HAND_INSTRUCTION, HandInstruction);
            request.SetIfNotNullOrEmpty(EMSX_ACCOUNT, Account);
            request.SetIfNotNullOrEmpty(EMSX_CFD_FLAG, CfdFlag);
            request.SetIfNotNullOrEmpty(EMSX_EXEC_INSTRUCTION, ExecInstruction);
            request.SetIfNotNullOrEmpty(EMSX_GET_WARNINGS, Warnings);
            request.SetIfNotNull(EMSX_GTD_DATE, GtdDate, "yyyMMdd");
            request.SetIfNotNullOrEmpty(EMSX_INVESTOR_ID, InvestorId);
            request.SetIfNotNull(EMSX_LIMIT_PRICE, LimitPrice);
            request.SetIfNotNullOrEmpty(EMSX_NOTES, Notes);
            request.SetIfNotNull(EMSX_REQUEST_SEQ, RequestSequence);
            if (StopPrice == null || StopPrice <= 0)
                request.Set(EMSX_STOP_PRICE, -1);
            else
                request.SetIfNotNull(EMSX_STOP_PRICE, StopPrice);
            // If modifying on behalf of another trader, set the order owner's UUID
            request.SetIfNotNull(EMSX_TRADER_UUID, TraderUuid);

            // Note: To clear down the stop price, set the content to -1

            //request.Set("EMSX_TRADER_UUID", 1234567);
            return request;
        }
        public override IResponseHandler CreateResponseHandler(TaskCompletionSource<ModifyOrderResponse> taskCompletionSource)
        {
            return new ResponseHandler<ModifyOrderRequest, ModifyOrderResponse>(
                "ModifyOrderEx",
                RequestId,
                new ModifyOrderResponseParser(),
                taskCompletionSource);
        }
    }
}
