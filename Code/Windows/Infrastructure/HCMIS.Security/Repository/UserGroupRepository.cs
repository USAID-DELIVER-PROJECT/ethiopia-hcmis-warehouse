using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.DataContext;
using HCMIS.Security.Models;

namespace HCMIS.Security.Repository
{
    public class UserGroupRepository : GenericRepository<SecurityContext,UserGroup>
    {
        public UserGroupRepository(SecurityContext context)
        {
            
            this.Context = context;
        }
        public override void Add(UserGroup entity)
        {
            base.Add(entity);
            var operations = Context.Set<GroupPermission>().Where(m => m.GroupID == entity.GroupID && m.Allow==true).Select(o => o.OperationID);
            //foreach (var operation in operations)
            //{
            //    Context.Set<Permission>().Add(new Permission()
            //                                {
            //                                    UserID = entity.UserID,
            //                                    OperationID = operation
            //                                });
            //}
            Context.SaveChanges();
        }

        public override void Delete(UserGroup entity)
        {
            base.Delete(entity);
            var operations = Context.GroupPermissions.Where(m => m.GroupID == entity.GroupID && m.Allow == true).Select(o => o.OperationID);
            //foreach (var operation in operations)
            //{
            //    var permission =
            //        Context.Set<Permission>().FirstOrDefault(p => p.UserID == entity.UserID && p.OperationID == operation);
            //    if(permission != null)
            //        Context.Permissions.Remove(permission);
            //}
            Context.SaveChanges();
        }

        public override void DeleteBy(System.Linq.Expressions.Expression<Func<UserGroup, bool>> predicate)
        {
            IQueryable<UserGroup> query = Context.Set<UserGroup>().Where(predicate);
            foreach (var entity in query)
            {
                Context.Set<UserGroup>().Remove(entity);
                var operations = Context.GroupPermissions.Where(m => m.GroupID == entity.GroupID && m.Allow == true).Select(o => o.OperationID);
                //foreach (var operation in operations)
                //{
                //    var permission =
                //        Context.Set<Permission>().FirstOrDefault(p => p.UserID == entity.UserID && p.OperationID == operation);
                //    if (permission != null)
                //        Context.Permissions.Remove(permission);
                //}
            }
            Context.SaveChanges();
        }
    }
}
