using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Models;

namespace HCMIS.Security.UserManagement.ViewModels
{
    class AccountListViewModel
    {
        public AccountListViewModel(List<AccountUser> Accounts)
        {
            this.Account = Accounts;
          
        }
        public List<AccountUser> Account { get; set; }

    }
}
