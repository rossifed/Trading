using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal class MultiLegFilter : Filter
    {
        private IEnumerable<int> MultilegIds { get; }
        public MultiLegFilter(IEnumerable<int> multilegIds) : base("Multileg")
        {
            MultilegIds = multilegIds;
        }

        protected override void SetElement(Element filterBy)
        {
            Element multilegElement = filterBy.GetElement("Multileg");

            foreach (var multileg in MultilegIds)
            {
                multilegElement.AppendValue(multileg);

            }
        }

        public override string? ToString()
        {
            return $"{Choice}:{string.Join(',', MultilegIds)}";
        }

        public override bool Equals(object? obj)
        {
            return obj is MultiLegFilter filter &&
                   base.Equals(obj) &&
                   Choice == filter.Choice &&
                   EqualityComparer<IEnumerable<int>>.Default.Equals(MultilegIds, filter.MultilegIds);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Choice, MultilegIds);
        }
    }
}
