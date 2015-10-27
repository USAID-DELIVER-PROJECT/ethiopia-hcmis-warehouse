using DevExpress.XtraEditors;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    partial class InvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.boxSizedList = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemDateEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemButtonEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.lblPicklistPrintedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblPicklistConfirmedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblAppDate = new DevExpress.XtraEditors.LabelControl();
            this.lblIssueStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblIssueTypes = new DevExpress.XtraEditors.LabelControl();
            this.lblissuedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblPaymentType = new DevExpress.XtraEditors.LabelControl();
            this.lblApprovedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblIssuedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblRefNo = new DevExpress.XtraEditors.LabelControl();
            this.lblApprovedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblInstitutionType = new DevExpress.XtraEditors.LabelControl();
            this.lblRegion = new DevExpress.XtraEditors.LabelControl();
            this.lblZone = new DevExpress.XtraEditors.LabelControl();
            this.lblWoreda = new DevExpress.XtraEditors.LabelControl();
            this.lblOwnership = new DevExpress.XtraEditors.LabelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.chkIncludeInsurance = new DevExpress.XtraEditors.CheckEdit();
            this.btnReturnToApprovalStep = new DevExpress.XtraEditors.SimpleButton();
            this.txtFacilityNameFilter = new DevExpress.XtraEditors.TextEdit();
            this.gridOutstandingPickLists = new DevExpress.XtraGrid.GridControl();
            this.gridOutstandingPickListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmIssue1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelIssue = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmOrderNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmApprovedBy = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmFromStore = new DevExpress.XtraEditors.TextEdit();
            this.txtConfirmRequestedBy = new DevExpress.XtraEditors.TextEdit();
            this.dtIssuedDate = new CalendarLib.DateTimePickerEx();
            this.txtRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.txtIssueRefNo = new DevExpress.XtraEditors.TextEdit();
            this.gridOutstandingPicklistDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewConfirmation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn76 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSKUPicked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colBUPicked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtIssuedBy = new DevExpress.XtraEditors.TextEdit();
            this.lkMode = new DevExpress.XtraEditors.LookUpEdit();
            this.lkPaymentType = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup11 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup12 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.HeaderSection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutSupplimentaryOrder = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcOutstandingPicklists = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.emptySpaceItem15 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup10 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem22 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem23 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
            this.printOrder = new DevExpress.XtraPrinting.PrintableComponentLink();
            ((System.ComponentModel.ISupportInitialize)(this.boxSizedList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeInsurance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFacilityNameFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutstandingPickLists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutstandingPickListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmOrderNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmApprovedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmFromStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmRequestedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueRefNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutstandingPicklistDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConfirmation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssuedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPaymentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSupplimentaryOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcOutstandingPicklists)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
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
            this.SuspendLayout();
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
            this.layoutControl3.Controls.Add(this.lblPicklistPrintedDate);
            this.layoutControl3.Controls.Add(this.lblPicklistConfirmedBy);
            this.layoutControl3.Controls.Add(this.lblAppDate);
            this.layoutControl3.Controls.Add(this.lblIssueStatus);
            this.layoutControl3.Controls.Add(this.lblIssueTypes);
            this.layoutControl3.Controls.Add(this.lblissuedDate);
            this.layoutControl3.Controls.Add(this.lblPaymentType);
            this.layoutControl3.Controls.Add(this.lblApprovedBy);
            this.layoutControl3.Controls.Add(this.lblIssuedBy);
            this.layoutControl3.Controls.Add(this.lblRefNo);
            this.layoutControl3.Controls.Add(this.lblApprovedDate);
            this.layoutControl3.Controls.Add(this.lblInstitutionType);
            this.layoutControl3.Controls.Add(this.lblRegion);
            this.layoutControl3.Controls.Add(this.lblZone);
            this.layoutControl3.Controls.Add(this.lblWoreda);
            this.layoutControl3.Controls.Add(this.lblOwnership);
            this.layoutControl3.Controls.Add(this.lblMode);
            this.layoutControl3.Controls.Add(this.chkIncludeInsurance);
            this.layoutControl3.Controls.Add(this.btnReturnToApprovalStep);
            this.layoutControl3.Controls.Add(this.txtFacilityNameFilter);
            this.layoutControl3.Controls.Add(this.gridOutstandingPickLists);
            this.layoutControl3.Controls.Add(this.simpleButton1);
            this.layoutControl3.Controls.Add(this.btnConfirmIssue1);
            this.layoutControl3.Controls.Add(this.btnCancelIssue);
            this.layoutControl3.Controls.Add(this.txtConfirmOrderNumber);
            this.layoutControl3.Controls.Add(this.txtConfirmApprovedBy);
            this.layoutControl3.Controls.Add(this.txtConfirmFromStore);
            this.layoutControl3.Controls.Add(this.txtConfirmRequestedBy);
            this.layoutControl3.Controls.Add(this.dtIssuedDate);
            this.layoutControl3.Controls.Add(this.txtRemarks);
            this.layoutControl3.Controls.Add(this.txtIssueRefNo);
            this.layoutControl3.Controls.Add(this.gridOutstandingPicklistDetail);
            this.layoutControl3.Controls.Add(this.txtIssuedBy);
            this.layoutControl3.Controls.Add(this.lkMode);
            this.layoutControl3.Controls.Add(this.lkPaymentType);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.tabbedControlGroup1,
            this.layoutControlItem26,
            this.layoutControlItem25,
            this.layoutControlItem20,
            this.layoutControlItem17,
            this.layoutControlItem21,
            this.layoutControlItem27,
            this.layoutControlItem22,
            this.layoutControlItem1,
            this.layoutControlItem12,
            this.layoutControlItem15});
            this.layoutControl3.Location = new System.Drawing.Point(0, 0);
            this.layoutControl3.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(330, 260, 250, 350);
            this.layoutControl3.Root = this.layoutControlGroup7;
            this.layoutControl3.Size = new System.Drawing.Size(1123, 575);
            this.layoutControl3.TabIndex = 37;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // lblPicklistPrintedDate
            // 
            this.lblPicklistPrintedDate.Location = new System.Drawing.Point(823, 104);
            this.lblPicklistPrintedDate.Name = "lblPicklistPrintedDate";
            this.lblPicklistPrintedDate.Size = new System.Drawing.Size(91, 16);
            this.lblPicklistPrintedDate.StyleController = this.layoutControl3;
            this.lblPicklistPrintedDate.TabIndex = 63;
            // 
            // lblPicklistConfirmedBy
            // 
            this.lblPicklistConfirmedBy.Location = new System.Drawing.Point(823, 124);
            this.lblPicklistConfirmedBy.Name = "lblPicklistConfirmedBy";
            this.lblPicklistConfirmedBy.Size = new System.Drawing.Size(91, 16);
            this.lblPicklistConfirmedBy.StyleController = this.layoutControl3;
            this.lblPicklistConfirmedBy.TabIndex = 62;
            // 
            // lblAppDate
            // 
            this.lblAppDate.Location = new System.Drawing.Point(622, 104);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(91, 16);
            this.lblAppDate.StyleController = this.layoutControl3;
            this.lblAppDate.TabIndex = 61;
            // 
            // lblIssueStatus
            // 
            this.lblIssueStatus.Location = new System.Drawing.Point(977, 104);
            this.lblIssueStatus.Name = "lblIssueStatus";
            this.lblIssueStatus.Size = new System.Drawing.Size(135, 16);
            this.lblIssueStatus.StyleController = this.layoutControl3;
            this.lblIssueStatus.TabIndex = 60;
            // 
            // lblIssueTypes
            // 
            this.lblIssueTypes.Location = new System.Drawing.Point(977, 124);
            this.lblIssueTypes.Name = "lblIssueTypes";
            this.lblIssueTypes.Size = new System.Drawing.Size(135, 16);
            this.lblIssueTypes.StyleController = this.layoutControl3;
            this.lblIssueTypes.TabIndex = 59;
            // 
            // lblissuedDate
            // 
            this.lblissuedDate.Location = new System.Drawing.Point(424, 104);
            this.lblissuedDate.Name = "lblissuedDate";
            this.lblissuedDate.Size = new System.Drawing.Size(87, 16);
            this.lblissuedDate.StyleController = this.layoutControl3;
            this.lblissuedDate.TabIndex = 58;
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.Location = new System.Drawing.Point(384, 50);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(139, 16);
            this.lblPaymentType.StyleController = this.layoutControl3;
            this.lblPaymentType.TabIndex = 57;
            // 
            // lblApprovedBy
            // 
            this.lblApprovedBy.Location = new System.Drawing.Point(622, 124);
            this.lblApprovedBy.Name = "lblApprovedBy";
            this.lblApprovedBy.Size = new System.Drawing.Size(91, 16);
            this.lblApprovedBy.StyleController = this.layoutControl3;
            this.lblApprovedBy.TabIndex = 56;
            // 
            // lblIssuedBy
            // 
            this.lblIssuedBy.Location = new System.Drawing.Point(424, 124);
            this.lblIssuedBy.Name = "lblIssuedBy";
            this.lblIssuedBy.Size = new System.Drawing.Size(87, 16);
            this.lblIssuedBy.StyleController = this.layoutControl3;
            this.lblIssuedBy.TabIndex = 55;
            // 
            // lblRefNo
            // 
            this.lblRefNo.Location = new System.Drawing.Point(594, 50);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(132, 16);
            this.lblRefNo.StyleController = this.layoutControl3;
            this.lblRefNo.TabIndex = 54;
            // 
            // lblApprovedDate
            // 
            this.lblApprovedDate.Location = new System.Drawing.Point(854, 104);
            this.lblApprovedDate.Name = "lblApprovedDate";
            this.lblApprovedDate.Size = new System.Drawing.Size(58, 16);
            this.lblApprovedDate.StyleController = this.layoutControl3;
            this.lblApprovedDate.TabIndex = 53;
            // 
            // lblInstitutionType
            // 
            this.lblInstitutionType.Location = new System.Drawing.Point(795, 50);
            this.lblInstitutionType.Name = "lblInstitutionType";
            this.lblInstitutionType.Size = new System.Drawing.Size(317, 16);
            this.lblInstitutionType.StyleController = this.layoutControl3;
            this.lblInstitutionType.TabIndex = 52;
            // 
            // lblRegion
            // 
            this.lblRegion.Location = new System.Drawing.Point(795, 70);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(317, 16);
            this.lblRegion.StyleController = this.layoutControl3;
            this.lblRegion.TabIndex = 51;
            // 
            // lblZone
            // 
            this.lblZone.Location = new System.Drawing.Point(594, 70);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(132, 16);
            this.lblZone.StyleController = this.layoutControl3;
            this.lblZone.TabIndex = 50;
            // 
            // lblWoreda
            // 
            this.lblWoreda.Location = new System.Drawing.Point(384, 70);
            this.lblWoreda.Name = "lblWoreda";
            this.lblWoreda.Size = new System.Drawing.Size(139, 16);
            this.lblWoreda.StyleController = this.layoutControl3;
            this.lblWoreda.TabIndex = 49;
            // 
            // lblOwnership
            // 
            this.lblOwnership.Location = new System.Drawing.Point(594, 30);
            this.lblOwnership.Name = "lblOwnership";
            this.lblOwnership.Size = new System.Drawing.Size(518, 16);
            this.lblOwnership.StyleController = this.layoutControl3;
            this.lblOwnership.TabIndex = 48;
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(384, 30);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(139, 16);
            this.lblMode.StyleController = this.layoutControl3;
            this.lblMode.TabIndex = 47;
            // 
            // chkIncludeInsurance
            // 
            this.chkIncludeInsurance.Location = new System.Drawing.Point(318, 151);
            this.chkIncludeInsurance.Name = "chkIncludeInsurance";
            this.chkIncludeInsurance.Properties.Caption = "Include Insurance";
            this.chkIncludeInsurance.Size = new System.Drawing.Size(801, 19);
            this.chkIncludeInsurance.StyleController = this.layoutControl3;
            this.chkIncludeInsurance.TabIndex = 45;
            // 
            // btnReturnToApprovalStep
            // 
            this.btnReturnToApprovalStep.Image = global::HCMIS.Desktop.Properties.Resources.Undo;
            this.btnReturnToApprovalStep.Location = new System.Drawing.Point(685, 549);
            this.btnReturnToApprovalStep.Name = "btnReturnToApprovalStep";
            this.btnReturnToApprovalStep.Size = new System.Drawing.Size(142, 22);
            this.btnReturnToApprovalStep.StyleController = this.layoutControl3;
            this.btnReturnToApprovalStep.TabIndex = 39;
            this.btnReturnToApprovalStep.Text = "Return to SDO";
            this.btnReturnToApprovalStep.Click += new System.EventHandler(this.btnReturnToApprovalStep_Click);
            // 
            // txtFacilityNameFilter
            // 
            this.txtFacilityNameFilter.Location = new System.Drawing.Point(50, 62);
            this.txtFacilityNameFilter.Name = "txtFacilityNameFilter";
            this.txtFacilityNameFilter.Size = new System.Drawing.Size(243, 20);
            this.txtFacilityNameFilter.StyleController = this.layoutControl3;
            this.txtFacilityNameFilter.TabIndex = 44;
            this.txtFacilityNameFilter.EditValueChanged += new System.EventHandler(this.txtFacilityNameFilter_EditValueChanged);
            // 
            // gridOutstandingPickLists
            // 
            this.gridOutstandingPickLists.Location = new System.Drawing.Point(5, 98);
            this.gridOutstandingPickLists.MainView = this.gridOutstandingPickListView;
            this.gridOutstandingPickLists.Name = "gridOutstandingPickLists";
            this.gridOutstandingPickLists.Size = new System.Drawing.Size(300, 448);
            this.gridOutstandingPickLists.TabIndex = 0;
            this.gridOutstandingPickLists.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridOutstandingPickListView});
            // 
            // gridOutstandingPickListView
            // 
            this.gridOutstandingPickListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn48,
            this.gridColumn49,
            this.gridColumn46});
            this.gridOutstandingPickListView.GridControl = this.gridOutstandingPickLists;
            this.gridOutstandingPickListView.GroupCount = 1;
            this.gridOutstandingPickListView.Name = "gridOutstandingPickListView";
            this.gridOutstandingPickListView.OptionsBehavior.Editable = false;
            this.gridOutstandingPickListView.OptionsCustomization.AllowColumnMoving = false;
            this.gridOutstandingPickListView.OptionsCustomization.AllowColumnResizing = false;
            this.gridOutstandingPickListView.OptionsCustomization.AllowSort = false;
            this.gridOutstandingPickListView.OptionsMenu.EnableColumnMenu = false;
            this.gridOutstandingPickListView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridOutstandingPickListView.OptionsSelection.UseIndicatorForSelection = false;
            this.gridOutstandingPickListView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridOutstandingPickListView.OptionsView.ShowGroupPanel = false;
            this.gridOutstandingPickListView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn46, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridOutstandingPickListView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.OnOutstandingPicklistSelected);
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "Referance Number";
            this.gridColumn48.FieldName = "RefNo";
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
            this.gridColumn48.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn48.OptionsFilter.AllowFilter = false;
            this.gridColumn48.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn48.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.Visible = true;
            this.gridColumn48.VisibleIndex = 0;
            // 
            // gridColumn49
            // 
            this.gridColumn49.Caption = "Requested By";
            this.gridColumn49.FieldName = "RequestedBy";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.OptionsColumn.AllowEdit = false;
            this.gridColumn49.OptionsColumn.AllowFocus = false;
            this.gridColumn49.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn49.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsColumn.AllowMove = false;
            this.gridColumn49.OptionsColumn.AllowShowHide = false;
            this.gridColumn49.OptionsColumn.AllowSize = false;
            this.gridColumn49.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn49.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn49.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn49.OptionsFilter.AllowFilter = false;
            this.gridColumn49.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn49.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.Visible = true;
            this.gridColumn49.VisibleIndex = 1;
            this.gridColumn49.Width = 159;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "Route";
            this.gridColumn46.FieldName = "RouteName";
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.OptionsColumn.AllowEdit = false;
            this.gridColumn46.OptionsColumn.AllowFocus = false;
            this.gridColumn46.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn46.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsColumn.AllowMove = false;
            this.gridColumn46.OptionsColumn.AllowShowHide = false;
            this.gridColumn46.OptionsColumn.AllowSize = false;
            this.gridColumn46.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn46.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn46.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn46.OptionsFilter.AllowFilter = false;
            this.gridColumn46.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn46.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(539, 549);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(142, 22);
            this.simpleButton1.StyleController = this.layoutControl3;
            this.simpleButton1.TabIndex = 43;
            this.simpleButton1.Text = "Supplimentary PickList";
            // 
            // btnConfirmIssue1
            // 
            this.btnConfirmIssue1.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmIssue1.Image")));
            this.btnConfirmIssue1.Location = new System.Drawing.Point(831, 549);
            this.btnConfirmIssue1.Name = "btnConfirmIssue1";
            this.btnConfirmIssue1.Size = new System.Drawing.Size(142, 22);
            this.btnConfirmIssue1.StyleController = this.layoutControl3;
            this.btnConfirmIssue1.TabIndex = 42;
            this.btnConfirmIssue1.Text = "Confirm Issue";
            this.btnConfirmIssue1.Click += new System.EventHandler(this.btnConfirmIssue_Click);
            // 
            // btnCancelIssue
            // 
            this.btnCancelIssue.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelIssue.Image")));
            this.btnCancelIssue.Location = new System.Drawing.Point(977, 549);
            this.btnCancelIssue.Name = "btnCancelIssue";
            this.btnCancelIssue.Size = new System.Drawing.Size(142, 22);
            this.btnCancelIssue.StyleController = this.layoutControl3;
            this.btnCancelIssue.TabIndex = 41;
            this.btnCancelIssue.Text = "Cancel";
            this.btnCancelIssue.Click += new System.EventHandler(this.btnCancelIssue_Click);
            // 
            // txtConfirmOrderNumber
            // 
            this.txtConfirmOrderNumber.Enabled = false;
            this.txtConfirmOrderNumber.Location = new System.Drawing.Point(378, 119);
            this.txtConfirmOrderNumber.Name = "txtConfirmOrderNumber";
            this.txtConfirmOrderNumber.Size = new System.Drawing.Size(217, 20);
            this.txtConfirmOrderNumber.StyleController = this.layoutControl3;
            this.txtConfirmOrderNumber.TabIndex = 40;
            // 
            // txtConfirmApprovedBy
            // 
            this.txtConfirmApprovedBy.Enabled = false;
            this.txtConfirmApprovedBy.Location = new System.Drawing.Point(938, 100);
            this.txtConfirmApprovedBy.Name = "txtConfirmApprovedBy";
            this.txtConfirmApprovedBy.Size = new System.Drawing.Size(50, 20);
            this.txtConfirmApprovedBy.StyleController = this.layoutControl3;
            this.txtConfirmApprovedBy.TabIndex = 39;
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
            // txtConfirmRequestedBy
            // 
            this.txtConfirmRequestedBy.Enabled = false;
            this.txtConfirmRequestedBy.Location = new System.Drawing.Point(378, 167);
            this.txtConfirmRequestedBy.Name = "txtConfirmRequestedBy";
            this.txtConfirmRequestedBy.Size = new System.Drawing.Size(217, 20);
            this.txtConfirmRequestedBy.StyleController = this.layoutControl3;
            this.txtConfirmRequestedBy.TabIndex = 37;
            // 
            // dtIssuedDate
            // 
            this.dtIssuedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtIssuedDate.CalendarFont = new System.Drawing.Font("Nyala", 13F);
            this.dtIssuedDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtIssuedDate.DayOfWeekCharacters = 1;
            this.dtIssuedDate.Enabled = false;
            this.dtIssuedDate.ForeColor = System.Drawing.Color.Black;
            this.dtIssuedDate.Location = new System.Drawing.Point(590, 104);
            this.dtIssuedDate.MinDateTime = new System.DateTime(2002, 1, 12, 0, 0, 0, 0);
            this.dtIssuedDate.Name = "dtIssuedDate";
            this.dtIssuedDate.PopUpFontSize = 10F;
            this.dtIssuedDate.Size = new System.Drawing.Size(120, 36);
            this.dtIssuedDate.TabIndex = 28;
            this.dtIssuedDate.Value = new System.DateTime(2012, 1, 12, 0, 0, 0, 0);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRemarks.Location = new System.Drawing.Point(343, 447);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(235, 124);
            this.txtRemarks.StyleController = this.layoutControl3;
            this.txtRemarks.TabIndex = 32;
            // 
            // txtIssueRefNo
            // 
            this.txtIssueRefNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIssueRefNo.Enabled = false;
            this.txtIssueRefNo.Location = new System.Drawing.Point(378, 100);
            this.txtIssueRefNo.Name = "txtIssueRefNo";
            this.txtIssueRefNo.Size = new System.Drawing.Size(50, 20);
            this.txtIssueRefNo.StyleController = this.layoutControl3;
            this.txtIssueRefNo.TabIndex = 34;
            // 
            // gridOutstandingPicklistDetail
            // 
            this.gridOutstandingPicklistDetail.Location = new System.Drawing.Point(318, 174);
            this.gridOutstandingPicklistDetail.MainView = this.gridViewConfirmation;
            this.gridOutstandingPicklistDetail.Margin = new System.Windows.Forms.Padding(0);
            this.gridOutstandingPicklistDetail.Name = "gridOutstandingPicklistDetail";
            this.gridOutstandingPicklistDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit3,
            this.repositoryItemTextEdit2});
            this.gridOutstandingPicklistDetail.Size = new System.Drawing.Size(801, 371);
            this.gridOutstandingPicklistDetail.TabIndex = 13;
            this.gridOutstandingPicklistDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewConfirmation});
            this.gridOutstandingPicklistDetail.DoubleClick += new System.EventHandler(this.gridOutstandingPicklistDetail_DoubleClick);
            // 
            // gridViewConfirmation
            // 
            this.gridViewConfirmation.Appearance.GroupFooter.BackColor = System.Drawing.Color.White;
            this.gridViewConfirmation.Appearance.GroupFooter.BackColor2 = System.Drawing.Color.White;
            this.gridViewConfirmation.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewConfirmation.Appearance.GroupFooter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gridViewConfirmation.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridViewConfirmation.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridViewConfirmation.Appearance.GroupFooter.Options.UseTextOptions = true;
            this.gridViewConfirmation.Appearance.GroupFooter.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewConfirmation.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewConfirmation.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridViewConfirmation.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewConfirmation.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewConfirmation.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewConfirmation.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewConfirmation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn76,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn40,
            this.colSKUPicked,
            this.colBUPicked,
            this.gridColumn47,
            this.colCost,
            this.gridColumn60,
            this.gridColumn62,
            this.gridColumn50});
            this.gridViewConfirmation.GridControl = this.gridOutstandingPicklistDetail;
            this.gridViewConfirmation.GroupCount = 1;
            this.gridViewConfirmation.Name = "gridViewConfirmation";
            this.gridViewConfirmation.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewConfirmation.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewConfirmation.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewConfirmation.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewConfirmation.OptionsMenu.EnableColumnMenu = false;
            this.gridViewConfirmation.OptionsView.AllowCellMerge = true;
            this.gridViewConfirmation.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden;
            this.gridViewConfirmation.OptionsView.RowAutoHeight = true;
            this.gridViewConfirmation.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewConfirmation.OptionsView.ShowFooter = true;
            this.gridViewConfirmation.OptionsView.ShowGroupPanel = false;
            this.gridViewConfirmation.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn22, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewConfirmation.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            // 
            // gridColumn76
            // 
            this.gridColumn76.Caption = "Unit";
            this.gridColumn76.FieldName = "Unit";
            this.gridColumn76.Name = "gridColumn76";
            this.gridColumn76.OptionsColumn.AllowEdit = false;
            this.gridColumn76.OptionsColumn.AllowFocus = false;
            this.gridColumn76.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn76.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn76.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn76.OptionsColumn.AllowMove = false;
            this.gridColumn76.OptionsColumn.AllowShowHide = false;
            this.gridColumn76.OptionsColumn.AllowSize = false;
            this.gridColumn76.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn76.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn76.OptionsFilter.AllowFilter = false;
            this.gridColumn76.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn76.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn76.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn76.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn76.Visible = true;
            this.gridColumn76.VisibleIndex = 4;
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
            this.gridColumn22.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.AllowMove = false;
            this.gridColumn22.OptionsColumn.AllowShowHide = false;
            this.gridColumn22.OptionsColumn.AllowSize = false;
            this.gridColumn22.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn22.OptionsFilter.AllowFilter = false;
            this.gridColumn22.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn22.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.Width = 84;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn23.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn23.Caption = "Manufacturer";
            this.gridColumn23.FieldName = "ManufacturerName";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsColumn.AllowMove = false;
            this.gridColumn23.OptionsColumn.AllowShowHide = false;
            this.gridColumn23.OptionsColumn.AllowSize = false;
            this.gridColumn23.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn23.OptionsFilter.AllowFilter = false;
            this.gridColumn23.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn23.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
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
            this.gridColumn35.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn35.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsColumn.AllowMove = false;
            this.gridColumn35.OptionsColumn.AllowShowHide = false;
            this.gridColumn35.OptionsColumn.AllowSize = false;
            this.gridColumn35.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn35.OptionsFilter.AllowFilter = false;
            this.gridColumn35.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn35.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.Width = 120;
            // 
            // gridColumn36
            // 
            this.gridColumn36.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn36.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn36.Caption = "Packs To Pick";
            this.gridColumn36.DisplayFormat.FormatString = "#,###.##";
            this.gridColumn36.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn36.FieldName = "SKUTOPICK";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            this.gridColumn36.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn36.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.AllowMove = false;
            this.gridColumn36.OptionsColumn.AllowShowHide = false;
            this.gridColumn36.OptionsColumn.AllowSize = false;
            this.gridColumn36.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn36.OptionsFilter.AllowFilter = false;
            this.gridColumn36.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn36.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 5;
            this.gridColumn36.Width = 101;
            // 
            // gridColumn37
            // 
            this.gridColumn37.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn37.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn37.Caption = "Batch";
            this.gridColumn37.FieldName = "BatchNumber";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn37.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsColumn.AllowMove = false;
            this.gridColumn37.OptionsColumn.AllowShowHide = false;
            this.gridColumn37.OptionsColumn.AllowSize = false;
            this.gridColumn37.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn37.OptionsFilter.AllowFilter = false;
            this.gridColumn37.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn37.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 1;
            this.gridColumn37.Width = 67;
            // 
            // gridColumn38
            // 
            this.gridColumn38.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn38.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn38.Caption = "Expiry Date";
            this.gridColumn38.ColumnEdit = this.repositoryItemDateEdit3;
            this.gridColumn38.DisplayFormat.FormatString = "MMM/d/yyyy";
            this.gridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn38.FieldName = "ExpireDate";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.AllowFocus = false;
            this.gridColumn38.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn38.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsColumn.AllowMove = false;
            this.gridColumn38.OptionsColumn.AllowShowHide = false;
            this.gridColumn38.OptionsColumn.AllowSize = false;
            this.gridColumn38.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn38.OptionsFilter.AllowFilter = false;
            this.gridColumn38.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn38.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 2;
            this.gridColumn38.Width = 99;
            // 
            // gridColumn39
            // 
            this.gridColumn39.ColumnEdit = this.repositoryItemButtonEdit4;
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.OptionsColumn.AllowFocus = false;
            this.gridColumn39.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn39.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsColumn.AllowMove = false;
            this.gridColumn39.OptionsColumn.AllowShowHide = false;
            this.gridColumn39.OptionsColumn.AllowSize = false;
            this.gridColumn39.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn39.OptionsFilter.AllowFilter = false;
            this.gridColumn39.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn39.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
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
            this.gridColumn40.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn40.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsColumn.AllowMove = false;
            this.gridColumn40.OptionsColumn.AllowShowHide = false;
            this.gridColumn40.OptionsColumn.AllowSize = false;
            this.gridColumn40.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn40.OptionsFilter.AllowFilter = false;
            this.gridColumn40.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn40.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colSKUPicked
            // 
            this.colSKUPicked.Caption = "Packs Picked";
            this.colSKUPicked.ColumnEdit = this.repositoryItemTextEdit2;
            this.colSKUPicked.DisplayFormat.FormatString = "#,###";
            this.colSKUPicked.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSKUPicked.FieldName = "SKUPICKED";
            this.colSKUPicked.Name = "colSKUPicked";
            this.colSKUPicked.OptionsColumn.AllowEdit = false;
            this.colSKUPicked.OptionsColumn.AllowFocus = false;
            this.colSKUPicked.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSKUPicked.OptionsColumn.AllowIncrementalSearch = false;
            this.colSKUPicked.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSKUPicked.OptionsColumn.AllowMove = false;
            this.colSKUPicked.OptionsColumn.AllowShowHide = false;
            this.colSKUPicked.OptionsColumn.AllowSize = false;
            this.colSKUPicked.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSKUPicked.OptionsFilter.AllowAutoFilter = false;
            this.colSKUPicked.OptionsFilter.AllowFilter = false;
            this.colSKUPicked.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colSKUPicked.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colSKUPicked.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colSKUPicked.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colSKUPicked.Width = 78;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
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
            this.colBUPicked.OptionsColumn.AllowEdit = false;
            this.colBUPicked.OptionsColumn.AllowFocus = false;
            this.colBUPicked.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsColumn.AllowIncrementalSearch = false;
            this.colBUPicked.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsColumn.AllowMove = false;
            this.colBUPicked.OptionsColumn.AllowShowHide = false;
            this.colBUPicked.OptionsColumn.AllowSize = false;
            this.colBUPicked.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsFilter.AllowAutoFilter = false;
            this.colBUPicked.OptionsFilter.AllowFilter = false;
            this.colBUPicked.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colBUPicked.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colBUPicked.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colBUPicked.Width = 102;
            // 
            // gridColumn47
            // 
            this.gridColumn47.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn47.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn47.Caption = "Location";
            this.gridColumn47.FieldName = "PalletLocation";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.OptionsColumn.AllowEdit = false;
            this.gridColumn47.OptionsColumn.AllowFocus = false;
            this.gridColumn47.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn47.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.AllowMove = false;
            this.gridColumn47.OptionsColumn.AllowShowHide = false;
            this.gridColumn47.OptionsColumn.AllowSize = false;
            this.gridColumn47.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn47.OptionsFilter.AllowFilter = false;
            this.gridColumn47.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn47.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 3;
            this.gridColumn47.Width = 100;
            // 
            // colCost
            // 
            this.colCost.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colCost.AppearanceCell.Options.UseBackColor = true;
            this.colCost.Caption = "Price";
            this.colCost.DisplayFormat.FormatString = "#,##0.#0";
            this.colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCost.FieldName = "Cost";
            this.colCost.GroupFormat.FormatString = "#,###.##";
            this.colCost.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCost.Name = "colCost";
            this.colCost.OptionsColumn.AllowEdit = false;
            this.colCost.OptionsColumn.AllowFocus = false;
            this.colCost.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsColumn.AllowIncrementalSearch = false;
            this.colCost.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsColumn.AllowMove = false;
            this.colCost.OptionsColumn.AllowShowHide = false;
            this.colCost.OptionsColumn.AllowSize = false;
            this.colCost.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsFilter.AllowAutoFilter = false;
            this.colCost.OptionsFilter.AllowFilter = false;
            this.colCost.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCost.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:#,###.##}")});
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 7;
            this.colCost.Width = 85;
            // 
            // gridColumn60
            // 
            this.gridColumn60.Caption = "Units";
            this.gridColumn60.FieldName = "SKUBU";
            this.gridColumn60.Name = "gridColumn60";
            this.gridColumn60.OptionsColumn.AllowEdit = false;
            this.gridColumn60.OptionsColumn.AllowFocus = false;
            this.gridColumn60.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn60.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsColumn.AllowMove = false;
            this.gridColumn60.OptionsColumn.AllowShowHide = false;
            this.gridColumn60.OptionsColumn.AllowSize = false;
            this.gridColumn60.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn60.OptionsFilter.AllowFilter = false;
            this.gridColumn60.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn60.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn60.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn62
            // 
            this.gridColumn62.Caption = "Unit Price";
            this.gridColumn62.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn62.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn62.FieldName = "UnitPrice";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.OptionsColumn.AllowEdit = false;
            this.gridColumn62.OptionsColumn.AllowFocus = false;
            this.gridColumn62.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn62.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsColumn.AllowMove = false;
            this.gridColumn62.OptionsColumn.AllowShowHide = false;
            this.gridColumn62.OptionsColumn.AllowSize = false;
            this.gridColumn62.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn62.OptionsFilter.AllowFilter = false;
            this.gridColumn62.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn62.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 6;
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
            this.gridColumn50.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn50.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsColumn.AllowMove = false;
            this.gridColumn50.OptionsColumn.AllowShowHide = false;
            this.gridColumn50.OptionsColumn.AllowSize = false;
            this.gridColumn50.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn50.OptionsFilter.AllowFilter = false;
            this.gridColumn50.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn50.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.Width = 77;
            // 
            // txtIssuedBy
            // 
            this.txtIssuedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIssuedBy.Enabled = false;
            this.txtIssuedBy.Location = new System.Drawing.Point(609, 124);
            this.txtIssuedBy.Name = "txtIssuedBy";
            this.txtIssuedBy.Size = new System.Drawing.Size(53, 20);
            this.txtIssuedBy.StyleController = this.layoutControl3;
            this.txtIssuedBy.TabIndex = 31;
            // 
            // lkMode
            // 
            this.lkMode.EditValue = "Select Mode";
            this.lkMode.Location = new System.Drawing.Point(50, 36);
            this.lkMode.Name = "lkMode";
            this.lkMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkMode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "Name")});
            this.lkMode.Properties.DisplayMember = "TypeName";
            this.lkMode.Properties.PopupSizeable = false;
            this.lkMode.Properties.ShowFooter = false;
            this.lkMode.Properties.ShowHeader = false;
            this.lkMode.Properties.ValueMember = "ID";
            this.lkMode.Size = new System.Drawing.Size(243, 20);
            this.lkMode.StyleController = this.layoutControl3;
            this.lkMode.TabIndex = 46;
            this.lkMode.EditValueChanged += new System.EventHandler(this.lkMode_EditValueChanged);
            // 
            // lkPaymentType
            // 
            this.lkPaymentType.EditValue = "Select Payment Type";
            this.lkPaymentType.Enabled = false;
            this.lkPaymentType.Location = new System.Drawing.Point(867, 30);
            this.lkPaymentType.Margin = new System.Windows.Forms.Padding(0);
            this.lkPaymentType.Name = "lkPaymentType";
            this.lkPaymentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkPaymentType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkPaymentType.Properties.DisplayMember = "Name";
            this.lkPaymentType.Properties.PopupSizeable = false;
            this.lkPaymentType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lkPaymentType.Properties.ValueMember = "ID";
            this.lkPaymentType.Size = new System.Drawing.Size(127, 20);
            this.lkPaymentType.StyleController = this.layoutControl3;
            this.lkPaymentType.TabIndex = 38;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidationProvider1.SetValidationRule(this.lkPaymentType, conditionValidationRule1);
            this.lkPaymentType.EditValueChanged += new System.EventHandler(this.lkPaymentType_EditValueChanged);
            this.lkPaymentType.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cboCashCredit_EditValueChanging);
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
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.txtConfirmRequestedBy;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem25";
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(326, 24);
            this.layoutControlItem25.Text = "Requested By";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(100, 13);
            this.layoutControlItem25.TextToControlDistance = 5;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.txtConfirmOrderNumber;
            this.layoutControlItem20.CustomizationFormText = "Order Number";
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(326, 24);
            this.layoutControlItem20.Text = "Order Number";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(100, 13);
            this.layoutControlItem20.TextToControlDistance = 5;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txtIssueRefNo;
            this.layoutControlItem17.CustomizationFormText = "Ref. No";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(159, 24);
            this.layoutControlItem17.Text = "Ref. No:";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(100, 13);
            this.layoutControlItem17.TextToControlDistance = 5;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.txtIssuedBy;
            this.layoutControlItem21.CustomizationFormText = "Issued By";
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(144, 24);
            this.layoutControlItem21.Text = "Issued By";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(100, 13);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.txtConfirmApprovedBy;
            this.layoutControlItem27.CustomizationFormText = "Approved By";
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(158, 24);
            this.layoutControlItem27.Text = "Approved By";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(100, 13);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.txtRemarks;
            this.layoutControlItem22.CustomizationFormText = "Remarks";
            this.layoutControlItem22.Location = new System.Drawing.Point(257, 443);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(321, 128);
            this.layoutControlItem22.Text = "Remarks";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(100, 13);
            this.layoutControlItem22.TextToControlDistance = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkPaymentType;
            this.layoutControlItem1.CustomizationFormText = "Payment Type";
            this.layoutControlItem1.Location = new System.Drawing.Point(468, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(128, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(205, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Payment Type";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem12.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem12.Control = this.lblApprovedDate;
            this.layoutControlItem12.CustomizationFormText = "Approved Date:";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(188, 20);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(188, 20);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(188, 20);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "Approved Date:";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(121, 13);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.dtIssuedDate;
            this.layoutControlItem15.CustomizationFormText = "Issued Date";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(186, 24);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(187, 40);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.Text = "Issued Date";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(58, 13);
            this.layoutControlItem15.TextToControlDistance = 5;
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.CustomizationFormText = "layoutControlGroup7";
            this.layoutControlGroup7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup7.GroupBordersVisible = false;
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup12,
            this.layoutControlGroup13,
            this.layoutControlItem42,
            this.layoutControlItem43,
            this.layoutSupplimentaryOrder,
            this.lcOutstandingPicklists,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.emptySpaceItem3});
            this.layoutControlGroup7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup7.Name = "Root";
            this.layoutControlGroup7.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup7.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup7.Size = new System.Drawing.Size(1123, 575);
            this.layoutControlGroup7.Text = "Root";
            this.layoutControlGroup7.TextVisible = false;
            // 
            // layoutControlGroup12
            // 
            this.layoutControlGroup12.CustomizationFormText = "Order Headers";
            this.layoutControlGroup12.GroupBordersVisible = false;
            this.layoutControlGroup12.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.HeaderSection,
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4,
            this.layoutControlGroup1});
            this.layoutControlGroup12.Location = new System.Drawing.Point(314, 0);
            this.layoutControlGroup12.Name = "layoutControlGroup12";
            this.layoutControlGroup12.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup12.Size = new System.Drawing.Size(805, 147);
            this.layoutControlGroup12.Text = "Order Headers";
            // 
            // HeaderSection
            // 
            this.HeaderSection.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderSection.AppearanceGroup.Options.UseFont = true;
            this.HeaderSection.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.HeaderSection.AppearanceItemCaption.Options.UseFont = true;
            this.HeaderSection.CustomizationFormText = " ";
            this.HeaderSection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem23,
            this.layoutControlItem11,
            this.layoutControlItem13});
            this.HeaderSection.Location = new System.Drawing.Point(0, 0);
            this.HeaderSection.Name = "HeaderSection";
            this.HeaderSection.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.HeaderSection.Size = new System.Drawing.Size(805, 93);
            this.HeaderSection.Text = " ";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem6.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem6.Control = this.lblMode;
            this.layoutControlItem6.CustomizationFormText = "Mode:";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(51, 20);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(202, 20);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Mode:";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(34, 13);
            this.layoutControlItem6.TextToControlDistance = 25;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem7.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem7.Control = this.lblOwnership;
            this.layoutControlItem7.CustomizationFormText = "Ownership Type:";
            this.layoutControlItem7.Location = new System.Drawing.Point(202, 0);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(64, 17);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(589, 20);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "Ownership:";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(62, 13);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem8.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem8.Control = this.lblWoreda;
            this.layoutControlItem8.CustomizationFormText = "Woreda:";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(51, 20);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(202, 20);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "Woreda:";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem8.TextToControlDistance = 12;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem9.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem9.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem9.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem9.Control = this.lblZone;
            this.layoutControlItem9.CustomizationFormText = "Zone:";
            this.layoutControlItem9.Location = new System.Drawing.Point(202, 40);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(78, 17);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(203, 20);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "Zone:";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(31, 13);
            this.layoutControlItem9.TextToControlDistance = 36;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem10.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem10.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem10.Control = this.lblRegion;
            this.layoutControlItem10.CustomizationFormText = "Region:";
            this.layoutControlItem10.Location = new System.Drawing.Point(405, 40);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(66, 17);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(386, 20);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "Region:";
            this.layoutControlItem10.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(42, 13);
            this.layoutControlItem10.TextToControlDistance = 23;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem23.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem23.Control = this.lblPaymentType;
            this.layoutControlItem23.CustomizationFormText = "Payment Type:";
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(82, 17);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(202, 20);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.Text = "Payment:";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(54, 13);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem11.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem11.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem11.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem11.Control = this.lblInstitutionType;
            this.layoutControlItem11.CustomizationFormText = "Type:";
            this.layoutControlItem11.Location = new System.Drawing.Point(405, 20);
            this.layoutControlItem11.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(386, 20);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.Text = "Inst. Type:";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem13.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem13.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem13.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem13.Control = this.lblRefNo;
            this.layoutControlItem13.CustomizationFormText = "Ref. No:";
            this.layoutControlItem13.Location = new System.Drawing.Point(202, 20);
            this.layoutControlItem13.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem13.MinSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(203, 20);
            this.layoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem13.Text = "Ref. No:";
            this.layoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(42, 13);
            this.layoutControlItem13.TextToControlDistance = 25;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem24,
            this.layoutControlItem14});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 93);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup2.Size = new System.Drawing.Size(204, 54);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem24.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem24.Control = this.lblissuedDate;
            this.layoutControlItem24.CustomizationFormText = "Issued Date:";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem24.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem24.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(190, 20);
            this.layoutControlItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem24.Text = "Requested Date:";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(94, 13);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem14.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem14.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem14.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem14.Control = this.lblIssuedBy;
            this.layoutControlItem14.CustomizationFormText = "Issued By:";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem14.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(190, 20);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = "Requested By:";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(81, 13);
            this.layoutControlItem14.TextToControlDistance = 18;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem16,
            this.layoutControlItem30});
            this.layoutControlGroup3.Location = new System.Drawing.Point(204, 93);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup3.Size = new System.Drawing.Size(202, 54);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem16.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem16.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem16.Control = this.lblApprovedBy;
            this.layoutControlItem16.CustomizationFormText = "Approved By:";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(86, 20);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(188, 20);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Text = "Approved By:";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(75, 13);
            this.layoutControlItem16.TextToControlDistance = 18;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem30.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem30.Control = this.lblAppDate;
            this.layoutControlItem30.CustomizationFormText = "Approved Date:";
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem30.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(188, 20);
            this.layoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem30.Text = "Approved Date:";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(88, 13);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem31,
            this.layoutControlItem32});
            this.layoutControlGroup4.Location = new System.Drawing.Point(406, 93);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup4.Size = new System.Drawing.Size(201, 54);
            this.layoutControlGroup4.Text = "layoutControlGroup4";
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem31.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem31.Control = this.lblPicklistConfirmedBy;
            this.layoutControlItem31.CustomizationFormText = "Picklist Confirmed By:";
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem31.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem31.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(187, 20);
            this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem31.Text = "Picklisted By:";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(74, 13);
            this.layoutControlItem31.TextToControlDistance = 18;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem32.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem32.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem32.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem32.Control = this.lblPicklistPrintedDate;
            this.layoutControlItem32.CustomizationFormText = "Picklisted Date:";
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem32.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(187, 20);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.Text = "Picklisted Date:";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(87, 13);
            this.layoutControlItem32.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem28,
            this.layoutControlItem29});
            this.layoutControlGroup1.Location = new System.Drawing.Point(607, 93);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup1.Size = new System.Drawing.Size(198, 54);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem28.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem28.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem28.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem28.Control = this.lblIssueTypes;
            this.layoutControlItem28.CustomizationFormText = "Issue Type:";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem28.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem28.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(184, 20);
            this.layoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem28.Text = "Type:";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(31, 13);
            this.layoutControlItem28.TextToControlDistance = 14;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem29.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem29.Control = this.lblIssueStatus;
            this.layoutControlItem29.CustomizationFormText = "Issue Status:";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(184, 20);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "Status:";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(40, 13);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlGroup13
            // 
            this.layoutControlGroup13.CustomizationFormText = "Pick List Confirmation";
            this.layoutControlGroup13.GroupBordersVisible = false;
            this.layoutControlGroup13.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem19,
            this.layoutControlItem4});
            this.layoutControlGroup13.Location = new System.Drawing.Point(314, 147);
            this.layoutControlGroup13.Name = "layoutControlGroup13";
            this.layoutControlGroup13.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup13.Size = new System.Drawing.Size(805, 398);
            this.layoutControlGroup13.Text = "Pick List Confirmation";
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.gridOutstandingPicklistDetail;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(805, 375);
            this.layoutControlItem19.Text = "layoutControlItem19";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextToControlDistance = 0;
            this.layoutControlItem19.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chkIncludeInsurance;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(805, 23);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.Control = this.btnCancelIssue;
            this.layoutControlItem42.CustomizationFormText = "layoutControlItem42";
            this.layoutControlItem42.Location = new System.Drawing.Point(973, 545);
            this.layoutControlItem42.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem42.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem42.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem42.Text = "layoutControlItem42";
            this.layoutControlItem42.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem42.TextToControlDistance = 0;
            this.layoutControlItem42.TextVisible = false;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.Control = this.btnConfirmIssue1;
            this.layoutControlItem43.CustomizationFormText = "layoutControlItem43";
            this.layoutControlItem43.Location = new System.Drawing.Point(827, 545);
            this.layoutControlItem43.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem43.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem43.Name = "layoutControlItem43";
            this.layoutControlItem43.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem43.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem43.Text = "layoutControlItem43";
            this.layoutControlItem43.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem43.TextToControlDistance = 0;
            this.layoutControlItem43.TextVisible = false;
            // 
            // layoutSupplimentaryOrder
            // 
            this.layoutSupplimentaryOrder.Control = this.simpleButton1;
            this.layoutSupplimentaryOrder.CustomizationFormText = "layoutSupplimentaryOrder";
            this.layoutSupplimentaryOrder.Location = new System.Drawing.Point(535, 545);
            this.layoutSupplimentaryOrder.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutSupplimentaryOrder.MinSize = new System.Drawing.Size(146, 26);
            this.layoutSupplimentaryOrder.Name = "layoutSupplimentaryOrder";
            this.layoutSupplimentaryOrder.Size = new System.Drawing.Size(146, 26);
            this.layoutSupplimentaryOrder.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutSupplimentaryOrder.Text = "layoutSupplimentaryOrder";
            this.layoutSupplimentaryOrder.TextSize = new System.Drawing.Size(0, 0);
            this.layoutSupplimentaryOrder.TextToControlDistance = 0;
            this.layoutSupplimentaryOrder.TextVisible = false;
            this.layoutSupplimentaryOrder.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // lcOutstandingPicklists
            // 
            this.lcOutstandingPicklists.CustomizationFormText = "Outstanding Pick Lists";
            this.lcOutstandingPicklists.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem50,
            this.layoutControlGroup5,
            this.emptySpaceItem1});
            this.lcOutstandingPicklists.Location = new System.Drawing.Point(0, 0);
            this.lcOutstandingPicklists.Name = "lcOutstandingPicklists";
            this.lcOutstandingPicklists.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcOutstandingPicklists.Size = new System.Drawing.Size(306, 571);
            this.lcOutstandingPicklists.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcOutstandingPicklists.Text = "Outstanding Pick Lists";
            this.lcOutstandingPicklists.TextLocation = DevExpress.Utils.Locations.Left;
            this.lcOutstandingPicklists.TextVisible = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.Control = this.gridOutstandingPickLists;
            this.layoutControlItem50.CustomizationFormText = "layoutControlItem50";
            this.layoutControlItem50.Location = new System.Drawing.Point(0, 93);
            this.layoutControlItem50.MaxSize = new System.Drawing.Size(304, 0);
            this.layoutControlItem50.MinSize = new System.Drawing.Size(304, 24);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(304, 452);
            this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem50.Text = "layoutControlItem50";
            this.layoutControlItem50.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem50.TextToControlDistance = 0;
            this.layoutControlItem50.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "Filter";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem5});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(304, 93);
            this.layoutControlGroup5.Text = "Filter";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtFacilityNameFilter;
            this.layoutControlItem2.ControlAlignment = System.Drawing.ContentAlignment.BottomLeft;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(300, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(236, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(280, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Filter:";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(28, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkMode;
            this.layoutControlItem5.CustomizationFormText = "Mode";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(85, 20);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(280, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Mode:";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem5.TextToControlDistance = 3;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 545);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(0, 24);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(304, 24);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnReturnToApprovalStep;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(681, 545);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(314, 545);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 26);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(221, 26);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(306, 0);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(8, 0);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(8, 10);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(8, 571);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
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
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 575);
            this.Controls.Add(this.layoutControl3);
            this.Name = "InvoiceForm";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.boxSizedList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeInsurance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFacilityNameFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutstandingPickLists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutstandingPickListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmOrderNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmApprovedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmFromStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmRequestedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssueRefNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOutstandingPicklistDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewConfirmation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIssuedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPaymentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSupplimentaryOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcOutstandingPicklists)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
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
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraGrid.GridControl gridOutstandingPicklistDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewConfirmation;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn colSKUPicked;
        private DevExpress.XtraGrid.Columns.GridColumn colBUPicked;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
        private DevExpress.XtraGrid.GridControl gridOutstandingPickLists;
        private DevExpress.XtraGrid.Views.Grid.GridView gridOutstandingPickListView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn49;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private CalendarLib.DateTimePickerEx dtIssuedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
        private DevExpress.XtraEditors.MemoEdit txtRemarks;
        private DevExpress.XtraEditors.TextEdit txtIssuedBy;
        private DevExpress.XtraEditors.TextEdit txtIssueRefNo;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraEditors.TextEdit txtConfirmRequestedBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraEditors.TextEdit txtConfirmFromStore;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem15;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup10;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraEditors.TextEdit txtConfirmApprovedBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit boxSizedList;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraEditors.TextEdit txtConfirmOrderNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem22;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem23;
        private DevExpress.XtraEditors.SimpleButton btnConfirmIssue1;
        private DevExpress.XtraEditors.SimpleButton btnCancelIssue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutSupplimentaryOrder;
        private DevExpress.XtraPrinting.PrintableComponentLink printOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn60;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn76;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private TextEdit txtFacilityNameFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private SimpleButton btnReturnToApprovalStep;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private CheckEdit chkIncludeInsurance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private LookUpEdit lkMode;
        private LookUpEdit lkPaymentType;
        private LabelControl lblRegion;
        private LabelControl lblZone;
        private LabelControl lblWoreda;
        private LabelControl lblOwnership;
        private LabelControl lblMode;
        private DevExpress.XtraLayout.LayoutControlGroup HeaderSection;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private LabelControl lblApprovedDate;
        private LabelControl lblInstitutionType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private LabelControl lblRefNo;
        private LabelControl lblIssuedBy;
        private LabelControl lblApprovedBy;
        private LabelControl lblPaymentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlGroup lcOutstandingPicklists;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private LabelControl lblissuedDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private LabelControl lblIssueTypes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private LabelControl lblIssueStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private LabelControl lblAppDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private LabelControl lblPicklistPrintedDate;
        private LabelControl lblPicklistConfirmedBy;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
    }
}