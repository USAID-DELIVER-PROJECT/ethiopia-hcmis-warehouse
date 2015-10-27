namespace HCMIS.Desktop.Forms.Reports
{
    partial class IssueSTVInvoiceDetail
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
            this.grdSTVInvoiceDetail = new DevExpress.XtraGrid.GridControl();
            this.grvViewSTVInvoiceDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatchNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.lblDescription = new DevExpress.XtraLayout.SimpleLabelItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdSTVInvoiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvViewSTVInvoiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSTVInvoiceDetail
            // 
            this.grdSTVInvoiceDetail.Location = new System.Drawing.Point(12, 35);
            this.grdSTVInvoiceDetail.MainView = this.grvViewSTVInvoiceDetail;
            this.grdSTVInvoiceDetail.Name = "grdSTVInvoiceDetail";
            this.grdSTVInvoiceDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.grdSTVInvoiceDetail.Size = new System.Drawing.Size(828, 330);
            this.grdSTVInvoiceDetail.TabIndex = 18;
            this.grdSTVInvoiceDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvViewSTVInvoiceDetail});
            // 
            // grvViewSTVInvoiceDetail
            // 
            this.grvViewSTVInvoiceDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colActivity,
            this.colFullItemName,
            this.colUnit,
            this.colManufacturer,
            this.colBatchNo,
            this.colQty,
            this.colExpDate});
            this.grvViewSTVInvoiceDetail.GridControl = this.grdSTVInvoiceDetail;
            this.grvViewSTVInvoiceDetail.Name = "grvViewSTVInvoiceDetail";
            this.grvViewSTVInvoiceDetail.OptionsView.ShowGroupPanel = false;
            // 
            // colActivity
            // 
            this.colActivity.Caption = "Activity";
            this.colActivity.FieldName = "ActivityName";
            this.colActivity.Name = "colActivity";
            // 
            // colFullItemName
            // 
            this.colFullItemName.Caption = "Item";
            this.colFullItemName.FieldName = "FullItemName";
            this.colFullItemName.Name = "colFullItemName";
            this.colFullItemName.OptionsColumn.AllowEdit = false;
            this.colFullItemName.Visible = true;
            this.colFullItemName.VisibleIndex = 0;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Unit";
            this.colUnit.FieldName = "UnitName";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 2;
            // 
            // colManufacturer
            // 
            this.colManufacturer.Caption = "Manufacturer";
            this.colManufacturer.FieldName = "Manufacturer";
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.OptionsColumn.AllowEdit = false;
            this.colManufacturer.Visible = true;
            this.colManufacturer.VisibleIndex = 3;
            // 
            // colBatchNo
            // 
            this.colBatchNo.Caption = "Batch No";
            this.colBatchNo.FieldName = "BatchNo";
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.OptionsColumn.AllowEdit = false;
            this.colBatchNo.Visible = true;
            this.colBatchNo.VisibleIndex = 4;
            // 
            // colQty
            // 
            this.colQty.Caption = "Qty";
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 1;
            // 
            // colExpDate
            // 
            this.colExpDate.Caption = "Expiry Date";
            this.colExpDate.FieldName = "ExpDate";
            this.colExpDate.Name = "colExpDate";
            this.colExpDate.OptionsColumn.AllowEdit = false;
            this.colExpDate.Visible = true;
            this.colExpDate.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "ID";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdSTVInvoiceDetail);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(510, 218, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(852, 377);
            this.layoutControl1.TabIndex = 19;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.lblDescription});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(852, 377);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdSTVInvoiceDetail;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 23);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(832, 334);
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
            this.emptySpaceItem1.Location = new System.Drawing.Point(606, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(226, 23);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // lblDescription
            // 
            this.lblDescription.AllowHotTrack = false;
            this.lblDescription.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescription.AppearanceItemCaption.Options.UseFont = true;
            this.lblDescription.CustomizationFormText = "[Description]";
            this.lblDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(606, 23);
            this.lblDescription.Text = "[Description]";
            this.lblDescription.TextSize = new System.Drawing.Size(106, 19);
            // 
            // IssueSTVInvoiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 377);
            this.Controls.Add(this.layoutControl1);
            this.Name = "IssueSTVInvoiceDetail";
            this.Text = "STV/Invoice Detail";
            this.Load += new System.EventHandler(this.IssueSTVInvoiceDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSTVInvoiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvViewSTVInvoiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSTVInvoiceDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvViewSTVInvoiceDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colFullItemName;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colManufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn colBatchNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraLayout.SimpleLabelItem lblDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colExpDate;
    }
}