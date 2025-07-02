using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Api.Dto
{
    public class RouteOrderRequestDto
    {

        public int Sequence { get; set; }
        public int Amount { get; set; }
        public string Broker { get; set; }
        public string HandInstruction { get; set; }
        public string OrderType { get; set; }
        public string Ticker { get; set; }
        public string TimeInForce { get; set; }


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

    }
}
