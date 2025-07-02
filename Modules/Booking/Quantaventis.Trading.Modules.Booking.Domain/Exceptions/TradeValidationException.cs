using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Domain.Exceptions
{
    internal class TradeValidationException : TradeBookingException
    {
      
        public TradeValidationException(int tradeId, string? message) : base(tradeId, BookingErrorType.Validation, message)
        {
        }

        public TradeValidationException(int tradeId, string? message, Exception? innerException) : base(tradeId, BookingErrorType.Enrichment, message, innerException)
        {
        }
   
    }
}
