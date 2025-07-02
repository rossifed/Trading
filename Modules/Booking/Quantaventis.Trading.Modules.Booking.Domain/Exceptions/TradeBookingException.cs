using Quantaventis.Trading.Modules.Booking.Domain.Model;

namespace Quantaventis.Trading.Modules.Booking.Domain.Exceptions
{
    internal class TradeBookingException :Exception
    {
        internal int TradeId { get; }

        internal BookingErrorType BookingErrorType { get; }

    
        public TradeBookingException(int tradeId, BookingErrorType bookingErrorType, string? message) : base(message)
        {
            TradeId = tradeId;
            BookingErrorType = bookingErrorType;
        }

        public TradeBookingException(int tradeId, BookingErrorType bookingErrorType,string? message, Exception? innerException) : base(message, innerException)
        {
            TradeId = tradeId;
            BookingErrorType = bookingErrorType;
        }
    }
}
