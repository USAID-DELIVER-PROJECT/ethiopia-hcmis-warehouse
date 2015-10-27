using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;

namespace HCMIS.Security.MVC
{
    class MembershipProvider : System.Web.Security.MembershipProvider
    {
        private UserRepository _repository;

        public MembershipProvider()
        {
            this._repository = new UserRepository();
        }

        public override string ApplicationName 
        {
            get { return "HCMIS"; }
            set { return; }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = _repository.FindBy(u => u.Username == username).SingleOrDefault();
            if (user == null || !user.CheckPassword(oldPassword))
                return false;
            user.SetPassword(newPassword);
            _repository.Update(user);
            return true;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            if (_repository.FindBy(u => u.Username == username).FirstOrDefault() == null)
            {
                status = MembershipCreateStatus.InvalidUserName;
                return null;
            }
            var user = new User
                           {
                               Username = username,
                           };
            user.SetPassword(password);
            _repository.Add(user);
            status = MembershipCreateStatus.Success;
            return GetUser(username,true);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            var user = _repository.FindBy(u => u.Username == username).SingleOrDefault();
            if (user == null)
                return false;
            _repository.Delete(user);
            return true;
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = _repository.FindBy(u => u.Username == username).SingleOrDefault();
            if(user == null)
                return null;
            return new MembershipUser("MembershipProvider",user.Username,user.UserID,string.Empty,string.Empty,string.Empty,true,!user.IsActive,user.CreatedDate.Value,DateTime.MinValue,DateTime.MinValue,DateTime.MinValue,DateTime.MinValue);
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Web.Security.MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var user = _repository.FindBy(u => u.Username == username && u.CheckPassword(password)).SingleOrDefault();
            if (user == null)
                return false;
            return true;
        }
    }
}
