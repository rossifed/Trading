using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO
{
    internal interface IFXGOOrderFileWriter
    {
        Task WriteToFileAsync(IEnumerable<FxemOrder> rows, string filePath, string separator);


    }
    internal class FxemOrderFileWriter : IFXGOOrderFileWriter
    {
   
        public async Task WriteToFileAsync(IEnumerable<FxemOrder> fxemOrders, string filePath, string separator)
        {
            // Prepare the header based on the properties of FXGOOrderFileRow
            var columnNames = typeof(FxemOrder)
                            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Select(p => p.Name)
            .ToArray();

            using (var writer = new StreamWriter(filePath))
            {
                // Write column names as header row
                writer.WriteLine(string.Join(separator, columnNames));

                // Write each order's data as a row
                foreach (var fxemOrder in fxemOrders)
                {
                    writer.WriteLine(string.Join(separator, columnNames.Select(name => typeof(FxemOrder).GetProperty(name).GetValue(fxemOrder)?.ToString())));
                }
            }
        }
    }
    
}

