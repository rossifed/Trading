using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Domain.Exceptions
{
    internal class TradeEnrichmentException : TradeBookingException
    {
        public TradeEnrichmentException(int tradeId, string? message) : base(tradeId, BookingErrorType.Enrichment, message)
        {
        }

        public TradeEnrichmentException(int tradeId, string? message, Exception? innerException) : base(tradeId, BookingErrorType.Enrichment, message, innerException)
        {
        }
   
    }
}
