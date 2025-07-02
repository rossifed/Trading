using Quantaventis.Trading.Modules.Valuation.Api.Events.Out;
using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Valuation.Api.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Quantaventis.Trading.Modules.Valuation.Api.Services
{
    internal interface IPortfolioValuationService {
        Task ValuatePortfolioAync(PortfolioId portfolioId);
        Task ValuateAllPortfolioAync();
    }
    internal class PortfolioValuationService : IPortfolioValuationService
    {  private IPortfolioRepository PortfolioRepository { get; }
        private IFxRateRepository FxRateRepository { get; }
        private IInstrumentPricingRepository InstrumentPricingRepository { get; }
        private IPortfolioValuationRepository PortfolioValuationRepository { get; }
        private IMessageBroker MessageBroker { get; }

        public PortfolioValuationService(
            IPortfolioRepository portfolioRepository, 
            IPortfolioValuationRepository portfolioValuationRepository, 
            IFxRateRepository fxRateRepository,
            IInstrumentPricingRepository instrumentPricingRepository,
            IMessageBroker messageBroker)
        {
            PortfolioRepository = portfolioRepository;
            PortfolioValuationRepository = portfolioValuationRepository;
            FxRateRepository= fxRateRepository;
            InstrumentPricingRepository = instrumentPricingRepository;
            MessageBroker = messageBroker;
        }

        public async Task ValuatePortfolioAync(PortfolioId portfolioId) {
          var portfolio = await  PortfolioRepository.GetByIdAsync(portfolioId);
            if (portfolio == null)
                throw new InvalidOperationException($"The portfolio with id {portfolioId} was not found");

            await ValuatePortfolioAync(portfolio);

        }
        public async Task ValuatePortfolioAync(Portfolio portfolio)
        {
          
            IEnumerable<Position> positions = portfolio.Positions;
            IEnumerable<InstrumentId> instrumentIds = positions.Select(x => x.Instrument.Id);
            IEnumerable<FxRate> fxRates = await FxRateRepository.GetByQuoteCurrencyAsync(portfolio.Currency);
            IEnumerable<InstrumentPricing> instrumentPricings = await InstrumentPricingRepository.GetByInstrumentIdsAsync(instrumentIds);
            ValuationContext valuationContext = new ValuationContext(portfolio.Currency, fxRates, instrumentPricings);
            PortfolioValuation portfolioValuation = portfolio.Valuate(valuationContext);
            var portfolioValuationId = await PortfolioValuationRepository.AddAsync(portfolioValuation);
            await MessageBroker.PublishAsync(new PortfolioValuated(portfolioValuation.Map(portfolioValuationId)));

        }
        public async Task ValuateAllPortfolioAync()
        {
            IEnumerable<Portfolio> portfolios = await PortfolioRepository.GetAllAsync();
            foreach (Portfolio portfolio in portfolios) {
                await ValuatePortfolioAync(portfolio);
            }
        }
    }
}
