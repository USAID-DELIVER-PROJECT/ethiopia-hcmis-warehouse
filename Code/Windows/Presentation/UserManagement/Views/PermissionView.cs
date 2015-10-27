using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Helpers;
using HCMIS.Security.Repository;
using HCMIS.Security.Models;
using HCMIS.Security.UserManagement.ViewModels;
using System.Collections.Generic;
using HCMIS.Logging;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class PermissionView : DevExpress.XtraEditors.XtraForm
    {
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("Some Page");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        public User CurrentUser { get; private set; }
        IUnitOfWork repository = UnitOfWork.CreateInstance();

        //private static List<Permission> permission;
        //public PermissionView()
        //{
        //    InitializeComponent();
        //    permission =new List<Permission>();


            
        //}

        public PermissionView(int userId)
        {
            
            InitializeComponent();
           
            this.CurrentUser = repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
            loadlookup();
            //var viewmodel = new PermissionListViewModel(this.CurrentUser.Permissions.ToList());
            //permissionbindingSource.DataSource = viewmodel.Permissions;
        }

        private void loadlookup()
        {
            operationbindingSource.DataSource = repository.Operations.GetAll().ToList();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnSavePermission_Click(object sender, EventArgs e)
        {
          
            //permissionbindingSource.EndEdit();
            //var obj = permissionbindingSource.DataSource as List<Permission>;
            //if (obj != null)
            //    try
            //    {
            //        foreach (var permission in obj)
            //        {
            //            this.CurrentUser.Permissions.Add(permission);
            //        }
            //        repository.Users.Update(this.CurrentUser);
            //         activityLogger.SaveAction(CurrentUser.UserID, 1, "User Permission Window", "User Permission  updated Succesfully");   
                   
            //        permissionbindingSource.DataSource = repository.Permissions.GetAll().ToList();
            //        this.Close();

            //    }
            //    catch (Exception ex)
            //    {

            //        ViewHelper.ShowErrorMessage("Unable to update Permission!", ex);
            //        errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Update user permission attempt", "Warehouse", ex);
            //    }
            
        }       

        private void permissionbindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            btnSavePermission.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh(this.CurrentUser.UserID);  
        }
        public void Refresh(int userId)
        {
           
            this.CurrentUser = repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
            loadlookup();
            //var viewmodel = new PermissionListViewModel(this.CurrentUser.Permissions.ToList());
            //permissionbindingSource.DataSource = viewmodel.Permissions;
            
        }

        
        
    }
}