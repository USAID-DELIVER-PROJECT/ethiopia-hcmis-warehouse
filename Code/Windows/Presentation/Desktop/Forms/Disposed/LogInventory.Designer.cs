using DevExpress.XtraEditors;
namespace HCMIS.Desktop
{
    partial class LogInventory
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
            this.yea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstRefNo = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dtDate = new CalendarLib.DateTimePickerEx();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtEmpty = new DevExpress.XtraEditors.TextEdit();
            this.gridInventory = new DevExpress.XtraGrid.GridControl();
            this.gridInventoryView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblAdjDate = new System.Windows.Forms.Label();
            this.lkActivity = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkActivity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // yea
            // 
            this.yea.Text = "Year";
            this.yea.Width = 126;
            // 
            // lstRefNo
            // 
            this.lstRefNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRefNo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.yea});
            this.lstRefNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstRefNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRefNo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lstRefNo.FullRowSelect = true;
            this.lstRefNo.Location = new System.Drawing.Point(0, 0);
            this.lstRefNo.MultiSelect = false;
            this.lstRefNo.Name = "lstRefNo";
            this.lstRefNo.Size = new System.Drawing.Size(247, 575);
            this.lstRefNo.TabIndex = 9;
            this.lstRefNo.UseCompatibleStateImageBehavior = false;
            this.lstRefNo.View = System.Windows.Forms.View.Details;
            this.lstRefNo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LstTransactionsMouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailToolStripMenuItem,
            this.detailToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 48);
            this.contextMenuStrip1.Text = "conTran";
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Image = global::HCMIS.Desktop.Properties.Resources.report;
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.detailToolStripMenuItem.Text = "detail";
            // 
            // detailToolStripMenuItem1
            // 
            this.detailToolStripMenuItem1.Image = global::HCMIS.Desktop.Properties.Resources.cross;
            this.detailToolStripMenuItem1.Name = "detailToolStripMenuItem1";
            this.detailToolStripMenuItem1.Size = new System.Drawing.Size(106, 22);
            this.detailToolStripMenuItem1.Text = "delete";
            // 
            // dtDate
            // 
            this.dtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDate.CalendarFont = new System.Drawing.Font("Nyala", 10.75F);
            this.dtDate.CalendarForeColor = System.Drawing.Color.Black;
            this.dtDate.CustomFormat = "MM/dd/yyyy";
            this.dtDate.DayOfWeekCharacters = 2;
            this.dtDate.ForeColor = System.Drawing.Color.Black;
            this.dtDate.Location = new System.Drawing.Point(784, 14);
            this.dtDate.Name = "dtDate";
            this.dtDate.PopUpFontSize = 9.75F;
            this.dtDate.Size = new System.Drawing.Size(114, 20);
            this.dtDate.TabIndex = 24;
            this.dtDate.Value = new System.DateTime(2008, 10, 3, 0, 0, 0, 0);
            this.dtDate.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::HCMIS.Desktop.Properties.Resources.MS_Excel;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(933, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 25);
            this.button1.TabIndex = 23;
            this.button1.Text = "Export";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnExportClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(428, 213);
            this.progressBar1.Minimum = 1;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 22;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Value = 1;
            this.progressBar1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(460, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Inventory Made On : ";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::HCMIS.Desktop.Properties.Resources.printer1;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1021, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 25);
            this.btnPrint.TabIndex = 32;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrintClick);
            // 
            // txtEmpty
            // 
            this.txtEmpty.EditValue = "Physical Inventory has not been done for the past fiscal year. The system automat" +
    "ically made the ending balance or last year, beginning balance for the current f" +
    "iscal year.";
            this.txtEmpty.Location = new System.Drawing.Point(340, 157);
            this.txtEmpty.Name = "txtEmpty";
            this.txtEmpty.Properties.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.txtEmpty.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpty.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtEmpty.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmpty.Properties.Appearance.Options.UseFont = true;
            this.txtEmpty.Properties.Appearance.Options.UseForeColor = true;
            this.txtEmpty.Size = new System.Drawing.Size(739, 24);
            this.txtEmpty.TabIndex = 34;
            this.txtEmpty.Visible = false;
            // 
            // gridInventory
            // 
            this.gridInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInventory.Location = new System.Drawing.Point(254, 51);
            this.gridInventory.MainView = this.gridInventoryView;
            this.gridInventory.Name = "gridInventory";
            this.gridInventory.Size = new System.Drawing.Size(856, 516);
            this.gridInventory.TabIndex = 35;
            this.gridInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInventoryView,
            this.gridView2});
            // 
            // gridInventoryView
            // 
            this.gridInventoryView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridInventoryView.GridControl = this.gridInventory;
            this.gridInventoryView.Name = "gridInventoryView";
            this.gridInventoryView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "No";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 56;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ItemName";
            this.gridColumn2.FieldName = "FullItemName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 168;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Begining Balance";
            this.gridColumn3.FieldName = "BBalance";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 168;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ending Balance (SOH)";
            this.gridColumn4.FieldName = "EBalance";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 168;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Physical Inventory";
            this.gridColumn5.FieldName = "PhysicalInventory";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 168;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Remark";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 174;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridInventory;
            this.gridView2.Name = "gridView2";
            // 
            // lblAdjDate
            // 
            this.lblAdjDate.AutoSize = true;
            this.lblAdjDate.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjDate.Location = new System.Drawing.Point(588, 25);
            this.lblAdjDate.Name = "lblAdjDate";
            this.lblAdjDate.Size = new System.Drawing.Size(71, 13);
            this.lblAdjDate.TabIndex = 30;
            this.lblAdjDate.Text = "Upto Date";
            // 
            // lkActivity
            // 
            this.lkActivity.Location = new System.Drawing.Point(254, 22);
            this.lkActivity.Name = "lkActivity";
            this.lkActivity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkActivity.Properties.View = this.gridLookUpEdit1View;
            this.lkActivity.Size = new System.Drawing.Size(159, 20);
            this.lkActivity.TabIndex = 36;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // LogInventory
            // 
            this.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 575);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.txtEmpty);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstRefNo);
            this.Controls.Add(this.lblAdjDate);
            this.Controls.Add(this.gridInventory);
            this.Controls.Add(this.lkActivity);
            this.Name = "LogInventory";
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.ManageItemsLoad);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEmpty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInventoryView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkActivity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstRefNo;
        private System.Windows.Forms.ColumnHeader yea;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private CalendarLib.DateTimePickerEx dtDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem1;
        private TextEdit txtEmpty;
        private DevExpress.XtraGrid.GridControl gridInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInventoryView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label lblAdjDate;
        private GridLookUpEdit lkActivity;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
    }
}