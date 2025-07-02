namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class BookedTrade
    {
        internal int TradeId { get; }
        internal EnrichedTrade EnrichedTrade { get; }
        internal IEnumerable<BookedTradeAllocation> BookedTradeAllocations { get; }
        internal TradeStatus TradeStatus { get; }
        internal DateTime BookingDateUtc { get; }

        internal DateTime? LastCorrectionDateUtc { get; }

        internal DateTime? CancelationDateUtc { get; }


        internal BookedTradeAllocation? GetAllocationById(int tradeAllocationId)
            => BookedTradeAllocations.FirstOrDefault(x => x.TradeAllocationId == tradeAllocationId);
        internal BookedTrade(EnrichedTrade enrichedTrade,
            IEnumerable<BookedTradeAllocation> tradeAllocations,
            TradeStatus tradeStatus,
            DateTime bookedOnUtc,
              DateTime? lastCorrectionDateUtc,
            DateTime? cancelationDateUtc)
        {
            this.EnrichedTrade = enrichedTrade;
            this.TradeId = EnrichedTrade.TradeId;
            this.BookedTradeAllocations = tradeAllocations;

            this.TradeStatus = tradeStatus;
            this.BookingDateUtc = bookedOnUtc;
            this.LastCorrectionDateUtc = lastCorrectionDateUtc;
            this.CancelationDateUtc = cancelationDateUtc;

        }

        internal bool IsCorrected => TradeStatus.COR.Equals(TradeStatus);
        internal bool IsCancelled=> TradeStatus.CAN.Equals(TradeStatus);
        internal bool IsCorrectedAfter(DateTime dateTimeUtc) { 
        return IsCorrected && LastCorrectionDateUtc > dateTimeUtc;
        }

        private BookedTrade(EnrichedTrade enrichedTrade,
            IEnumerable<BookedTradeAllocation> tradeAllocations,
            TradeStatus status,
            DateTime bookedOnUtc)
            : this(enrichedTrade, tradeAllocations, status, bookedOnUtc, null, null)
        {


        }

        internal BookedTrade Correct(int tradeAllocationId, TradeAllocationCorrection tradeAllocationCorrection)
        {
            BookedTradeAllocation? bookedTradeAllocation = GetAllocationById(tradeAllocationId);
            if (bookedTradeAllocation != null) {
                BookedTradeAllocation correctedAllocation = bookedTradeAllocation.Apply(tradeAllocationCorrection);
                IEnumerable<BookedTradeAllocation> newAllocations = BookedTradeAllocations.Select(x => x.TradeAllocationId == tradeAllocationId ? correctedAllocation : x);
                return AsCorrected(EnrichedTrade, newAllocations);
 } 
            return this;
        }
       
        internal BookedTrade Correct(TradeCorrection tradeCorrection)
        {
            if (TradeStatus == TradeStatus.CAN)
                throw new InvalidOperationException($"Canceled trade can't be corrected. TradeId:{EnrichedTrade.TradeId}");
                return AsCorrected(tradeCorrection.ApplyTo(EnrichedTrade), BookedTradeAllocations.Select(x => x.Apply(tradeCorrection)));
    

        }

        private BookedTrade AsCorrected(EnrichedTrade enrichedTrade, IEnumerable<BookedTradeAllocation> bookedTradeAllocations)
        {        
               return new BookedTrade(enrichedTrade, bookedTradeAllocations, Model.TradeStatus.COR, BookingDateUtc, DateTime.UtcNow, null);
        }

        private IEnumerable<BookedTradeAllocation> FlagAllocationsAsCorrected()
            => BookedTradeAllocations.Select(x => x.AsCorrected());
        internal BookedTrade AsCorrected(bool flagAllocations)
        {
            
            return new BookedTrade(EnrichedTrade,
               flagAllocations? FlagAllocationsAsCorrected():BookedTradeAllocations, 
                Model.TradeStatus.COR, 
                BookingDateUtc, 
                DateTime.UtcNow, 
                null);
        }

        internal BookedTrade FlagAllocationAsCorrected(int tradeAllocationId)
        {
            IEnumerable<BookedTradeAllocation> newAllocations = BookedTradeAllocations.Select(x => x.TradeAllocationId == tradeAllocationId ? x.AsCorrected() : x);
            return AsCorrected(EnrichedTrade, newAllocations);
            
        }

        internal BookedTrade Cancel()
           => new BookedTrade(EnrichedTrade, BookedTradeAllocations.Select(x=>x.Cancel()), Model.TradeStatus.CAN, BookingDateUtc, LastCorrectionDateUtc, DateTime.UtcNow);




        internal static BookedTrade New(EnrichedTrade enrichedTrade, IEnumerable<BookedTradeAllocation> tradeAllocations)
            => new BookedTrade(enrichedTrade, tradeAllocations, Model.TradeStatus.NEW, DateTime.UtcNow);



        internal static BookedTrade New(EnrichedTrade enrichedTrade, IEnumerable<EnrichedTradeAllocation> tradeAllocations)
            => new BookedTrade(enrichedTrade, tradeAllocations.Select(x=> BookedTradeAllocation.New(x)), Model.TradeStatus.NEW, DateTime.UtcNow);

        public override bool Equals(object? obj)
        {
            return obj is BookedTrade trade &&
                   EqualityComparer<EnrichedTrade>.Default.Equals(EnrichedTrade, trade.EnrichedTrade) &&
                   EqualityComparer<IEnumerable<BookedTradeAllocation>>.Default.Equals(BookedTradeAllocations, trade.BookedTradeAllocations);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EnrichedTrade, BookedTradeAllocations);
        }
    }
}
