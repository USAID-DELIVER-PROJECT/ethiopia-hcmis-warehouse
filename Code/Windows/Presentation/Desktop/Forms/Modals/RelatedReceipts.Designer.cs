namespace HCMIS.Desktop.Forms.WorkFlow
{
    partial class RelatedReceipts
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridMain = new DevExpress.XtraGrid.GridControl();
            this.gridMasterView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Packs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceivingCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalReceiving = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridDetailView
            // 
            this.gridDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25});
            this.gridDetailView.GridControl = this.gridMain;
            this.gridDetailView.GroupCount = 1;
            this.gridDetailView.Name = "gridDetailView";
            this.gridDetailView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridDetailView.OptionsBehavior.AutoUpdateTotalSummary = false;
            this.gridDetailView.OptionsCustomization.AllowGroup = false;
            this.gridDetailView.OptionsDetail.ShowDetailTabs = false;
            this.gridDetailView.OptionsFilter.AllowMRUFilterList = false;
            this.gridDetailView.OptionsMenu.EnableColumnMenu = false;
            this.gridDetailView.OptionsMenu.EnableFooterMenu = false;
            this.gridDetailView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridDetailView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridDetailView.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridDetailView.OptionsView.ShowGroupPanel = false;
            this.gridDetailView.OptionsView.ShowIndicator = false;
            this.gridDetailView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn12, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Cluster";
            this.gridColumn11.FieldName = "Cluster";
            this.gridColumn11.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Warehouse";
            this.gridColumn12.FieldName = "Warehouse";
            this.gridColumn12.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Store";
            this.gridColumn14.FieldName = "Store";
            this.gridColumn14.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 0;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Allocated Quantity";
            this.gridColumn17.FieldName = "AllocatedQuantity";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 1;
            this.gridColumn17.Width = 83;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Quantity";
            this.gridColumn18.FieldName = "NoOfPack";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "FOB Value";
            this.gridColumn22.FieldName = "PricePerPack";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 3;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Total FOB Value";
            this.gridColumn23.FieldName = "TotalReceived";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 4;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn24.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn24.Caption = "Unit Cost";
            this.gridColumn24.FieldName = "UnitCost";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 5;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn25.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn25.Caption = "Total Cost";
            this.gridColumn25.FieldName = "TotalCost";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 6;
            // 
            // gridMain
            // 
            this.gridMain.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridDetailView;
            gridLevelNode1.RelationName = "gridDetail";
            this.gridMain.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridMain.Location = new System.Drawing.Point(0, 0);
            this.gridMain.MainView = this.gridMasterView;
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(645, 310);
            this.gridMain.TabIndex = 1;
            this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMasterView,
            this.cardView1,
            this.gridDetailView});
            // 
            // gridMasterView
            // 
            this.gridMasterView.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gridMasterView.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.gridMasterView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName,
            this.colManufacturer,
            this.colUnit,
            this.Packs,
            this.colReceivingCost,
            this.colTotalReceiving,
            this.colRemark,
            this.gridColumn1});
            this.gridMasterView.GridControl = this.gridMain;
            this.gridMasterView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridMasterView.GroupPanelText = " ";
            this.gridMasterView.Name = "gridMasterView";
            this.gridMasterView.OptionsCustomization.AllowColumnMoving = false;
            this.gridMasterView.OptionsCustomization.AllowColumnResizing = false;
            this.gridMasterView.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.gridMasterView.OptionsDetail.ShowDetailTabs = false;
            this.gridMasterView.OptionsMenu.EnableColumnMenu = false;
            this.gridMasterView.OptionsPrint.UsePrintStyles = true;
            this.gridMasterView.OptionsView.AllowCellMerge = true;
            this.gridMasterView.OptionsView.ShowFooter = true;
            this.gridMasterView.OptionsView.ShowGroupPanel = false;
            this.gridMasterView.DoubleClick += new System.EventHandler(this.gridMasterView_DoubleClick);
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item Name";
            this.colItemName.FieldName = "FullItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowFocus = false;
            this.colItemName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 1;
            this.colItemName.Width = 129;
            // 
            // colManufacturer
            // 
            this.colManufacturer.Caption = "Manufacturer";
            this.colManufacturer.FieldName = "Manufacturer";
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.OptionsColumn.AllowEdit = false;
            this.colManufacturer.OptionsColumn.AllowFocus = false;
            this.colManufacturer.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colManufacturer.Visible = true;
            this.colManufacturer.VisibleIndex = 2;
            this.colManufacturer.Width = 78;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Unit";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.OptionsColumn.AllowFocus = false;
            this.colUnit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 3;
            this.colUnit.Width = 35;
            // 
            // Packs
            // 
            this.Packs.Caption = "Quantity";
            this.Packs.DisplayFormat.FormatString = "###,###,##0";
            this.Packs.FieldName = "NoOfPack";
            this.Packs.Name = "Packs";
            this.Packs.OptionsColumn.AllowEdit = false;
            this.Packs.OptionsColumn.AllowFocus = false;
            this.Packs.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Packs.Visible = true;
            this.Packs.VisibleIndex = 7;
            this.Packs.Width = 57;
            // 
            // colReceivingCost
            // 
            this.colReceivingCost.Caption = "Batch";
            this.colReceivingCost.FieldName = "Batch";
            this.colReceivingCost.Name = "colReceivingCost";
            this.colReceivingCost.OptionsColumn.AllowEdit = false;
            this.colReceivingCost.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colReceivingCost.Visible = true;
            this.colReceivingCost.VisibleIndex = 4;
            this.colReceivingCost.Width = 73;
            // 
            // colTotalReceiving
            // 
            this.colTotalReceiving.Caption = "Expiry Date";
            this.colTotalReceiving.FieldName = "Expiredate";
            this.colTotalReceiving.Name = "colTotalReceiving";
            this.colTotalReceiving.OptionsColumn.AllowEdit = false;
            this.colTotalReceiving.OptionsColumn.AllowFocus = false;
            this.colTotalReceiving.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalReceiving.Visible = true;
            this.colTotalReceiving.VisibleIndex = 5;
            this.colTotalReceiving.Width = 82;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "Remark";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 6;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Stock Code";
            this.gridColumn1.FieldName = "StockCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // cardView1
            // 
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridMain;
            this.cardView1.Name = "cardView1";
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Item Name";
            this.gridColumn3.FieldName = "FullItemName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 129;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Manufacturer";
            this.gridColumn4.FieldName = "Manufacturer";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 78;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Unit";
            this.gridColumn5.FieldName = "Unit";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 35;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Quantity";
            this.gridColumn6.DisplayFormat.FormatString = "###,###,##0";
            this.gridColumn6.FieldName = "NoOfPack";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 57;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Unit Cost";
            this.gridColumn7.DisplayFormat.FormatString = "ETB #,###,###,##0.#0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "PricePerPack";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "PricePerPack", "Raw Total Cost")});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 73;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Total Unit Cost";
            this.gridColumn8.DisplayFormat.FormatString = "ETB #,###,###,##0.#0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "TotalReceived";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 82;
            // 
            // RelatedReceipts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 310);
            this.Controls.Add(this.gridMain);
            this.Name = "RelatedReceipts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RelatedReceipts";
            this.Load += new System.EventHandler(this.RelatedReceipts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMasterView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMasterView;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colManufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn Packs;
        private DevExpress.XtraGrid.Columns.GridColumn colReceivingCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalReceiving;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}