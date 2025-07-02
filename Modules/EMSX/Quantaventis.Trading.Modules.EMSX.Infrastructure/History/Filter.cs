using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History
{
    internal abstract class Filter
    {
        protected string Choice { get; }
        protected abstract void SetElement(Element filterBy);

        protected Filter(string choice)
        {
            Choice = choice;
        }



        public void SetFilter(Request request)
        {
            Element filterBy = request.GetElement("FilterBy");
            filterBy.SetChoice(Choice);
            SetElement(filterBy);
        }

        public override string? ToString()
        {
            return Choice;
        }

        public override bool Equals(object? obj)
        {
            return obj is Filter filter &&
                   Choice == filter.Choice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Choice);
        }
    }
}
