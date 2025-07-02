using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileGeneration
    {
        internal DateTime GenerationTime { get; }
        internal TransmissionFile GeneratedFile { get; }

        internal int RowsCount => GeneratedFile.RowsCount;

        public FileGeneration(TransmissionFile generatedFile, DateTime generationTime)
        {
            GenerationTime = generationTime;
            GeneratedFile = generatedFile;
        }
    }
}
