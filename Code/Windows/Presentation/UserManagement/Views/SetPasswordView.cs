using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Models;
using HCMIS.Security.Repository;
using HCMIS.Security.UserManagement.Helpers;
using HCMIS.Logging;
using HCMIS.Security.Helpers;


namespace HCMIS.Security.UserManagement.Views
{
    public partial class SetPasswordView : DevExpress.XtraEditors.XtraForm
    {
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("Some Page");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        public User CurrentUser { get; private set; }
        private static UnitOfWork _repository = UnitOfWork.CreateInstance();
        public SetPasswordView()
        {
            InitializeComponent();
        }
        public SetPasswordView(int userId): this()
        {
            this.CurrentUser = _repository.Users.FindBy(u => u.UserID == userId).SingleOrDefault();
            
        }
        
        private void okCommand_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;
            if (!passwordTextEdit.Text.Equals(confirmPasswordTextEdit.Text))
            {
                ViewHelper.ShowErrorMessage("The password was not correctly confirmed. Please ensure that the password and confirmation match exactly.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "Set Password Window", "The password was not correctly confirmed. Please ensure that the password and confirmation match exactly.");
                this.Close();
            }

            try
            {
                CurrentUser.SetPassword(passwordTextEdit.EditValue.ToString());
                _repository.Users.Update(CurrentUser);
               //SecurityHelper.ResetPassword(CurrentUser.UserName, passwordTextEdit.Text);
                ViewHelper.ShowSuccessMessage("User password has been set.");
                activityLogger.SaveAction(CurrentUser.UserID, 1, "Set Password Window", "User password set succesfully");   
                this.Close();
            }
            catch (Exception exception)
            {
                ViewHelper.ShowErrorMessage("Error occured while setting new password.", exception);
                errorLogger.SaveError(CurrentUser.UserID, 1, 1, 2, "Unable to set password", "Warehouse", exception);
            }
        }

        private bool validateForm()
        {
            return resetPasswordValidation.Validate();
        }

        private void cancelCommand_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}