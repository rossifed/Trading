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
using NetTopologySuite.GeometriesGraph;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Valuation.Api.Events.Handlers;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace Quantaventis.Trading.Modules.Valuation.Api.Services
{
    internal interface ITargetAllocationValuationService
    {
        Task ValuateTargetAllocationAsync(PortfolioId portfolioId);

        Task ValuateAllTargetAllocationsAsync();
    }
    internal class TargetAllocationValuationService : ITargetAllocationValuationService
    {
        private IPortfolioRepository PortfolioRepository { get; }
        private IFxRateRepository FxRateRepository { get; }
        private IInstrumentPricingRepository InstrumentPricingRepository { get; }
        private ITargetAllocationValuationRepository TargetAllocationValuationRepository { get; }
        private IMessageBroker MessageBroker { get; }
        private ITargetAllocationRepository TargetAllocationRepository { get; }
        private ILogger<TargetAllocationValuationService> Logger { get; }
        public TargetAllocationValuationService(
            IPortfolioRepository portfolioRepository,
            ITargetAllocationRepository targetAllocationRepository,
            ITargetAllocationValuationRepository targetAllocationValuationRepository,
            IFxRateRepository fxRateRepository,
            IInstrumentPricingRepository instrumentPricingRepository,
          ILogger<TargetAllocationValuationService> logger,
        IMessageBroker messageBroker)
        {
            PortfolioRepository = portfolioRepository;
            TargetAllocationRepository = targetAllocationRepository;
            TargetAllocationValuationRepository = targetAllocationValuationRepository;
            FxRateRepository = fxRateRepository;
            InstrumentPricingRepository = instrumentPricingRepository;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task ValuateTargetAllocationAsync(PortfolioId portfolioId)
        { 
            TargetAllocation? targetAllocation = await TargetAllocationRepository.GetLastByPortfolioIdAsync(portfolioId);
            if (targetAllocation == null)
            {
                Logger.LogWarning($"No target allocation has been found for portfolio id {portfolioId}");
            }
            else
            {
                await ValuateTargetAllocationAsync(targetAllocation);
            }

        }

        public async Task ValuateTargetAllocationAsync(TargetAllocation targetAllocation)
        {
            var portfolioValue = await PortfolioRepository.GetPortfolioValueAsync(targetAllocation.PortfolioId);
            ValuationContext valuationContext = await GetValuationContextAsync(targetAllocation, portfolioValue);
            TargetAllocationValuation targetAllocationValuation = targetAllocation.Valuate(valuationContext, portfolioValue);
            var valuationId = await TargetAllocationValuationRepository.AddAsync(targetAllocationValuation);
            await MessageBroker.PublishAsync(new TargetAllocationValuated(targetAllocationValuation.Map(valuationId)));
        }

        private async Task<ValuationContext> GetValuationContextAsync(TargetAllocation targetAllocation, Money portfolioValue)
        {
            IEnumerable<InstrumentId> instrumentIds = targetAllocation.TargetWeights.Select(x => x.Instrument.Id);

            IEnumerable<FxRate> fxRates = await FxRateRepository.GetByQuoteCurrencyAsync(portfolioValue.Currency);
            Validate<FxRate>(fxRates, targetAllocation);
            IEnumerable<InstrumentPricing> instrumentPricings = await InstrumentPricingRepository.GetByInstrumentIdsAsync(instrumentIds);
            Validate<InstrumentPricing>(instrumentPricings, targetAllocation);
            return new ValuationContext(portfolioValue.Currency, fxRates, instrumentPricings);
        }
        private void Validate<T>(IEnumerable<T> items, TargetAllocation targetAllocation)
        {
            if (items.IsNullOrEmpty())
                throw new InvalidOperationException($"Target Allocation {targetAllocation} can't be valuated. {typeof(T).Name} are missing.");
        }
        public async Task ValuateAllTargetAllocationsAsync()
        {
            IEnumerable<TargetAllocation> targetAllocations = await TargetAllocationRepository.GetAllAsync();
            foreach (TargetAllocation targetAllocation in targetAllocations)
            {
                await ValuateTargetAllocationAsync(targetAllocation);
            }
        }
    }

}
