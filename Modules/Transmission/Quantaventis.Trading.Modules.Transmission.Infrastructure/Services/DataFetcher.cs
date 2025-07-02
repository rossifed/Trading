using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{
    internal interface IDataFetcher {

       
        DataTable FetchData(string viewName);

        DataTable FetchData(string functionName, int portfolioId);

    }
    internal class DataFetcher : IDataFetcher
    {
       private  TransmissionDbContext DbContext { get; }

        public DataFetcher(TransmissionDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DataTable FetchData(string viewName)
        {
           string connectionString = DbContext.Database.GetDbConnection().ConnectionString;
        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT * FROM {viewName}", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public DataTable FetchData(string functionName, int portfolioId)
        {
            string connectionString = DbContext.Database.GetDbConnection().ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Construct the SQL query to call the function with a parameter
                string sqlQuery = $"SELECT * FROM {functionName}(@PortfolioId)";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Add the portfolioId as a parameter to the SQL command
                    command.Parameters.AddWithValue("@PortfolioId", portfolioId);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }


    }
}
