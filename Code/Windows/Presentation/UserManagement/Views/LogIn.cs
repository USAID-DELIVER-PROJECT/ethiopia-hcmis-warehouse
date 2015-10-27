using System;
using System.Windows.Forms;
using System.Security.Authentication;
using HCMIS.Logging;
using HCMIS.Security.Common;
using HCMIS.Security.Repository;
using System.Threading;
using HCMIS.Security.UserManagement.Helpers;
using HCMIS.Shared.Connection;
using System.ComponentModel;
using HCMIS.Security.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class LogIn : Form
    {
        private static IActivityLog activityLogger = LogManager.GetActivityLogger("User Management Login");
        private static IErrorLog errorLogger = LogManager.GetErrorLogger();
        private int retryCount = 0;

        public LogIn()
        {
            InitializeComponent();
        }

        private void okCommand_Click(object sender, EventArgs e)
        {
            retryCount += 1;

            // If the user tries more than three times then they must restart the app
            //if (retryCount > 2) Application.Exit();

            if (!ValidateForm()) return;
            var user = userTextEdit.Text;
            var password = passwordTextEdit.Text;
            try
            {
                passwordTextEdit.Text = String.Empty;
                if (Helpers.SecurityHelper.Login(user, password))
                {
                    // Update the connection string for the logging.
                    ConnectionHelper.CurrentConnection.ApplicationName = string.Format("HCMIS.User-Managment-U-{0}", (SecurityHelper.CurrentPrincipal.Identity as
                                                                                                                                                     UserIdentity).UserID.ToString());
                    HCMIS.Logging.LogManager.ConnectionString =  HCMIS.Security.Settings.ConnectionString = ConnectionHelper.CurrentConnection.ToString();

                    var shell = new MainWindow();
                    shell.FormClosed += new FormClosedEventHandler(shell_FormClosed);
                    shell.Show();
                    this.Hide();
                }else
                {
                    lblErrorMessage.Text = @"User Name or Password Incorrect";
                }

                
            }
            catch (InvalidCredentialException exception)
            {
                ViewHelper.ShowErrorMessage(exception.Message);
                errorLogger.SaveError(1, 1, 1, 2, "Login Attempt", "Warehouse", exception);
            }
        }

        void shell_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = sender as MainWindow;
            if (form != null && form.ShowLoginWindowOnClose == true)
                this.Show();            
            else
                this.Close();
        }

        private void cancelCommand_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public bool ValidateForm()
        {
            return LoginValidation.Validate();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Write out the name of the hub
            UnitOfWork uow = UnitOfWork.CreateInstance();
            txtDBName.Text = uow.GeneralInfo.GetInstance().HospitalName;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                // try to load the context and initalize the repository
                // this is a hack, and could have been presented as loading database models.
                UnitOfWork uow = UnitOfWork.CreateInstance();
                uow.Users.FindBy(u => u.FirstName == "");
            }
            catch
            {
            }
        }

    }
}