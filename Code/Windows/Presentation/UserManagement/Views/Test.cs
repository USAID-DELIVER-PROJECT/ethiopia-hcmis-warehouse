using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Repository;
using HCMIS.Security.Models;
using HCMIS.Logging;
using HCMIS.Security.UserManagement.ViewModels;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class Test : DevExpress.XtraEditors.XtraForm
    {
        public User CurrentUser { get; private set; }
        private static UserRepository _repository = new UserRepository();
        private static AccountUserRepositroy accountuserRepository = new AccountUserRepositroy();
        private static AccountRepository accountRepository = new AccountRepository();
        private List<AccountUser> userAccount;
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("Some Page");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        public Test()
        {
            InitializeComponent();
            //Loadaccounts();
            //var viewModel = new AccountListViewModel(this.CurrentUser.AccountUsers.ToList());
            //accountuserbindingSource.DataSource = viewModel.Account;
        }
        public Test(int userId)
        {
            InitializeComponent();
            this.CurrentUser = _repository.FindBy(u => u.UserID == userId).SingleOrDefault();
            Loadaccounts();
            var viewModel = new AccountListViewModel(this.CurrentUser.AccountUsers.ToList());
            accountuserbindingSource.DataSource = viewModel.Account;
         }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var obj = accountuserbindingSource.DataSource as List<AccountUser>;
            foreach (var item in obj)
            { 
           
            var accountUser = new AccountUser
            {
                AccountID = item.AccountID,
                UserID = CurrentUser.UserID,
                //AccountStatus = true
            };
            accountuserRepository.Add(accountUser);

                
            }
        }
        private void Loadaccounts()
        {
            accountRepository = new AccountRepository();
            var allAccounts = accountRepository.GetAll().ToList();
            accountlistbindingSource.DataSource = allAccounts;
            //if (CurrentUser.AccountUsers != null)
            //{
            //    var accounts = from c in CurrentUser.AccountUsers select c.Account;
            //    foreach (var account in accounts)
            //    {
            //        if (accounts.Where(a => a.AccountID == account.AccountID).Count() > 0)
            //        {
            //            var a = allAccounts.SingleOrDefault(c => c.AccountID == account.AccountID);
            //            allAccounts.Remove(a);
            //        }
            //    }
            //}
          
        }
    }
}