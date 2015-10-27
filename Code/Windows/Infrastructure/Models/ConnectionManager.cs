using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Concrete.Models
{
    public class ConnectionManager
    {

        public static string ConnectionString { get; set; }

        public static void InitializeConnectionString(string connection)
        {
            ConnectionString = connection;
        }
    }
}
