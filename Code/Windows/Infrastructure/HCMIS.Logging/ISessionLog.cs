using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Logging
{
    public interface ISessionLog : ILog
    {
        Guid Login(int userId);
        //void KeepAlive(int userId, DateTime time);
        void Logout(Guid sessionID);
    }
}
