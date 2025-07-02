namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class TradeValidation
    {
      internal IEnumerable<TradeValidationError> TradeValidationErrors { get; }



      internal  bool IsSuccess() {
            return true;
        }
    }
}
