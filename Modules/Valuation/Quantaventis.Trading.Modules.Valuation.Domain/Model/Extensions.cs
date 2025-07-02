namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal static class Extensions
    {

        internal static Money Sum(this IEnumerable<Money> money)
          =>  money.Aggregate((x, y) => x + y);
        internal static Money Sum(this IEnumerable<PositionValuation> positionValuations, Func<PositionValuation, Money> propertyAccessor)
         => positionValuations.Select(x=> propertyAccessor(x)).Sum();

   
    }
}
