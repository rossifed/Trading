using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Abstractions.Azure.Storage
{
    public interface IAzureBlobFileDownloader
    {
        Task<string> DownloadBlobFileAsync(string blobFileName, string downloadFilePath);
        Task<string> DownloadAndDecompressBlobFileAsync(string blobFileName, string downloadFilePath);
    }
}
