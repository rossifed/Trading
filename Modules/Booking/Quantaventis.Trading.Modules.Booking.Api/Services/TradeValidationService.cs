using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface ITradeValidationService
    {
        Task<TradeValidation> ValidateTradeAsync(BookedTrade trade);
    }
    internal class TradeValidationService : ITradeValidationService
    {
       public async Task<TradeValidation> ValidateTradeAsync(BookedTrade trade)
        {
            return new TradeValidation();
        }
    }
}
