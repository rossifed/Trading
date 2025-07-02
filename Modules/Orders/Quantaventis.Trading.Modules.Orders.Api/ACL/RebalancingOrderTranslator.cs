using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.ACL
{   internal interface IRebalancingOrderTranslator : ICollectionTranslator<RebalancingOrderDto, BaseOrder> { }
    internal class RebalancingOrderTranslator : IRebalancingOrderTranslator
    {
      
        private IPortfolioRepository PortfolioRepository { get; }
        private  IInstrumentRepository InstrumentRepository { get; }
  
        public RebalancingOrderTranslator(IPortfolioRepository portfolioRepository, IInstrumentRepository instrumentRepository)
        {
            PortfolioRepository = portfolioRepository;
            InstrumentRepository = instrumentRepository;
        }
    
        public async Task<IEnumerable<BaseOrder>> TranslateAsync(IEnumerable<RebalancingOrderDto> orderDtos)
        {
            // Extract distinct Portfolio and Instrument IDs
            var portfolioIds = orderDtos.Select(o => o.PortfolioId).Distinct().ToList();
            var instrumentIds = orderDtos.Select(o => o.InstrumentId).Distinct().ToList();

            // Fetch in bulk
            var portfolios = await PortfolioRepository.GetAllAsync();
            var instruments = await InstrumentRepository.GetByIdsAsync(instrumentIds);

            var translatedOrders = new List<BaseOrder>();

            foreach (var dto in orderDtos)
            {
                var portfolio = portfolios.FirstOrDefault(p => p.Id == dto.PortfolioId);
                var instrument = instruments.FirstOrDefault(i => i.Id == dto.InstrumentId);
                if (portfolio == null)
                    throw new InvalidOperationException($"BaseOrder translation error:Portfolio {dto.PortfolioId} was not found");
                if (instrument == null)
                    throw new InvalidOperationException($"BaseOrder translation error:Instrument {dto.InstrumentId} was not found");

                var order = new BaseOrder(
                    dto.RebalancingSessionId,
        
                    portfolio,
                    instrument,
                    dto.Quantity,
                    OrderSide.Create(dto.Quantity),                                    
                    PositionSide.Create(dto.TargetPositionQuantity),
                    dto.TradeDate,
                    OrderReason.Rebalancing) ;
                  
                    translatedOrders.Add(order);
              
            }

            return translatedOrders;
        }
    }
}
