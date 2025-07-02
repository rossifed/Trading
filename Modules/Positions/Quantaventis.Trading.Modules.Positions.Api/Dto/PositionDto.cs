using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Api.Dto
{
    public class PositionDto
    {
        public byte PortfolioId { get; set;}
        public int Quantity { get; set;}
        public decimal NominalQuantity { get; set;}
        public int InstrumentId { get; set;}
        public string LocalCurrency { get; set;}
        public string BaseCurrency { get; set;}
        public decimal GrossEntryPriceLocal { get; set;}
        public decimal GrossEntryPriceBase { get; set;}

        public decimal NetEntryPriceLocal { get; set;}
        public decimal NetEntryPriceBase { get; set;}
        public decimal GrossTradeValueLocal { get; set;}
        public decimal GrossTradeValueBase { get; set;}
        public decimal NetTradeValueLocal { get; set;}
        public decimal NetTradeValueBase { get; set;}


        public decimal GrossNotionalValueLocal { get; set;}
        public decimal GrossNotionalValueBase { get; set;}
        public decimal NetNotionalValueLocal { get; set;}
        public decimal NetNotionalValueBase { get; set;}

        public decimal TotalCommissionLocal { get; set;}

        public decimal TotalCommissionBase { get; set;}


        public bool IsSwap { get; set;}

        public DateOnly PositionDate { get; set;}
        public DateOnly FirstTradeDate { get; set;}

        public DateOnly LastTradeDate { get; set;}
    }
}
