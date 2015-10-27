using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Repository.Queries
{
    public class DateTimeHelper
    {
        public static string SelectGetDateAsDate()
        {
            const string query = "SELECT GETDATE() as DATE";
            return query;
        }
    }
}
