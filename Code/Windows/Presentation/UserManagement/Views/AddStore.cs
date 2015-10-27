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

namespace HCMIS.Security.UserManagement.Views
{
    public partial class AddStore : DevExpress.XtraEditors.XtraForm
    {
        public User CurrentUser { get; private set; }
        IUnitOfWork repository;
        private List<StoreUser> storeUser;
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("Some Page");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        public AddStore(UnitOfWork repo)
        {
            repository = repo;
            InitializeComponent();
            LoadStores();
            storeUser = new List<StoreUser>();
            userstorebindingSource.DataSource = storeUser;
        }
        public AddStore(int userId, UnitOfWork repo)
        {
            repository = repo;
            InitializeComponent();
            this.CurrentUser = repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
            LoadStores();
            var viewmodel = new StoreListViewModel(this.CurrentUser.StoreUsers.ToList());
            userstorebindingSource.DataSource = viewmodel.storeslist;
        }

        private void LoadStores()
        {
           
            var allstores = repository.Stores.FindBy(o=>o.Warehouse != null).ToList().OrderBy(o=>o.FullName).ToList();
            if (CurrentUser.StoreUsers != null)
            {
                var stores = from c in CurrentUser.StoreUsers where c.IsActive select c.Store;
                foreach (var store in stores)
                {
                    if (stores.Where(s => s.StoreID == store.StoreID).Count() > 0)
                    {
                        var a = allstores.SingleOrDefault(c => c.StoreID == store.StoreID);
                        allstores.Remove(a);
                    }
                }

            }
            storelistbindingSource.DataSource = allstores;
        }

        private void btnStoreSave_Click(object sender, EventArgs e)
        {
            if (storelistBox.SelectedItem == null)
            {
                ViewHelper.ShowErrorMessage("There is no store to be added.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "User Store Window", "There is no store to be added."); 
                this.Close();
            }
            userstorebindingSource.EndEdit();
            var obj = userstorebindingSource.DataSource as List<StoreUser>;
            try
            {

                var selectedItems = storelistBox.SelectedItems;
               foreach (var anItem in selectedItems)
               {
                   var item = anItem as Store;

                   // check if there is a diabled store entity
                   var aStore = repository.StoreUsers.FindBy(s => s.UserID == CurrentUser.UserID && s.StoreID == item.StoreID).
                           FirstOrDefault();
                   if (aStore != null)
                   {
                       aStore.IsActive = true;
                       repository.StoreUsers.Update(aStore);
                   }
                   else
                   {

                       var storeuser = new StoreUser
                                           {
                                               StoreID = item.StoreID,
                                               UserID = CurrentUser.UserID,
                                               IsActive = true
                                           };
                       repository.StoreUsers.Add(storeuser);
                       activityLogger.SaveAction(CurrentUser.UserID, 1, "User Store Window",
                                                 "User store added Succesfully");
                   }

               }
               this.Close();
            }
            catch (Exception ex)
            {
                ViewHelper.ShowErrorMessage("Unable to create store",ex);
                errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Add store attempt", "Warehouse", ex);
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddStore_Load(object sender, EventArgs e)
        {
            // A hack to clear the selection.
            storelistBox.SelectionMode = SelectionMode.None;
            storelistBox.SelectionMode = SelectionMode.MultiSimple;
        }

       
    }
}