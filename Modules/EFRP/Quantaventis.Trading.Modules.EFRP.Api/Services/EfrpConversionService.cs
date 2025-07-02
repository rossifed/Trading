using Quantaventis.Trading.Modules.EFRP.Api.Events.Out;
using Quantaventis.Trading.Modules.EFRP.Api.Mappers;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;
using Quantaventis.Trading.Modules.EFRP.Domain.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.EFRP.Api.Services
{
    internal interface IEfrpConversionService {
        Task ConvertEfrpOrdersAsync(IEnumerable<Order> orders);

        Task<IEnumerable<EfrpConversionInfo>> GetEfrpConversionInfosAsync(IEnumerable<IEfrpCandidate> efrpCandidates);
    }
    internal class EfrpConversionService :IEfrpConversionService
    {



        private IEfrpConversionRuleRepository EfrpConversionRuleRepository { get; }
        private IFutureContractRepository FutureContractRepository { get; }
        private IIMMDateRepository IMMDateRepository { get; }
        private IMessageBroker MessageBroker { get; }

        private IEfrpOrderRepository EfrpOrderRepository { get; }
        public EfrpConversionService(
            IEfrpConversionRuleRepository efrpConversionRuleRepository,
            IFutureContractRepository futureContractRepository,
            IIMMDateRepository iMMDateRepository,
            IEfrpOrderRepository efrpOrderRepository,
            IMessageBroker messageBroker
            )
        {
            this.EfrpConversionRuleRepository = efrpConversionRuleRepository;
            this.FutureContractRepository = futureContractRepository;
            this.IMMDateRepository = iMMDateRepository;
            this.MessageBroker = messageBroker;
            this.EfrpOrderRepository = efrpOrderRepository;
        }
  

        public async Task ConvertEfrpOrdersAsync(IEnumerable<Order> orders)
        {
            IEfrpConversionInfoProvider efrpConversionInfoProvider = await CreateEfrpConversionInfoProviderAsync(orders);
            List<EfrpOrder> efrpOrders = new List<EfrpOrder>();
      
            foreach (Order order in orders) {
               EfrpConversionInfo efrpConversionInfo =  efrpConversionInfoProvider.GetEfrpConversionInfo(order);
                EfrpOrder? efrpOrder ;
                if (efrpConversionInfo.TryConvertToEfrpOrder(order, out efrpOrder)) {
                    if(efrpOrder != null)
                    efrpOrders.Add(efrpOrder);
                }
            }
            var dtos = efrpOrders.Map();
            await MessageBroker.PublishAsync(new EfrpOrdersConverted(dtos));
        }


  
        public async Task<IEnumerable<EfrpConversionInfo>> GetEfrpConversionInfosAsync(IEnumerable<IEfrpCandidate> efrpCandidates)
        {
            var distinctEfrpCandidates = efrpCandidates
               .GroupBy(c => new { c.InstrumentId, c.BrokerId })
               .Select(g => g.First())
               .ToList();
            EfrpConversionInfoProvider efrpConversionInfoProvider = await CreateEfrpConversionInfoProviderAsync(distinctEfrpCandidates);
            return efrpConversionInfoProvider.GetEfrpConversionInfos(distinctEfrpCandidates);

        }

        private async Task<EfrpConversionInfoProvider> CreateEfrpConversionInfoProviderAsync(IEnumerable<IEfrpCandidate> orders)
        {
            IEfrpConversionRuleSelector efrpSelectionRuleSelector = await CreateEfrpConversionRuleSelectorAsync();
            IFutureContractLookup futureContractLookup = await CreateFutureContractLookupAsync(orders);
            IIMMDateProvider iMMDateProvider = await CreateImmDateProviderAsync();
            return new EfrpConversionInfoProvider(
                efrpSelectionRuleSelector,
                futureContractLookup,
                iMMDateProvider);


        }
        private async Task<IEfrpConversionRuleSelector> CreateEfrpConversionRuleSelectorAsync() {
            var conversionRules = await EfrpConversionRuleRepository.GetAllAsync();
            return new EfrpConversionRuleSelector(conversionRules);
        }
        private async Task<IFutureContractLookup> CreateFutureContractLookupAsync(IEnumerable<IEfrpCandidate> orders)
        {
            var futureContracts = await FutureContractRepository.GetByIdsAsync(
              orders.Select(o => o.InstrumentId).ToList()
          );
            return new FutureContractLookup(futureContracts);
        }
        private async Task<IIMMDateProvider> CreateImmDateProviderAsync()
        {
            var immDates = await IMMDateRepository.GetAllAsync();
            return new IMMDateProvider(immDates);
        }
    }
}
