using Quantaventis.Trading.Modules.FXGOGateway.Api.ACL;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Options;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Services
{

    internal class EfrpFileGenerationService : IFXGOFileGenerationService<EfrpOrderDto>
    {
        private IFXGOOrderFileWriter FXGOFileWriter { get; }

        private IOrderTranslator<EfrpOrderDto> OrderTranslator { get; }

        private FXGOFileOptions FXGOFileOptions { get; }
        public EfrpFileGenerationService(IFXGOOrderFileWriter fXGOFileWriter,
            IOrderTranslator<EfrpOrderDto> orderTranslator,
            FXGOFileOptions fXGOFileOptions

            )
        {
            FXGOFileWriter = fXGOFileWriter;
            OrderTranslator= orderTranslator;
            FXGOFileOptions = fXGOFileOptions;
        }

        public async Task GenerateFXGOFileAsync(IEnumerable<EfrpOrderDto> efrpOrderDtos)
        { 
           var fileGroups =   efrpOrderDtos.GroupBy(x => $"FXEM_Orders_EFRP_{x.OrderReason}.csv");

            foreach ( var group in fileGroups )
            {
                var filePath = Path.Combine(FXGOFileOptions.WorkingFolder,group.Key);
               await GenerateFXGOFileAsync(filePath, group.ToList(), FXGOFileOptions.FileSeparator);

            }
        }

        public async Task GenerateFXGOFileAsync(string filePath, IEnumerable<EfrpOrderDto> efrpOrderDtos, string separator)
        {

            IEnumerable<FxemOrder> fxemOrders = OrderTranslator.Translate(efrpOrderDtos);

            await FXGOFileWriter.WriteToFileAsync(fxemOrders, filePath, separator);

        }
    }
}
