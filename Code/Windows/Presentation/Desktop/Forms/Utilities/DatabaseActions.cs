using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using System.Deployment.Application;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.GeneralLookups;
using HCMIS.Desktop;

namespace HCMIS.Desktop.Forms.Utilities
{
    [FormIdentifier("AD-DB-DB-UT","Database Actions","")]
    public partial class DatabaseActions : XtraForm
    {
        public DatabaseActions()
        {
            InitializeComponent();
        }

        public static System.Configuration.AppSettingsReader readApp = new System.Configuration.AppSettingsReader();
        BackgroundWorker bw = new BackgroundWorker();


        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = String.Format("{0}\\{1}PharmaInventory{2:MMMddyyyy}.bak", folderBrowserDialog1.SelectedPath, GeneralInfo.Current.HospitalName, DateTimeHelper.ServerDateTime);

                    string connectionString = readApp.GetValue("dbConnection", typeof(string)).ToString();
                    
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);
                    System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand();

                    if (!(conn.State == ConnectionState.Open))
                        conn.Open();
                    string dbName = conn.Database;
                    com.CommandText = "BACKUP DATABASE [" + dbName + "] TO  DISK = N'" + path + "' WITH NOFORMAT, NOINIT,  NAME = N'PharmaInventory" + DateTimeHelper.ServerDateTime.ToString("MMMddyyyy") + "-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                    com.Connection = conn;
                    com.ExecuteNonQuery();
         
                    GeneralInfo.Current.LastBackUp = DateTimeHelper.ServerDateTime;
                    GeneralInfo.Current.Save();
                    MessageBox.Show(@"Backup completed to " + path + @"!", @"Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show(@"Backup has failed! Please Try Again.",@"Try Again",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string path = openFileDialog1.FileName;
                    
                    string connectionString = readApp.GetValue("dbConnection", typeof(string)).ToString();
                    
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);
                    System.Data.SqlClient.SqlCommand com = new System.Data.SqlClient.SqlCommand();
                  
