using Quantaventis.Trading.Modules.EMSX.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.EMSX.Api.Commands.In
{
    internal record FetchFillsByOrderId(int orderId) : ICommand;
}
