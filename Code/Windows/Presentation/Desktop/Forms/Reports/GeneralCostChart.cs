using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.Reports
{
   [FormIdentifier("RP-CG-CG-RP","Receive vs Issue Report","")]
    public partial class GeneralCostChart : XtraForm
    {
       
       // System.Runtime.InteropServices.DllImportAttribute("gdi32.dll");

        
        public GeneralCostChart()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            lkAccount.SetupActivityEditor().SetDefaultActivity();
            GeneratCostChart();
            
        }

        DateTime dtCurrent = new DateTime();



        private void GeneratCostChart()
        {
            DataTable dtList = new DataTable();
            DataTable dtCons = new DataTable();
            string[] co = { "Ham", "Neh", "Mes", "Tek", "Hed", "Tah", "Tir", "Yek", "Meg", "Miz", "Gen", "Sen" };

            //foreach(string s in co)
            //{
            dtList.Columns.Add("Month");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);

            dtCons.Columns.Add("Month");
            dtCons.Columns.Add("Value");
            dtCons.Columns[1].DataType = typeof(Int64);

            int[] mon = { 11, 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] cos = new double[12];
            DataTable dtBal = new DataTable();
            Item recd = new Item();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            int year = (dtCurrent.Month < 11) ? dtCurrent.Year : dtCurrent.Year + 1;
            int storeId = Convert.ToInt32(lkAccount.EditValue);
            // int curMonth = (dtCurrent.Month < 11)?dtCurrent.Month +2:((dtCurrent.Month ==11)?1:2);
            for (int i = 0; i < mon.Length; i++)
            {
               // if (!(year == dtCurrent.Year && mon[i] > dtCurrent.Month && mon[i] < 11))
                if (((mon[i] == 11 || mon[i] == 12) && (mon[i] <= dtCurrent.Month || year == dtCurrent.Year)) || (mon[i] < 11 && mon[i] <= dtCurrent.Month && year == dtCurrent.Year))
                {
                    int yr = (mon[i] < 11) ? dtCurrent.Year : year;
                    // dtBal = bal.GetSOH(itemId,storeId,mon[i],yr);
                    double recVal = recd.GetCostReceiveByItemPerMonth(mon[i], storeId, yr);
                    object[] objrec = { co[i], recVal };
                    double issVal = recd.GetCostIssuedByItemPerMonth(mon[i], storeId, yr);
                    object[] objiss = { co[i], issVal };
                    dtList.Rows.Add(objrec);
                    dtCons.Rows.Add(objiss);
                }
            }

            chartReceiveCost.Series.Clear();

            Series ser = new Series("Received Cost In Birr", ViewType.Line);
            ser.DataSource = dtList;
            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Month";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
           // ser.PointOptions.ValueNumericOptions.Precision = 1;            
            chartReceiveCost.Series.Add(ser);

            Series serIss = new Series("Issued Cost In Birr", ViewType.Line);
            serIss.DataSource = dtCons;
            serIss.ArgumentScaleType = ScaleType.Qualitative;
            serIss.ArgumentDataMember = "Month";
            serIss.ValueScaleType = ScaleType.Numerical;
            serIss.ValueDataMembers.AddRange(new string[] { "Value" });
            serIss.PointOptions.ValueNumericOptions.Format = NumericFormat.Number;
            //serIss.PointOptions.ValueNumericOptions.Precision = 1;            
            chartReceiveCost.Series.Add(serIss);
            ((XYDiagram)chartReceiveCost.Diagram).AxisY.NumericOptions.Format = NumericFormat.Number;
            ((XYDiagram)chartReceiveCost.Diagram).AxisY.NumericOptions.Precision = 0;
        }

      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //TODO: implement print here
        }

       

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            GeneratCostChart();
        }

    }
}