namespace HCMIS.Desktop.Forms.Reports
{
    partial class AnnualRevenueReport
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnGo = new DevExpress.XtraEditors.SimpleButton();
            this.dEFrom = new DevExpress.XtraEditors.DateEdit();
            this.dEditTo = new DevExpress.XtraEditors.DateEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridAnnualRevenue = new DevExpress.XtraGrid.GridControl();
            this.gridViewAnnualRevenue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColInstitution = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColInstitutionType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColOwnership = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColRegion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColZone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColWoreda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColTinNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColIssuedAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lcRevenueReport = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnualRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAnnualRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRevenueReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnGo);
            this.layoutControl1.Controls.Add(this.dEFrom);
            this.layoutControl1.Controls.Add(this.dEditTo);
            this.layoutControl1.Controls.Add(this.btnExport);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.gridAnnualRevenue);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(414, 309, 250, 350);
            this.layoutControl1.Root = this.lcRevenueReport;
            this.layoutControl1.Size = new System.Drawing.Size(952, 483);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnGo
            // 
            this.btnGo.Image = global::HCMIS.Desktop.Properties.Resources.Go;
            this.btnGo.Location = new System.Drawing.Point(614, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(79, 22);
            this.btnGo.StyleController = this.layoutControl1;
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Go";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dEFrom
            // 
            this.dEFrom.EditValue = null;
            this.dEFrom.Location = new System.Drawing.Point(179, 12);
            this.dEFrom.Name = "dEFrom";
            this.dEFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dEFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dEFrom.Size = new System.Drawing.Size(187, 20);
            this.dEFrom.StyleController = this.layoutControl1;
            this.dEFrom.TabIndex = 8;
            // 
            // dEditTo
            // 
            this.dEditTo.EditValue = null;
            this.dEditTo.Location = new System.Drawing.Point(401, 12);
            this.dEditTo.Name = "dEditTo";
            this.dEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dEditTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dEditTo.Size = new System.Drawing.Size(209, 20);
            this.dEditTo.StyleController = this.layoutControl1;
            this.dEditTo.TabIndex = 7;
            // 
            // btnExport
            // 
            this.btnExport.Image = global::HCMIS.Desktop.Properties.Resources.Excel_Icon;
            this.btnExport.Location = new System.Drawing.Point(771, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 22);
            this.btnExport.StyleController = this.layoutControl1;
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::HCMIS.Desktop.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(854, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gridAnnualRevenue
            // 
            this.gridAnnualRevenue.Location = new System.Drawing.Point(12, 38);
            this.gridAnnualRevenue.MainView = this.gridViewAnnualRevenue;
            this.gridAnnualRevenue.Name = "gridAnnualRevenue";
            this.gridAnnualRevenue.Size = new System.Drawing.Size(928, 433);
            this.gridAnnualRevenue.TabIndex = 4;
            this.gridAnnualRevenue.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAnnualRevenue});
            // 
            // gridViewAnnualRevenue
            // 
            this.gridViewAnnualRevenue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColInstitution,
            this.gridColInstitutionType,
            this.gridColOwnership,
            this.gridColRegion,
            this.gridColZone,
            this.gridColWoreda,
            this.gridColPhone,
            this.gridColTinNo,
            this.gridColIssuedAmount});
            this.gridViewAnnualRevenue.GridControl = this.gridAnnualRevenue;
            this.gridViewAnnualRevenue.Name = "gridViewAnnualRevenue";
            this.gridViewAnnualRevenue.OptionsBehavior.Editable = false;
            this.gridViewAnnualRevenue.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewAnnualRevenue.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewAnnualRevenue.OptionsCustomization.AllowFilter = false;
            this.gridViewAnnualRevenue.OptionsCustomization.AllowGroup = false;
            this.gridViewAnnualRevenue.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridViewAnnualRevenue.OptionsCustomization.AllowSort = false;
            this.gridViewAnnualRevenue.OptionsMenu.EnableColumnMenu = false;
            this.gridViewAnnualRevenue.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewAnnualRevenue.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewAnnualRevenue.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridViewAnnualRevenue.OptionsView.ShowGroupPanel = false;
            // 
            // gridColInstitution
            // 
            this.gridColInstitution.Caption = "Institution";
            this.gridColInstitution.FieldName = "Institution";
            this.gridColInstitution.Name = "gridColInstitution";
            this.gridColInstitution.Visible = true;
            this.gridColInstitution.VisibleIndex = 0;
            this.gridColInstitution.Width = 250;
            // 
            // gridColInstitutionType
            // 
            this.gridColInstitutionType.Caption = "Institution Type";
            this.gridColInstitutionType.FieldName = "InstitutionType";
            this.gridColInstitutionType.Name = "gridColInstitutionType";
            this.gridColInstitutionType.Visible = true;
            this.gridColInstitutionType.VisibleIndex = 1;
            this.gridColInstitutionType.Width = 100;
            // 
            // gridColOwnership
            // 
            this.gridColOwnership.Caption = "Ownership";
            this.gridColOwnership.FieldName = "Ownership";
            this.gridColOwnership.Name = "gridColOwnership";
            this.gridColOwnership.Visible = true;
            this.gridColOwnership.VisibleIndex = 2;
            this.gridColOwnership.Width = 100;
            // 
            // gridColRegion
            // 
            this.gridColRegion.Caption = "Region";
            this.gridColRegion.FieldName = "Region";
            this.gridColRegion.Name = "gridColRegion";
            this.gridColRegion.Visible = true;
            this.gridColRegion.VisibleIndex = 3;
            // 
            // gridColZone
            // 
            this.gridColZone.Caption = "Zone";
            this.gridColZone.FieldName = "Zone";
            this.gridColZone.Name = "gridColZone";
            this.gridColZone.Visible = true;
            this.gridColZone.VisibleIndex = 4;
            this.gridColZone.Width = 100;
            // 
            // gridColWoreda
            // 
            this.gridColWoreda.Caption = "Woreda";
            this.gridColWoreda.FieldName = "Woreda";
            this.gridColWoreda.Name = "gridColWoreda";
            this.gridColWoreda.Visible = true;
            this.gridColWoreda.VisibleIndex = 5;
            this.gridColWoreda.Width = 100;
            // 
            // gridColPhone
            // 
            this.gridColPhone.Caption = "Phone";
            this.gridColPhone.FieldName = "Phone";
            this.gridColPhone.Name = "gridColPhone";
            this.gridColPhone.Visible = true;
            this.gridColPhone.VisibleIndex = 6;
            this.gridColPhone.Width = 81;
            // 
            // gridColTinNo
            // 
            this.gridColTinNo.Caption = "TinNo";
            this.gridColTinNo.FieldName = "TinNo";
            this.gridColTinNo.Name = "gridColTinNo";
            this.gridColTinNo.Visible = true;
            this.gridColTinNo.VisibleIndex = 7;
            this.gridColTinNo.Width = 81;
            // 
            // gridColIssuedAmount
            // 
            this.gridColIssuedAmount.Caption = "Issued Amount";
            this.gridColIssuedAmount.DisplayFormat.FormatString = "#,###,###";
            this.gridColIssuedAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColIssuedAmount.FieldName = "IssuedAmount";
            this.gridColIssuedAmount.Name = "gridColIssuedAmount";
            this.gridColIssuedAmount.Visible = true;
            this.gridColIssuedAmount.VisibleIndex = 8;
            this.gridColIssuedAmount.Width = 98;
            // 
            // lcRevenueReport
            // 
            this.lcRevenueReport.CustomizationFormText = "Root";
            this.lcRevenueReport.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcRevenueReport.GroupBordersVisible = false;
            this.lcRevenueReport.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem6});
            this.lcRevenueReport.Location = new System.Drawing.Point(0, 0);
            this.lcRevenueReport.Name = "Root";
            this.lcRevenueReport.Size = new System.Drawing.Size(952, 483);
            this.lcRevenueReport.Text = "Root";
            this.lcRevenueReport.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridAnnualRevenue;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(932, 437);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPrint;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(842, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnExport;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(759, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(136, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dEditTo;
            this.layoutControlItem4.CustomizationFormText = "To:";
            this.layoutControlItem4.Location = new System.Drawing.Point(358, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(244, 26);
            this.layoutControlItem4.Text = "To:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(28, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dEFrom;
            this.layoutControlItem5.CustomizationFormText = "From:";
            this.layoutControlItem5.Location = new System.Drawing.Point(136, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(222, 26);
            this.layoutControlItem5.Text = "From:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(28, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(685, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(74, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnGo;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(602, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(83, 26);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // AnnualRevenueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 483);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AnnualRevenueReport";
            this.Text = "AnnualRevenueReport";
            this.Load += new System.EventHandler(this.AnnualRevenueReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dEFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAnnualRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAnnualRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcRevenueReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.GridControl gridAnnualRevenue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAnnualRevenue;
        private DevExpress.XtraLayout.LayoutControlGroup lcRevenueReport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInstitution;
        private DevExpress.XtraGrid.Columns.GridColumn gridColInstitutionType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColZone;
        private DevExpress.XtraGrid.Columns.GridColumn gridColWoreda;
        private DevExpress.XtraGrid.Columns.GridColumn gridColOwnership;
        private DevExpress.XtraGrid.Columns.GridColumn gridColPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gridColTinNo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColIssuedAmount;
        private DevExpress.XtraGrid.Columns.GridColumn gridColRegion;
        private DevExpress.XtraEditors.SimpleButton btnGo;
        private DevExpress.XtraEditors.DateEdit dEFrom;
        private DevExpress.XtraEditors.DateEdit dEditTo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;

    }
}