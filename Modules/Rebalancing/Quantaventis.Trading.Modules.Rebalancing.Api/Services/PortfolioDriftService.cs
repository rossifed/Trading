using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Services
{
    internal interface IPortfolioDriftService
    {
        Task OnPortfolioValuated(PortfolioValuation portfolio);
        Task OnTargetAllocationValuated(TargetAllocationValuation targetAllocation);
    }
    internal class PortfolioDriftService : IPortfolioDriftService
    {
        private IPortfolioValuationRepository PortfolioValuationRepository { get; }

        private ITargetAllocationValuationRepository TargetAllocationValuationRepository { get; }
        private IPortfolioDriftRepository PortfolioDriftRepository { get; }
        private ILogger<IPortfolioDriftService> Logger { get; }

        private IMessageBroker MessageBroker { get; }
        public PortfolioDriftService(
            IPortfolioDriftRepository portfolioDriftRepository,
            IPortfolioValuationRepository portfolioValuationRepository,
            ITargetAllocationValuationRepository targetAllocationValuationRepository,
            ILogger<IPortfolioDriftService> logger,
            IMessageBroker messageBroker)
        {
            PortfolioDriftRepository = portfolioDriftRepository;
            PortfolioValuationRepository = portfolioValuationRepository;
            TargetAllocationValuationRepository = targetAllocationValuationRepository;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task OnPortfolioValuated(PortfolioValuation portfolioValuation)
        {
            var portfolioId = portfolioValuation.PortfolioId;
            await PortfolioValuationRepository.UpdateAsync(portfolioValuation);
            TargetAllocationValuation? targetAllocationValuation = await TargetAllocationValuationRepository.GetLastByPortfolioIdAsync(portfolioId);
            if (targetAllocationValuation is null)
            {
                string message = $"Portfolio drift can't be compted, no Target Allocation Valuation was found for portfolio {portfolioId}";
                Logger.LogWarning(message);
            }
            else
            {
                var porftolioDrift = PortfolioDrift.New(portfolioValuation, targetAllocationValuation);
                await PortfolioDriftRepository.AddAsync(porftolioDrift);
            }
        }

        public async Task OnTargetAllocationValuated(TargetAllocationValuation targetAllocationValuation)
        {
            var portfolioId = targetAllocationValuation.PortfolioId;
            await TargetAllocationValuationRepository.UpdateAsync(targetAllocationValuation);
            PortfolioValuation? portfolioValuation = await PortfolioValuationRepository.GetLastByPortfolioIdAsync(portfolioId);
            if (portfolioValuation is null)
            {
                string message = $"Portfolio drift can't be compted, no Portfolio  Valuation was found for portfolio {portfolioId}";
                Logger.LogWarning(message);
            }
            else
            {
                var porftolioDrift = PortfolioDrift.New(portfolioValuation, targetAllocationValuation);
                await PortfolioDriftRepository.AddAsync(porftolioDrift);
            }

        }

    }
}
