using Element = Bloomberglp.Blpapi.Element;
using Request = Bloomberglp.Blpapi.Request;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public abstract class Strategy
    {

        public string Name { get; }

        public Strategy(string name)
        {
            this.Name = name;
        }

        public void SetStrategyElement(Request request)
        {
            Element strategy = request.GetElement("EMSX_STRATEGY_PARAMS");
            strategy.SetElement("EMSX_STRATEGY_NAME", Name);
            Element indicator = strategy.GetElement("EMSX_STRATEGY_FIELD_INDICATORS");
            Element data = strategy.GetElement("EMSX_STRATEGY_FIELDS");
            SetIndicatorDataElements(indicator, data);
        }

        protected abstract void SetIndicatorDataElements(Element indicator, Element data);
    }
}
