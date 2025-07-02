using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Dto
{
    internal class MsTradeAffirmItemDto
    {
        [Name("Account")]
        public string? Account { get; set; }
        [Name("Type")]
        public string? Type { get; set; }
        [Name("Ccy1 Side")]
        public string? Ccy1Side { get; set; }
        [Name("Ccy1")]
        public string? Ccy1 { get; set; }
        [Name("Ccy1 Amt")]
        public string? Ccy1Amt { get; set; }
        [Name("Ccy2 Side")]
        public string? Ccy2Side { get; set; }
        [Name("Ccy2")]
        public string? Ccy2 { get; set; }
        [Name("Ccy2 Amt")]
        public string? Ccy2Amt { get; set; }
        [Name("Spot Rate")]
        public string? SpotRate { get; set; }
        [Name("Trade Date")]
        public string? TradeDate { get; set; }
        [Name("Value Date")]
        public string? ValueDate { get; set; }
        [Name("Entry User")]
        public string? EntryUser { get; set; }
        [Name("Deal ID")]
        public string? DealID { get; set; }
        [Name("Last Update Time")]
        public string? LastUpdateTime { get; set; }
        [Name("Deal Entry Time")]
        public string? DealEntryTime { get; set; }


        internal bool IsFutureItem => Account == "Future";
    }
}
