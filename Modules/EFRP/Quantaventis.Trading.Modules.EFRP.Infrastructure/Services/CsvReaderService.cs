using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using Quantaventis.Trading.Shared.Infrastructure.Database;
namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Services
{
    internal interface ICsvReaderService{
        DataTable ReadToDataTable(string path);
}
    public class CsvReaderService : ICsvReaderService
    {
        public DataTable ReadToDataTable(string path)
        {
            DataTable dt = new DataTable();

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                // Get the header record to build the DataTable columns
                csv.Read();
                csv.ReadHeader();
                if (csv.HeaderRecord == null) {
                    throw new InvalidOperationException($"Header is required in the {path} file");
                }
                foreach (var header in csv.HeaderRecord)
                {
                    dt.Columns.Add(header);
                }

                // Read the rest of the records and populate the DataTable
                while (csv.Read())
                {
                    var row = dt.NewRow();
                    foreach (var column in dt.Columns.Cast<DataColumn>())
                    {
                        row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);
                    }
                    dt.Rows.Add(row);
                }
            }

            return dt;
        }
    }

}
