namespace HCMIS.Desktop.Forms.WorkFlow
{
    partial class ClientStatusViewForm
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkEditActive = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.chkEditShowInProcess = new DevExpress.XtraEditors.CheckEdit();
            this.lkActive = new DevExpress.XtraEditors.LookUpEdit();
            this.lkOwnership = new DevExpress.XtraEditors.LookUpEdit();
            this.lkWoreda = new DevExpress.XtraEditors.LookUpEdit();
            this.lkZone = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.grdClientStatus = new DevExpress.XtraGrid.GridControl();
            this.grdViewClientStatus = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditAgreement = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkEditInprocess = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lkRegion = new DevExpress.XtraEditors.LookUpEdit();
            this.lkType = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAddReceivingUnit = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditShowInProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkOwnership.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkWoreda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkZone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClientStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewClientStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditInprocess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkRegion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // colActive
            // 
            this.colActive.Caption = "Active";
            this.colActive.ColumnEdit = this.chkEditActive;
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.OptionsColumn.AllowEdit = false;
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 4;
            this.colActive.Width = 181;
            // 
            // chkEditActive
            // 
            this.chkEditActive.AutoHeight = false;
            this.chkEditActive.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.chkEditActive.Name = "chkEditActive";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkEditShowInProcess);
            this.layoutControl1.Controls.Add(this.lkActive);
            this.layoutControl1.Controls.Add(this.lkOwnership);
            this.layoutControl1.Controls.Add(this.lkWoreda);
            this.layoutControl1.Controls.Add(this.lkZone);
            this.layoutControl1.Controls.Add(this.layoutControl2);
            this.layoutControl1.Controls.Add(this.lkRegion);
            this.layoutControl1.Controls.Add(this.lkType);
            this.layoutControl1.Controls.Add(this.btnAddReceivingUnit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(243, 254, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1123, 575);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkEditShowInProcess
            // 
            this.chkEditShowInProcess.Location = new System.Drawing.Point(747, 4);
            this.chkEditShowInProcess.Name = "chkEditShowInProcess";
            this.chkEditShowInProcess.Properties.Caption = "Show in process only";
            this.chkEditShowInProcess.Size = new System.Drawing.Size(372, 19);
            this.chkEditShowInProcess.StyleController = this.layoutControl1;
            this.chkEditShowInProcess.TabIndex = 11;
            this.chkEditShowInProcess.CheckedChanged += new System.EventHandler(this.chkEditShowInProcess_CheckedChanged);
            // 
            // lkActive
            // 
            this.lkActive.EnterMoveNextControl = true;
            this.lkActive.Location = new System.Drawing.Point(473, 52);
            this.lkActive.Name = "lkActive";
            this.lkActive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkActive.Properties.DropDownRows = 3;
            this.lkActive.Properties.NullText = "";
            this.lkActive.Properties.ShowFooter = false;
            this.lkActive.Properties.ShowHeader = false;
            this.lkActive.Size = new System.Drawing.Size(270, 20);
            this.lkActive.StyleController = this.layoutControl1;
            this.lkActive.TabIndex = 10;
            this.lkActive.EditValueChanged += new System.EventHandler(this.lkActive_EditValueChanged);
            // 
            // lkOwnership
            // 
            this.lkOwnership.EnterMoveNextControl = true;
            this.lkOwnership.Location = new System.Drawing.Point(473, 4);
            this.lkOwnership.Name = "lkOwnership";
            this.lkOwnership.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkOwnership.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkOwnership.Properties.DisplayMember = "Name";
            this.lkOwnership.Properties.NullText = "";
            this.lkOwnership.Properties.ShowFooter = false;
            this.lkOwnership.Properties.ShowHeader = false;
            this.lkOwnership.Properties.ValueMember = "ID";
            this.lkOwnership.Size = new System.Drawing.Size(270, 20);
            this.lkOwnership.StyleController = this.layoutControl1;
            this.lkOwnership.TabIndex = 9;
            this.lkOwnership.ToolTip = "Select Ownership type";
            this.lkOwnership.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.lkOwnership.ToolTipTitle = "Filter...";
            this.lkOwnership.EditValueChanged += new System.EventHandler(this.lkOwnership_EditValueChanged);
            // 
            // lkWoreda
            // 
            this.lkWoreda.EnterMoveNextControl = true;
            this.lkWoreda.Location = new System.Drawing.Point(86, 52);
            this.lkWoreda.Name = "lkWoreda";
            this.lkWoreda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkWoreda.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("WoredaName", "Woreda Name", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Count", "Count")});
            this.lkWoreda.Properties.DisplayMember = "Count";
            this.lkWoreda.Properties.NullText = "Select Woreda";
            this.lkWoreda.Properties.ShowFooter = false;
            this.lkWoreda.Properties.ShowHeader = false;
            this.lkWoreda.Properties.ValueMember = "ID";
            this.lkWoreda.Size = new System.Drawing.Size(301, 20);
            this.lkWoreda.StyleController = this.layoutControl1;
            this.lkWoreda.TabIndex = 7;
            this.lkWoreda.ToolTip = "Select woreda, the number of facilities in that Woreda is written next to it.";
            this.lkWoreda.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.lkWoreda.ToolTipTitle = "Filter";
            this.lkWoreda.EditValueChanged += new System.EventHandler(this.lkWoreda_EditValueChanged);
            // 
            // lkZone
            // 
            this.lkZone.EnterMoveNextControl = true;
            this.lkZone.Location = new System.Drawing.Point(86, 28);
            this.lkZone.Name = "lkZone";
            this.lkZone.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkZone.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ZoneName", "Zone Name", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Count", "Count")});
            this.lkZone.Properties.DisplayMember = "Count";
            this.lkZone.Properties.NullText = "Select Zone";
            this.lkZone.Properties.ShowFooter = false;
            this.lkZone.Properties.ShowHeader = false;
            this.lkZone.Properties.ValueMember = "ID";
            this.lkZone.Size = new System.Drawing.Size(301, 20);
            this.lkZone.StyleController = this.layoutControl1;
            this.lkZone.TabIndex = 6;
            this.lkZone.ToolTip = "Select Zone, the number of facilities in that zone is written next to it.";
            this.lkZone.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.lkZone.ToolTipTitle = "Filter";
            this.lkZone.EditValueChanged += new System.EventHandler(this.lkZone_EditValueChanged);
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.grdClientStatus);
            this.layoutControl2.Location = new System.Drawing.Point(4, 76);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(251, 0, 250, 350);
            this.layoutControl2.Root = this.Root;
            this.layoutControl2.Size = new System.Drawing.Size(1115, 495);
            this.layoutControl2.TabIndex = 4;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // grdClientStatus
            // 
            this.grdClientStatus.Location = new System.Drawing.Point(12, 12);
            this.grdClientStatus.MainView = this.grdViewClientStatus;
            this.grdClientStatus.Name = "grdClientStatus";
            this.grdClientStatus.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkEditInprocess,
            this.chkEditActive});
            this.grdClientStatus.Size = new System.Drawing.Size(1091, 471);
            this.grdClientStatus.TabIndex = 4;
            this.grdClientStatus.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewClientStatus});
            // 
            // grdViewClientStatus
            // 
            this.grdViewClientStatus.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdViewClientStatus.Appearance.Empty.Options.UseBackColor = true;
            this.grdViewClientStatus.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNo,
            this.colName,
            this.colType,
            this.colCreditAgreement,
            this.colActive,
            this.colInProcess,
            this.colID});
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colActive;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = false;
            this.grdViewClientStatus.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.grdViewClientStatus.GridControl = this.grdClientStatus;
            this.grdViewClientStatus.Name = "grdViewClientStatus";
            this.grdViewClientStatus.OptionsCustomization.AllowColumnMoving = false;
            this.grdViewClientStatus.OptionsCustomization.AllowGroup = false;
            this.grdViewClientStatus.OptionsView.ShowGroupPanel = false;
            this.grdViewClientStatus.CustomDrawEmptyForeground += new DevExpress.XtraGrid.Views.Base.CustomDrawEventHandler(this.grdViewClientStatus_CustomDrawEmptyForeground);
            this.grdViewClientStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdViewClientStatus_KeyPress);
            // 
            // colNo
            // 
            this.colNo.Caption = "No";
            this.colNo.FieldName = "No";
            this.colNo.Name = "colNo";
            this.colNo.OptionsColumn.AllowEdit = false;
            this.colNo.Visible = true;
            this.colNo.VisibleIndex = 0;
            this.colNo.Width = 42;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 243;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsColumn.AllowEdit = false;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 2;
            this.colType.Width = 204;
            // 
            // colCreditAgreement
            // 
            this.colCreditAgreement.Caption = "Credit Agreement";
            this.colCreditAgreement.Name = "colCreditAgreement";
            this.colCreditAgreement.OptionsColumn.AllowEdit = false;
            this.colCreditAgreement.Visible = true;
            this.colCreditAgreement.VisibleIndex = 3;
            this.colCreditAgreement.Width = 117;
            // 
            // colInProcess
            // 
            this.colInProcess.Caption = "In Process";
            this.colInProcess.ColumnEdit = this.chkEditInprocess;
            this.colInProcess.FieldName = "InProcess";
            this.colInProcess.Name = "colInProcess";
            this.colInProcess.Visible = true;
            this.colInProcess.VisibleIndex = 5;
            this.colInProcess.Width = 286;
            // 
            // chkEditInprocess
            // 
            this.chkEditInprocess.AutoHeight = false;
            this.chkEditInprocess.Name = "chkEditInprocess";
            this.chkEditInprocess.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkEditInprocess.PictureChecked = global::HCMIS.Desktop.Properties.Resources.Check;
            this.chkEditInprocess.PictureGrayed = global::HCMIS.Desktop.Properties.Resources.cross;
            this.chkEditInprocess.PictureUnchecked = global::HCMIS.Desktop.Properties.Resources.cross;
            this.chkEditInprocess.CheckedChanged += new System.EventHandler(this.chkEditInprocess_CheckedChanged);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1115, 495);
            this.Root.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.grdClientStatus;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1095, 475);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // lkRegion
            // 
            this.lkRegion.EditValue = "<null>";
            this.lkRegion.EnterMoveNextControl = true;
            this.lkRegion.Location = new System.Drawing.Point(86, 4);
            this.lkRegion.Name = "lkRegion";
            this.lkRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkRegion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RegionName", "Region Name")});
            this.lkRegion.Properties.DisplayMember = "RegionName";
            this.lkRegion.Properties.NullText = "";
            this.lkRegion.Properties.ShowFooter = false;
            this.lkRegion.Properties.ShowHeader = false;
            this.lkRegion.Properties.ValueMember = "ID";
            this.lkRegion.Size = new System.Drawing.Size(301, 20);
            this.lkRegion.StyleController = this.layoutControl1;
            this.lkRegion.TabIndex = 5;
            this.lkRegion.EditValueChanged += new System.EventHandler(this.lkRegion_EditValueChanged);
            // 
            // lkType
            // 
            this.lkType.EnterMoveNextControl = true;
            this.lkType.Location = new System.Drawing.Point(473, 28);
            this.lkType.Name = "lkType";
            this.lkType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkType.Properties.DisplayMember = "Name";
            this.lkType.Properties.NullText = "";
            this.lkType.Properties.ShowFooter = false;
            this.lkType.Properties.ShowHeader = false;
            this.lkType.Properties.ValueMember = "ID";
            this.lkType.Size = new System.Drawing.Size(270, 20);
            this.lkType.StyleController = this.layoutControl1;
            this.lkType.TabIndex = 8;
            this.lkType.ToolTip = "Select Facility Type,";
            this.lkType.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.lkType.ToolTipTitle = "Filter...";
            this.lkType.EditValueChanged += new System.EventHandler(this.lkType_EditValueChanged);
            // 
            // btnAddReceivingUnit
            // 
            this.btnAddReceivingUnit.Image = global::HCMIS.Desktop.Properties.Resources.pencil_go;
            this.btnAddReceivingUnit.Location = new System.Drawing.Point(869, 50);
            this.btnAddReceivingUnit.Name = "btnAddReceivingUnit";
            this.btnAddReceivingUnit.Size = new System.Drawing.Size(151, 22);
            this.btnAddReceivingUnit.StyleController = this.layoutControl1;
            this.btnAddReceivingUnit.TabIndex = 12;
            this.btnAddReceivingUnit.Text = "Search Location by Name";
            this.btnAddReceivingUnit.Click += new System.EventHandler(this.btnAddReceivingUnit_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem3,
            this.emptySpaceItem2,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1123, 575);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.layoutControl2;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1119, 499);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkRegion;
            this.layoutControlItem2.CustomizationFormText = "Region";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(387, 24);
            this.layoutControlItem2.Text = "Region";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.lkWoreda;
            this.layoutControlItem4.CustomizationFormText = "Woreda";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(387, 24);
            this.layoutControlItem4.Text = "Woreda";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.lkZone;
            this.layoutControlItem3.CustomizationFormText = "Zone";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(387, 24);
            this.layoutControlItem3.Text = "Zone";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.lkType;
            this.layoutControlItem5.CustomizationFormText = "Type";
            this.layoutControlItem5.Location = new System.Drawing.Point(387, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(356, 24);
            this.layoutControlItem5.Text = "Facility Type";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lkOwnership;
            this.layoutControlItem6.CustomizationFormText = "Ownership";
            this.layoutControlItem6.Location = new System.Drawing.Point(387, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(356, 24);
            this.layoutControlItem6.Text = "Ownership Type";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(78, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.chkEditShowInProcess;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(743, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(376, 23);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnAddReceivingUnit;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(865, 46);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(155, 26);
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(743, 23);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(122, 49);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(1020, 23);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(99, 49);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lkActive;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(387, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(356, 24);
            this.layoutControlItem7.Text = "Show";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(78, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(865, 23);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(155, 23);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // ClientStatusViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 575);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ClientStatusViewForm";
            this.Text = "Client Status View";
            this.Load += new System.EventHandler(this.ClientStatusViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkEditActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkEditShowInProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkOwnership.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkWoreda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkZone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdClientStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewClientStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEditInprocess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkRegion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit lkWoreda;
        private DevExpress.XtraEditors.LookUpEdit lkZone;
        private DevExpress.XtraEditors.LookUpEdit lkRegion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.LookUpEdit lkOwnership;
        private DevExpress.XtraEditors.LookUpEdit lkType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl grdClientStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewClientStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn colNo;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditAgreement;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colInProcess;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEditInprocess;
        private DevExpress.XtraEditors.LookUpEdit lkActive;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkEditActive;
        private DevExpress.XtraEditors.CheckEdit chkEditShowInProcess;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnAddReceivingUnit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
    }
}