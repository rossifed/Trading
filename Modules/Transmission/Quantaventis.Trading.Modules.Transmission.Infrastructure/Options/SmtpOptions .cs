using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Options
{
    public class SmtpOptions
    {
        public string Host { get; set; }

        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public string CredentialEmail { get; set; } 

        public bool EnableSsl { get; set; }
        public string CredentialPassword { get; set; }
    }
}
