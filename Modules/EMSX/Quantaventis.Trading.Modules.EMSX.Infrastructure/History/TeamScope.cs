using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal class TeamScope : Scope
    {

        private string TeamName { get; }
        public TeamScope(string teamName) : base("Team")
        {
            TeamName = teamName;
        }

        protected override void SetElement(Element scope)
        {
            scope.SetElement("Team", TeamName);
        }

        public override string? ToString()
        {
            return $"{Choice}:{TeamName}";
        }

        public override bool Equals(object? obj)
        {
            return obj is TeamScope scope &&
                   base.Equals(obj) &&
                   Choice == scope.Choice &&
                   TeamName == scope.TeamName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Choice, TeamName);
        }
    }
}
