using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Quantaventis.Trading.Shared.Abstractions.Queries;
namespace Quantaventis.Trading.Modules.EMSX.Api.Queries.In
{
    internal record GetSessionStatus() : IQuery<string>;
}
