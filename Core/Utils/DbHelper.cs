using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ExamenAutomationSofka.Core.Utils
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
 
        public string GetSingleValue(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                var result = command.ExecuteScalar();
                return result?.ToString() ?? string.Empty;
            }
        }

        // Método para verificar si un registro existe 
        public bool RecordExists(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }
}