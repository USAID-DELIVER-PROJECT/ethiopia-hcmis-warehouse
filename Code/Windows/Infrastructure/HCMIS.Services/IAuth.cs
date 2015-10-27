using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using HCMIS.Security.Common.DataContracts;

namespace HCMIS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuth" in both code and config file together.
    [ServiceContract]
    public interface IAuth
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        UserInformation Authenticate(string username,string password);
    }
}
