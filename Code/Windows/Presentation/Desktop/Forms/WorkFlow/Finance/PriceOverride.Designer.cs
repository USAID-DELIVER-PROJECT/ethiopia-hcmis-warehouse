namespace HCMIS.Desktop.Forms.WorkFlow.Finance
{
    partial class PriceOverride
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
            this.lkAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ParentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.btnItemPriceHistory = new DevExpress.XtraEditors.SimpleButton();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.lkCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.txtfilter = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridPriceList = new DevExpress.XtraGrid.GridControl();
            this.gridViewPriceList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rpTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colSellingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.layoutMainGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutGridPriceList = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutBtnLoad = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutlkAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpTextEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMainGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGridPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBtnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutlkAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lkAccount
            // 
            this.lkAccount.Location = new System.Drawing.Point(65, 54);
            this.lkAccount.Name = "lkAccount";
            this.lkAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccount.Properties.DisplayMember = "StoreGroup";
            this.lkAccount.Properties.NullText = "Select Account";
            this.lkAccount.Properties.ShowFooter = false;
            this.lkAccount.Properties.ValueMember = "ID";
            this.lkAccount.Properties.View = this.gridLookUpEdit1View;
            this.lkAccount.Size = new System.Drawing.Size(291, 20);
            this.lkAccount.StyleController = this.layoutControl1;
            this.lkAccount.TabIndex = 59;
            this.lkAccount.EditValueChanged += new System.EventHandler(this.lkAccount_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.ParentID,
            this.gridColumn10});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.GroupCount = 1;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ParentID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // ParentID
            // 
            this.ParentID.Caption = "Mode";
            this.ParentID.FieldName = "StoreType";
            this.ParentID.Name = "ParentID";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Account";
            this.gridColumn10.FieldName = "StoreGroup";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.lblMode);
            this.layoutControl1.Controls.Add(this.btnItemPriceHistory);
            this.layoutControl1.Controls.Add(this.chkShowAll);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.lkCategory);
            this.layoutControl1.Controls.Add(this.txtfilter);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.gridPriceList);
            this.layoutControl1.Controls.Add(this.btnLoad);
            this.layoutControl1.Controls.Add(this.lkAccount);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(263, 316, 250, 350);
            this.layoutControl1.Root = this.layoutMainGroup;
            this.layoutControl1.Size = new System.Drawing.Size(1103, 491);
            this.layoutControl1.TabIndex = 60;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(66, 32);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(290, 18);
            this.lblMode.StyleController = this.layoutControl1;
            this.lblMode.TabIndex = 68;
            // 
            // btnItemPriceHistory
            // 
            this.btnItemPriceHistory.Location = new System.Drawing.Point(661, 463);
            this.btnItemPriceHistory.Name = "btnItemPriceHistory";
            this.btnItemPriceHistory.Size = new System.Drawing.Size(142, 22);
            this.btnItemPriceHistory.StyleController = this.layoutControl1;
            this.btnItemPriceHistory.TabIndex = 67;
            this.btnItemPriceHistory.Text = "History";
            this.btnItemPriceHistory.Click += new System.EventHandler(this.btnItemPriceHistory_Click);
            // 
            // chkShowAll
            // 
            this.chkShowAll.Location = new System.Drawing.Point(367, 135);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(730, 20);
            this.chkShowAll.TabIndex = 66;
            this.chkShowAll.Text = "Show All";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::HCMIS.Desktop.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(955, 463);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(142, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 65;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lkCategory
            // 
            this.lkCategory.Location = new System.Drawing.Point(65, 78);
            this.lkCategory.Name = "lkCategory";
            this.lkCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCategory.Properties.DisplayMember = "Name";
            this.lkCategory.Properties.NullText = "Select Category";
            this.lkCategory.Properties.ShowFooter = false;
            this.lkCategory.Properties.ValueMember = "ID";
            this.lkCategory.Size = new System.Drawing.Size(291, 20);
            this.lkCategory.StyleController = this.layoutControl1;
            this.lkCategory.TabIndex = 64;
            this.lkCategory.EditValueChanged += new System.EventHandler(this.lkCategory_EditValueChanged);
            // 
            // txtfilter
            // 
            this.txtfilter.Location = new System.Drawing.Point(65, 128);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(291, 20);
            this.txtfilter.StyleController = this.layoutControl1;
            this.txtfilter.TabIndex = 63;
            this.txtfilter.EditValueChanged += new System.EventHandler(this.txtfilter_EditValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::HCMIS.Desktop.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(807, 463);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridPriceList
            // 
            this.gridPriceList.Location = new System.Drawing.Point(6, 159);
            this.gridPriceList.MainView = this.gridViewPriceList;
            this.gridPriceList.Name = "gridPriceList";
            this.gridPriceList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpTextEdit});
            this.gridPriceList.Size = new System.Drawing.Size(1091, 300);
            this.gridPriceList.TabIndex = 61;
            this.gridPriceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPriceList});
            this.gridPriceList.Click += new System.EventHandler(this.gridPriceList_Click);
            // 
            // gridViewPriceList
            // 
            this.gridViewPriceList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colStockCode,
            this.colItemName,
            this.colUnit,
            this.colManufacturer,
            this.colUnitCost,
            this.colMargin,
            this.colSellingPrice});
            this.gridViewPriceList.GridControl = this.gridPriceList;
            this.gridViewPriceList.Name = "gridViewPriceList";
            this.gridViewPriceList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewPriceList.OptionsView.ShowGroupPanel = false;
            this.gridViewPriceList.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewPriceList_CellValueChanged);
            // 
            // colNumber
            // 
            this.colNumber.Caption = "No.";
            this.colNumber.FieldName = "No";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.OptionsColumn.AllowFocus = false;
            this.colNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNumber.OptionsColumn.AllowIncrementalSearch = false;
            this.colNumber.OptionsColumn.AllowMove = false;
            this.colNumber.OptionsColumn.AllowShowHide = false;
            this.colNumber.OptionsColumn.AllowSize = false;
            this.colNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNumber.OptionsColumn.ShowInCustomizationForm = false;
            this.colNumber.OptionsColumn.ShowInExpressionEditor = false;
            this.colNumber.OptionsColumn.TabStop = false;
            this.colNumber.OptionsFilter.AllowAutoFilter = false;
            this.colNumber.OptionsFilter.AllowFilter = false;
            this.colNumber.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colNumber.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colNumber.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colNumber.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            this.colNumber.Width = 25;
            // 
            // colStockCode
            // 
            this.colStockCode.Caption = "Stock Code";
            this.colStockCode.FieldName = "StockCode";
            this.colStockCode.Name = "colStockCode";
            this.colStockCode.OptionsColumn.AllowEdit = false;
            this.colStockCode.OptionsColumn.AllowFocus = false;
            this.colStockCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colStockCode.OptionsColumn.AllowIncrementalSearch = false;
            this.colStockCode.OptionsColumn.AllowMove = false;
            this.colStockCode.OptionsColumn.AllowShowHide = false;
            this.colStockCode.OptionsColumn.AllowSize = false;
            this.colStockCode.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colStockCode.OptionsColumn.ShowInCustomizationForm = false;
            this.colStockCode.OptionsColumn.ShowInExpressionEditor = false;
            this.colStockCode.OptionsColumn.TabStop = false;
            this.colStockCode.OptionsFilter.AllowAutoFilter = false;
            this.colStockCode.OptionsFilter.AllowFilter = false;
            this.colStockCode.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colStockCode.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colStockCode.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colStockCode.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colStockCode.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colStockCode.Visible = true;
            this.colStockCode.VisibleIndex = 1;
            this.colStockCode.Width = 67;
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowFocus = false;
            this.colItemName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsColumn.AllowIncrementalSearch = false;
            this.colItemName.OptionsColumn.AllowMove = false;
            this.colItemName.OptionsColumn.AllowShowHide = false;
            this.colItemName.OptionsColumn.AllowSize = false;
            this.colItemName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsColumn.ShowInCustomizationForm = false;
            this.colItemName.OptionsColumn.ShowInExpressionEditor = false;
            this.colItemName.OptionsColumn.TabStop = false;
            this.colItemName.OptionsFilter.AllowAutoFilter = false;
            this.colItemName.OptionsFilter.AllowFilter = false;
            this.colItemName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colItemName.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 2;
            this.colItemName.Width = 564;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Unit";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.OptionsColumn.AllowFocus = false;
            this.colUnit.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsColumn.AllowIncrementalSearch = false;
            this.colUnit.OptionsColumn.AllowMove = false;
            this.colUnit.OptionsColumn.AllowShowHide = false;
            this.colUnit.OptionsColumn.AllowSize = false;
            this.colUnit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsColumn.ShowInCustomizationForm = false;
            this.colUnit.OptionsColumn.ShowInExpressionEditor = false;
            this.colUnit.OptionsColumn.TabStop = false;
            this.colUnit.OptionsFilter.AllowAutoFilter = false;
            this.colUnit.OptionsFilter.AllowFilter = false;
            this.colUnit.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colUnit.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 3;
            this.colUnit.Width = 70;
            // 
            // colManufacturer
            // 
            this.colManufacturer.Caption = "Manufacturer";
            this.colManufacturer.FieldName = "Manufacturer";
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.OptionsColumn.AllowEdit = false;
            this.colManufacturer.OptionsColumn.AllowFocus = false;
            this.colManufacturer.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsColumn.AllowIncrementalSearch = false;
            this.colManufacturer.OptionsColumn.AllowMove = false;
            this.colManufacturer.OptionsColumn.AllowShowHide = false;
            this.colManufacturer.OptionsColumn.AllowSize = false;
            this.colManufacturer.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsColumn.ShowInCustomizationForm = false;
            this.colManufacturer.OptionsColumn.ShowInExpressionEditor = false;
            this.colManufacturer.OptionsColumn.TabStop = false;
            this.colManufacturer.OptionsFilter.AllowAutoFilter = false;
            this.colManufacturer.OptionsFilter.AllowFilter = false;
            this.colManufacturer.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colManufacturer.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.Visible = true;
            this.colManufacturer.VisibleIndex = 4;
            this.colManufacturer.Width = 198;
            // 
            // colUnitCost
            // 
            this.colUnitCost.Caption = "Unit Cost";
            this.colUnitCost.DisplayFormat.FormatString = "#,##0.#0";
            this.colUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitCost.FieldName = "UnitCost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitCost.OptionsColumn.AllowIncrementalSearch = false;
            this.colUnitCost.OptionsColumn.AllowMove = false;
            this.colUnitCost.OptionsColumn.AllowShowHide = false;
            this.colUnitCost.OptionsColumn.AllowSize = false;
            this.colUnitCost.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitCost.OptionsColumn.ShowInCustomizationForm = false;
            this.colUnitCost.OptionsColumn.ShowInExpressionEditor = false;
            this.colUnitCost.OptionsColumn.TabStop = false;
            this.colUnitCost.OptionsFilter.AllowAutoFilter = false;
            this.colUnitCost.OptionsFilter.AllowFilter = false;
            this.colUnitCost.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitCost.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitCost.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colUnitCost.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitCost.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitCost.Visible = true;
            this.colUnitCost.VisibleIndex = 5;
            this.colUnitCost.Width = 84;
            // 
            // colMargin
            // 
            this.colMargin.Caption = "Margin";
            this.colMargin.ColumnEdit = this.rpTextEdit;
            this.colMargin.DisplayFormat.FormatString = "#,##0.#0 %";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.Name = "colMargin";
            this.colMargin.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsColumn.AllowIncrementalSearch = false;
            this.colMargin.OptionsColumn.AllowMove = false;
            this.colMargin.OptionsColumn.AllowShowHide = false;
            this.colMargin.OptionsColumn.AllowSize = false;
            this.colMargin.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsColumn.ShowInCustomizationForm = false;
            this.colMargin.OptionsColumn.ShowInExpressionEditor = false;
            this.colMargin.OptionsColumn.TabStop = false;
            this.colMargin.OptionsFilter.AllowAutoFilter = false;
            this.colMargin.OptionsFilter.AllowFilter = false;
            this.colMargin.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colMargin.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 6;
            this.colMargin.Width = 62;
            // 
            // rpTextEdit
            // 
            this.rpTextEdit.AutoHeight = false;
            this.rpTextEdit.Mask.EditMask = "p";
            this.rpTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.rpTextEdit.Mask.UseMaskAsDisplayFormat = true;
            this.rpTextEdit.Name = "rpTextEdit";
            // 
            // colSellingPrice
            // 
            this.colSellingPrice.Caption = "Selling Price";
            this.colSellingPrice.DisplayFormat.FormatString = "#,##0.#0";
            this.colSellingPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellingPrice.FieldName = "SellingPrice";
            this.colSellingPrice.Name = "colSellingPrice";
            this.colSellingPrice.OptionsColumn.AllowEdit = false;
            this.colSellingPrice.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSellingPrice.OptionsColumn.AllowIncrementalSearch = false;
            this.colSellingPrice.OptionsColumn.AllowMove = false;
            this.colSellingPrice.OptionsColumn.AllowShowHide = false;
            this.colSellingPrice.OptionsColumn.AllowSize = false;
            this.colSellingPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSellingPrice.OptionsColumn.ShowInCustomizationForm = false;
            this.colSellingPrice.OptionsColumn.ShowInExpressionEditor = false;
            this.colSellingPrice.OptionsColumn.TabStop = false;
            this.colSellingPrice.OptionsFilter.AllowAutoFilter = false;
            this.colSellingPrice.OptionsFilter.AllowFilter = false;
            this.colSellingPrice.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colSellingPrice.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colSellingPrice.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colSellingPrice.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colSellingPrice.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colSellingPrice.Visible = true;
            this.colSellingPrice.VisibleIndex = 7;
            this.colSellingPrice.Width = 94;
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::HCMIS.Desktop.Properties.Resources.Go;
            this.btnLoad.Location = new System.Drawing.Point(214, 102);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(142, 22);
            this.btnLoad.StyleController = this.layoutControl1;
            this.btnLoad.TabIndex = 60;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // layoutMainGroup
            // 
            this.layoutMainGroup.CustomizationFormText = "layoutMainGroup";
            this.layoutMainGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutMainGroup.GroupBordersVisible = false;
            this.layoutMainGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlGroup1,
            this.emptySpaceItem6,
            this.emptySpaceItem2,
            this.layoutGridPriceList,
            this.layoutControlItem5});
            this.layoutMainGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutMainGroup.Name = "layoutMainGroup";
            this.layoutMainGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutMainGroup.Size = new System.Drawing.Size(1103, 491);
            this.layoutMainGroup.Text = "layoutMainGroup";
            this.layoutMainGroup.TextVisible = false;
            // 
            // layoutGridPriceList
            // 
            this.layoutGridPriceList.Control = this.gridPriceList;
            this.layoutGridPriceList.CustomizationFormText = "layoutGridPriceList";
            this.layoutGridPriceList.Location = new System.Drawing.Point(0, 153);
            this.layoutGridPriceList.Name = "layoutGridPriceList";
            this.layoutGridPriceList.Size = new System.Drawing.Size(1095, 304);
            this.layoutGridPriceList.Text = "layoutGridPriceList";
            this.layoutGridPriceList.TextSize = new System.Drawing.Size(0, 0);
            this.layoutGridPriceList.TextToControlDistance = 0;
            this.layoutGridPriceList.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(801, 457);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(148, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(148, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(148, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnPrint;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(949, 457);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnItemPriceHistory;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(655, 457);
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
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Filter";
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutBtnLoad,
            this.emptySpaceItem3,
            this.layoutControlItem3,
            this.layoutlkAccount,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup1.Size = new System.Drawing.Size(361, 153);
            this.layoutControlGroup1.Text = "Filter";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtfilter;
            this.layoutControlItem2.CustomizationFormText = "Filter";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(347, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(347, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(347, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Filter:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkShowAll;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(361, 129);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(734, 24);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutBtnLoad
            // 
            this.layoutBtnLoad.Control = this.btnLoad;
            this.layoutBtnLoad.CustomizationFormText = "layoutBtnLoad";
            this.layoutBtnLoad.Location = new System.Drawing.Point(201, 70);
            this.layoutBtnLoad.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutBtnLoad.MinSize = new System.Drawing.Size(146, 26);
            this.layoutBtnLoad.Name = "layoutBtnLoad";
            this.layoutBtnLoad.Size = new System.Drawing.Size(146, 26);
            this.layoutBtnLoad.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutBtnLoad.Text = "layoutBtnLoad";
            this.layoutBtnLoad.TextSize = new System.Drawing.Size(0, 0);
            this.layoutBtnLoad.TextToControlDistance = 0;
            this.layoutBtnLoad.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 70);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(201, 26);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lkCategory;
            this.layoutControlItem3.CustomizationFormText = "Category";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(347, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(347, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(347, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Category:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutlkAccount
            // 
            this.layoutlkAccount.Control = this.lkAccount;
            this.layoutlkAccount.CustomizationFormText = "Account ";
            this.layoutlkAccount.Location = new System.Drawing.Point(0, 22);
            this.layoutlkAccount.MaxSize = new System.Drawing.Size(347, 24);
            this.layoutlkAccount.MinSize = new System.Drawing.Size(347, 24);
            this.layoutlkAccount.Name = "layoutlkAccount";
            this.layoutlkAccount.Size = new System.Drawing.Size(347, 24);
            this.layoutlkAccount.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutlkAccount.Text = "Account:";
            this.layoutlkAccount.TextSize = new System.Drawing.Size(49, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lblMode;
            this.layoutControlItem7.CustomizationFormText = "Mode:";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(347, 22);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(347, 22);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(347, 22);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "Mode:";
            this.layoutControlItem7.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(30, 13);
            this.layoutControlItem7.TextToControlDistance = 23;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 457);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(655, 26);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.lblMode;
            this.layoutControlItem38.CustomizationFormText = "Order Number: ";
            this.layoutControlItem38.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem38.Text = "Order No.: ";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem38.TextToControlDistance = 8;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(361, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(734, 129);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // PriceOverride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 491);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PriceOverride";
            this.Text = "PriceOverride";
            this.Load += new System.EventHandler(this.PriceOverride_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpTextEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMainGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGridPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBtnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutlkAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GridLookUpEdit lkAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn ParentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutMainGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutlkAccount;
        private DevExpress.XtraGrid.GridControl gridPriceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPriceList;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private DevExpress.XtraLayout.LayoutControlItem layoutBtnLoad;
        private DevExpress.XtraLayout.LayoutControlItem layoutGridPriceList;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colManufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colMargin;
        private DevExpress.XtraGrid.Columns.GridColumn colSellingPrice;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpTextEdit;
        private DevExpress.XtraEditors.LookUpEdit lkCategory;
        private DevExpress.XtraEditors.TextEdit txtfilter;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.CheckBox chkShowAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnItemPriceHistory;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}