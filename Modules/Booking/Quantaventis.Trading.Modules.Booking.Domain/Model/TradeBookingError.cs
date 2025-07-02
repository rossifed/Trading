namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class TradeBookingError
    {
        internal int TradeId { get; }
        internal string Message { get; }
        internal BookingErrorType BookingErrorType { get; }
        public TradeBookingError(int tradeId, BookingErrorType bookingErrorType, string message)
        {
            TradeId = tradeId;
            Message = message;
            BookingErrorType = bookingErrorType;
        }

        public override string? ToString()
        {
            return $"{TradeId} {BookingErrorType}: {Message}";
        }
    }
}
