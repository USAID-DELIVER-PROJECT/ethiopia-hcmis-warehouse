using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Core.Distribution.Services
{
   public class PrintLogMeta
    {
        public int Reference { get; set; }

        public string Type { get; set; }

        public DateTime PrintedDate { get; set; }

        public int ID { get; set; }

        public int? PrintedID { get; set; }

        public string Description { get; set; }
    }
}
