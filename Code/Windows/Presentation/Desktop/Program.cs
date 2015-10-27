using System;
using System.Windows.Forms;
using System.Deployment.Application;
using HCMIS.Extensions.Enums;
using HCMIS.Extensions.Services;
using Microsoft.Win32;
using System.ComponentModel;
using System.Threading;
using HCMIS.Concrete.Models;
using HCMIS.Shared.Connection;
using HCMIS.Desktop.Helpers;
using Shared.Forms;


namespace HCMIS.Desktop
{
    static class Program
    {
        public static ILookupKernel LookupKernel { get; private set; }
        public const string RegKey = "Software\\JSI\\HCMIS\\HE\\Configuration";
        public const string PrevConnectionStringKey = "Software\\JSI\\HCMIS\\HE\\ConnectionStringManager\\History";
        public static bool isRemoteClient = false;
        public static ApplicationDeployment HCMISDeployment;
        public static bool UpdateRunning, RestartRequired;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Setup Application Constants


            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            
            // Setup JIRA integration
            //

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            // Configure the connection string helper
            ConnectionHelper.Configure(RegKey, PrevConnectionStringKey);
          if (Control.ModifierKeys == Keys.Shift)
            {
                Application.Run(new ConnectionChoices());
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                //Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            }

            MyGeneration.dOOdads.BusinessEntity.RegistryConnectionString = ConnectionHelper.CurrentConnection.ToString();
            ConnectionManager.ConnectionString = ConnectionHelper.CurrentConnection.ToString();
            LookupKernel = new LookupKernel(new WarehouseContext(ConnectionManager.ConnectionString), new DefaultBindingManager());
        
            HCMIS.Logging.LogManager.ConnectionString =  HCMIS.Security.Settings.ConnectionString = ConnectionHelper.CurrentConnection.ToString();
            
            StockoutIndexBuilder.Settings.ConnectionString = ConnectionHelper.CurrentConnection.ToString();
            HCMIS.Modules.Requisition.CacheSetting.LoadConfigurationForCaching();
            ConstantsHelper.LoadAllConstants();

            Application.Run(new LoginForm());
                 }

     

        public static string HCMISVersionString
        {
            get
            {
                string versionInfo = "";
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    if (HCMISDeployment == null)
                        HCMISDeployment = ApplicationDeployment.CurrentDeployment;

                    versionInfo =   HCMISDeployment.CurrentVersion.Major.ToString();
                    versionInfo += "." + HCMISDeployment.CurrentVersion.Minor;
                    versionInfo += "." + HCMISDeployment.CurrentVersion.Build;
                    versionInfo += "." + HCMISDeployment.CurrentVersion.MinorRevision;
                }
                else
                {
                    versionInfo = Application.ProductVersion;
                }
                return versionInfo;
            }
        }

        public static string HCMISVersionStringShort
        {
            get
            {
                string versionInfo = "";
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    if (HCMISDeployment == null)
                        HCMISDeployment = ApplicationDeployment.CurrentDeployment;

                    versionInfo = HCMISDeployment.CurrentVersion.Major.ToString();
                    versionInfo += "." + HCMISDeployment.CurrentVersion.Minor;
                    versionInfo += "." + HCMISDeployment.CurrentVersion.Build;
                }
                else
                {
                    versionInfo = Application.ProductVersion;
                }
                return versionInfo;
            }
        }

        public static void SaveHCMISVersionToRegistry()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKey);
            string versionString = "";

            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(RegKey);
            }
            try
            {
                versionString = key.GetValue("ApplicationVersion").ToString();
            }
            catch
            {
                key = Registry.CurrentUser.CreateSubKey(RegKey);
                key.SetValue("ApplicationVersion", "");
            }

            Helpers.RegistrationHelper.UpdateApplicationVersionInfo();
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(RegKey);
            regKey.SetValue("ApplicationVersion", HCMISVersionString);
        }

        //Event For Application
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            
            Helpers.ErrorHandler.Handle(e.Exception);
        }

    }
}