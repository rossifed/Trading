namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal enum PositionSide
    {
        L, S, C

          
            
    }

internal static class PositionSideExtensions
{
    internal static bool IsValidPositionSide(this string posSide)
    {
        return posSide == PositionSide.L.ToString() ||
               posSide == PositionSide.S.ToString() ||
               posSide == PositionSide.C.ToString();
    }
}
}
