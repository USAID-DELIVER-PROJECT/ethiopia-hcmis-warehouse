using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HCMIS.Reports.Reports
{
     
    public partial class OrderSummary : DevExpress.XtraReports.UI.XtraReport
    {
        private decimal _totalQuantity = 0;
        private decimal _invoiceQuantity = 0;
        public OrderSummary()
        {
            InitializeComponent();
        }

       

        private void xrTableCell6_SummaryReset(object sender, EventArgs e)
        {
            _totalQuantity = 0;
           
        }

        private void xrTableCell6_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
        {
            _invoiceQuantity = Convert.ToDecimal((sender as XRLabel).Tag);

            var result = Convert.ToDecimal(_invoiceQuantity - _totalQuantity);
            e.Result = result;
            if (result < 0)
            {
                 e.Result = "Invoice quantity entered is Less Than Total Receive Please Correct it.";
            }
  
            e.Handled = true;
        }

        private void xrTableCell6_SummaryRowChanged(object sender, EventArgs e)
        {
            _totalQuantity += Convert.ToDecimal(GetCurrentColumnValue("ReceivedQty"));
    
        }

        private void xrLabel12_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
           
            

        }

        private void xrTableCell6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void xrTableCell6_SummaryCalculated(object sender, TextFormatEventArgs e)
        {

        }

    }
}
