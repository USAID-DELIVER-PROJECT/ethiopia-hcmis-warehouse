using DevExpress.XtraEditors;
namespace HCMIS.Desktop.Forms.Reports
{
    partial class ReservedProducts
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReservedProducts));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkMode = new DevExpress.XtraEditors.LookUpEdit();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.gridDetailReport = new DevExpress.XtraGrid.GridControl();
            this.gridItemChoiceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDayDifference = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.lblState = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemChoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkMode);
            this.layoutControl1.Controls.Add(this.btnExport);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.gridDetailReport);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(203, 276, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1077, 432);
            this.layoutControl1.TabIndex = 37;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkMode
            // 
            this.lkMode.Location = new System.Drawing.Point(42, 12);
            this.lkMode.Name = "lkMode";
            this.lkMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkMode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "Name")});
            this.lkMode.Properties.DisplayMember = "TypeName";
            this.lkMode.Properties.ValueMember = "ID";
            this.lkMode.Size = new System.Drawing.Size(302, 20);
            this.lkMode.StyleController = this.layoutControl1;
            this.lkMode.TabIndex = 38;
            this.lkMode.EditValueChanged += new System.EventHandler(this.lkMode_EditValueChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(883, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(93, 22);
            this.btnExport.StyleController = this.layoutControl1;
            this.btnExport.TabIndex = 47;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(980, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 46;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // gridDetailReport
            // 
            this.gridDetailReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDetailReport.Location = new System.Drawing.Point(12, 38);
            this.gridDetailReport.MainView = this.gridItemChoiceView;
            this.gridDetailReport.Name = "gridDetailReport";
            this.gridDetailReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridDetailReport.Size = new System.Drawing.Size(1053, 382);
            this.gridDetailReport.TabIndex = 38;
            this.gridDetailReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridItemChoiceView});
            // 
            // gridItemChoiceView
            // 
            this.gridItemChoiceView.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(190)))), ((int)(((byte)(243)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.Empty.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FilterCloseButton.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.FilterCloseButton.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.gridItemChoiceView.Appearance.FilterPanel.ForeColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.gridItemChoiceView.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FocusedCell.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.gridItemChoiceView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.FooterPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(109)))), ((int)(((byte)(185)))));
            this.gridItemChoiceView.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(216)))), ((int)(((byte)(247)))));
            this.gridItemChoiceView.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridItemChoiceView.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseFont = true;
            this.gridItemChoiceView.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(171)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.gridItemChoiceView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridItemChoiceView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridItemChoiceView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(153)))), ((int)(((byte)(228)))));
            this.gridItemChoiceView.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.gridItemChoiceView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.HorzLine.BackColor = System.Drawing.Color.AliceBlue;
            this.gridItemChoiceView.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.OddRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.OddRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.gridItemChoiceView.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(129)))), ((int)(((byte)(185)))));
            this.gridItemChoiceView.Appearance.Preview.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.Preview.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridItemChoiceView.Appearance.Row.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.Row.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(126)))), ((int)(((byte)(217)))));
            this.gridItemChoiceView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridItemChoiceView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridItemChoiceView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridItemChoiceView.Appearance.VertLine.BackColor = System.Drawing.Color.AliceBlue;
            this.gridItemChoiceView.Appearance.VertLine.Options.UseBackColor = true;
            this.gridItemChoiceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colName,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.colAccount,
            this.colDayDifference});
            this.gridItemChoiceView.FixedLineWidth = 1;
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition1.Value1 = "Stock Out";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition2.Value1 = "Excess Stock";
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition3.Value1 = "Near EOP";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition4.Value1 = "Below EOP";
            styleFormatCondition5.Appearance.BackColor = System.Drawing.Color.White;
            styleFormatCondition5.Appearance.Options.UseBackColor = true;
            styleFormatCondition5.ApplyToRow = true;
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition5.Value1 = "Normal";
            this.gridItemChoiceView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2,
            styleFormatCondition3,
            styleFormatCondition4,
            styleFormatCondition5});
            this.gridItemChoiceView.GridControl = this.gridDetailReport;
            this.gridItemChoiceView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Count", this.gridColumn1, "")});
            this.gridItemChoiceView.IndicatorWidth = 40;
            this.gridItemChoiceView.Name = "gridItemChoiceView";
            this.gridItemChoiceView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridItemChoiceView.OptionsBehavior.Editable = false;
            this.gridItemChoiceView.OptionsBehavior.KeepFocusedRowOnUpdate = false;
            this.gridItemChoiceView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridItemChoiceView.OptionsDetail.EnableDetailToolTip = true;
            this.gridItemChoiceView.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.AlwaysEnabled;
            this.gridItemChoiceView.OptionsDetail.SmartDetailHeight = true;
            this.gridItemChoiceView.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridItemChoiceView.OptionsPrint.EnableAppearanceOddRow = true;
            this.gridItemChoiceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridItemChoiceView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridItemChoiceView.OptionsSelection.UseIndicatorForSelection = false;
            this.gridItemChoiceView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridItemChoiceView.OptionsView.EnableAppearanceOddRow = true;
            this.gridItemChoiceView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridItemChoiceView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No.";
            this.gridColumn1.FieldName = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsFilter.AllowFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 287;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ref No";
            this.gridColumn2.FieldName = "RefNo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Amount In Birr";
            this.gridColumn4.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Amount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Date Reserved";
            this.gridColumn5.FieldName = "SavedDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // colAccount
            // 
            this.colAccount.Caption = "Account";
            this.colAccount.FieldName = "AccountName";
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 2;
            // 
            // colDayDifference
            // 
            this.colDayDifference.Caption = "Difference";
            this.colDayDifference.FieldName = "Difference";
            this.colDayDifference.Name = "colDayDifference";
            this.colDayDifference.Visible = true;
            this.colDayDifference.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem3,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1077, 432);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridDetailReport;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1057, 386);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnPrint;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(968, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnExport;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(871, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(97, 26);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(336, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(535, 26);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkMode;
            this.layoutControlItem2.CustomizationFormText = "Mode";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(336, 26);
            this.layoutControlItem2.Text = "Mode";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(26, 13);
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.ForeColor = System.Drawing.Color.Black;
            this.dtDate.Location = new System.Drawing.Point(576, 7);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 16;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(447, 9);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(87, 13);
            this.lblState.TabIndex = 11;
            this.lblState.Text = "Expired Items";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(744, 394);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Total Price";
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(null, new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Time Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            this.printableComponentLink1.RtfReportFooter = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Arial;}{\\f1" +
    "\\fnil\\fcharset0 Times New Roman;}}\r\n\\viewkind4\\uc1\\pard\\qc\\fs28 Expired Products" +
    "\\f1\\fs20\\par\r\n}\r\n";
            // 
            // ReservedProducts
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 432);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.lblState);
            this.Name = "ReservedProducts";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetailReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemChoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblState;
        private CalendarLib.DateTimePickerEx dtDate;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridDetailReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridItemChoiceView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private SimpleButton btnExport;
        private SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private LookUpEdit lkMode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colDayDifference;
    }
}