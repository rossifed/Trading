using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Options;
using Quantaventis.Trading.Shared.Abstractions.Azure.Storage;
using Quantaventis.Trading.Shared.Infrastructure.Azure.Storage;
using Quantaventis.Trading.Shared.Infrastructure.IO;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using System.IO;

namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Files
{
    interface IAzureBlobFileReader {
        Task<ModelWeightingFile> ReadAsync(byte portfolioId, string blobFileName);


    }
    internal class AzureBlobFileReader  : IAzureBlobFileReader
    {

        private IDictionary<byte, AzureBlobFileOptionsItem> AzureBlobFileOptions { get; set; }
    
        public AzureBlobFileReader(AzureBlobFileOptions azureBlobFileOptions)
        {

            AzureBlobFileOptions = azureBlobFileOptions.AzureBlobFileOptionsItems.ToDictionary(x=>x.PortfolioId);
        }

        private async Task<IEnumerable<(string symbol, double weight)>> ReadAllLinesAsync(BlobClient blobClient, string separator)
        {
            using (Stream stream = await blobClient.OpenReadAsync())
            using (var streamReader = new StreamReader(stream))
            {
                return streamReader.ReadToEnd()
                    .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
                    .Select(line =>
                    {
                        string[] parts = line.Split(separator);
                        if (parts.Length == 2 && double.TryParse(parts[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double weight))
                        {
                            return (parts[0], weight);
                        }
                        return (null, 0.0); // Handle parsing errors or invalid lines as needed
                    })
                    .Where(data => data.Item1 != null && data.weight!=0)
                    .ToList();

            }
        }
        public async Task<ModelWeightingFile> ReadAsync(byte portfolioId, string blobFileName)
        {

            if (!AzureBlobFileOptions.TryGetValue(portfolioId, out var azureBlobStorageOptions))
            {
                throw new ArgumentException($"No configuration found for portfolioId {portfolioId}");
            }

            BlobServiceClient blobServiceClient = new BlobServiceClient(azureBlobStorageOptions.ConnectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(azureBlobStorageOptions.ContainerName);
            BlobClient blobClient = containerClient.GetBlobClient(blobFileName);

            BlobProperties properties = await blobClient.GetPropertiesAsync();
            DateTime createdOn = properties.CreatedOn.DateTime;
            DateTime lastWriteTime = properties.LastModified.DateTime;

        IEnumerable<(string symbol, double weight)> weights = await ReadAllLinesAsync(blobClient, azureBlobStorageOptions.Separator);


            return new ModelWeightingFile(blobFileName,
                portfolioId,
                createdOn,
                lastWriteTime,
                weights);

        }
        private (string symbol, double weight) ReadLine(string[] lineValues) {
            string symbol = Convert.ToString(lineValues[0]);
            double weight = double.Parse(lineValues[1], System.Globalization.CultureInfo.InvariantCulture);
            return (symbol, weight);
        }

        private ICollection<(string symbol, double weight)> ReadWeights(string[] lines, char separator)
         => lines.Select(line => ReadLine(line.Split(separator))).ToList();
    }
}
