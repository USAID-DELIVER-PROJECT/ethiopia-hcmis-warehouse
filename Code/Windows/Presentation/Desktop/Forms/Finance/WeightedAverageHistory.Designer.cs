namespace HCMIS.Desktop.Forms.Modals
{
    partial class WeightedAverageHistory
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
            this.ReceiveDocAudit = new System.Data.DataTable();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.IssueDocAudit = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.gridAllSimilarItems = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBalance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGRV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridBeggining = new DevExpress.XtraGrid.GridControl();
            this.gridBegginingView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColReceiveDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBatchNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBeginningQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBeginningUnitCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBeginningTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBeginningMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColBeginningSellingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.DataSet = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDocAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IssueDocAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllSimilarItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBeggining)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBegginingView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // ReceiveDocAudit
            // 
            this.ReceiveDocAudit.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn3,
            this.dataColumn4});
            this.ReceiveDocAudit.TableName = "ReceiveDocAudit";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Date";
            this.dataColumn3.ColumnName = "Date";
            this.dataColumn3.DataType = typeof(System.DateTime);
            // 
            // dataColumn4
            // 
            this.dataColumn4.Caption = "Value";
            this.dataColumn4.ColumnName = "Value";
            this.dataColumn4.DataType = typeof(double);
            // 
            // IssueDocAudit
            // 
            this.IssueDocAudit.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.IssueDocAudit.TableName = "IssueDocAudit";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Date";
            this.dataColumn1.DataType = typeof(System.DateTime);
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Value";
            this.dataColumn2.DataType = typeof(double);
            // 
            // gridAllSimilarItems
            // 
            this.gridAllSimilarItems.Location = new System.Drawing.Point(24, 187);
            this.gridAllSimilarItems.MainView = this.gridView2;
            this.gridAllSimilarItems.Name = "gridAllSimilarItems";
            this.gridAllSimilarItems.Size = new System.Drawing.Size(761, 159);
            this.gridAllSimilarItems.TabIndex = 6;
            this.gridAllSimilarItems.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserName,
            this.colRemark,
            this.gridColumn16,
            this.colBalance,
            this.colUnitCost,
            this.colCost,
            this.colTotQty,
            this.gridColumn11,
            this.gridColumn12,
            this.colSellingPrice,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colMargin,
            this.colGRV});
            this.gridView2.GridControl = this.gridAllSimilarItems;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "Changed By";
            this.colUserName.FieldName = "FullName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 11;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 12;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Date";
            this.gridColumn16.FieldName = "Date";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            this.gridColumn16.Width = 113;
            // 
            // colBalance
            // 
            this.colBalance.Caption = "Previous Quantity";
            this.colBalance.DisplayFormat.FormatString = "#,##0.##";
            this.colBalance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBalance.FieldName = "PQty";
            this.colBalance.Name = "colBalance";
            this.colBalance.OptionsColumn.AllowEdit = false;
            this.colBalance.OptionsColumn.AllowFocus = false;
            this.colBalance.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0:#,##0}")});
            this.colBalance.Visible = true;
            this.colBalance.VisibleIndex = 3;
            this.colBalance.Width = 85;
            // 
            // colUnitCost
            // 
            this.colUnitCost.Caption = "Average Cost";
            this.colUnitCost.DisplayFormat.FormatString = "{0:ETB #,###0.#0}";
            this.colUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitCost.FieldName = "NUnitCost";
            this.colUnitCost.Name = "colUnitCost";
            this.colUnitCost.OptionsColumn.AllowEdit = false;
            this.colUnitCost.OptionsColumn.AllowFocus = false;
            this.colUnitCost.Visible = true;
            this.colUnitCost.VisibleIndex = 6;
            this.colUnitCost.Width = 85;
            // 
            // colCost
            // 
            this.colCost.Caption = "Previous Cost";
            this.colCost.DisplayFormat.FormatString = "{0:ETB #,###0.#0}";
            this.colCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCost.FieldName = "PUnitCost";
            this.colCost.Name = "colCost";
            this.colCost.OptionsColumn.AllowEdit = false;
            this.colCost.OptionsColumn.AllowFocus = false;
            this.colCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cost", "{0:ETB #,###,###,###0.#0}")});
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 4;
            this.colCost.Width = 85;
            // 
            // colTotQty
            // 
            this.colTotQty.Caption = "Total Quantity";
            this.colTotQty.DisplayFormat.FormatString = "#,##0";
            this.colTotQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotQty.FieldName = "NQty";
            this.colTotQty.Name = "colTotQty";
            this.colTotQty.OptionsColumn.AllowEdit = false;
            this.colTotQty.OptionsColumn.AllowFocus = false;
            this.colTotQty.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "SellingPrice", "{0:#,##0.###0}")});
            this.colTotQty.Visible = true;
            this.colTotQty.VisibleIndex = 7;
            this.colTotQty.Width = 85;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Item Name";
            this.gridColumn11.FieldName = "FullItemName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Manufacturer Name";
            this.gridColumn12.FieldName = "ManufacturerName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // colSellingPrice
            // 
            this.colSellingPrice.Caption = "Selling Price";
            this.colSellingPrice.DisplayFormat.FormatString = "{0:ETB #,###0.#0}";
            this.colSellingPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellingPrice.FieldName = "Price";
            this.colSellingPrice.Name = "colSellingPrice";
            this.colSellingPrice.OptionsColumn.AllowEdit = false;
            this.colSellingPrice.OptionsColumn.AllowFocus = false;
            this.colSellingPrice.Visible = true;
            this.colSellingPrice.VisibleIndex = 10;
            this.colSellingPrice.Width = 88;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Manufacturer";
            this.gridColumn1.FieldName = "Manufacturer";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Width = 250;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Remark";
            this.gridColumn4.FieldName = "Remark";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "New Cost";
            this.gridColumn5.DisplayFormat.FormatString = "{0:ETB #,###0.#0}";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "UPUnitCost";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "New Quantity";
            this.gridColumn6.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "UPQty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // colMargin
            // 
            this.colMargin.Caption = "Margin";
            this.colMargin.DisplayFormat.FormatString = "{0: #,###0.#0%}";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.Name = "colMargin";
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 9;
            // 
            // colGRV
            // 
            this.colGRV.Caption = "GRV/IGRV";
            this.colGRV.DisplayFormat.FormatString = "{0:00000}";
            this.colGRV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGRV.FieldName = "GRV";
            this.colGRV.Name = "colGRV";
            this.colGRV.Visible = true;
            this.colGRV.VisibleIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.gridBeggining);
            this.layoutControl1.Controls.Add(this.gridAllSimilarItems);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(809, 396);
            this.layoutControl1.TabIndex = 7;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(639, 350);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(146, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gridBeggining
            // 
            this.gridBeggining.Location = new System.Drawing.Point(24, 62);
            this.gridBeggining.MainView = this.gridBegginingView;
            this.gridBeggining.Name = "gridBeggining";
            this.gridBeggining.Size = new System.Drawing.Size(761, 105);
            this.gridBeggining.TabIndex = 7;
            this.gridBeggining.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridBegginingView});
            // 
            // gridBegginingView
            // 
            this.gridBegginingView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColReceiveDate,
            this.ColBatchNo,
            this.ColExpiryDate,
            this.ColBeginningQuantity,
            this.ColBeginningUnitCost,
            this.ColBeginningTotalCost,
            this.ColBeginningMargin,
            this.ColBeginningSellingPrice});
            this.gridBegginingView.GridControl = this.gridBeggining;
            this.gridBegginingView.Name = "gridBegginingView";
            this.gridBegginingView.OptionsView.ShowFooter = true;
            this.gridBegginingView.OptionsView.ShowGroupPanel = false;
            // 
            // ColReceiveDate
            // 
            this.ColReceiveDate.Caption = "Received Date";
            this.ColReceiveDate.FieldName = "ReceivedDate";
            this.ColReceiveDate.Name = "ColReceiveDate";
            this.ColReceiveDate.OptionsColumn.AllowEdit = false;
            this.ColReceiveDate.OptionsColumn.AllowFocus = false;
            this.ColReceiveDate.Visible = true;
            this.ColReceiveDate.VisibleIndex = 0;
            // 
            // ColBatchNo
            // 
            this.ColBatchNo.Caption = "BatchNo";
            this.ColBatchNo.FieldName = "BatchNo";
            this.ColBatchNo.Name = "ColBatchNo";
            this.ColBatchNo.OptionsColumn.AllowEdit = false;
            this.ColBatchNo.OptionsColumn.AllowFocus = false;
            this.ColBatchNo.Visible = true;
            this.ColBatchNo.VisibleIndex = 1;
            // 
            // ColExpiryDate
            // 
            this.ColExpiryDate.Caption = "Exp Date";
            this.ColExpiryDate.FieldName = "ExpDate";
            this.ColExpiryDate.Name = "ColExpiryDate";
            this.ColExpiryDate.OptionsColumn.AllowEdit = false;
            this.ColExpiryDate.OptionsColumn.AllowFocus = false;
            this.ColExpiryDate.Visible = true;
            this.ColExpiryDate.VisibleIndex = 2;
            // 
            // ColBeginningQuantity
            // 
            this.ColBeginningQuantity.Caption = "Quantity";
            this.ColBeginningQuantity.DisplayFormat.FormatString = "#,##0.##";
            this.ColBeginningQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColBeginningQuantity.FieldName = "Quantity";
            this.ColBeginningQuantity.Name = "ColBeginningQuantity";
            this.ColBeginningQuantity.OptionsColumn.AllowEdit = false;
            this.ColBeginningQuantity.OptionsColumn.AllowFocus = false;
            this.ColBeginningQuantity.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.ColBeginningQuantity.Visible = true;
            this.ColBeginningQuantity.VisibleIndex = 3;
            // 
            // ColBeginningUnitCost
            // 
            this.ColBeginningUnitCost.Caption = "Unit Cost";
            this.ColBeginningUnitCost.DisplayFormat.FormatString = "{0:ETB #,###0.#0}";
            this.ColBeginningUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColBeginningUnitCost.FieldName = "UnitCost";
            this.ColBeginningUnitCost.Name = "ColBeginningUnitCost";
            this.ColBeginningUnitCost.OptionsColumn.AllowEdit = false;
            this.ColBeginningUnitCost.OptionsColumn.AllowFocus = false;
            this.ColBeginningUnitCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Min)});
            this.ColBeginningUnitCost.Visible = true;
            this.ColBeginningUnitCost.VisibleIndex = 4;
            // 
            // ColBeginningTotalCost
            // 
            this.ColBeginningTotalCost.Caption = "Total Cost";
            this.ColBeginningTotalCost.DisplayFormat.FormatString = "{0:ETB #,###0.#0}";
            this.ColBeginningTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColBeginningTotalCost.FieldName = "TotalCost";
            this.ColBeginningTotalCost.Name = "ColBeginningTotalCost";
            this.ColBeginningTotalCost.OptionsColumn.AllowEdit = false;
            this.ColBeginningTotalCost.OptionsColumn.AllowFocus = false;
            this.ColBeginningTotalCost.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.ColBeginningTotalCost.Visible = true;
            this.ColBeginningTotalCost.VisibleIndex = 5;
            // 
            // ColBeginningMargin
            // 
            this.ColBeginningMargin.Caption = "Margin";
            this.ColBeginningMargin.DisplayFormat.FormatString = "{0:#,###0.#0%}";
            this.ColBeginningMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColBeginningMargin.FieldName = "Margin";
            this.ColBeginningMargin.Name = "ColBeginningMargin";
            this.ColBeginningMargin.OptionsColumn.AllowEdit = false;
            this.ColBeginningMargin.OptionsColumn.AllowFocus = false;
            this.ColBeginningMargin.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Min)});
            this.ColBeginningMargin.Visible = true;
            this.ColBeginningMargin.VisibleIndex = 6;
            // 
            // ColBeginningSellingPrice
            // 
            this.ColBeginningSellingPrice.Caption = "Selling Price";
            this.ColBeginningSellingPrice.DisplayFormat.FormatString = "{0:ETB #,###0.#0}";
            this.ColBeginningSellingPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ColBeginningSellingPrice.FieldName = "SellingPrice";
            this.ColBeginningSellingPrice.Name = "ColBeginningSellingPrice";
            this.ColBeginningSellingPrice.OptionsColumn.AllowEdit = false;
            this.ColBeginningSellingPrice.OptionsColumn.AllowFocus = false;
            this.ColBeginningSellingPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Min)});
            this.ColBeginningSellingPrice.Visible = true;
            this.ColBeginningSellingPrice.VisibleIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(809, 396);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.layoutControlGroup2;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(789, 376);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Information";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(765, 330);
            this.layoutControlGroup2.Text = "Information";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridBeggining;
            this.layoutControlItem2.CustomizationFormText = "Beginning Balance";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(765, 125);
            this.layoutControlItem2.Text = "Beginning Balance";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridAllSimilarItems;
            this.layoutControlItem1.CustomizationFormText = "Moving Average";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 125);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(765, 179);
            this.layoutControlItem1.Text = "Moving Average";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(86, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnPrint;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(615, 304);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(150, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 304);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(615, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // DataSet
            // 
            this.DataSet.DataSetName = "PriceAudit";
            this.DataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.ReceiveDocAudit,
            this.IssueDocAudit});
            // 
            // WeightedAverageHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 396);
            this.Controls.Add(this.layoutControl1);
            this.Name = "WeightedAverageHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.WeightedAverageHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiveDocAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IssueDocAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllSimilarItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBeggining)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBegginingView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridAllSimilarItems;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn colBalance;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private DevExpress.XtraGrid.Columns.GridColumn colTotQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn colSellingPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridBeggining;
        private DevExpress.XtraGrid.Views.Grid.GridView gridBegginingView;
        private DevExpress.XtraGrid.Columns.GridColumn ColBeginningQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn ColBeginningUnitCost;
        private DevExpress.XtraGrid.Columns.GridColumn ColBeginningTotalCost;
        private DevExpress.XtraGrid.Columns.GridColumn ColBeginningMargin;
        private DevExpress.XtraGrid.Columns.GridColumn ColBeginningSellingPrice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn ColReceiveDate;
        private DevExpress.XtraGrid.Columns.GridColumn ColBatchNo;
        private DevExpress.XtraGrid.Columns.GridColumn ColExpiryDate;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Data.DataTable ReceiveDocAudit;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataTable IssueDocAudit;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataSet DataSet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colMargin;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colGRV;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}