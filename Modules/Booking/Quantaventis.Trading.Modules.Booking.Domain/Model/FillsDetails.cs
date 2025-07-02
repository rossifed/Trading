using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class FillsDetails
    {
        internal DateOnly? FirstFillDate { get; set; }

        internal DateOnly? LastFillDate { get; set; }

        internal DateTime? FirstFillDateTimeUtc { get; set; }

        internal DateTime? LastFillDateTimeUtc { get; set; }

        internal decimal? MaxFillPrice { get; set; }

        internal decimal? MinFillPrice { get; set; }
        internal byte? NumberOfFills { get; set; }

        internal static FillsDetails Empty() => new FillsDetails();
        private FillsDetails() { }
        public FillsDetails(
            byte? numberOfFills,
            DateTime? firstFillDateTimeUtc,
            DateTime? lastFillDateTimeUtc,
            decimal? maxFillPrice,
            decimal? minFillPrice)
        {
            NumberOfFills = numberOfFills;
            FirstFillDateTimeUtc = firstFillDateTimeUtc;
            LastFillDateTimeUtc = lastFillDateTimeUtc;
            MaxFillPrice = maxFillPrice;
            MinFillPrice = minFillPrice;
        }
    }
}
