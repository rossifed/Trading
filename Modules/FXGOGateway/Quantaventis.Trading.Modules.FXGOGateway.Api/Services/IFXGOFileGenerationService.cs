using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Services
{
    internal interface IFXGOFileGenerationService<T> {

        Task GenerateFXGOFileAsync(IEnumerable<T> orderDtos);




    }

}
