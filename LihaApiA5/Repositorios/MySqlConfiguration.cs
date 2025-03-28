using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIhaApiA5.Data.Repositorios
{
    public class MySqlConfiguration
    {
        public MySqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
    }

    public class MySqlConfiguration2
    {
        public MySqlConfiguration2(string connectionString2)
        {
            ConnectionString2 = connectionString2;
        }
        public string ConnectionString2 { get; set; }
    }

}
