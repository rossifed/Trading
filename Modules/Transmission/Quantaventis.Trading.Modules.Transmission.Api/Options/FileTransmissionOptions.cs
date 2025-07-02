using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Api.Options
{
    public class FileTransmissionOptions
    {
        public string EodTransmissionTimeUtc { get; set; }


        public TimeOnly ParseEodTransmissionTimeUtc() => TimeOnly.ParseExact(EodTransmissionTimeUtc, "HH:mm");
    }
}
