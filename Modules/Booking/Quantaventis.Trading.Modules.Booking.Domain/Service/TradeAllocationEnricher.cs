using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
namespace Quantaventis.Trading.Modules.Booking.Domain.Service
{
    internal interface ITradeAllocationEnricher
    {
        Task<EnrichedTradeAllocation> EnrichTradeAllocationAsync(EnrichedTrade enrichedTrade, RawTradeAllocation tradeAllocation);
        Task<IEnumerable<EnrichedTradeAllocation>> EnrichTradeAllocationsAsync(EnrichedTrade enrichedTrade, IEnumerable<RawTradeAllocation> tradeAllocations);
    }
    internal class TradeAllocationEnricher : ITradeAllocationEnricher
    {
        private IPortfolioRepository PortfolioRepository { get; }
        private ICounterpartyRoleSetupRepository CounterpartyRoleSetupRepository { get; }

        private ISettlementInfoRepository SettlementInfoRepository { get; }

        private IClearingAccountRepository ClearingAccountRepository { get; }

        private IFxRateRepository FxRateRepository { get; }

        private ICommissionRepository CommissionRepository { get; }
        private ILogger<TradeAllocationEnricher> Logger { get; }
        public TradeAllocationEnricher(IPortfolioRepository portfolioRepository,
            ICounterpartyRoleSetupRepository counterpartyRoleSetupRepository,
            ISettlementInfoRepository settlementInfoRepository,
            IClearingAccountRepository clearingAccountRepository,
            IFxRateRepository fxRateRepository,
            ICommissionRepository commissionRepository,
            ILogger<TradeAllocationEnricher> logger)
        {
            PortfolioRepository = portfolioRepository;
            CounterpartyRoleSetupRepository = counterpartyRoleSetupRepository;
            SettlementInfoRepository = settlementInfoRepository;
            ClearingAccountRepository = clearingAccountRepository;
            FxRateRepository = fxRateRepository;
            CommissionRepository = commissionRepository;
            Logger = logger;
        }

        internal async Task<Portfolio> GetPortfolioAsync(RawTradeAllocation tradeAllocation)
        {

            int portfolioId = tradeAllocation.PortfolioId;
            Portfolio? portfolio = await PortfolioRepository.GetByIdAsync(portfolioId);
            if (portfolio == null)
            {

                throw new InvalidOperationException($"Portfolio with Id {portfolioId} was not found");
            }
            return portfolio;
        }

        internal async Task<Commission> GetCommissionAsync(EnrichedTrade enrichedTrade, RawTradeAllocation tradeAllocation, CounterpartyRoleSetup counterpartyRoleSetup)
        {

            Commission? commission = await CommissionRepository.GetAsync(enrichedTrade.InstrumentId, enrichedTrade.ExecutionBroker, counterpartyRoleSetup.Id, enrichedTrade.ExecutionType);
            if (commission == null)
            {
                var messate = $"No commission found for Instrument:{enrichedTrade.Symbol}, ExecutionBroker:{enrichedTrade.ExecutionBroker}, CounterPartyRoleSetup:{counterpartyRoleSetup}, ExecutionType:{enrichedTrade.ExecutionType}";
                return Commission.NA();
                throw new InvalidOperationException($"No commission found for Instrument:{enrichedTrade.Symbol}, ExecutionBroker:{enrichedTrade.ExecutionBroker}, CounterPartyRoleSetup:{counterpartyRoleSetup}, ExecutionType:{enrichedTrade.ExecutionType}");
            }
            return commission;
        }
        internal async Task<TradeSettlement> GetTradeSettlementAsync(EnrichedTrade enrichedTrade, RawTradeAllocation tradeAllocation, Counterparty counterparty)
        {


            SettlementInfo settlementInfo = await GetSettlementInfoAsync(enrichedTrade, tradeAllocation, counterparty);
            DateOnly settlmentDate = settlementInfo.ComputeSettlementDate(enrichedTrade.TradeDate);
            return new TradeSettlement(settlementInfo.SettlementCurrency, settlmentDate);
        }
        internal async Task<SettlementInfo> GetSettlementInfoAsync(EnrichedTrade enrichedTrade, RawTradeAllocation tradeAllocation, Counterparty counterparty)
        {


            SettlementInfo? settlementInfo = await SettlementInfoRepository.GetByCounterpartyAndInstrumentAsync(counterparty.Id, enrichedTrade.InstrumentId, enrichedTrade.IsSwap);
            if (settlementInfo == null)
            {

                throw new InvalidOperationException($"No SettlementInfo where found for the counterparty {counterparty} and instrument:{enrichedTrade.Symbol}");
            }
            return settlementInfo.Value;
        }
        internal async Task<Account> GetClearingAccountAsync(EnrichedTrade enrichedTrade, RawTradeAllocation tradeAllocation, Portfolio portfolio, Counterparty clearingBroker)
        {

            Account? clearingAccount = await ClearingAccountRepository.GetAsync(portfolio.Id, enrichedTrade.TradeInstrumentType, clearingBroker.Id);
            if (clearingAccount == null)
            {

                throw new InvalidOperationException($"No ClearingAccount  found for Portfolio:{portfolio} TradeInstrumentType:{enrichedTrade.TradeInstrumentType}  and ClearingBroker{clearingBroker}");
            }
            return clearingAccount.Value;
        }
        internal async Task<CounterpartyRoleSetup> GetCounterpartyRoleSetupAsync(EnrichedTrade enrichedTrade, RawTradeAllocation tradeAllocation)
        {

            int portfolioId = tradeAllocation.PortfolioId;
            CounterpartyRoleSetup? counterparties = await CounterpartyRoleSetupRepository.GetAsync(portfolioId, enrichedTrade.InstrumentId, enrichedTrade.ExecutionBroker);
            if (counterparties == null)
            {

                throw new InvalidOperationException($"No CounterpartyRoleSetup found for PortfolioId:{portfolioId}, Instrument:{enrichedTrade.Symbol} and ExecutionBroker:{enrichedTrade.ExecutionBroker} was not found");
            }
            return counterparties;
        }
        internal async Task<FxRate> GetFxRateAsync(Currency baseCurrency, Currency quoteCurrency, DateTime tradeDate)
        {
            if (baseCurrency == quoteCurrency)
                return FxRate.One(baseCurrency);
            FxRate? fxRate = await FxRateRepository.GetLastAsOfDateAsync(baseCurrency, quoteCurrency, tradeDate);

            if (fxRate == null)
            {

                throw new InvalidOperationException($"FxRate for currency pair {baseCurrency}/{quoteCurrency} was not found");
            }
            return fxRate.Value;
        }


