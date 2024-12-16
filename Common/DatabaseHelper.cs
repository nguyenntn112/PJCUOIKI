using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;

namespace EmployeeManagement.Common
{
    public static class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager
            .ConnectionStrings["OracleConnection"].ConnectionString;

        public static OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }
    }
}