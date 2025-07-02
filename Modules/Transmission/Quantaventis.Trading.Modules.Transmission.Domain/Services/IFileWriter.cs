using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
namespace Quantaventis.Trading.Modules.Transmission.Domain.Services
{
    internal interface IFileWriter
    {

        Task WriteAsync(Domain.Model.TransmissionFile file);
    }
}
