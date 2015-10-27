using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Models;

namespace HCMIS.Security.UserManagement.ViewModels
{
    class GroupsListViewModel
    {
        public GroupsListViewModel(List<UserGroup> userGroupList)
        {
            this.Grouplist = userGroupList;
        }
        public List<UserGroup> Grouplist { get; set; }
    }
}
