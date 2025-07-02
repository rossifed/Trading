using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses
{
    internal class GetFillsResponse
    {
        internal IEnumerable<EmsxFillDto> EmsxFills { get; }


        public GetFillsResponse(IEnumerable<EmsxFillDto> emsxFills)
        {
            EmsxFills = emsxFills;

        }


    }
}
