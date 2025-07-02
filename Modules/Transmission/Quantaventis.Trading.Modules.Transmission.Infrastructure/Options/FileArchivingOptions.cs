using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Options
{
    internal class FileArchivingOptions
    {
        public string TimestampFormat { get; set; }
        public string SuccessFolderName { get; set; } 

        public string ErrorFolderName { get; set; }

    
    }
}
