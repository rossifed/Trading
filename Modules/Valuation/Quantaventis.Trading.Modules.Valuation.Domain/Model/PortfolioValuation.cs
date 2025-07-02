using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class PortfolioValuation
    {
       internal PortfolioId PortfolioId { get; }
        internal Money TotalValue { get; }
        internal Money GrossExposure { get; }

        internal Money NetExposure { get; }

        internal Money PnL { get; }
        internal Money ROI { get; }
        internal Currency Currency => TotalValue.Currency;
        internal DateTime ValuationDate { get; }
        internal IEnumerable<PositionValuation> PositionValuations { get; }


        internal PortfolioValuation(
            PortfolioId portfolioId,
            Money totalValue,
            Money netExposure,
            Money grossExposure,
            Money pnL,
            Money roi,
            DateTime valuationDate,
            IEnumerable<PositionValuation> positionValuations
            )
        {
            PortfolioId = portfolioId;
            GrossExposure = grossExposure;
            TotalValue= totalValue;
            NetExposure = netExposure;    
            PnL= pnL;
            ROI = roi;
            PositionValuations = positionValuations;  
            ValuationDate = valuationDate;
        }
    }
}
