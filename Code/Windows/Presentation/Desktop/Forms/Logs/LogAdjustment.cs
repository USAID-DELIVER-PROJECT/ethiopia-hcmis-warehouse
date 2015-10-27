using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Logs
{
    [FormIdentifier("AL-LA-LA-RP","Loss and Adjustment Log","")]
    public partial class LogAdjustment : XtraForm
    {
        public LogAdjustment()
        {
            InitializeComponent();
        }

        private void ManageItems_Load(object sender, EventArgs e)
        {
            LossAndAdjustmentReason rec = new LossAndAdjustmentReason();
            DataTable dtDis = rec.GetAvailableReasons();
            cboReasons.Properties.DataSource = dtDis;
            cboReasons.ItemIndex = 0;
            lkActivity.SetupActivityEditor().SetDefaultActivity();
           
            
        }

        
        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            if (lkActivity.EditValue != null)
            {
                LossAndAdjustment Adj = new LossAndAdjustment();
                DataTable dtRec = Adj.GetDistinctAdjustmentDocments(Convert.ToInt32(lkActivity.EditValue));
                /*PopulateDocument(dtRec);*/ lstTree.DataSource = dtRec;
                DateTime dt1 = new DateTime();
                DateTime dt2 = new DateTime();
                CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
                dtDate.CustomFormat = "MM/dd/yyyy";
                dtDate.Value = DateTimeHelper.ServerDateTime;
                DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);
                int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                dt1 = new DateTime(yr, 11, 1);
                dt2 = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
                dtRec = Adj.GetTransactionByDateRange(Convert.ToInt32(lkActivity.EditValue), dt1, dt2);
                lblAdjDate.Text = "Current Year";
                gridAdjustments.DataSource = dtRec;
            }
        }

        private void cboReasons_EditValueChanged(object sender, EventArgs e)
        {
            if (lkActivity.EditValue != null && cboReasons.EditValue != null)
            {
                LossAndAdjustment Adj = new LossAndAdjustment();
                DataTable dtRec = new DataTable();
                dtRec = Adj.GetTransactionByReason(Convert.ToInt32(lkActivity.EditValue), Convert.ToInt32(cboReasons.EditValue));
                gridAdjustments.DataSource = dtRec;                
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LossAndAdjustment Adj = new LossAndAdjustment();
            DataTable dtRec = new DataTable();
            dtFrom.CustomFormat = "MM/dd/yyyy";
            dtTo.CustomFormat = "MM/dd/yyyy";
            DateTime dteFrom = new DateTime();
            DateTime dteTo = new DateTime();
            dteFrom = ConvertDate.DateConverter(dtFrom.Text);
            dteTo = ConvertDate.DateConverter(dtTo.Text);
            
            if (dteFrom < dteTo)
            {
                dtRec = Adj.GetTransactionByDateRange(Convert.ToInt32(lkActivity.EditValue), dteFrom, dteTo);
            }
            else
            {
                dtRec = Adj.GetAllTransaction(Convert.ToInt32(lkActivity.EditValue));
            }
            gridAdjustments.DataSource = dtRec;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Microsoft Excel | *.xls";

            if (DialogResult.OK == saveDlg.ShowDialog())
            {
                gridAdjustments.MainView.ExportToXls(saveDlg.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
         
            DevExpress.XtraPrinting.PrintingSystem ps = new DevExpress.XtraPrinting.PrintingSystem();
            DevExpress.XtraPrinting.PrintableComponentLink pcl = new DevExpress.XtraPrinting.PrintableComponentLink(ps);

            pcl.CreateReportHeaderArea += this.pcl_CreateReportHeaderArea;

            pcl.Component = gridAdjustments;
            pcl.Landscape = true;

            pcl.CreateDocument();
            ps.PreviewFormEx.ShowDialog();
        }

        private void pcl_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
            dtDate.Value = DateTimeHelper.ServerDateTime;
            dtDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtCurrent = Convert.ToDateTime(dtDate.Text);
            string header = GeneralInfo.Current.HospitalName + " Loss/Adjustment Activity Log " + dtCurrent.ToString("MM dd,yyyy");

            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(header, Color.Navy, new RectangleF(0, 0, 500, 40),
            DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Arial", 16);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        private void LstTreeFocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DateTime dt1 = new DateTime();
            DateTime dt2 = new DateTime();
            CalendarLib.DateTimePickerEx dtDate = new CalendarLib.DateTimePickerEx();
            dtDate.CustomFormat = "MM/dd/yyyy";
            dtDate.Value = DateTimeHelper.ServerDateTime;
            DateTime dtCurrent = ConvertDate.DateConverter(dtDate.Text);

            DataRowView dr = (DataRowView)lstTree.GetDataRecordByNode(lstTree.FocusedNode);

            if (dr != null)
            {
              
                LossAndAdjustment disp = new LossAndAdjustment();
                DataTable dtRec = new DataTable();
                if (dr["ParentID"] == DBNull.Value)
                {
                    int yr = ((dtCurrent.Month > 10) ? dtCurrent.Year : dtCurrent.Year - 1);
                    dt1 = new DateTime(Convert.ToInt32(dr["ID"]) - 1, 11, 1);
                    dt2 = new DateTime(Convert.ToInt32(dr["ID"]), 11, 1);
                    dtRec = disp.GetTransactionByDateRange(Convert.ToInt32(lkActivity.EditValue), dt1, dt2);
                    string dateString = dr["RefNo"].ToString();
                    lblAdjDate.Text = dateString;
                }
                else
                {
                    dtRec = disp.GetDocumentByRefNo(dr["RefNo"].ToString(), Convert.ToInt32(lkActivity.EditValue), dr["Date"].ToString());
                    lblAdjDate.Text = Convert.ToDateTime(dr["Date"]).ToString("MM dd,yyyy");
                }
                gridAdjustments.DataSource = dtRec;
            }
        }
       

        
    }
}