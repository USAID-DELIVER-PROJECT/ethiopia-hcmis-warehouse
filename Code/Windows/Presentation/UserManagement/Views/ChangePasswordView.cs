using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Helpers;
using HCMIS.Security.UserManagement.Helpers;
using System.Threading;
using HCMIS.Security.Repository;
using HCMIS.Logging;


namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-MA-CP-FR")]
    public partial class ChangePasswordView : DevExpress.XtraEditors.XtraForm
    {
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("UM-MA-CP-FR");

        IUnitOfWork repository = UnitOfWork.CreateInstance();
        public ChangePasswordView()
        {
            InitializeComponent();
           
        }

        private void cancelCommand_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoChangePassword()
        {
            if (!ValidateForm())
            {
                lblMessage.Text = "Please provide the correct Old Password";
                Exception exception = new Exception("New & confirmed passwords doesn't match.");
            }else
            {
                lblMessage.Text = "";
            }

            if (newPasswordTextEdit.Text != confirmpasswordtextEdit.Text)
            {
                ViewHelper.ShowErrorMessage("New & confirmed passwords doesn't match.");
                activityLogger.SaveAction(repository.Users.FindByName(Thread.CurrentPrincipal.Identity.Name).UserID, 1,
                                          "Change Password Window", "New & confirmed passwords doesn't match.");
            }

            else if (SecurityHelper.ChangePassword(repository, Thread.CurrentPrincipal.Identity.Name, oldPasswordTextEdit.Text,
                                                   newPasswordTextEdit.Text))
            {
                ViewHelper.ShowSuccessMessage("Password changed successfully.");
                activityLogger.SaveAction(repository.Users.FindByName(Thread.CurrentPrincipal.Identity.Name).UserID, 1,
                                          "Change Password Window", "Password changed successfully.");
                this.Close();
            }
        }

        private bool ValidateForm()
        {
            return ChangePasswordValidation.Validate();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            DoChangePassword();
        }

     }
}