                    if (!(conn.State == ConnectionState.Open))
                        conn.Open();
                    string dbName = conn.Database;
                    com.CommandText = " USE MASTER RESTORE DATABASE [" + dbName + "] FROM  DISK = N'" + path + "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10";
                    com.Connection = conn;
                    com.ExecuteNonQuery();
                    MessageBox.Show(@"Restore completed!", @"Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show(@"Restore has failed! Make sure that the file exists and  Try Again.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DatabaseActions_Load(object sender, EventArgs e)
        {
            SetPermission();
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            btnRestore.Enabled = false;
            
            lkEndOfYear.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            btnDoEndOfYear.Enabled = false;
            if (EthiopianDate.EthiopianDate.Now.Month > 10 && !BLL.YearEnd.IsPerformedForYear(EthiopianDate.EthiopianDate.Now.Year))
            {
                btnDoEndOfYear.Enabled = true;
                lkEndOfYear.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            
            TimeSpan tt = new TimeSpan();
            string lastdt = "";
            try
            {
                tt = new TimeSpan(DateTimeHelper.ServerDateTime.Ticks - GeneralInfo.Current.LastBackUp.Ticks);
               decimal days = Decimal.Round(Convert.ToDecimal(tt.TotalDays), 0);
               lastdt = GeneralInfo.Current.LastBackUp.ToString("MMM dd, yyyy") + " (" + days.ToString() + " days ago)";
            }
            catch
            { }
            //lblLastDate.Text = lastdt;
            // Bind the Last updated date
            lblLastUpdatedDate.Text = String.Format("Last Updated On: {0}", DirectoryUpdateStatus.GetLastUpdateTime());
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnBackup.Enabled = this.HasPermission("Backup-Database");
                btnRefreshDirectoryService.Enabled = this.HasPermission("Refresh-Directory-Service");
                btnConnectionConfig.Enabled = this.HasPermission("Connection-String-Config");
                btnRestore.Enabled = this.HasPermission("Restore-Database");
                btnGeneralLookupSync.Enabled = this.HasPermission("General-Lookup");
                btnDoEndOfYear.Enabled = this.HasPermission("End-Of-Year");
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            layoutSynching.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutSyncingText.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            
            bw.RunWorkerAsync("DS");
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string username = "hcmishe";
            string password = "hcmishe";

            if(e.Argument.ToString()=="DS")
            {
                int? dUpdateStatus = DirectoryUpdateStatus.GetLastVersion("All");

                try
                {
                    
                    HCMIS.Desktop.DirectoryServices.Service1SoapClient sc = new HCMIS.Desktop.DirectoryServices.Service1SoapClient();
                    
                    long newLastVersionDS = sc.GetLastVersion(username, password);

                    if (!dUpdateStatus.HasValue || dUpdateStatus.Value != newLastVersionDS)
                    {
                        //Proxy.ABC.SaveList(sc.GetABCs(username, password, dUpdateStatus, null));
                        //Proxy.VEN.SaveList(sc.GetVENs(username, password, dUpdateStatus, null));
                        //Proxy.CommodityType.SaveList(sc.GetCommodityTypes(username, password, dUpdateStatus, null));
                        //Proxy.DosageForm.SaveList(sc.GetDosageForms(username, password, dUpdateStatus, null));
                        //Proxy.Product.SaveList(sc.GetProducts(username, password, dUpdateStatus, null));
                        //Proxy.Unit.SaveList(sc.GetUnits(username, password, dUpdateStatus, null));
                        //Proxy.Program.SaveList(sc.GetPrograms(username, password, dUpdateStatus, null));
                        //Proxy.Manufacturer.SaveList(sc.GetManufacturer(username, password, dUpdateStatus, null));
                        //Proxy.Supplier.SaveList(sc.GetSuppliers(username, password, dUpdateStatus, null));
                        //Proxy.StoreType.SaveList(sc.GetModes(username, password, dUpdateStatus, null));
                        //Proxy.StoreGroup.SaveList(sc.GetAccounts(username, password, dUpdateStatus, null));
                        //Proxy.StoreGroupDivision.SaveList(sc.GetSubAccounts(username, password, dUpdateStatus, null));
                        //Proxy.Stores.SaveList(sc.GetSubSubAccounts(username, password, dUpdateStatus, null));
                        //Proxy.ItemUnit.SaveList(sc.GetItemUnitsWithUnitDetail(username, password, dUpdateStatus, null));
                        //Proxy.Items.SaveList(sc.GetDrugItems(username, password, dUpdateStatus, null));
                        //Proxy.Items.SaveList(sc.GetSupplyItems(username, password, dUpdateStatus, null));
                        //Proxy.DrugCategory.SaveList(sc.GetDrugCategory(username, password, dUpdateStatus, null));
                        //Proxy.DrugSubCategory.SaveList(sc.GetDrugSubCategory(username, password, dUpdateStatus, null));
                        //Proxy.SupplyCategory.SaveList(sc.GetSupplyCategories(username, password, dUpdateStatus, null));
                        //Proxy.ItemSupplyCategory.SaveList(sc.GetItemSupplyCategories(username, password, dUpdateStatus, null));
                        //Proxy.DrugItemSubCategory.SaveList(sc.GetDrugItemSubCategory(username, password, dUpdateStatus, null));
                        ////Proxy.ItemProgram.SaveList(sc.GetItemPrograms(username, password, dUpdateStatus, null));
                        //Proxy.ItemUnit.SaveList(sc.GetItemUnitsWithUnitDetail(username, password, dUpdateStatus, null));
                        //Proxy.ItemManufacturer.SaveList(sc.GetItemManufacturers(username, password, dUpdateStatus, null));
                        DirectoryUpdateStatus.SaveLastVersion("All", Convert.ToInt32(newLastVersionDS));
                    }
                }
                catch (Exception exp)
                {
                    string message = "";

                    if (CurrentContext.LoggedInUser.UserType == UserType.Constants.SUPER_ADMINISTRATOR)
                    {
                        message = exp.Message;
                    }
                    else
                    {
                        message = "Please check the network connection and try again.";
                    }
                    e.Result = message;
                }
            }

            else if(e.Argument.ToString()=="GL")
            {
                int? gLUpdateStatus = DirectoryUpdateStatus.GetLastVersion("GL");
                try
                {
                    HCMIS.Desktop.GeneralLookups.Service1SoapClient glSC = new Service1SoapClient();
                    long newLastVersionGL = glSC.GetLastVersion(username, password);
                    if (!gLUpdateStatus.HasValue || gLUpdateStatus.Value != newLastVersionGL)
                    {
                        //Proxy.Region.SaveList(glSC.GetRegions(username, password, gLUpdateStatus, null));
                        //Proxy.Zone.SaveList(glSC.GetZones(username, password, gLUpdateStatus, null));
                        //Proxy.Woreda.SaveList(glSC.GetWoredas(username, password, gLUpdateStatus, null));
                        DirectoryUpdateStatus.SaveLastVersion("GL", Convert.ToInt32(newLastVersionGL));
                    }
                }
                catch (Exception exp)
                {
                    string message = "";

                    if (CurrentContext.LoggedInUser.UserType == UserType.Constants.SUPER_ADMINISTRATOR)
                    {
                        message = exp.Message;
                    }
                    else
                    {
                        message = "Please check the network connection and try again.";
                    }
                    e.Result = message;
                }
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            layoutSynching.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            layoutSyncingText.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lblLastUpdatedDate.Text = @"Last Updated Date: " + DateTimeHelper.ServerDateTime.ToString(); 
            if (e.Result != null) 
            { 
                //TODO: make a notification why it has failed
                XtraMessageBox.Show(e.Result.ToString());
            }
            else
            {
                XtraMessageBox.Show("Directory Services Synchronized!");   
            }
        }

        private void btnDoEndOfYear_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Are you sure you want to perform the year End activity automatically?",
                                             "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            var confirm =
                XtraMessageBox.Show(
                    "Performing the year end automatically will make HCMIS take the present stock as the beginning balance of the next fiscal year.  You will not be able to use the Inventory page to input inventory data.  Do you want to proceed?",
                    "Confirmation", MessageBoxButtons.YesNo);
            if(confirm==DialogResult.No)
            {
                return;
            }

            btnDoEndOfYear.Enabled = false;
            int year = ConvertDate.GetEthiopianYear(DateTimeHelper.ServerDateTime);
            Activity stores = new Activity();
            stores.LoadAll();

            BLL.CommodityType commodityType = new BLL.CommodityType();
            commodityType.LoadAll();

            while (!commodityType.EOF)
            {
                while (!stores.EOF)
                {
                    DataTable dtbl = Balance.GetSohForAllItems(stores.ID, commodityType.ID, year, 10);
                    YearEnd ye = new YearEnd();
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        if (dr["ID"] == DBNull.Value || dr["UnitID"] == DBNull.Value)
                            continue;

                        ye.AddNew();

                        ye.ItemID = Convert.ToInt32(dr["ID"]);
                        ye.UnitID = Convert.ToInt32(dr["UnitID"]);
                        ye.StoreID = stores.ID;
                        ye.Year = year;

                        ye.PhysicalInventory = ye.EBalance = Convert.ToInt32(dr["SOH"]);
                        ye.PhysicalInventoryPrice = ye.EndingPrice = Convert.ToDecimal(Convert.ToDouble(dr["Price"]));
                        ye.Save();
                    }
                    stores.MoveNext();
                }
                commodityType.MoveNext();
            }
            XtraMessageBox.Show("Year End has been populated");
            btnDoEndOfYear.Enabled = !BLL.YearEnd.IsPerformedForYear(EthiopianDate.EthiopianDate.Now.Year);
        }

        private void btnConnectionConfig_Click(object sender, EventArgs e)
        {
            //ConnectionStringManager.ConnectionStringManager connMgr =
            //    new ConnectionStringManager.ConnectionStringManager(Program.RegKey, Program.PrevConnectionStringKey);
            //connMgr.ShowDialog();
        }

        private void btnGeneralLookupSync_Click(object sender, EventArgs e)
        {
            layoutSynching.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutSyncingText.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            bw.RunWorkerAsync("GL");
        }

        //
    }
}