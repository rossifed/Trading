using Bloomberglp.Blpapi;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal class TradingSystemScope : Scope
    {

        private bool UseTradingSystemView { get; }
        public TradingSystemScope(bool useTradingSystemView) : base("TradingSystem")
        {
            UseTradingSystemView = useTradingSystemView;
        }

        protected override void SetElement(Element scope)
        {
            scope.SetElement("TradingSystem", UseTradingSystemView);
        }

        public override string? ToString()
        {
            return $"{Choice}:{UseTradingSystemView}";
        }

        public override bool Equals(object? obj)
        {
            return obj is TradingSystemScope scope &&
                   base.Equals(obj) &&
                   Choice == scope.Choice &&
                   UseTradingSystemView == scope.UseTradingSystemView;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Choice, UseTradingSystemView);
        }
    }
}
