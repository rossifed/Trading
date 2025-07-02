using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileNameGenerationInfo
    {
        internal FileNameTemplate FileNameTemplate { get; } 


        internal string? DateParamFormat { get; }

        internal FileNameGenerationInfo(FileNameTemplate fileNameTemplate, string? dateParamFormat)
        {
            FileNameTemplate = fileNameTemplate;
            DateParamFormat = dateParamFormat;
        }


    }
}
