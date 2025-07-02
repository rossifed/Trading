using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Transmission.Domain.Exceptions;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
namespace Quantaventis.Trading.Modules.Transmission.Domain.Services
{
    internal interface IFtpUploader
    {
        void UploadFile(TransmissionFile file, FtpConfiguration ftpConfiguration);
        void UploadFiles(IEnumerable<TransmissionFile> files, FtpConfiguration ftpConfiguration);
    }
}
