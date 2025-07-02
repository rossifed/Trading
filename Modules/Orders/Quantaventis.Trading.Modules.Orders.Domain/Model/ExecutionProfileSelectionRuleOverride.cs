namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class ExecutionProfileSelectionRuleOverride
    {
        private Portfolio Portfolio { get; }
        private Broker Broker { get; }
        private Instrument Instrument { get; }
        internal TradeMode TradeMode { get; }
        internal ExecutionProfile ExecutionProfile { get; }

        public ExecutionProfileSelectionRuleOverride(Portfolio portfolio,
            Broker broker,
            Instrument instrument,
            TradeMode tradeMode,
            ExecutionProfile executionProfile)
        {
            Portfolio = portfolio;
            Broker = broker;
            Instrument = instrument;
            TradeMode = tradeMode;
            ExecutionProfile = executionProfile;
        }
        
        internal bool IsSatisfied(Portfolio portfolio, Broker broker, Instrument instrument, TradeMode tradeMode)
        {
            return this.Portfolio == portfolio
                && this.Broker == broker
                && this.Instrument == instrument
                && this.TradeMode == tradeMode;
        }
    }
}
