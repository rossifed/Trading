using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
using System.Data;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Services
{
    internal interface IFileIntegrationService
    {
        Task InsertCsvToTableAsync(string tableName, DataTable csvDataTable);
    }
    internal class FileIntegrationService : IFileIntegrationService
    {
        private readonly TradesDbContext _context;

        public FileIntegrationService(TradesDbContext context)
        {
            _context = context;
        }
        private async Task TruncateTableAsync(string tableName)
        {
            var command = $"TRUNCATE TABLE {tableName}";
            await _context.Database.ExecuteSqlRawAsync(command);
        }

        public async Task ReplaceCsvToTableAsync(string tableName, DataTable csvDataTable) {
            await TruncateTableAsync(tableName);
            await InsertCsvToTableAsync(tableName, csvDataTable);
        }
        public async Task InsertCsvToTableAsync(string tableName, DataTable csvDataTable)
        {
            StringBuilder insertQueryBuilder = new StringBuilder($"INSERT INTO {tableName} (");
            char[] replacedChars = new char[] { ' ', '/', '-' };

            string ReplaceChars(string column, char[] replacedChars)
            {
                return string.Concat(column.Select(c => replacedChars.Contains(c) ? '_' : c));
            }
            // Column names
            var columnNames = csvDataTable.Columns.Cast<DataColumn>().Select(column => $"[{ReplaceChars(column.ColumnName, replacedChars)}]").ToList();
            insertQueryBuilder.Append(string.Join(", ", columnNames));

            insertQueryBuilder.Append(") VALUES ");

        
            // Values from DataTable rows
            var rows = csvDataTable.AsEnumerable().Select(row =>
            {
                var values = row.ItemArray.Select(val => $"'{val.ToString().Replace("'", "''")}'");
                return $"({string.Join(", ", values)})";
            });

            insertQueryBuilder.Append(string.Join(", ", rows));

            await _context.Database.ExecuteSqlRawAsync(insertQueryBuilder.ToString());
        }
    }
}
