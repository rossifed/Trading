using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
namespace Quantaventis.Trading.Modules.Transmission.Domain.Services
{
    internal interface IFileEncryptor
    {
        Task<IEnumerable<TransmissionFile>> EncryptFilesAsync(IEnumerable<TransmissionFile> files, EncryptionProfile encryptionProfile);
        Task<Domain.Model.TransmissionFile> EncryptFileAsync(Domain.Model.TransmissionFile file, EncryptionProfile encryptionProfile);
    }
}
