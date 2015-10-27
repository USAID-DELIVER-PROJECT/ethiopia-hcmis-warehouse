using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HCMIS.Logging.Models;
using HCMIS.Logging.Repository;
using HCMIS.Security.UserManagement.Views;
using HCMIS.Shared.Connection;
using Shared.Forms;

namespace HCMIS.Security.UserManagement
{
    static class Program
    {
        public const string RegKey = "Software\\JSI\\HCMIS\\HE\\Configuration";
        public const string PrevConnectionStringKey = "Software\\JSI\\HCMIS\\HE\\ConnectionStringManager\\History";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             

            ConnectionHelper.Configure(RegKey, PrevConnectionStringKey);
            if (Control.ModifierKeys == Keys.Shift)
            {
                Application.Run(new ConnectionChoices());
            }

            HCMIS.Logging.LogManager.ConnectionString =
                HCMIS.Security.Settings.ConnectionString = ConnectionHelper.CurrentConnection.ToString();
           
          
            Application.Run(new LogIn());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext.SecurityContext>());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // TODO: catch the exception and save it.
        }
    }
}
