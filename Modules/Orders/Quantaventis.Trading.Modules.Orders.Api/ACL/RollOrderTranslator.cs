using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;

namespace Quantaventis.Trading.Modules.Orders.Api.ACL
{
    internal interface IRollOrderTranslator : ICollectionTranslator<PositionRolloverDto, BaseOrder> { }
    internal class RollOrderTranslator : IRollOrderTranslator
    {

        private IPortfolioRepository PortfolioRepository { get; }
        private IInstrumentRepository InstrumentRepository { get; }

        public RollOrderTranslator(IPortfolioRepository portfolioRepository, IInstrumentRepository instrumentRepository)
        {
            PortfolioRepository = portfolioRepository;
            InstrumentRepository = instrumentRepository;
        }

        public async Task<IEnumerable<BaseOrder>> TranslateAsync(IEnumerable<PositionRolloverDto> rollovers)
        {
            // Extract distinct Portfolio and Instrument IDs
            var portfolioIds = rollovers.Select(o => o.PortfolioId).Distinct().ToList();
            var exprigingContracts = rollovers.Select(o => o.ExpiringContractId).Distinct().ToList();
            var nextContracts = rollovers.Select(o => o.NextContractId).Distinct().ToList();
            var instrumentIds = exprigingContracts.Union(nextContracts);
            // Fetch in bulk
            var portfolios = await PortfolioRepository.GetAllAsync();
            var instruments = await InstrumentRepository.GetByIdsAsync(instrumentIds);

            var translatedOrders = new List<BaseOrder>();
            BaseOrder Create(int portfolioId, int instrumentId, int quantity, int targetPositionQuantity, DateOnly rollDate)
            {
                var portfolio = portfolios.FirstOrDefault(p => p.Id == portfolioId);
                var instrument = instruments.FirstOrDefault(i => i.Id == instrumentId);
                if (portfolio == null)
                    throw new InvalidOperationException($"BaseOrder translation error:Portfolio {portfolioId} was not found");
                if (instrument == null)
                    throw new InvalidOperationException($"BaseOrder translation error:Instrument {instrumentId} was not found");

                return new BaseOrder(            
                    portfolio,
                    instrument,
                    quantity,
                    OrderSide.Create(quantity),
                    PositionSide.Create(targetPositionQuantity),
                    rollDate,
                    OrderReason.Rollover
                    );
            }
            foreach (var dto in rollovers)
            {
                BaseOrder closePositionOrder = Create(dto.PortfolioId, dto.ExpiringContractId, dto.ExpiringQuantity, 0, dto.RollDate);
                BaseOrder openPositionOrder = Create(dto.PortfolioId, dto.NextContractId, dto.NextQuantity, dto.NextQuantity, dto.RollDate);
                translatedOrders.Add(closePositionOrder);
                translatedOrders.Add(openPositionOrder);
            }

            return translatedOrders;
        }
    }
}
