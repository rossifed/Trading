using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileContentGenerationInfo
    {
        public bool IncludeHeader { get; set; }
        public string Separator { get; set; } = null!;
        public byte PortfolioId { get; set; }
 
        public string FunctionName { get; set; } = null!;

        public FileContentGenerationInfo(byte portfolioId, string functionName, bool includeHeader, string separator)
        {
            IncludeHeader = includeHeader;
            Separator = separator;
            PortfolioId = portfolioId;
            FunctionName = functionName;
        }

        public override bool Equals(object? obj)
        {
            return obj is FileContentGenerationInfo info &&
                   IncludeHeader == info.IncludeHeader &&
                   Separator == info.Separator &&
                   PortfolioId == info.PortfolioId &&
                   FunctionName == info.FunctionName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IncludeHeader, Separator, PortfolioId, FunctionName);
        }


    }
}
