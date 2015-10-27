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

namespace HCMIS.Desktop.Forms.Reports
{
   
    public partial class GeneralExpiryChart : XtraForm
    {
        public GeneralExpiryChart()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            
            Activity stor = new Activity();
            stor.LoadAll();
            DataTable dtStor = stor.DefaultView.ToTable();
            cboStores.DataSource = dtStor;

            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            ConvertDate.DateConverter(dtDate.Text);
        }

        public void GenerateExpiryChart()
        {
            // Generate the pie Chart for the Current SOH and EXpired Drugs

            ReceiveDoc rec = new ReceiveDoc();
            Balance bal = new Balance();
            chartPie.Series.Clear();

            Item itm = new Item();
            int storeId = Convert.ToInt32(cboStores.SelectedValue);
            object[] objExp = itm.CountExpiredItemsAndAmount(storeId);
            Int64 expAmount = Convert.ToInt64(objExp[0]);
            Double expCost = Convert.ToDouble(objExp[1]);
            // TOFIX ---------
            object[] nearObj = itm.CountNearlyExpiredQtyAmount(storeId);
            Int64 nearExpAmount = Convert.ToInt64(nearObj[0]);
            double nearExpCost = Convert.ToDouble(nearObj[1]);

            object[] sohObj = {0,0}; //itm.GetAllSohQtyAmount(storeId);
            Int64 soh = Convert.ToInt64(sohObj[0]);
            double sohPrice = Convert.ToDouble(sohObj[1]);

            Int64 normal = (soh - nearExpAmount - expAmount);
            Int64 nearExpiry = nearExpAmount;
            Int64 expired = expAmount;


            object[] obj = { normal, nearExpiry, expired };

            DataTable dtSOHList = new DataTable();
            dtSOHList.Columns.Add("Type");
            dtSOHList.Columns.Add("Value");
            dtSOHList.Columns[1].DataType = typeof(Int64);
            double normalPrice = (sohPrice - nearExpCost - expAmount);

            Int64 totItm = normal + nearExpiry + expired;

            object[] oo = { "Normal : " + normalPrice.ToString("C"), obj[0] };
            dtSOHList.Rows.Add(oo);

            object[] oo3 = { "Expired : " + expCost.ToString("C"), obj[2] };
            dtSOHList.Rows.Add(oo3);

            object[] oo2 = { "Near Expiry : " + nearExpCost.ToString("C"), obj[1] };
            dtSOHList.Rows.Add(oo2);

            decimal per = 0;
            if (Convert.ToDecimal(totItm) > 0)
            {
                per = Convert.ToDecimal(normal) / Convert.ToDecimal(totItm) * 100;
            }
           

            Series serExpired = new Series("pie", ViewType.Pie3D);
            serExpired.DataSource = dtSOHList;

            serExpired.ArgumentScaleType = ScaleType.Qualitative;
            serExpired.ArgumentDataMember = "Type";
            serExpired.ValueScaleType = ScaleType.Numerical;
            serExpired.ValueDataMembers.AddRange(new string[] { "Value" });
            serExpired.PointOptions.PointView = PointView.ArgumentAndValues;
            serExpired.LegendText = "Key";
            serExpired.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            serExpired.PointOptions.ValueNumericOptions.Precision = 0;
            ((PieSeriesLabel)serExpired.Label).Position = PieSeriesLabelPosition.TwoColumns;
        
            ((PiePointOptions)serExpired.PointOptions).PointView = PointView.ArgumentAndValues;
         
            chartPie.Series.Add(serExpired);
            chartPie.Size = new System.Drawing.Size(1000, 500);
        
        }

        private void cboStores_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null)
                GenerateExpiryChart();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            
            g1.ReleaseHdc(dc1);
            g2.ReleaseHdc(dc2);
            MyImage.Save(@"c:\PrintPage.jpg", ImageFormat.Jpeg);
            FileStream fileStream = new FileStream(@"c:\PrintPage.jpg", FileMode.Open, FileAccess.Read);
            StartPrint(fileStream, "Image");
            fileStream.Close();
            if (System.IO.File.Exists(@"c:\PrintPage.jpg"))
            {
                System.IO.File.Delete(@"c:\PrintPage.jpg");
            }
        }

        public void StartPrint(Stream streamToPrint, string streamType)
        {
            this.printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
          
            System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
            PrintDialog1.AllowSomePages = true;
            printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;
            PrintDialog1.ShowHelp = true;
            printDoc.DefaultPageSettings.Landscape = true;
            printDialog1.PrinterSettings.DefaultPageSettings.Landscape = true;

            PrintDialog1.Document = printDoc;
            DialogResult result = PrintDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDoc.Print();
                //docToPrint.Print();
            }
        }

         }
}