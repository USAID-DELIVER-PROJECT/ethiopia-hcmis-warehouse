using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Models;

namespace HCMIS.Security.UserManagement.ViewModels
{
    class StoreListViewModel
    {
        public StoreListViewModel(List<StoreUser> storeuserlist)
        {
            this.storeslist = storeuserlist;
        }
        public List<StoreUser> storeslist { get; set; }
    }
}
