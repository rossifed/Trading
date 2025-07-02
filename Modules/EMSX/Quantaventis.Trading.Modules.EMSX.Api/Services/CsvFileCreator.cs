using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Api.Services
{
    public static class CsvFileCreator
    {
        public static void CreateCsvFile(IEnumerable<EmsxFillDto> dtos, string filePath)
        {
            if (dtos == null || !dtos.Any())
            {
                throw new ArgumentException("DTO list is null or empty.", nameof(dtos));
            }

            var properties = typeof(EmsxFillDto).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var headerLine = string.Join(",", properties.Select(p => p.Name));

            var csvStringBuilder = new StringBuilder();
            csvStringBuilder.AppendLine(headerLine);

            foreach (var dto in dtos)
            {
                var line = string.Join(",", properties.Select(p => FormatCsvValue(p.GetValue(dto, null))));
                csvStringBuilder.AppendLine(line);
            }

            File.WriteAllText(filePath, csvStringBuilder.ToString());
        }

        private static string FormatCsvValue(object value)
        {
            if (value == null) return "";
            var output = value.ToString().Replace("\"", "\"\"");
            if (output.Contains(',') || output.Contains('\n') || output.Contains('\r'))
            {
                output = $"\"{output}\"";
            }
            return output.Trim();
        }
    }
}
