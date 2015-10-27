using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;
using HCMIS.Security.UserManagement.ViewModels;
using HCMIS.Logging;
using System.Threading;
using HCMIS.Security.Common;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class AddAccount : DevExpress.XtraEditors.XtraForm
    {
        public User CurrentUser { get; private set; }
        
        IUnitOfWork repository;
        private List<AccountUser> userAccount;
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("Some Page");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        public AddAccount(UnitOfWork repo)
        {
            repository = repo;
            InitializeComponent();
            Loadaccounts();
            userAccount = new List<AccountUser>();
            accountuserbindingSource.DataSource = userAccount;
        }

        public AddAccount(int userId, UnitOfWork repo)
        {
            repository = repo;
            InitializeComponent();
            this.CurrentUser = repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
            Loadaccounts();
            var viewModel = new AccountListViewModel(this.CurrentUser.AccountUsers.ToList());
            accountuserbindingSource.DataSource = viewModel.Account;
         }

        private void Loadaccounts()
        {
          
            var allAccounts = repository.Accounts.FindBy(o=>o.SubAccount != null).ToList().OrderBy(o=>o.FullName).ToList();
            if (CurrentUser.AccountUsers != null)
            {
                var accounts = from c in CurrentUser.AccountUsers where c.IsActive select c.Account;
                foreach (var account in accounts)
                {
                    if (accounts.Where(a => a.ActivityID == account.ActivityID).Count() > 0)
                    {
                        var a = allAccounts.SingleOrDefault(c => c.ActivityID == account.ActivityID);
                        allAccounts.Remove(a);
                    }
                }
            }
            accountbindingSource.DataSource = allAccounts;
        }

       private void BtnSaveAccountClick(object sender, EventArgs e)
        {
            if (accountlistBox.SelectedItem == null)
            {
                ViewHelper.ShowErrorMessage("There is no account to be added.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "User Account list", "There is no account to be added.");
                this.Close();
            }
          accountuserbindingSource.EndEdit();
          var obj = accountuserbindingSource.DataSource as List<AccountUser>;       
           try
           {
               var selectedItems = accountlistBox.SelectedItems;
               foreach (var anItem in selectedItems)
               {
                   var item = anItem as Activity;
                   // check if there is a deactivated account by the same account id
                   var aUser =
                       repository.AccountUsers.FindBy(u => u.UserID == CurrentUser.UserID && u.AccountID == item.ActivityID).FirstOrDefault();

                   if (aUser != null)
                   {
                       aUser.IsActive = true;
                       repository.AccountUsers.Update(aUser);
                   }
                   else
                   {

                       var accountUser = new AccountUser
                                             {
                                                 AccountID = item.ActivityID,
                                                 UserID = CurrentUser.UserID,
                                                 IsActive = true
                                             };

                       repository.AccountUsers.Add(accountUser);
                   }
               }
              
               activityLogger.SaveAction(CurrentUser.UserID, 1, "User Account list", "Account Succesfully Added");                  
               this.Close();
           }
           catch (Exception ex)
           {
               ViewHelper.ShowErrorMessage("Unable to create account", ex);
               errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Add account attempt", "Warehouse", ex);

           }
       }
              
       private void BtnCloseClick(object sender, EventArgs e)
       {
           this.Close();
       }

       private void NewAccountView_FormClosing(object sender, FormClosingEventArgs e)
       {
           Refreshlist();
       }
       public void Refreshlist()
       {
           
       }

       private void AddAccount_Load(object sender, EventArgs e)
       {
           // A hack to clear the selection.
           accountlistBox.SelectionMode = SelectionMode.None;
           accountlistBox.SelectionMode = SelectionMode.MultiSimple;
       }

      

    }
}