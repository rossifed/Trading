using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Api.Dto
{
    public class BookedTradeDto
    {
        public int TradeId { get; set; }

        public string TradeStatus { get; set; }

        public int InstrumentId { get; set; }

        public string Symbol { get; set; }

        public string TradeSide { get; set; }

        public int TradeQuantity { get; set; }

        public decimal NominalQuantity { get; set; }

        public string TradeCurrency { get; set; }

        public DateTime TradeDate { get; set; }

        public string Exchange { get; set; }

        public string ExecutionChannel { get; set; }

        public string ExecutionType { get; set; }

        public bool IsSwap { get; set; }

        public int? RebalancingId { get; set; }

        public decimal ContractMultiplier { get; set; }

        public decimal AvgPrice { get; set; }

        public decimal Principal { get; set; }

        public decimal TradeValue { get; set; }
        public string InstrumentType { get; set; }
        public string TradeInstrumentType { get; set; }

        public string ExecutionDesk { get; set; }

        public string ExecutionBroker { get; set; }

        public string ExecutionAccount { get; set; }

        public string? Isin { get; set; }

        public string? Sedol { get; set; }

        public string? Cusip { get; set; }

        public string? SecurityName { get; set; }

        public string? LocalExchangeSymbol { get; set; }

        public DateTime? SettlementDate { get; set; }

        public int? EmsxOrderId { get; set; }

        public int? OrderReferenceId { get; set; }

        public int? OrderQuantity { get; set; }

        public string? OrderType { get; set; }

        public string? StrategyType { get; set; }

        public string? TimeInForce { get; set; }

        public string? OrderExecutionInstruction { get; set; }

        public string? OrderHandlingInstruction { get; set; }

        public string? OrderInstruction { get; set; }

        public decimal? LimitPrice { get; set; }

        public decimal? StopPrice { get; set; }

        public int? OriginatingTraderUuid { get; set; }

        public string? TraderName { get; set; }

        public int? TraderUuid { get; set; }

        public decimal? UserCommissionAmount { get; set; }

        public decimal? UserCommissionRate { get; set; }

        public decimal? UserFees { get; set; }

        public decimal? UserNetMoney { get; set; }

        public string? YellowKey { get; set; }

        public byte? NumberOfFills { get; set; }

        public DateTime? FirstFillTimeUtc { get; set; }

        public DateTime? LastFillTimeUtc { get; set; }

        public decimal? MaxFillPrice { get; set; }

        public decimal? MinFillPrice { get; set; }

        public DateTime BookedOnUtc { get; set; }

        public DateTime? LastCorrectedOnUtc { get; set; }

        public DateTime? CanceledOnUtc { get; set; }
        public decimal PriceScalingFactor { get; set; }
        public IEnumerable<BookedTradeAllocationDto> TradeAllocations { get; set; }
    }
}
