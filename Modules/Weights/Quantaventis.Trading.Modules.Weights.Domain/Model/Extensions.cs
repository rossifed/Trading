

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal static class Extensions
    {
        internal static IEnumerable<ModelWeight> TakeLastGenerated(this IEnumerable<ModelWeight> modelWeights)
                     => modelWeights
                    .ToLookup(x => x.Instrument, x => (x.GeneratedOn, x))
                    .ToDictionary(x => x.Key, x => x.OrderByDescending(x => x.GeneratedOn).First().x)
                    .Values;

 


    }
}
