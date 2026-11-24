using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

using Microsoft.Data.SqlClient;

namespace Dal
{
    public class DbConnection
    {
        private readonly string _connectionString;

        public DbConnection()
        {
            // Usa el mismo Server Name que te funcionó al conectar database.sql
           // _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BookstoreDB;Integrated Security=True;TrustServerCertificate=True;";
            _connectionString = ConfigurationManager.ConnectionStrings["BookstoreDB"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}