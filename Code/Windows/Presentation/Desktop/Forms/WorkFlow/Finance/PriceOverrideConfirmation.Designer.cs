namespace HCMIS.Desktop.Forms.WorkFlow.Finance
{
    partial class PriceOverrideConfirmation
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
            this.colSellingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirmed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.layoutMainGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutlkAccount = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutBtnLoad = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutGridPriceList = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtfilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMainGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutlkAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBtnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGridPriceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // lkAccount
            // 
            this.lkAccount.Location = new System.Drawing.Point(57, 12);
            this.lkAccount.Name = "lkAccount";
            this.lkAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccount.Properties.DisplayMember = "StoreGroup";
            this.lkAccount.Properties.NullText = "Select Account";
            this.lkAccount.Properties.ValueMember = "ID";
            this.lkAccount.Properties.View = this.gridLookUpEdit1View;
            this.lkAccount.Size = new System.Drawing.Size(330, 20);
            this.lkAccount.StyleController = this.layoutControl1;
            this.lkAccount.TabIndex = 59;
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
            this.layoutControl1.Controls.Add(this.txtfilter);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.gridPriceList);
            this.layoutControl1.Controls.Add(this.btnLoad);
            this.layoutControl1.Controls.Add(this.lkAccount);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutMainGroup;
            this.layoutControl1.Size = new System.Drawing.Size(1103, 491);
            this.layoutControl1.TabIndex = 60;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtfilter
            // 
            this.txtfilter.Location = new System.Drawing.Point(57, 36);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(330, 20);
            this.txtfilter.StyleController = this.layoutControl1;
            this.txtfilter.TabIndex = 64;
            this.txtfilter.EditValueChanged += new System.EventHandler(this.txtfilter_EditValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::HCMIS.Desktop.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(958, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridPriceList
            // 
            this.gridPriceList.Location = new System.Drawing.Point(12, 60);
            this.gridPriceList.MainView = this.gridViewPriceList;
            this.gridPriceList.Name = "gridPriceList";
            this.gridPriceList.Size = new System.Drawing.Size(1079, 393);
            this.gridPriceList.TabIndex = 61;
            this.gridPriceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPriceList});
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
            this.colSellingPrice,
            this.colConfirmed});
            this.gridViewPriceList.GridControl = this.gridPriceList;
            this.gridViewPriceList.Name = "gridViewPriceList";
            this.gridViewPriceList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewPriceList.OptionsView.ShowGroupPanel = false;
            this.gridViewPriceList.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colItemName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colNumber
            // 
            this.colNumber.Caption = "No.";
            this.colNumber.FieldName = "No";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.OptionsColumn.AllowFocus = false;
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
            this.colStockCode.Visible = true;
            this.colStockCode.VisibleIndex = 1;
            this.colStockCode.Width = 67;
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowFocus = false;
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
            this.colUnitCost.OptionsColumn.AllowEdit = false;
            this.colUnitCost.Visible = true;
            this.colUnitCost.VisibleIndex = 5;
            this.colUnitCost.Width = 84;
            // 
            // colMargin
            // 
            this.colMargin.Caption = "Margin";
            this.colMargin.DisplayFormat.FormatString = "#,##0.#0 %";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.Name = "colMargin";
            this.colMargin.OptionsColumn.AllowEdit = false;
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 6;
            this.colMargin.Width = 62;
            // 
            // colSellingPrice
            // 
            this.colSellingPrice.Caption = "Selling Price";
            this.colSellingPrice.DisplayFormat.FormatString = "#,##0.#0";
            this.colSellingPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellingPrice.FieldName = "SellingPrice";
            this.colSellingPrice.Name = "colSellingPrice";
            this.colSellingPrice.OptionsColumn.AllowEdit = false;
            this.colSellingPrice.Visible = true;
            this.colSellingPrice.VisibleIndex = 7;
            this.colSellingPrice.Width = 94;
            // 
            // colConfirmed
            // 
            this.colConfirmed.Caption = "Confirmed";
            this.colConfirmed.FieldName = "IsConfirmed";
            this.colConfirmed.Name = "colConfirmed";
            this.colConfirmed.Visible = true;
            this.colConfirmed.VisibleIndex = 8;
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::HCMIS.Desktop.Properties.Resources.Go;
            this.btnLoad.Location = new System.Drawing.Point(958, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(133, 22);
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
            this.layoutlkAccount,
            this.emptySpaceItem2,
            this.layoutBtnLoad,
            this.layoutGridPriceList,
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.layoutMainGroup.Location = new System.Drawing.Point(0, 0);
            this.layoutMainGroup.Name = "layoutMainGroup";
            this.layoutMainGroup.Size = new System.Drawing.Size(1103, 491);
            this.layoutMainGroup.Text = "layoutMainGroup";
            this.layoutMainGroup.TextVisible = false;
            // 
            // layoutlkAccount
            // 
            this.layoutlkAccount.Control = this.lkAccount;
            this.layoutlkAccount.CustomizationFormText = "Account ";
            this.layoutlkAccount.Location = new System.Drawing.Point(0, 0);
            this.layoutlkAccount.Name = "layoutlkAccount";
            this.layoutlkAccount.Size = new System.Drawing.Size(379, 24);
            this.layoutlkAccount.Text = "Account ";
            this.layoutlkAccount.TextSize = new System.Drawing.Size(42, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(379, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(567, 48);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutBtnLoad
            // 
            this.layoutBtnLoad.Control = this.btnLoad;
            this.layoutBtnLoad.CustomizationFormText = "layoutBtnLoad";
            this.layoutBtnLoad.Location = new System.Drawing.Point(946, 0);
            this.layoutBtnLoad.Name = "layoutBtnLoad";
            this.layoutBtnLoad.Size = new System.Drawing.Size(137, 48);
            this.layoutBtnLoad.Text = "layoutBtnLoad";
            this.layoutBtnLoad.TextSize = new System.Drawing.Size(0, 0);
            this.layoutBtnLoad.TextToControlDistance = 0;
            this.layoutBtnLoad.TextVisible = false;
            // 
            // layoutGridPriceList
            // 
            this.layoutGridPriceList.Control = this.gridPriceList;
            this.layoutGridPriceList.CustomizationFormText = "layoutGridPriceList";
            this.layoutGridPriceList.Location = new System.Drawing.Point(0, 48);
            this.layoutGridPriceList.Name = "layoutGridPriceList";
            this.layoutGridPriceList.Size = new System.Drawing.Size(1083, 397);
            this.layoutGridPriceList.Text = "layoutGridPriceList";
            this.layoutGridPriceList.TextSize = new System.Drawing.Size(0, 0);
            this.layoutGridPriceList.TextToControlDistance = 0;
            this.layoutGridPriceList.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(946, 445);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(137, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 445);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(946, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtfilter;
            this.layoutControlItem2.CustomizationFormText = "Filter";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(379, 24);
            this.layoutControlItem2.Text = "Filter";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(42, 13);
            // 
            // PriceOverrideConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 491);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PriceOverrideConfirmation";
            this.Text = "PriceOverride";
            this.Load += new System.EventHandler(this.PriceOverride_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtfilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutMainGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutlkAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutBtnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGridPriceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
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
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirmed;
        private DevExpress.XtraEditors.TextEdit txtfilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}