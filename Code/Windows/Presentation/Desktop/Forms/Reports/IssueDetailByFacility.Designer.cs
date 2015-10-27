namespace HCMIS.Desktop.Forms.Reports
{
    partial class IssueDetailByFacility
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
            this.grdFacilityList = new DevExpress.XtraGrid.GridControl();
            this.grdFacilityListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacilityName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.printIssueDetailByFacility = new DevExpress.XtraPrinting.Control.PrintControl();
            this.dtTo = new CalendarLib.DateTimePickerEx();
            this.dtFrom = new CalendarLib.DateTimePickerEx();
            this.btnIssueDetailByFacilityPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridSummary = new DevExpress.XtraGrid.GridControl();
            this.gridSummaryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabbedControlGroup1 = new DevExpress.XtraLayout.TabbedControlGroup();
            this.tabIssueDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.From = new DevExpress.XtraLayout.LayoutControlItem();
            this.To = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Account = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacilityList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacilityListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummaryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabIssueDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.From)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.To)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Account)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // grdFacilityList
            // 
            this.grdFacilityList.Location = new System.Drawing.Point(12, 12);
            this.grdFacilityList.MainView = this.grdFacilityListView;
            this.grdFacilityList.Name = "grdFacilityList";
            this.grdFacilityList.Size = new System.Drawing.Size(253, 697);
            this.grdFacilityList.TabIndex = 4;
            this.grdFacilityList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdFacilityListView});

            // 
            // grdFacilityListView
            // 
            this.grdFacilityListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colFacilityName});
            this.grdFacilityListView.GridControl = this.grdFacilityList;
            this.grdFacilityListView.Name = "grdFacilityListView";
            this.grdFacilityListView.OptionsView.ShowAutoFilterRow = true;
            this.grdFacilityListView.OptionsView.ShowColumnHeaders = false;
            this.grdFacilityListView.OptionsView.ShowGroupPanel = false;
            this.grdFacilityListView.OptionsView.ShowIndicator = false;
            this.grdFacilityListView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFacilityName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdFacilityListView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.GrdFacilityListViewFocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.AllowFocus = false;
            // 
            // colFacilityName
            // 
            this.colFacilityName.Caption = "Facility";
            this.colFacilityName.FieldName = "Name";
            this.colFacilityName.Name = "colFacilityName";
            this.colFacilityName.OptionsColumn.AllowEdit = false;
            this.colFacilityName.OptionsColumn.AllowFocus = false;
            this.colFacilityName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colFacilityName.Visible = true;
            this.colFacilityName.VisibleIndex = 0;
            this.colFacilityName.Width = 685;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkAccount);
            this.layoutControl1.Controls.Add(this.printIssueDetailByFacility);
            this.layoutControl1.Controls.Add(this.dtTo);
            this.layoutControl1.Controls.Add(this.dtFrom);
            this.layoutControl1.Controls.Add(this.btnIssueDetailByFacilityPrint);
            this.layoutControl1.Controls.Add(this.gridSummary);
            this.layoutControl1.Controls.Add(this.grdFacilityList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(958, 371, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1145, 721);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkAccount
            // 
            this.lkAccount.Location = new System.Drawing.Point(323, 46);
            this.lkAccount.Name = "lkAccount";
            this.lkAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccount.Properties.DisplayMember = "StoreGroup";
            this.lkAccount.Properties.NullText = "Select Account";
            this.lkAccount.Properties.ValueMember = "ID";
            this.lkAccount.Properties.View = this.gridView1;
            this.lkAccount.Size = new System.Drawing.Size(151, 20);
            this.lkAccount.StyleController = this.layoutControl1;
            this.lkAccount.TabIndex = 82;
            this.lkAccount.EditValueChanged += new System.EventHandler(this.lkAccount_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn12});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn11, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "ID";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Mode";
            this.gridColumn11.FieldName = "StoreType";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Account";
            this.gridColumn12.FieldName = "StoreGroup";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            // 
            // printIssueDetailByFacility
            // 
            this.printIssueDetailByFacility.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.printIssueDetailByFacility.BackColor = System.Drawing.Color.Empty;
            this.printIssueDetailByFacility.ForeColor = System.Drawing.Color.Empty;
            this.printIssueDetailByFacility.IsMetric = false;
            this.printIssueDetailByFacility.Location = new System.Drawing.Point(281, 72);
            this.printIssueDetailByFacility.Name = "printIssueDetailByFacility";
            this.printIssueDetailByFacility.Size = new System.Drawing.Size(840, 625);
            this.printIssueDetailByFacility.TabIndex = 20;
            this.printIssueDetailByFacility.TooltipFont = new System.Drawing.Font("Tahoma", 8.25F);
            // 
            // dtTo
            // 
            this.dtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTo.CalendarFont = new System.Drawing.Font("Nyala", 12F);
            this.dtTo.CalendarForeColor = System.Drawing.Color.Black;
            this.dtTo.DayOfWeekCharacters = 1;
            this.dtTo.ForeColor = System.Drawing.Color.Black;
            this.dtTo.Location = new System.Drawing.Point(872, 46);
            this.dtTo.Name = "dtTo";
            this.dtTo.PopUpFontSize = 10F;
            this.dtTo.Size = new System.Drawing.Size(154, 22);
            this.dtTo.TabIndex = 81;
            this.dtTo.TextSelect = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtTo.Value = new System.DateTime(2013, 4, 7, 0, 0, 0, 0);
            this.dtTo.ValueChanged += new System.EventHandler(this.dtTo_ValueChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFrom.CalendarFont = new System.Drawing.Font("Nyala", 12F);
            this.dtFrom.CalendarForeColor = System.Drawing.Color.Black;
            this.dtFrom.DayOfWeekCharacters = 1;
            this.dtFrom.ForeColor = System.Drawing.Color.Black;
            this.dtFrom.Location = new System.Drawing.Point(672, 46);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.PopUpFontSize = 10F;
            this.dtFrom.Size = new System.Drawing.Size(154, 22);
            this.dtFrom.TabIndex = 80;
            this.dtFrom.TextSelect = System.Drawing.SystemColors.GradientActiveCaption;
            this.dtFrom.Value = new System.DateTime(2013, 4, 7, 0, 0, 0, 0);
            this.dtFrom.ValueChanged += new System.EventHandler(this.dtFrom_ValueChanged);
            // 
            // btnIssueDetailByFacilityPrint
            // 
            this.btnIssueDetailByFacilityPrint.Location = new System.Drawing.Point(1030, 46);
            this.btnIssueDetailByFacilityPrint.Name = "btnIssueDetailByFacilityPrint";
            this.btnIssueDetailByFacilityPrint.Size = new System.Drawing.Size(91, 22);
            this.btnIssueDetailByFacilityPrint.StyleController = this.layoutControl1;
            this.btnIssueDetailByFacilityPrint.TabIndex = 25;
            this.btnIssueDetailByFacilityPrint.Text = "Print";
            this.btnIssueDetailByFacilityPrint.Click += new System.EventHandler(this.btnIssueDetailByFacilityPrint_Click);
            // 
            // gridSummary
            // 
            this.gridSummary.Location = new System.Drawing.Point(313, 563);
            this.gridSummary.MainView = this.gridSummaryView;
            this.gridSummary.Name = "gridSummary";
            this.gridSummary.Size = new System.Drawing.Size(1033, 163);
            this.gridSummary.TabIndex = 9;
            this.gridSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSummaryView});
            // 
            // gridSummaryView
            // 
            this.gridSummaryView.GridControl = this.gridSummary;
            this.gridSummaryView.Name = "gridSummaryView";
            this.gridSummaryView.OptionsView.ShowGroupPanel = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridSummary;
            this.layoutControlItem7.CustomizationFormText = "Summary";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 496);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1037, 183);
            this.layoutControlItem7.Text = "Summary";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(87, 13);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.tabbedControlGroup1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1145, 721);
            this.layoutControlGroup1.Text = "Root";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Facility List";
            this.layoutControlGroup2.ExpandButtonVisible = true;
            this.layoutControlGroup2.ExpandOnDoubleClick = true;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.ShowTabPageCloseButton = true;
            this.layoutControlGroup2.Size = new System.Drawing.Size(257, 701);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Text = "Facility List";
            this.layoutControlGroup2.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdFacilityList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(257, 701);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // tabbedControlGroup1
            // 
            this.tabbedControlGroup1.CustomizationFormText = "tabbedControlGroup1";
            this.tabbedControlGroup1.Location = new System.Drawing.Point(257, 0);
            this.tabbedControlGroup1.Name = "tabbedControlGroup1";
            this.tabbedControlGroup1.SelectedTabPage = this.tabIssueDetail;
            this.tabbedControlGroup1.SelectedTabPageIndex = 0;
            this.tabbedControlGroup1.Size = new System.Drawing.Size(868, 701);
            this.tabbedControlGroup1.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabIssueDetail});
            this.tabbedControlGroup1.Text = "tabbedControlGroup1";
            // 
            // tabIssueDetail
            // 
            this.tabIssueDetail.CustomizationFormText = "Issue Detail";
            this.tabIssueDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem21,
            this.From,
            this.To,
            this.emptySpaceItem1,
            this.Account});
            this.tabIssueDetail.Location = new System.Drawing.Point(0, 0);
            this.tabIssueDetail.Name = "tabIssueDetail";
            this.tabIssueDetail.Size = new System.Drawing.Size(844, 655);
            this.tabIssueDetail.Text = "Issue Detail";
            this.tabIssueDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.printIssueDetailByFacility;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(844, 629);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.btnIssueDetailByFacilityPrint;
            this.layoutControlItem21.CustomizationFormText = "layoutControlItem21";
            this.layoutControlItem21.Location = new System.Drawing.Point(749, 0);
            this.layoutControlItem21.MaxSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(95, 26);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(95, 26);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.Text = "layoutControlItem21";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextToControlDistance = 0;
            this.layoutControlItem21.TextVisible = false;
            // 
            // From
            // 
            this.From.Control = this.dtFrom;
            this.From.CustomizationFormText = "From";
            this.From.Location = new System.Drawing.Point(349, 0);
            this.From.Name = "From";
            this.From.Size = new System.Drawing.Size(200, 26);
            this.From.Text = "From";
            this.From.TextSize = new System.Drawing.Size(39, 13);
            // 
            // To
            // 
            this.To.Control = this.dtTo;
            this.To.CustomizationFormText = "To";
            this.To.Location = new System.Drawing.Point(549, 0);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(200, 26);
            this.To.Text = "To";
            this.To.TextSize = new System.Drawing.Size(39, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(197, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(152, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Account
            // 
            this.Account.Control = this.lkAccount;
            this.Account.CustomizationFormText = "Account";
            this.Account.Location = new System.Drawing.Point(0, 0);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(197, 26);
            this.Account.Text = "Account";
            this.Account.TextSize = new System.Drawing.Size(39, 13);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem6.Location = new System.Drawing.Point(645, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem4";
            this.emptySpaceItem6.Size = new System.Drawing.Size(245, 50);
            this.emptySpaceItem6.Text = "emptySpaceItem4";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // IssueDetailByFacility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 721);
            this.Controls.Add(this.layoutControl1);
            this.Name = "IssueDetailByFacility";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IssueDetailByFacility";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IssueDetailByFacilityLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grdFacilityList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFacilityListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSummaryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabIssueDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.From)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.To)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Account)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdFacilityList;
        private DevExpress.XtraGrid.Views.Grid.GridView grdFacilityListView;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFacilityName;
        private DevExpress.XtraGrid.GridControl gridSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSummaryView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnIssueDetailByFacilityPrint;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private CalendarLib.DateTimePickerEx dtFrom;
        private CalendarLib.DateTimePickerEx dtTo;
        private DevExpress.XtraLayout.TabbedControlGroup tabbedControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup tabIssueDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem From;
        private DevExpress.XtraLayout.LayoutControlItem To;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.GridLookUpEdit lkAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraLayout.LayoutControlItem Account;
        private DevExpress.XtraPrinting.Control.PrintControl printIssueDetailByFacility;
    }
}