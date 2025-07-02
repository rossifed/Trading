using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses
{
    internal class HistoryResponse<TResponse>
    {

        internal IEnumerable<TResponse> PartialResponses { get; }

        public HistoryResponse(IEnumerable<TResponse> partialResponses)
        {
            PartialResponses = partialResponses;
        }
    }
}
