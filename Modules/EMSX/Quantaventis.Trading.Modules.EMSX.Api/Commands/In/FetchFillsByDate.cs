using Quantaventis.Trading.Modules.EMSX.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.EMSX.Api.Commands.In
{
    internal record FetchFillsByDate(DateOnly FillDate) : ICommand;
}
