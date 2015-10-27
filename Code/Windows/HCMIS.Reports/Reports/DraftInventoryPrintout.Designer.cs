using HCMIS.Desktop.Reports.Helpers;

namespace HCMIS.Desktop.Reports
{
    partial class DraftInventoryPrintout

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DraftInventoryPrintout));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tblStockCode2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblItemName = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblUnit = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellManufacturer = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblExpiry = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblBatch = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblDamaged = new DevExpress.XtraReports.UI.XRTableCell();
            this.tblExpired = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.WarehouseName = new DevExpress.XtraReports.UI.XRLabel();
            this.AccountName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.pxLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrPrintedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.cellStockCode = new DevExpress.XtraReports.UI.XRTableCell();
            this.cellItemName = new DevExpress.XtraReports.UI.XRTableCell();
            this.Unit = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.theDataSet = new HCMIS.Desktop.Reports.Helpers.TheDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theDataSet)).BeginInit();
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
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(2.00001F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(1030F, 20F);
            this.xrTable1.StylePriority.UseBorderColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tblStockCode2,
            this.tblItemName,
            this.tblUnit,
            this.cellManufacturer,
            this.tblExpiry,
            this.tblBatch,
            this.xrTableCell6,
            this.tblDamaged,
            this.tblExpired,
            this.xrTableCell9});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // tblStockCode2
            // 
            this.tblStockCode2.BorderColor = System.Drawing.Color.Silver;
            this.tblStockCode2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblStockCode2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "StockCode")});
            this.tblStockCode2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblStockCode2.Name = "tblStockCode2";
            this.tblStockCode2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tblStockCode2.StylePriority.UseBorderColor = false;
            this.tblStockCode2.StylePriority.UseBorders = false;
            this.tblStockCode2.StylePriority.UseFont = false;
            this.tblStockCode2.StylePriority.UsePadding = false;
            this.tblStockCode2.StylePriority.UseTextAlignment = false;
            this.tblStockCode2.Text = "tblStockCode2";
            this.tblStockCode2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblStockCode2.Weight = 0.16340563712754944D;
            // 
            // tblItemName
            // 
            this.tblItemName.BorderColor = System.Drawing.Color.Silver;
            this.tblItemName.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblItemName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "FullItemName")});
            this.tblItemName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tblItemName.ForeColor = System.Drawing.Color.Black;
            this.tblItemName.Name = "tblItemName";
            this.tblItemName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.tblItemName.StylePriority.UseBorderColor = false;
            this.tblItemName.StylePriority.UseBorders = false;
            this.tblItemName.StylePriority.UseFont = false;
            this.tblItemName.StylePriority.UseForeColor = false;
            this.tblItemName.StylePriority.UsePadding = false;
            this.tblItemName.StylePriority.UseTextAlignment = false;
            this.tblItemName.Text = "tblItemName";
            this.tblItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblItemName.Weight = 0.416656994458169D;
            // 
            // tblUnit
            // 
            this.tblUnit.BorderColor = System.Drawing.Color.Silver;
            this.tblUnit.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblUnit.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Unit")});
            this.tblUnit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblUnit.Name = "tblUnit";
            this.tblUnit.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.tblUnit.StylePriority.UseBorderColor = false;
            this.tblUnit.StylePriority.UseBorders = false;
            this.tblUnit.StylePriority.UseFont = false;
            this.tblUnit.StylePriority.UsePadding = false;
            this.tblUnit.StylePriority.UseTextAlignment = false;
            this.tblUnit.Text = "[Unit]";
            this.tblUnit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblUnit.Weight = 0.081468494980737646D;
            // 
            // cellManufacturer
            // 
            this.cellManufacturer.BorderColor = System.Drawing.Color.Silver;
            this.cellManufacturer.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.cellManufacturer.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ManufacturerName")});
            this.cellManufacturer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cellManufacturer.Name = "cellManufacturer";
            this.cellManufacturer.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.cellManufacturer.StylePriority.UseBorderColor = false;
            this.cellManufacturer.StylePriority.UseBorders = false;
            this.cellManufacturer.StylePriority.UseFont = false;
            this.cellManufacturer.StylePriority.UsePadding = false;
            this.cellManufacturer.StylePriority.UseTextAlignment = false;
            this.cellManufacturer.Text = "cellManufacturer";
            this.cellManufacturer.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cellManufacturer.Weight = 0.32606625958221991D;
            // 
            // tblExpiry
            // 
            this.tblExpiry.BorderColor = System.Drawing.Color.Silver;
            this.tblExpiry.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblExpiry.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ExpiryDate", "{0:dd-MMM-yyyy}")});
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
            this.tblExpiry.Weight = 0.12467019248229939D;
            // 
            // tblBatch
            // 
            this.tblBatch.BorderColor = System.Drawing.Color.Silver;
            this.tblBatch.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblBatch.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BatchNo")});
            this.tblBatch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblBatch.Name = "tblBatch";
            this.tblBatch.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.tblBatch.StylePriority.UseBorderColor = false;
            this.tblBatch.StylePriority.UseBorders = false;
            this.tblBatch.StylePriority.UseFont = false;
            this.tblBatch.StylePriority.UsePadding = false;
            this.tblBatch.StylePriority.UseTextAlignment = false;
            this.tblBatch.Text = "Batch";
            this.tblBatch.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.tblBatch.Weight = 0.12467018763892433D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "InventorySoundQuantity", "{0:#,###.##}")});
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
            this.xrTableCell6.Weight = 0.12467019055934661D;
            // 
            // tblDamaged
            // 
            this.tblDamaged.BorderColor = System.Drawing.Color.Silver;
            this.tblDamaged.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblDamaged.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "InventoryDamagedQuantity", "{0:#,###.##}")});
            this.tblDamaged.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblDamaged.Name = "tblDamaged";
            this.tblDamaged.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.tblDamaged.StylePriority.UseBorderColor = false;
            this.tblDamaged.StylePriority.UseBorders = false;
            this.tblDamaged.StylePriority.UseFont = false;
            this.tblDamaged.StylePriority.UsePadding = false;
            this.tblDamaged.StylePriority.UseTextAlignment = false;
            this.tblDamaged.Text = "tblDamaged";
            this.tblDamaged.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tblDamaged.Weight = 0.12467019506814142D;
            // 
            // tblExpired
            // 
            this.tblExpired.BorderColor = System.Drawing.Color.Silver;
            this.tblExpired.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tblExpired.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "InventoryExpiredQuantity", "{0:#,###.##}")});
            this.tblExpired.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblExpired.Name = "tblExpired";
            this.tblExpired.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
            this.tblExpired.StylePriority.UseBorderColor = false;
            this.tblExpired.StylePriority.UseBorders = false;
            this.tblExpired.StylePriority.UseFont = false;
            this.tblExpired.StylePriority.UsePadding = false;
            this.tblExpired.StylePriority.UseTextAlignment = false;
            this.tblExpired.Text = "tblExpired";
            this.tblExpired.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.tblExpired.Weight = 0.12467019427395519D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.Text = " ";
            this.xrTableCell9.Weight = 0.097997547103814489D;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.WarehouseName,
            this.AccountName,
            this.xrLabel2,
            this.pxLogo});
            this.TopMargin.HeightF = 206.375F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // WarehouseName
            // 
            this.WarehouseName.BackColor = System.Drawing.Color.White;
            this.WarehouseName.BorderColor = System.Drawing.Color.White;
            this.WarehouseName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.WarehouseName.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.WarehouseName.LocationFloat = new DevExpress.Utils.PointFloat(161.2239F, 140.5418F);
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.WarehouseName.SizeF = new System.Drawing.SizeF(681.2504F, 26.04167F);
            this.WarehouseName.StylePriority.UseBackColor = false;
            this.WarehouseName.StylePriority.UseBorderColor = false;
            this.WarehouseName.StylePriority.UseBorders = false;
            this.WarehouseName.StylePriority.UseFont = false;
            this.WarehouseName.StylePriority.UseTextAlignment = false;
            this.WarehouseName.Text = "WarehouseName";
            this.WarehouseName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // AccountName
            // 
            this.AccountName.BackColor = System.Drawing.Color.White;
            this.AccountName.BorderColor = System.Drawing.Color.White;
            this.AccountName.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.AccountName.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.AccountName.LocationFloat = new DevExpress.Utils.PointFloat(161.2239F, 172.6667F);
            this.AccountName.Name = "AccountName";
            this.AccountName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.AccountName.SizeF = new System.Drawing.SizeF(680.2085F, 33.70834F);
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
            this.xrLabel2.BorderColor = System.Drawing.Color.White;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(162.2656F, 111.375F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(680.2085F, 29.16673F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseBorderColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Draft Inventory Printout";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // pxLogo
            // 
            this.pxLogo.BorderColor = System.Drawing.Color.Transparent;
            this.pxLogo.BorderWidth = 0;
            this.pxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pxLogo.Image")));
            this.pxLogo.LocationFloat = new DevExpress.Utils.PointFloat(162.2656F, 0F);
            this.pxLogo.Name = "pxLogo";
            this.pxLogo.SizeF = new System.Drawing.SizeF(680.2086F, 111.375F);
            this.pxLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.pxLogo.StylePriority.UseBorderColor = false;
            this.pxLogo.StylePriority.UseBorderWidth = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPrintedBy,
            this.xrLabel10,
            this.xrPageInfo2,
            this.xrPageInfo1});
            this.BottomMargin.HeightF = 52F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPrintedBy
            // 
            this.xrPrintedBy.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrPrintedBy.ForeColor = System.Drawing.Color.Gray;
            this.xrPrintedBy.LocationFloat = new DevExpress.Utils.PointFloat(2F, 19.2083F);
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
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(814.4584F, 0F);
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
            this.xrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPageInfo2.Name = "xrPageInfo2";
            this.xrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo2.SizeF = new System.Drawing.SizeF(170.8333F, 17.16668F);
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Format = "Page {0} of {1}";
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(846.1251F, 25F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(171.8749F, 17.16667F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrLabel1});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Category", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
            this.GroupHeader1.HeightF = 43.95836F;
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
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0.9583036F, 24.41669F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(1031.042F, 19.54167F);
            this.xrTable2.StylePriority.UseBorderColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.cellStockCode,
            this.cellItemName,
            this.Unit,
            this.xrTableCell12,
            this.xrTableCell5,
            this.xrTableCell10,
            this.xrTableCell4,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell3});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // cellStockCode
            // 
            this.cellStockCode.BorderColor = System.Drawing.Color.Silver;
            this.cellStockCode.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.cellStockCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cellStockCode.Name = "cellStockCode";
            this.cellStockCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 0, 0, 0, 100F);
            this.cellStockCode.StylePriority.UseBorderColor = false;
            this.cellStockCode.StylePriority.UseBorders = false;
            this.cellStockCode.StylePriority.UseFont = false;
            this.cellStockCode.StylePriority.UsePadding = false;
            this.cellStockCode.StylePriority.UseTextAlignment = false;
            this.cellStockCode.Text = "Stock Code";
            this.cellStockCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cellStockCode.Weight = 0.1629869206512542D;
            // 
            // cellItemName
            // 
            this.cellItemName.BorderColor = System.Drawing.Color.Silver;
            this.cellItemName.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.cellItemName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.cellItemName.Name = "cellItemName";
            this.cellItemName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.cellItemName.StylePriority.UseBorderColor = false;
            this.cellItemName.StylePriority.UseBorders = false;
            this.cellItemName.StylePriority.UseFont = false;
            this.cellItemName.StylePriority.UsePadding = false;
            this.cellItemName.StylePriority.UseTextAlignment = false;
            this.cellItemName.Text = "Item Name";
            this.cellItemName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.cellItemName.Weight = 0.41139754362176617D;
            // 
            // Unit
            // 
            this.Unit.BorderColor = System.Drawing.Color.Silver;
            this.Unit.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.Unit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unit.Name = "Unit";
            this.Unit.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.Unit.StylePriority.UseBorderColor = false;
            this.Unit.StylePriority.UseBorders = false;
            this.Unit.StylePriority.UseFont = false;
            this.Unit.StylePriority.UsePadding = false;
            this.Unit.StylePriority.UseTextAlignment = false;
            this.Unit.Text = "Unit";
            this.Unit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.Unit.Weight = 0.080440074723083968D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell12.StylePriority.UseBorderColor = false;
            this.xrTableCell12.StylePriority.UseBorders = false;
            this.xrTableCell12.StylePriority.UseFont = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            this.xrTableCell12.Text = "Manufacturer";
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell12.Weight = 0.32195022705742593D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell5.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell5.StylePriority.UseBorderColor = false;
            this.xrTableCell5.StylePriority.UseBorders = false;
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Expiry Date";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell5.Weight = 0.12309666231992575D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseBorderColor = false;
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "Batch";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell10.Weight = 0.12309648415640104D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
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
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell4.Weight = 0.12309649018064434D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell14.StylePriority.UseBorderColor = false;
            this.xrTableCell14.StylePriority.UseBorders = false;
            this.xrTableCell14.StylePriority.UseFont = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.StylePriority.UseTextAlignment = false;
            this.xrTableCell14.Text = "Damaged";
            this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell14.Weight = 0.12309649922859559D;
            // 
            // xrTableCell15
            // 
            this.xrTableCell15.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell15.Name = "xrTableCell15";
            this.xrTableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableCell15.StylePriority.UseBorderColor = false;
            this.xrTableCell15.StylePriority.UseFont = false;
            this.xrTableCell15.StylePriority.UsePadding = false;
            this.xrTableCell15.StylePriority.UseTextAlignment = false;
            this.xrTableCell15.Text = "Expired";
            this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell15.Weight = 0.1230964924311576D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BorderColor = System.Drawing.Color.Silver;
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 0, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseBorderColor = false;
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = " Remark";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell3.Weight = 0.09675853489726699D;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.White;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Category")});
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1.999998F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(455.888F, 22.41669F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.GroupUnion = DevExpress.XtraReports.UI.GroupFooterUnion.WithLastDetail;
            this.GroupFooter1.HeightF = 0F;
            this.GroupFooter1.Name = "GroupFooter1";
            this.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "DraftInventory";
            this.bindingSource1.DataSource = this.theDataSet;
            // 
            // theDataSet
            // 
            this.theDataSet.DataSetName = "TheDataSet";
            this.theDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DraftInventoryPrintout
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
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(33, 32, 206, 52);
            this.PageHeight = 850;
            this.PageWidth = 1100;
            this.Version = "11.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.StockStatusByPhysicalStore_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tblStockCode2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell cellStockCode;
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
        private DevExpress.XtraReports.UI.XRTableCell tblItemName;
        private DevExpress.XtraReports.UI.XRTableCell tblExpiry;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell tblUnit;
        private DevExpress.XtraReports.UI.XRTableCell cellManufacturer;
        private DevExpress.XtraReports.UI.XRTableCell tblBatch;
        private DevExpress.XtraReports.UI.XRTableCell tblDamaged;
        private DevExpress.XtraReports.UI.XRTableCell tblExpired;
        private DevExpress.XtraReports.UI.XRTableCell cellItemName;
        private DevExpress.XtraReports.UI.XRTableCell Unit;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell15;
        public DevExpress.XtraReports.UI.XRLabel WarehouseName;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        public DevExpress.XtraReports.UI.XRLabel xrPrintedBy;
        private TheDataSet theDataSet;
    }
}
