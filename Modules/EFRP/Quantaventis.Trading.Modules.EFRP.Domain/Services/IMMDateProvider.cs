using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Services
{
    internal interface IIMMDateProvider
    {

        DateOnly GetNextIMMDate(DateOnly date);
    }
    internal class IMMDateProvider : IIMMDateProvider
    {
        private IEnumerable<DateOnly> ImmDates { get; }

        public IMMDateProvider(IEnumerable<DateOnly> immDates)
        {
            ImmDates = immDates;
        }

        public DateOnly GetNextIMMDate(DateOnly date)
        {
           return ImmDates.Where(x => x.CompareTo(date) > 0).First();

        }
    }
}
