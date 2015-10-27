using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Reports;
using DevExpress.XtraEditors;
using BLL;
using HCMIS.Desktop.ViewHelpers;


namespace HCMIS.Desktop.Forms.Modals
{
    public partial class PriceListPrintDialog : Form
    {
        private string choice = "";
        private PriceList priceList = null;
        private HCMIS.Desktop.Reports.PriceListByManufacturer priceListByManufacturer = null;

        public PriceListPrintDialog()
        {
            InitializeComponent();
            priceList=new PriceList();
            priceListByManufacturer = new PriceListByManufacturer();
            priceListByManufacturer.Date.Text = EthiopianDate.EthiopianDate.Now.ToDateString();
            priceListByManufacturer.HubName.Text = BLL.GeneralInfo.Current.HospitalName;
            priceList.Date.Text = EthiopianDate.EthiopianDate.Now.ToDateString();
            priceList.HubName.Text = BLL.GeneralInfo.Current.HospitalName;
            
        }

        private void radioChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            choice = radioChoice.EditValue.ToString();
            dtStarting.Enabled =  (choice == "Range")? true : false ;
            dtEnding.Enabled = (choice == "Range")? true : false ;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbPrintChoice.EditValue == "By Manufacturer")
            {
                if (choice == "All")
                {
                    priceListByManufacturer.DataSource = BLL.Item.GetItemPriceListByManufacturer(Convert.ToInt32(lkStore.EditValue));
                }
                else if (choice == "Range")
                {
                    priceListByManufacturer.DataSource = BLL.Item.GetItemPriceListByManufacturer(dtStarting.Value, dtEnding.Value, Convert.ToInt32(lkStore.EditValue));
                }
                else if (choice == "Today")
                {
                    priceListByManufacturer.DataSource = BLL.Item.GetItemPriceListByManufacturer(DateTimeHelper.ServerDateTime, Convert.ToInt32(lkStore.EditValue));
                }

                priceListByManufacturer.ShowPreview();

            }
            else
            {

                if (choice == "All")
                {
                    priceList.DataSource = BLL.Item.GetItemPriceList(Convert.ToInt32(lkStore.EditValue));
                }
                else if (choice == "Range")
                {
                    priceList.DataSource = BLL.Item.GetItemPriceList(dtStarting.Value, dtEnding.Value, Convert.ToInt32(lkStore.EditValue));
                }
                else if (choice == "Today")
                {
                    priceList.DataSource = BLL.Item.GetItemPriceList(DateTimeHelper.ServerDateTime, Convert.ToInt32(lkStore.EditValue));
                }

                priceList.ShowPreview();
            }
           
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PriceListPrintDialog_Load(object sender, EventArgs e)
        {
            //Printing PriceChange on GRV;
            gridGrvList.DataSource = MovingAverageHistory.GetListForGRVPricing();
            //Printing priceList
            dtStarting.Enabled = false;
            dtEnding.Enabled = false;
            radioChoice.SelectedIndex = 0;
            choice = radioChoice.EditValue.ToString();
            
            lkStore.SetupActivityEditor().SetDefaultActivity();
            cmbPrintChoice.EditValue = "By Commodity Type";
           
            //Load Mode->Account->SubAccount Selection
            //Lookup For Accounts
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            //Load Mode->Account->SubAccount Selection
            //Lookup For Accounts
            //lkAccount.Properties.DataSource = Stores.GetStoresWithStoreGroupsAndStoreTypes(NewMainWindow.UserId);
            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.EditValue = 0;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow drv = gridviewGrvList.GetFocusedDataRow();
            if (drv["ReceiptID"]!= DBNull.Value)
            {
                int ReceiptID = Convert.ToInt32(drv["ReceiptID"]);

                MovingAverage movingAverage = new MovingAverage();
                movingAverage.DataSource = MovingAverageHistory.GetMovingAverageByReceiptID(ReceiptID);
                movingAverage.ShowPreview();
            }
        }

        private void btnPrintMargin_Click(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null)
            {
                HCMIS.Desktop.Reports.AverageCostMarginReport xreport = new HCMIS.Desktop.Reports.AverageCostMarginReport();
                xreport.DataSource = BLL.Receipt.GetMarginByAccount(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkCategories.EditValue));
                xreport.ShowPreview();
            }
        }

        private void gridGrvList_MouseClick(object sender, MouseEventArgs e)
        {
            DataRow drv = gridviewGrvList.GetFocusedDataRow();
            if (drv["ReceiptID"] != DBNull.Value)
            {
                int ReceiptID = Convert.ToInt32(drv["ReceiptID"]);

                MovingAverage movingAverage = new MovingAverage();
                movingAverage.DataSource = MovingAverageHistory.GetMovingAverageByReceiptID(ReceiptID);
                movingAverage.CreateDocument();
                PrintPreview.PrintingSystem = movingAverage.PrintingSystem;
            }
        }

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccount.EditValue != null)
            {
                HCMIS.Desktop.Reports.AverageCostMarginReport xreport = new HCMIS.Desktop.Reports.AverageCostMarginReport();
                xreport.DataSource = BLL.Receipt.GetMarginByAccount(Convert.ToInt32(lkAccount.EditValue), Convert.ToInt32(lkCategories.EditValue));
                xreport.CreateDocument();
                PrintPreview.PrintingSystem = xreport.PrintingSystem;
            }
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            lkCategories_EditValueChanged(null, null);
        }

        private void cmbPrintChoice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      }
}
