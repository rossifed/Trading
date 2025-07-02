using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.MarketData.Infrastructure.Options
{
    internal class AzureBlobStorageOptions
    {

        public string ConnectionString { get; set; }

        public string ContainerName { get; set; }

        public bool DecompressFile { get; set; }

        public string DownloadFolder { get; set; }
    }
}
