using System.Data.SqlClient;
using WebApiCore.Configuration;

namespace WebApiCore.Repository
{
    public class DatabaseConnectionProvider:IDatabaseConnectionProvider
    {
        private readonly IConnectionStringProvider _connectionStringProvider;
        //---conect to database---

        public DatabaseConnectionProvider(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        //--open conection---
        public SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_connectionStringProvider.GetConnectionString());
            connection.Open();
            return connection;
        }
    }
}
