using Quantaventis.Trading.Modules.Orders.Api.Clients;
using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Domain.Services;

using Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Services
{
    internal interface IOrderEnrichmentService {
        Task<IEnumerable<Order>> EnrichOrdersAsync(IEnumerable<BaseOrder> individualOrders);
    }
    internal class OrderEnrichmentService : IOrderEnrichmentService
    {
        private IEFRPModuleClient EFRPModuleClient { get; }
        private IBrokerSelectionRuleRepository BrokerSelectionRuleRepository { get; }
        private IBrokerSelectionRuleOverrideRepository BrokerSelectionRuleOverrideRepository { get; }
        private ITradeModeSelectionRuleRepository TradeModeSelectionRuleRepository { get; }

        private IExecutionProfileSelectionRuleRepository ExecutionProfileSelectionRuleRepository { get; }

        private IExecutionProfileSelectionRuleOverrideRepository ExecutionProfileSelectionRuleOverrideRepository { get; }
        private IAccountSelectionRuleRepository AccountSelectionRuleRepository { get; }

        public OrderEnrichmentService(
            IEFRPModuleClient eFRPModuleClient,
            IBrokerSelectionRuleRepository brokerSelectionRuleRepository,
            IBrokerSelectionRuleOverrideRepository brokerSelectionRuleOverrideRepository,
            ITradeModeSelectionRuleRepository tradeModeSelectionRuleRepository,
            IExecutionProfileSelectionRuleRepository executionProfileSelectionRuleRepository,
            IExecutionProfileSelectionRuleOverrideRepository executionProfileSelectionRuleOverrideRepository,
            IAccountSelectionRuleRepository accountSelectionRuleRepository)
        {
            EFRPModuleClient= eFRPModuleClient;
            BrokerSelectionRuleRepository = brokerSelectionRuleRepository;
            BrokerSelectionRuleOverrideRepository = brokerSelectionRuleOverrideRepository;
            ExecutionProfileSelectionRuleOverrideRepository = executionProfileSelectionRuleOverrideRepository;
            TradeModeSelectionRuleRepository = tradeModeSelectionRuleRepository;
            ExecutionProfileSelectionRuleRepository = executionProfileSelectionRuleRepository;
            AccountSelectionRuleRepository = accountSelectionRuleRepository;
        }
        private async Task<IEnumerable<EfrpSelectionRule>> GetEfrpSelectionRulesAsync(IEnumerable<BaseOrder> baseOrders, IEnumerable<BrokerSelectionRule> brokerSelectionRules)
        {
           return await GetEfrpSelectionRulesAsync(baseOrders, brokerSelectionRules.Select(x => x.Broker).Distinct());
        }
        private async Task<IEnumerable<EfrpSelectionRule>> GetEfrpSelectionRulesAsync(IEnumerable<BaseOrder> baseOrders, IEnumerable<Broker> brokers) {
           IEnumerable<int> futureContractIds = baseOrders.Where(x=>x.InstrumentType.IsFuture).Select(x=>x.Instrument.Id);
            IEnumerable<EfrpCandidateDto> efrpCandidateDtos = futureContractIds.SelectMany(n => brokers, (n, l) => new EfrpCandidateDto{ InstrumentId = n, BrokerId = l.Id }).ToList();
            IEnumerable <EfrpConversionInfoDto> efrpConversionInfos = await EFRPModuleClient.GetEfrpConversionInfoAsync(efrpCandidateDtos);
            return efrpConversionInfos.Select(x => new EfrpSelectionRule(x.BrokerId, x.InstrumentId,  x.IsEfrp)).Distinct();
        }
        public async Task<IEnumerable<Order>> EnrichOrdersAsync(IEnumerable<BaseOrder> baseOrders)
        {

           
            IEnumerable<BrokerSelectionRule> brokerSelectionRules = await BrokerSelectionRuleRepository.GetAllAsync();
            IEnumerable<BrokerSelectionRuleOverride> brokerSelectionRuleOverrides = await BrokerSelectionRuleOverrideRepository.GetAllAsync();
            IEnumerable<ExecutionProfileSelectionRule> executionProfileSelectionRules = await ExecutionProfileSelectionRuleRepository.GetAllAsync();
            IEnumerable<ExecutionProfileSelectionRuleOverride> executionProfileSelectionRuleOverrides = await ExecutionProfileSelectionRuleOverrideRepository.GetAllAsync();

            IEnumerable<TradingAccountSelectionRule> accountSelectionRules = await AccountSelectionRuleRepository.GetAllAsync();
            IEnumerable<TradeModeSelectionRule> tradeModeSelectionRules = await TradeModeSelectionRuleRepository.GetAllAsync();
            IEnumerable<EfrpSelectionRule> efrpSelectionRules = await GetEfrpSelectionRulesAsync(baseOrders, brokerSelectionRules);
                OrderEnricher orderEnricher = CreateOrderEnricher(brokerSelectionRules,
                    brokerSelectionRuleOverrides,
                executionProfileSelectionRules,
                executionProfileSelectionRuleOverrides,
                accountSelectionRules,
                tradeModeSelectionRules,
                efrpSelectionRules
                );

            return orderEnricher.Enrich(baseOrders);
        }
  
        private OrderEnricher CreateOrderEnricher(IEnumerable<BrokerSelectionRule> brokerSelectionRules,
            IEnumerable<BrokerSelectionRuleOverride> brokerSelectionRuleOverrides,
        IEnumerable<ExecutionProfileSelectionRule> executionProfileSelectionRules,
        IEnumerable<ExecutionProfileSelectionRuleOverride> executionProfileSelectionRuleOverrides,
        IEnumerable<TradingAccountSelectionRule> accountSelectionRules,
        IEnumerable<TradeModeSelectionRule> tradeModeSelectionRules,
        IEnumerable<EfrpSelectionRule> efrpSelectionRules) {
            BrokerSelector brokerSelector = new BrokerSelector(brokerSelectionRules, brokerSelectionRuleOverrides);
            ExecutionProfileSelector executionProfileSelector = new ExecutionProfileSelector(executionProfileSelectionRules, executionProfileSelectionRuleOverrides);

            TradingAccountSelector accountSelector = new TradingAccountSelector(accountSelectionRules);
            TradeModeSelector routingMethodSelector = new TradeModeSelector(tradeModeSelectionRules);
            EfrpDetector efrpDetector = new EfrpDetector(efrpSelectionRules);
            return new OrderEnricher(brokerSelector,
                routingMethodSelector,
                executionProfileSelector,
                accountSelector,
                efrpDetector);
        }
    }
}
