using Microsoft.Extensions.Options;
using System;
using System.Configuration;

namespace WebApiCore.Configuration
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        //---conection to database---
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        }
    }
}
