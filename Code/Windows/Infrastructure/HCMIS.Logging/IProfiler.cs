using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Logging
{
    public interface IProfiler
    {
        Guid StartOperation(int userId, string page , string action);
        void EndOperation(Guid operationId);
    }
}
