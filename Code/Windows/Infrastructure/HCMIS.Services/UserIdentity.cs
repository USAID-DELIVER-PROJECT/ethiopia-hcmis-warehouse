using System.Security.Principal;

namespace HCMIS.Services
{
    class UserIdentity : IIdentity
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

        public static UserIdentity CreateUserIdentity(string username)
        {
            return new UserIdentity(username);
        }
    }
}
