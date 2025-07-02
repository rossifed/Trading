using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal class UuidScope : Scope
    {

        private IEnumerable<int> Uuids { get; }
        public UuidScope(IEnumerable<int> uuids) : base("Uuids")
        {
            Uuids = uuids;
        }

        protected override void SetElement(Element scope)
        {
            Element element = scope.GetElement("Uuids");
            foreach (int uuid in Uuids)
            {
                element.AppendValue(uuid);

            }
        }

        public override string? ToString()
        {
            return $"{Choice}:{string.Join(',', Uuids)}";
        }

        public override bool Equals(object? obj)
        {
            return obj is UuidScope scope &&
                   base.Equals(obj) &&
                   Choice == scope.Choice &&
                   EqualityComparer<IEnumerable<int>>.Default.Equals(Uuids, scope.Uuids);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Choice, Uuids);
        }
    }
}
