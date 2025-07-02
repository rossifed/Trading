using Quantaventis.Trading.Modules.FXGOGateway.Api.ACL;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Options;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Services
{

    internal class FxForwardFileGenerationService : IFXGOFileGenerationService<OrderDto>
    {
        private IFXGOOrderFileWriter FXGOFileWriter { get; }
        FXGOFileOptions FXGOFileOptions { get; }
        private IOrderTranslator<OrderDto> OrderTranslator { get; }
        public FxForwardFileGenerationService(IFXGOOrderFileWriter fXGOFileWriter,
            IOrderTranslator<OrderDto> orderTranslator,
                  FXGOFileOptions fXGOFileOptions
            )
        {
            FXGOFileWriter = fXGOFileWriter;
            OrderTranslator= orderTranslator;
            FXGOFileOptions = fXGOFileOptions;
        }
        public async Task GenerateFXGOFileAsync(IEnumerable<OrderDto> orderDto)
        {
            var fileGroups = orderDto.GroupBy(x => $"FXEM_Orders_FXFWD_{x.OrderReason}.csv");

            foreach (var group in fileGroups)
            {
                var filePath = Path.Combine(FXGOFileOptions.WorkingFolder, group.Key);
                await GenerateFXGOFileAsync(filePath, group.ToList(), FXGOFileOptions.FileSeparator);

            }
        }

        public async Task GenerateFXGOFileAsync(string filePath, IEnumerable<OrderDto> orderDtos, string separator)
        {

            IEnumerable<FxemOrder> fxemOrders = OrderTranslator.Translate(orderDtos);

            await FXGOFileWriter.WriteToFileAsync(fxemOrders, filePath, separator);

        }
       
    }
}
