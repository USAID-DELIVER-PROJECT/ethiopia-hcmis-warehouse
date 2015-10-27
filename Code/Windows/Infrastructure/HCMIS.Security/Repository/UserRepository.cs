using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HCMIS.Security.Common;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class UserRepository : GenericRepository<SecurityContext, User>
    {
       
        public UserRepository(SecurityContext context)
        {
            this.Context = context;
        }

        public UserRepository()
        {
            // TODO: Complete member initialization
        }
        public override void Add(User entity)
        {
            if (this.UsernameIsAvailable(entity.UserName))
            {
                entity.CreatedDate = Helpers.DateTimeHelper.ServerDateTime;
                base.Add(entity);
                return;
            }
            throw new ArgumentException("A user with the supplied username already exists.");
        }

        public User FindByName(string username)
        {
            return Context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public bool UsernameIsAvailable(string username)
        {
            return Context.Users.SingleOrDefault(u => u.UserName == username) == null;
        }

        public IQueryable<User> Search(string query)
        {
            return Context.Users.Where(u => u.UserName.Contains(query) || u.FirstName.Contains(query) || u.LastName.Contains(query));
        }

       
    }
}
