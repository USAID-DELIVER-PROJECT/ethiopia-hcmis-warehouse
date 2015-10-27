using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;

namespace HCMIS.Security.UserManagement.ViewModels
{
    class GroupPermissionListViewModel
    {
        private Group group;
        public GroupPermissionListViewModel(IUnitOfWork repository, Group group)
        {
         
            this.group = group;
            // Existing group permissions 
            this.GroupPermissions = new List<GroupPermission>();
            
            var possibleOperations = group.MenuItemGroups.Select(gm => gm.MenuItem.Operations).ToList();
            foreach (var operations in possibleOperations)
            {
                foreach(var operation in operations)
                {
                    // check if the operation is already inserted
                    var entry = repository.GroupPermissions.FindBy(
                        p => p.GroupID == group.GroupID && p.OperationID == operation.OperationID).FirstOrDefault();
                    if (entry != null)
                    {
                        this.GroupPermissions.Add(entry);
                    }else
                    {
                        var gp = new GroupPermission()
                                     {
                                         Allow = false,
                                         Group = group,
                                         GroupID = group.GroupID,
                                         Operation = operation,
                                         OperationID = operation.OperationID
                                     };
                        repository.GroupPermissions.Add(gp);
                        this.GroupPermissions.Add(gp);
                    }
                    // 
                }
                
            }
        }

        public List<GroupPermission> GroupPermissions { get; set; }
    }
}
