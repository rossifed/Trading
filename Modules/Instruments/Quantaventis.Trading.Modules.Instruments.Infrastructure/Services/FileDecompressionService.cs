using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Services
{
    internal interface IFileDecompressionService {

        Task<string> DecompressFileAsync(string blobName);

        Task<string> DecompressFileToAsync(string inputPath, string outputPath);
    }
    internal class FileDecompressionService : IFileDecompressionService
    {
        public async Task<string> DecompressFileAsync(string gzFilePath)
        {
            string? directory = Path.GetDirectoryName(gzFilePath);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(gzFilePath);
            string newFilePath = Path.Combine(directory, fileNameWithoutExtension);
  
          return await DecompressFileToAsync(gzFilePath, newFilePath);
        }
        public async Task<string> DecompressFileToAsync(string inputPath, string outputPath)
        {
            using (FileStream originalFileStream = new FileStream(inputPath, FileMode.Open))
            {
                using (FileStream decompressedFileStream = File.Create(outputPath))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                       await decompressionStream.CopyToAsync(decompressedFileStream);
                    }
                }
            }
            return outputPath;
        }
    }
}
