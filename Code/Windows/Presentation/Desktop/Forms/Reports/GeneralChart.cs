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
   
    public partial class GeneralChart : XtraForm
    {
       
       // System.Runtime.InteropServices.DllImportAttribute("gdi32.dll");

        private System.IO.Stream streamToPrint;
        string streamType;
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt
        (
            IntPtr hdcDest, // handle to destination DC
            int nXDest, // x-coord of destination upper-left corner
            int nYDest, // y-coord of destination upper-left corner
            int nWidth, // width of destination rectangle
            int nHeight, // height of destination rectangle
            IntPtr hdcSrc, // handle to source DC
            int nXSrc, // x-coordinate of source upper-left corner
            int nYSrc, // y-coordinate of source upper-left corner
            System.Int32 dwRop // raster operation code
        );
        
        public GeneralChart()
        {
            InitializeComponent();
        }

        private void GeneralReport_Load(object sender, EventArgs e)
        {
            
            Activity stor = new Activity();
            stor.LoadAll();
            DataTable dtStor = stor.DefaultView.ToTable();
            object[] obj = {0,1,"All"};
            //if(stor.RowCount > 1)
                //dtStor.Rows.Add(obj);
            cboStores.DataSource = dtStor;
            //if (stor.RowCount > 1)
            //    cboStores.SelectedValue = 0;

            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtCurrent = ConvertDate.DateConverter(dtDate.Text);
            curMont = dtCurrent.Month;
            curYear = dtCurrent.Year;

            Item itm = new Item();
            DataTable dtyears = itm.AllYears();

            foreach (DataRow drYears in dtyears.Rows)
            {
                int yr = Convert.ToInt32(drYears["year"]);
                cboYear.Items.Add(yr);
            }
            cboYear.SelectedItem = dtCurrent.Year;
            
        }

        DateTime dtCurrent = new DateTime();
        int curMont = 0;
        int curYear = 0;

        private void GenerateStockStatusPieChart()
        {
            ReceiveDoc rec = new ReceiveDoc();
            
            progressBar1.Visible = true;
            chartPie.UseWaitCursor = true;
            chartPie.Series.Clear();
            int storeId = (cboStores.SelectedValue != null) ? Convert.ToInt32(cboStores.SelectedValue) : 0;
            
            int neverRec = rec.CountNeverReceivedItems(storeId);

            curYear = Convert.ToInt32(cboYear.SelectedItem);
            curMont = (curYear == dtCurrent.Year) ? dtCurrent.Month : 12;
            progressBar1.PerformStep();
           
           
            
            DataTable dtList = new DataTable();
            dtList.Columns.Add("Type");
            dtList.Columns.Add("Value");
            dtList.Columns[1].DataType = typeof(Int64);

            //TODO: the pie has to display something doesn't it?

            Series ser = new Series("pie", ViewType.Pie3D);
            ser.DataSource = dtList;
            
            ser.ArgumentScaleType = ScaleType.Qualitative;
            ser.ArgumentDataMember = "Type";
            ser.ValueScaleType = ScaleType.Numerical;
            ser.ValueDataMembers.AddRange(new string[] { "Value" });
            ser.PointOptions.PointView = PointView.ArgumentAndValues;
            ser.LegendText = "Key";
            ser.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
            ser.PointOptions.ValueNumericOptions.Precision = 0;

            progressBar1.PerformStep();
           
            ((PieSeriesLabel)ser.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PiePointOptions)ser.PointOptions).PointView = PointView.ArgumentAndValues;
            

            
            chartPie.Series.Add(ser);
            chartPie.Size = new System.Drawing.Size(1000, 500);
            progressBar1.PerformStep();


            lblHeader.Text = GeneralInfo.Current.HospitalName + " Stock Status summary of year " + curYear + " of " + cboStores.Text;
            progressBar1.Visible = false;
            chartPie.UseWaitCursor = false;
        }

        

        private void cboStores_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null && cboYear.SelectedItem != null)
            GenerateStockStatusPieChart();
        }

        private void cboYear_SelectedValueChanged(object sender, EventArgs e)
        {
           if(cboStores.SelectedValue != null && cboYear.SelectedItem != null)
            GenerateStockStatusPieChart();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Image image = System.Drawing.Image.FromStream( this.streamToPrint);
            int x = e.MarginBounds.X;
            int y = e.MarginBounds.Y;
            int width = image.Width;
            int height = image.Height;
            if ((width / e.MarginBounds.Width) > (height / e.MarginBounds.Height))
            {
                width = e.MarginBounds.Width;
                height = image.Height * e.MarginBounds.Width / image.Width;
            }
            else
            {
                height = e.MarginBounds.Height;
                width = image.Width * e.MarginBounds.Height / image.Height;
            }
            System.Drawing.Rectangle destRect = new System.Drawing.Rectangle(x, y, width, height);
            e.Graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, System.Drawing.GraphicsUnit.Pixel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g1 = this.CreateGraphics();
            Image MyImage = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, g1);
            Graphics g2 = Graphics.FromImage(MyImage);
            IntPtr dc1 = g1.GetHdc();
            IntPtr dc2 = g2.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
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
            this.streamToPrint = streamToPrint;
            this.streamType = streamType;
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

        private void ckExclude_CheckedChanged(object sender, EventArgs e)
        {
            if (cboStores.SelectedValue != null && cboYear.SelectedItem != null)
                GenerateStockStatusPieChart();
        }

            



    }
}