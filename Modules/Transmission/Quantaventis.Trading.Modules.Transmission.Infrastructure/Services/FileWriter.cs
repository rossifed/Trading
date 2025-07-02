using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{

    internal class FileWriter : IFileWriter
    {

        public async Task WriteAsync(TransmissionFile file)
        {
            var filePath = file.FullPath;
            var directoryPath = file.Directory.Path;
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            await  File.WriteAllTextAsync(filePath, file.Content.ToString());
        }
    }
}
