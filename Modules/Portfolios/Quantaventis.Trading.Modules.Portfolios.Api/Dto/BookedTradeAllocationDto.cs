using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Dto
{
    public class BookedTradeAllocationDto
    {
   
        public int TradeAllocationId { get; set; }

        public int TradeId { get; set; }

        public string TradeStatus { get; set; } 

        public byte PortfolioId { get; set; }

        public string PositionSide { get; set; } 

        public int Quantity { get; set; }
        public int OrderAllocationQuantity { get; set; }
        public decimal ContractMultiplier { get; set; }

        public decimal NominalQuantity { get; set; }

        public string LocalCurrency { get; set; } 

        public string BaseCurrency { get; set; } 

        public string SettlementCurrency { get; set; } 

        public decimal CommissionValue { get; set; }

        public string CommissionType { get; set; } 

        public decimal GrossAvgPriceLocal { get; set; }

        public decimal PriceCommissionLocal { get; set; }

        public decimal NetAvgPriceLocal { get; set; }

        public decimal GrossAvgPriceBase { get; set; }

        public decimal PriceCommissionBase { get; set; }

        public decimal NetAvgPriceBase { get; set; }

        public decimal GrossAvgPriceSettle { get; set; }

        public decimal PriceCommissionSettle { get; set; }

        public decimal NetAvgPriceSettle { get; set; }

        public decimal CommissionAmountLocal { get; set; }

        public decimal CommissionAmountBase { get; set; }

        public decimal CommissionAmountSettle { get; set; }

        public decimal GrossTradeValueLocal { get; set; }

        public decimal NetTradeValueLocal { get; set; }

        public decimal GrossTradeValueBase { get; set; }

        public decimal NetTradeValueBase { get; set; }

        public decimal GrossTradeValueSettle { get; set; }

        public decimal NetTradeValueSettle { get; set; }

        public decimal GrossPrincipalLocal { get; set; }

        public decimal NetPrincipalLocal { get; set; }

        public decimal GrossPrincipalBase { get; set; }

        public decimal NetPrincipalBase { get; set; }

        public decimal GrossPrincipalSettle { get; set; }

        public decimal NetPrincipalSettle { get; set; }

        public DateTime SettlementDate { get; set; }

        public decimal LocalToBaseFxRate { get; set; }

        public decimal LocalToSettleFxRate { get; set; }

        public string? PrimeBroker { get; set; }

        public string ClearingBroker { get; set; } 

        public string ClearingAccount { get; set; } 

        public string? Custodian { get; set; }
        public decimal MiscFeesAmountLocal { get; set; }

        public decimal MiscFeesAmountSettle { get; set; }

        public decimal MiscFeesAmountBase { get; set; }
        public DateTime? LastCorrectedOnUtc { get; set; }

        public DateTime? CanceledOnUtc { get; set; }

    }
}
