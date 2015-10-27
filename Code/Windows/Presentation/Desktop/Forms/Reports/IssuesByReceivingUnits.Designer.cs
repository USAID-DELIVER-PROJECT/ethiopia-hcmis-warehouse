using DevExpress.XtraEditors;
namespace HCMIS.Desktop.Forms.Reports
{
    partial class IssuesByReceivingUnit
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
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnload = new DevExpress.XtraEditors.SimpleButton();
            this.btnFilter = new DevExpress.XtraEditors.SimpleButton();
            this.lkCategories = new DevExpress.XtraEditors.LookUpEdit();
            this.chkExcludeNIssued = new DevExpress.XtraEditors.CheckEdit();
            this.chkExcludeNReceived = new DevExpress.XtraEditors.CheckEdit();
            this.cboStores = new DevExpress.XtraEditors.LookUpEdit();
            this.lkRoutes = new DevExpress.XtraEditors.LookUpEdit();
            this.xpButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dtTo = new CalendarLib.DateTimePickerEx();
            this.xpButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.dtFrom = new CalendarLib.DateTimePickerEx();
            this.gridDetailReport = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.lblState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkCategories.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcludeNIssued.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcludeNReceived.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkRoutes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(109, 36);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(91, 20);
            this.txtItemName.StyleController = this.layoutControl1;
            this.txtItemName.TabIndex = 43;
            this.txtItemName.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnload);
            this.layoutControl1.Controls.Add(this.btnFilter);
            this.layoutControl1.Controls.Add(this.lkCategories);
            this.layoutControl1.Controls.Add(this.chkExcludeNIssued);
            this.layoutControl1.Controls.Add(this.chkExcludeNReceived);
            this.layoutControl1.Controls.Add(this.cboStores);
            this.layoutControl1.Controls.Add(this.lkRoutes);
            this.layoutControl1.Controls.Add(this.xpButton1);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.xpButton2);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.gridDetailReport);
            this.layoutControl1.Controls.Add(this.txtItemName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(218, 260, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1148, 432);
            this.layoutControl1.TabIndex = 39;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(962, 12);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(86, 22);
            this.btnload.StyleController = this.layoutControl1;
            this.btnload.TabIndex = 52;
            this.btnload.Text = "Load";
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(962, 54);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(86, 22);
            this.btnFilter.StyleController = this.layoutControl1;
            this.btnFilter.TabIndex = 50;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // lkCategories
            // 
            this.lkCategories.Location = new System.Drawing.Point(109, 12);
            this.lkCategories.Name = "lkCategories";
            this.lkCategories.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCategories.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkCategories.Properties.DisplayMember = "Name";
            this.lkCategories.Properties.ValueMember = "ID";
            this.lkCategories.Size = new System.Drawing.Size(173, 20);
            this.lkCategories.StyleController = this.layoutControl1;
            this.lkCategories.TabIndex = 49;
            this.lkCategories.EditValueChanged += new System.EventHandler(this.lkCategories_EditValueChanged);
            // 
            // chkExcludeNIssued
            // 
            this.chkExcludeNIssued.Location = new System.Drawing.Point(366, 57);
            this.chkExcludeNIssued.Name = "chkExcludeNIssued";
            this.chkExcludeNIssued.Properties.Caption = "Exclude Never Issued";
            this.chkExcludeNIssued.Size = new System.Drawing.Size(126, 19);
            this.chkExcludeNIssued.StyleController = this.layoutControl1;
            this.chkExcludeNIssued.TabIndex = 48;
            this.chkExcludeNIssued.EditValueChanged += new System.EventHandler(this.chkExclude_EditValueChanged);
            // 
            // chkExcludeNReceived
            // 
            this.chkExcludeNReceived.Location = new System.Drawing.Point(204, 57);
            this.chkExcludeNReceived.Name = "chkExcludeNReceived";
            this.chkExcludeNReceived.Properties.Caption = "Exclude Never Received";
            this.chkExcludeNReceived.Size = new System.Drawing.Size(158, 19);
            this.chkExcludeNReceived.StyleController = this.layoutControl1;
            this.chkExcludeNReceived.TabIndex = 47;
            this.chkExcludeNReceived.EditValueChanged += new System.EventHandler(this.chkExclude_EditValueChanged);
            // 
            // cboStores
            // 
            this.cboStores.EditValue = "1";
            this.cboStores.Location = new System.Drawing.Point(687, 12);
            this.cboStores.Name = "cboStores";
            this.cboStores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboStores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullActivityName", "StoreName")});
            this.cboStores.Properties.DisplayMember = "FullActivityName";
            this.cboStores.Properties.NullText = "";
            this.cboStores.Properties.ValueMember = "ID";
            this.cboStores.Size = new System.Drawing.Size(151, 20);
            this.cboStores.StyleController = this.layoutControl1;
            this.cboStores.TabIndex = 46;
            // 
            // lkRoutes
            // 
            this.lkRoutes.Location = new System.Drawing.Point(395, 12);
            this.lkRoutes.Name = "lkRoutes";
            this.lkRoutes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkRoutes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkRoutes.Properties.DisplayMember = "Name";
            this.lkRoutes.Properties.NullText = "";
            this.lkRoutes.Properties.ValueMember = "RouteID";
            this.lkRoutes.Size = new System.Drawing.Size(191, 20);
            this.lkRoutes.StyleController = this.layoutControl1;
            this.lkRoutes.TabIndex = 45;
            this.lkRoutes.EditValueChanged += new System.EventHandler(this.lkRoutes_EditValueChanged);
            // 
            // xpButton1
            // 
            this.xpButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xpButton1.Image = global::HCMIS.Desktop.Properties.Resources.printer;
            this.xpButton1.Location = new System.Drawing.Point(1052, 54);
            this.xpButton1.Name = "xpButton1";
            this.xpButton1.Size = new System.Drawing.Size(84, 22);
            this.xpButton1.StyleController = this.layoutControl1;
            this.xpButton1.TabIndex = 25;
            this.xpButton1.Text = "Print";
            this.xpButton1.Click += new System.EventHandler(this.xpButton1_Click);
            // 
            // dtTo
            // 
            this.dtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTo.CalendarFont = new System.Drawing.Font("Nyala", 9.75F);
            this.dtTo.CalendarForeColor = System.Drawing.Color.Black;
            this.dtTo.DayOfWeekCharacters = 2;
            this.dtTo.ForeColor = System.Drawing.Color.Black;
            this.dtTo.Location = new System.Drawing.Point(836, 56);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(112, 20);
            this.dtTo.TabIndex = 12;
            this.dtTo.Value = new System.DateTime(2014, 11, 6, 0, 0, 0, 0);
            this.dtTo.ValueChanged += new System.EventHandler(this.btnSearchByDate_Click);
            // 
            // xpButton2
            // 
            this.xpButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xpButton2.Image = global::HCMIS.Desktop.Properties.Resources.MS_Excel;
            this.xpButton2.Location = new System.Drawing.Point(1052, 12);
            this.xpButton2.Name = "xpButton2";
            this.xpButton2.Size = new System.Drawing.Size(84, 38);
            this.xpButton2.StyleController = this.layoutControl1;
            this.xpButton2.TabIndex = 26;
            this.xpButton2.Text = "Export";
            this.xpButton2.Click += new System.EventHandler(this.xpButton2_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFrom.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtFrom.CalendarForeColor = System.Drawing.Color.Black;
            this.dtFrom.DayOfWeekCharacters = 1;
            this.dtFrom.ForeColor = System.Drawing.Color.Black;
            this.dtFrom.Location = new System.Drawing.Point(608, 56);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.PopUpFontSize = 9.75F;
            this.dtFrom.Size = new System.Drawing.Size(127, 20);
            this.dtFrom.TabIndex = 12;
            this.dtFrom.Value = new System.DateTime(2014, 11, 6, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.btnSearchByDate_Click);
            // 
            // gridDetailReport
            // 
            this.gridDetailReport.Location = new System.Drawing.Point(12, 80);
            this.gridDetailReport.MainView = this.gridView1;
            this.gridDetailReport.Name = "gridDetailReport";
            this.gridDetailReport.Size = new System.Drawing.Size(1124, 340);
            this.gridDetailReport.TabIndex = 38;
            this.gridDetailReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridDetailReport;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem3,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem14,
            this.emptySpaceItem3,
            this.layoutControlItem11,
            this.emptySpaceItem1,
            this.layoutControlItem8,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.emptySpaceItem4,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem7,
            this.emptySpaceItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1148, 432);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridDetailReport;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 68);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1128, 344);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.xpButton2;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(1040, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(88, 42);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.xpButton1;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(1040, 42);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(88, 26);
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.dtTo;
            this.layoutControlItem12.CustomizationFormText = "To";
            this.layoutControlItem12.Location = new System.Drawing.Point(727, 44);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(213, 24);
            this.layoutControlItem12.Text = "To";
            this.layoutControlItem12.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.lkRoutes;
            this.layoutControlItem13.CustomizationFormText = "Route";
            this.layoutControlItem13.Location = new System.Drawing.Point(286, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(292, 24);
            this.layoutControlItem13.Text = "Route";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(94, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cboStores;
            this.layoutControlItem3.CustomizationFormText = "Stores";
            this.layoutControlItem3.Location = new System.Drawing.Point(578, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(252, 24);
            this.layoutControlItem3.Text = "Stores";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(484, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(15, 44);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkExcludeNReceived;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(192, 45);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(162, 23);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chkExcludeNIssued;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(354, 45);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(130, 23);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.lkCategories;
            this.layoutControlItem14.CustomizationFormText = "Categories";
            this.layoutControlItem14.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(274, 24);
            this.layoutControlItem14.Text = "Categories";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(274, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(12, 24);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.dtFrom;
            this.layoutControlItem11.CustomizationFormText = "From";
            this.layoutControlItem11.Location = new System.Drawing.Point(499, 44);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(228, 24);
            this.layoutControlItem11.Text = "From";
            this.layoutControlItem11.TextSize = new System.Drawing.Size(94, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(830, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(110, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtItemName;
            this.layoutControlItem8.CustomizationFormText = "Filter by Item Name";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(192, 44);
            this.layoutControlItem8.Text = "Filter by Item Name";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(94, 13);
            this.layoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnFilter;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(950, 42);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(90, 26);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnload;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(950, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(90, 42);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(940, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(10, 68);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(499, 24);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(228, 20);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(354, 24);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(130, 21);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(192, 24);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(162, 21);
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(727, 24);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(213, 20);
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.ForeColor = System.Drawing.Color.Black;
            this.dtDate.Location = new System.Drawing.Point(897, 2);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 15;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(447, 9);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(58, 13);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "All Items";
            // 
            // IssuesByReceivingUnit
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 432);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.lblState);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "IssuesByReceivingUnit";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkCategories.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcludeNIssued.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExcludeNReceived.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkRoutes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblState;
        private CalendarLib.DateTimePickerEx dtTo;
        private CalendarLib.DateTimePickerEx dtFrom;
        private CalendarLib.DateTimePickerEx dtDate;
        private SimpleButton xpButton2;
        private SimpleButton xpButton1;
        private TextEdit txtItemName;
        private DevExpress.XtraGrid.GridControl gridDetailReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraEditors.LookUpEdit lkRoutes;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraEditors.LookUpEdit cboStores;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.CheckEdit chkExcludeNIssued;
        private DevExpress.XtraEditors.CheckEdit chkExcludeNReceived;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private LookUpEdit lkCategories;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private SimpleButton btnFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private SimpleButton btnload;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
    }
}