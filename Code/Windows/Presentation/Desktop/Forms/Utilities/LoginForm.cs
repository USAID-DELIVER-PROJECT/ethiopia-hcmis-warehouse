using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using System.ComponentModel;
using HCMIS.Concrete.Models;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Properties;
using HCMIS.Desktop.ViewModels;
using HCMIS.Desktop.Views;
using HCMIS.Security;
using HCMIS.Security.Common;
using HCMIS.Security.Common.DataContracts;
using HCMIS.Shared.Connection;
using LoginLog = BLL.LogLogin;
using User = BLL.User;
using System.Collections.Generic;

namespace HCMIS.Desktop
{
    public partial class LoginForm : XtraForm
    {
        public static LoginForm Instance;
        private BackgroundWorker bwSendAdditional;
        public LoginForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
            UserInformation userInfo = null;
            try
            {
                if (BLL.Settings.UseNewUserManagement)
                {
                   userInfo  = Auth.Authenticate(txtUsername.Text, txtPassword.Text);
                    if (userInfo == null)
                    {
                        //errorLogger.SaveError(0, 1, 1, 2, "Login Attempt", "Warehouse", new InvalidCredentialException("Invalid credentials, Username = " + username));
                        //return false;
                    }
                    Thread.CurrentPrincipal = SecurityPrincipal.CreateSecurityPrincipal(userInfo);
                    JiraHelper.SetupHelper();
                }

                User us = new User();
                us.GetUserByAccountInfo(txtUsername.Text, txtPassword.Text);

                // Just incase the password was saved using the new tool, it would create a problem
                // this is to fix that.
                if (userInfo != null && BLL.Settings.UseNewUserManagement)
                {
                    us.LoadByPrimaryKey(userInfo.UserID);
                }

                if (us.RowCount > 0)
                {
                    LogUserIn(us);
                }
                else
                {
                    BLL.LogLogin newLoginLog = new LoginLog();
                    newLoginLog.AddNew(null, DateTimeHelper.ServerDateTime, false, Environment.MachineName, "", "", true, txtUsername.Text, Program.HCMISVersionString);
                    if (XtraMessageBox.Show(@"Invalid Username or Password!", @"Login Failed", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
                    {
                        Application.Exit();
                    }
                    else
                    {
                       
                    }
                }
            }
            catch
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    //ConnectionStringManager.ConnectionStringManager connMgr =
                    //    new ConnectionStringManager.ConnectionStringManager(Program.RegKey,
                    //                                                        Program.PrevConnectionStringKey);
                    //connMgr.ShowDialog();
                }
                else
                {
                    XtraMessageBox.Show("Network error.  Please make sure your network connection is working.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Clear the login form
            txtPassword.Text = "";
            txtUsername.Text = "";
            txtUsername.Focus();
        }

        private void LogUserIn(User us)
        {
            // Now change the connection string to have the user id in the application name... 
            ConnectionHelper.CurrentConnection.ApplicationName = string.Format("HCMIS-Warehouse-V-{0}-U-{1}",Program.HCMISVersionString,us.ID);
            
            // Re-register the connection string manager here.

            MyGeneration.dOOdads.BusinessEntity.RegistryConnectionString = ConnectionHelper.CurrentConnection.ToString();
            ConnectionManager.ConnectionString = ConnectionHelper.CurrentConnection.ToString();

            if (BLL.Settings.UseNewUserManagement)
            {
                // Idealy, this has to work, but we don't know the kind of code that depends on the legacy new main window object.
                var menuItems = MenuListViewModel.GenerateMenuForUser(((UserIdentity)Thread.CurrentPrincipal.Identity).UserID);
                MainWindow mainWindow = new MainWindow(menuItems);

                //Legacy Code ... Remove this when not in use.
                CurrentContext main = new CurrentContext();
                CurrentContext.UserId = us.ID;
                CurrentContext.LoggedInUser = us;
                CurrentContext.LoggedInUserName = string.Format("{0} {1}", us.FirstName, us.LastName);

                if(string.IsNullOrEmpty(CurrentContext.LoggedInUserName) )
                {
                    CurrentContext.LoggedInUserName = us.UserName;
                }

                mainWindow.Show();
                this.Hide();

            }
           
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                BLL.LogLogin newLoginLog = new LoginLog();
                newLoginLog.AddNew(us.ID, DateTimeHelper.ServerDateTime, true, Environment.MachineName, "", "",
                                   false, "", Program.HCMISVersionString);
                // Also update the last login time on the User Object
                
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtUsernameKeyDown(object sender, KeyEventArgs e)
        {
            // if this is a debugging session login automattically
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // this has to be removed after development
                if (e.Control && e.Alt)
                {
                       if (txtUsername.Text == "")
                    {
                        txtUsername.Text = "su";
                    }
                   UserInformation userInfo = null;
          
                if (BLL.Settings.UseNewUserManagement)
                {
                   userInfo  = Auth.Authenticate(txtUsername.Text);
                    if (userInfo == null)
                    {
                        //errorLogger.SaveError(0, 1, 1, 2, "Login Attempt", "Warehouse", new InvalidCredentialException("Invalid credentials, Username = " + username));
                        //return false;
                    }
                    Thread.CurrentPrincipal = SecurityPrincipal.CreateSecurityPrincipal(userInfo);
                }  
                    
                    User usr = new User();
                    usr.Where.UserName.Value = txtUsername.Text;
                    usr.Query.Load();
                    LogUserIn(usr);
                }
            }
        }

        private void LoginFormLoad(object sender, EventArgs e)
        {
            VersionLabel.Text = Program.HCMISVersionStringShort;

            

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();

            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWorkDbName);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.RunWorkerAsync();
            bwSendAdditional = new BackgroundWorker();
            bwSendAdditional.DoWork += new DoWorkEventHandler(bwSendAdditional_DoWork);
    
            defaultLookAndFeel1.LookAndFeel.SkinName = "Office2003";
           
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                DatabaseIdentity.Text = e.Result.ToString();
            }
            
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // initalize the database context for Security Tool
            try
            {
                Auth.InitalizeRepository();
            }
            catch
            {
            }
            //Program.SaveHCMISVersionToRegistry();
            //Program.UpdateApplication();

        }

        void bw_DoWorkDbName(object sender, DoWorkEventArgs e)
        {

            // if there is no connection, this would fail
            try
            {
                e.Result = BLL.GeneralInfo.Current.HospitalName;
                if (File.Exists(BLL.GeneralInfo.Current.LogoUrl))
                    pxLogo.ImageLocation = BLL.GeneralInfo.Current.LogoUrl;
                
            }
            catch
            {

            }

        }

        void bwSendAdditional_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Helpers.RegistrationHelper.SendAdditionalData("LastLogin", DateTimeHelper.ServerDateTime.ToString());
            }
            catch
            {
            }
        }

        private void DatabaseIdentity_DoubleClick(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                //ConnectionStringManager.ConnectionStringManager connMgr =
                //           new ConnectionStringManager.ConnectionStringManager(Program.RegKey,
                //                                                               Program.PrevConnectionStringKey);
                //connMgr.ShowDialog();
            }
        }

        private void VersionLabel_DoubleClick(object sender, EventArgs e)
        {
            if((ModifierKeys & Keys.Control)==Keys.Control)
            {
                if (VersionLabel.Text == Program.HCMISVersionString)
                {
                    VersionLabel.Text = Program.HCMISVersionStringShort;
                }
                else
                {
                    VersionLabel.Text = Program.HCMISVersionString;
                }
            }
        }
    }
}