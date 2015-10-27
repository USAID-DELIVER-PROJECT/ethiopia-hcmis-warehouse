using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class Program
    {
        public static string SelectGetAllPrograms()
        {
            return String.Format("SELECT * FROM Program");
        }
    }
}
