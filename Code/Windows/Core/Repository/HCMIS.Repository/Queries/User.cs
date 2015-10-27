using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Repository.Queries
{
    public class User
    {
        public static string SelectGetUsers()
        {
            string query = String.Format("SELECT v.*,ut.Type as UserTypeName FROM vwGetUsers v join UserType ut on v.UserType = ut.ID  Order By FullName");
            return query;
        }

        public static string SelectLoadByPrimaryKey(int ID)
        {
            string query = String.Format("Select * from [user] where ID={0}", ID);
            return query;
        }

        public static string SelectGetUserByAccountInfo(string userName, string password, string encriptedPassword)
        {
            string query = String.Format("select * from [User] where UserName = '{0}' and Active = 1 and (Password = HASHBYTES ('MD5','{1}') or Password = '{2}')",
                userName, password, encriptedPassword);
            return query;
        }

        public static string UpdateSavePassword(string newPassword, int userID)
        {
            string query = String.Format("update [User] set Password = HASHBYTES ('MD5','{1}') where ID = {0}", userID,
                newPassword);
            return query;
        }
        public static string SelectDoesUserHaveFinancialRights(int id)
        {
            string query = String.Format("SELECT * FROM Stores where ID in (Select StoreID from UserStore WHERE UserID ={0}) and UsesMovingAverage=1", id);
            return query;
        }

        public static string SelectGetUsersExceptSysAdmins(int superAdmin)
        {
            return String.Format(
                "SELECT v.*,ut.Type as UserTypeName FROM vwGetUsers v join UserType ut on v.UserType = ut.ID Where v.UserType<>{0} Order By FullName",
                superAdmin);
        }
    }
}