        public async Task<IEnumerable<EnrichedTradeAllocation>> EnrichTradeAllocationsAsync(EnrichedTrade enrichedTrade, IEnumerable<RawTradeAllocation> tradeAllocations)
        {
            var tasks = tradeAllocations.Select(allocation => EnrichTradeAllocationAsync(enrichedTrade, allocation));
            var results = await Task.WhenAll(tasks);
            return results;
        }
        public async Task<EnrichedTradeAllocation> EnrichTradeAllocationAsync(EnrichedTrade enrichedTrade, RawTradeAllocation tradeAllocation)
        {
            Logger.LogInformation($"Enriching TradeAllocation {tradeAllocation}");
            Portfolio portfolio = await GetPortfolioAsync(tradeAllocation);
            CounterpartyRoleSetup counterpartyRoleSetup = await GetCounterpartyRoleSetupAsync(enrichedTrade, tradeAllocation);
            TradeSettlement tradeSettlement = await GetTradeSettlementAsync(enrichedTrade, tradeAllocation, counterpartyRoleSetup.ClearingBroker);
            Account clearingAccount = await GetClearingAccountAsync(enrichedTrade, tradeAllocation, portfolio, counterpartyRoleSetup.ClearingBroker);

            DateTime tradeDate = enrichedTrade.TradeDateTime;
            FxRate localToBaseFxRate = await GetFxRateAsync(enrichedTrade.TradeCurrency, portfolio.Currency, tradeDate);
            FxRate localToSettleFxRate = await GetFxRateAsync(enrichedTrade.TradeCurrency, tradeSettlement.SettlementCurrency, tradeDate);
            Commission commission = await GetCommissionAsync(enrichedTrade, tradeAllocation, counterpartyRoleSetup);
            PositionSide positionSide = Enum.Parse<PositionSide>(tradeAllocation.PositionSide);
            Quantity allocationQuantity = tradeAllocation.Quantity.AdjustSign(enrichedTrade.TradeSide);

            return new EnrichedTradeAllocation(
                tradeAllocation.Id,
                tradeAllocation.TradeId,
                portfolio,
                positionSide,
                allocationQuantity,
                tradeAllocation.OrderAllocationQuantity,
                enrichedTrade.AvgPrice,
                enrichedTrade.ContractMultiplier,
                commission,
                localToBaseFxRate,
                localToSettleFxRate,
                tradeSettlement,
               counterpartyRoleSetup,
               clearingAccount
                );
        }
    }
}
