using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Modules.Requisition.Helpers;

namespace HCMIS.Modules.Requisition.Domain
{
    public enum Modes
    {
        [Code("HPR")]
        HeathProgram,
        [Code("RDF")]
        RDF
    }
}
