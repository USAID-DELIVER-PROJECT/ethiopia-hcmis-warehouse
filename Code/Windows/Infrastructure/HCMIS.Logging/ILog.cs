using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Logging
{
    public interface ILog
    {
        void Setup(string connectionString);
    }
}
