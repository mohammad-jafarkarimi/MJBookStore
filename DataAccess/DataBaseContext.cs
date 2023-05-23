using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class DataBaseContext : IDisposable
    {
        private const string _connectionStringMaster = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

        public SqlConnection connection { get; private set; }
        public DataBaseContext()
        {
            connection = new SqlConnection(_connectionStringMaster);
            connection.Open();
        }

        public void Dispose()
        {
           connection.Close();
        }
    }
}
