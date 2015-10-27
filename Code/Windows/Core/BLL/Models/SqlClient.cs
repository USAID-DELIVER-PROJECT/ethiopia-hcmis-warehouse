using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MyGeneration.dOOdads;

namespace BLL
{
    public class SqlClient: SqlClientEntity
    {
        public void Load(string query )
        {
            this.LoadFromSql(query);
        }

        public static DataView Run(string query)
        {
            var customSqlClient = new SqlClient();
            customSqlClient.LoadFromRawSql(query);
            return customSqlClient.DefaultView;
        }
    }
}
