using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Options
{
    internal class GpgEncryptionOptions
    {
        public string GpgPath { get; set; }
        public string Homedir { get; set; } 

        public string Passphrase { get; set; }
    }
}
