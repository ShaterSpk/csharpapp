using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolDatabase.Backend
{
    class DbConnection
    {
        private SqlConnection connection;

        public DbConnection()
        {
            connection = new SqlConnection("Data Source = csharpapptest.database.windows.net; Initial Catalog = csharpapp; User ID = Shather; Password = Mi57062694; Connect Timeout = 60; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }

        public SqlConnection Connection { get => connection; }
    }
}
