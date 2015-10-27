using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.DataContext;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;
using HCMIS.Security.DataContext;
using HCMIS.Security.Repository;
using System.Threading;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class CreateUserView : DevExpress.XtraEditors.XtraForm
    {
        IUnitOfWork repository = UnitOfWork.CreateInstance();

        private User newuser;

        public CreateUserView()
        {
            InitializeComponent();
            loadlookup();
            newuser = new User();
            userBindingSource.DataSource = newuser;
        }

        private void loadlookup()
        {
            departmentbindingSource.DataSource= repository.Departments.GetAll().ToList();
            jobtitlebindingSource.DataSource = repository.JobTitles.GetAll().ToList();
         }
        
        private void createCommand_Click(object sender, EventArgs e)
        {
            userBindingSource.EndEdit();
            if (!ValidateForm()) return;
            try
           {
               newuser.SetPassword(newuser.Password);
               newuser.IsActive = true;
               newuser.CreatedDate = Security.Helpers.DateTimeHelper.ServerDateTime;
               repository.Users.Add(newuser);
               ViewHelper.ShowSuccessMessage("New user created successfully!");
               this.DialogResult =DialogResult.OK;
               this.Close();
            }
            catch (Exception ex)
            {
                ViewHelper.ShowErrorMessage("Unable to create new user",ex);
            }
            
          
         }

         private void closeCommand_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public bool ValidateForm()
        {
            return NewUserValidation.Validate();
            
        }
       
        
        
    }
}