using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Infrastructure.IO
{
    public interface IFileDecompressor
    {
        Task<string> DecompressFileAsync(string fileName);
    }
}
