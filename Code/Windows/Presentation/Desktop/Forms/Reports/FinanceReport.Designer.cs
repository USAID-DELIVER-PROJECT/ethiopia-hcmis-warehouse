namespace HCMIS.Desktop.Forms.Reports
{
    partial class FinanceReport
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridVoucherView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceTotalLandedCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrandGRVTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridMain = new DevExpress.XtraGrid.GridControl();
            this.gridOrderView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPONumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRefNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridGRVView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkSupplier = new DevExpress.XtraEditors.LookUpEdit();
            this.lkAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ParentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGRVView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkSupplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVoucherView
            // 
            this.gridVoucherView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoice,
            this.colTotalInvoice,
            this.colInvoiceInsurance,
            this.colNationalBank,
            this.colInvoiceTotalLandedCost,
            this.colGrandGRVTotal});
            this.gridVoucherView.GridControl = this.gridMain;
            this.gridVoucherView.Name = "gridVoucherView";
            // 
            // colInvoice
            // 
            this.colInvoice.Caption = "Invoice #";
            this.colInvoice.FieldName = "InvoiceNumber";
            this.colInvoice.Name = "colInvoice";
            this.colInvoice.Visible = true;
            this.colInvoice.VisibleIndex = 0;
            // 
            // colTotalInvoice
            // 
            this.colTotalInvoice.Caption = "Total Value";
            this.colTotalInvoice.FieldName = "TotalValue";
            this.colTotalInvoice.Name = "colTotalInvoice";
            this.colTotalInvoice.Visible = true;
            this.colTotalInvoice.VisibleIndex = 1;
            // 
            // colInvoiceInsurance
            // 
            this.colInvoiceInsurance.Caption = "Insurance";
            this.colInvoiceInsurance.FieldName = "proInsurance";
            this.colInvoiceInsurance.Name = "colInvoiceInsurance";
            this.colInvoiceInsurance.Visible = true;
            this.colInvoiceInsurance.VisibleIndex = 2;
            // 
            // colNationalBank
            // 
            this.colNationalBank.Caption = "NBE";
            this.colNationalBank.FieldName = "proNBE";
            this.colNationalBank.Name = "colNationalBank";
            this.colNationalBank.Visible = true;
            this.colNationalBank.VisibleIndex = 3;
            // 
            // colInvoiceTotalLandedCost
            // 
            this.colInvoiceTotalLandedCost.Caption = "Total Landed Cost";
            this.colInvoiceTotalLandedCost.FieldName = "TotalLandedCost";
            this.colInvoiceTotalLandedCost.Name = "colInvoiceTotalLandedCost";
            this.colInvoiceTotalLandedCost.Visible = true;
            this.colInvoiceTotalLandedCost.VisibleIndex = 4;
            // 
            // colGrandGRVTotal
            // 
            this.colGrandGRVTotal.Caption = "GrandTotalGRV";
            this.colGrandGRVTotal.FieldName = "GrandTotalGRV";
            this.colGrandGRVTotal.Name = "colGrandGRVTotal";
            this.colGrandGRVTotal.Visible = true;
            this.colGrandGRVTotal.VisibleIndex = 5;
            // 
            // gridMain
            // 
            gridLevelNode1.LevelTemplate = this.gridVoucherView;
            gridLevelNode2.LevelTemplate = this.gridGRVView;
            gridLevelNode2.RelationName = "Level3";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "Level1";
            this.gridMain.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridMain.Location = new System.Drawing.Point(12, 36);
            this.gridMain.MainView = this.gridOrderView;
            this.gridMain.Name = "gridMain";
            this.gridMain.Size = new System.Drawing.Size(782, 455);
            this.gridMain.TabIndex = 6;
            this.gridMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridOrderView,
            this.gridGRVView,
            this.gridVoucherView});
            // 
            // gridOrderView
            // 
            this.gridOrderView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPONumber,
            this.colRefNo,
            this.colTotalValue,
            this.colInsurance,
            this.colNBE});
            this.gridOrderView.GridControl = this.gridMain;
            this.gridOrderView.Name = "gridOrderView";
            // 
            // colPONumber
            // 
            this.colPONumber.Caption = "Order Number";
            this.colPONumber.FieldName = "PONumber";
            this.colPONumber.Name = "colPONumber";
            this.colPONumber.Visible = true;
            this.colPONumber.VisibleIndex = 0;
            // 
            // colRefNo
            // 
            this.colRefNo.Caption = "Ref No";
            this.colRefNo.FieldName = "RefNo";
            this.colRefNo.Name = "colRefNo";
            this.colRefNo.Visible = true;
            this.colRefNo.VisibleIndex = 1;
            // 
            // colTotalValue
            // 
            this.colTotalValue.Caption = "Total FOB Value";
            this.colTotalValue.FieldName = "TotalValue";
            this.colTotalValue.Name = "colTotalValue";
            this.colTotalValue.Visible = true;
            this.colTotalValue.VisibleIndex = 2;
            // 
            // colInsurance
            // 
            this.colInsurance.Caption = "Insurance";
            this.colInsurance.FieldName = "Insurance";
            this.colInsurance.Name = "colInsurance";
            this.colInsurance.Visible = true;
            this.colInsurance.VisibleIndex = 3;
            // 
            // colNBE
            // 
            this.colNBE.Caption = "NBE";
            this.colNBE.Name = "colNBE";
            this.colNBE.Visible = true;
            this.colNBE.VisibleIndex = 4;
            // 
            // gridGRVView
            // 
            this.gridGRVView.GridControl = this.gridMain;
            this.gridGRVView.Name = "gridGRVView";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkSupplier);
            this.layoutControl1.Controls.Add(this.lkAccount);
            this.layoutControl1.Controls.Add(this.gridMain);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(806, 503);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkSupplier
            // 
            this.lkSupplier.Location = new System.Drawing.Point(262, 12);
            this.lkSupplier.Name = "lkSupplier";
            this.lkSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkSupplier.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "Supplier")});
            this.lkSupplier.Properties.DisplayMember = "CompanyName";
            this.lkSupplier.Properties.NullText = "Select Supplier";
            this.lkSupplier.Properties.ValueMember = "ID";
            this.lkSupplier.Size = new System.Drawing.Size(155, 20);
            this.lkSupplier.StyleController = this.layoutControl1;
            this.lkSupplier.TabIndex = 9;
            // 
            // lkAccount
            // 
            this.lkAccount.EditValue = "";
            this.lkAccount.Location = new System.Drawing.Point(55, 12);
            this.lkAccount.Name = "lkAccount";
            this.lkAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccount.Properties.DisplayMember = "Name";
            this.lkAccount.Properties.NullText = "Select Account";
            this.lkAccount.Properties.ValueMember = "ID";
            this.lkAccount.Properties.View = this.gridView1;
            this.lkAccount.Size = new System.Drawing.Size(117, 20);
            this.lkAccount.StyleController = this.layoutControl1;
            this.lkAccount.TabIndex = 58;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.gridColumn1,
            this.ParentID,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GroupCount = 2;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.ParentID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Sub Account";
            this.gridColumn1.FieldName = "Name";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // ParentID
            // 
            this.ParentID.Caption = "Mode";
            this.ParentID.FieldName = "StoreType";
            this.ParentID.Name = "ParentID";
            this.ParentID.Visible = true;
            this.ParentID.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Account";
            this.gridColumn2.FieldName = "StoreGroup";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(806, 503);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridMain;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(786, 459);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(409, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(377, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkAccount;
            this.layoutControlItem2.CustomizationFormText = "Account";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(164, 24);
            this.layoutControlItem2.Text = "Account";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(39, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lkSupplier;
            this.layoutControlItem4.CustomizationFormText = "Supplier";
            this.layoutControlItem4.Location = new System.Drawing.Point(207, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(202, 24);
            this.layoutControlItem4.Text = "Supplier";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(39, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(164, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(43, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FinanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 503);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FinanceReport";
            this.Text = "FinanceReport";
            this.Load += new System.EventHandler(this.FinanceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGRVView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkSupplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridMain;
        private DevExpress.XtraGrid.Views.Grid.GridView gridOrderView;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridVoucherView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridGRVView;
        private DevExpress.XtraEditors.GridLookUpEdit lkAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn ParentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit lkSupplier;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colPONumber;
        private DevExpress.XtraGrid.Columns.GridColumn colRefNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalValue;
        private DevExpress.XtraGrid.Columns.GridColumn colInsurance;
        private DevExpress.XtraGrid.Columns.GridColumn colNBE;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceInsurance;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalBank;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceTotalLandedCost;
        private DevExpress.XtraGrid.Columns.GridColumn colGrandGRVTotal;
    }
}