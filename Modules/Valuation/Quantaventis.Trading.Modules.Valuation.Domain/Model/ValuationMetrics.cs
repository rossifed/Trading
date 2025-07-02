using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class ValuationMetrics
    {
        internal Money NetExposure { get; }
        internal Money GrossExposure { get; }
        internal Money ROI { get; }

        internal Money Pnl { get; }

        public ValuationMetrics(
            Money netExposure, 
            Money grossExposure, 
            Money rOI, 
            Money pnl)
        {
            NetExposure = netExposure;
            GrossExposure = grossExposure;
            ROI = rOI;
            Pnl = pnl;
        }
    }
}
