namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class BookedTradeAllocation
    {
        internal int TradeAllocationId => EnrichedTradeAllocation.TradeAllocationId;
        internal EnrichedTradeAllocation EnrichedTradeAllocation { get; }
        internal TradeStatus TradeStatus { get; }
        internal DateTime? LastCorrectedOnUtc { get; }
        internal DateTime? CanceledOnUtc { get; }
        internal bool IsCorrected => TradeStatus.COR.Equals(TradeStatus);
        internal BookedTradeAllocation(EnrichedTradeAllocation tradeAllocation,
            TradeStatus tradeStatus,
            DateTime? lastCorrectionDateUtc,
            DateTime? cancelationDateUtc)
        {
            this.EnrichedTradeAllocation = tradeAllocation;
            this.TradeStatus = tradeStatus;
            this.LastCorrectedOnUtc = lastCorrectionDateUtc;
            this.CanceledOnUtc = cancelationDateUtc;
        }

        private BookedTradeAllocation(
            EnrichedTradeAllocation tradeAllocation,
            TradeStatus status)
            : this(tradeAllocation, status, null, null)
        {
        }

        internal BookedTradeAllocation Apply(TradeCorrection tradeCorrection)
        {
            if (TradeStatus == TradeStatus.CAN)
                throw new InvalidOperationException($"Canceled tradeAllocation {EnrichedTradeAllocation.TradeAllocationId} can't be corrected. ");
            return Apply(tradeCorrection.ToTradeAllocationCorrection(EnrichedTradeAllocation));
        }

        internal BookedTradeAllocation Apply(TradeAllocationCorrection tradeAllocationCorrection)
        {
            if (TradeStatus == TradeStatus.CAN)
                throw new InvalidOperationException($"Canceled tradeAllocation {EnrichedTradeAllocation.TradeAllocationId} can't be corrected. ");
            EnrichedTradeAllocation correctedAllocation = tradeAllocationCorrection.ApplyTo(EnrichedTradeAllocation);
            return new BookedTradeAllocation(correctedAllocation, Model.TradeStatus.COR, DateTime.UtcNow, null); ;
        }

        internal BookedTradeAllocation AsCorrected()
        {
            if (TradeStatus == TradeStatus.CAN)
                throw new InvalidOperationException($"Canceled tradeAllocation {EnrichedTradeAllocation.TradeAllocationId} can't be flagged as corrected. ");
            return new BookedTradeAllocation(EnrichedTradeAllocation, TradeStatus.COR, DateTime.UtcNow, CanceledOnUtc);
        }

        internal BookedTradeAllocation Cancel()
           => new BookedTradeAllocation(EnrichedTradeAllocation, Model.TradeStatus.CAN, LastCorrectedOnUtc, DateTime.UtcNow);

        internal static BookedTradeAllocation New(EnrichedTradeAllocation tradeAllocation)
            => new BookedTradeAllocation(tradeAllocation, Model.TradeStatus.NEW);

        internal static BookedTradeAllocation Correct(EnrichedTradeAllocation tradeAllocation)
            => new BookedTradeAllocation(tradeAllocation, Model.TradeStatus.NEW);
    }
}
