using Azure.Core.GeoJson;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class Portfolio
    {
        
        internal  PortfolioId PortfolioId { get; }

        internal IEnumerable<Position> Positions { get; } = Enumerable.Empty<Position>();
        internal Money TotalValue { get; }
    
        internal Currency Currency { get; }
        internal Portfolio(PortfolioId portfolioId,
            Currency currency,
            IEnumerable<Position> positions,
            Money totalValue)
        {
            PortfolioId = portfolioId;
            Currency = currency;
            Positions = positions;
            TotalValue = totalValue;
        }
        private Portfolio(PortfolioId portfolioId,Currency currency): 
            this(portfolioId, currency, Enumerable.Empty<Position>(), Money.Zero(currency))
        {
  
        }
        private Portfolio(PortfolioId portfolioId, Currency currency, Money cashBalance) :
            this(portfolioId, currency, Enumerable.Empty<Position>(), cashBalance)
        {

        }

        internal Portfolio UpdateTotalValue(Money totalValue)
             => new Portfolio(PortfolioId, Currency, Positions, totalValue);

        
        internal PortfolioValuation Valuate(ValuationContext valuationContext)
        {
            if (!valuationContext.IsValuationCurrency(Currency))
                throw new InvalidOperationException($"Portfolio {this} can't be valuated. Portfolio currency {Currency} is different than valuation currency {valuationContext.ValuationCurrency}");
           
            var netExposure = Money.Zero(Currency);
            var grossExposure = Money.Zero(Currency);
            var totalPnL = Money.Zero(Currency);
            var totalROI = Money.Zero(Currency);
            var positionValuations = ValuatePositions(valuationContext);

            foreach (PositionValuation positionValuation in positionValuations) {
                netExposure += positionValuation.NetExposure;
                grossExposure += positionValuation.GrossExposure;
                totalPnL += positionValuation.Pnl;
                totalROI += positionValuation.ROI;
            }
 

            return new PortfolioValuation(
                PortfolioId,
                TotalValue,
                netExposure,
                grossExposure,         
                totalPnL,
                totalROI,             
                DateTime.UtcNow,
                positionValuations
                );
        }


        internal IEnumerable<PositionValuation> ValuatePositions(ValuationContext valuationContext) {
           return Positions.Select(pos => pos.Valuate(valuationContext, TotalValue));
        }


    }
}
