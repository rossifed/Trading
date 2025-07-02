using Bloomberglp.Blpapi;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal abstract class Scope
    {
        protected string Choice { get; }
        protected abstract void SetElement(Element scope);

        protected Scope(string choice)
        {
            Choice = choice;
        }

        public void SetScope(Request request)
        {
            Element scope = request.GetElement("Scope");
            scope.SetChoice(Choice);
            SetElement(scope);
        }




    }
}
