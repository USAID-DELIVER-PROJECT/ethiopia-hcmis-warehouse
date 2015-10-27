using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;
using HCMIS.Security.Helpers;


namespace HCMIS.Security.MVC
{
    public sealed class CustomMembershipProvider : System.Web.Security.MembershipProvider
    {
        #region Fields
        private readonly UnitOfWork _repository;
       
        

        #endregion

        #region MembershipProvider Members
        public CustomMembershipProvider()
        {
            this._repository = UnitOfWork.CreateInstance();
        }

        public override string ApplicationName 
        {
            get { return "HCMIS"; }
            set 
            {
                if(value!="HCMIS")
                    return;
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            var user = _repository.Users.FindBy(u => u.UserName == username).SingleOrDefault();
            if (user == null || !user.CheckPassword(oldPassword))
                return false;
            user.SetPassword(newPassword);
            _repository.Users.Update(user);
            return true;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
        {
            if (_repository.Users.FindBy(u => u.UserName == username).FirstOrDefault() == null)
            {
                status = MembershipCreateStatus.InvalidUserName;
                return null;
            }
            var user = new User
                           {
                               UserName = username,
                           };
            user.SetPassword(password);
            _repository.Users.Add(user);
            status = MembershipCreateStatus.Success;
            return GetUser(username,true);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            var user = _repository.Users.FindBy(u => u.UserName == username).SingleOrDefault();
            if (user == null)
                return false;
            _repository.Users.Delete(user);
            if(deleteAllRelatedData)
            {
                
            }
            return true;
        }

        public override bool EnablePasswordReset
        {
            get { return true; }
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
            var user = _repository.Users.FindBy(u => u.UserName == username).SingleOrDefault();
            if(user == null)
                return null;
            return new MembershipUser("MembershipProvider",user.UserName,user.UserID,string.Empty,string.Empty,string.Empty,true,!user.IsActive,user.CreatedDate.Value,DateTime.MinValue,DateTime.MinValue,DateTime.MinValue,DateTime.MinValue);
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
            var user = _repository.Users.FindByName(userName);
            if (user == null || user.IsActive)
                return false;
            user.IsActive = true;
            _repository.Users.Update(user);
            return true;
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var user = _repository.Users.FindBy(u => u.UserName == username && u.CheckPassword(password)).SingleOrDefault();
            if (user == null)
                return false;
            return true;
        }

        #endregion


    }
}
