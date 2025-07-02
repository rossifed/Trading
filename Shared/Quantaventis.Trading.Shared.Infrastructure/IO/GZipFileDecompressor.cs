using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Infrastructure.IO
{
    public class GZipFileDecompressor :IFileDecompressor
    {
        public async Task<string> DecompressFileAsync(string gzFilePath)
        {
            string? directory = Path.GetDirectoryName(gzFilePath);
      
            string decompressedFilePath = gzFilePath.Replace("Schedule", "Schedule2");

            using (FileStream originalFileStream = new FileStream(gzFilePath, FileMode.Open))
            {
                using (FileStream decompressedFileStream = File.Create(decompressedFilePath))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        await decompressionStream.CopyToAsync(decompressedFileStream);
                    }
                }
            }
            return decompressedFilePath;
        }
  
    }
}
