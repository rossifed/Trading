using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.EFRP.Api.Queries.In
{
    internal record GetIsEfrp(int InstrumentId) : IQuery<bool>
    {

    }
}
