using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMIS.Desktop.Helpers
{
    class QueryHelper
    {
        public static DataView RunQuery(string query)
        {
            BLL.ABC abc = new BLL.ABC();
            return abc.RunQuery(query);
        }
    }
}
