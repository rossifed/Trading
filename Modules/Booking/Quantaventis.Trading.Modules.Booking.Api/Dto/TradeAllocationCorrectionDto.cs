using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Api.Dto
{
    public class TradeAllocationCorrectionDto
    {


        public string? PositionSide { get; set; }

        public decimal? AvgPriceLocal { get; set; }
        public decimal? ContractMultiplier { get; set; }
        public string? CommissionType { get; set; }
        public decimal? CommissionValue { get; set; }
        public decimal? LocalToBaseFxRate { get; set; }
        public decimal? LocalToSettleFxRate { get; set; }
        public DateOnly? SettlementDate { get; set; }

        public string? SettlementCurrency { get; set; }
        public string? ClearingBroker { get; set; }
        public string? Custodian { get; set; }
        public string? PrimeBroker { get; set; }
        public string? ClearingAccount { get; set; }

    }
}
