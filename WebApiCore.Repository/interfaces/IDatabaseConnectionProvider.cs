using System.Data.SqlClient;

namespace WebApiCore.Repository
{
    public interface IDatabaseConnectionProvider
    {
        //---interface od DatabaseConnectionProvider---
        SqlConnection GetOpenConnection();
    }
}