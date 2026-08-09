using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SafeUnsafeAdder
{
    /// <summary>
    /// All SQL Server access lives here so the form only deals with the user interface.
    /// The database is a local SQL Server LocalDB instance.
    /// </summary>
    internal class NumberRepository
    {
        private readonly string _masterConnectionString;
        private readonly string _appConnectionString;

        public NumberRepository()
        {
            _masterConnectionString = ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString;
            _appConnectionString = ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString;
        }

        /// <summary>
        /// Creates the database and the Numbers table the first time the app runs,
        /// so the project works on any machine without a manual setup step.
        /// </summary>
        public void EnsureDatabaseExists()
        {
            const string createDatabaseSql =
                "IF DB_ID('ICE2NumbersDb') IS NULL CREATE DATABASE [ICE2NumbersDb];";

            using (SqlConnection connection = new SqlConnection(_masterConnectionString))
            using (SqlCommand command = new SqlCommand(createDatabaseSql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            const string createTableSql =
                "IF OBJECT_ID('dbo.Numbers', 'U') IS NULL " +
                "CREATE TABLE dbo.Numbers (" +
                "    NumberId   INT IDENTITY(1,1) PRIMARY KEY, " +
                "    Value      INT NOT NULL, " +
                "    DateAdded  DATETIME NOT NULL DEFAULT GETDATE());";

            using (SqlConnection connection = new SqlConnection(_appConnectionString))
            using (SqlCommand command = new SqlCommand(createTableSql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Stores a single number in the database. Parameterised to avoid SQL injection.
        /// </summary>
        public void Insert(int value)
        {
            const string sql = "INSERT INTO dbo.Numbers (Value) VALUES (@value);";

            using (SqlConnection connection = new SqlConnection(_appConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add("@value", SqlDbType.Int).Value = value;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retrieves every stored number, oldest first.
        /// </summary>
        public List<int> GetAll()
        {
            const string sql = "SELECT Value FROM dbo.Numbers ORDER BY NumberId;";

            List<int> numbers = new List<int>();

            using (SqlConnection connection = new SqlConnection(_appConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        numbers.Add(reader.GetInt32(0));
                    }
                }
            }

            return numbers;
        }

        /// <summary>
        /// Empties the table so the demonstration can be run again from scratch.
        /// </summary>
        public void DeleteAll()
        {
            const string sql = "DELETE FROM dbo.Numbers;";

            using (SqlConnection connection = new SqlConnection(_appConnectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
