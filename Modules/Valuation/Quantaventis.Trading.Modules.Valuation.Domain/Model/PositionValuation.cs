using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class PositionValuation
    {
        internal Money NetExposure { get; }
        internal Money GrossExposure { get; }
        internal Money ROI { get; }

        internal Money Pnl { get; }


        internal Money InstrumentValue { get; }


        internal InstrumentId InstrumentId => Instrument.Id;

        internal Quantity Quantity => Position.Quantity;
        internal DateTime ValuationDate{ get; }
        internal InstrumentPricing InstrumentPricing { get; }
        internal Currency ValuationCurrency { get; }
        internal DateTime PriceDate => InstrumentPricing.PricedOn;
        internal FxRate FxRate { get; }
        internal Money Price => InstrumentPricing.Price;
        internal DateTime PricedOn => InstrumentPricing.PricedOn;

        internal Weight Weight { get; }

        internal Position Position { get; }
        internal Instrument Instrument => Position.Instrument;
        public PositionValuation(Position position,
            InstrumentPricing instrumentPricing,
            Money instrumentValue,
            FxRate fxRate,
            Weight weight,
            Money netExposure,
            Money grossExposure,
            Money pnl,
            Money roi)
        {

            Position = position;

            InstrumentValue = instrumentValue;
            InstrumentPricing = instrumentPricing;
            FxRate = fxRate;
            Weight = weight;
            NetExposure = netExposure;
            GrossExposure = grossExposure;
            ROI = roi;
            Pnl = pnl;
            ValuationCurrency = instrumentValue.Currency;
        }


    }
}
