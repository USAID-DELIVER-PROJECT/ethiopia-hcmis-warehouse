namespace HCMIS.Desktop.Forms.Settings
{
    partial class WarehouseFreezeForm
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.ComboBoxFreezChoice = new DevExpress.XtraEditors.ComboBoxEdit();
            this.grdWarehouseFreez = new DevExpress.XtraGrid.GridControl();
            this.gridManageInvetoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.LocationName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.LocationID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lyoutFreezChoice = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Cluster = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WarehouseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Store = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StoreStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WarhouseID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.StoreID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxFreezChoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWarehouseFreez)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageInvetoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutFreezChoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // colStatusText
            // 
            this.colStatusText.Caption = "Status";
            this.colStatusText.FieldName = "StatusText";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.OptionsColumn.AllowEdit = false;
            this.colStatusText.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colStatusText.Visible = true;
            this.colStatusText.VisibleIndex = 1;
            this.colStatusText.Width = 200;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.ComboBoxFreezChoice);
            this.layoutControl1.Controls.Add(this.grdWarehouseFreez);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(651, 203, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(715, 490);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(625, 456);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 85;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ComboBoxFreezChoice
            // 
            this.ComboBoxFreezChoice.EditValue = "Physical Store";
            this.ComboBoxFreezChoice.Location = new System.Drawing.Point(57, 52);
            this.ComboBoxFreezChoice.Name = "ComboBoxFreezChoice";
            this.ComboBoxFreezChoice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxFreezChoice.Properties.Items.AddRange(new object[] {
            "Physical Store"});
            this.ComboBoxFreezChoice.Size = new System.Drawing.Size(197, 20);
            this.ComboBoxFreezChoice.StyleController = this.layoutControl1;
            this.ComboBoxFreezChoice.TabIndex = 84;
            this.ComboBoxFreezChoice.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFreezChoice_SelectedIndexChanged);
            // 
            // grdWarehouseFreez
            // 
            this.grdWarehouseFreez.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWarehouseFreez.Location = new System.Drawing.Point(12, 86);
            this.grdWarehouseFreez.MainView = this.gridManageInvetoryView;
            this.grdWarehouseFreez.Name = "grdWarehouseFreez";
            this.grdWarehouseFreez.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit2,
            this.repositoryItemCheckEdit1});
            this.grdWarehouseFreez.Size = new System.Drawing.Size(542, 366);
            this.grdWarehouseFreez.TabIndex = 83;
            this.grdWarehouseFreez.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.LocationName,
            this.Status,
            this.LocationID,
            this.colStatusText});
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = true;
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.Column = this.colStatusText;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = "[Status] == False";
            this.gridManageInvetoryView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition3,
            styleFormatCondition4});
            this.gridManageInvetoryView.GridControl = this.grdWarehouseFreez;
            this.gridManageInvetoryView.Name = "gridManageInvetoryView";
            this.gridManageInvetoryView.OptionsView.AllowCellMerge = true;
            this.gridManageInvetoryView.OptionsView.ShowGroupPanel = false;
            // 
            // LocationName
            // 
            this.LocationName.Caption = "LocationName";
            this.LocationName.FieldName = "LocationName";
            this.LocationName.Name = "LocationName";
            this.LocationName.OptionsColumn.AllowEdit = false;
            this.LocationName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.LocationName.OptionsColumn.ReadOnly = true;
            this.LocationName.Visible = true;
            this.LocationName.VisibleIndex = 0;
            this.LocationName.Width = 174;
            // 
            // Status
            // 
            this.Status.Caption = "Status";
            this.Status.ColumnEdit = this.repositoryItemCheckEdit1;
            this.Status.FieldName = "Status";
            this.Status.Name = "Status";
            this.Status.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.Status.Visible = true;
            this.Status.VisibleIndex = 2;
            this.Status.Width = 150;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // LocationID
            // 
            this.LocationID.Caption = "LocationID";
            this.LocationID.FieldName = "LocationID";
            this.LocationID.Name = "LocationID";
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
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.lyoutFreezChoice,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem2,
            this.simpleLabelItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(715, 490);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdWarehouseFreez;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(546, 370);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(546, 74);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(149, 370);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(246, 40);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(449, 24);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lyoutFreezChoice
            // 
            this.lyoutFreezChoice.Control = this.ComboBoxFreezChoice;
            this.lyoutFreezChoice.CustomizationFormText = "Freez By";
            this.lyoutFreezChoice.Location = new System.Drawing.Point(0, 40);
            this.lyoutFreezChoice.Name = "lyoutFreezChoice";
            this.lyoutFreezChoice.Size = new System.Drawing.Size(246, 24);
            this.lyoutFreezChoice.Text = "Freez By";
            this.lyoutFreezChoice.TextSize = new System.Drawing.Size(42, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 64);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(695, 10);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 444);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(613, 26);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSave;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(613, 444);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(82, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // Cluster
            // 
            this.Cluster.Caption = "Cluster";
            this.Cluster.FieldName = "Cluster";
            this.Cluster.Name = "Cluster";
            // 
            // WarehouseName
            // 
            this.WarehouseName.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WarehouseName.AppearanceCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WarehouseName.AppearanceCell.Options.UseBackColor = true;
            this.WarehouseName.Caption = "Warehouse";
            this.WarehouseName.FieldName = "Warehouse";
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.OptionsColumn.AllowEdit = false;
            this.WarehouseName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.WarehouseName.Visible = true;
            this.WarehouseName.VisibleIndex = 0;
            // 
            // Store
            // 
            this.Store.Caption = "Store";
            this.Store.FieldName = "Store";
            this.Store.Name = "Store";
            this.Store.Visible = true;
            this.Store.VisibleIndex = 1;
            // 
            // StoreStatus
            // 
            this.StoreStatus.Caption = "StoreStatus";
            this.StoreStatus.FieldName = "StoreStatus";
            this.StoreStatus.Name = "StoreStatus";
            this.StoreStatus.Visible = true;
            this.StoreStatus.VisibleIndex = 2;
            // 
            // WStatus
            // 
            this.WStatus.Caption = "WarehouseStatus";
            this.WStatus.FieldName = "WarehouseStatus";
            this.WStatus.Name = "WStatus";
            // 
            // WarhouseID
            // 
            this.WarhouseID.Caption = "ID";
            this.WarhouseID.FieldName = "ID";
            this.WarhouseID.Name = "WarhouseID";
            // 
            // StoreID
            // 
            this.StoreID.Caption = "StoreID";
            this.StoreID.FieldName = "StoreID";
            this.StoreID.Name = "StoreID";
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.CustomizationFormText = "Use this form to freeze receive / issue transactions from warehouses. Use the che" +
    "ck box to change the status of a warehouse";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.simpleLabelItem1.Size = new System.Drawing.Size(695, 40);
            this.simpleLabelItem1.Text = "Use this form to freeze receive / issue transactions from warehouses. Use the che" +
    "ck box to change the status of a warehouse";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(50, 20);
            // 
            // WarehouseFreezeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 490);
            this.Controls.Add(this.layoutControl1);
            this.Name = "WarehouseFreezeForm";
            this.Text = "Freeze / Release Warehoue Transactions";
            this.Load += new System.EventHandler(this.WarehouseFreezeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxFreezChoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWarehouseFreez)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridManageInvetoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutFreezChoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn Cluster;
        private DevExpress.XtraGrid.Columns.GridColumn WarehouseName;
        private DevExpress.XtraGrid.Columns.GridColumn Store;
        private DevExpress.XtraGrid.Columns.GridColumn StoreStatus;
        private DevExpress.XtraGrid.Columns.GridColumn WStatus;
        private DevExpress.XtraGrid.Columns.GridColumn WarhouseID;
        private DevExpress.XtraGrid.Columns.GridColumn StoreID;
        private DevExpress.XtraGrid.GridControl grdWarehouseFreez;
        private DevExpress.XtraGrid.Views.Grid.GridView gridManageInvetoryView;
        private DevExpress.XtraGrid.Columns.GridColumn LocationName;
        private DevExpress.XtraGrid.Columns.GridColumn Status;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ComboBoxEdit ComboBoxFreezChoice;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem lyoutFreezChoice;
        private DevExpress.XtraGrid.Columns.GridColumn LocationID;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;

    }
}