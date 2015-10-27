using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraVerticalGrid.Events;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Reports;
using HCMIS.Desktop.Forms.Modals;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-DR-TF-RP","Distribution Report","")]
    public partial class DistributionReport : XtraForm
    {

        int _chosenStoreTypeID = Mode.Constants.HEALTH_PROGRAM;

        public DistributionReport()
        {
            InitializeComponent();
        }

        private void DistributionReport_Load(object sender, EventArgs e)
        {
            dtFromFacilitySupply.Text = dtToTopFacilities.Text =  dtFrom.Text = @"7/7/2010";
            btnRefresh_Click(null, null);
            Institution institution = new Institution();

            institution.LoadAll();
            gridFacilities.DataSource = institution.DefaultView;

            gridTopFacilities.DataSource = BLL.Institution.GetTopReceivingUnits();
            //TODO: add a combo box for selection and change this 1 whenever that combo is changed
            gridItemList.DataSource = Item.GetActiveItemsByCommodityType(1, null);
            lkStoreType.SetupModeEditor().SetDefaultMode();
        }

        private DistributionBreakdown _distributionBreakdown;
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();

            printControl1.Enabled = false;
            picLoading.Visible = true;

        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _distributionBreakdown = (DistributionBreakdown) e.Result;
            if (_distributionBreakdown != null)
            {
                printControl1.PrintingSystem = _distributionBreakdown.PrintingSystem;
                _distributionBreakdown.CreateDocument(true);
            }
            printControl1.Enabled = true;
            picLoading.Visible = false;
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataSet ds = new DataSet();
            DateTime dateFrom = dtFrom.Value;
            DateTime dateTo = dtTo.Value;
            ds.Tables.Add(IssueDoc.GetIssueSummaryBySupplier(dateFrom, dateTo,_chosenStoreTypeID));
            ds.Tables[0].TableName = "SupplierSummary";
            ds.Tables.Add(IssueDoc.GetIssueBreakdownBySupplier(dateFrom, dateTo,_chosenStoreTypeID));
            ds.Tables[1].TableName = "SupplierBreakdown";

            var _distributionBreakdow = new DistributionBreakdown
            {
                HubName = { Text = GeneralInfo.Current.HospitalName },
                DateRange =
                {
                    Text =
                        string.Format("{0} to {1}", dtFrom.Text,
                                      dtTo.Text)
                },
                DataSource = ds
            };
            e.Result = _distributionBreakdow;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _distributionBreakdown.PrintDialog();
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //distributionBreakdown.ExportToXlsx();
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView3.GetFocusedDataRow();
            if (dr != null)
            {
                int facilityID = Convert.ToInt32(dr["ID"]);
                gridFacilityBreakdown.DataSource = Institution.GetResupplyPerUnit(facilityID);
                txtSelectedFacility.Text = dr["Name"].ToString();
            }
        }

        private void txtSearchFacility_EditValueChanged(object sender, EventArgs e)
        {
            gridView3.ActiveFilterString = string.Format("Name like '{0}%'", txtSearchFacility.Text);
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView4.GetFocusedDataRow();
            if (dataRow != null)
            {
                // do the thing here.
                gridTopItemReceivingFacilities.DataSource = chartControl1.Series[0].DataSource = IssueDoc.TopItemReceivers(Convert.ToInt32(dataRow["ID"]));
            }
        }

        private void gridTopFacilities_DoubleClick(object sender, EventArgs e)
        {
            DataRow dRow = gridViewTopFacilities.GetFocusedDataRow();
            int receivingUnitID = int.Parse(dRow["ID"].ToString());

            ReceivingUnitIssueHistory history = new ReceivingUnitIssueHistory(receivingUnitID);
            history.ShowDialog();            
        }

        private void lkStoreType_EditValueChanged(object sender, EventArgs e)
        {
            if (lkStoreType.EditValue != null || lkStoreType.EditValue != "")
            {
                _chosenStoreTypeID = int.Parse(lkStoreType.EditValue.ToString());
                btnRefresh_Click(null, null);
            }
        }

        private void btnExportTopFacilities_Click(object sender, EventArgs e)
        {
            var saveFileTo = new SaveFileDialog();
            if (saveFileTo.ShowDialog() != DialogResult.Cancel)
            {
                gridTopFacilities.ExportToXlsx(saveFileTo.FileName + ".xlsx");
                XtraMessageBox.Show("File has been Exported!");
            }
        }

        private void btnPrintTopFacilities_Click(object sender, EventArgs e)
        {
           //PrintGrid(gridViewTopFacilities);
            gridViewTopFacilities.OptionsPrint.AutoWidth = true;
            gridViewTopFacilities.Print();
        }


        private void btnPrintItemReport_Click(object sender, EventArgs e)
        {
            PrintGrid(gridView5);
        }

        private void btnExportItems_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gridView5);
        }

        private void btnExportFacilitiyBreakdown_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gridView2);
        }

        private void btnPrintFacilityBreakdown_Click(object sender, EventArgs e)
        {
            PrintGrid(gridView2);
        }
        
        #region Export and Print Helpers
        public void ExportGridToExcel(GridView grid)
        {
            var saveFileTo = new SaveFileDialog();
            if (saveFileTo.ShowDialog() != DialogResult.Cancel)
            {
                var gridExport = PrepareGridForPrint(grid);
                gridExport.ExportToXlsx(saveFileTo.FileName + ".xlsx");
                //grid.ExportToXlsx(saveFileTo.FileName + ".xlsx");
                XtraMessageBox.Show("File has been Exported!");
            }
        }

        public void PrintGrid(GridView gridView)
        {
            var printComp = PrepareGridForPrint(gridView);
            printComp.ShowPreview();
        }

        private PrintableComponentLink PrepareGridForPrint(GridView gridView)
        {
            gridView.OptionsPrint.AutoWidth = true;
            var printComp = new PrintableComponentLink(new PrintingSystem());
            printComp.CreateReportHeaderArea += PrintCompOnCreateReportHeaderArea;
            printComp.Component = gridView.GridControl;
            printComp.CreateDocument();
            return printComp;
        }

        private void PrintCompOnCreateReportHeaderArea(object sender, CreateAreaEventArgs createAreaEventArgs)
        {
            TextBrick brick = createAreaEventArgs.Graph.DrawString(txtSelectedFacility.Text + " Report", Color.Black, new RectangleF(0, 0, 500, 40), BorderSide.None);
            brick.Font = new Font("Tahoma", 12);
            brick.StringFormat = new BrickStringFormat(StringAlignment.Near);
        }

       
        #endregion

                private void btnExp_Click(object sender, EventArgs e)
        {
            var filedialog = new SaveFileDialog();
            filedialog.AddExtension = true;
            filedialog.CheckPathExists = true;
            filedialog.Title = "Save Exported file";
            filedialog.FileName = "DistributionReport";
            
            if (filedialog.ShowDialog() == DialogResult.OK)
            { 
                _distributionBreakdown.ExportToXlsx(filedialog.FileName);
                 XtraMessageBox.Show("File has been Exported!");
                }
        }
        
        
    }
}
