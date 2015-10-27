using System.Security.Principal;
using HCMIS.Security.Common.DataContracts;

namespace HCMIS.Security.Common
{
   public class UserIdentity : IIdentity
    {
        #region Fields
        private const string _authenticationType = "Database Authentication";
        private string _username;
        #endregion

        private UserIdentity(string username)
        {
            this._username = username;
        }

        
        #region IIdentity Members
        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string AuthenticationType
        {
            get { return _authenticationType; }
        }

        public string Name
        {
            get { return this._username; }
        }

        #endregion

        public int UserID { get; set; }

        public string FullName { get; set; }

        internal static UserIdentity CreateUserIdentity(int userId, string username)
        {
            return new UserIdentity(username)
                       {
                           UserID = userId
                       };
        }

        internal static UserIdentity CreateUserIdentity(UserInformation userInfo)
        {
            return new UserIdentity(userInfo.Username)
            {
                UserID = userInfo.UserID,
                FullName = userInfo.FullName,
                
            };
        }

     
    }
}
