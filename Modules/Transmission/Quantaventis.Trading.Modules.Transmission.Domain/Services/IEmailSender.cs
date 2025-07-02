using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Services
{
    internal interface IEmailSender
    {
        Task SendEmailAsync( IEnumerable<TransmissionFile> files, EmailConfiguration emailConfiguration);
    }
}
