using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class SchemaScript
    {
        public int ID { get; set; }
        public string ScriptName { get; set; }
        public Nullable<System.DateTime> DateApplied { get; set; }
        public Nullable<bool> Successful { get; set; }
    }
}
