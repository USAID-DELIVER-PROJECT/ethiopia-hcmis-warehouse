using DevExpress.XtraEditors;
namespace HCMIS.Desktop
{
    partial class YearEndProcess
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YearEndProcess));
            this.colExpInven = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColIsDraft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoLkPalletLocation = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColPhysicalStoreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColStorageType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColShelfCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPalletLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDamagedPalletLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoDamagedPalletLocation = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColStore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColStorageTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColShelfCodes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDamagedQtyPalletlocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCommit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRowCommit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.chkShowLocations = new DevExpress.XtraEditors.CheckEdit();
            this.ckInventoryStockedOut = new DevExpress.XtraEditors.CheckEdit();
            this.btnInventoryAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDraftPrintout = new DevExpress.XtraEditors.SimpleButton();
            this.btnFinalPrintout = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOutstandingTransactions = new DevExpress.XtraEditors.SimpleButton();
            this.btnCommit = new DevExpress.XtraEditors.SimpleButton();
            this.lkPeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.btnLoadInventory = new DevExpress.XtraEditors.SimpleButton();
            this.lkInventoryAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkInventoryStore = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.gridManageInventory = new DevExpress.XtraGrid.GridControl();
            this.gridManageInvetoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPhysicalStore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastInventory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnStartInventory = new DevExpress.XtraEditors.SimpleButton();
            this.dtEndInventory = new CalendarLib.DateTimePickerEx();
            this.dtStartInventory = new CalendarLib.DateTimePickerEx();
            this.chkIncludeBatchExpiry = new DevExpress.XtraEditors.CheckEdit();
            this.btnPrintCountSheet = new DevExpress.XtraEditors.SimpleButton();
            this.chkIncludeStockedOut = new DevExpress.XtraEditors.CheckEdit();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.pcPrintout = new DevExpress.XtraPrinting.Control.PrintControl();
            this.btnSaveDraft = new DevExpress.XtraEditors.SimpleButton();
            this.lkAccountType = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn96 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn97 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn98 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLocationRelatedInventory = new DevExpress.XtraGrid.GridControl();
            this.gridLocationRelatedInventoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDamagedQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewDamagedQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRowSave = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkPhysicalStore = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ParentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.lcLocationInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.xpButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.StockCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dxRequiredValidation = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.InventoryBgWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarDetail = new DevExpress.XtraEditors.ProgressBarControl();
            this.startbgWorker = new System.ComponentModel.BackgroundWorker();
            this.InitiateInventoryProgressPanel = new DevExpress.XtraEditors.GroupControl();
            this.labelTotalActivity = new DevExpress.XtraEditors.LabelControl();
            this.labelActivity = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescription = new DevExpress.XtraEditors.LabelControl();
            this.progressBarActivities = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.repoLkPalletLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDamagedPalletLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowCommit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowLocations.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckInventoryStockedOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkInventoryAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkInventoryStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageInvetoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeBatchExpiry.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeStockedOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccountType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocationRelatedInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocationRelatedInventoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPhysicalStore.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcLocationInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxRequiredValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarDetail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitiateInventoryProgressPanel)).BeginInit();
            this.InitiateInventoryProgressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarActivities.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colExpInven
            // 
            this.colExpInven.Caption = "isExpiredAfterInventory";
            this.colExpInven.FieldName = "isExpiredAfterInventory";
            this.colExpInven.Name = "colExpInven";
            // 
            // ColIsDraft
            // 
            this.ColIsDraft.Caption = "isDraft";
            this.ColIsDraft.FieldName = "IsDraft";
            this.ColIsDraft.Name = "ColIsDraft";
            this.ColIsDraft.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Normal PalletLocation";
            this.gridColumn5.ColumnEdit = this.repoLkPalletLocation;
            this.gridColumn5.FieldName = "PalletLocationID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 13;
            this.gridColumn5.Width = 119;
            // 
            // repoLkPalletLocation
            // 
            this.repoLkPalletLocation.AutoHeight = false;
            this.repoLkPalletLocation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoLkPalletLocation.DisplayMember = "PalletLocationName";
            this.repoLkPalletLocation.Name = "repoLkPalletLocation";
            this.repoLkPalletLocation.NullText = "Select PalletLocation";
            this.repoLkPalletLocation.ValueMember = "PalletLocationID";
            this.repoLkPalletLocation.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColPhysicalStoreName,
            this.ColStorageType,
            this.ColShelfCode,
            this.colPalletLocation});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.GroupCount = 3;
            this.repositoryItemGridLookUpEdit1View.GroupFormat = "{0} [#image]{1} {2}";
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.repositoryItemGridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColPhysicalStoreName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColStorageType, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColShelfCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ColPhysicalStoreName
            // 
            this.ColPhysicalStoreName.Caption = "Store : ";
            this.ColPhysicalStoreName.FieldName = "PhysicalStoreName";
            this.ColPhysicalStoreName.Name = "ColPhysicalStoreName";
            this.ColPhysicalStoreName.Visible = true;
            this.ColPhysicalStoreName.VisibleIndex = 2;
            // 
            // ColStorageType
            // 
            this.ColStorageType.Caption = " ";
            this.ColStorageType.FieldName = "StorageTypeName";
            this.ColStorageType.Name = "ColStorageType";
            this.ColStorageType.Visible = true;
            this.ColStorageType.VisibleIndex = 2;
            // 
            // ColShelfCode
            // 
            this.ColShelfCode.Caption = " ";
            this.ColShelfCode.FieldName = "ShelfCode";
            this.ColShelfCode.Name = "ColShelfCode";
            this.ColShelfCode.Visible = true;
            this.ColShelfCode.VisibleIndex = 1;
            // 
            // colPalletLocation
            // 
            this.colPalletLocation.FieldName = "PalletLocationName";
            this.colPalletLocation.Name = "colPalletLocation";
            this.colPalletLocation.Visible = true;
            this.colPalletLocation.VisibleIndex = 0;
            this.colPalletLocation.Width = 83;
            // 
            // ColDamagedPalletLocation
            // 
            this.ColDamagedPalletLocation.Caption = "Damaged PalletLocation";
            this.ColDamagedPalletLocation.ColumnEdit = this.repoDamagedPalletLocation;
            this.ColDamagedPalletLocation.FieldName = "DamagedPalletLocationID";
            this.ColDamagedPalletLocation.Name = "ColDamagedPalletLocation";
            this.ColDamagedPalletLocation.OptionsColumn.AllowIncrementalSearch = false;
            this.ColDamagedPalletLocation.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.ColDamagedPalletLocation.Visible = true;
            this.ColDamagedPalletLocation.VisibleIndex = 14;
            this.ColDamagedPalletLocation.Width = 105;
            // 
            // repoDamagedPalletLocation
            // 
            this.repoDamagedPalletLocation.AutoHeight = false;
            this.repoDamagedPalletLocation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoDamagedPalletLocation.DisplayMember = "PalletLocationName";
            this.repoDamagedPalletLocation.Name = "repoDamagedPalletLocation";
            this.repoDamagedPalletLocation.NullText = "Select PalletLocation";
            this.repoDamagedPalletLocation.ValueMember = "PalletLocationID";
            this.repoDamagedPalletLocation.View = this.gridView3;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColStore,
            this.ColStorageTypeName,
            this.ColShelfCodes,
            this.colDamagedQtyPalletlocation});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.GroupCount = 3;
            this.gridView3.GroupFormat = "{0} [#image]{1} {2}";
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColStore, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColStorageTypeName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ColShelfCodes, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ColStore
            // 
            this.ColStore.Caption = "Store";
            this.ColStore.FieldName = "PhysicalStoreName";
            this.ColStore.Name = "ColStore";
            this.ColStore.Visible = true;
            this.ColStore.VisibleIndex = 1;
            // 
            // ColStorageTypeName
            // 
            this.ColStorageTypeName.Caption = " ";
            this.ColStorageTypeName.FieldName = "StorageTypeName";
            this.ColStorageTypeName.Name = "ColStorageTypeName";
            this.ColStorageTypeName.Visible = true;
            this.ColStorageTypeName.VisibleIndex = 1;
            // 
            // ColShelfCodes
            // 
            this.ColShelfCodes.Caption = " ";
            this.ColShelfCodes.FieldName = "ShelfCode";
            this.ColShelfCodes.Name = "ColShelfCodes";
            this.ColShelfCodes.Visible = true;
            this.ColShelfCodes.VisibleIndex = 1;
            // 
            // colDamagedQtyPalletlocation
            // 
            this.colDamagedQtyPalletlocation.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colDamagedQtyPalletlocation.AppearanceCell.Options.UseBackColor = true;
            this.colDamagedQtyPalletlocation.FieldName = "PalletLocationName";
            this.colDamagedQtyPalletlocation.Name = "colDamagedQtyPalletlocation";
            this.colDamagedQtyPalletlocation.Visible = true;
            this.colDamagedQtyPalletlocation.VisibleIndex = 0;
            this.colDamagedQtyPalletlocation.Width = 83;
            // 
            // colCommit
            // 
            this.colCommit.Caption = "Commit";
            this.colCommit.ColumnEdit = this.btnRowCommit;
            this.colCommit.Name = "colCommit";
            this.colCommit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCommit.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colCommit.Visible = true;
            this.colCommit.VisibleIndex = 17;
            this.colCommit.Width = 43;
            // 
            // btnRowCommit
            // 
            this.btnRowCommit.AutoHeight = false;
            this.btnRowCommit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Commit", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleLeft, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnRowCommit.HideSelection = false;
            this.btnRowCommit.Name = "btnRowCommit";
            this.btnRowCommit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnRowCommit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRowCommit_ButtonClick);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lookUpEdit1);
            this.layoutControl1.Controls.Add(this.chkShowLocations);
            this.layoutControl1.Controls.Add(this.ckInventoryStockedOut);
            this.layoutControl1.Controls.Add(this.btnInventoryAdd);
            this.layoutControl1.Controls.Add(this.btnDraftPrintout);
            this.layoutControl1.Controls.Add(this.btnFinalPrintout);
            this.layoutControl1.Controls.Add(this.BtnOutstandingTransactions);
            this.layoutControl1.Controls.Add(this.btnCommit);
            this.layoutControl1.Controls.Add(this.lkPeriod);
            this.layoutControl1.Controls.Add(this.btnLoadInventory);
            this.layoutControl1.Controls.Add(this.lkInventoryAccount);
            this.layoutControl1.Controls.Add(this.lkInventoryStore);
            this.layoutControl1.Controls.Add(this.memoEdit1);
            this.layoutControl1.Controls.Add(this.gridManageInventory);
            this.layoutControl1.Controls.Add(this.btnStartInventory);
            this.layoutControl1.Controls.Add(this.dtEndInventory);
            this.layoutControl1.Controls.Add(this.dtStartInventory);
            this.layoutControl1.Controls.Add(this.chkIncludeBatchExpiry);
            this.layoutControl1.Controls.Add(this.btnPrintCountSheet);
            this.layoutControl1.Controls.Add(this.chkIncludeStockedOut);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.pcPrintout);
            this.layoutControl1.Controls.Add(this.btnSaveDraft);
            this.layoutControl1.Controls.Add(this.lkAccountType);
            this.layoutControl1.Controls.Add(this.gridLocationRelatedInventory);
            this.layoutControl1.Controls.Add(this.lkPhysicalStore);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem14,
            this.layoutControlGroup8});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(346, 279, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1151, 575);
            this.layoutControl1.TabIndex = 30;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(150, 80);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(134, 20);
            this.lookUpEdit1.StyleController = this.layoutControl1;
            this.lookUpEdit1.TabIndex = 80;
            // 
            // chkShowLocations
            // 
            this.chkShowLocations.Enabled = false;
            this.chkShowLocations.Location = new System.Drawing.Point(362, 70);
            this.chkShowLocations.Name = "chkShowLocations";
            this.chkShowLocations.Properties.Caption = "Show Locations";
            this.chkShowLocations.Size = new System.Drawing.Size(153, 19);
            this.chkShowLocations.StyleController = this.layoutControl1;
            this.chkShowLocations.TabIndex = 99;
            // 
            // ckInventoryStockedOut
            // 
            this.ckInventoryStockedOut.Location = new System.Drawing.Point(36, 103);
            this.ckInventoryStockedOut.Name = "ckInventoryStockedOut";
            this.ckInventoryStockedOut.Properties.Caption = "Show Stockout";
            this.ckInventoryStockedOut.Size = new System.Drawing.Size(258, 19);
            this.ckInventoryStockedOut.StyleController = this.layoutControl1;
            this.ckInventoryStockedOut.TabIndex = 95;
            this.ckInventoryStockedOut.CheckedChanged += new System.EventHandler(this.ckInventoryStockedOut_CheckedChanged);
            // 
            // btnInventoryAdd
            // 
            this.btnInventoryAdd.Location = new System.Drawing.Point(964, 103);
            this.btnInventoryAdd.Name = "btnInventoryAdd";
            this.btnInventoryAdd.Size = new System.Drawing.Size(151, 22);
            this.btnInventoryAdd.StyleController = this.layoutControl1;
            this.btnInventoryAdd.TabIndex = 94;
            this.btnInventoryAdd.Text = "Add New Inventory Line";
            this.btnInventoryAdd.Click += new System.EventHandler(this.btnInventoryAdd_Click);
            // 
            // btnDraftPrintout
            // 
            this.btnDraftPrintout.Location = new System.Drawing.Point(731, 529);
            this.btnDraftPrintout.Name = "btnDraftPrintout";
            this.btnDraftPrintout.Size = new System.Drawing.Size(96, 22);
            this.btnDraftPrintout.StyleController = this.layoutControl1;
            this.btnDraftPrintout.TabIndex = 93;
            this.btnDraftPrintout.Text = "Draft Printout";
            this.btnDraftPrintout.Click += new System.EventHandler(this.btnDraftPrintout_Click);
            // 
            // btnFinalPrintout
            // 
            this.btnFinalPrintout.Location = new System.Drawing.Point(1031, 529);
            this.btnFinalPrintout.Name = "btnFinalPrintout";
            this.btnFinalPrintout.Size = new System.Drawing.Size(96, 22);
            this.btnFinalPrintout.StyleController = this.layoutControl1;
            this.btnFinalPrintout.TabIndex = 92;
            this.btnFinalPrintout.Text = "Final Printout";
            this.btnFinalPrintout.Click += new System.EventHandler(this.btnFinalPrintout_Click);
            // 
            // BtnOutstandingTransactions
            // 
            this.BtnOutstandingTransactions.Location = new System.Drawing.Point(788, 206);
            this.BtnOutstandingTransactions.Name = "BtnOutstandingTransactions";
            this.BtnOutstandingTransactions.Size = new System.Drawing.Size(187, 22);
            this.BtnOutstandingTransactions.StyleController = this.layoutControl1;
            this.BtnOutstandingTransactions.TabIndex = 91;
            this.BtnOutstandingTransactions.Text = "Show Outstanding Transactions";
            this.BtnOutstandingTransactions.Click += new System.EventHandler(this.BtnOutstandingTransactions_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(931, 529);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(96, 22);
            this.btnCommit.StyleController = this.layoutControl1;
            this.btnCommit.TabIndex = 89;
            this.btnCommit.Text = "Commit";
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // lkPeriod
            // 
            this.lkPeriod.Location = new System.Drawing.Point(520, 77);
            this.lkPeriod.Name = "lkPeriod";
            this.lkPeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkPeriod.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StartDate", "StartDate", 20, DevExpress.Utils.FormatType.DateTime, "dd/MM/yyyy", true, DevExpress.Utils.HorzAlignment.Default)});
            this.lkPeriod.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.lkPeriod.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.lkPeriod.Properties.DisplayMember = "StartDate";
            this.lkPeriod.Properties.NullText = "Period";
            this.lkPeriod.Properties.ValueMember = "ID";
            this.lkPeriod.Size = new System.Drawing.Size(154, 20);
            this.lkPeriod.StyleController = this.layoutControl1;
            this.lkPeriod.TabIndex = 88;
            this.lkPeriod.EditValueChanged += new System.EventHandler(this.btnLoadInventory_Click);
            // 
            // btnLoadInventory
            // 
            this.btnLoadInventory.Location = new System.Drawing.Point(678, 77);
            this.btnLoadInventory.Name = "btnLoadInventory";
            this.btnLoadInventory.Size = new System.Drawing.Size(122, 22);
            this.btnLoadInventory.StyleController = this.layoutControl1;
            this.btnLoadInventory.TabIndex = 87;
            this.btnLoadInventory.Text = "Load";
            this.btnLoadInventory.Click += new System.EventHandler(this.btnLoadInventory_Click);
            // 
            // lkInventoryAccount
            // 
            this.lkInventoryAccount.EditValue = "Select Activity";
            this.lkInventoryAccount.Location = new System.Drawing.Point(312, 77);
            this.lkInventoryAccount.Name = "lkInventoryAccount";
            this.lkInventoryAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkInventoryAccount.Properties.DisplayMember = "Name";
            this.lkInventoryAccount.Properties.NullText = "Select Activity";
            this.lkInventoryAccount.Properties.ValueMember = "ID";
            this.lkInventoryAccount.Properties.View = this.gridView1;
            this.lkInventoryAccount.Size = new System.Drawing.Size(134, 20);
            this.lkInventoryAccount.StyleController = this.layoutControl1;
            this.lkInventoryAccount.TabIndex = 86;
            this.lkInventoryAccount.EditValueChanged += new System.EventHandler(this.lkInventoryAccount_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn27,
            this.gridColumn33,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GroupCount = 3;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn36, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn37, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn33, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "ID";
            this.gridColumn27.FieldName = "ID";
            this.gridColumn27.Name = "gridColumn27";
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Sub Account";
            this.gridColumn33.FieldName = "StoreGroupDivision";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 0;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Mode";
            this.gridColumn36.FieldName = "StoreType";
            this.gridColumn36.Name = "gridColumn36";
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Account";
            this.gridColumn37.FieldName = "StoreGroup";
            this.gridColumn37.Name = "gridColumn37";
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "SSA";
            this.gridColumn38.FieldName = "Name";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 0;
            this.gridColumn38.Width = 83;
            // 
            // lkInventoryStore
            // 
            this.lkInventoryStore.EditValue = "";
            this.lkInventoryStore.Location = new System.Drawing.Point(106, 77);
            this.lkInventoryStore.Name = "lkInventoryStore";
            this.lkInventoryStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkInventoryStore.Properties.DisplayMember = "Name";
            this.lkInventoryStore.Properties.NullText = "Select Store";
            this.lkInventoryStore.Properties.ValueMember = "ID";
            this.lkInventoryStore.Properties.View = this.gridView4;
            this.lkInventoryStore.Size = new System.Drawing.Size(132, 20);
            this.lkInventoryStore.StyleController = this.layoutControl1;
            this.lkInventoryStore.TabIndex = 85;
            this.lkInventoryStore.EditValueChanged += new System.EventHandler(this.lkInventoryAccount_EditValueChanged);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.GroupCount = 2;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn41, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn42, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "ID";
            this.gridColumn39.FieldName = "ID";
            this.gridColumn39.Name = "gridColumn39";
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "Name";
            this.gridColumn40.FieldName = "Name";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 0;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "Cluster";
            this.gridColumn41.FieldName = "Cluster";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 1;
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "Warehouse";
            this.gridColumn42.FieldName = "Warehouse";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 1;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(732, 129);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(383, 73);
            this.memoEdit1.StyleController = this.layoutControl1;
            this.memoEdit1.TabIndex = 84;
            // 
            // gridManageInventory
            // 
            this.gridManageInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridManageInventory.Location = new System.Drawing.Point(24, 46);
            this.gridManageInventory.MainView = this.gridManageInvetoryView;
            this.gridManageInventory.Name = "gridManageInventory";
            this.gridManageInventory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit2});
            this.gridManageInventory.Size = new System.Drawing.Size(639, 505);
            this.gridManageInventory.TabIndex = 82;
            this.gridManageInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridManageInvetoryView});
            // 
            // gridManageInvetoryView
            // 
            this.gridManageInvetoryView.Appearance.FocusedCell.BackColor = System.Drawing.Color.Silver;
            this.gridManageInvetoryView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridManageInvetoryView.Appearance.FocusedRow.BackColor = System.Drawing.Color.Silver;
            this.gridManageInvetoryView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridManageInvetoryView.Appearance.SelectedRow.BackColor = System.Drawing.Color.Silver;
            this.gridManageInvetoryView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridManageInvetoryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhysicalStore,
            this.colLastInventory,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn22});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = true;
            this.gridManageInvetoryView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridManageInvetoryView.GridControl = this.gridManageInventory;
            this.gridManageInvetoryView.Name = "gridManageInvetoryView";
            this.gridManageInvetoryView.OptionsView.AllowCellMerge = true;
            this.gridManageInvetoryView.OptionsView.ShowGroupPanel = false;
            this.gridManageInvetoryView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridManageInvetoryView_FocusedRowChanged);
            // 
            // colPhysicalStore
            // 
            this.colPhysicalStore.Caption = "Warehouse";
            this.colPhysicalStore.FieldName = "Warehouse";
            this.colPhysicalStore.Name = "colPhysicalStore";
            this.colPhysicalStore.OptionsColumn.AllowEdit = false;
            this.colPhysicalStore.Visible = true;
            this.colPhysicalStore.VisibleIndex = 0;
            // 
            // colLastInventory
            // 
            this.colLastInventory.Caption = "PhysicalStore";
            this.colLastInventory.FieldName = "PhysicalStoreName";
            this.colLastInventory.Name = "colLastInventory";
            this.colLastInventory.OptionsColumn.AllowEdit = false;
            this.colLastInventory.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colLastInventory.OptionsColumn.ReadOnly = true;
            this.colLastInventory.Visible = true;
            this.colLastInventory.VisibleIndex = 1;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Last Inventory Date";
            this.gridColumn34.FieldName = "CurrentPeriodStartDate";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsColumn.ReadOnly = true;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 2;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "New Inventory Start Date";
            this.gridColumn35.FieldName = "StartDate";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn35.OptionsColumn.ReadOnly = true;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 3;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "New Status";
            this.gridColumn22.FieldName = "InventoryStatusID";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 4;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.AutoHeight = false;
            this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit2.DisplayMember = "Label";
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.NullText = "";
            this.repositoryItemGridLookUpEdit2.ValueMember = "ID";
            this.repositoryItemGridLookUpEdit2.View = this.gridView2;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // btnStartInventory
            // 
            this.btnStartInventory.Location = new System.Drawing.Point(979, 206);
            this.btnStartInventory.Name = "btnStartInventory";
            this.btnStartInventory.Size = new System.Drawing.Size(136, 22);
            this.btnStartInventory.StyleController = this.layoutControl1;
            this.btnStartInventory.TabIndex = 81;
            this.btnStartInventory.Text = "Start Inventory Period";
            this.btnStartInventory.Click += new System.EventHandler(this.btnStartInventory_Click);
            // 
            // dtEndInventory
            // 
            this.dtEndInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEndInventory.CalendarFont = new System.Drawing.Font("Nyala", 12F);
            this.dtEndInventory.CalendarForeColor = System.Drawing.Color.Black;
            this.dtEndInventory.DayOfWeekCharacters = 1;
            this.dtEndInventory.ForeColor = System.Drawing.Color.Black;
            this.dtEndInventory.Location = new System.Drawing.Point(732, 103);
            this.dtEndInventory.Name = "dtEndInventory";
            this.dtEndInventory.PopUpFontSize = 10F;
            this.dtEndInventory.Size = new System.Drawing.Size(383, 22);
            this.dtEndInventory.TabIndex = 79;
            this.dtEndInventory.TextSelect = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtEndInventory.Value = new System.DateTime(2013, 4, 7, 0, 0, 0, 0);
            // 
            // dtStartInventory
            // 
            this.dtStartInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartInventory.CalendarFont = new System.Drawing.Font("Nyala", 12F);
            this.dtStartInventory.CalendarForeColor = System.Drawing.Color.Black;
            this.dtStartInventory.DayOfWeekCharacters = 1;
            this.dtStartInventory.ForeColor = System.Drawing.Color.Black;
            this.dtStartInventory.Location = new System.Drawing.Point(732, 77);
            this.dtStartInventory.Name = "dtStartInventory";
            this.dtStartInventory.PopUpFontSize = 10F;
            this.dtStartInventory.Size = new System.Drawing.Size(383, 22);
            this.dtStartInventory.TabIndex = 79;
            this.dtStartInventory.TextSelect = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtStartInventory.Value = new System.DateTime(2013, 4, 7, 0, 0, 0, 0);
            // 
            // chkIncludeBatchExpiry
            // 
            this.chkIncludeBatchExpiry.Location = new System.Drawing.Point(206, 70);
            this.chkIncludeBatchExpiry.Name = "chkIncludeBatchExpiry";
            this.chkIncludeBatchExpiry.Properties.Caption = "Show Batch And Expiry";
            this.chkIncludeBatchExpiry.Size = new System.Drawing.Size(152, 19);
            this.chkIncludeBatchExpiry.StyleController = this.layoutControl1;
            this.chkIncludeBatchExpiry.TabIndex = 78;
            this.chkIncludeBatchExpiry.CheckedChanged += new System.EventHandler(this.chkIncludeBatchExpiry_CheckedChanged);
            // 
            // btnPrintCountSheet
            // 
            this.btnPrintCountSheet.Location = new System.Drawing.Point(649, 46);
            this.btnPrintCountSheet.Name = "btnPrintCountSheet";
            this.btnPrintCountSheet.Size = new System.Drawing.Size(173, 22);
            this.btnPrintCountSheet.StyleController = this.layoutControl1;
            this.btnPrintCountSheet.TabIndex = 78;
            this.btnPrintCountSheet.Text = "Show Empty Count Sheet";
            this.btnPrintCountSheet.Click += new System.EventHandler(this.btnPrintCountSheet_Click);
            // 
            // chkIncludeStockedOut
            // 
            this.chkIncludeStockedOut.Location = new System.Drawing.Point(24, 70);
            this.chkIncludeStockedOut.Name = "chkIncludeStockedOut";
            this.chkIncludeStockedOut.Properties.Caption = "Include Stockedout Batches";
            this.chkIncludeStockedOut.Size = new System.Drawing.Size(178, 19);
            this.chkIncludeStockedOut.StyleController = this.layoutControl1;
            this.chkIncludeStockedOut.TabIndex = 77;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(978, 46);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(149, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 76;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(826, 46);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(148, 22);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 75;
            this.btnRefresh.Text = "Show Report";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pcPrintout
            // 
            this.pcPrintout.BackColor = System.Drawing.Color.Empty;
            this.pcPrintout.ForeColor = System.Drawing.Color.Empty;
            this.pcPrintout.IsMetric = false;
            this.pcPrintout.Location = new System.Drawing.Point(24, 93);
            this.pcPrintout.Name = "pcPrintout";
            this.pcPrintout.Size = new System.Drawing.Size(1103, 458);
            this.pcPrintout.TabIndex = 74;
            this.pcPrintout.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(831, 529);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(96, 22);
            this.btnSaveDraft.StyleController = this.layoutControl1;
            this.btnSaveDraft.TabIndex = 73;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveLocationRelatedInformation_Click);
            // 
            // lkAccountType
            // 
            this.lkAccountType.Location = new System.Drawing.Point(310, 46);
            this.lkAccountType.Name = "lkAccountType";
            this.lkAccountType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccountType.Properties.DisplayMember = "Name";
            this.lkAccountType.Properties.NullText = "Select Account";
            this.lkAccountType.Properties.ValueMember = "ID";
            this.lkAccountType.Properties.View = this.gridView6;
            this.lkAccountType.Size = new System.Drawing.Size(205, 20);
            this.lkAccountType.StyleController = this.layoutControl1;
            this.lkAccountType.TabIndex = 71;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxRequiredValidation.SetValidationRule(this.lkAccountType, conditionValidationRule1);
            // 
            // gridView6
            // 
            this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn31,
            this.gridColumn96,
            this.gridColumn32,
            this.gridColumn97,
            this.gridColumn98});
            this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView6.GroupCount = 3;
            this.gridView6.Name = "gridView6";
            this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView6.OptionsView.ShowGroupPanel = false;
            this.gridView6.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn32, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn97, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn96, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "ID";
            this.gridColumn31.FieldName = "ID";
            this.gridColumn31.Name = "gridColumn31";
            // 
            // gridColumn96
            // 
            this.gridColumn96.Caption = "Sub Account";
            this.gridColumn96.FieldName = "StoreGroupDivision";
            this.gridColumn96.Name = "gridColumn96";
            this.gridColumn96.Visible = true;
            this.gridColumn96.VisibleIndex = 0;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Mode";
            this.gridColumn32.FieldName = "StoreType";
            this.gridColumn32.Name = "gridColumn32";
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
            // gridLocationRelatedInventory
            // 
            this.gridLocationRelatedInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridLocationRelatedInventory.Location = new System.Drawing.Point(24, 141);
            this.gridLocationRelatedInventory.MainView = this.gridLocationRelatedInventoryView;
            this.gridLocationRelatedInventory.Name = "gridLocationRelatedInventory";
            this.gridLocationRelatedInventory.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoLkPalletLocation,
            this.btnRowCommit,
            this.btnRowSave,
            this.repoDamagedPalletLocation});
            this.gridLocationRelatedInventory.Size = new System.Drawing.Size(1103, 384);
            this.gridLocationRelatedInventory.TabIndex = 31;
            this.gridLocationRelatedInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridLocationRelatedInventoryView});
            this.gridLocationRelatedInventory.DoubleClick += new System.EventHandler(this.gridLocationRelatedInventory_DoubleClick);
            // 
            // gridLocationRelatedInventoryView
            // 
            this.gridLocationRelatedInventoryView.BestFitMaxRowCount = 2;
            this.gridLocationRelatedInventoryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn17,
            this.gridColumn4,
            this.gridColumn20,
            this.gridColumn18,
            this.gridColumn21,
            this.gridColumn19,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn1,
            this.gridColumn3,
            this.colDamagedQuantity,
            this.colNewDamagedQuantity,
            this.gridColumn5,
            this.ColDamagedPalletLocation,
            this.gridColumn2,
            this.colSave,
            this.colCommit,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn14,
            this.gridColumn15,
            this.colExpInven,
            this.ColIsDraft});
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Column = this.colExpInven;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = true;
            styleFormatCondition3.Appearance.ForeColor = System.Drawing.Color.DarkGray;
            styleFormatCondition3.Appearance.Options.UseForeColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Column = this.ColIsDraft;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = false;
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.Column = this.gridColumn5;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = "([InventorySoundQuantity] > 0  or [InventoryExpiredQuantity] > 0) And IsNullOrEmp" +
    "ty([PalletLocationID])";
            styleFormatCondition5.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            styleFormatCondition5.Appearance.Options.UseBackColor = true;
            styleFormatCondition5.Column = this.ColDamagedPalletLocation;
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition5.Expression = "[InventoryDamagedQuantity] > 0  And IsNullOrEmpty([DamagedPalletLocationID])";
            this.gridLocationRelatedInventoryView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4,
            styleFormatCondition5});
            this.gridLocationRelatedInventoryView.GridControl = this.gridLocationRelatedInventory;
            this.gridLocationRelatedInventoryView.Name = "gridLocationRelatedInventoryView";
            this.gridLocationRelatedInventoryView.OptionsCustomization.AllowColumnMoving = false;
            this.gridLocationRelatedInventoryView.OptionsMenu.EnableColumnMenu = false;
            this.gridLocationRelatedInventoryView.OptionsView.AllowCellMerge = true;
            this.gridLocationRelatedInventoryView.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.gridLocationRelatedInventoryView.OptionsView.ShowGroupPanel = false;
            this.gridLocationRelatedInventoryView.ShownEditor += new System.EventHandler(this.gridLocationRelatedInventoryView_ShownEditor);
            this.gridLocationRelatedInventoryView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridLocationRelatedInventoryView_CellValueChanged);
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn17.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn17.Caption = "No";
            this.gridColumn17.FieldName = "LineNo";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.FixedWidth = true;
            this.gridColumn17.Width = 30;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Stock Code";
            this.gridColumn4.FieldName = "StockCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 42;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn20.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn20.Caption = "Category";
            this.gridColumn20.FieldName = "Category";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            this.gridColumn20.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            this.gridColumn20.Width = 39;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn18.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn18.Caption = "Item Name";
            this.gridColumn18.FieldName = "FullItemName";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn18.OptionsColumn.FixedWidth = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 250;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn21.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn21.Caption = "Manufacturer";
            this.gridColumn21.FieldName = "ManufacturerName";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 4;
            this.gridColumn21.Width = 62;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn19.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn19.Caption = "Unit";
            this.gridColumn19.FieldName = "Unit";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 3;
            this.gridColumn19.Width = 28;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn23.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn23.Caption = "Expiry Date";
            this.gridColumn23.FieldName = "ExpiryDate";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 5;
            this.gridColumn23.Width = 37;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn24.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn24.Caption = "Batch No.";
            this.gridColumn24.FieldName = "BatchNo";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn24.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 6;
            this.gridColumn24.Width = 41;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn25.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn25.Caption = "Sound Balance";
            this.gridColumn25.DisplayFormat.FormatString = "#,###.##";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "SystemSoundQuantity";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            this.gridColumn25.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn25.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 7;
            this.gridColumn25.Width = 39;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Sound";
            this.gridColumn26.DisplayFormat.FormatString = "#,###.##";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn26.FieldName = "InventorySoundQuantity";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn26.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 10;
            this.gridColumn26.Width = 37;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Expired";
            this.gridColumn1.DisplayFormat.FormatString = "#,###.##";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "InventoryExpiredQuantity";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 12;
            this.gridColumn1.Width = 38;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridColumn3.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn3.Caption = "Expired Quantity";
            this.gridColumn3.DisplayFormat.FormatString = "#,###.##";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "SystemExpiredQuantity";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 46;
            // 
            // colDamagedQuantity
            // 
            this.colDamagedQuantity.AppearanceCell.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colDamagedQuantity.AppearanceCell.Options.UseBackColor = true;
            this.colDamagedQuantity.Caption = "Damaged Quantity";
            this.colDamagedQuantity.DisplayFormat.FormatString = "#,###.##";
            this.colDamagedQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDamagedQuantity.FieldName = "SystemDamagedQuantity";
            this.colDamagedQuantity.Name = "colDamagedQuantity";
            this.colDamagedQuantity.OptionsColumn.AllowEdit = false;
            this.colDamagedQuantity.OptionsColumn.AllowFocus = false;
            this.colDamagedQuantity.OptionsColumn.AllowIncrementalSearch = false;
            this.colDamagedQuantity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDamagedQuantity.Visible = true;
            this.colDamagedQuantity.VisibleIndex = 8;
            this.colDamagedQuantity.Width = 41;
            // 
            // colNewDamagedQuantity
            // 
            this.colNewDamagedQuantity.Caption = "Damaged";
            this.colNewDamagedQuantity.DisplayFormat.FormatString = "#,###.##";
            this.colNewDamagedQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNewDamagedQuantity.FieldName = "InventoryDamagedQuantity";
            this.colNewDamagedQuantity.Name = "colNewDamagedQuantity";
            this.colNewDamagedQuantity.OptionsColumn.AllowIncrementalSearch = false;
            this.colNewDamagedQuantity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colNewDamagedQuantity.Visible = true;
            this.colNewDamagedQuantity.VisibleIndex = 11;
            this.colNewDamagedQuantity.Width = 46;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Remarks";
            this.gridColumn2.FieldName = "Remarks";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 15;
            this.gridColumn2.Width = 35;
            // 
            // colSave
            // 
            this.colSave.Caption = "Save";
            this.colSave.ColumnEdit = this.btnRowSave;
            this.colSave.Name = "colSave";
            this.colSave.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSave.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colSave.Visible = true;
            this.colSave.VisibleIndex = 16;
            this.colSave.Width = 37;
            // 
            // btnRowSave
            // 
            this.btnRowSave.AutoHeight = false;
            this.btnRowSave.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Save Draft", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, false)});
            this.btnRowSave.HideSelection = false;
            this.btnRowSave.Name = "btnRowSave";
            this.btnRowSave.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnRowSave.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnRowSave_ButtonClick);
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "UnitID";
            this.gridColumn28.FieldName = "UnitID";
            this.gridColumn28.Name = "gridColumn28";
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "ID";
            this.gridColumn29.FieldName = "ID";
            this.gridColumn29.Name = "gridColumn29";
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "gridColumn11";
            this.gridColumn30.FieldName = "ItemID";
            this.gridColumn30.Name = "gridColumn30";
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.FieldName = "ReceiveID";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "gridColumn15";
            this.gridColumn15.FieldName = "QtyPerPack";
            this.gridColumn15.Name = "gridColumn15";
            // 
            // lkPhysicalStore
            // 
            this.lkPhysicalStore.EditValue = "";
            this.lkPhysicalStore.Location = new System.Drawing.Point(77, 46);
            this.lkPhysicalStore.Name = "lkPhysicalStore";
            this.lkPhysicalStore.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkPhysicalStore.Properties.DisplayMember = "Name";
            this.lkPhysicalStore.Properties.NullText = "Select Store";
            this.lkPhysicalStore.Properties.ValueMember = "ID";
            this.lkPhysicalStore.Properties.View = this.gridLookUpEdit1View;
            this.lkPhysicalStore.Size = new System.Drawing.Size(176, 20);
            this.lkPhysicalStore.StyleController = this.layoutControl1;
            this.lkPhysicalStore.TabIndex = 49;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxRequiredValidation.SetValidationRule(this.lkPhysicalStore, conditionValidationRule2);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.gridColumn13,
            this.ParentID,
            this.gridColumn12});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.GroupCount = 2;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ParentID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Name";
            this.gridColumn13.FieldName = "Name";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // ParentID
            // 
            this.ParentID.Caption = "Cluster";
            this.ParentID.FieldName = "Cluster";
            this.ParentID.Name = "ParentID";
            this.ParentID.Visible = true;
            this.ParentID.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Warehouse";
            this.gridColumn12.FieldName = "Warehouse";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.lookUpEdit1;
            this.layoutControlItem14.CustomizationFormText = "Previous Inventory";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 10);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(264, 24);
            this.layoutControlItem14.Text = "Previous Inventory";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem14.TextToControlDistance = 5;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.CustomizationFormText = "Shortage/Overage Report";
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Size = new System.Drawing.Size(976, 493);
            this.layoutControlGroup8.Text = "Shortage/Overage Report";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.ShowTabPageCloseButton = true;
            this.layoutControlGroup1.Size = new System.Drawing.Size(1151, 575);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.lcLocationInformation;
            this.tabbedControlGroup1.SelectedTabPageIndex = 2;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(1131, 555);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4,
            this.layoutControlGroup2,
            this.lcLocationInformation});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // lcLocationInformation
            // 
            this.lcLocationInformation.CustomizationFormText = "Location Information";
            this.lcLocationInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlGroup3,
            this.layoutControlItem13,
            this.layoutControlItem24,
            this.emptySpaceItem3,
            this.layoutControlItem7,
            this.layoutControlItem25});
            this.lcLocationInformation.Location = new System.Drawing.Point(0, 0);
            this.lcLocationInformation.Name = "lcLocationInformation";
            this.lcLocationInformation.Size = new System.Drawing.Size(1107, 509);
            this.lcLocationInformation.Text = "Post Inventory: Data Entry";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridLocationRelatedInventory;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 95);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1107, 388);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Status";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem19,
            this.layoutControlItem22,
            this.layoutControlItem23,
            this.emptySpaceItem9,
            this.layoutControlItem21,
            this.layoutControlItem27,
            this.emptySpaceItem2,
            this.layoutControlItem26,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1107, 95);
            this.layoutControlGroup3.Text = " ";
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.lkInventoryAccount;
            this.layoutControlItem19.CustomizationFormText = "Select Activity";
            this.layoutControlItem19.Location = new System.Drawing.Point(206, 0);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(208, 26);
            this.layoutControlItem19.Text = "Activity";
            this.layoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(65, 13);
            this.layoutControlItem19.TextToControlDistance = 5;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.btnLoadInventory;
            this.layoutControlItem22.CustomizationFormText = "layoutControlItem22";
            this.layoutControlItem22.Location = new System.Drawing.Point(642, 0);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(126, 26);
            this.layoutControlItem22.Text = "layoutControlItem22";
            this.layoutControlItem22.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem22.TextToControlDistance = 0;
            this.layoutControlItem22.TextVisible = false;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.Control = this.lkPeriod;
            this.layoutControlItem23.CustomizationFormText = "Period";
            this.layoutControlItem23.Location = new System.Drawing.Point(414, 0);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(228, 26);
            this.layoutControlItem23.Text = "Period";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(65, 13);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem9";
            this.emptySpaceItem9.Location = new System.Drawing.Point(262, 26);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(506, 26);
            this.emptySpaceItem9.Text = "emptySpaceItem9";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.lkInventoryStore;
            this.layoutControlItem21.CustomizationFormText = "Select Physical Store";
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(206, 26);
            this.layoutControlItem21.Text = "Physical Store";
            this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(65, 13);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.Control = this.ckInventoryStockedOut;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(262, 26);
            this.layoutControlItem27.Text = "layoutControlItem27";
            this.layoutControlItem27.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem27.TextToControlDistance = 0;
            this.layoutControlItem27.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(768, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(315, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.btnInventoryAdd;
            this.layoutControlItem26.CustomizationFormText = "layoutControlItem26";
            this.layoutControlItem26.Location = new System.Drawing.Point(928, 26);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(155, 26);
            this.layoutControlItem26.Text = "layoutControlItem26";
            this.layoutControlItem26.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem26.TextToControlDistance = 0;
            this.layoutControlItem26.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(768, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(160, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.btnCommit;
            this.layoutControlItem13.CustomizationFormText = "layoutControlItem13";
            this.layoutControlItem13.Location = new System.Drawing.Point(907, 483);
            this.layoutControlItem13.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem13.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem13.Text = "layoutControlItem13";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextToControlDistance = 0;
            this.layoutControlItem13.TextVisible = false;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.btnFinalPrintout;
            this.layoutControlItem24.CustomizationFormText = "layoutControlItem24";
            this.layoutControlItem24.Location = new System.Drawing.Point(1007, 483);
            this.layoutControlItem24.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem24.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem24.Text = "layoutControlItem24";
            this.layoutControlItem24.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem24.TextToControlDistance = 0;
            this.layoutControlItem24.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 483);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(707, 26);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnSaveDraft;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(807, 483);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.Control = this.btnDraftPrintout;
            this.layoutControlItem25.CustomizationFormText = "layoutControlItem25";
            this.layoutControlItem25.Location = new System.Drawing.Point(707, 483);
            this.layoutControlItem25.MaxSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(100, 26);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(100, 26);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.Text = "layoutControlItem25";
            this.layoutControlItem25.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem25.TextToControlDistance = 0;
            this.layoutControlItem25.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "Manage Inventory";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlGroup5,
            this.layoutControlGroup6});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(1107, 509);
            this.layoutControlGroup4.Text = "Manage Inventory";
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.gridManageInventory;
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(643, 509);
            this.layoutControlItem18.Text = "layoutControlItem18";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextToControlDistance = 0;
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "New Inventory Detail";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem4,
            this.layoutControlItem16,
            this.layoutControlItem17,
            this.layoutControlItem15,
            this.emptySpaceItem5,
            this.layoutControlItem20,
            this.layoutControlItem4});
            this.layoutControlGroup5.Location = new System.Drawing.Point(643, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(464, 236);
            this.layoutControlGroup5.Text = "New Inventory Detail";
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 155);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(440, 38);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.dtStartInventory;
            this.layoutControlItem16.CustomizationFormText = "Start Date";
            this.layoutControlItem16.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(440, 26);
            this.layoutControlItem16.Text = "Start Date";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.dtEndInventory;
            this.layoutControlItem17.CustomizationFormText = "End Date";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(440, 26);
            this.layoutControlItem17.Text = "End Date";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnStartInventory;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(300, 129);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(140, 26);
            this.layoutControlItem15.Text = "layoutControlItem15";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextToControlDistance = 0;
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 129);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(109, 26);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.memoEdit1;
            this.layoutControlItem20.CustomizationFormText = "Remark";
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(440, 77);
            this.layoutControlItem20.Text = "Remark";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.BtnOutstandingTransactions;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(109, 129);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(191, 26);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "History";
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem7});
            this.layoutControlGroup6.Location = new System.Drawing.Point(643, 236);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Size = new System.Drawing.Size(464, 273);
            this.layoutControlGroup6.Text = "History";
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(440, 230);
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Print Inventory Sheet";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.emptySpaceItem6,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlItem6,
            this.layoutControlItem5,
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1107, 509);
            this.layoutControlGroup2.Text = "Pre Inventory: Print Worksheet";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pcPrintout;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 47);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1107, 462);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(495, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(130, 47);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnRefresh;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(802, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(152, 47);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnPrint;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(954, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(153, 47);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.chkIncludeStockedOut;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(182, 23);
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.btnPrintCountSheet;
            this.layoutControlItem11.CustomizationFormText = "layoutControlItem11";
            this.layoutControlItem11.Location = new System.Drawing.Point(625, 0);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(177, 47);
            this.layoutControlItem11.Text = "layoutControlItem11";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextToControlDistance = 0;
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.chkIncludeBatchExpiry;
            this.layoutControlItem12.CustomizationFormText = "layoutControlItem12";
            this.layoutControlItem12.Location = new System.Drawing.Point(182, 24);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(156, 23);
            this.layoutControlItem12.Text = "layoutControlItem12";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextToControlDistance = 0;
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lkAccountType;
            this.layoutControlItem6.CustomizationFormText = "Account";
            this.layoutControlItem6.Location = new System.Drawing.Point(233, 0);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(97, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(262, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Account";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkPhysicalStore;
            this.layoutControlItem5.CustomizationFormText = "Store";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(97, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "Store";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(50, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkShowLocations;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(338, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(157, 23);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // xpButton2
            // 
            this.xpButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xpButton2.Image = ((System.Drawing.Image)(resources.GetObject("xpButton2.Image")));
            this.xpButton2.Location = new System.Drawing.Point(1064, 38);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(75, 23);
            this.xpButton2.TabIndex = 24;
            this.xpButton2.Text = "Export";
            // 
            // xpButton1
            // 
            this.xpButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xpButton1.Image = ((System.Drawing.Image)(resources.GetObject("xpButton1.Image")));
            this.xpButton1.Location = new System.Drawing.Point(1064, 9);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(75, 23);
            this.xpButton1.TabIndex = 23;
            this.xpButton1.Text = "Print";
            // 
            // StockCode
            // 
            this.StockCode.Text = "No";
            this.StockCode.Width = 30;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Item Name";
            this.columnHeader3.Width = 334;
            // 
            // batch
            // 
            this.batch.Text = "Batch No";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Begning Balance";
            this.columnHeader4.Width = 97;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ending Balance (SOH)";
            this.columnHeader5.Width = 128;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Physical Inventory";
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Remark";
            this.columnHeader7.Width = 228;
            // 
            // InventoryBgWorker
            // 
            this.InventoryBgWorker.WorkerReportsProgress = true;
            this.InventoryBgWorker.WorkerSupportsCancellation = true;
            this.InventoryBgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InventorybBgWorker_DoWork);
            this.InventoryBgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.InventorybBgWorker_ProgressChanged);
            this.InventoryBgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InventorybBgWorker_RunWorkerCompleted);
            // 
            // progressBarDetail
            // 
            this.progressBarDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarDetail.Location = new System.Drawing.Point(20, 172);
            this.progressBarDetail.Name = "progressBarDetail";
            this.progressBarDetail.Properties.ShowTitle = true;
            this.progressBarDetail.Size = new System.Drawing.Size(835, 18);
            this.progressBarDetail.StyleController = this.layoutControl1;
            this.progressBarDetail.TabIndex = 97;
            // 
            // startbgWorker
            // 
            this.startbgWorker.WorkerReportsProgress = true;
            this.startbgWorker.WorkerSupportsCancellation = true;
            this.startbgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.startbgWorker_DoWork);
            this.startbgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.startbgWorker_ProgressChanged);
            this.startbgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.startbgWorker_RunWorkerCompleted);
            // 
            // InitiateInventoryProgressPanel
            // 
            this.InitiateInventoryProgressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InitiateInventoryProgressPanel.Controls.Add(this.labelTotalActivity);
            this.InitiateInventoryProgressPanel.Controls.Add(this.labelActivity);
            this.InitiateInventoryProgressPanel.Controls.Add(this.labelControl1);
            this.InitiateInventoryProgressPanel.Controls.Add(this.lblDescription);
            this.InitiateInventoryProgressPanel.Controls.Add(this.progressBarActivities);
            this.InitiateInventoryProgressPanel.Controls.Add(this.progressBarDetail);
            this.InitiateInventoryProgressPanel.Location = new System.Drawing.Point(146, 185);
            this.InitiateInventoryProgressPanel.Name = "InitiateInventoryProgressPanel";
            this.InitiateInventoryProgressPanel.Size = new System.Drawing.Size(884, 219);
            this.InitiateInventoryProgressPanel.TabIndex = 98;
            this.InitiateInventoryProgressPanel.Text = "Initiate Inventory Progress";
            this.InitiateInventoryProgressPanel.Visible = false;
            // 
            // labelTotalActivity
            // 
            this.labelTotalActivity.AllowHtmlString = true;
            this.labelTotalActivity.Location = new System.Drawing.Point(23, 85);
            this.labelTotalActivity.Name = "labelTotalActivity";
            this.labelTotalActivity.Size = new System.Drawing.Size(337, 13);
            this.labelTotalActivity.TabIndex = 102;
            this.labelTotalActivity.Text = "HCMIS is searching this physical store for stock under all {0} activities.";
            // 
            // labelActivity
            // 
            this.labelActivity.Location = new System.Drawing.Point(137, 147);
            this.labelActivity.Name = "labelActivity";
            this.labelActivity.Size = new System.Drawing.Size(113, 13);
            this.labelActivity.TabIndex = 101;
            this.labelActivity.Text = "Processing stock under ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 147);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(113, 13);
            this.labelControl1.TabIndex = 100;
            this.labelControl1.Text = "Processing stock under ";
            // 
            // lblDescription
            // 
            this.lblDescription.AllowHtmlString = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 43);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(531, 13);
            this.lblDescription.TabIndex = 99;
            this.lblDescription.Text = "HCMIS is starting inventory on {0} warehouse. Please do not close this window unt" +
    "il this operation is complete. ";
            // 
            // progressBarActivities
            // 
            this.progressBarActivities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarActivities.Location = new System.Drawing.Point(20, 111);
            this.progressBarActivities.Name = "progressBarActivities";
            this.progressBarActivities.Properties.PercentView = false;
            this.progressBarActivities.Properties.ShowTitle = true;
            this.progressBarActivities.Properties.Step = 1;
            this.progressBarActivities.Size = new System.Drawing.Size(835, 18);
            this.progressBarActivities.StyleController = this.layoutControl1;
            this.progressBarActivities.TabIndex = 98;
            // 
            // YearEndProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 575);
            this.Controls.Add(this.InitiateInventoryProgressPanel);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.xpButton2);
            this.Controls.Add(this.xpButton1);
            this.Name = "YearEndProcess";
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.YearEndProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repoLkPalletLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoDamagedPalletLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowCommit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowLocations.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckInventoryStockedOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkInventoryAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkInventoryStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageInvetoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeBatchExpiry.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncludeStockedOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccountType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocationRelatedInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLocationRelatedInventoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRowSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPhysicalStore.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcLocationInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxRequiredValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarDetail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InitiateInventoryProgressPanel)).EndInit();
            this.InitiateInventoryProgressPanel.ResumeLayout(false);
            this.InitiateInventoryProgressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarActivities.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButton xpButton2;
        private SimpleButton xpButton1;
       
        private System.Windows.Forms.ColumnHeader StockCode;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader batch;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private GridLookUpEdit lkPhysicalStore;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn ParentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraGrid.GridControl gridLocationRelatedInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLocationRelatedInventoryView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private GridLookUpEdit lkAccountType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn96;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn97;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn98;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private SimpleButton btnSaveDraft;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraPrinting.Control.PrintControl pcPrintout;
        private SimpleButton btnPrint;
        private SimpleButton btnRefresh;
        private CheckEdit chkIncludeStockedOut;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxRequiredValidation;
        private SimpleButton btnPrintCountSheet;
        private CheckEdit chkIncludeBatchExpiry;
        private LookUpEdit lookUpEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private SimpleButton btnStartInventory;
        private CalendarLib.DateTimePickerEx dtEndInventory;
        private CalendarLib.DateTimePickerEx dtStartInventory;
        private DevExpress.XtraGrid.GridControl gridManageInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridManageInvetoryView;
        private DevExpress.XtraGrid.Columns.GridColumn colPhysicalStore;
        private DevExpress.XtraGrid.Columns.GridColumn colLastInventory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private MemoEdit memoEdit1;
        private GridLookUpEdit lkInventoryAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private GridLookUpEdit lkInventoryStore;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private SimpleButton btnLoadInventory;
        private LookUpEdit lkPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colDamagedQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colNewDamagedQuantity;
        private SimpleButton btnCommit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.LayoutControlGroup lcLocationInformation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.ComponentModel.BackgroundWorker InventoryBgWorker;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private SimpleButton BtnOutstandingTransactions;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private SimpleButton btnFinalPrintout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private SimpleButton btnDraftPrintout;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private SimpleButton btnInventoryAdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private CheckEdit ckInventoryStockedOut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraGrid.Columns.GridColumn colExpInven;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private ProgressBarControl progressBarDetail;
        private System.ComponentModel.BackgroundWorker startbgWorker;
        private GroupControl InitiateInventoryProgressPanel;
        private ProgressBarControl progressBarActivities;
        private LabelControl lblDescription;
        private LabelControl labelActivity;
        private LabelControl labelControl1;
        private LabelControl labelTotalActivity;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private CheckEdit chkShowLocations;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colCommit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repoLkPalletLocation;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colPalletLocation;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRowCommit;
        private DevExpress.XtraGrid.Columns.GridColumn colSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnRowSave;
        private DevExpress.XtraGrid.Columns.GridColumn ColIsDraft;
        private DevExpress.XtraGrid.Columns.GridColumn ColPhysicalStoreName;
        private DevExpress.XtraGrid.Columns.GridColumn ColStorageType;
        private DevExpress.XtraGrid.Columns.GridColumn ColShelfCode;
        private DevExpress.XtraGrid.Columns.GridColumn ColDamagedPalletLocation;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repoDamagedPalletLocation;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colDamagedQtyPalletlocation;
        private DevExpress.XtraGrid.Columns.GridColumn ColStore;
        private DevExpress.XtraGrid.Columns.GridColumn ColStorageTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn ColShelfCodes;
    }
}