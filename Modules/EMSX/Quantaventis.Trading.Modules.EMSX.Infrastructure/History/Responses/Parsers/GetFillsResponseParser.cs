using Bloomberglp.Blpapi;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Parsers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses.Parsers
{
    internal class GetFillsResponseParser : IMessageParser<GetFillsResponse>
    {
        public GetFillsResponse Parse(Message msg)
        {
            Element fillsElement = msg.GetElement("Fills");


            List<EmsxFillDto> fills = new List<EmsxFillDto>();
            for (int i = 0; i < fillsElement.NumValues; i++)
            {

                Element fill = fillsElement.GetValueAsElement(i);
                EmsxFillDto emsxFill = Parse(fill);
                fills.Add(emsxFill);

            }
            return new GetFillsResponse(fills);
        }

        private EmsxFillDto Parse(Element fill)
        {
            return new EmsxFillDto()
            {
                Account = fill.GetElementAsString("Account").NullIfEmpty(),
                Amount = fill.GetElementAsFloat64("Amount"),
                AssetClass = fill.GetElementAsString("AssetClass").NullIfEmpty(),
                BasketId = fill.GetElementAsInt32("BasketId").NullIfZero(),
                Bbgid = fill.GetElementAsString("BBGID").NullIfEmpty(),
                BlockId = fill.GetElementAsString("BlockId").NullIfEmpty(),
                Broker = fill.GetElementAsString("Broker").NullIfEmpty(),
                ClearingAccount = fill.GetElementAsString("ClearingAccount").NullIfEmpty(),
                ClearingFirm = fill.GetElementAsString("ClearingFirm").NullIfEmpty(),
                ContractExpDate = fill.GetElementAsDate("ContractExpDate").ToSystemDateTime(),
                CorrectedFillId = fill.GetElementAsInt32("CorrectedFillId").NullIfZero(),
                Currency = fill.GetElementAsString("Currency").NullIfEmpty(),
                Cusip = fill.GetElementAsString("Cusip").NullIfEmpty(),
                DateTimeOfFillUtc = fill.GetAsDateTimeUtc("DateTimeOfFill"),
                Exchange = fill.GetElementAsString("Exchange").NullIfEmpty(),
                ExecPrevSeqNo = fill.GetElementAsInt32("ExecPrevSeqNo").NullIfZero(),
                ExecType = fill.GetElementAsString("ExecType").NullIfEmpty(),
                ExecutingBroker = fill.GetElementAsString("ExecutingBroker").NullIfEmpty(),
                FillId = fill.GetElementAsInt32("FillId"),
                FillPrice = fill.GetElementAsFloat64("FillPrice"),
                FillShares = fill.GetElementAsFloat64("FillShares"),
                InvestorId = fill.GetElementAsString("InvestorID").NullIfEmpty(),
                IsCFD = fill.GetElementAsBool("IsCfd"),
                Isin = fill.GetElementAsString("Isin").NullIfEmpty(),
                IsLeg = fill.GetElementAsBool("IsLeg"),
                LastCapacity = fill.GetElementAsString("LastCapacity").NullIfEmpty(),
                LastMarket = fill.GetElementAsString("LastMarket").NullIfEmpty(),
                LimitPrice = fill.GetElementAsFloat64("LimitPrice").NullIfZero(),
                Liquidity = fill.GetElementAsString("Liquidity").NullIfEmpty(),
                LocalExchangeSymbol = fill.GetElementAsString("LocalExchangeSymbol").NullIfEmpty(),
                LocateBroker = fill.GetElementAsString("LocateBroker").NullIfEmpty(),
                LocateId = fill.GetElementAsString("LocateId").NullIfEmpty(),
                LocateRequired = fill.GetElementAsBool("LocateRequired"),
                MultiLegId = fill.GetElementAsString("MultilegId").NullIfEmpty(),
                OccSymbol = fill.GetElementAsString("OCCSymbol").NullIfEmpty(),
                OrderExecutionInstruction = fill.GetElementAsString("OrderExecutionInstruction").NullIfEmpty(),
                OrderHandlingInstruction = fill.GetElementAsString("OrderHandlingInstruction").NullIfEmpty(),
                OrderId = fill.GetElementAsInt32("OrderId"),
                OrderInstruction = fill.GetElementAsString("OrderInstruction").NullIfEmpty(),
                OrderOrigin = fill.GetElementAsString("OrderOrigin").NullIfEmpty(),
                OrderReferenceId = fill.GetElementAsString("OrderReferenceId").NullIfEmpty(),
                OriginatingTraderUUId = fill.GetElementAsInt32("OriginatingTraderUuid").NullIfZero(),
                ReroutedBroker = fill.GetElementAsString("ReroutedBroker").NullIfEmpty(),
                RouteCommissionAmount = fill.GetElementAsFloat64("RouteCommissionAmount"),
                RouteCommissionRate = fill.GetElementAsFloat64("RouteCommissionRate"),
                RouteExecutionInstruction = fill.GetElementAsString("RouteExecutionInstruction").NullIfEmpty(),
                RouteHandlingInstruction = fill.GetElementAsString("RouteHandlingInstruction").NullIfEmpty(),
                RouteId = fill.GetElementAsInt32("RouteId"),
                RouteNetMoney = fill.GetElementAsFloat64("RouteNetMoney"),
                RouteNotes = fill.GetElementAsString("RouteNotes").NullIfEmpty(),
                RouteShares = fill.GetElementAsFloat64("RouteShares"),
                SecurityName = fill.GetElementAsString("SecurityName").NullIfEmpty(),
                Sedol = fill.GetElementAsString("Sedol").NullIfEmpty(),
                SettlementDate = fill.HasElement("SettlementDate") ? fill.GetElementAsDate("SettlementDate").ToSystemDateTime() : null,
                Side = fill.GetElementAsString("Side").NullIfEmpty(),
                StopPrice = fill.GetElementAsFloat64("StopPrice").NullIfZero(),
                StrategyType = fill.GetElementAsString("StrategyType").NullIfEmpty(),
                Ticker = fill.GetElementAsString("Ticker").NullIfEmpty(),
                Tif = fill.GetElementAsString("TIF").NullIfEmpty(),
                TraderName = fill.GetElementAsString("TraderName").NullIfEmpty(),
                TraderUUId = fill.GetElementAsInt32("TraderUuid"),
                Type = fill.GetElementAsString("Type").NullIfEmpty(),
                UserCommissionAmount = fill.GetElementAsFloat64("UserCommissionAmount"),
                UserCommissionRate = fill.GetElementAsFloat64("UserCommissionRate"),
                UserFees = fill.GetElementAsFloat64("UserFees"),
                UserNetMoney = fill.GetElementAsFloat64("UserNetMoney"),
                YellowKey = fill.GetElementAsString("YellowKey").NullIfEmpty(),
            };
        }
    }
}
