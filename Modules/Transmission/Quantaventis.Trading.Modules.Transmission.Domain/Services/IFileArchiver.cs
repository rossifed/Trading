using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
namespace Quantaventis.Trading.Modules.Transmission.Domain.Services
{
    internal interface IFileArchiver
    {

        IEnumerable<TransmissionFile> ArchiveToSuccessFolder(IEnumerable<TransmissionFile> files);
       IEnumerable<TransmissionFile> ArchiveToErrorFolder(IEnumerable<TransmissionFile> files);
    }
}
