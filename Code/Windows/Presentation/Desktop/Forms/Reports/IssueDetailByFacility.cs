using System;
using System.Data;
using BLL;
using DevExpress.XtraLayout.Utils;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Helpers;
using HCMIS.Reports.Helpers;
using HCMIS.Reports.Reports;
using DevExpress.XtraReports.UI;

//using HCMIS.Reports.Views;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("RP-ID-ID-DF", "Issue Detail by Facility", "")]
    public partial class IssueDetailByFacility : DevExpress.XtraEditors.XtraForm
    {
        private XtraReport report;
        int _facilityID;

        #region Loading And FacilitySelection

        // Loading of the Form and the left Side Menu  

        public IssueDetailByFacility()
        {
            InitializeComponent();
        }

        private void IssueDetailByFacilityLoad(object sender, EventArgs e)
        {

            grdFacilityList.DataSource = Institution.GetDistinctInstitutionForIssueDetail();
            lkAccount.SetupAccountEditor().SetDefaultAccount();
            tabIssueDetail.Visibility = LayoutVisibility.Always;
            DataRow selectedFacility = grdFacilityListView.GetFocusedDataRow();
             if (lkAccount.EditValue != null && selectedFacility != null)
            {
                _facilityID = Convert.ToInt32(selectedFacility["ID"]);
                LoadReport(Convert.ToInt32(lkAccount.EditValue), Convert.ToDateTime(dtFrom.Value), Convert.ToDateTime(dtTo.Value), _facilityID);
            }
        }

        private void GrdFacilityListViewFocusedRowChanged(object sender,DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow selectedFacility = grdFacilityListView.GetFocusedDataRow();

            if (lkAccount.EditValue != null && selectedFacility != null)
            {
                _facilityID = Convert.ToInt32(selectedFacility["ID"]);
               
                if (lkAccount.EditValue != null)
                {
                    LoadReport(Convert.ToInt32(lkAccount.EditValue), Convert.ToDateTime(dtFrom.Value), Convert.ToDateTime(dtTo.Value), _facilityID);
                }

            }
        }

        private void ClearSelection()
        {
            lkAccount.EditValue = null;
        }

        #endregion

        #region Report

        private void LoadReport(int accountID,DateTime fromDate,DateTime toDate,int facilityID)
        {
            IssueDetailForFacilityReport issuDetailByFacilityReport = new IssueDetailForFacilityReport(CurrentContext.LoggedInUserName);
            issuDetailByFacilityReport.DataSource = Issue.GetIssueDetailByFacility(accountID, fromDate, toDate, facilityID);
            printIssueDetailByFacility.PrintingSystem = issuDetailByFacilityReport.PrintingSystem;
            issuDetailByFacilityReport.xrAccount.Text = lkAccount.Text;
            issuDetailByFacilityReport.xrFrom.Text = dtFrom.Text;
            issuDetailByFacilityReport.xrTo.Text = dtTo.Text;
            issuDetailByFacilityReport.xrAccount.Text = lkAccount.Text;
            report = issuDetailByFacilityReport;     
            issuDetailByFacilityReport.CreateDocument();
        }


        #endregion

        private void btnIssueDetailByFacilityPrint_Click(object sender, EventArgs e)
        {
            if (printIssueDetailByFacility.PrintingSystem != null)
            {
                report.PrintDialog();
            }
        }

       
        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            DataRow selectedFacility = grdFacilityListView.GetFocusedDataRow();
            if (lkAccount.EditValue != null && selectedFacility != null)
            {
                _facilityID = Convert.ToInt32(selectedFacility["ID"]);
                LoadReport(Convert.ToInt32(lkAccount.EditValue), Convert.ToDateTime(dtFrom.Value), Convert.ToDateTime(dtTo.Value), _facilityID);
            }
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            DataRow selectedFacility = grdFacilityListView.GetFocusedDataRow();
            if (lkAccount.EditValue != null && selectedFacility != null)
            {
                _facilityID = Convert.ToInt32(selectedFacility["ID"]);
                LoadReport(Convert.ToInt32(lkAccount.EditValue), Convert.ToDateTime(dtFrom.Value), Convert.ToDateTime(dtTo.Value), _facilityID);
            }
        }

        private void lkAccount_EditValueChanged(object sender, EventArgs e)
        {
            DataRow selectedFacility = grdFacilityListView.GetFocusedDataRow();
            if (lkAccount.EditValue != null && selectedFacility != null)
            {
                _facilityID = Convert.ToInt32(selectedFacility["ID"]);
                LoadReport(Convert.ToInt32(lkAccount.EditValue), Convert.ToDateTime(dtFrom.Value), Convert.ToDateTime(dtTo.Value), _facilityID);
            }
            
        }

       

    } 
}

