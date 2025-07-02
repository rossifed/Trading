using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Domain.Exceptions;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Service;
namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface ITradeEnrichmentService
    {
        Task<EnrichedTrade> EnrichTradeAsync(RawTrade trade);
        Task<IEnumerable<EnrichedTradeAllocation>> EnrichTradeAllocationsAsync(EnrichedTrade enrichedTrade, IEnumerable<RawTradeAllocation> tradeAllocations);

    }

    internal class TradeEnrichmentService : ITradeEnrichmentService
    {
        private ITradeEnricher TradeEnricher { get; }

        private ITradeAllocationEnricher TradeAllocationEnricher { get; }

        public TradeEnrichmentService(ITradeEnricher tradeEnricher, ITradeAllocationEnricher tradeAllocationEnricher)
        {
            TradeEnricher = tradeEnricher;
            TradeAllocationEnricher = tradeAllocationEnricher;
        }

        public async Task<EnrichedTrade> EnrichTradeAsync(RawTrade trade)
        {
            try
            {
               
                EnrichedTrade enrichedTrade = await TradeEnricher.EnrichTradeAsync(trade);
                return enrichedTrade;
            }
            catch (Exception ex)
            {

                throw new TradeEnrichmentException(trade.TradeId, ex.Message, ex);

            }
        }
        public async Task<IEnumerable<EnrichedTradeAllocation>> EnrichTradeAllocationsAsync(EnrichedTrade enrichedTrade, IEnumerable<RawTradeAllocation> tradeAllocations)
        {
            try
            {
                IEnumerable<EnrichedTradeAllocation> enrichedTradeAllocations = await TradeAllocationEnricher.EnrichTradeAllocationsAsync(enrichedTrade, tradeAllocations);
                return enrichedTradeAllocations;
            }
            catch (Exception ex)
            {
                throw new TradeEnrichmentException(enrichedTrade.TradeId, ex.Message, ex);
            }
        }
    }
}
