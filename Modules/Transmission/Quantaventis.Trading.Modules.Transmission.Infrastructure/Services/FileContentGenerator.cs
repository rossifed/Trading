using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
using System.Data;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{

    internal class FileContentGenerator : IFileContentGenerator
    {
        private IDataFetcher DataFetcher { get; }

        public FileContentGenerator(IDataFetcher dataFetcher)
        {
            DataFetcher = dataFetcher;
        }

        public FileContent GenerateFileContent(FileContentGenerationInfo fileGenerationProfile)
        {
            DataTable dataTable = DataFetcher.FetchData(fileGenerationProfile.FunctionName, fileGenerationProfile.PortfolioId);
            string separator = fileGenerationProfile.Separator;
            string header = GetHeader(dataTable, separator);
            string[] rows = GetRows(dataTable, separator);

            return new FileContent(header, rows);
        }


        private string GetHeader(DataTable dataTable, string separator)
        {
            string[] columnNames = new string[dataTable.Columns.Count];
            for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; columnIndex++)
            {
                columnNames[columnIndex] = dataTable.Columns[columnIndex].ColumnName;
            }
            return string.Join(separator, columnNames);
        }

        private string[] GetRows(DataTable dataTable, string separator)
        {
            List<string> rows = new List<string>();

            // For each row in the DataTable
            foreach (DataRow dataRow in dataTable.Rows)
            {
                string[] fields = new string[dataTable.Columns.Count];
                for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; columnIndex++)
                {
                    fields[columnIndex] = dataRow[columnIndex].ToString();
                }
                rows.Add(string.Join(separator, fields));
            }
            return rows.ToArray();
        }

    }
}
