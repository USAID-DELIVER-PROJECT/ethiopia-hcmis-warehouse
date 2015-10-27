using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Logging.Models
{
    public abstract class Log
	{
        public int LogID { get; set; }
        public int UserID { get; set; }
        public DateTime TimeStamp { get; set; }
	}
}
