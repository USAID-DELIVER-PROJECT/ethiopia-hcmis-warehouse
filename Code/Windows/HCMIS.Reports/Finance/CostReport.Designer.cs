namespace HCMIS.Desktop.Reports
{
    partial class CostReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.pxLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrGRVLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCostedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCheckedBy = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrSubreportCostBuildup = new DevExpress.XtraReports.UI.XRSubreport();
            this.previousCostPrintout1 = new HCMIS.Desktop.Reports.PreviousCostPrintout();
            this.xrSubreportCostAnalysis = new DevExpress.XtraReports.UI.XRSubreport();
            this.costAnalysis1 = new HCMIS.Desktop.Reports.CostAnalysis();
            this.GroupHeader3 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.subReportCostCalculation = new DevExpress.XtraReports.UI.XRSubreport();
            this.costCalculationPrintout1 = new HCMIS.Desktop.Reports.CostCalculationPrintout();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.HasSubAccount = new DevExpress.XtraReports.UI.FormattingRule();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrInvoiceNoValue = new DevExpress.XtraReports.UI.XRLabel();
            this.xrInvoiceNo = new DevExpress.XtraReports.UI.XRLabel();
            this.GRVNO = new DevExpress.XtraReports.UI.XRLabel();
            this.NA = new DevExpress.XtraReports.UI.FormattingRule();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrWarehouse = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.previousCostPrintout1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costAnalysis1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCalculationPrintout1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Detail.HeightF = 42.33333F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.StylePriority.UseFont = false;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.pxLogo});
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 311.5417F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // pxLogo
            // 
            this.pxLogo.BorderColor = System.Drawing.Color.Transparent;
            this.pxLogo.BorderWidth = 0;
            this.pxLogo.Dpi = 254F;
            this.pxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pxLogo.Image")));
            this.pxLogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 66.96103F);
            this.pxLogo.Name = "pxLogo";
            this.pxLogo.SizeF = new System.Drawing.SizeF(2675F, 244.5807F);
            this.pxLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.pxLogo.StylePriority.UseBorderColor = false;
            this.pxLogo.StylePriority.UseBorderWidth = false;
            // 
            // xrDate
            // 
            this.xrDate.BorderColor = System.Drawing.Color.Gray;
            this.xrDate.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrDate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrDate.BorderWidth = 1;
            this.xrDate.Dpi = 254F;
            this.xrDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrDate.LocationFloat = new DevExpress.Utils.PointFloat(2279.831F, 25.00001F);
            this.xrDate.Name = "xrDate";
            this.xrDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrDate.SizeF = new System.Drawing.SizeF(368.1697F, 47.94242F);
            this.xrDate.StylePriority.UseBorderColor = false;
            this.xrDate.StylePriority.UseBorderDashStyle = false;
            this.xrDate.StylePriority.UseBorders = false;
            this.xrDate.StylePriority.UseBorderWidth = false;
            this.xrDate.StylePriority.UseFont = false;
            this.xrDate.StylePriority.UseTextAlignment = false;
            this.xrDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(2024.923F, 25.00001F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(222.25F, 47.94247F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Date";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrGRVLabel
            // 
            this.xrGRVLabel.Dpi = 254F;
            this.xrGRVLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrGRVLabel.LocationFloat = new DevExpress.Utils.PointFloat(10.59754F, 161.3964F);
            this.xrGRVLabel.Name = "xrGRVLabel";
            this.xrGRVLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrGRVLabel.SizeF = new System.Drawing.SizeF(261.9373F, 47.94247F);
            this.xrGRVLabel.StylePriority.UseFont = false;
            this.xrGRVLabel.StylePriority.UseTextAlignment = false;
            this.xrGRVLabel.Text = "GRNF No.";
            this.xrGRVLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel18,
            this.xrCostedBy,
            this.xrCheckedBy,
            this.xrLabel12,
            this.xrPageInfo1});
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 98.2133F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel18
            // 
            this.xrLabel18.Dpi = 254F;
            this.xrLabel18.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(129.2533F, 0F);
            this.xrLabel18.Name = "xrLabel18";
            this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel18.SizeF = new System.Drawing.SizeF(222.25F, 47.94247F);
            this.xrLabel18.StylePriority.UseFont = false;
            this.xrLabel18.StylePriority.UseTextAlignment = false;
            this.xrLabel18.Text = "Costed By:";
            this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCostedBy
            // 
            this.xrCostedBy.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrCostedBy.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrCostedBy.BorderWidth = 1;
            this.xrCostedBy.Dpi = 254F;
            this.xrCostedBy.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrCostedBy.LocationFloat = new DevExpress.Utils.PointFloat(380.6074F, 0F);
            this.xrCostedBy.Name = "xrCostedBy";
            this.xrCostedBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrCostedBy.SizeF = new System.Drawing.SizeF(284.7667F, 47.94247F);
            this.xrCostedBy.StylePriority.UseBorderDashStyle = false;
            this.xrCostedBy.StylePriority.UseBorders = false;
            this.xrCostedBy.StylePriority.UseBorderWidth = false;
            this.xrCostedBy.StylePriority.UseFont = false;
            this.xrCostedBy.StylePriority.UseTextAlignment = false;
            this.xrCostedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrCheckedBy
            // 
            this.xrCheckedBy.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrCheckedBy.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrCheckedBy.BorderWidth = 1;
            this.xrCheckedBy.Dpi = 254F;
            this.xrCheckedBy.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrCheckedBy.LocationFloat = new DevExpress.Utils.PointFloat(1653.724F, 0F);
            this.xrCheckedBy.Name = "xrCheckedBy";
            this.xrCheckedBy.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrCheckedBy.SizeF = new System.Drawing.SizeF(274.7705F, 47.94247F);
            this.xrCheckedBy.StylePriority.UseBorderDashStyle = false;
            this.xrCheckedBy.StylePriority.UseBorders = false;
            this.xrCheckedBy.StylePriority.UseBorderWidth = false;
            this.xrCheckedBy.StylePriority.UseFont = false;
            this.xrCheckedBy.StylePriority.UseTextAlignment = false;
            this.xrCheckedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Dpi = 254F;
            this.xrLabel12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(1302.568F, 0F);
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(285.75F, 47.94247F);
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "Checked By:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Dpi = 254F;
            this.xrPageInfo1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(2546.188F, 39.63372F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(67.4165F, 44.97916F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            // 
            // xrSubreportCostBuildup
            // 
            this.xrSubreportCostBuildup.Dpi = 254F;
            this.xrSubreportCostBuildup.LocationFloat = new DevExpress.Utils.PointFloat(0F, 460.375F);
            this.xrSubreportCostBuildup.Name = "xrSubreportCostBuildup";
            this.xrSubreportCostBuildup.ReportSource = this.previousCostPrintout1;
            this.xrSubreportCostBuildup.SizeF = new System.Drawing.SizeF(2664.417F, 421.8336F);
            // 
            // xrSubreportCostAnalysis
            // 
            this.xrSubreportCostAnalysis.Dpi = 254F;
            this.xrSubreportCostAnalysis.LocationFloat = new DevExpress.Utils.PointFloat(0F, 926.0415F);
            this.xrSubreportCostAnalysis.Name = "xrSubreportCostAnalysis";
            this.xrSubreportCostAnalysis.ReportSource = this.costAnalysis1;
            this.xrSubreportCostAnalysis.SizeF = new System.Drawing.SizeF(1468.5F, 421.8336F);
            // 
            // GroupHeader3
            // 
            this.GroupHeader3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subReportCostCalculation,
            this.xrSubreportCostBuildup,
            this.xrSubreportCostAnalysis});
            this.GroupHeader3.Dpi = 254F;
            this.GroupHeader3.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("PrintedGRVNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending),
            new DevExpress.XtraReports.UI.GroupField("PhysicalStoreTypeName", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader3.HeightF = 1347.875F;
            this.GroupHeader3.Name = "GroupHeader3";
            // 
            // subReportCostCalculation
            // 
            this.subReportCostCalculation.Dpi = 254F;
            this.subReportCostCalculation.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.subReportCostCalculation.Name = "subReportCostCalculation";
            this.subReportCostCalculation.ReportSource = this.costCalculationPrintout1;
            this.subReportCostCalculation.SizeF = new System.Drawing.SizeF(2675F, 421.8336F);
            // 
            // xrLabel3
            // 
            this.xrLabel3.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel3.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel3.BorderWidth = 1;
            this.xrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Activity")});
            this.xrLabel3.Dpi = 254F;
            this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.FormattingRules.Add(this.HasSubAccount);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1325.433F, 227.4358F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(555.5995F, 47.9425F);
            this.xrLabel3.StylePriority.UseBorderColor = false;
            this.xrLabel3.StylePriority.UseBorderDashStyle = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseBorderWidth = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "xrTransitValue";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // HasSubAccount
            // 
            this.HasSubAccount.Condition = "[SubAccount] != [Account]";
            // 
            // 
            // 
            this.HasSubAccount.Formatting.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.HasSubAccount.Name = "HasSubAccount";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1103.405F, 227.4361F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(200.4371F, 47.94243F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Activity";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel21
            // 
            this.xrLabel21.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel21.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel21.BorderWidth = 1;
            this.xrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SubAccount")});
            this.xrLabel21.Dpi = 254F;
            this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel21.FormattingRules.Add(this.HasSubAccount);
            this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(1323.432F, 161.396F);
            this.xrLabel21.Name = "xrLabel21";
            this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel21.SizeF = new System.Drawing.SizeF(555.5994F, 47.94247F);
            this.xrLabel21.StylePriority.UseBorderColor = false;
            this.xrLabel21.StylePriority.UseBorderDashStyle = false;
            this.xrLabel21.StylePriority.UseBorders = false;
            this.xrLabel21.StylePriority.UseBorderWidth = false;
            this.xrLabel21.StylePriority.UseFont = false;
            this.xrLabel21.StylePriority.UseTextAlignment = false;
            this.xrLabel21.Text = "xrTransitValue";
            this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel22
            // 
            this.xrLabel22.Dpi = 254F;
            this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(10.59754F, 227.4363F);
            this.xrLabel22.Name = "xrLabel22";
            this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel22.SizeF = new System.Drawing.SizeF(261.9373F, 47.94234F);
            this.xrLabel22.StylePriority.UseFont = false;
            this.xrLabel22.StylePriority.UseTextAlignment = false;
            this.xrLabel22.Text = "Supplier";
            this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel23
            // 
            this.xrLabel23.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel23.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel23.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel23.BorderWidth = 1;
            this.xrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SupplierName")});
            this.xrLabel23.Dpi = 254F;
            this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(302.9998F, 227.4361F);
            this.xrLabel23.Name = "xrLabel23";
            this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel23.SizeF = new System.Drawing.SizeF(612.0051F, 47.9425F);
            this.xrLabel23.StylePriority.UseBorderColor = false;
            this.xrLabel23.StylePriority.UseBorderDashStyle = false;
            this.xrLabel23.StylePriority.UseBorders = false;
            this.xrLabel23.StylePriority.UseBorderWidth = false;
            this.xrLabel23.StylePriority.UseFont = false;
            this.xrLabel23.StylePriority.UseTextAlignment = false;
            this.xrLabel23.Text = "xrInsuranceValue";
            this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Dpi = 254F;
            this.xrLabel10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(1103.404F, 97.896F);
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(198.4371F, 47.94249F);
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Account";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.BorderColor = System.Drawing.Color.DarkGray;
            this.xrLabel11.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel11.BorderWidth = 1;
            this.xrLabel11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Account")});
            this.xrLabel11.Dpi = 254F;
            this.xrLabel11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(1323.432F, 97.896F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(555.6005F, 47.9425F);
            this.xrLabel11.StylePriority.UseBorderColor = false;
            this.xrLabel11.StylePriority.UseBorderDashStyle = false;
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseBorderWidth = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "xrAirValue";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel14
            // 
            this.xrLabel14.Dpi = 254F;
            this.xrLabel14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(1103.405F, 161.396F);
            this.xrLabel14.Multiline = true;
            this.xrLabel14.Name = "xrLabel14";
            this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel14.SizeF = new System.Drawing.SizeF(198.4362F, 47.94244F);
            this.xrLabel14.StylePriority.UseFont = false;
            this.xrLabel14.StylePriority.UseTextAlignment = false;
            this.xrLabel14.Text = "Sub Account \r\n";
            this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrInvoiceNoValue
            // 
            this.xrInvoiceNoValue.BorderColor = System.Drawing.Color.DarkGray;
            this.xrInvoiceNoValue.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrInvoiceNoValue.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrInvoiceNoValue.BorderWidth = 1;
            this.xrInvoiceNoValue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "STVOrInvoiceNo")});
            this.xrInvoiceNoValue.Dpi = 254F;
            this.xrInvoiceNoValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrInvoiceNoValue.LocationFloat = new DevExpress.Utils.PointFloat(302.9998F, 97.89624F);
            this.xrInvoiceNoValue.Name = "xrInvoiceNoValue";
            this.xrInvoiceNoValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrInvoiceNoValue.SizeF = new System.Drawing.SizeF(612.0051F, 47.94245F);
            this.xrInvoiceNoValue.StylePriority.UseBorderColor = false;
            this.xrInvoiceNoValue.StylePriority.UseBorderDashStyle = false;
            this.xrInvoiceNoValue.StylePriority.UseBorders = false;
            this.xrInvoiceNoValue.StylePriority.UseBorderWidth = false;
            this.xrInvoiceNoValue.StylePriority.UseFont = false;
            this.xrInvoiceNoValue.StylePriority.UseTextAlignment = false;
            this.xrInvoiceNoValue.Text = "xrInvoiceNoValue";
            this.xrInvoiceNoValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrInvoiceNo
            // 
            this.xrInvoiceNo.Dpi = 254F;
            this.xrInvoiceNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrInvoiceNo.LocationFloat = new DevExpress.Utils.PointFloat(10.59754F, 97.896F);
            this.xrInvoiceNo.Name = "xrInvoiceNo";
            this.xrInvoiceNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrInvoiceNo.SizeF = new System.Drawing.SizeF(261.9373F, 47.94247F);
            this.xrInvoiceNo.StylePriority.UseFont = false;
            this.xrInvoiceNo.StylePriority.UseTextAlignment = false;
            this.xrInvoiceNo.Text = "Invoice No.";
            this.xrInvoiceNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // GRVNO
            // 
            this.GRVNO.BorderColor = System.Drawing.Color.DarkGray;
            this.GRVNO.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.GRVNO.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.GRVNO.BorderWidth = 1;
            this.GRVNO.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "RefNo")});
            this.GRVNO.Dpi = 254F;
            this.GRVNO.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRVNO.LocationFloat = new DevExpress.Utils.PointFloat(302.9998F, 161.3964F);
            this.GRVNO.Name = "GRVNO";
            this.GRVNO.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.GRVNO.SizeF = new System.Drawing.SizeF(612.0051F, 47.94241F);
            this.GRVNO.StylePriority.UseBorderColor = false;
            this.GRVNO.StylePriority.UseBorderDashStyle = false;
            this.GRVNO.StylePriority.UseBorders = false;
            this.GRVNO.StylePriority.UseBorderWidth = false;
            this.GRVNO.StylePriority.UseFont = false;
            this.GRVNO.StylePriority.UseTextAlignment = false;
            this.GRVNO.Text = "GRVNO";
            this.GRVNO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // NA
            // 
            this.NA.Condition = "[Account] == [SubAccount]";
            // 
            // 
            // 
            this.NA.Formatting.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.NA.Name = "NA";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrWarehouse,
            this.xrLabel4,
            this.GRVNO,
            this.xrGRVLabel,
            this.xrInvoiceNo,
            this.xrInvoiceNoValue,
            this.xrLabel2,
            this.xrLabel14,
            this.xrLabel11,
            this.xrLabel10,
            this.xrLabel23,
            this.xrLabel22,
            this.xrLabel21,
            this.xrLabel1,
            this.xrLabel3,
            this.xrDate});
            this.GroupHeader1.Dpi = 254F;
            this.GroupHeader1.HeightF = 278.0244F;
            this.GroupHeader1.Level = 1;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrWarehouse
            // 
            this.xrWarehouse.BorderColor = System.Drawing.Color.DarkGray;
            this.xrWarehouse.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrWarehouse.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrWarehouse.BorderWidth = 1;
            this.xrWarehouse.Dpi = 254F;
            this.xrWarehouse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrWarehouse.FormattingRules.Add(this.HasSubAccount);
            this.xrWarehouse.LocationFloat = new DevExpress.Utils.PointFloat(2119.401F, 97.896F);
            this.xrWarehouse.Name = "xrWarehouse";
            this.xrWarehouse.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrWarehouse.SizeF = new System.Drawing.SizeF(555.5995F, 47.9425F);
            this.xrWarehouse.StylePriority.UseBorderColor = false;
            this.xrWarehouse.StylePriority.UseBorderDashStyle = false;
            this.xrWarehouse.StylePriority.UseBorders = false;
            this.xrWarehouse.StylePriority.UseBorderWidth = false;
            this.xrWarehouse.StylePriority.UseFont = false;
            this.xrWarehouse.StylePriority.UseTextAlignment = false;
            this.xrWarehouse.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1897.373F, 97.89632F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(200.4371F, 47.94243F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Warehouse:";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "CostAnalysis";
            this.bindingSource1.DataSource = typeof(HCMIS.Desktop.Reports.Helpers.TheDataSet);
            // 
            // xrLabel5
            // 
            this.xrLabel5.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel5.BorderWidth = 1;
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(690.5625F, 0F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(284.7667F, 47.94247F);
            this.xrLabel5.StylePriority.UseBorderDashStyle = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseBorderWidth = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel6.BorderWidth = 1;
            this.xrLabel6.Dpi = 254F;
            this.xrLabel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(1962.406F, 0F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(284.7667F, 47.94247F);
            this.xrLabel6.StylePriority.UseBorderDashStyle = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseBorderWidth = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // CostReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader3,
            this.GroupHeader1});
            this.BorderWidth = 0;
            this.DataSource = this.bindingSource1;
            this.Dpi = 254F;
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.NA,
            this.HasSubAccount});
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(86, 33, 312, 98);
            this.PageHeight = 2159;
            this.PageWidth = 2794;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 31.75F;
            this.Version = "11.2";
            ((System.ComponentModel.ISupportInitialize)(this.previousCostPrintout1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costAnalysis1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costCalculationPrintout1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        public DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private System.Windows.Forms.BindingSource bindingSource1;
        public DevExpress.XtraReports.UI.XRLabel xrDate;
        public DevExpress.XtraReports.UI.XRLabel xrLabel2;
        public DevExpress.XtraReports.UI.XRLabel xrGRVLabel;
        public DevExpress.XtraReports.UI.XRLabel xrCheckedBy;
        private DevExpress.XtraReports.UI.XRLabel xrLabel12;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader3;
        public DevExpress.XtraReports.UI.XRLabel xrInvoiceNo;
        public DevExpress.XtraReports.UI.XRLabel xrInvoiceNoValue;
        private DevExpress.XtraReports.UI.XRLabel xrLabel18;
        public DevExpress.XtraReports.UI.XRLabel xrCostedBy;
        public DevExpress.XtraReports.UI.XRLabel xrLabel21;
        public DevExpress.XtraReports.UI.XRLabel xrLabel22;
        public DevExpress.XtraReports.UI.XRLabel xrLabel23;
        public DevExpress.XtraReports.UI.XRLabel xrLabel10;
        public DevExpress.XtraReports.UI.XRLabel xrLabel11;
        public DevExpress.XtraReports.UI.XRLabel xrLabel14;
        private DevExpress.XtraReports.UI.XRPictureBox pxLogo;
        private DevExpress.XtraReports.UI.FormattingRule NA;
        private DevExpress.XtraReports.UI.FormattingRule HasSubAccount;
        public DevExpress.XtraReports.UI.XRLabel GRVNO;
        public DevExpress.XtraReports.UI.XRLabel xrLabel3;
        public DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private CostCalculationPrintout costCalculationPrintout1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        public DevExpress.XtraReports.UI.XRSubreport subReportCostCalculation;
        public DevExpress.XtraReports.UI.XRSubreport xrSubreportCostBuildup;
        public DevExpress.XtraReports.UI.XRSubreport xrSubreportCostAnalysis;
        public DevExpress.XtraReports.UI.XRLabel xrWarehouse;
        public DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private PreviousCostPrintout previousCostPrintout1;
        private CostAnalysis costAnalysis1;
        public DevExpress.XtraReports.UI.XRLabel xrLabel6;
        public DevExpress.XtraReports.UI.XRLabel xrLabel5;
    }
}
