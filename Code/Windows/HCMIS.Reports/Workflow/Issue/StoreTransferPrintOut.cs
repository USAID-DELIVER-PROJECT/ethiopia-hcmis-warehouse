using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLL;
using System.Data;

namespace HCMIS.Desktop.Reports
{
    public partial class StoreTransferPrintOut : DevExpress.XtraReports.UI.XtraReport
    {
        public StoreTransferPrintOut()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

       public void LoadByPickListID(int PicklistID)
       {
           DataRowView drv = Transfer.GetStoreTransfer(PicklistID);

           this.ToAccount.Text = drv["ToAccount"].ToString();
           this.ToStore.Text = drv["ToStore"].ToString();
           this.Date.Text = EthiopianDate.EthiopianDate.GregorianToEthiopian(Convert.ToDateTime(drv["Date"].ToString())).ToString();
           this.FromStore.Text = drv["FromStore"].ToString();
           this.DataSource = Transfer.GetDetailForStoreTransfer(PicklistID);
       }
    }
}
