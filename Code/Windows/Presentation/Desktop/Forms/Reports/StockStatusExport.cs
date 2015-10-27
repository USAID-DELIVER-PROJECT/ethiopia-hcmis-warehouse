using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Reports.Finance;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-SSE-SS-RP", "Order Status", "")]
    public partial class StockStatusExport : DevExpress.XtraEditors.XtraForm
    {
        private XtraReport report;
       
        public StockStatusExport()
        {
            InitializeComponent();
        }


        private void StockStatusExport_Load(object sender, EventArgs e)
        {
            lkAccount.SetupAccountEditor().SetDefaultAccount();
            lkMode.SetupModeEditor().SetDefaultMode();
            Item itm = new Item();
            DataTable dtyears = itm.AllYears();
            foreach(DataRowView dr in dtyears.DefaultView)
            {
                 cbYear.Items.Add(dr["Year"]);
                 cbToYear.Items.Add(dr["Year"]);
            }
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;

            cbMonth.Items.AddRange(new object[] { "መስከረም", "ጥቅምት", "ኅዳር", "ታኅሣሥ", "ጥር", "የካቲት", "መጋቢት", "ሚያዝያ", "ግንቦት", "ሰኔ", "ሐምሌ", "ነሐሴ" });
            cbToMonth.Items.AddRange(new object[] { "መስከረም", "ጥቅምት", "ኅዳር", "ታኅሣሥ", "ጥር", "የካቲት", "መጋቢት", "ሚያዝያ", "ግንቦት", "ሰኔ", "ሐምሌ", "ነሐሴ" });

        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null && layoutMonth.Visibility == LayoutVisibility.Never && layoutYear.Visibility == LayoutVisibility.Always)
            {
                cbYear_SelectedIndexChanged(null, null);
            }
            else if(lkAccount.EditValue != null && layoutMonth.Visibility != LayoutVisibility.Always)
            {

                var accountID = Convert.ToInt32(lkAccount.EditValue);
                var account = new StockStatusByAccount(CurrentContext.LoggedInUserName);
                var account2 =  new StockStatusByAccountWithUnitPrice(CurrentContext.LoggedInUserName);
                if (chkExludeDamaged.Checked)
                {
                    if (Convert.ToBoolean(checkShowUnitPrice.Checked))
                    {
                        account2.DataSource = Balance.GetStockStatusByAccountDamagedExcluded(accountID, Convert.ToBoolean(checkShowUnitPrice.Checked));
                        printControl1.PrintingSystem = account2.PrintingSystem;
                    }
                       
                    else
                    {
                        account.DataSource = Balance.GetStockStatusByAccountDamagedExcluded(accountID, Convert.ToBoolean(checkShowUnitPrice.Checked));
                        printControl1.PrintingSystem = account.PrintingSystem;
                    }
                   
                }
                else
                {
                    if (Convert.ToBoolean(checkShowUnitPrice.Checked))
                    {
                        account2.DataSource = Balance.GetStockStatusByAccount(accountID, Convert.ToBoolean(checkShowUnitPrice.Checked));
                        printControl1.PrintingSystem = account2.PrintingSystem;
                    }
                       
                    else
                    {
                        account.DataSource = Balance.GetStockStatusByAccount(accountID, Convert.ToBoolean(checkShowUnitPrice.Checked));
                        printControl1.PrintingSystem = account.PrintingSystem;
                    }   
                }
               

                var accountO = new Account();
                accountO.LoadByPrimaryKey(accountID);

                if (Convert.ToBoolean(checkShowUnitPrice.Checked))
                {
                    account2.AccountName.Text = accountO.Name;
                    report = account2;
                    account2.CreateDocument();
                }
                else
                {
                   
                    account.AccountName.Text = accountO.Name;
                    report = account;
                    account.CreateDocument();
                }
                
                
            }

            else if (lkAccount.EditValue != null && cbMonth.SelectedItem != null && cbYear.SelectedItem != null && cbToYear.SelectedItem != null && cbToMonth.SelectedItem != null && listBoxControl1.SelectedItem.ToString().Equals("Vital Report"))
            {
                LadVitalItemReport();
            }
            
            else
            {
                cbMonth_SelectedIndexChanged(null,null);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            report.PrintDialog();
        }

        private void chkExludeDamaged_CheckedChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedItem.ToString().Equals("Stock Status by Account") || listBoxControl1.SelectedItem.ToString().Equals("Stock Status by Mode"))
                listBoxControl1_DoubleClick(null, null);
            else

                lkAccount_EditValueChanged(null, null);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using(var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = ".xlsx";
               if(saveFileDialog.ShowDialog(this) != DialogResult.Cancel)
               {

                   report.ExportToXlsx(saveFileDialog.FileName);       
               }
                
            }
            
        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            string SelectedReport = listBoxControl1.SelectedItem.ToString();
            if (SelectedReport.Equals("Stock Status by Account"))
            {
                LoadStockStatusByAccountReport();
                ShowFilter(false);
                layoutDamagedandExpired.Visibility = LayoutVisibility.Always;

            }
            else if (SelectedReport.Equals("Stock Status by Mode"))
            {
                LoadStockStatusByModeReport();
                ShowFilter(false);
                layoutDamagedandExpired.Visibility = LayoutVisibility.Always;
                layoutAccount.Visibility = LayoutVisibility.Never;
                layoutToMonth.Visibility = LayoutVisibility.Never;
                layoutToYear.Visibility = LayoutVisibility.Never;
                lblFrom.Visibility = LayoutVisibility.Never;
                lblTo.Visibility = LayoutVisibility.Never;
                layoutCategory.Visibility = LayoutVisibility.Never;
                layoutChecSellingPrice.Visibility = LayoutVisibility.Never;
                layoutShowUnitPrice.Visibility = LayoutVisibility.Never;
               
                
               
            }
            else if (SelectedReport.Equals("Issued Amount by Month") || SelectedReport.Equals("Received Amount by Month") || SelectedReport.Equals("Cost of Good Sold"))
            {
                ShowFilter();    
                layoutAccount.Visibility = LayoutVisibility.Always;
                layoutToMonth.Visibility = LayoutVisibility.Never;
                layoutToYear.Visibility = LayoutVisibility.Never;
                lblFrom.Visibility = LayoutVisibility.Never;
                lblTo.Visibility = LayoutVisibility.Never;
                layoutCategory.Visibility = LayoutVisibility.Never;
                layoutChecSellingPrice.Visibility = LayoutVisibility.Never;
                layoutShowUnitPrice.Visibility = LayoutVisibility.Never;
                report = null;
            }
            else if (SelectedReport.Equals("Issued Amount by Year") || SelectedReport.Equals("Received Amount by Year"))
            {

                ShowYearFilter();
                layoutToMonth.Visibility = LayoutVisibility.Never;
                layoutToYear.Visibility = LayoutVisibility.Never;
                layoutCategory.Visibility = LayoutVisibility.Never;
                layoutChecSellingPrice.Visibility = LayoutVisibility.Never;
                layoutShowUnitPrice.Visibility = LayoutVisibility.Never;
                
            }

            else if (SelectedReport.Equals("Vital Report") )
            {
                ShowFromandToFilter();
            }
            else if (SelectedReport.Equals("Stock Status"))
            {
                
                layoutAccount.Visibility = LayoutVisibility.Always;
                layoutToMonth.Visibility = LayoutVisibility.Never;
                layoutToYear.Visibility = LayoutVisibility.Never;
                lblFrom.Visibility = LayoutVisibility.Never;
                lblTo.Visibility = LayoutVisibility.Never;
                layoutCategory.Visibility = LayoutVisibility.Never;
                layoutChecSellingPrice.Visibility = LayoutVisibility.Never;
                layoutShowUnitPrice.Visibility = LayoutVisibility.Always;

                report = null;
            }

            //Let's handle which lookup gets shown.  Mode or Account
            if (SelectedReport.Equals("Cost of Good Sold") || SelectedReport.Equals("Vital Report"))
            {
                ShowModeOrAccountOrNeither(1);
            }
            else if (SelectedReport.Equals("Issued Amount by Month") || SelectedReport.Equals("Received Amount by Month") || SelectedReport.Equals("Issued Amount by Year") || SelectedReport.Equals("Received Amount by Year")  || SelectedReport.Equals("Stock Status"))
            {
                if (SelectedReport.Equals("Issued Amount by Month") || SelectedReport.Equals("Issued Amount by Year"))
                {
                    layoutChecSellingPrice.Visibility = LayoutVisibility.Always;
                    layoutDamagedandExpired.Visibility = LayoutVisibility.Never;
                }
                ShowModeOrAccountOrNeither(2);
            }
            else
            {
                ShowModeOrAccountOrNeither(3);
            }
        }
        public void ShowFilter(bool show =true)
        {
           
            layoutMonth.Visibility = layoutYear.Visibility = show ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        public void ShowYearFilter(bool show = true)
        {
            layoutMonth.Visibility = LayoutVisibility.Never;
            layoutYear.Visibility = show ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        public void ShowFromandToFilter(bool show = true)
        {
            emptyTo.Visibility = LayoutVisibility.Always;
            emptyFrom.Visibility = LayoutVisibility.Always;
            layoutCategory.Visibility = LayoutVisibility.Always;
            layoutDamagedandExpired.Visibility = LayoutVisibility.Never;
            layoutYear.Visibility = layoutMonth.Visibility = layoutToMonth.Visibility = layoutToYear.Visibility = lblFrom.Visibility = lblTo.Visibility = show ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="showWhat">1 - Show Mode, 2 - Show Account, 3 - Don't show neither mode or account</param>
        private void ShowModeOrAccountOrNeither(int showWhat)
        {
            if(showWhat==1)
            {
                layoutMode.Visibility=LayoutVisibility.Always;
                layoutAccount.Visibility = LayoutVisibility.Never;
            }
            else if(showWhat==2)
            {
                layoutMode.Visibility = LayoutVisibility.Never;
                layoutAccount.Visibility = LayoutVisibility.Always;
            }
            else if (showWhat==3)
            {
                layoutMode.Visibility = LayoutVisibility.Never;
                layoutAccount.Visibility = LayoutVisibility.Never;
            }
        }

 	 
        

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonth.SelectedItem != null && cbYear.SelectedItem != null && lkAccount.EditValue != null && listBoxControl1.SelectedItem.ToString().Equals("Issued Amount by Month"))
            {
                IssuedAmoutPerMonth issueAmountReport = new IssuedAmoutPerMonth(CurrentContext.LoggedInUserName);
          
                issueAmountReport.DataSource = IssueDoc.IssueAmountByPaymentType(Convert.ToInt32(cbMonth.SelectedIndex + 1), Convert.ToInt32(cbYear.SelectedItem), Convert.ToInt32(lkAccount.EditValue),Convert.ToBoolean(checbySellingPrice.Checked));
                issueAmountReport.xrMonth.Text = string.Format("{0} {1}", cbMonth.SelectedItem, cbYear.SelectedItem);
                printControl1.PrintingSystem = issueAmountReport.PrintingSystem;
                report = issueAmountReport;
                issueAmountReport.CreateDocument();
            }
            else if (cbMonth.SelectedItem != null && cbYear.SelectedItem != null && lkAccount.EditValue != null && listBoxControl1.SelectedItem.ToString().Equals("Received Amount by Month"))
            {
                ReceivedAmoutPerMonth receivedAmountReport = new ReceivedAmoutPerMonth( CurrentContext.LoggedInUserName);

                receivedAmountReport.DataSource = ReceiveDoc.ReceivedAmountByReason(Convert.ToInt32(cbMonth.SelectedIndex + 1), Convert.ToInt32(cbYear.SelectedItem), Convert.ToInt32(lkAccount.EditValue));
                receivedAmountReport.xrMonth.Text = string.Format("{0} {1}", cbMonth.SelectedItem, cbYear.SelectedItem);
                printControl1.PrintingSystem = receivedAmountReport.PrintingSystem;
                report = receivedAmountReport;
                receivedAmountReport.CreateDocument();
            }
            else if (cbMonth.SelectedItem != null && lkMode.EditValue != null && cbYear.SelectedItem != null && listBoxControl1.SelectedItem.ToString().Equals("Cost of Good Sold"))
            {
                CostOfGoodSold costOfGoodSold = new CostOfGoodSold(CurrentContext.LoggedInUserName);

                costOfGoodSold.DataSource = IssueDoc.CostOfSales(Convert.ToInt32(cbMonth.SelectedIndex + 1),
                                                                 Convert.ToInt32(cbYear.SelectedItem),
                                                                 Convert.ToInt32(lkMode.EditValue));
                
                costOfGoodSold.xrMonth.Text = string.Format("{0} {1}", cbMonth.SelectedItem, cbYear.SelectedItem);
                printControl1.PrintingSystem = costOfGoodSold.PrintingSystem;
                report = costOfGoodSold;
                costOfGoodSold.CreateDocument();
            }
            else if (lkMode.EditValue != null && lkCategories.EditValue != null && cbMonth.SelectedItem != null && cbYear.SelectedItem != null && cbToYear.SelectedItem != null && cbToMonth.SelectedItem != null && listBoxControl1.SelectedItem.ToString().Equals("Vital Report"))
            {
                LadVitalItemReport();
            }
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedItem.ToString().Equals("Issued Amount by Year"))
            {
                IssuedAmoutByYear issuedAmoutByYearReport = new IssuedAmoutByYear(CurrentContext.LoggedInUserName);

                issuedAmoutByYearReport.DataSource = IssueDoc.IssuedAmoutByYear(Convert.ToInt32(cbYear.SelectedItem), Convert.ToInt32(lkAccount.EditValue),Convert.ToBoolean(checbySellingPrice.Checked));
                issuedAmoutByYearReport.xrMonth.Text = string.Format("{0}", cbYear.SelectedItem);
                printControl1.PrintingSystem = issuedAmoutByYearReport.PrintingSystem;
                report = issuedAmoutByYearReport;
                issuedAmoutByYearReport.CreateDocument();
            }
            else if (listBoxControl1.SelectedItem.ToString().Equals("Received Amount by Year"))
            {
                ReceivedAmoutByYear receivedAmountReport = new ReceivedAmoutByYear(CurrentContext.LoggedInUserName);

                receivedAmountReport.DataSource = ReceiveDoc.ReceivedAmoutByYear(Convert.ToInt32(cbYear.SelectedItem), Convert.ToInt32(lkAccount.EditValue));
                receivedAmountReport.xrMonth.Text = string.Format("{0}", cbYear.SelectedItem);
                printControl1.PrintingSystem = receivedAmountReport.PrintingSystem;
                report = receivedAmountReport;
                receivedAmountReport.CreateDocument();
            }
            else if (lkMode.EditValue != null && lkCategories.EditValue != null && cbMonth.SelectedItem != null && cbYear.SelectedItem != null && cbToYear.SelectedItem != null && cbToMonth.SelectedItem != null && listBoxControl1.SelectedItem.ToString().Equals("Vital Report"))
            {
                LadVitalItemReport();
            }
            else
            {
                cbMonth_SelectedIndexChanged(null, null);
            }
            
        }

        

        private void cbToYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lkMode.EditValue != null && lkCategories.EditValue != null && cbMonth.SelectedItem != null && cbYear.SelectedItem != null && cbToYear.SelectedItem != null && cbToMonth.SelectedItem != null && listBoxControl1.SelectedItem.ToString().Equals("Vital Report"))
            {
                LadVitalItemReport();
            }
        }


        private void LoadStockStatusByAccountReport()
        {
            StockStatusByCommodity SOHreport = new StockStatusByCommodity(CurrentContext.LoggedInUserName);
            if (!chkExludeDamaged.Checked)
            {
                SOHreport.DataSource = Balance.GetStockStatusByAccount();
            }
            else
            {
                SOHreport.DataSource = Balance.GetStockStatusByAccountDamagedExcluded();
            }
            printControl1.PrintingSystem = SOHreport.PrintingSystem;


            report = SOHreport;
            SOHreport.CreateDocument();
            
            
        }

        private void LoadStockStatusByModeReport()
        {
            StockStatusByCommodity SOHreport = new StockStatusByCommodity(CurrentContext.LoggedInUserName);
            if (!chkExludeDamaged.Checked)
            {
                SOHreport.DataSource = Balance.GetStockStatusByMode();
            }
            else
            {
                SOHreport.DataSource = Balance.GetStockStatusByModeDamagedExcluded();
            }
            printControl1.PrintingSystem = SOHreport.PrintingSystem;
            report = SOHreport;
            SOHreport.CreateDocument();

        }
        private void LadVitalItemReport()
        {
            VitalReport vitalReport = new VitalReport(CurrentContext.LoggedInUserName);

            var x = new ReceiveDoc();
            DataView dv = new DataView(x.VitalReport(Convert.ToInt32(cbYear.SelectedItem),
                                            Convert.ToInt32(cbMonth.SelectedIndex + 1),
                                            Convert.ToInt32(cbToYear.SelectedItem),
                                            Convert.ToInt32(cbToMonth.SelectedIndex + 1),
                                            Convert.ToInt32(lkMode.EditValue), CurrentContext.UserId, Convert.ToInt32(lkCategories.EditValue)));

            vitalReport.DataSource = dv;
            vitalReport.xrAccount.Text = string.Format("{0}", lkMode.Text);
            vitalReport.xrCategory.Text = string.Format("{0}", lkCategories.Text);
            vitalReport.xrFromDate.Text = string.Format("{0} {1}", cbMonth.SelectedItem, cbYear.SelectedItem);
            vitalReport.xrToDate.Text = string.Format("{0} {1}", cbToMonth.SelectedItem, cbToYear.SelectedItem);
            printControl1.PrintingSystem = vitalReport.PrintingSystem;
            report = vitalReport;
            vitalReport.CreateDocument();
        }

        private void cbToMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lkMode.EditValue != null && lkCategories.EditValue != null && cbMonth.SelectedItem != null && cbYear.SelectedItem != null && cbToYear.SelectedItem != null && cbToMonth.SelectedItem != null && listBoxControl1.SelectedItem.ToString().Equals("Vital Report"))
            {
                LadVitalItemReport();
            }
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            if (lkMode.EditValue != null && lkCategories.EditValue != null && cbMonth.SelectedItem != null && cbYear.SelectedItem != null && cbToYear.SelectedItem != null && cbToMonth.SelectedItem != null && listBoxControl1.SelectedItem.ToString().Equals("Vital Report"))
            {
                LadVitalItemReport();
            }
        }

        private void checbySellingPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedItem.ToString().Equals("Issued Amount by Year"))
            {
                cbYear_SelectedIndexChanged(null,null);
            }
            else if (listBoxControl1.SelectedItem.ToString().Equals("Issued Amount by Month"))
            {
                cbMonth_SelectedIndexChanged(null,null);
            }
        }

        private void checkShowUnitPrice_CheckedChanged(object sender, EventArgs e)
        {
            lkAccount_EditValueChanged(null, null);
        }

        












    }
}
