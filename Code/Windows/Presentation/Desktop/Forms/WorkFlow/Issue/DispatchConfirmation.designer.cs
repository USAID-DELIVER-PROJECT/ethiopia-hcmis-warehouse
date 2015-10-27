using DevExpress.XtraEditors;
namespace HCMIS.Desktop.Forms.WorkFlow
{
    partial class DispatchConfirmation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DispatchConfirmation));
            this.colVoidReq = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.boxSizedList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemButtonEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.lblVoidConfirmedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblVoidConfirmedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblDispatchedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblIssueStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblIssueType = new DevExpress.XtraEditors.LabelControl();
            this.lblRequistedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblVoidRequestedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblDocumentedType = new DevExpress.XtraEditors.LabelControl();
            this.lblOwnership = new DevExpress.XtraEditors.LabelControl();
            this.lblPaymentType = new DevExpress.XtraEditors.LabelControl();
            this.lblInstitutionType = new DevExpress.XtraEditors.LabelControl();
            this.lblSTVDate = new DevExpress.XtraEditors.LabelControl();
            this.lblActivity = new DevExpress.XtraEditors.LabelControl();
            this.lblSubAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblDispatchConfirmedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblSTVPrintedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblSTVNo = new DevExpress.XtraEditors.LabelControl();
            this.lblWoreda = new DevExpress.XtraEditors.LabelControl();
            this.lblZone = new DevExpress.XtraEditors.LabelControl();
            this.lblRegion = new DevExpress.XtraEditors.LabelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.btnGoSTV = new DevExpress.XtraEditors.SimpleButton();
            this.tEditSTVNo = new DevExpress.XtraEditors.TextEdit();
            this.dateTo = new CalendarLib.DateTimePickerEx();
            this.dateFrom = new CalendarLib.DateTimePickerEx();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            this.lkAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn96 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn97 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn98 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPreprintedInvoiceNo = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelVoidRequest = new DevExpress.XtraEditors.SimpleButton();
            this.txtFacilityNameFilter = new DevExpress.XtraEditors.TextEdit();
            this.gridUndispatchedIssues = new DevExpress.XtraGrid.GridControl();
            this.gridUndispatchedIssuesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnConfirmIssue1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnApproveVoidRequest = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmFromStore = new DevExpress.XtraEditors.TextEdit();
            this.btnMarkAsVoid = new DevExpress.XtraEditors.SimpleButton();
            this.txtSTVInvoiceNo = new DevExpress.XtraEditors.TextEdit();
            this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.gridUndispatchedIssueDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewUndispatchedIssueDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Unit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActuallyIssuedNoOfPack = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUPicked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtIssuedBy = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup11 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem58 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.FacilityGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem60 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem62 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem56 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup19 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcRequestVoid = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lcApprovalCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcApproval = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcDispatchConfirm = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.emptySpaceItem15 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem22 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem23 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printOrder = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LastVisitlayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.NoRequisitionlayout = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem57 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem59 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem61 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxSizedList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEditSTVNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreprintedInvoiceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFacilityNameFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUndispatchedIssues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUndispatchedIssuesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmFromStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTVInvoiceNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUndispatchedIssueDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUndispatchedIssueDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssuedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacilityGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem62)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRequestVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcApprovalCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcApproval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDispatchConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastVisitlayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoRequisitionlayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem61)).BeginInit();
            this.SuspendLayout();
            // 
            // colVoidReq
            // 
            this.colVoidReq.Caption = "VoidRequest";
            this.colVoidReq.FieldName = "VoidRequest";
            this.colVoidReq.Name = "colVoidReq";
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.LookAndFeel.SkinName = "Seven";
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // boxSizedList
            // 
            this.boxSizedList.AutoHeight = false;
            this.boxSizedList.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.boxSizedList.DisplayMember = "Name";
            this.boxSizedList.Name = "boxSizedList";
            this.boxSizedList.ValueMember = "ID";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // repositoryItemDateEdit3
            // 
            this.repositoryItemDateEdit3.AutoHeight = false;
            this.repositoryItemDateEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit3.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemDateEdit3.EditFormat.FormatString = "mm-DD-YYYY";
            this.repositoryItemDateEdit3.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit3.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.repositoryItemDateEdit3.Name = "repositoryItemDateEdit3";
            // 
            // repositoryItemButtonEdit4
            // 
            this.repositoryItemButtonEdit4.AutoHeight = false;
            this.repositoryItemButtonEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.repositoryItemButtonEdit4.Name = "repositoryItemButtonEdit4";
            this.repositoryItemButtonEdit4.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutControl3
            // 
            this.layoutControl3.AllowCustomizationMenu = false;
            this.layoutControl3.Controls.Add(this.lblVoidConfirmedBy);
            this.layoutControl3.Controls.Add(this.lblVoidConfirmedDate);
            this.layoutControl3.Controls.Add(this.lblDispatchedDate);
            this.layoutControl3.Controls.Add(this.lblIssueStatus);
            this.layoutControl3.Controls.Add(this.lblIssueType);
            this.layoutControl3.Controls.Add(this.lblRequistedDate);
            this.layoutControl3.Controls.Add(this.lblVoidRequestedBy);
            this.layoutControl3.Controls.Add(this.lblDocumentedType);
            this.layoutControl3.Controls.Add(this.lblOwnership);
            this.layoutControl3.Controls.Add(this.lblPaymentType);
            this.layoutControl3.Controls.Add(this.lblInstitutionType);
            this.layoutControl3.Controls.Add(this.lblSTVDate);
            this.layoutControl3.Controls.Add(this.lblActivity);
            this.layoutControl3.Controls.Add(this.lblSubAccount);
            this.layoutControl3.Controls.Add(this.lblAccount);
            this.layoutControl3.Controls.Add(this.lblDispatchConfirmedBy);
            this.layoutControl3.Controls.Add(this.lblSTVPrintedBy);
            this.layoutControl3.Controls.Add(this.lblSTVNo);
            this.layoutControl3.Controls.Add(this.lblWoreda);
            this.layoutControl3.Controls.Add(this.lblZone);
            this.layoutControl3.Controls.Add(this.lblRegion);
            this.layoutControl3.Controls.Add(this.lblMode);
            this.layoutControl3.Controls.Add(this.btnGoSTV);
            this.layoutControl3.Controls.Add(this.tEditSTVNo);
            this.layoutControl3.Controls.Add(this.dateTo);
            this.layoutControl3.Controls.Add(this.dateFrom);
            this.layoutControl3.Controls.Add(this.btnGo);
            this.layoutControl3.Controls.Add(this.lkAccount);
            this.layoutControl3.Controls.Add(this.txtPreprintedInvoiceNo);
            this.layoutControl3.Controls.Add(this.btnCancelVoidRequest);
            this.layoutControl3.Controls.Add(this.txtFacilityNameFilter);
            this.layoutControl3.Controls.Add(this.gridUndispatchedIssues);
            this.layoutControl3.Controls.Add(this.btnConfirmIssue1);
            this.layoutControl3.Controls.Add(this.btnApproveVoidRequest);
            this.layoutControl3.Controls.Add(this.txtConfirmFromStore);
            this.layoutControl3.Controls.Add(this.btnMarkAsVoid);
            this.layoutControl3.Controls.Add(this.txtSTVInvoiceNo);
            this.layoutControl3.Controls.Add(this.txtRemarks);
            this.layoutControl3.Controls.Add(this.gridUndispatchedIssueDetails);
            this.layoutControl3.Controls.Add(this.txtIssuedBy);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.tabbedControlGroup1,
            this.layoutControlItem26,
            this.layoutControlItem21,
            this.layoutControlItem25,
            this.layoutControlItem20,
            this.layoutControlItem58,
            this.layoutControlItem27});
            this.layoutControl3.Location = new System.Drawing.Point(0, 0);
            this.layoutControl3.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(237, 213, 474, 421);
            this.layoutControl3.Root = this.layoutControlGroup7;
            this.layoutControl3.Size = new System.Drawing.Size(1123, 385);
            this.layoutControl3.TabIndex = 37;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // lblVoidConfirmedBy
            // 
            this.lblVoidConfirmedBy.Location = new System.Drawing.Point(825, 129);
            this.lblVoidConfirmedBy.Name = "lblVoidConfirmedBy";
            this.lblVoidConfirmedBy.Size = new System.Drawing.Size(61, 16);
            this.lblVoidConfirmedBy.StyleController = this.layoutControl3;
            this.lblVoidConfirmedBy.TabIndex = 106;
            // 
            // lblVoidConfirmedDate
            // 
            this.lblVoidConfirmedDate.Location = new System.Drawing.Point(825, 109);
            this.lblVoidConfirmedDate.Name = "lblVoidConfirmedDate";
            this.lblVoidConfirmedDate.Size = new System.Drawing.Size(61, 16);
            this.lblVoidConfirmedDate.StyleController = this.layoutControl3;
            this.lblVoidConfirmedDate.TabIndex = 105;
            // 
            // lblDispatchedDate
            // 
            this.lblDispatchedDate.Location = new System.Drawing.Point(803, 129);
            this.lblDispatchedDate.Name = "lblDispatchedDate";
            this.lblDispatchedDate.Size = new System.Drawing.Size(87, 16);
            this.lblDispatchedDate.StyleController = this.layoutControl3;
            this.lblDispatchedDate.TabIndex = 104;
            // 
            // lblIssueStatus
            // 
            this.lblIssueStatus.Location = new System.Drawing.Point(949, 109);
            this.lblIssueStatus.Name = "lblIssueStatus";
            this.lblIssueStatus.Size = new System.Drawing.Size(158, 16);
            this.lblIssueStatus.StyleController = this.layoutControl3;
            this.lblIssueStatus.TabIndex = 103;
            // 
            // lblIssueType
            // 
            this.lblIssueType.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblIssueType.Location = new System.Drawing.Point(949, 129);
            this.lblIssueType.Name = "lblIssueType";
            this.lblIssueType.Size = new System.Drawing.Size(158, 16);
            this.lblIssueType.StyleController = this.layoutControl3;
            this.lblIssueType.TabIndex = 102;
            // 
            // lblRequistedDate
            // 
            this.lblRequistedDate.Location = new System.Drawing.Point(619, 109);
            this.lblRequistedDate.Name = "lblRequistedDate";
            this.lblRequistedDate.Size = new System.Drawing.Size(65, 16);
            this.lblRequistedDate.StyleController = this.layoutControl3;
            this.lblRequistedDate.TabIndex = 101;
            // 
            // lblVoidRequestedBy
            // 
            this.lblVoidRequestedBy.Location = new System.Drawing.Point(619, 129);
            this.lblVoidRequestedBy.Name = "lblVoidRequestedBy";
            this.lblVoidRequestedBy.Size = new System.Drawing.Size(65, 16);
            this.lblVoidRequestedBy.StyleController = this.layoutControl3;
            this.lblVoidRequestedBy.TabIndex = 100;
            // 
            // lblDocumentedType
            // 
            this.lblDocumentedType.Location = new System.Drawing.Point(596, 55);
            this.lblDocumentedType.Name = "lblDocumentedType";
            this.lblDocumentedType.Size = new System.Drawing.Size(103, 16);
            this.lblDocumentedType.StyleController = this.layoutControl3;
            this.lblDocumentedType.TabIndex = 99;
            // 
            // lblOwnership
            // 
            this.lblOwnership.Location = new System.Drawing.Point(974, 55);
            this.lblOwnership.Name = "lblOwnership";
            this.lblOwnership.Size = new System.Drawing.Size(133, 16);
            this.lblOwnership.StyleController = this.layoutControl3;
            this.lblOwnership.TabIndex = 98;
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.Location = new System.Drawing.Point(344, 55);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(151, 16);
            this.lblPaymentType.StyleController = this.layoutControl3;
            this.lblPaymentType.TabIndex = 96;
            // 
            // lblInstitutionType
            // 
            this.lblInstitutionType.Location = new System.Drawing.Point(781, 55);
            this.lblInstitutionType.Name = "lblInstitutionType";
            this.lblInstitutionType.Size = new System.Drawing.Size(122, 16);
            this.lblInstitutionType.StyleController = this.layoutControl3;
            this.lblInstitutionType.TabIndex = 95;
            // 
            // lblSTVDate
            // 
            this.lblSTVDate.Location = new System.Drawing.Point(364, 109);
            this.lblSTVDate.Name = "lblSTVDate";
            this.lblSTVDate.Size = new System.Drawing.Size(115, 16);
            this.lblSTVDate.StyleController = this.layoutControl3;
            this.lblSTVDate.TabIndex = 94;
            // 
            // lblActivity
            // 
            this.lblActivity.Location = new System.Drawing.Point(974, 35);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(133, 16);
            this.lblActivity.StyleController = this.layoutControl3;
            this.lblActivity.TabIndex = 93;
            // 
            // lblSubAccount
            // 
            this.lblSubAccount.Location = new System.Drawing.Point(781, 35);
            this.lblSubAccount.Name = "lblSubAccount";
            this.lblSubAccount.Size = new System.Drawing.Size(122, 16);
            this.lblSubAccount.StyleController = this.layoutControl3;
            this.lblSubAccount.TabIndex = 92;
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(596, 35);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(103, 16);
            this.lblAccount.StyleController = this.layoutControl3;
            this.lblAccount.TabIndex = 91;
            // 
            // lblDispatchConfirmedBy
            // 
            this.lblDispatchConfirmedBy.Location = new System.Drawing.Point(803, 129);
            this.lblDispatchConfirmedBy.Name = "lblDispatchConfirmedBy";
            this.lblDispatchConfirmedBy.Size = new System.Drawing.Size(87, 16);
            this.lblDispatchConfirmedBy.StyleController = this.layoutControl3;
            this.lblDispatchConfirmedBy.TabIndex = 90;
            // 
            // lblSTVPrintedBy
            // 
            this.lblSTVPrintedBy.Location = new System.Drawing.Point(364, 129);
            this.lblSTVPrintedBy.Name = "lblSTVPrintedBy";
            this.lblSTVPrintedBy.Size = new System.Drawing.Size(115, 16);
            this.lblSTVPrintedBy.StyleController = this.layoutControl3;
            this.lblSTVPrintedBy.TabIndex = 86;
            // 
            // lblSTVNo
            // 
            this.lblSTVNo.Location = new System.Drawing.Point(369, 109);
            this.lblSTVNo.Name = "lblSTVNo";
            this.lblSTVNo.Size = new System.Drawing.Size(119, 16);
            this.lblSTVNo.StyleController = this.layoutControl3;
            this.lblSTVNo.TabIndex = 85;
            this.lblSTVNo.Text = " ";
            // 
            // lblWoreda
            // 
            this.lblWoreda.Location = new System.Drawing.Point(344, 75);
            this.lblWoreda.Name = "lblWoreda";
            this.lblWoreda.Size = new System.Drawing.Size(151, 16);
            this.lblWoreda.StyleController = this.layoutControl3;
            this.lblWoreda.TabIndex = 84;
            // 
            // lblZone
            // 
            this.lblZone.Location = new System.Drawing.Point(596, 75);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(103, 16);
            this.lblZone.StyleController = this.layoutControl3;
            this.lblZone.TabIndex = 83;
            // 
            // lblRegion
            // 
            this.lblRegion.Location = new System.Drawing.Point(781, 75);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(326, 16);
            this.lblRegion.StyleController = this.layoutControl3;
            this.lblRegion.TabIndex = 82;
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(344, 35);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(151, 16);
            this.lblMode.StyleController = this.layoutControl3;
            this.lblMode.TabIndex = 80;
            // 
            // btnGoSTV
            // 
            this.btnGoSTV.Image = global::HCMIS.Desktop.Properties.Resources.Search;
            this.btnGoSTV.Location = new System.Drawing.Point(106, 134);
            this.btnGoSTV.MinimumSize = new System.Drawing.Size(0, 20);
            this.btnGoSTV.Name = "btnGoSTV";
            this.btnGoSTV.Size = new System.Drawing.Size(142, 22);
            this.btnGoSTV.StyleController = this.layoutControl3;
            this.btnGoSTV.TabIndex = 76;
            this.btnGoSTV.Text = "Search";
            this.btnGoSTV.Click += new System.EventHandler(this.btnGoSTV_Click);
            // 
            // tEditSTVNo
            // 
            this.tEditSTVNo.EditValue = "";
            this.dxValidationProvider1.SetIconAlignment(this.tEditSTVNo, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
            this.tEditSTVNo.Location = new System.Drawing.Point(18, 135);
            this.tEditSTVNo.Margin = new System.Windows.Forms.Padding(0);
            this.tEditSTVNo.MinimumSize = new System.Drawing.Size(0, 20);
            this.tEditSTVNo.Name = "tEditSTVNo";
            this.tEditSTVNo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.tEditSTVNo.Properties.NullValuePrompt = "Invoice No:";
            this.tEditSTVNo.Properties.NullValuePromptShowForEmptyValue = true;
            this.tEditSTVNo.Size = new System.Drawing.Size(83, 20);
            this.tEditSTVNo.StyleController = this.layoutControl3;
            this.tEditSTVNo.TabIndex = 75;
            // 
            // dateTo
            // 
            this.dateTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTo.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dateTo.DayOfWeekCharacters = 1;
            this.dateTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dateTo.Location = new System.Drawing.Point(17, 84);
            this.dateTo.Name = "dateTo";
            this.dateTo.PopUpFontSize = 11F;
            this.dateTo.Size = new System.Drawing.Size(231, 20);
            this.dateTo.TabIndex = 74;
            this.dateTo.Value = new System.DateTime(2014, 10, 5, 0, 0, 0, 0);
            // 
            // dateFrom
            // 
            this.dateFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateFrom.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dateFrom.DayOfWeekCharacters = 1;
            this.dateFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.dateFrom.Location = new System.Drawing.Point(17, 60);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.PopUpFontSize = 11F;
            this.dateFrom.Size = new System.Drawing.Size(231, 20);
            this.dateFrom.TabIndex = 73;
            this.dateFrom.Value = new System.DateTime(2014, 10, 5, 0, 0, 0, 0);
            // 
            // btnGo
            // 
            this.btnGo.Image = global::HCMIS.Desktop.Properties.Resources.Forward;
            this.btnGo.Location = new System.Drawing.Point(106, 108);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(142, 22);
            this.btnGo.StyleController = this.layoutControl3;
            this.btnGo.TabIndex = 72;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lkAccount
            // 
            this.lkAccount.Location = new System.Drawing.Point(17, 36);
            this.lkAccount.Name = "lkAccount";
            this.lkAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccount.Properties.DisplayMember = "StoreNameConcat";
            this.lkAccount.Properties.NullText = "Select Account";
            this.lkAccount.Properties.ShowFooter = false;
            this.lkAccount.Properties.ValueMember = "ID";
            this.lkAccount.Properties.View = this.gridView2;
            this.lkAccount.Size = new System.Drawing.Size(231, 20);
            this.lkAccount.StyleController = this.layoutControl3;
            this.lkAccount.TabIndex = 69;
            this.lkAccount.EditValueChanged += new System.EventHandler(this.lkAccount_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn96,
            this.gridColumn10,
            this.gridColumn97,
            this.gridColumn98});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.GroupCount = 3;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView2.OptionsMenu.EnableFooterMenu = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn97, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn96, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "ID";
            this.gridColumn9.FieldName = "ID";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn96
            // 
            this.gridColumn96.Caption = "Sub Account";
            this.gridColumn96.FieldName = "StoreGroupDivision";
            this.gridColumn96.Name = "gridColumn96";
            this.gridColumn96.Visible = true;
            this.gridColumn96.VisibleIndex = 0;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Mode";
            this.gridColumn10.FieldName = "StoreType";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn97
            // 
            this.gridColumn97.Caption = "Account";
            this.gridColumn97.FieldName = "StoreGroup";
            this.gridColumn97.Name = "gridColumn97";
            // 
            // gridColumn98
            // 
            this.gridColumn98.Caption = "SSA";
            this.gridColumn98.FieldName = "Name";
            this.gridColumn98.Name = "gridColumn98";
            this.gridColumn98.Visible = true;
            this.gridColumn98.VisibleIndex = 0;
            this.gridColumn98.Width = 83;
            // 
            // txtPreprintedInvoiceNo
            // 
            this.txtPreprintedInvoiceNo.Location = new System.Drawing.Point(1020, 161);
            this.txtPreprintedInvoiceNo.Name = "txtPreprintedInvoiceNo";
            this.txtPreprintedInvoiceNo.Size = new System.Drawing.Size(99, 20);
            this.txtPreprintedInvoiceNo.StyleController = this.layoutControl3;
            this.txtPreprintedInvoiceNo.TabIndex = 48;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Please fill this box";
            this.dxValidationProvider1.SetValidationRule(this.txtPreprintedInvoiceNo, conditionValidationRule1);
            this.txtPreprintedInvoiceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPreprintedInvoiceNo_KeyDown);
            // 
            // btnCancelVoidRequest
            // 
            this.btnCancelVoidRequest.Image = global::HCMIS.Desktop.Properties.Resources.cross;
            this.btnCancelVoidRequest.Location = new System.Drawing.Point(977, 359);
            this.btnCancelVoidRequest.Name = "btnCancelVoidRequest";
            this.btnCancelVoidRequest.Size = new System.Drawing.Size(142, 22);
            this.btnCancelVoidRequest.StyleController = this.layoutControl3;
            this.btnCancelVoidRequest.TabIndex = 46;
            this.btnCancelVoidRequest.Text = "Cancel Void Request";
            this.btnCancelVoidRequest.Click += new System.EventHandler(this.btnCancelVoidRequest_Click);
            // 
            // txtFacilityNameFilter
            // 
            this.txtFacilityNameFilter.CausesValidation = false;
            this.txtFacilityNameFilter.Location = new System.Drawing.Point(57, 172);
            this.txtFacilityNameFilter.Name = "txtFacilityNameFilter";
            this.txtFacilityNameFilter.Size = new System.Drawing.Size(203, 20);
            this.txtFacilityNameFilter.StyleController = this.layoutControl3;
            this.txtFacilityNameFilter.TabIndex = 44;
            this.txtFacilityNameFilter.EditValueChanged += new System.EventHandler(this.txtFacilityNameFilter_EditValueChanged);
            // 
            // gridUndispatchedIssues
            // 
            this.gridUndispatchedIssues.Location = new System.Drawing.Point(5, 196);
            this.gridUndispatchedIssues.MainView = this.gridUndispatchedIssuesView;
            this.gridUndispatchedIssues.Name = "gridUndispatchedIssues";
            this.gridUndispatchedIssues.Size = new System.Drawing.Size(255, 157);
            this.gridUndispatchedIssues.TabIndex = 15;
            this.gridUndispatchedIssues.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridUndispatchedIssuesView});
            // 
            // gridUndispatchedIssuesView
            // 
            this.gridUndispatchedIssuesView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn48,
            this.gridColumn49,
            this.gridColumn46,
            this.gridColumn1,
            this.colVoidReq});
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colVoidReq;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "True";
            this.gridUndispatchedIssuesView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridUndispatchedIssuesView.GridControl = this.gridUndispatchedIssues;
            this.gridUndispatchedIssuesView.GroupCount = 1;
            this.gridUndispatchedIssuesView.GroupFormat = "[#image]{1} {2}";
            this.gridUndispatchedIssuesView.Name = "gridUndispatchedIssuesView";
            this.gridUndispatchedIssuesView.OptionsBehavior.Editable = false;
            this.gridUndispatchedIssuesView.OptionsCustomization.AllowColumnMoving = false;
            this.gridUndispatchedIssuesView.OptionsCustomization.AllowColumnResizing = false;
            this.gridUndispatchedIssuesView.OptionsCustomization.AllowFilter = false;
            this.gridUndispatchedIssuesView.OptionsCustomization.AllowGroup = false;
            this.gridUndispatchedIssuesView.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridUndispatchedIssuesView.OptionsCustomization.AllowSort = false;
            this.gridUndispatchedIssuesView.OptionsMenu.EnableColumnMenu = false;
            this.gridUndispatchedIssuesView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridUndispatchedIssuesView.OptionsSelection.UseIndicatorForSelection = false;
            this.gridUndispatchedIssuesView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridUndispatchedIssuesView.OptionsView.ShowGroupPanel = false;
            this.gridUndispatchedIssuesView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn49, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridUndispatchedIssuesView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.OnUndispatchedIssueClicked);
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "Invoice";
            this.gridColumn48.FieldName = "IDPrinted";
            this.gridColumn48.Name = "gridColumn48";
            this.gridColumn48.OptionsColumn.AllowEdit = false;
            this.gridColumn48.OptionsColumn.AllowFocus = false;
            this.gridColumn48.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn48.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsColumn.AllowMove = false;
            this.gridColumn48.OptionsColumn.AllowShowHide = false;
            this.gridColumn48.OptionsColumn.AllowSize = false;
            this.gridColumn48.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn48.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn48.OptionsColumn.TabStop = false;
            this.gridColumn48.Visible = true;
            this.gridColumn48.VisibleIndex = 0;
            // 
            // gridColumn49
            // 
            this.gridColumn49.FieldName = "RequestedBy";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.Width = 159;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "Account Type";
            this.gridColumn46.FieldName = "StoreName";
            this.gridColumn46.Name = "gridColumn46";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "STVID";
            this.gridColumn1.FieldName = "STVID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // btnConfirmIssue1
            // 
            this.btnConfirmIssue1.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmIssue1.Image")));
            this.btnConfirmIssue1.Location = new System.Drawing.Point(539, 359);
            this.btnConfirmIssue1.Name = "btnConfirmIssue1";
            this.btnConfirmIssue1.Size = new System.Drawing.Size(142, 22);
            this.btnConfirmIssue1.StyleController = this.layoutControl3;
            this.btnConfirmIssue1.TabIndex = 42;
            this.btnConfirmIssue1.Text = "Confirm Dispatch";
            this.btnConfirmIssue1.Click += new System.EventHandler(this.btnConfirmIssue_Click);
            // 
            // btnApproveVoidRequest
            // 
            this.btnApproveVoidRequest.Image = global::HCMIS.Desktop.Properties.Resources.icon_accept;
            this.btnApproveVoidRequest.Location = new System.Drawing.Point(831, 359);
            this.btnApproveVoidRequest.Name = "btnApproveVoidRequest";
            this.btnApproveVoidRequest.Size = new System.Drawing.Size(142, 22);
            this.btnApproveVoidRequest.StyleController = this.layoutControl3;
            this.btnApproveVoidRequest.TabIndex = 47;
            this.btnApproveVoidRequest.Text = "Confirm Void Request";
            this.btnApproveVoidRequest.Click += new System.EventHandler(this.btnApproveVoidRequest_Click);
            // 
            // txtConfirmFromStore
            // 
            this.txtConfirmFromStore.Enabled = false;
            this.txtConfirmFromStore.Location = new System.Drawing.Point(527, 54);
            this.txtConfirmFromStore.Name = "txtConfirmFromStore";
            this.txtConfirmFromStore.Size = new System.Drawing.Size(201, 20);
            this.txtConfirmFromStore.StyleController = this.layoutControl3;
            this.txtConfirmFromStore.TabIndex = 38;
            // 
            // btnMarkAsVoid
            // 
            this.btnMarkAsVoid.Image = global::HCMIS.Desktop.Properties.Resources.Unmark;
            this.btnMarkAsVoid.Location = new System.Drawing.Point(685, 359);
            this.btnMarkAsVoid.Name = "btnMarkAsVoid";
            this.btnMarkAsVoid.Size = new System.Drawing.Size(142, 22);
            this.btnMarkAsVoid.StyleController = this.layoutControl3;
            this.btnMarkAsVoid.TabIndex = 45;
            this.btnMarkAsVoid.Text = "Request a Void";
            this.btnMarkAsVoid.Click += new System.EventHandler(this.btnMarkAsVoid_Click);
            // 
            // txtSTVInvoiceNo
            // 
            this.txtSTVInvoiceNo.Enabled = false;
            this.txtSTVInvoiceNo.Location = new System.Drawing.Point(638, 100);
            this.txtSTVInvoiceNo.Name = "txtSTVInvoiceNo";
            this.txtSTVInvoiceNo.Size = new System.Drawing.Size(359, 20);
            this.txtSTVInvoiceNo.StyleController = this.layoutControl3;
            this.txtSTVInvoiceNo.TabIndex = 37;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRemarks.Location = new System.Drawing.Point(56, 358);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(203, 21);
            this.txtRemarks.StyleController = this.layoutControl3;
            this.txtRemarks.TabIndex = 32;
            // 
            // gridUndispatchedIssueDetails
            // 
            this.gridUndispatchedIssueDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridUndispatchedIssueDetails.Location = new System.Drawing.Point(273, 185);
            this.gridUndispatchedIssueDetails.MainView = this.gridViewUndispatchedIssueDetails;
            this.gridUndispatchedIssueDetails.Name = "gridUndispatchedIssueDetails";
            this.gridUndispatchedIssueDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridUndispatchedIssueDetails.Size = new System.Drawing.Size(846, 170);
            this.gridUndispatchedIssueDetails.TabIndex = 13;
            this.gridUndispatchedIssueDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewUndispatchedIssueDetails});
            // 
            // gridViewUndispatchedIssueDetails
            // 
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.BackColor = System.Drawing.Color.White;
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.BackColor2 = System.Drawing.Color.White;
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.gridViewUndispatchedIssueDetails.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewUndispatchedIssueDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Unit,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn40,
            this.colActuallyIssuedNoOfPack,
            this.colBUPicked,
            this.gridColumn47,
            this.colCost,
            this.gridColumn60,
            this.gridColumn62,
            this.gridColumn50,
            this.gridColumn2});
            this.gridViewUndispatchedIssueDetails.GridControl = this.gridUndispatchedIssueDetails;
            this.gridViewUndispatchedIssueDetails.GroupCount = 1;
            this.gridViewUndispatchedIssueDetails.Name = "gridViewUndispatchedIssueDetails";
            this.gridViewUndispatchedIssueDetails.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewUndispatchedIssueDetails.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewUndispatchedIssueDetails.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewUndispatchedIssueDetails.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewUndispatchedIssueDetails.OptionsMenu.EnableColumnMenu = false;
            this.gridViewUndispatchedIssueDetails.OptionsView.AllowCellMerge = true;
            this.gridViewUndispatchedIssueDetails.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.gridViewUndispatchedIssueDetails.OptionsView.RowAutoHeight = true;
            this.gridViewUndispatchedIssueDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewUndispatchedIssueDetails.OptionsView.ShowGroupPanel = false;
            this.gridViewUndispatchedIssueDetails.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn22, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewUndispatchedIssueDetails.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            // 
            // Unit
            // 
            this.Unit.Caption = "Unit";
            this.Unit.FieldName = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.OptionsColumn.AllowEdit = false;
            this.Unit.OptionsColumn.AllowFocus = false;
            this.Unit.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.Unit.OptionsColumn.AllowIncrementalSearch = false;
            this.Unit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Unit.OptionsColumn.AllowMove = false;
            this.Unit.OptionsColumn.AllowShowHide = false;
            this.Unit.OptionsColumn.AllowSize = false;
            this.Unit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.Unit.OptionsColumn.ShowInCustomizationForm = false;
            this.Unit.OptionsColumn.ShowInExpressionEditor = false;
            this.Unit.OptionsColumn.TabStop = false;
            this.Unit.OptionsFilter.AllowAutoFilter = false;
            this.Unit.OptionsFilter.AllowFilter = false;
            this.Unit.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.Unit.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.Unit.Visible = true;
            this.Unit.VisibleIndex = 4;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn22.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn22.Caption = "Item";
            this.gridColumn22.ColumnEdit = this.repositoryItemMemoEdit3;
            this.gridColumn22.FieldName = "FullItemName";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn22.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn22.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn22.OptionsFilter.AllowFilter = false;
            this.gridColumn22.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.Width = 84;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn23.Caption = "Manufacturer";
            this.gridColumn23.FieldName = "ManufacturerName";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.AllowShowHide = false;
            this.gridColumn23.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn23.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn23.OptionsFilter.AllowFilter = false;
            this.gridColumn23.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 0;
            this.gridColumn23.Width = 103;
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn35.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn35.Caption = "Pack Size";
            this.gridColumn35.FieldName = "BoxSizeDisplay";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            this.gridColumn35.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn35.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn35.OptionsFilter.AllowFilter = false;
            this.gridColumn35.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.Width = 120;
            // 
            // gridColumn36
            // 
            this.gridColumn36.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn36.Caption = "Quantity Printed";
            this.gridColumn36.DisplayFormat.FormatString = "#,##0.###0";
            this.gridColumn36.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn36.FieldName = "NoOfPack";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            this.gridColumn36.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn36.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn36.OptionsFilter.AllowFilter = false;
            this.gridColumn36.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 5;
            this.gridColumn36.Width = 101;
            // 
            // gridColumn37
            // 
            this.gridColumn37.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn37.Caption = "Batch";
            this.gridColumn37.FieldName = "BatchNumber";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn37.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn37.OptionsFilter.AllowFilter = false;
            this.gridColumn37.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 1;
            this.gridColumn37.Width = 67;
            // 
            // gridColumn38
            // 
            this.gridColumn38.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn38.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn38.Caption = "Expiry Date";
            this.gridColumn38.ColumnEdit = this.repositoryItemDateEdit3;
            this.gridColumn38.DisplayFormat.FormatString = "MMM/d/yyyy";
            this.gridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn38.FieldName = "ExpireDate";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.AllowFocus = false;
            this.gridColumn38.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn38.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn38.OptionsFilter.AllowFilter = false;
            this.gridColumn38.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 2;
            this.gridColumn38.Width = 99;
            // 
            // gridColumn39
            // 
            this.gridColumn39.ColumnEdit = this.repositoryItemButtonEdit4;
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn39.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn39.OptionsFilter.AllowFilter = false;
            this.gridColumn39.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn39.Width = 25;
            // 
            // gridColumn40
            // 
            this.gridColumn40.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn40.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn40.Caption = "Volume";
            this.gridColumn40.FieldName = "Volume";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.OptionsColumn.AllowFocus = false;
            this.gridColumn40.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn40.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn40.OptionsFilter.AllowFilter = false;
            this.gridColumn40.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colActuallyIssuedNoOfPack
            // 
            this.colActuallyIssuedNoOfPack.AppearanceCell.BackColor = System.Drawing.Color.PaleTurquoise;
            this.colActuallyIssuedNoOfPack.AppearanceCell.Options.UseBackColor = true;
            this.colActuallyIssuedNoOfPack.Caption = "Actually Issued";
            this.colActuallyIssuedNoOfPack.ColumnEdit = this.repositoryItemTextEdit2;
            this.colActuallyIssuedNoOfPack.DisplayFormat.FormatString = "#,##0.###0";
            this.colActuallyIssuedNoOfPack.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colActuallyIssuedNoOfPack.FieldName = "ActuallyIssuedNoOfPack";
            this.colActuallyIssuedNoOfPack.Name = "colActuallyIssuedNoOfPack";
            this.colActuallyIssuedNoOfPack.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colActuallyIssuedNoOfPack.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colActuallyIssuedNoOfPack.OptionsColumn.ShowInCustomizationForm = false;
            this.colActuallyIssuedNoOfPack.OptionsFilter.AllowAutoFilter = false;
            this.colActuallyIssuedNoOfPack.OptionsFilter.AllowFilter = false;
            this.colActuallyIssuedNoOfPack.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colActuallyIssuedNoOfPack.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colActuallyIssuedNoOfPack.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colActuallyIssuedNoOfPack.Visible = true;
            this.colActuallyIssuedNoOfPack.VisibleIndex = 6;
            this.colActuallyIssuedNoOfPack.Width = 78;
            // 
            // colBUPicked
            // 
            this.colBUPicked.Caption = "Qty picked in BU";
            this.colBUPicked.DisplayFormat.FormatString = "#,###";
            this.colBUPicked.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBUPicked.FieldName = "BUPICKED";
            this.colBUPicked.GroupFormat.FormatString = "#,###";
            this.colBUPicked.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBUPicked.Name = "colBUPicked";
            this.colBUPicked.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsColumn.ShowInCustomizationForm = false;
            this.colBUPicked.OptionsFilter.AllowAutoFilter = false;
            this.colBUPicked.OptionsFilter.AllowFilter = false;
            this.colBUPicked.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colBUPicked.Width = 102;
            // 
            // gridColumn47
            // 
            this.gridColumn47.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.gridColumn47.Caption = "Location";
            this.gridColumn47.FieldName = "PalletLocation";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.OptionsColumn.AllowEdit = false;
            this.gridColumn47.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn47.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn47.OptionsFilter.AllowFilter = false;
            this.gridColumn47.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 3;
            this.gridColumn47.Width = 100;
            // 
            // colCost
            // 
            this.colCost.AppearanceCell.BackColor = System.Drawing.Color.White;
            this.colCost.Caption = "Price";
            this.colCost.DisplayFormat.FormatString = "#,##0.#0";
            this.colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCost.FieldName = "Cost";
            this.colCost.GroupFormat.FormatString = "#,###.##";
            this.colCost.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCost.Name = "colCost";
            this.colCost.OptionsColumn.AllowEdit = false;
            this.colCost.OptionsColumn.AllowFocus = false;
            this.colCost.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsColumn.ShowInCustomizationForm = false;
            this.colCost.OptionsFilter.AllowAutoFilter = false;
            this.colCost.OptionsFilter.AllowFilter = false;
            this.colCost.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:#,###.##}")});
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 8;
            this.colCost.Width = 85;
            // 
            // gridColumn60
            // 
            this.gridColumn60.Caption = "Units";
            this.gridColumn60.FieldName = "SKUBU";
            this.gridColumn60.Name = "gridColumn60";
            this.gridColumn60.OptionsColumn.AllowEdit = false;
            this.gridColumn60.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn60.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn60.OptionsFilter.AllowFilter = false;
            this.gridColumn60.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn62
            // 
            this.gridColumn62.Caption = "Unit Price";
            this.gridColumn62.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn62.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn62.FieldName = "UnitPrice";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.OptionsColumn.AllowEdit = false;
            this.gridColumn62.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn62.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn62.OptionsFilter.AllowFilter = false;
            this.gridColumn62.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 7;
            // 
            // gridColumn50
            // 
            this.gridColumn50.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn50.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn50.Caption = "Packs to Pick";
            this.gridColumn50.FieldName = "Packs";
            this.gridColumn50.Name = "gridColumn50";
            this.gridColumn50.OptionsColumn.AllowEdit = false;
            this.gridColumn50.OptionsColumn.AllowFocus = false;
            this.gridColumn50.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn50.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn50.OptionsFilter.AllowFilter = false;
            this.gridColumn50.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.Width = 77;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IssueDocID";
            this.gridColumn2.FieldName = "IssueDocID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueGrayed = false;
            // 
            // txtIssuedBy
            // 
            this.txtIssuedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIssuedBy.Enabled = false;
            this.txtIssuedBy.Location = new System.Drawing.Point(638, 100);
            this.txtIssuedBy.Name = "txtIssuedBy";
            this.txtIssuedBy.Size = new System.Drawing.Size(156, 20);
            this.txtIssuedBy.StyleController = this.layoutControl3;
            this.txtIssuedBy.TabIndex = 31;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem18.Location = new System.Drawing.Point(387, 72);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(330, 24);
            this.layoutControlItem18.Text = "layoutControlItem18";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(100, 0);
            this.layoutControlItem18.TextToControlDistance = 0;
            this.layoutControlItem18.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(421, 241);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup11;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(148, 132);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup11});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // layoutControlGroup11
            // 
            this.layoutControlGroup11.CustomizationFormText = "layoutControlGroup11";
            this.layoutControlGroup11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup11.Name = "layoutControlGroup11";
            this.layoutControlGroup11.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup11.Size = new System.Drawing.Size(124, 86);
            this.layoutControlGroup11.Text = "layoutControlGroup11";
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.txtConfirmFromStore;
            this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
            this.layoutControlItem26.Location = new System.Drawing.Point(189, 50);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(310, 24);
            this.layoutControlItem26.Text = "From Store";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(100, 13);
            this.layoutControlItem26.TextToControlDistance = 5;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtIssuedBy;
            this.layoutControlItem21.CustomizationFormText = "Dispatch Confirmed By:";
            this.layoutControlItem21.Location = new System.Drawing.Point(86, 0);
            this.layoutControlItem21.MaxSize = new System.Drawing.Size(277, 24);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(277, 24);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(277, 24);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.Text = "Dispatch Confirmed By";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(112, 13);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.txtSTVInvoiceNo;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem25";
            this.layoutControlItem25.Location = new System.Drawing.Point(86, 0);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(171, 24);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(480, 40);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.Text = "STV/Invoice No:";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(112, 13);
            this.layoutControlItem25.TextToControlDistance = 5;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.lblSTVNo;
            this.layoutControlItem20.CustomizationFormText = "STV/Invoice No:";
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem20.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem20.MinSize = new System.Drawing.Size(89, 20);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(207, 20);
            this.layoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem20.Text = "STV/Invoice No:";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(79, 13);
            this.layoutControlItem20.TextToControlDistance = 5;
            // 
            // layoutControlItem58
            // 
            this.layoutControlItem58.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem58.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem58.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem58.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem58.Control = this.lblDispatchedDate;
            this.layoutControlItem58.CustomizationFormText = "Dispatched Date:";
            this.layoutControlItem58.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem58.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem58.MinSize = new System.Drawing.Size(123, 20);
            this.layoutControlItem58.Name = "layoutControlItem58";
            this.layoutControlItem58.Size = new System.Drawing.Size(192, 20);
            this.layoutControlItem58.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem58.Text = "Dispatched Date:";
            this.layoutControlItem58.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem58.TextSize = new System.Drawing.Size(96, 13);
            this.layoutControlItem58.TextToControlDistance = 5;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem27.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem27.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem27.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem27.Control = this.lblDispatchConfirmedBy;
            this.layoutControlItem27.CustomizationFormText = "Dispatch By:";
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(107, 20);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(192, 40);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "Dispatched By:";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(83, 13);
            this.layoutControlItem27.TextToControlDistance = 18;
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.CustomizationFormText = "layoutControlGroup7";
            this.layoutControlGroup7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup7.GroupBordersVisible = false;
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup13,
            this.layoutControlGroup19,
            this.lcRequestVoid,
            this.emptySpaceItem5,
            this.emptySpaceItem4,
            this.lcApprovalCancel,
            this.lcApproval,
            this.lcDispatchConfirm});
            this.layoutControlGroup7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup7.Name = "Root";
            this.layoutControlGroup7.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup7.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup7.Size = new System.Drawing.Size(1123, 385);
            this.layoutControlGroup7.Text = "Root";
            this.layoutControlGroup7.TextVisible = false;
            // 
            // layoutControlGroup13
            // 
            this.layoutControlGroup13.CustomizationFormText = "Pick List Confirmation";
            this.layoutControlGroup13.GroupBordersVisible = false;
            this.layoutControlGroup13.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem19,
            this.layoutControlItem1,
            this.emptySpaceItem2,
            this.FacilityGroup});
            this.layoutControlGroup13.Location = new System.Drawing.Point(269, 0);
            this.layoutControlGroup13.Name = "layoutControlGroup13";
            this.layoutControlGroup13.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup13.Size = new System.Drawing.Size(850, 355);
            this.layoutControlGroup13.Text = "Pick List Confirmation";
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.gridUndispatchedIssueDetails;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 181);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(850, 174);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.Text = "layoutControlItem19";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextToControlDistance = 0;
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtPreprintedInvoiceNo;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(630, 157);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(171, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(220, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Pre-Printed Invoice No:";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(112, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 157);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(630, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FacilityGroup
            // 
            this.FacilityGroup.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FacilityGroup.AppearanceGroup.Options.UseFont = true;
            this.FacilityGroup.CustomizationFormText = "Facility";
            this.FacilityGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup5,
            this.layoutControlGroup6,
            this.layoutControlGroup4});
            this.FacilityGroup.Location = new System.Drawing.Point(0, 0);
            this.FacilityGroup.Name = "FacilityGroup";
            this.FacilityGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.FacilityGroup.Size = new System.Drawing.Size(850, 157);
            this.FacilityGroup.Text = " ";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem43,
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.layoutControlItem38,
            this.layoutControlItem45,
            this.layoutControlItem16,
            this.layoutControlItem31,
            this.layoutControlItem40,
            this.layoutControlItem37,
            this.layoutControlItem10,
            this.layoutControlItem33});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup2.Size = new System.Drawing.Size(840, 74);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem43.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem43.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem43.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem43.Control = this.lblMode;
            this.layoutControlItem43.CustomizationFormText = "Mode:";
            this.layoutControlItem43.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem43.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem43.MinSize = new System.Drawing.Size(59, 20);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(214, 20);
            this.layoutControlItem43.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem43.Text = "Mode:";
            this.layoutControlItem43.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem43.TextSize = new System.Drawing.Size(34, 13);
            this.layoutControlItem43.TextToControlDistance = 25;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem12.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem12.Control = this.lblAccount;
            this.layoutControlItem12.CustomizationFormText = "Account:";
            this.layoutControlItem12.Location = new System.Drawing.Point(214, 0);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(98, 20);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(204, 20);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "Account:";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem12.TextToControlDistance = 48;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem14.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem14.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem14.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem14.Control = this.lblSubAccount;
            this.layoutControlItem14.CustomizationFormText = "Sub Account:";
            this.layoutControlItem14.Location = new System.Drawing.Point(418, 0);
            this.layoutControlItem14.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(85, 20);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(204, 20);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = "Sub Account:";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(73, 13);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem38.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem38.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem38.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem38.Control = this.lblActivity;
            this.layoutControlItem38.CustomizationFormText = "Activity:";
            this.layoutControlItem38.Location = new System.Drawing.Point(622, 0);
            this.layoutControlItem38.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem38.MinSize = new System.Drawing.Size(104, 20);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(204, 20);
            this.layoutControlItem38.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem38.Text = "Activity:";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem38.TextToControlDistance = 20;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem45.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem45.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem45.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem45.Control = this.lblZone;
            this.layoutControlItem45.CustomizationFormText = "Zone:";
            this.layoutControlItem45.Location = new System.Drawing.Point(214, 40);
            this.layoutControlItem45.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem45.MinSize = new System.Drawing.Size(98, 20);
            this.layoutControlItem45.Name = "layoutControlItem45";
            this.layoutControlItem45.Size = new System.Drawing.Size(204, 20);
            this.layoutControlItem45.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem45.Text = "Zone:";
            this.layoutControlItem45.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem45.TextSize = new System.Drawing.Size(31, 13);
            this.layoutControlItem45.TextToControlDistance = 66;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem16.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem16.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem16.Control = this.lblWoreda;
            this.layoutControlItem16.CustomizationFormText = "Woreda:";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(59, 20);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(214, 20);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Text = "Woreda:";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem16.TextToControlDistance = 12;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem31.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem31.Control = this.lblPaymentType;
            this.layoutControlItem31.CustomizationFormText = "Payment Type:";
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem31.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem31.MinSize = new System.Drawing.Size(97, 20);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(214, 20);
            this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem31.Text = "Payment:";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(54, 13);
            this.layoutControlItem31.TextToControlDistance = 5;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem40.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem40.Control = this.lblOwnership;
            this.layoutControlItem40.CustomizationFormText = "Ownership:";
            this.layoutControlItem40.Location = new System.Drawing.Point(622, 20);
            this.layoutControlItem40.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem40.MinSize = new System.Drawing.Size(84, 20);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(204, 20);
            this.layoutControlItem40.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem40.Text = "Ownership:";
            this.layoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(62, 13);
            this.layoutControlItem40.TextToControlDistance = 5;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem37.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem37.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem37.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem37.Control = this.lblRegion;
            this.layoutControlItem37.CustomizationFormText = "Region:";
            this.layoutControlItem37.Location = new System.Drawing.Point(418, 40);
            this.layoutControlItem37.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem37.MinSize = new System.Drawing.Size(84, 20);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(408, 20);
            this.layoutControlItem37.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem37.Text = "Region:";
            this.layoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(42, 13);
            this.layoutControlItem37.TextToControlDistance = 36;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem10.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem10.Control = this.lblInstitutionType;
            this.layoutControlItem10.CustomizationFormText = "Inst. Type:";
            this.layoutControlItem10.Location = new System.Drawing.Point(418, 20);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(59, 20);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(204, 20);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "Inst. Type:";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem10.TextToControlDistance = 18;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem33.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem33.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem33.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem33.Control = this.lblDocumentedType;
            this.layoutControlItem33.CustomizationFormText = "Documented Type:";
            this.layoutControlItem33.Location = new System.Drawing.Point(214, 20);
            this.layoutControlItem33.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem33.MinSize = new System.Drawing.Size(104, 20);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(204, 20);
            this.layoutControlItem33.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem33.Text = "Document Type:";
            this.layoutControlItem33.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(92, 13);
            this.layoutControlItem33.TextToControlDistance = 5;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem47,
            this.layoutControlItem30});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 74);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup3.Size = new System.Drawing.Size(212, 54);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem47.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem47.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem47.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem47.Control = this.lblSTVDate;
            this.layoutControlItem47.CustomizationFormText = "Date:";
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem47.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem47.MinSize = new System.Drawing.Size(113, 20);
            this.layoutControlItem47.Name = "layoutControlItem47";
            this.layoutControlItem47.Size = new System.Drawing.Size(198, 20);
            this.layoutControlItem47.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem47.Text = "Printed Date:";
            this.layoutControlItem47.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem47.TextSize = new System.Drawing.Size(74, 13);
            this.layoutControlItem47.TextToControlDistance = 5;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem30.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem30.Control = this.lblSTVPrintedBy;
            this.layoutControlItem30.CustomizationFormText = "Letter Number:";
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem30.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem30.MinSize = new System.Drawing.Size(86, 20);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(198, 20);
            this.layoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem30.Text = "Printed By:";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(61, 13);
            this.layoutControlItem30.TextToControlDistance = 18;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem60,
            this.layoutControlItem62});
            this.layoutControlGroup5.Location = new System.Drawing.Point(417, 74);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup5.Size = new System.Drawing.Size(202, 54);
            this.layoutControlGroup5.Text = "layoutControlGroup5";
            this.layoutControlGroup5.TextVisible = false;
            // 
            // layoutControlItem60
            // 
            this.layoutControlItem60.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem60.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem60.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem60.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem60.Control = this.lblVoidConfirmedDate;
            this.layoutControlItem60.CustomizationFormText = "Void Confirmed Date:";
            this.layoutControlItem60.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem60.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem60.MinSize = new System.Drawing.Size(127, 20);
            this.layoutControlItem60.Name = "layoutControlItem60";
            this.layoutControlItem60.Size = new System.Drawing.Size(188, 20);
            this.layoutControlItem60.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem60.Text = "Void Confirmed Date:";
            this.layoutControlItem60.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem60.TextSize = new System.Drawing.Size(118, 13);
            this.layoutControlItem60.TextToControlDistance = 5;
            // 
            // layoutControlItem62
            // 
            this.layoutControlItem62.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem62.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem62.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem62.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem62.Control = this.lblVoidConfirmedBy;
            this.layoutControlItem62.CustomizationFormText = "Void Confirmed By:";
            this.layoutControlItem62.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem62.MinSize = new System.Drawing.Size(114, 17);
            this.layoutControlItem62.Name = "layoutControlItem62";
            this.layoutControlItem62.Size = new System.Drawing.Size(188, 20);
            this.layoutControlItem62.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem62.Text = "Void Confirmed By:";
            this.layoutControlItem62.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem62.TextSize = new System.Drawing.Size(105, 13);
            this.layoutControlItem62.TextToControlDistance = 18;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "layoutControlGroup6";
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem54,
            this.layoutControlItem56});
            this.layoutControlGroup6.Location = new System.Drawing.Point(619, 74);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup6.Size = new System.Drawing.Size(221, 54);
            this.layoutControlGroup6.Text = "layoutControlGroup6";
            this.layoutControlGroup6.TextVisible = false;
            // 
            // layoutControlItem54
            // 
            this.layoutControlItem54.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem54.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem54.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem54.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem54.Control = this.lblIssueType;
            this.layoutControlItem54.CustomizationFormText = "Type:";
            this.layoutControlItem54.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem54.MinSize = new System.Drawing.Size(69, 4);
            this.layoutControlItem54.Name = "layoutControlItem54";
            this.layoutControlItem54.Size = new System.Drawing.Size(207, 20);
            this.layoutControlItem54.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem54.Text = "Type:";
            this.layoutControlItem54.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem54.TextSize = new System.Drawing.Size(31, 13);
            this.layoutControlItem54.TextToControlDistance = 14;
            // 
            // layoutControlItem56
            // 
            this.layoutControlItem56.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem56.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem56.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem56.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem56.Control = this.lblIssueStatus;
            this.layoutControlItem56.CustomizationFormText = "Issue Status:";
            this.layoutControlItem56.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem56.MaxSize = new System.Drawing.Size(207, 20);
            this.layoutControlItem56.MinSize = new System.Drawing.Size(207, 20);
            this.layoutControlItem56.Name = "layoutControlItem56";
            this.layoutControlItem56.Size = new System.Drawing.Size(207, 20);
            this.layoutControlItem56.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem56.Text = "Status:";
            this.layoutControlItem56.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem56.TextSize = new System.Drawing.Size(40, 13);
            this.layoutControlItem56.TextToControlDistance = 5;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem49,
            this.layoutControlItem52});
            this.layoutControlGroup4.Location = new System.Drawing.Point(212, 74);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup4.Size = new System.Drawing.Size(205, 54);
            this.layoutControlGroup4.Text = "layoutControlGroup4";
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem49.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem49.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem49.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem49.Control = this.lblVoidRequestedBy;
            this.layoutControlItem49.CustomizationFormText = "Void Requested By:";
            this.layoutControlItem49.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem49.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem49.MinSize = new System.Drawing.Size(113, 20);
            this.layoutControlItem49.Name = "layoutControlItem49";
            this.layoutControlItem49.Size = new System.Drawing.Size(191, 20);
            this.layoutControlItem49.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem49.Text = "Void Requested By:";
            this.layoutControlItem49.TextSize = new System.Drawing.Size(117, 13);
            this.layoutControlItem49.TextToControlDistance = 5;
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem52.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem52.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem52.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem52.Control = this.lblRequistedDate;
            this.layoutControlItem52.CustomizationFormText = "Void Requisted Date:";
            this.layoutControlItem52.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem52.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem52.MinSize = new System.Drawing.Size(113, 20);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Size = new System.Drawing.Size(191, 20);
            this.layoutControlItem52.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem52.Text = "Void Requisted Date:";
            this.layoutControlItem52.TextSize = new System.Drawing.Size(117, 13);
            this.layoutControlItem52.TextToControlDistance = 5;
            // 
            // layoutControlGroup19
            // 
            this.layoutControlGroup19.CustomizationFormText = "Outstanding Pick Lists";
            this.layoutControlGroup19.ExpandOnDoubleClick = true;
            this.layoutControlGroup19.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem50,
            this.layoutControlGroup1,
            this.layoutControlItem22,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup19.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup19.Name = "layoutControlGroup19";
            this.layoutControlGroup19.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup19.Size = new System.Drawing.Size(261, 381);
            this.layoutControlGroup19.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup19.Text = "Unconfirmed STVs";
            this.layoutControlGroup19.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlGroup19.TextVisible = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.gridUndispatchedIssues;
            this.layoutControlItem50.CustomizationFormText = "layoutControlItem50";
            this.layoutControlItem50.Location = new System.Drawing.Point(0, 191);
            this.layoutControlItem50.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(259, 161);
            this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem50.Text = "layoutControlItem50";
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextToControlDistance = 0;
            this.layoutControlItem50.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Date Filter";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem5,
            this.emptySpaceItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(259, 167);
            this.layoutControlGroup1.Text = "Filter";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lkAccount;
            this.layoutControlItem3.CustomizationFormText = "Account";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(235, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Account";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.dateFrom;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(235, 24);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dateTo;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(235, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnGo;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(89, 72);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnGoSTV;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(89, 98);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.tEditSTVNo;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(56, 22);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem5.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "STV/Invoice:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(89, 26);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txtRemarks;
            this.layoutControlItem22.CustomizationFormText = "Remarks";
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 352);
            this.layoutControlItem22.MaxSize = new System.Drawing.Size(259, 27);
            this.layoutControlItem22.MinSize = new System.Drawing.Size(259, 27);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem22.Size = new System.Drawing.Size(259, 27);
            this.layoutControlItem22.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem22.Text = "Remarks:";
            this.layoutControlItem22.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(45, 13);
            this.layoutControlItem22.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtFacilityNameFilter;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(19, 167);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(240, 24);
            this.layoutControlItem2.Text = "Filter:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(28, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 167);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(19, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcRequestVoid
            // 
            this.lcRequestVoid.Control = this.btnMarkAsVoid;
            this.lcRequestVoid.CustomizationFormText = "layoutControlItem1";
            this.lcRequestVoid.Location = new System.Drawing.Point(681, 355);
            this.lcRequestVoid.MaxSize = new System.Drawing.Size(146, 26);
            this.lcRequestVoid.MinSize = new System.Drawing.Size(146, 26);
            this.lcRequestVoid.Name = "lcRequestVoid";
            this.lcRequestVoid.Size = new System.Drawing.Size(146, 26);
            this.lcRequestVoid.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcRequestVoid.Text = "lcRequestVoid";
            this.lcRequestVoid.TextSize = new System.Drawing.Size(0, 0);
            this.lcRequestVoid.TextToControlDistance = 0;
            this.lcRequestVoid.TextVisible = false;
            this.lcRequestVoid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(269, 355);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(266, 26);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(261, 0);
            this.emptySpaceItem4.MaxSize = new System.Drawing.Size(8, 0);
            this.emptySpaceItem4.MinSize = new System.Drawing.Size(8, 24);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(8, 381);
            this.emptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lcApprovalCancel
            // 
            this.lcApprovalCancel.Control = this.btnCancelVoidRequest;
            this.lcApprovalCancel.CustomizationFormText = "layoutControlItem3";
            this.lcApprovalCancel.Location = new System.Drawing.Point(973, 355);
            this.lcApprovalCancel.MaxSize = new System.Drawing.Size(146, 26);
            this.lcApprovalCancel.MinSize = new System.Drawing.Size(146, 26);
            this.lcApprovalCancel.Name = "lcApprovalCancel";
            this.lcApprovalCancel.Size = new System.Drawing.Size(146, 26);
            this.lcApprovalCancel.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcApprovalCancel.Text = "lcApprovalCancel";
            this.lcApprovalCancel.TextSize = new System.Drawing.Size(0, 0);
            this.lcApprovalCancel.TextToControlDistance = 0;
            this.lcApprovalCancel.TextVisible = false;
            this.lcApprovalCancel.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lcApproval
            // 
            this.lcApproval.Control = this.btnApproveVoidRequest;
            this.lcApproval.CustomizationFormText = "layoutControlItem4";
            this.lcApproval.Location = new System.Drawing.Point(827, 355);
            this.lcApproval.MaxSize = new System.Drawing.Size(146, 26);
            this.lcApproval.MinSize = new System.Drawing.Size(146, 26);
            this.lcApproval.Name = "lcApproval";
            this.lcApproval.Size = new System.Drawing.Size(146, 26);
            this.lcApproval.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcApproval.Text = "lcApproval";
            this.lcApproval.TextSize = new System.Drawing.Size(0, 0);
            this.lcApproval.TextToControlDistance = 0;
            this.lcApproval.TextVisible = false;
            this.lcApproval.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lcDispatchConfirm
            // 
            this.lcDispatchConfirm.Control = this.btnConfirmIssue1;
            this.lcDispatchConfirm.CustomizationFormText = "layoutControlItem43";
            this.lcDispatchConfirm.Location = new System.Drawing.Point(535, 355);
            this.lcDispatchConfirm.MaxSize = new System.Drawing.Size(146, 26);
            this.lcDispatchConfirm.MinSize = new System.Drawing.Size(146, 26);
            this.lcDispatchConfirm.Name = "lcDispatchConfirm";
            this.lcDispatchConfirm.Size = new System.Drawing.Size(146, 26);
            this.lcDispatchConfirm.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcDispatchConfirm.Text = "lcDispatchConfirm";
            this.lcDispatchConfirm.TextSize = new System.Drawing.Size(0, 0);
            this.lcDispatchConfirm.TextToControlDistance = 0;
            this.lcDispatchConfirm.TextVisible = false;
            this.lcDispatchConfirm.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            // 
            // emptySpaceItem15
            // 
            this.emptySpaceItem15.AllowHotTrack = false;
            this.emptySpaceItem15.CustomizationFormText = "emptySpaceItem15";
            this.emptySpaceItem15.Location = new System.Drawing.Point(0, 116);
            this.emptySpaceItem15.Name = "emptySpaceItem15";
            this.emptySpaceItem15.Size = new System.Drawing.Size(717, 10);
            this.emptySpaceItem15.Text = "emptySpaceItem15";
            this.emptySpaceItem15.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.CustomizationFormText = "layoutControlGroup8";
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup8.Size = new System.Drawing.Size(717, 116);
            this.layoutControlGroup8.Text = "layoutControlGroup8";
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.CustomizationFormText = "layoutControlGroup9";
            this.layoutControlGroup9.Location = new System.Drawing.Point(0, 126);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup9.Size = new System.Drawing.Size(717, 68);
            this.layoutControlGroup9.Text = "layoutControlGroup9";
            // 
            // layoutControlGroup10
            // 
            this.layoutControlGroup10.CustomizationFormText = "layoutControlGroup10";
            this.layoutControlGroup10.Location = new System.Drawing.Point(0, 126);
            this.layoutControlGroup10.Name = "layoutControlGroup10";
            this.layoutControlGroup10.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup10.Size = new System.Drawing.Size(717, 68);
            this.layoutControlGroup10.Text = "layoutControlGroup10";
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem10";
            this.emptySpaceItem10.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(693, 10);
            this.emptySpaceItem10.Text = "emptySpaceItem10";
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem22
            // 
            this.emptySpaceItem22.AllowHotTrack = false;
            this.emptySpaceItem22.CustomizationFormText = "emptySpaceItem22";
            this.emptySpaceItem22.Location = new System.Drawing.Point(85, 0);
            this.emptySpaceItem22.Name = "emptySpaceItem22";
            this.emptySpaceItem22.Size = new System.Drawing.Size(119, 479);
            this.emptySpaceItem22.Text = "emptySpaceItem22";
            this.emptySpaceItem22.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem23
            // 
            this.emptySpaceItem23.AllowHotTrack = false;
            this.emptySpaceItem23.CustomizationFormText = "emptySpaceItem23";
            this.emptySpaceItem23.Location = new System.Drawing.Point(1179, 24);
            this.emptySpaceItem23.Name = "emptySpaceItem23";
            this.emptySpaceItem23.Size = new System.Drawing.Size(10, 455);
            this.emptySpaceItem23.Text = "emptySpaceItem23";
            this.emptySpaceItem23.TextSize = new System.Drawing.Size(0, 0);
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1,
            this.printOrder});
            // 
            // printableComponentLink1
            // 
            this.printableComponentLink1.Landscape = true;
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(null, new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "[Time Printed]",
                "[Date Printed]",
                "[Page # of Pages #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink1.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            this.printableComponentLink1.RtfReportHeader = resources.GetString("printableComponentLink1.RtfReportHeader");
            // 
            // printOrder
            // 
            this.printOrder.Landscape = true;
            this.printOrder.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.printOrder.PrintingSystemBase = this.printingSystem1;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtSTVInvoiceNo;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem25";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(171, 24);
            this.layoutControlItem11.Name = "layoutControlItem25";
            this.layoutControlItem11.Size = new System.Drawing.Size(314, 24);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.Text = "STV/Invoice No:";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(112, 13);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // LastVisitlayout
            // 
            this.LastVisitlayout.CustomizationFormText = "                   Last Visit:";
            this.LastVisitlayout.Location = new System.Drawing.Point(977, 0);
            this.LastVisitlayout.Name = "LastVisitlayout";
            this.LastVisitlayout.Size = new System.Drawing.Size(138, 20);
            this.LastVisitlayout.Text = "                   Last Visit:";
            this.LastVisitlayout.TextSize = new System.Drawing.Size(120, 13);
            this.LastVisitlayout.TextToControlDistance = 5;
            // 
            // NoRequisitionlayout
            // 
            this.NoRequisitionlayout.CustomizationFormText = "        No of Requistion:";
            this.NoRequisitionlayout.Location = new System.Drawing.Point(839, 0);
            this.NoRequisitionlayout.Name = "NoRequisitionlayout";
            this.NoRequisitionlayout.Size = new System.Drawing.Size(138, 20);
            this.NoRequisitionlayout.Text = "        No of Requistion:";
            this.NoRequisitionlayout.TextSize = new System.Drawing.Size(120, 13);
            this.NoRequisitionlayout.TextToControlDistance = 5;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.CustomizationFormText = "        No of Requistion:";
            this.layoutControlItem41.Location = new System.Drawing.Point(839, 0);
            this.layoutControlItem41.Name = "NoRequisitionlayout";
            this.layoutControlItem41.Size = new System.Drawing.Size(138, 20);
            this.layoutControlItem41.Text = "        No of Requistion:";
            this.layoutControlItem41.TextSize = new System.Drawing.Size(120, 13);
            this.layoutControlItem41.TextToControlDistance = 5;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.lblMode;
            this.layoutControlItem42.CustomizationFormText = "                   Last Visit:";
            this.layoutControlItem42.Location = new System.Drawing.Point(977, 0);
            this.layoutControlItem42.Name = "LastVisitlayout";
            this.layoutControlItem42.Size = new System.Drawing.Size(138, 20);
            this.layoutControlItem42.Text = "                   Last Visit:";
            this.layoutControlItem42.TextSize = new System.Drawing.Size(120, 13);
            this.layoutControlItem42.TextToControlDistance = 5;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.lblRegion;
            this.layoutControlItem34.CustomizationFormText = "                   Last Visit:";
            this.layoutControlItem34.Location = new System.Drawing.Point(977, 0);
            this.layoutControlItem34.Name = "LastVisitlayout";
            this.layoutControlItem34.Size = new System.Drawing.Size(138, 20);
            this.layoutControlItem34.Text = "                   Last Visit:";
            this.layoutControlItem34.TextSize = new System.Drawing.Size(120, 13);
            this.layoutControlItem34.TextToControlDistance = 5;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.lblZone;
            this.layoutControlItem13.CustomizationFormText = "                   Last Visit:";
            this.layoutControlItem13.Location = new System.Drawing.Point(977, 0);
            this.layoutControlItem13.Name = "LastVisitlayout";
            this.layoutControlItem13.Size = new System.Drawing.Size(138, 20);
            this.layoutControlItem13.Text = "                   Last Visit:";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(120, 13);
            this.layoutControlItem13.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.lblWoreda;
            this.layoutControlItem15.CustomizationFormText = "                   Last Visit:";
            this.layoutControlItem15.Location = new System.Drawing.Point(977, 0);
            this.layoutControlItem15.Name = "LastVisitlayout";
            this.layoutControlItem15.Size = new System.Drawing.Size(138, 20);
            this.layoutControlItem15.Text = "                   Last Visit:";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(120, 13);
            this.layoutControlItem15.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.lblSTVNo;
            this.layoutControlItem17.CustomizationFormText = "                   Last Visit:";
            this.layoutControlItem17.Location = new System.Drawing.Point(977, 0);
            this.layoutControlItem17.Name = "LastVisitlayout";
            this.layoutControlItem17.Size = new System.Drawing.Size(138, 20);
            this.layoutControlItem17.Text = "                   Last Visit:";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(120, 13);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.lblSTVPrintedBy;
            this.layoutControlItem23.CustomizationFormText = "Mode:";
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem23.Name = "layoutControlItem43";
            this.layoutControlItem23.Size = new System.Drawing.Size(825, 20);
            this.layoutControlItem23.Text = "Mode:";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.lblDispatchConfirmedBy;
            this.layoutControlItem24.CustomizationFormText = "Mode:";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem24.Name = "layoutControlItem43";
            this.layoutControlItem24.Size = new System.Drawing.Size(825, 20);
            this.layoutControlItem24.Text = "Mode:";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.lblAccount;
            this.layoutControlItem36.CustomizationFormText = "Region:";
            this.layoutControlItem36.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem36.MinSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem36.Name = "layoutControlItem37";
            this.layoutControlItem36.Size = new System.Drawing.Size(274, 20);
            this.layoutControlItem36.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem36.Text = "Region:";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlItem36.TextToControlDistance = 5;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.lblSubAccount;
            this.layoutControlItem39.CustomizationFormText = "Region:";
            this.layoutControlItem39.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem39.MinSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem39.Name = "layoutControlItem37";
            this.layoutControlItem39.Size = new System.Drawing.Size(274, 20);
            this.layoutControlItem39.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem39.Text = "Region:";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.Control = this.lblActivity;
            this.layoutControlItem44.CustomizationFormText = "Region:";
            this.layoutControlItem44.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem44.MinSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem44.Name = "layoutControlItem37";
            this.layoutControlItem44.Size = new System.Drawing.Size(274, 20);
            this.layoutControlItem44.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem44.Text = "Region:";
            this.layoutControlItem44.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem44.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlItem44.TextToControlDistance = 5;
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.Control = this.lblSTVDate;
            this.layoutControlItem46.CustomizationFormText = "Region:";
            this.layoutControlItem46.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem46.MinSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem46.Name = "layoutControlItem37";
            this.layoutControlItem46.Size = new System.Drawing.Size(274, 20);
            this.layoutControlItem46.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem46.Text = "Region:";
            this.layoutControlItem46.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem46.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlItem46.TextToControlDistance = 5;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.lblInstitutionType;
            this.layoutControlItem9.CustomizationFormText = "Mode:";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.MaxSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem9.Name = "layoutControlItem43";
            this.layoutControlItem9.Size = new System.Drawing.Size(196, 20);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "Mode:";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(560, 186);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(3, 13);
            this.labelControl2.StyleController = this.layoutControl3;
            this.labelControl2.TabIndex = 81;
            this.labelControl2.Text = " ";
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.labelControl2;
            this.layoutControlItem28.CustomizationFormText = "Mode:";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem28.MaxSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem28.MinSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem28.Name = "layoutControlItem43";
            this.layoutControlItem28.Size = new System.Drawing.Size(196, 20);
            this.layoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem28.Text = "Mode:";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.Control = this.lblPaymentType;
            this.layoutControlItem29.CustomizationFormText = "Mode:";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem29.MaxSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem29.Name = "layoutControlItem43";
            this.layoutControlItem29.Size = new System.Drawing.Size(196, 20);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "Mode:";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.Control = this.lblOwnership;
            this.layoutControlItem35.CustomizationFormText = "Mode:";
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem35.MaxSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem35.MinSize = new System.Drawing.Size(196, 20);
            this.layoutControlItem35.Name = "layoutControlItem43";
            this.layoutControlItem35.Size = new System.Drawing.Size(196, 20);
            this.layoutControlItem35.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem35.Text = "Mode:";
            this.layoutControlItem35.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem35.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.lblDocumentedType;
            this.layoutControlItem32.CustomizationFormText = "Region:";
            this.layoutControlItem32.Location = new System.Drawing.Point(422, 40);
            this.layoutControlItem32.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(75, 20);
            this.layoutControlItem32.Name = "layoutControlItem37";
            this.layoutControlItem32.Size = new System.Drawing.Size(404, 20);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.Text = "Region:";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(37, 13);
            this.layoutControlItem32.TextToControlDistance = 31;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.Control = this.lblVoidRequestedBy;
            this.layoutControlItem48.CustomizationFormText = "STV Date:";
            this.layoutControlItem48.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem48.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem48.MinSize = new System.Drawing.Size(89, 20);
            this.layoutControlItem48.Name = "layoutControlItem47";
            this.layoutControlItem48.Size = new System.Drawing.Size(198, 20);
            this.layoutControlItem48.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem48.Text = "STV Date:";
            this.layoutControlItem48.TextSize = new System.Drawing.Size(79, 13);
            this.layoutControlItem48.TextToControlDistance = 5;
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.Control = this.lblRequistedDate;
            this.layoutControlItem51.CustomizationFormText = "STV Date:";
            this.layoutControlItem51.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem51.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem51.MinSize = new System.Drawing.Size(89, 20);
            this.layoutControlItem51.Name = "layoutControlItem47";
            this.layoutControlItem51.Size = new System.Drawing.Size(198, 20);
            this.layoutControlItem51.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem51.Text = "STV Date:";
            this.layoutControlItem51.TextSize = new System.Drawing.Size(79, 13);
            this.layoutControlItem51.TextToControlDistance = 5;
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem53.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem53.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem53.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem53.Control = this.lblIssueType;
            this.layoutControlItem53.CustomizationFormText = "Type:";
            this.layoutControlItem53.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem53.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem53.MinSize = new System.Drawing.Size(59, 20);
            this.layoutControlItem53.Name = "layoutControlItem10";
            this.layoutControlItem53.Size = new System.Drawing.Size(206, 20);
            this.layoutControlItem53.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem53.Text = "Type:";
            this.layoutControlItem53.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem53.TextSize = new System.Drawing.Size(31, 13);
            this.layoutControlItem53.TextToControlDistance = 21;
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem55.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem55.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem55.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem55.Control = this.lblIssueStatus;
            this.layoutControlItem55.CustomizationFormText = "Type:";
            this.layoutControlItem55.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem55.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem55.MinSize = new System.Drawing.Size(59, 20);
            this.layoutControlItem55.Name = "layoutControlItem10";
            this.layoutControlItem55.Size = new System.Drawing.Size(206, 20);
            this.layoutControlItem55.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem55.Text = "Type:";
            this.layoutControlItem55.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem55.TextSize = new System.Drawing.Size(31, 13);
            this.layoutControlItem55.TextToControlDistance = 21;
            // 
            // layoutControlItem57
            // 
            this.layoutControlItem57.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem57.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem57.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem57.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem57.Control = this.lblDispatchedDate;
            this.layoutControlItem57.CustomizationFormText = "Dispatch By:";
            this.layoutControlItem57.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem57.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem57.MinSize = new System.Drawing.Size(124, 20);
            this.layoutControlItem57.Name = "layoutControlItem27";
            this.layoutControlItem57.Size = new System.Drawing.Size(211, 40);
            this.layoutControlItem57.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem57.Text = "Dispatched By:";
            this.layoutControlItem57.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem57.TextSize = new System.Drawing.Size(83, 13);
            this.layoutControlItem57.TextToControlDistance = 5;
            // 
            // layoutControlItem59
            // 
            this.layoutControlItem59.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem59.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem59.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem59.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem59.Control = this.lblVoidConfirmedDate;
            this.layoutControlItem59.CustomizationFormText = "Date:";
            this.layoutControlItem59.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem59.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem59.MinSize = new System.Drawing.Size(113, 20);
            this.layoutControlItem59.Name = "layoutControlItem47";
            this.layoutControlItem59.Size = new System.Drawing.Size(198, 20);
            this.layoutControlItem59.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem59.Text = "Printed Date:";
            this.layoutControlItem59.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem59.TextSize = new System.Drawing.Size(74, 13);
            this.layoutControlItem59.TextToControlDistance = 5;
            // 
            // layoutControlItem61
            // 
            this.layoutControlItem61.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem61.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem61.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem61.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem61.Control = this.lblVoidConfirmedBy;
            this.layoutControlItem61.CustomizationFormText = "Date:";
            this.layoutControlItem61.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem61.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem61.MinSize = new System.Drawing.Size(113, 20);
            this.layoutControlItem61.Name = "layoutControlItem47";
            this.layoutControlItem61.Size = new System.Drawing.Size(198, 20);
            this.layoutControlItem61.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem61.Text = "Printed Date:";
            this.layoutControlItem61.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem61.TextSize = new System.Drawing.Size(74, 13);
            this.layoutControlItem61.TextToControlDistance = 5;
            // 
            // DispatchConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 385);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.layoutControl3);
            this.Name = "DispatchConfirmation";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boxSizedList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tEditSTVNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreprintedInvoiceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFacilityNameFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUndispatchedIssues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUndispatchedIssuesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmFromStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTVInvoiceNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUndispatchedIssueDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewUndispatchedIssueDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssuedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FacilityGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem62)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRequestVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcApprovalCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcApproval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDispatchConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastVisitlayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoRequisitionlayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem61)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.GridControl gridUndispatchedIssueDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewUndispatchedIssueDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn colActuallyIssuedNoOfPack;
        private DevExpress.XtraGrid.Columns.GridColumn colBUPicked;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
        private DevExpress.XtraGrid.GridControl gridUndispatchedIssues;
        private DevExpress.XtraGrid.Views.Grid.GridView gridUndispatchedIssuesView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn49;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
        private DevExpress.XtraEditors.MemoEdit txtRemarks;
        private DevExpress.XtraEditors.TextEdit txtIssuedBy;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraEditors.TextEdit txtSTVInvoiceNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraEditors.TextEdit txtConfirmFromStore;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem15;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup10;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit boxSizedList;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem22;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem23;
        private DevExpress.XtraEditors.SimpleButton btnConfirmIssue1;
        private DevExpress.XtraLayout.LayoutControlItem lcDispatchConfirm;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
        private DevExpress.XtraPrinting.PrintableComponentLink printOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn60;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraGrid.Columns.GridColumn Unit;
        private TextEdit txtFacilityNameFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private SimpleButton btnMarkAsVoid;
        private DevExpress.XtraLayout.LayoutControlItem lcRequestVoid;
        private SimpleButton btnCancelVoidRequest;
        private SimpleButton btnApproveVoidRequest;
        private DevExpress.XtraLayout.LayoutControlItem lcApprovalCancel;
        private DevExpress.XtraLayout.LayoutControlItem lcApproval;
        private DevExpress.XtraGrid.Columns.GridColumn colVoidReq;
        private TextEdit txtPreprintedInvoiceNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private GridLookUpEdit lkAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn96;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn97;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn98;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private SimpleButton btnGo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private CalendarLib.DateTimePickerEx dateFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private CalendarLib.DateTimePickerEx dateTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private SimpleButton btnGoSTV;
        private TextEdit tEditSTVNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem LastVisitlayout;
        private DevExpress.XtraLayout.LayoutControlItem NoRequisitionlayout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private LabelControl lblRegion;
        private LabelControl lblMode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private LabelControl lblSTVNo;
        private LabelControl lblWoreda;
        private LabelControl lblZone;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private LabelControl lblDispatchConfirmedBy;
        private LabelControl lblSTVPrintedBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private LabelControl lblSTVDate;
        private LabelControl lblActivity;
        private LabelControl lblSubAccount;
        private LabelControl lblAccount;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup FacilityGroup;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private LabelControl lblPaymentType;
        private LabelControl lblInstitutionType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private LabelControl labelControl2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private LabelControl lblOwnership;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private LabelControl lblDocumentedType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private LabelControl lblRequistedDate;
        private LabelControl lblVoidRequestedBy;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem52;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private LabelControl lblIssueStatus;
        private LabelControl lblIssueType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem54;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem56;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
        private LabelControl lblDispatchedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem58;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem57;
        private LabelControl lblVoidConfirmedBy;
        private LabelControl lblVoidConfirmedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem60;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem62;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem59;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem61;
    }
}