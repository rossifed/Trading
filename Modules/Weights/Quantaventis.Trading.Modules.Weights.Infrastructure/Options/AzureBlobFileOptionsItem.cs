using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Infrastructure.Options
{

    public class AzureBlobFileOptionsItem
    {
        public byte PortfolioId { get; set; }
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
        public bool DecompressFile { get; set; }
        public string Separator { get; set; }
    }
}
