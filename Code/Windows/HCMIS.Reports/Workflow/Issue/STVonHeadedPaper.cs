
using HCMIS.Shared.Helpers;
using System;
namespace HCMIS.Desktop.Reports
{    
    public partial class STVonHeadedPaper : DevExpress.XtraReports.UI.XtraReport
    {
        public int _orderID;
        public double totalWithoutInsurance;
        public double insuranceValue;
        public bool _includeInsurance;

        public STVonHeadedPaper()
        {
            InitializeComponent();
        }

        public STVonHeadedPaper(int orderID, bool includeInsurance, string userFullName)
        {
            InitializeComponent();
            _includeInsurance = includeInsurance;
            _orderID = orderID;
            PrintUserDetailOnReport(userFullName);
        }

        private void PrintUserDetailOnReport(string userFullName)
        {
            xrLabelReportPrintedBy.Text = string.Format("Printed by {0} on {1}", userFullName,
                                                        BLL.DateTimeHelper.ServerDateTime);
        }

        private void PriceInWords_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {
           
            if (e.Value != null)
            {
                double grandTotal = Convert.ToDouble(e.Value.ToString().Replace(",", ""));
                if (_includeInsurance)
                {
                    grandTotal += BLL.Order.GetInsuranceValue(_orderID, grandTotal);
                }
                e.Text = NumberToEnglish.ConvertMoneyToWords(grandTotal);
            }
        }

        private void xrInsuranceValue_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {
            try
            {
                NumberToEnglish converter = new NumberToEnglish();
                totalWithoutInsurance = Convert.ToDouble(e.Value);
                if (_includeInsurance)
                {

                    BLL.Order order = new BLL.Order();
                    insuranceValue = BLL.Order.GetInsuranceValue(_orderID, totalWithoutInsurance);
                    e.Text = insuranceValue.ToString("###,###,##0.#0");
                    xrTotalPrice.Text = (insuranceValue + totalWithoutInsurance).ToString();
                   
                }
                else
                {
                    insuranceValue = 0;
                    e.Text = " - ";
                    xrTotalPrice.Text = totalWithoutInsurance.ToString();
                    
                }
            }
            catch
            {
            }
        }

        private void xrInsuranceValue_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    BLL.Order order = new BLL.Order();
            //    double insuranceValue = BLL.Order.GetInsuranceValue(_orderID);
            //    double totalWithoutInsurance = Convert.ToDouble(xrTotalWithoutInsurance.Text);
            //    //xrTotalPrice.Text = insuranceValue.ToString();
            //    xrTotalPrice.Text = (insuranceValue + totalWithoutInsurance).ToString();
            //}
            //catch
            //{
            //}
        }

        private void xrTotalPrice_SummaryCalculated(object sender, DevExpress.XtraReports.UI.TextFormatEventArgs e)
        {

            totalWithoutInsurance = 0;
            if(e.Value != null){
            totalWithoutInsurance = Convert.ToDouble(e.Value.ToString());
            }
            
            insuranceValue = BLL.Order.GetInsuranceValue(_orderID, totalWithoutInsurance);

            e.Text = (insuranceValue + totalWithoutInsurance).ToString("###,###,##0.#0");

            try
            {
                if (_includeInsurance)
                {
                    totalWithoutInsurance = Convert.ToDouble(e.Value.ToString());
                    insuranceValue = BLL.Order.GetInsuranceValue(_orderID, totalWithoutInsurance);
                    e.Text = (insuranceValue + totalWithoutInsurance).ToString("###,###,##0.#0");
                }
                else
                {
                    insuranceValue = 0;
                    totalWithoutInsurance = Convert.ToDouble(e.Value.ToString());
                    e.Text = totalWithoutInsurance.ToString("###,###,##0.#0");
                }
            }
            catch
            {
            }


        }
    }
}