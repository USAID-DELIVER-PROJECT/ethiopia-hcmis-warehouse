using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using BLL.Models;
using DevExpress.Data.Mask;
using DevExpress.XtraPrinting;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("PR-PH-PH-RP", "Price List History", "")]
    public partial class ItemPriceHistoryReport : Form
    {
       private  DateTime _date;
        readonly int  _useriD = CurrentContext.UserId;
        DataTable _datasource;
        List<int> _allActivityIDs = new List<int>();
       
        public ItemPriceHistoryReport()
        {
            InitializeComponent();
        }

        private void ItemPriceHistoryReport_Load(object sender, EventArgs e)
        {
            //if (lkenddate.EditValue == null || (string) lkenddate.EditValue == "")
            //{
            //    _date = DateTime.Now;
            //    _datasource = Receipt.GetItemPriceHistoryCostTierByDate(_date,_useriD);
            //}
            //else
            //{
            //    _date =Convert.ToDateTime(lkenddate.DateTime);
            //    _datasource = Receipt.GetItemPriceHistoryCostTierByDate(_date,_useriD);
            //}

            //gridPriceHistory.DataSource = _datasource.DefaultView;
            lkenddate.EditValue = DateTime.Now;
            lkstartdate.EditValue = DateTime.Now;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gridViewPriceHistory.OptionsPrint.AutoWidth = true;
            var printableComponent = new PrintableComponentLink(new PrintingSystem())
            {
               Component = gridPriceHistory,
               Landscape =  true, 
               PaperKind = PaperKind.A4,
            };
            printableComponent.CreateReportHeaderArea += printableComponent_CreateReportHeaderArea;
            printableComponent.CreateDocument();
            printableComponent.ShowPreview();
            
           
        }

        private void printableComponent_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            const string reportHeader = "Price List History Report";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
            var rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString(reportHeader, Color.Black, rec, BorderSide.None);
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            var datasource = _datasource.AsDataView();

            datasource.RowFilter = string.Format("StoreID='{0}'", Int32.Parse(lkAccount.EditValue.ToString()));

            gridPriceHistory.DataSource = datasource;
        }

        private void btnload_Click(object sender, EventArgs e)
        {
          DateTime  sdate = (DateTime)lkstartdate.EditValue;
          DateTime enddate = (DateTime)lkenddate.EditValue;
          _datasource = Receipt.GetItemPriceHistoryCostTierByDate(sdate,enddate, _useriD);
            gridPriceHistory.DataSource = _datasource.DefaultView;

            //extract Distinct Activites from the datasource
            List<int> ActivityIDList = new List<int>();
            foreach (DataRow row in _datasource.Rows)
            {
                if (!ActivityIDList.Contains((int)row["StoreID"]))
                {

                    ActivityIDList.Add((int)row["StoreID"]);
                }
            }
            _allActivityIDs = ActivityIDList;

            //get all activities from database
            var movingAverageGroup = new MovingAverageGroup();
            movingAverageGroup.LoadByUserForPriceHistory(CurrentContext.UserId);
            DataTable allStoreGroup = movingAverageGroup.DefaultView.Table;
            DataTable filteredStoreGroup = allStoreGroup.Clone();

            //filter the activities
            foreach (DataRow row in allStoreGroup.Rows)
            {
                DataRow newRow = filteredStoreGroup.NewRow();

                if (ActivityIDList.Contains((int)row["MovingAverageID"]))
                {
                    filteredStoreGroup.Rows.Add(row.ItemArray);
                    ActivityIDList.Remove((int)row["MovingAverageID"]);
                }
            }

            lkAccount.Properties.DataSource = filteredStoreGroup;
 
        }
    }
}
