using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMIS.Repository.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class Schema : Attribute
    {
        public string Name { get; set; }

        public Schema(string schemaName)
        {
            Name = schemaName;
        }
    }
}
