using HCMIS.Desktop.Reports.Helpers;

namespace HCMIS.Desktop.Reports
{
    partial class StockStatusByAccountWithUnitPrice
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockStatusByAccountWithUnitPrice));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblItemName = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblUnit = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblSubAccount = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblActivity = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblExpiry = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblUnitPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.pxLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.pxLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.AccountName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPrintedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellUnitPrice = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail.HeightF = 20F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable1
            // 
            this.xrTable1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrTable1.Borders = DevExpress.XtraPrinting.BorderSide.Top;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(762F, 20F);
            this.xrTable1.StylePriority.UseBorderColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.tblItemName,
            this.tblUnit,
            this.tblSubAccount,
            this.tblActivity,
            this.tblExpiry,
            this.tblUnitPrice,
            this.xrTableCell6});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LineNo")});
            this.xrTableCell8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UseBorderColor = false;
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "xrTableCell8";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell8.Weight = 0.0525157492261005D;
            // 
            // tblItemName
            // 
            this.tblItemName.BorderColor = System.Drawing.Color.Silver;
            this.tblItemName.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblItemName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FullItemName")});
            this.tblItemName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblItemName.Name = "tblItemName";
            this.tblItemName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tblItemName.StylePriority.UseBorderColor = false;
            this.tblItemName.StylePriority.UseBorders = false;
            this.tblItemName.StylePriority.UseFont = false;
            this.tblItemName.StylePriority.UsePadding = false;
            this.tblItemName.StylePriority.UseTextAlignment = false;
            this.tblItemName.Text = "tblItemName";
            this.tblItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblItemName.Weight = 0.40700588853025849D;
            // 
            // tblUnit
            // 
            this.tblUnit.BorderColor = System.Drawing.Color.Silver;
            this.tblUnit.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblUnit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Text")});
            this.tblUnit.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tblUnit.ForeColor = System.Drawing.Color.Black;
            this.tblUnit.Name = "tblUnit";
            this.tblUnit.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tblUnit.StylePriority.UseBorderColor = false;
            this.tblUnit.StylePriority.UseBorders = false;
            this.tblUnit.StylePriority.UseFont = false;
            this.tblUnit.StylePriority.UseForeColor = false;
            this.tblUnit.StylePriority.UsePadding = false;
            this.tblUnit.StylePriority.UseTextAlignment = false;
            this.tblUnit.Text = "tblUnit";
            this.tblUnit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblUnit.Weight = 0.11217485113578821D;
            // 
            // tblSubAccount
            // 
            this.tblSubAccount.BorderColor = System.Drawing.Color.Silver;
            this.tblSubAccount.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblSubAccount.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SubAccountName")});
            this.tblSubAccount.Font = new System.Drawing.Font("Tahoma", 8F);
            this.tblSubAccount.Name = "tblSubAccount";
            this.tblSubAccount.StylePriority.UseBorderColor = false;
            this.tblSubAccount.StylePriority.UseBorders = false;
            this.tblSubAccount.StylePriority.UseFont = false;
            this.tblSubAccount.StylePriority.UseTextAlignment = false;
            this.tblSubAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblSubAccount.Weight = 0.12934445184076635D;
            // 
            // tblActivity
            // 
            this.tblActivity.BorderColor = System.Drawing.Color.Silver;
            this.tblActivity.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblActivity.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ActivityName")});
            this.tblActivity.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tblActivity.ForeColor = System.Drawing.Color.Black;
            this.tblActivity.Name = "tblActivity";
            this.tblActivity.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tblActivity.StylePriority.UseBorderColor = false;
            this.tblActivity.StylePriority.UseBorders = false;
            this.tblActivity.StylePriority.UseFont = false;
            this.tblActivity.StylePriority.UseForeColor = false;
            this.tblActivity.StylePriority.UsePadding = false;
            this.tblActivity.StylePriority.UseTextAlignment = false;
            this.tblActivity.Text = "tblActivity";
            this.tblActivity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblActivity.Weight = 0.12934445184076635D;
            // 
            // tblExpiry
            // 
            this.tblExpiry.BorderColor = System.Drawing.Color.Silver;
            this.tblExpiry.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblExpiry.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ExpDate", "{0:MMM d, yyyy}")});
            this.tblExpiry.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tblExpiry.ForeColor = System.Drawing.Color.Black;
            this.tblExpiry.Name = "tblExpiry";
            this.tblExpiry.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tblExpiry.StylePriority.UseBorderColor = false;
            this.tblExpiry.StylePriority.UseBorders = false;
            this.tblExpiry.StylePriority.UseFont = false;
            this.tblExpiry.StylePriority.UseForeColor = false;
            this.tblExpiry.StylePriority.UsePadding = false;
            this.tblExpiry.StylePriority.UseTextAlignment = false;
            this.tblExpiry.Text = "tblExpiry";
            this.tblExpiry.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblExpiry.Weight = 0.15275750073052583D;
            // 
            // tblUnitPrice
            // 
            this.tblUnitPrice.BorderColor = System.Drawing.Color.Silver;
            this.tblUnitPrice.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblUnitPrice.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "UnitCost", "{0:#,##0.0####}")});
            this.tblUnitPrice.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tblUnitPrice.ForeColor = System.Drawing.Color.Black;
            this.tblUnitPrice.Name = "tblUnitPrice";
            this.tblUnitPrice.StylePriority.UseBorderColor = false;
            this.tblUnitPrice.StylePriority.UseBorders = false;
            this.tblUnitPrice.StylePriority.UseFont = false;
            this.tblUnitPrice.StylePriority.UseForeColor = false;
            this.tblUnitPrice.StylePriority.UseTextAlignment = false;
            this.tblUnitPrice.Text = "tblUnitPrice";
            this.tblUnitPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tblUnitPrice.Weight = 0.13652464650787133D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SOH", "{0:#,##0}")});
            this.xrTableCell6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCell6.StylePriority.UseBorderColor = false;
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "xrTableCell6";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell6.Weight = 0.098264350336434964D;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pxLogo,
            this.pxLogo,
            this.AccountName,
            this.xrLabel2});
            this.TopMargin.HeightF = 209.2916F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pxLogo
            // 
            this.pxLogo.BorderColor = System.Drawing.Color.Transparent;
            this.pxLogo.BorderWidth = 0;
            this.pxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pxLogo.Image")));
            this.pxLogo.LocationFloat = new DevExpress.Utils.PointFloat(12.5F, 20.50002F);
            this.pxLogo.Name = "pxLogo";
            this.pxLogo.SizeF = new System.Drawing.SizeF(763.0417F, 96.30075F);
            this.pxLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.pxLogo.StylePriority.UseBorderColor = false;
            this.pxLogo.StylePriority.UseBorderWidth = false;
            // 
            // pxLogo
            // 
            this.pxLogo.BorderColor = System.Drawing.Color.Transparent;
            this.pxLogo.BorderWidth = 0;
            this.pxLogo.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 20.50002F);
            this.pxLogo.Name = "pxLogo";
            this.pxLogo.SizeF = new System.Drawing.SizeF(763.5417F, 96.2916F);
            this.pxLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.pxLogo.StylePriority.UseBorderColor = false;
            this.pxLogo.StylePriority.UseBorderWidth = false;
            // 
            // AccountName
            // 
            this.AccountName.BackColor = System.Drawing.Color.White;
            this.AccountName.BorderColor = System.Drawing.Color.White;
            this.AccountName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountName.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.AccountName.LocationFloat = new DevExpress.Utils.PointFloat(72.91666F, 171.3749F);
            this.AccountName.Name = "AccountName";
            this.AccountName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName.SizeF = new System.Drawing.SizeF(648.9583F, 37.91668F);
            this.AccountName.StylePriority.UseBackColor = false;
            this.AccountName.StylePriority.UseBorderColor = false;
            this.AccountName.StylePriority.UseBorders = false;
            this.AccountName.StylePriority.UseFont = false;
            this.AccountName.StylePriority.UseTextAlignment = false;
            this.AccountName.Text = "AccountName";
            this.AccountName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.White;
            this.xrLabel2.BorderColor = System.Drawing.Color.White;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(72.9167F, 127.2083F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(648.9583F, 33.41668F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseBorderColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Stock Status Report";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPrintedBy,
            this.xrLabel10,
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin.HeightF = 91F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPrintedBy
            // 
            this.xrPrintedBy.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPrintedBy.ForeColor = System.Drawing.Color.Gray;
            this.xrPrintedBy.LocationFloat = new DevExpress.Utils.PointFloat(1.999998F, 31.20829F);
            this.xrPrintedBy.Name = "xrPrintedBy";
            this.xrPrintedBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPrintedBy.SizeF = new System.Drawing.SizeF(349.0417F, 18.87499F);
            this.xrPrintedBy.StylePriority.UseFont = false;
            this.xrPrintedBy.StylePriority.UseForeColor = false;
            this.xrPrintedBy.StylePriority.UseTextAlignment = false;
            this.xrPrintedBy.Text = "Printed By {}";
            this.xrPrintedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F);
            this.xrLabel10.ForeColor = System.Drawing.Color.Gray;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(566.4584F, 17.20829F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(205.5416F, 23F);
            this.xrLabel10.StylePriority.UseBackColor = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.Text = "Generated by HCMIS Version 3.0 ";
            // 
            // xrPageInfo2
            // 
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(1.041698F, 10F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(170.8333F, 17.16668F);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Format = "Page {0} of {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(600.1251F, 40.20831F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(151.0416F, 17.16668F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrLabel1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Type", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
            this.GroupHeader1.HeightF = 50F;
            this.GroupHeader1.LockedInUserDesigner = true;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.RepeatEveryPage = true;
            // 
            // xrTable2
            // 
            this.xrTable2.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(8.958305F, 30.45833F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(764.5833F, 19.54167F);
            this.xrTable2.StylePriority.UseBorderColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell10,
            this.xrTableCell3,
            this.xrTableCell9,
            this.xrTableCell5,
            this.xrTableCellUnitPrice,
            this.xrTableCell4});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UseBorderColor = false;
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "No.";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell1.Weight = 0.0525157492261005D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseBorderColor = false;
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Item Name";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell2.Weight = 0.45257225631697395D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Unit";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell10.Weight = 0.12285308669581786D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "Sub Account";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell3.Weight = 0.14165704757696623D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UseFont = false;
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Activity";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell9.Weight = 0.14165704757696623D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Expiry Date";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell5.Weight = 0.16729893704610455D;
            // 
            // xrTableCellUnitPrice
            // 
            this.xrTableCellUnitPrice.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.xrTableCellUnitPrice.Name = "xrTableCellUnitPrice";
            this.xrTableCellUnitPrice.StylePriority.UseFont = false;
            this.xrTableCellUnitPrice.StylePriority.UseTextAlignment = false;
            this.xrTableCellUnitPrice.Text = "Unit Price";
            this.xrTableCellUnitPrice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCellUnitPrice.Weight = 0.14952063964244222D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseBorderColor = false;
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "SOH";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell4.Weight = 0.11031692416716596D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.White;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Type")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(450.6797F, 22.41669F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(HCMIS.Desktop.Reports.Helpers.TheDataSet.StockStatusDataTable);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter1.HeightF = 9.375F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // StockStatusByAccountWithUnitPrice
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.GroupFooter1});
            this.DataSource = this.bindingSource1;
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Margins = new System.Drawing.Printing.Margins(33, 35, 209, 91);
            this.Version = "11.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTableCell tblItemName;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        public DevExpress.XtraReports.UI.XRLabel AccountName;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo2;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule1;
        private DevExpress.XtraReports.UI.XRPictureBox pxLogo;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel10;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRTableCell tblUnit;
        private DevExpress.XtraReports.UI.XRTableCell tblActivity;
        private DevExpress.XtraReports.UI.XRTableCell tblExpiry;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell tblSubAccount;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        public DevExpress.XtraReports.UI.XRLabel xrPrintedBy;
        private DevExpress.XtraReports.UI.XRTableCell tblUnitPrice;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellUnitPrice;

    }
}
