using Quantaventis.Trading.Modules.Booking.Domain.Model;

namespace Quantaventis.Trading.Modules.Booking.Domain.Exceptions
{
    internal class TradeAllocationException : TradeBookingException
    {
        public TradeAllocationException(int tradeId,  string? message) : base(tradeId, BookingErrorType.Allocation, message)
        {
        }

        public TradeAllocationException(int tradeId,  string? message, Exception? innerException) : base(tradeId, BookingErrorType.Allocation, message, innerException)
        {
        }
    }
}
