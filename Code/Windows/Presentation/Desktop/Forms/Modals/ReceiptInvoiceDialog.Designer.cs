namespace HCMIS.Desktop.Forms.WorkFlow
{
    partial class ReceiptInvoiceDialog
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblOrderNumber = new DevExpress.XtraEditors.LabelControl();
            this.lkDocumentType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblOrderStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblPOType = new DevExpress.XtraEditors.LabelControl();
            this.lblActivity = new DevExpress.XtraEditors.LabelControl();
            this.lblSubAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.lblSupplier = new DevExpress.XtraEditors.LabelControl();
            this.lblRefNo = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.lblPOTypeDetail = new DevExpress.XtraEditors.LabelControl();
            this.lblInvoiceTypeDetail = new DevExpress.XtraEditors.LabelControl();
            this.lblPONumberDetail = new DevExpress.XtraEditors.LabelControl();
            this.lblAccountDetail = new DevExpress.XtraEditors.LabelControl();
            this.lblActivityDetail = new DevExpress.XtraEditors.LabelControl();
            this.lblSubAccountDetail = new DevExpress.XtraEditors.LabelControl();
            this.lblInvoiceNoDetail = new DevExpress.XtraEditors.LabelControl();
            this.lblModeDetail = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridInvoiceDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewInvoiceDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpiryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBatchNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderdQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoicedQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMargin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPlusMinus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.plusMinusButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colIsSaved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colguid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.HeaderGroupDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem54 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem56 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem52 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lkInvoiceType = new DevExpress.XtraEditors.LookUpEdit();
            this.txtInvoiceCustomDutyTax = new DevExpress.XtraEditors.TextEdit();
            this.dtInvoiceDate = new DevExpress.XtraEditors.DateEdit();
            this.lkCurrencyLCID = new DevExpress.XtraEditors.LookUpEdit();
            this.txtInvoiceCBEServiceCharge = new DevExpress.XtraEditors.TextEdit();
            this.gridGrv = new DevExpress.XtraGrid.GridControl();
            this.gridGrvView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGRVNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferTransitNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDamaged = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomDutyTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtExchangeRate = new DevExpress.XtraEditors.TextEdit();
            this.txtTransitNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtWayBill = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceSeaFreight = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtInvoiceAirFreight = new DevExpress.XtraEditors.TextEdit();
            this.btnSaveInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.txtInsurance = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalValue = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoiceInlandFreight = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabInvoice = new DevExpress.XtraLayout.TabbedControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.HeaderGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutFinancialInformation = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutGoodsReceived = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem57 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidation = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem51 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem53 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem55 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkDocumentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInvoiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusMinusButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkInvoiceType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCustomDutyTax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCurrencyLCID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCBEServiceCharge.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrvView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransitNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWayBill.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceSeaFreight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceAirFreight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceInlandFreight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFinancialInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGoodsReceived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.lblOrderNumber);
            this.layoutControl1.Controls.Add(this.lkDocumentType);
            this.layoutControl1.Controls.Add(this.lblOrderStatus);
            this.layoutControl1.Controls.Add(this.lblPOType);
            this.layoutControl1.Controls.Add(this.lblActivity);
            this.layoutControl1.Controls.Add(this.lblSubAccount);
            this.layoutControl1.Controls.Add(this.lblAccount);
            this.layoutControl1.Controls.Add(this.lblMode);
            this.layoutControl1.Controls.Add(this.lblSupplier);
            this.layoutControl1.Controls.Add(this.lblRefNo);
            this.layoutControl1.Controls.Add(this.layoutControl2);
            this.layoutControl1.Controls.Add(this.lkInvoiceType);
            this.layoutControl1.Controls.Add(this.txtInvoiceCustomDutyTax);
            this.layoutControl1.Controls.Add(this.dtInvoiceDate);
            this.layoutControl1.Controls.Add(this.lkCurrencyLCID);
            this.layoutControl1.Controls.Add(this.txtInvoiceCBEServiceCharge);
            this.layoutControl1.Controls.Add(this.gridGrv);
            this.layoutControl1.Controls.Add(this.txtExchangeRate);
            this.layoutControl1.Controls.Add(this.txtTransitNumber);
            this.layoutControl1.Controls.Add(this.txtWayBill);
            this.layoutControl1.Controls.Add(this.txtInvoiceSeaFreight);
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.txtInvoiceAirFreight);
            this.layoutControl1.Controls.Add(this.btnSaveInvoice);
            this.layoutControl1.Controls.Add(this.txtInsurance);
            this.layoutControl1.Controls.Add(this.txtInvoiceNumber);
            this.layoutControl1.Controls.Add(this.txtTotalValue);
            this.layoutControl1.Controls.Add(this.txtInvoiceInlandFreight);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem24});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(161, 609, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1067, 535);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.Location = new System.Drawing.Point(77, 81);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(159, 16);
            this.lblOrderNumber.StyleController = this.layoutControl1;
            this.lblOrderNumber.TabIndex = 73;
            this.lblOrderNumber.Click += new System.EventHandler(this.lblPONumber_Click);
            // 
            // lkDocumentType
            // 
            this.lkDocumentType.Location = new System.Drawing.Point(930, 127);
            this.lkDocumentType.Name = "lkDocumentType";
            this.lkDocumentType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkDocumentType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lkDocumentType.Properties.DisplayMember = "Name";
            this.lkDocumentType.Properties.NullText = "Select Document Type";
            this.lkDocumentType.Properties.ShowFooter = false;
            this.lkDocumentType.Properties.ValueMember = "DocumentTypeID";
            this.lkDocumentType.Size = new System.Drawing.Size(106, 20);
            this.lkDocumentType.StyleController = this.layoutControl1;
            this.lkDocumentType.TabIndex = 82;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.Location = new System.Drawing.Point(871, 81);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(172, 16);
            this.lblOrderStatus.StyleController = this.layoutControl1;
            this.lblOrderStatus.TabIndex = 81;
            // 
            // lblPOType
            // 
            this.lblPOType.Location = new System.Drawing.Point(612, 81);
            this.lblPOType.Name = "lblPOType";
            this.lblPOType.Size = new System.Drawing.Size(175, 16);
            this.lblPOType.StyleController = this.layoutControl1;
            this.lblPOType.TabIndex = 80;
            this.lblPOType.Click += new System.EventHandler(this.lblPoType_Click);
            // 
            // lblActivity
            // 
            this.lblActivity.Location = new System.Drawing.Point(871, 61);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(172, 16);
            this.lblActivity.StyleController = this.layoutControl1;
            this.lblActivity.TabIndex = 79;
            // 
            // lblSubAccount
            // 
            this.lblSubAccount.Location = new System.Drawing.Point(612, 61);
            this.lblSubAccount.Name = "lblSubAccount";
            this.lblSubAccount.Size = new System.Drawing.Size(175, 16);
            this.lblSubAccount.StyleController = this.layoutControl1;
            this.lblSubAccount.TabIndex = 78;
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(331, 61);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(199, 16);
            this.lblAccount.StyleController = this.layoutControl1;
            this.lblAccount.TabIndex = 77;
            this.lblAccount.Click += new System.EventHandler(this.lblAccount_Click);
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(64, 61);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(209, 16);
            this.lblMode.StyleController = this.layoutControl1;
            this.lblMode.TabIndex = 76;
            this.lblMode.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(331, 81);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(199, 16);
            this.lblSupplier.StyleController = this.layoutControl1;
            this.lblSupplier.TabIndex = 75;
            // 
            // lblRefNo
            // 
            this.lblRefNo.Location = new System.Drawing.Point(64, 81);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(209, 16);
            this.lblRefNo.StyleController = this.layoutControl1;
            this.lblRefNo.TabIndex = 74;
            // 
            // layoutControl2
            // 
            this.layoutControl2.AllowCustomizationMenu = false;
            this.layoutControl2.Controls.Add(this.lblPOTypeDetail);
            this.layoutControl2.Controls.Add(this.lblInvoiceTypeDetail);
            this.layoutControl2.Controls.Add(this.lblPONumberDetail);
            this.layoutControl2.Controls.Add(this.lblAccountDetail);
            this.layoutControl2.Controls.Add(this.lblActivityDetail);
            this.layoutControl2.Controls.Add(this.lblSubAccountDetail);
            this.layoutControl2.Controls.Add(this.lblInvoiceNoDetail);
            this.layoutControl2.Controls.Add(this.lblModeDetail);
            this.layoutControl2.Controls.Add(this.btnCancelInvoice);
            this.layoutControl2.Controls.Add(this.btnSave);
            this.layoutControl2.Controls.Add(this.gridInvoiceDetail);
            this.layoutControl2.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem44});
            this.layoutControl2.Location = new System.Drawing.Point(13, 35);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(283, 334, 250, 350);
            this.layoutControl2.Root = this.Root;
            this.layoutControl2.Size = new System.Drawing.Size(1039, 483);
            this.layoutControl2.TabIndex = 71;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // lblPOTypeDetail
            // 
            this.lblPOTypeDetail.Location = new System.Drawing.Point(597, 46);
            this.lblPOTypeDetail.Name = "lblPOTypeDetail";
            this.lblPOTypeDetail.Size = new System.Drawing.Size(174, 16);
            this.lblPOTypeDetail.StyleController = this.layoutControl2;
            this.lblPOTypeDetail.TabIndex = 81;
            // 
            // lblInvoiceTypeDetail
            // 
            this.lblInvoiceTypeDetail.Location = new System.Drawing.Point(88, 46);
            this.lblInvoiceTypeDetail.Name = "lblInvoiceTypeDetail";
            this.lblInvoiceTypeDetail.Size = new System.Drawing.Size(171, 16);
            this.lblInvoiceTypeDetail.StyleController = this.layoutControl2;
            this.lblInvoiceTypeDetail.TabIndex = 80;
            // 
            // lblPONumberDetail
            // 
            this.lblPONumberDetail.Location = new System.Drawing.Point(336, 46);
            this.lblPONumberDetail.Name = "lblPONumberDetail";
            this.lblPONumberDetail.Size = new System.Drawing.Size(179, 16);
            this.lblPONumberDetail.StyleController = this.layoutControl2;
            this.lblPONumberDetail.TabIndex = 79;
            this.lblPONumberDetail.Click += new System.EventHandler(this.lblPONumberDetail_Click);
            // 
            // lblAccountDetail
            // 
            this.lblAccountDetail.Location = new System.Drawing.Point(336, 26);
            this.lblAccountDetail.Name = "lblAccountDetail";
            this.lblAccountDetail.Size = new System.Drawing.Size(179, 16);
            this.lblAccountDetail.StyleController = this.layoutControl2;
            this.lblAccountDetail.TabIndex = 78;
            // 
            // lblActivityDetail
            // 
            this.lblActivityDetail.Location = new System.Drawing.Point(827, 26);
            this.lblActivityDetail.Name = "lblActivityDetail";
            this.lblActivityDetail.Size = new System.Drawing.Size(205, 16);
            this.lblActivityDetail.StyleController = this.layoutControl2;
            this.lblActivityDetail.TabIndex = 77;
            // 
            // lblSubAccountDetail
            // 
            this.lblSubAccountDetail.Location = new System.Drawing.Point(597, 26);
            this.lblSubAccountDetail.Name = "lblSubAccountDetail";
            this.lblSubAccountDetail.Size = new System.Drawing.Size(174, 16);
            this.lblSubAccountDetail.StyleController = this.layoutControl2;
            this.lblSubAccountDetail.TabIndex = 76;
            // 
            // lblInvoiceNoDetail
            // 
            this.lblInvoiceNoDetail.Location = new System.Drawing.Point(74, 46);
            this.lblInvoiceNoDetail.Name = "lblInvoiceNoDetail";
            this.lblInvoiceNoDetail.Size = new System.Drawing.Size(185, 16);
            this.lblInvoiceNoDetail.StyleController = this.layoutControl2;
            this.lblInvoiceNoDetail.TabIndex = 75;
            // 
            // lblModeDetail
            // 
            this.lblModeDetail.Location = new System.Drawing.Point(88, 26);
            this.lblModeDetail.Name = "lblModeDetail";
            this.lblModeDetail.Size = new System.Drawing.Size(171, 16);
            this.lblModeDetail.StyleController = this.layoutControl2;
            this.lblModeDetail.TabIndex = 74;
            // 
            // btnCancelInvoice
            // 
            this.btnCancelInvoice.Image = global::HCMIS.Desktop.Properties.Resources.cross;
            this.btnCancelInvoice.Location = new System.Drawing.Point(895, 459);
            this.btnCancelInvoice.Name = "btnCancelInvoice";
            this.btnCancelInvoice.Size = new System.Drawing.Size(142, 22);
            this.btnCancelInvoice.StyleController = this.layoutControl2;
            this.btnCancelInvoice.TabIndex = 7;
            this.btnCancelInvoice.Text = "Cancel";
            this.btnCancelInvoice.Click += new System.EventHandler(this.btnCancelInvoice_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::HCMIS.Desktop.Properties.Resources.disk;
            this.btnSave.Location = new System.Drawing.Point(749, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 22);
            this.btnSave.StyleController = this.layoutControl2;
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridInvoiceDetail
            // 
            this.gridInvoiceDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridInvoiceDetail.Location = new System.Drawing.Point(7, 66);
            this.gridInvoiceDetail.MainView = this.gridViewInvoiceDetail;
            this.gridInvoiceDetail.Name = "gridInvoiceDetail";
            this.gridInvoiceDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.plusMinusButtonEdit});
            this.gridInvoiceDetail.Size = new System.Drawing.Size(1025, 384);
            this.gridInvoiceDetail.TabIndex = 4;
            this.gridInvoiceDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInvoiceDetail});
            this.gridInvoiceDetail.Click += new System.EventHandler(this.gridInvoiceDetail_Click);
            // 
            // gridViewInvoiceDetail
            // 
            this.gridViewInvoiceDetail.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewInvoiceDetail.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridViewInvoiceDetail.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridViewInvoiceDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemName,
            this.colUnit,
            this.colManufacturer,
            this.colExpiryDate,
            this.colBatchNo,
            this.colOrderdQuantity,
            this.colInvoicedQty,
            this.colUnitPrice,
            this.colTotalCost,
            this.colMargin,
            this.colPlusMinus,
            this.colIsSaved,
            this.colguid});
            this.gridViewInvoiceDetail.GridControl = this.gridInvoiceDetail;
            this.gridViewInvoiceDetail.Name = "gridViewInvoiceDetail";
            this.gridViewInvoiceDetail.OptionsCustomization.AllowColumnMoving = false;
            this.gridViewInvoiceDetail.OptionsCustomization.AllowColumnResizing = false;
            this.gridViewInvoiceDetail.OptionsCustomization.AllowFilter = false;
            this.gridViewInvoiceDetail.OptionsCustomization.AllowGroup = false;
            this.gridViewInvoiceDetail.OptionsCustomization.AllowSort = false;
            this.gridViewInvoiceDetail.OptionsMenu.EnableColumnMenu = false;
            this.gridViewInvoiceDetail.OptionsMenu.EnableFooterMenu = false;
            this.gridViewInvoiceDetail.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridViewInvoiceDetail.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewInvoiceDetail.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridViewInvoiceDetail.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridViewInvoiceDetail.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridViewInvoiceDetail.OptionsMenu.ShowSplitItem = false;
            this.gridViewInvoiceDetail.OptionsView.AllowCellMerge = true;
            this.gridViewInvoiceDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewInvoiceDetail.OptionsView.ShowGroupPanel = false;
            this.gridViewInvoiceDetail.OptionsView.ShowIndicator = false;
            this.gridViewInvoiceDetail.CellMerge += new DevExpress.XtraGrid.Views.Grid.CellMergeEventHandler(this.gridViewInvoiceDetail_CellMerge);
            this.gridViewInvoiceDetail.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewInvoiceDetail_CellValueChanged);
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Item";
            this.colItemName.FieldName = "FullItemName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowFocus = false;
            this.colItemName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsColumn.AllowIncrementalSearch = false;
            this.colItemName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsColumn.AllowMove = false;
            this.colItemName.OptionsColumn.AllowShowHide = false;
            this.colItemName.OptionsColumn.AllowSize = false;
            this.colItemName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsFilter.AllowAutoFilter = false;
            this.colItemName.OptionsFilter.AllowFilter = false;
            this.colItemName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colItemName.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 219;
            // 
            // colUnit
            // 
            this.colUnit.Caption = "Unit";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.OptionsColumn.AllowFocus = false;
            this.colUnit.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsColumn.AllowIncrementalSearch = false;
            this.colUnit.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsColumn.AllowMove = false;
            this.colUnit.OptionsColumn.AllowShowHide = false;
            this.colUnit.OptionsColumn.AllowSize = false;
            this.colUnit.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsFilter.AllowAutoFilter = false;
            this.colUnit.OptionsFilter.AllowFilter = false;
            this.colUnit.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colUnit.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colUnit.Visible = true;
            this.colUnit.VisibleIndex = 1;
            this.colUnit.Width = 65;
            // 
            // colManufacturer
            // 
            this.colManufacturer.Caption = "Manufacturer";
            this.colManufacturer.FieldName = "Manufacturer";
            this.colManufacturer.Name = "colManufacturer";
            this.colManufacturer.OptionsColumn.AllowEdit = false;
            this.colManufacturer.OptionsColumn.AllowFocus = false;
            this.colManufacturer.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsColumn.AllowIncrementalSearch = false;
            this.colManufacturer.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsColumn.AllowMove = false;
            this.colManufacturer.OptionsColumn.AllowShowHide = false;
            this.colManufacturer.OptionsColumn.AllowSize = false;
            this.colManufacturer.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.AllowAutoFilter = false;
            this.colManufacturer.OptionsFilter.AllowFilter = false;
            this.colManufacturer.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colManufacturer.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.Visible = true;
            this.colManufacturer.VisibleIndex = 2;
            this.colManufacturer.Width = 131;
            // 
            // colExpiryDate
            // 
            this.colExpiryDate.Caption = "Expiry Date";
            this.colExpiryDate.FieldName = "ExpiryDate";
            this.colExpiryDate.Name = "colExpiryDate";
            this.colExpiryDate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.OptionsColumn.AllowIncrementalSearch = false;
            this.colExpiryDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.OptionsColumn.AllowMove = false;
            this.colExpiryDate.OptionsColumn.AllowShowHide = false;
            this.colExpiryDate.OptionsColumn.AllowSize = false;
            this.colExpiryDate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.OptionsFilter.AllowAutoFilter = false;
            this.colExpiryDate.OptionsFilter.AllowFilter = false;
            this.colExpiryDate.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colExpiryDate.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colExpiryDate.Visible = true;
            this.colExpiryDate.VisibleIndex = 3;
            this.colExpiryDate.Width = 65;
            // 
            // colBatchNo
            // 
            this.colBatchNo.Caption = "Batch";
            this.colBatchNo.FieldName = "BatchNumber";
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colBatchNo.OptionsColumn.AllowIncrementalSearch = false;
            this.colBatchNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colBatchNo.OptionsColumn.AllowMove = false;
            this.colBatchNo.OptionsColumn.AllowShowHide = false;
            this.colBatchNo.OptionsColumn.AllowSize = false;
            this.colBatchNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colBatchNo.OptionsFilter.AllowAutoFilter = false;
            this.colBatchNo.OptionsFilter.AllowFilter = false;
            this.colBatchNo.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colBatchNo.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colBatchNo.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colBatchNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colBatchNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colBatchNo.Visible = true;
            this.colBatchNo.VisibleIndex = 4;
            this.colBatchNo.Width = 65;
            // 
            // colOrderdQuantity
            // 
            this.colOrderdQuantity.Caption = "Ordered Qty";
            this.colOrderdQuantity.FieldName = "OrderedQuantity";
            this.colOrderdQuantity.Name = "colOrderdQuantity";
            this.colOrderdQuantity.OptionsColumn.AllowEdit = false;
            this.colOrderdQuantity.OptionsColumn.AllowFocus = false;
            this.colOrderdQuantity.OptionsColumn.AllowIncrementalSearch = false;
            this.colOrderdQuantity.OptionsColumn.AllowMove = false;
            this.colOrderdQuantity.OptionsColumn.AllowShowHide = false;
            this.colOrderdQuantity.OptionsColumn.AllowSize = false;
            this.colOrderdQuantity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderdQuantity.OptionsFilter.AllowAutoFilter = false;
            this.colOrderdQuantity.OptionsFilter.AllowFilter = false;
            this.colOrderdQuantity.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderdQuantity.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderdQuantity.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colOrderdQuantity.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderdQuantity.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderdQuantity.Visible = true;
            this.colOrderdQuantity.VisibleIndex = 5;
            this.colOrderdQuantity.Width = 87;
            // 
            // colInvoicedQty
            // 
            this.colInvoicedQty.Caption = "Invoiced Qty";
            this.colInvoicedQty.FieldName = "InvoicedQty";
            this.colInvoicedQty.Name = "colInvoicedQty";
            this.colInvoicedQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoicedQty.OptionsColumn.AllowIncrementalSearch = false;
            this.colInvoicedQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoicedQty.OptionsColumn.AllowMove = false;
            this.colInvoicedQty.OptionsColumn.AllowShowHide = false;
            this.colInvoicedQty.OptionsColumn.AllowSize = false;
            this.colInvoicedQty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoicedQty.OptionsFilter.AllowAutoFilter = false;
            this.colInvoicedQty.OptionsFilter.AllowFilter = false;
            this.colInvoicedQty.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoicedQty.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoicedQty.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colInvoicedQty.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoicedQty.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoicedQty.Visible = true;
            this.colInvoicedQty.VisibleIndex = 6;
            this.colInvoicedQty.Width = 92;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "Unit Price";
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsColumn.AllowIncrementalSearch = false;
            this.colUnitPrice.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsColumn.AllowMove = false;
            this.colUnitPrice.OptionsColumn.AllowShowHide = false;
            this.colUnitPrice.OptionsColumn.AllowSize = false;
            this.colUnitPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsFilter.AllowAutoFilter = false;
            this.colUnitPrice.OptionsFilter.AllowFilter = false;
            this.colUnitPrice.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colUnitPrice.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 7;
            this.colUnitPrice.Width = 65;
            // 
            // colTotalCost
            // 
            this.colTotalCost.Caption = "Total Cost";
            this.colTotalCost.FieldName = "colOrderedAmount";
            this.colTotalCost.Name = "colTotalCost";
            this.colTotalCost.OptionsColumn.AllowEdit = false;
            this.colTotalCost.OptionsColumn.AllowFocus = false;
            this.colTotalCost.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalCost.OptionsColumn.AllowIncrementalSearch = false;
            this.colTotalCost.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalCost.OptionsColumn.AllowMove = false;
            this.colTotalCost.OptionsColumn.AllowShowHide = false;
            this.colTotalCost.OptionsColumn.AllowSize = false;
            this.colTotalCost.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalCost.OptionsFilter.AllowAutoFilter = false;
            this.colTotalCost.OptionsFilter.AllowFilter = false;
            this.colTotalCost.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalCost.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalCost.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTotalCost.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalCost.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalCost.UnboundExpression = "[InvoicedQty] * [UnitPrice]";
            this.colTotalCost.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colTotalCost.Visible = true;
            this.colTotalCost.VisibleIndex = 9;
            this.colTotalCost.Width = 65;
            // 
            // colMargin
            // 
            this.colMargin.Caption = "Margin";
            this.colMargin.DisplayFormat.FormatString = "#,##0.## %";
            this.colMargin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMargin.FieldName = "Margin";
            this.colMargin.Name = "colMargin";
            this.colMargin.OptionsColumn.AllowEdit = false;
            this.colMargin.OptionsColumn.AllowFocus = false;
            this.colMargin.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsColumn.AllowIncrementalSearch = false;
            this.colMargin.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsColumn.AllowMove = false;
            this.colMargin.OptionsColumn.AllowShowHide = false;
            this.colMargin.OptionsColumn.AllowSize = false;
            this.colMargin.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsFilter.AllowAutoFilter = false;
            this.colMargin.OptionsFilter.AllowFilter = false;
            this.colMargin.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colMargin.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colMargin.Visible = true;
            this.colMargin.VisibleIndex = 8;
            this.colMargin.Width = 65;
            // 
            // colPlusMinus
            // 
            this.colPlusMinus.ColumnEdit = this.plusMinusButtonEdit;
            this.colPlusMinus.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colPlusMinus.MaxWidth = 42;
            this.colPlusMinus.MinWidth = 42;
            this.colPlusMinus.Name = "colPlusMinus";
            this.colPlusMinus.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPlusMinus.OptionsColumn.AllowIncrementalSearch = false;
            this.colPlusMinus.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPlusMinus.OptionsColumn.AllowMove = false;
            this.colPlusMinus.OptionsColumn.AllowShowHide = false;
            this.colPlusMinus.OptionsColumn.AllowSize = false;
            this.colPlusMinus.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPlusMinus.OptionsFilter.AllowAutoFilter = false;
            this.colPlusMinus.OptionsFilter.AllowFilter = false;
            this.colPlusMinus.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colPlusMinus.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colPlusMinus.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colPlusMinus.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colPlusMinus.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colPlusMinus.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colPlusMinus.Visible = true;
            this.colPlusMinus.VisibleIndex = 10;
            this.colPlusMinus.Width = 42;
            // 
            // plusMinusButtonEdit
            // 
            this.plusMinusButtonEdit.AutoHeight = false;
            this.plusMinusButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "Split", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Split", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Minus, "Remove", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Remove", null, null, true)});
            this.plusMinusButtonEdit.Name = "plusMinusButtonEdit";
            this.plusMinusButtonEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.plusMinusButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.plusMinusButtonEdit_ButtonClick);
            // 
            // colIsSaved
            // 
            this.colIsSaved.Caption = "IsSaved";
            this.colIsSaved.FieldName = "IsSaved";
            this.colIsSaved.Name = "colIsSaved";
            this.colIsSaved.OptionsColumn.AllowEdit = false;
            this.colIsSaved.OptionsColumn.AllowFocus = false;
            this.colIsSaved.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colIsSaved.OptionsColumn.AllowIncrementalSearch = false;
            this.colIsSaved.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colIsSaved.OptionsColumn.AllowMove = false;
            this.colIsSaved.OptionsColumn.AllowShowHide = false;
            this.colIsSaved.OptionsColumn.AllowSize = false;
            this.colIsSaved.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colIsSaved.OptionsFilter.AllowAutoFilter = false;
            this.colIsSaved.OptionsFilter.AllowFilter = false;
            this.colIsSaved.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colIsSaved.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colIsSaved.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colIsSaved.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colIsSaved.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colguid
            // 
            this.colguid.Caption = "Guid";
            this.colguid.FieldName = "GUID";
            this.colguid.Name = "colguid";
            this.colguid.OptionsColumn.AllowEdit = false;
            this.colguid.OptionsColumn.AllowFocus = false;
            this.colguid.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colguid.OptionsColumn.AllowIncrementalSearch = false;
            this.colguid.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colguid.OptionsColumn.AllowMove = false;
            this.colguid.OptionsColumn.AllowShowHide = false;
            this.colguid.OptionsColumn.AllowSize = false;
            this.colguid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colguid.OptionsFilter.AllowAutoFilter = false;
            this.colguid.OptionsFilter.AllowFilter = false;
            this.colguid.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colguid.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colguid.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colguid.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colguid.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem44.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem44.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem44.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem44.Control = this.lblInvoiceNoDetail;
            this.layoutControlItem44.CustomizationFormText = "Invoice No:";
            this.layoutControlItem44.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem44.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem44.MinSize = new System.Drawing.Size(71, 20);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem44.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem44.Text = "Invoice No:";
            this.layoutControlItem44.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem44.TextSize = new System.Drawing.Size(62, 13);
            this.layoutControlItem44.TextToControlDistance = 5;
            // 
            // Root
            // 
            this.Root.CustomizationFormText = "Root";
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem21,
            this.emptySpaceItem2,
            this.layoutControlItem20,
            this.HeaderGroupDetail});
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(1039, 483);
            this.Root.Text = "Root";
            this.Root.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.Control = this.btnSave;
            this.layoutControlItem21.CustomizationFormText = "layoutControlItem21";
            this.layoutControlItem21.Location = new System.Drawing.Point(747, 457);
            this.layoutControlItem21.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.Text = "layoutControlItem21";
            this.layoutControlItem21.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem21.TextToControlDistance = 0;
            this.layoutControlItem21.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 457);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(747, 26);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.Control = this.btnCancelInvoice;
            this.layoutControlItem20.CustomizationFormText = "layoutControlItem20";
            this.layoutControlItem20.Location = new System.Drawing.Point(893, 457);
            this.layoutControlItem20.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem20.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem20.Text = "layoutControlItem20";
            this.layoutControlItem20.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem20.TextToControlDistance = 0;
            this.layoutControlItem20.TextVisible = false;
            // 
            // HeaderGroupDetail
            // 
            this.HeaderGroupDetail.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderGroupDetail.AppearanceGroup.Options.UseFont = true;
            this.HeaderGroupDetail.CustomizationFormText = " ";
            this.HeaderGroupDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem42,
            this.layoutControlItem50,
            this.layoutControlItem46,
            this.layoutControlItem48,
            this.layoutControlItem54,
            this.layoutControlItem56,
            this.layoutControlItem19,
            this.emptySpaceItem11,
            this.layoutControlItem52});
            this.HeaderGroupDetail.Location = new System.Drawing.Point(0, 0);
            this.HeaderGroupDetail.Name = "HeaderGroupDetail";
            this.HeaderGroupDetail.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.HeaderGroupDetail.Size = new System.Drawing.Size(1039, 457);
            this.HeaderGroupDetail.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.HeaderGroupDetail.Text = " ";
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem42.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem42.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem42.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem42.Control = this.lblModeDetail;
            this.layoutControlItem42.CustomizationFormText = "Mode:";
            this.layoutControlItem42.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem42.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem42.MinSize = new System.Drawing.Size(71, 20);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem42.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem42.Text = "Mode:";
            this.layoutControlItem42.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem42.TextSize = new System.Drawing.Size(34, 13);
            this.layoutControlItem42.TextToControlDistance = 47;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem50.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem50.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem50.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem50.Control = this.lblAccountDetail;
            this.layoutControlItem50.CustomizationFormText = "Account:";
            this.layoutControlItem50.Location = new System.Drawing.Point(256, 0);
            this.layoutControlItem50.MinSize = new System.Drawing.Size(85, 17);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem50.Text = "Account:";
            this.layoutControlItem50.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem50.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem50.TextToControlDistance = 24;
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem46.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem46.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem46.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem46.Control = this.lblSubAccountDetail;
            this.layoutControlItem46.CustomizationFormText = "Sub Account:";
            this.layoutControlItem46.Location = new System.Drawing.Point(512, 0);
            this.layoutControlItem46.MinSize = new System.Drawing.Size(82, 17);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem46.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem46.Text = "Sub Account:";
            this.layoutControlItem46.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem46.TextSize = new System.Drawing.Size(73, 13);
            this.layoutControlItem46.TextToControlDistance = 5;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem48.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem48.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem48.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem48.Control = this.lblActivityDetail;
            this.layoutControlItem48.CustomizationFormText = "Activity:";
            this.layoutControlItem48.Location = new System.Drawing.Point(768, 0);
            this.layoutControlItem48.MinSize = new System.Drawing.Size(61, 17);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(261, 20);
            this.layoutControlItem48.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem48.Text = "Activity:";
            this.layoutControlItem48.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem48.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem48.TextToControlDistance = 5;
            // 
            // layoutControlItem54
            // 
            this.layoutControlItem54.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem54.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem54.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem54.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem54.Control = this.lblInvoiceTypeDetail;
            this.layoutControlItem54.CustomizationFormText = "Invoice Type:";
            this.layoutControlItem54.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem54.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem54.MinSize = new System.Drawing.Size(85, 20);
            this.layoutControlItem54.Name = "layoutControlItem54";
            this.layoutControlItem54.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem54.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem54.Text = "Invoice Type:";
            this.layoutControlItem54.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem54.TextSize = new System.Drawing.Size(76, 13);
            this.layoutControlItem54.TextToControlDistance = 5;
            // 
            // layoutControlItem56
            // 
            this.layoutControlItem56.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem56.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem56.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem56.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem56.Control = this.lblPOTypeDetail;
            this.layoutControlItem56.CustomizationFormText = "PO. Type:";
            this.layoutControlItem56.Location = new System.Drawing.Point(512, 20);
            this.layoutControlItem56.MinSize = new System.Drawing.Size(61, 17);
            this.layoutControlItem56.Name = "layoutControlItem56";
            this.layoutControlItem56.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem56.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem56.Text = "PO. Type:";
            this.layoutControlItem56.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem56.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem56.TextToControlDistance = 26;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.gridInvoiceDetail;
            this.layoutControlItem19.CustomizationFormText = "layoutControlItem19";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(104, 24);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(1029, 388);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.Text = "layoutControlItem19";
            this.layoutControlItem19.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem19.TextToControlDistance = 0;
            this.layoutControlItem19.TextVisible = false;
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.CustomizationFormText = "emptySpaceItem11";
            this.emptySpaceItem11.Location = new System.Drawing.Point(768, 20);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(261, 20);
            this.emptySpaceItem11.Text = "emptySpaceItem11";
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem52
            // 
            this.layoutControlItem52.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem52.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem52.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem52.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem52.Control = this.lblPONumberDetail;
            this.layoutControlItem52.CustomizationFormText = "PO. Number:";
            this.layoutControlItem52.Location = new System.Drawing.Point(256, 20);
            this.layoutControlItem52.MinSize = new System.Drawing.Size(82, 17);
            this.layoutControlItem52.Name = "layoutControlItem52";
            this.layoutControlItem52.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem52.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem52.Text = "PO. Number:";
            this.layoutControlItem52.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem52.TextSize = new System.Drawing.Size(68, 13);
            this.layoutControlItem52.TextToControlDistance = 5;
            // 
            // lkInvoiceType
            // 
            this.lkInvoiceType.Location = new System.Drawing.Point(689, 151);
            this.lkInvoiceType.Name = "lkInvoiceType";
            this.lkInvoiceType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkInvoiceType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Invoice Type")});
            this.lkInvoiceType.Properties.DisplayMember = "Name";
            this.lkInvoiceType.Properties.NullText = "Select Invoice Type";
            this.lkInvoiceType.Properties.ShowFooter = false;
            this.lkInvoiceType.Properties.ShowHeader = false;
            this.lkInvoiceType.Properties.ValueMember = "ID";
            this.lkInvoiceType.Size = new System.Drawing.Size(159, 20);
            this.lkInvoiceType.StyleController = this.layoutControl1;
            this.lkInvoiceType.TabIndex = 70;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "This value is not valid";
            this.dxValidation.SetValidationRule(this.lkInvoiceType, conditionValidationRule1);
            this.lkInvoiceType.EditValueChanged += new System.EventHandler(this.lkInvoiceType_EditValueChanged);
            // 
            // txtInvoiceCustomDutyTax
            // 
            this.txtInvoiceCustomDutyTax.Location = new System.Drawing.Point(127, 225);
            this.txtInvoiceCustomDutyTax.Name = "txtInvoiceCustomDutyTax";
            this.txtInvoiceCustomDutyTax.Properties.AllowMouseWheel = false;
            this.txtInvoiceCustomDutyTax.Properties.DisplayFormat.FormatString = "ETB #,##0.#0";
            this.txtInvoiceCustomDutyTax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtInvoiceCustomDutyTax.Properties.Mask.EditMask = "n";
            this.txtInvoiceCustomDutyTax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInvoiceCustomDutyTax.Size = new System.Drawing.Size(159, 20);
            this.txtInvoiceCustomDutyTax.StyleController = this.layoutControl1;
            this.txtInvoiceCustomDutyTax.TabIndex = 69;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.EditValue = null;
            this.dtInvoiceDate.Location = new System.Drawing.Point(381, 151);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInvoiceDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtInvoiceDate.Size = new System.Drawing.Size(159, 20);
            this.dtInvoiceDate.StyleController = this.layoutControl1;
            this.dtInvoiceDate.TabIndex = 13;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals;
            conditionValidationRule2.ErrorText = "This value is not valid";
            this.dxValidation.SetValidationRule(this.dtInvoiceDate, conditionValidationRule2);
            // 
            // lkCurrencyLCID
            // 
            this.lkCurrencyLCID.Location = new System.Drawing.Point(127, 249);
            this.lkCurrencyLCID.Name = "lkCurrencyLCID";
            this.lkCurrencyLCID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkCurrencyLCID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Symbol", "Symbol")});
            this.lkCurrencyLCID.Properties.DisplayMember = "Name";
            this.lkCurrencyLCID.Properties.NullText = "Select Currency";
            this.lkCurrencyLCID.Properties.ShowFooter = false;
            this.lkCurrencyLCID.Properties.ValueMember = "ID";
            this.lkCurrencyLCID.Size = new System.Drawing.Size(159, 20);
            this.lkCurrencyLCID.StyleController = this.layoutControl1;
            this.lkCurrencyLCID.TabIndex = 66;
            this.lkCurrencyLCID.EditValueChanged += new System.EventHandler(this.lkCurrencyLCID_EditValueChanged);
            // 
            // txtInvoiceCBEServiceCharge
            // 
            this.txtInvoiceCBEServiceCharge.Location = new System.Drawing.Point(441, 201);
            this.txtInvoiceCBEServiceCharge.Name = "txtInvoiceCBEServiceCharge";
            this.txtInvoiceCBEServiceCharge.Properties.AllowMouseWheel = false;
            this.txtInvoiceCBEServiceCharge.Properties.DisplayFormat.FormatString = "ETB #,##0.#0";
            this.txtInvoiceCBEServiceCharge.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtInvoiceCBEServiceCharge.Properties.Mask.EditMask = "n";
            this.txtInvoiceCBEServiceCharge.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInvoiceCBEServiceCharge.Size = new System.Drawing.Size(159, 20);
            this.txtInvoiceCBEServiceCharge.StyleController = this.layoutControl1;
            this.txtInvoiceCBEServiceCharge.TabIndex = 68;
            // 
            // gridGrv
            // 
            this.gridGrv.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridGrv.Location = new System.Drawing.Point(32, 304);
            this.gridGrv.MainView = this.gridGrvView;
            this.gridGrv.Name = "gridGrv";
            this.gridGrv.Size = new System.Drawing.Size(999, 169);
            this.gridGrv.TabIndex = 3;
            this.gridGrv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridGrvView});
            // 
            // gridGrvView
            // 
            this.gridGrvView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceID,
            this.colGRVNumber,
            this.colTransferTransitNo,
            this.colTotalValue,
            this.colDamaged,
            this.gridColumn1,
            this.colFreight,
            this.colCustomDutyTax,
            this.colCBE});
            styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[Status]>[CurrentStatus]";
            styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            styleFormatCondition2.Appearance.Options.UseBackColor = true;
            styleFormatCondition2.ApplyToRow = true;
            styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition2.Expression = "[Status]<[CurrentStatus]";
            this.gridGrvView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridGrvView.GridControl = this.gridGrv;
            this.gridGrvView.Name = "gridGrvView";
            this.gridGrvView.OptionsCustomization.AllowColumnMoving = false;
            this.gridGrvView.OptionsCustomization.AllowColumnResizing = false;
            this.gridGrvView.OptionsMenu.EnableColumnMenu = false;
            this.gridGrvView.OptionsMenu.EnableFooterMenu = false;
            this.gridGrvView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridGrvView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridGrvView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridGrvView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridGrvView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridGrvView.OptionsMenu.ShowSplitItem = false;
            this.gridGrvView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridGrvView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridGrvView.OptionsView.ShowFooter = true;
            this.gridGrvView.OptionsView.ShowGroupPanel = false;
            // 
            // colInvoiceID
            // 
            this.colInvoiceID.Caption = "InvoiceID";
            this.colInvoiceID.Name = "colInvoiceID";
            this.colInvoiceID.OptionsColumn.AllowEdit = false;
            this.colInvoiceID.OptionsColumn.AllowFocus = false;
            this.colInvoiceID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceID.OptionsColumn.AllowIncrementalSearch = false;
            this.colInvoiceID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceID.OptionsColumn.AllowMove = false;
            this.colInvoiceID.OptionsColumn.AllowShowHide = false;
            this.colInvoiceID.OptionsColumn.AllowSize = false;
            this.colInvoiceID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceID.OptionsColumn.ShowInCustomizationForm = false;
            this.colInvoiceID.OptionsColumn.ShowInExpressionEditor = false;
            this.colInvoiceID.OptionsColumn.TabStop = false;
            this.colInvoiceID.OptionsFilter.AllowAutoFilter = false;
            this.colInvoiceID.OptionsFilter.AllowFilter = false;
            this.colInvoiceID.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceID.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceID.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colInvoiceID.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceID.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colGRVNumber
            // 
            this.colGRVNumber.Caption = "GNF No";
            this.colGRVNumber.FieldName = "ID";
            this.colGRVNumber.Name = "colGRVNumber";
            this.colGRVNumber.OptionsColumn.AllowEdit = false;
            this.colGRVNumber.OptionsColumn.AllowFocus = false;
            this.colGRVNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colGRVNumber.OptionsColumn.AllowIncrementalSearch = false;
            this.colGRVNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colGRVNumber.OptionsColumn.AllowMove = false;
            this.colGRVNumber.OptionsColumn.AllowShowHide = false;
            this.colGRVNumber.OptionsColumn.AllowSize = false;
            this.colGRVNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colGRVNumber.OptionsColumn.ShowInCustomizationForm = false;
            this.colGRVNumber.OptionsColumn.ShowInExpressionEditor = false;
            this.colGRVNumber.OptionsColumn.TabStop = false;
            this.colGRVNumber.OptionsFilter.AllowAutoFilter = false;
            this.colGRVNumber.OptionsFilter.AllowFilter = false;
            this.colGRVNumber.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colGRVNumber.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colGRVNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colGRVNumber.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colGRVNumber.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colGRVNumber.Visible = true;
            this.colGRVNumber.VisibleIndex = 1;
            // 
            // colTransferTransitNo
            // 
            this.colTransferTransitNo.Caption = "Transit / Transfer No";
            this.colTransferTransitNo.FieldName = "TransitTransferNo";
            this.colTransferTransitNo.Name = "colTransferTransitNo";
            this.colTransferTransitNo.OptionsColumn.AllowEdit = false;
            this.colTransferTransitNo.OptionsColumn.AllowFocus = false;
            this.colTransferTransitNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferTransitNo.OptionsColumn.AllowIncrementalSearch = false;
            this.colTransferTransitNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferTransitNo.OptionsColumn.AllowMove = false;
            this.colTransferTransitNo.OptionsColumn.AllowShowHide = false;
            this.colTransferTransitNo.OptionsColumn.AllowSize = false;
            this.colTransferTransitNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferTransitNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colTransferTransitNo.OptionsColumn.ShowInExpressionEditor = false;
            this.colTransferTransitNo.OptionsColumn.TabStop = false;
            this.colTransferTransitNo.OptionsFilter.AllowAutoFilter = false;
            this.colTransferTransitNo.OptionsFilter.AllowFilter = false;
            this.colTransferTransitNo.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferTransitNo.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferTransitNo.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTransferTransitNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferTransitNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colTransferTransitNo.Visible = true;
            this.colTransferTransitNo.VisibleIndex = 2;
            // 
            // colTotalValue
            // 
            this.colTotalValue.Caption = "Total Value";
            this.colTotalValue.FieldName = "TotalValue";
            this.colTotalValue.Name = "colTotalValue";
            this.colTotalValue.OptionsColumn.AllowEdit = false;
            this.colTotalValue.OptionsColumn.AllowFocus = false;
            this.colTotalValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalValue.OptionsColumn.AllowIncrementalSearch = false;
            this.colTotalValue.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalValue.OptionsColumn.AllowMove = false;
            this.colTotalValue.OptionsColumn.AllowShowHide = false;
            this.colTotalValue.OptionsColumn.AllowSize = false;
            this.colTotalValue.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalValue.OptionsColumn.ShowInCustomizationForm = false;
            this.colTotalValue.OptionsColumn.ShowInExpressionEditor = false;
            this.colTotalValue.OptionsColumn.TabStop = false;
            this.colTotalValue.OptionsFilter.AllowAutoFilter = false;
            this.colTotalValue.OptionsFilter.AllowFilter = false;
            this.colTotalValue.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalValue.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalValue.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colTotalValue.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalValue.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colTotalValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colTotalValue.Visible = true;
            this.colTotalValue.VisibleIndex = 3;
            // 
            // colDamaged
            // 
            this.colDamaged.Caption = "Insurance";
            this.colDamaged.FieldName = "Insurance";
            this.colDamaged.Name = "colDamaged";
            this.colDamaged.OptionsColumn.AllowEdit = false;
            this.colDamaged.OptionsColumn.AllowFocus = false;
            this.colDamaged.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDamaged.OptionsColumn.AllowIncrementalSearch = false;
            this.colDamaged.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colDamaged.OptionsColumn.AllowMove = false;
            this.colDamaged.OptionsColumn.AllowShowHide = false;
            this.colDamaged.OptionsColumn.AllowSize = false;
            this.colDamaged.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDamaged.OptionsColumn.ShowInCustomizationForm = false;
            this.colDamaged.OptionsColumn.ShowInExpressionEditor = false;
            this.colDamaged.OptionsColumn.TabStop = false;
            this.colDamaged.OptionsFilter.AllowAutoFilter = false;
            this.colDamaged.OptionsFilter.AllowFilter = false;
            this.colDamaged.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colDamaged.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colDamaged.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colDamaged.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colDamaged.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colDamaged.Visible = true;
            this.colDamaged.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Warehouse";
            this.gridColumn1.FieldName = "Warehouse";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowShowHide = false;
            this.gridColumn1.OptionsColumn.AllowSize = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn1.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn1.OptionsColumn.TabStop = false;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn1.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // colFreight
            // 
            this.colFreight.Caption = "Freight";
            this.colFreight.FieldName = "Freight";
            this.colFreight.Name = "colFreight";
            this.colFreight.OptionsColumn.AllowEdit = false;
            this.colFreight.OptionsColumn.AllowFocus = false;
            this.colFreight.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colFreight.OptionsColumn.AllowIncrementalSearch = false;
            this.colFreight.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colFreight.OptionsColumn.AllowMove = false;
            this.colFreight.OptionsColumn.AllowShowHide = false;
            this.colFreight.OptionsColumn.AllowSize = false;
            this.colFreight.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colFreight.OptionsColumn.ShowInCustomizationForm = false;
            this.colFreight.OptionsColumn.ShowInExpressionEditor = false;
            this.colFreight.OptionsColumn.TabStop = false;
            this.colFreight.OptionsFilter.AllowAutoFilter = false;
            this.colFreight.OptionsFilter.AllowFilter = false;
            this.colFreight.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colFreight.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colFreight.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colFreight.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colFreight.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colFreight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colFreight.Visible = true;
            this.colFreight.VisibleIndex = 5;
            // 
            // colCustomDutyTax
            // 
            this.colCustomDutyTax.Caption = "Custom Duty Tax";
            this.colCustomDutyTax.FieldName = "CustomDutyTax";
            this.colCustomDutyTax.Name = "colCustomDutyTax";
            this.colCustomDutyTax.OptionsColumn.AllowEdit = false;
            this.colCustomDutyTax.OptionsColumn.AllowFocus = false;
            this.colCustomDutyTax.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomDutyTax.OptionsColumn.AllowIncrementalSearch = false;
            this.colCustomDutyTax.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomDutyTax.OptionsColumn.AllowMove = false;
            this.colCustomDutyTax.OptionsColumn.AllowShowHide = false;
            this.colCustomDutyTax.OptionsColumn.AllowSize = false;
            this.colCustomDutyTax.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomDutyTax.OptionsColumn.ShowInCustomizationForm = false;
            this.colCustomDutyTax.OptionsColumn.ShowInExpressionEditor = false;
            this.colCustomDutyTax.OptionsColumn.TabStop = false;
            this.colCustomDutyTax.OptionsFilter.AllowAutoFilter = false;
            this.colCustomDutyTax.OptionsFilter.AllowFilter = false;
            this.colCustomDutyTax.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomDutyTax.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomDutyTax.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCustomDutyTax.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomDutyTax.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colCustomDutyTax.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colCustomDutyTax.Visible = true;
            this.colCustomDutyTax.VisibleIndex = 6;
            // 
            // colCBE
            // 
            this.colCBE.Caption = "CBE";
            this.colCBE.FieldName = "CBE";
            this.colCBE.Name = "colCBE";
            this.colCBE.OptionsColumn.AllowEdit = false;
            this.colCBE.OptionsColumn.AllowFocus = false;
            this.colCBE.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCBE.OptionsColumn.AllowIncrementalSearch = false;
            this.colCBE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colCBE.OptionsColumn.AllowMove = false;
            this.colCBE.OptionsColumn.AllowShowHide = false;
            this.colCBE.OptionsColumn.AllowSize = false;
            this.colCBE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCBE.OptionsColumn.ShowInCustomizationForm = false;
            this.colCBE.OptionsColumn.ShowInExpressionEditor = false;
            this.colCBE.OptionsColumn.TabStop = false;
            this.colCBE.OptionsFilter.AllowAutoFilter = false;
            this.colCBE.OptionsFilter.AllowFilter = false;
            this.colCBE.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colCBE.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colCBE.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCBE.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colCBE.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colCBE.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colCBE.Visible = true;
            this.colCBE.VisibleIndex = 7;
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.EditValue = "1";
            this.txtExchangeRate.Location = new System.Drawing.Point(441, 249);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Properties.AllowMouseWheel = false;
            this.txtExchangeRate.Properties.Mask.EditMask = "n4";
            this.txtExchangeRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtExchangeRate.Size = new System.Drawing.Size(159, 20);
            this.txtExchangeRate.StyleController = this.layoutControl1;
            this.txtExchangeRate.TabIndex = 65;
            // 
            // txtTransitNumber
            // 
            this.txtTransitNumber.Enabled = false;
            this.txtTransitNumber.Location = new System.Drawing.Point(689, 127);
            this.txtTransitNumber.Name = "txtTransitNumber";
            this.txtTransitNumber.Size = new System.Drawing.Size(159, 20);
            this.txtTransitNumber.StyleController = this.layoutControl1;
            this.txtTransitNumber.TabIndex = 8;
            // 
            // txtWayBill
            // 
            this.txtWayBill.Enabled = false;
            this.txtWayBill.Location = new System.Drawing.Point(381, 127);
            this.txtWayBill.Name = "txtWayBill";
            this.txtWayBill.Size = new System.Drawing.Size(159, 20);
            this.txtWayBill.StyleController = this.layoutControl1;
            this.txtWayBill.TabIndex = 8;
            // 
            // txtInvoiceSeaFreight
            // 
            this.txtInvoiceSeaFreight.Location = new System.Drawing.Point(441, 225);
            this.txtInvoiceSeaFreight.Name = "txtInvoiceSeaFreight";
            this.txtInvoiceSeaFreight.Properties.AllowMouseWheel = false;
            this.txtInvoiceSeaFreight.Properties.Mask.EditMask = "n";
            this.txtInvoiceSeaFreight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInvoiceSeaFreight.Size = new System.Drawing.Size(159, 20);
            this.txtInvoiceSeaFreight.StyleController = this.layoutControl1;
            this.txtInvoiceSeaFreight.TabIndex = 64;
            this.txtInvoiceSeaFreight.EditValueChanged += new System.EventHandler(this.txtInvoiceSeaFreight_EditValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::HCMIS.Desktop.Properties.Resources.cross;
            this.btnCancel.Location = new System.Drawing.Point(901, 489);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(142, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtInvoiceAirFreight
            // 
            this.txtInvoiceAirFreight.Location = new System.Drawing.Point(724, 201);
            this.txtInvoiceAirFreight.Name = "txtInvoiceAirFreight";
            this.txtInvoiceAirFreight.Properties.AllowMouseWheel = false;
            this.txtInvoiceAirFreight.Properties.Mask.EditMask = "n";
            this.txtInvoiceAirFreight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInvoiceAirFreight.Size = new System.Drawing.Size(159, 20);
            this.txtInvoiceAirFreight.StyleController = this.layoutControl1;
            this.txtInvoiceAirFreight.TabIndex = 63;
            // 
            // btnSaveInvoice
            // 
            this.btnSaveInvoice.Image = global::HCMIS.Desktop.Properties.Resources.disk;
            this.btnSaveInvoice.Location = new System.Drawing.Point(755, 489);
            this.btnSaveInvoice.Name = "btnSaveInvoice";
            this.btnSaveInvoice.Size = new System.Drawing.Size(142, 22);
            this.btnSaveInvoice.StyleController = this.layoutControl1;
            this.btnSaveInvoice.TabIndex = 11;
            this.btnSaveInvoice.Text = "Save";
            this.btnSaveInvoice.Click += new System.EventHandler(this.btnSaveInvoice_Click);
            // 
            // txtInsurance
            // 
            this.txtInsurance.Enabled = false;
            this.txtInsurance.Location = new System.Drawing.Point(113, 151);
            this.txtInsurance.Name = "txtInsurance";
            this.txtInsurance.Size = new System.Drawing.Size(160, 20);
            this.txtInsurance.StyleController = this.layoutControl1;
            this.txtInsurance.TabIndex = 7;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(114, 127);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(159, 20);
            this.txtInvoiceNumber.StyleController = this.layoutControl1;
            this.txtInvoiceNumber.TabIndex = 6;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "This value is not valid";
            this.dxValidation.SetValidationRule(this.txtInvoiceNumber, conditionValidationRule3);
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Location = new System.Drawing.Point(127, 201);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Properties.AllowMouseWheel = false;
            this.txtTotalValue.Properties.Mask.EditMask = "n";
            this.txtTotalValue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalValue.Size = new System.Drawing.Size(159, 20);
            this.txtTotalValue.StyleController = this.layoutControl1;
            this.txtTotalValue.TabIndex = 5;
            // 
            // txtInvoiceInlandFreight
            // 
            this.txtInvoiceInlandFreight.Location = new System.Drawing.Point(724, 225);
            this.txtInvoiceInlandFreight.Name = "txtInvoiceInlandFreight";
            this.txtInvoiceInlandFreight.Properties.AllowMouseWheel = false;
            this.txtInvoiceInlandFreight.Properties.DisplayFormat.FormatString = "ETB #,##0.#0";
            this.txtInvoiceInlandFreight.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtInvoiceInlandFreight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtInvoiceInlandFreight.Size = new System.Drawing.Size(159, 20);
            this.txtInvoiceInlandFreight.StyleController = this.layoutControl1;
            this.txtInvoiceInlandFreight.TabIndex = 65;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem24.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem24.Control = this.lblOrderNumber;
            this.layoutControlItem24.CustomizationFormText = "Order No:";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem24.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem24.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem24.Text = "Order No:";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabInvoice});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1067, 535);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // tabInvoice
            // 
            this.tabInvoice.CustomizationFormText = "tabbedControlGroup1";
            this.tabInvoice.Location = new System.Drawing.Point(0, 0);
            this.tabInvoice.Name = "tabInvoice";
            this.tabInvoice.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.tabInvoice.SelectedTabPage = this.layoutControlGroup2;
            this.tabInvoice.SelectedTabPageIndex = 0;
            this.tabInvoice.Size = new System.Drawing.Size(1047, 515);
            this.tabInvoice.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.tabInvoice.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.tabInvoice.Text = "tabInvoice";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Invoice Detail";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(-2, -2, -2, -2);
            this.layoutControlGroup3.Size = new System.Drawing.Size(1037, 483);
            this.layoutControlGroup3.Text = "Invoice Detail";
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.layoutControl2;
            this.layoutControlItem18.CustomizationFormText = "layoutControlItem18";
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Padding = new DevExpress.XtraLayout.Utils.Padding(-2, -2, -2, -2);
            this.layoutControlItem18.Size = new System.Drawing.Size(1037, 483);
            this.layoutControlItem18.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 0, 2, 2);
            this.layoutControlItem18.Text = "layoutControlItem18";
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextToControlDistance = 0;
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Purchase Order";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.HeaderGroup});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1037, 483);
            this.layoutControlGroup2.Text = " Invoice Header";
            // 
            // HeaderGroup
            // 
            this.HeaderGroup.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderGroup.AppearanceGroup.Options.UseFont = true;
            this.HeaderGroup.CustomizationFormText = "Order Information";
            this.HeaderGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup5,
            this.emptySpaceItem4,
            this.layoutControlItem10,
            this.layoutControlItem1,
            this.layoutControlItem30,
            this.layoutControlItem32,
            this.layoutControlItem34,
            this.layoutControlItem36,
            this.layoutControlItem26,
            this.layoutControlItem40,
            this.layoutControlItem38,
            this.layoutControlItem28});
            this.HeaderGroup.Location = new System.Drawing.Point(0, 0);
            this.HeaderGroup.Name = "HeaderGroup";
            this.HeaderGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.HeaderGroup.Size = new System.Drawing.Size(1037, 483);
            this.HeaderGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.HeaderGroup.Text = " Order Information";
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "Invoice Information";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutFinancialInformation,
            this.layoutGoodsReceived,
            this.layoutControlItem6,
            this.layoutControlItem8,
            this.layoutControlItem11,
            this.emptySpaceItem3,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.emptySpaceItem8,
            this.emptySpaceItem7,
            this.layoutControlItem57});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 40);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup5.Size = new System.Drawing.Size(1027, 388);
            this.layoutControlGroup5.Text = "Invoice Information";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtInvoiceNumber;
            this.layoutControlItem4.CustomizationFormText = "Invoice Number";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(250, 24);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Invoice No *";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem4.TextToControlDistance = 27;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtWayBill;
            this.layoutControlItem2.CustomizationFormText = "Way Bill Number";
            this.layoutControlItem2.Location = new System.Drawing.Point(272, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(245, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(245, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(245, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "Way Bill Number";
            this.layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 13);
            this.layoutControlItem2.TextToControlDistance = 5;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtInsurance;
            this.layoutControlItem5.CustomizationFormText = "Insurance Policy";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(250, 24);
            this.layoutControlItem5.Text = "Insurance Policy ";
            this.layoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(81, 13);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutFinancialInformation
            // 
            this.layoutFinancialInformation.CustomizationFormText = "Financial Information";
            this.layoutFinancialInformation.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem16,
            this.layoutControlItem14,
            this.layoutControlItem15,
            this.layoutControlItem3,
            this.layoutControlItem17,
            this.layoutControlItem12,
            this.layoutControlItem13,
            this.layoutControlItem9,
            this.emptySpaceItem1,
            this.emptySpaceItem9,
            this.emptySpaceItem10,
            this.emptySpaceItem12});
            this.layoutFinancialInformation.Location = new System.Drawing.Point(0, 48);
            this.layoutFinancialInformation.Name = "layoutFinancialInformation";
            this.layoutFinancialInformation.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutFinancialInformation.Size = new System.Drawing.Size(1013, 105);
            this.layoutFinancialInformation.Text = "Financial Information";
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.txtInvoiceCBEServiceCharge;
            this.layoutControlItem16.CustomizationFormText = "CBE Service Charge";
            this.layoutControlItem16.Location = new System.Drawing.Point(307, 0);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(263, 24);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(263, 24);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Text = "CBE Service Charge";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(95, 13);
            this.layoutControlItem16.TextToControlDistance = 5;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.txtExchangeRate;
            this.layoutControlItem14.CustomizationFormText = "Exchange Rate";
            this.layoutControlItem14.Location = new System.Drawing.Point(307, 48);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(152, 24);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = "Exchange Rate";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(73, 13);
            this.layoutControlItem14.TextToControlDistance = 27;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.lkCurrencyLCID;
            this.layoutControlItem15.CustomizationFormText = "Currency (Freight)";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(256, 24);
            this.layoutControlItem15.Text = "Currency(Foreign)";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(88, 13);
            this.layoutControlItem15.TextToControlDistance = 5;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTotalValue;
            this.layoutControlItem3.CustomizationFormText = "Total Value";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(256, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(256, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(256, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Total Value";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(53, 13);
            this.layoutControlItem3.TextToControlDistance = 40;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.txtInvoiceCustomDutyTax;
            this.layoutControlItem17.CustomizationFormText = "Custom Duty Tax";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem17.MinSize = new System.Drawing.Size(152, 24);
            this.layoutControlItem17.Name = "layoutControlItem17";
            this.layoutControlItem17.Size = new System.Drawing.Size(256, 24);
            this.layoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem17.Text = "Custom Duty Tax";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(83, 13);
            this.layoutControlItem17.TextToControlDistance = 10;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtInvoiceAirFreight;
            this.layoutControlItem12.CustomizationFormText = "Air Freight";
            this.layoutControlItem12.Location = new System.Drawing.Point(618, 0);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(235, 24);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(235, 24);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "Air Freight";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(50, 13);
            this.layoutControlItem12.TextToControlDistance = 22;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtInvoiceSeaFreight;
            this.layoutControlItem13.CustomizationFormText = "Sea Freight";
            this.layoutControlItem13.Location = new System.Drawing.Point(307, 24);
            this.layoutControlItem13.MinSize = new System.Drawing.Size(152, 24);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(263, 24);
            this.layoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem13.Text = "Sea Freight";
            this.layoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem13.TextToControlDistance = 45;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtInvoiceInlandFreight;
            this.layoutControlItem9.CustomizationFormText = "Inland Freight";
            this.layoutControlItem9.Location = new System.Drawing.Point(618, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(152, 24);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(235, 24);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "Inland Freight";
            this.layoutControlItem9.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(67, 13);
            this.layoutControlItem9.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(618, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(235, 24);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem9";
            this.emptySpaceItem9.Location = new System.Drawing.Point(256, 0);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(51, 72);
            this.emptySpaceItem9.Text = "emptySpaceItem9";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem10";
            this.emptySpaceItem10.Location = new System.Drawing.Point(570, 0);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(48, 72);
            this.emptySpaceItem10.Text = "emptySpaceItem10";
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.CustomizationFormText = "emptySpaceItem12";
            this.emptySpaceItem12.Location = new System.Drawing.Point(853, 0);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(146, 72);
            this.emptySpaceItem12.Text = "emptySpaceItem12";
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutGoodsReceived
            // 
            this.layoutGoodsReceived.CustomizationFormText = "GRV\'s";
            this.layoutGoodsReceived.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.layoutGoodsReceived.Location = new System.Drawing.Point(0, 153);
            this.layoutGoodsReceived.Name = "layoutGoodsReceived";
            this.layoutGoodsReceived.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutGoodsReceived.Size = new System.Drawing.Size(1013, 202);
            this.layoutGoodsReceived.Text = "Good Receive Notifications";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridGrv;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1003, 173);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtTransitNumber;
            this.layoutControlItem6.CustomizationFormText = "Transit / Transfer Number";
            this.layoutControlItem6.Location = new System.Drawing.Point(533, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(292, 24);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(292, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(292, 24);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Transit / Transfer Number";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(124, 13);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.dtInvoiceDate;
            this.layoutControlItem8.CustomizationFormText = "Invoice Date";
            this.layoutControlItem8.Location = new System.Drawing.Point(272, 24);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(137, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(245, 24);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "Invoice Date";
            this.layoutControlItem8.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(61, 13);
            this.layoutControlItem8.TextToControlDistance = 21;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.lkInvoiceType;
            this.layoutControlItem11.CustomizationFormText = "Type of Invoice";
            this.layoutControlItem11.Location = new System.Drawing.Point(533, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(292, 24);
            this.layoutControlItem11.Text = "Type of Invoice";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(75, 13);
            this.layoutControlItem11.TextToControlDistance = 54;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(250, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(22, 24);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(250, 24);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(22, 24);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(517, 0);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(16, 24);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(517, 24);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(16, 24);
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(825, 24);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(188, 24);
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem57
            // 
            this.layoutControlItem57.Control = this.lkDocumentType;
            this.layoutControlItem57.CustomizationFormText = "Document Type";
            this.layoutControlItem57.Location = new System.Drawing.Point(825, 0);
            this.layoutControlItem57.Name = "layoutControlItem57";
            this.layoutControlItem57.Size = new System.Drawing.Size(188, 24);
            this.layoutControlItem57.Text = "Document Type";
            this.layoutControlItem57.TextSize = new System.Drawing.Size(75, 13);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 428);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(735, 26);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnSaveInvoice;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(735, 428);
            this.layoutControlItem10.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.Text = "layoutControlItem10";
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextToControlDistance = 0;
            this.layoutControlItem10.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnCancel;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(881, 428);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem30.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem30.Control = this.lblMode;
            this.layoutControlItem30.CustomizationFormText = "Mode:";
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem30.MinSize = new System.Drawing.Size(61, 17);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(257, 20);
            this.layoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem30.Text = "Mode:";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(34, 13);
            this.layoutControlItem30.TextToControlDistance = 10;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem32.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem32.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem32.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem32.Control = this.lblAccount;
            this.layoutControlItem32.CustomizationFormText = "Account:";
            this.layoutControlItem32.Location = new System.Drawing.Point(257, 0);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(84, 17);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(257, 20);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.Text = "Account:";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem32.TextToControlDistance = 5;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem34.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem34.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem34.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem34.Control = this.lblSubAccount;
            this.layoutControlItem34.CustomizationFormText = "Sub Account:";
            this.layoutControlItem34.Location = new System.Drawing.Point(514, 0);
            this.layoutControlItem34.MinSize = new System.Drawing.Size(82, 17);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(257, 20);
            this.layoutControlItem34.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem34.Text = "Sub Account:";
            this.layoutControlItem34.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(73, 13);
            this.layoutControlItem34.TextToControlDistance = 5;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem36.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem36.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem36.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem36.Control = this.lblActivity;
            this.layoutControlItem36.CustomizationFormText = "Activity:";
            this.layoutControlItem36.Location = new System.Drawing.Point(771, 0);
            this.layoutControlItem36.MinSize = new System.Drawing.Size(56, 17);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem36.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem36.Text = "Activity:";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem36.TextToControlDistance = 33;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem26.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem26.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem26.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem26.Control = this.lblRefNo;
            this.layoutControlItem26.CustomizationFormText = "Ref No:";
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem26.MinSize = new System.Drawing.Size(84, 17);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(257, 20);
            this.layoutControlItem26.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem26.Text = "Ref No:";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(39, 13);
            this.layoutControlItem26.TextToControlDistance = 5;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem40.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem40.Control = this.lblOrderStatus;
            this.layoutControlItem40.CustomizationFormText = "Order Status:";
            this.layoutControlItem40.Location = new System.Drawing.Point(771, 20);
            this.layoutControlItem40.MinSize = new System.Drawing.Size(84, 17);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(256, 20);
            this.layoutControlItem40.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem40.Text = "Order Status:";
            this.layoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(75, 13);
            this.layoutControlItem40.TextToControlDistance = 5;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem38.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem38.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem38.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem38.Control = this.lblPOType;
            this.layoutControlItem38.CustomizationFormText = "PO Type:";
            this.layoutControlItem38.Location = new System.Drawing.Point(514, 20);
            this.layoutControlItem38.MinSize = new System.Drawing.Size(61, 17);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(257, 20);
            this.layoutControlItem38.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem38.Text = "PO Type:";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem38.TextToControlDistance = 29;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem28.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem28.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem28.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem28.Control = this.lblSupplier;
            this.layoutControlItem28.CustomizationFormText = "Supplier:";
            this.layoutControlItem28.Location = new System.Drawing.Point(257, 20);
            this.layoutControlItem28.MinSize = new System.Drawing.Size(88, 17);
            this.layoutControlItem28.Name = "layoutControlItem28";
            this.layoutControlItem28.Size = new System.Drawing.Size(257, 20);
            this.layoutControlItem28.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem28.Text = "Supplier:";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem23.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem23.Control = this.lblOrderNumber;
            this.layoutControlItem23.CustomizationFormText = "Order Number:";
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem23.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem23.Name = "layoutControlItem21";
            this.layoutControlItem23.Size = new System.Drawing.Size(205, 20);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.Text = "Order Number:";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem23.TextToControlDistance = 5;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem25.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layoutControlItem25.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem25.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem25.Control = this.lblRefNo;
            this.layoutControlItem25.CustomizationFormText = "Order Number:";
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem25.Name = "layoutControlItem21";
            this.layoutControlItem25.Size = new System.Drawing.Size(205, 20);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.Text = "Order Number:";
            this.layoutControlItem25.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem25.TextToControlDistance = 5;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem27.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layoutControlItem27.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem27.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem27.Control = this.lblSupplier;
            this.layoutControlItem27.CustomizationFormText = "Order Number:";
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem27.Name = "layoutControlItem21";
            this.layoutControlItem27.Size = new System.Drawing.Size(205, 20);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "Order Number:";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem29.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layoutControlItem29.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem29.Control = this.lblMode;
            this.layoutControlItem29.CustomizationFormText = "Order Number:";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem29.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem29.Name = "layoutControlItem21";
            this.layoutControlItem29.Size = new System.Drawing.Size(205, 20);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "Order Number:";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem31.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layoutControlItem31.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem31.Control = this.lblAccount;
            this.layoutControlItem31.CustomizationFormText = "Order Number:";
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem31.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem31.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem31.Name = "layoutControlItem21";
            this.layoutControlItem31.Size = new System.Drawing.Size(205, 20);
            this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem31.Text = "Order Number:";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem31.TextToControlDistance = 5;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem33.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layoutControlItem33.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem33.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem33.Control = this.lblSubAccount;
            this.layoutControlItem33.CustomizationFormText = "Order Number:";
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem33.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem33.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem33.Name = "layoutControlItem21";
            this.layoutControlItem33.Size = new System.Drawing.Size(205, 20);
            this.layoutControlItem33.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem33.Text = "Order Number:";
            this.layoutControlItem33.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem33.TextToControlDistance = 5;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem35.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.layoutControlItem35.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem35.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem35.Control = this.lblActivity;
            this.layoutControlItem35.CustomizationFormText = "Order Number:";
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem35.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem35.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem35.Name = "layoutControlItem21";
            this.layoutControlItem35.Size = new System.Drawing.Size(205, 20);
            this.layoutControlItem35.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem35.Text = "Order Number:";
            this.layoutControlItem35.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem35.TextToControlDistance = 5;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem37.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem37.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem37.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem37.Control = this.lblPOType;
            this.layoutControlItem37.CustomizationFormText = "Order No:";
            this.layoutControlItem37.Location = new System.Drawing.Point(0, 17);
            this.layoutControlItem37.Name = "layoutControlItem24";
            this.layoutControlItem37.Size = new System.Drawing.Size(256, 17);
            this.layoutControlItem37.Text = "Order No:";
            this.layoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem37.TextToControlDistance = 5;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem39.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem39.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem39.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem39.Control = this.lblOrderStatus;
            this.layoutControlItem39.CustomizationFormText = "Order No:";
            this.layoutControlItem39.Location = new System.Drawing.Point(0, 17);
            this.layoutControlItem39.Name = "layoutControlItem24";
            this.layoutControlItem39.Size = new System.Drawing.Size(256, 17);
            this.layoutControlItem39.Text = "Order No:";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem41.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem41.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem41.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem41.Control = this.lblModeDetail;
            this.layoutControlItem41.CustomizationFormText = "Order No:";
            this.layoutControlItem41.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem41.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem41.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem41.Name = "layoutControlItem24";
            this.layoutControlItem41.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem41.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem41.Text = "Order No:";
            this.layoutControlItem41.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem41.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem41.TextToControlDistance = 5;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem43.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem43.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem43.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem43.Control = this.lblInvoiceNoDetail;
            this.layoutControlItem43.CustomizationFormText = "Order No:";
            this.layoutControlItem43.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem43.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem43.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem43.Name = "layoutControlItem24";
            this.layoutControlItem43.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem43.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem43.Text = "Order No:";
            this.layoutControlItem43.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem43.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem43.TextToControlDistance = 5;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem45.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem45.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem45.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem45.Control = this.lblSubAccountDetail;
            this.layoutControlItem45.CustomizationFormText = "Order No:";
            this.layoutControlItem45.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem45.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem45.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem45.Name = "layoutControlItem24";
            this.layoutControlItem45.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem45.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem45.Text = "Order No:";
            this.layoutControlItem45.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem45.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem45.TextToControlDistance = 5;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem47.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem47.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem47.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem47.Control = this.lblActivityDetail;
            this.layoutControlItem47.CustomizationFormText = "Order No:";
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem47.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem47.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem47.Name = "layoutControlItem24";
            this.layoutControlItem47.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem47.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem47.Text = "Order No:";
            this.layoutControlItem47.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem47.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem47.TextToControlDistance = 5;
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem49.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem49.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem49.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem49.Control = this.lblAccountDetail;
            this.layoutControlItem49.CustomizationFormText = "Order No:";
            this.layoutControlItem49.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem49.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem49.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem49.Name = "layoutControlItem24";
            this.layoutControlItem49.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem49.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem49.Text = "Order No:";
            this.layoutControlItem49.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem49.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem49.TextToControlDistance = 5;
            // 
            // layoutControlItem51
            // 
            this.layoutControlItem51.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem51.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem51.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem51.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem51.Control = this.lblPONumberDetail;
            this.layoutControlItem51.CustomizationFormText = "Order No:";
            this.layoutControlItem51.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem51.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem51.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem51.Name = "layoutControlItem24";
            this.layoutControlItem51.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem51.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem51.Text = "Order No:";
            this.layoutControlItem51.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem51.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem51.TextToControlDistance = 5;
            // 
            // layoutControlItem53
            // 
            this.layoutControlItem53.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem53.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem53.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem53.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem53.Control = this.lblInvoiceTypeDetail;
            this.layoutControlItem53.CustomizationFormText = "Order No:";
            this.layoutControlItem53.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem53.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem53.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem53.Name = "layoutControlItem24";
            this.layoutControlItem53.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem53.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem53.Text = "Order No:";
            this.layoutControlItem53.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem53.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem53.TextToControlDistance = 5;
            // 
            // layoutControlItem55
            // 
            this.layoutControlItem55.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem55.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem55.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem55.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem55.Control = this.lblPOTypeDetail;
            this.layoutControlItem55.CustomizationFormText = "Order No:";
            this.layoutControlItem55.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem55.MaxSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem55.MinSize = new System.Drawing.Size(220, 20);
            this.layoutControlItem55.Name = "layoutControlItem24";
            this.layoutControlItem55.Size = new System.Drawing.Size(220, 20);
            this.layoutControlItem55.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem55.Text = "Order No:";
            this.layoutControlItem55.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem55.TextSize = new System.Drawing.Size(52, 13);
            this.layoutControlItem55.TextToControlDistance = 5;
            // 
            // ReceiptInvoiceDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 535);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ReceiptInvoiceDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Invoice";
            this.Load += new System.EventHandler(this.ReceiptInvoiceDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkDocumentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInvoiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plusMinusButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkInvoiceType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCustomDutyTax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInvoiceDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkCurrencyLCID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCBEServiceCharge.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGrvView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExchangeRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransitNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWayBill.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceSeaFreight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceAirFreight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceInlandFreight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutFinancialInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutGoodsReceived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem57)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem55)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSaveInvoice;
        private DevExpress.XtraEditors.TextEdit txtInsurance;
        private DevExpress.XtraEditors.TextEdit txtInvoiceNumber;
        private DevExpress.XtraEditors.TextEdit txtTotalValue;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidation;
        private DevExpress.XtraEditors.TextEdit txtTransitNumber;
        private DevExpress.XtraEditors.TextEdit txtWayBill;
        private DevExpress.XtraGrid.GridControl gridGrv;
        private DevExpress.XtraGrid.Views.Grid.GridView gridGrvView;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colGRVNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferTransitNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalValue;
        private DevExpress.XtraGrid.Columns.GridColumn colDamaged;
        private DevExpress.XtraEditors.DateEdit dtInvoiceDate;
        private DevExpress.XtraEditors.TextEdit txtInvoiceCustomDutyTax;
        private DevExpress.XtraEditors.TextEdit txtInvoiceCBEServiceCharge;
        private DevExpress.XtraEditors.TextEdit txtInvoiceSeaFreight;
        private DevExpress.XtraEditors.TextEdit txtInvoiceAirFreight;
        private DevExpress.XtraEditors.TextEdit txtInvoiceInlandFreight;
        private DevExpress.XtraEditors.LookUpEdit lkInvoiceType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colFreight;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomDutyTax;
        private DevExpress.XtraGrid.Columns.GridColumn colCBE;
        private DevExpress.XtraEditors.LookUpEdit lkCurrencyLCID;
        private DevExpress.XtraEditors.TextEdit txtExchangeRate;
        private DevExpress.XtraLayout.TabbedControlGroup tabInvoice;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup HeaderGroup;
        private DevExpress.XtraLayout.LayoutControlGroup layoutGoodsReceived;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutFinancialInformation;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl gridInvoiceDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInvoiceDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colManufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderdQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoicedQty;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.SimpleButton btnCancelInvoice;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSaved;
        private DevExpress.XtraGrid.Columns.GridColumn colExpiryDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBatchNo;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMargin;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCost;
        private DevExpress.XtraGrid.Columns.GridColumn colPlusMinus;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit plusMinusButtonEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colguid;
        private DevExpress.XtraEditors.LabelControl lblAccount;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraEditors.LabelControl lblSupplier;
        private DevExpress.XtraEditors.LabelControl lblRefNo;
        private DevExpress.XtraEditors.LabelControl lblOrderNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraEditors.LabelControl lblActivity;
        private DevExpress.XtraEditors.LabelControl lblSubAccount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraEditors.LabelControl lblOrderStatus;
        private DevExpress.XtraEditors.LabelControl lblPOType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraEditors.LabelControl lblPOTypeDetail;
        private DevExpress.XtraEditors.LabelControl lblInvoiceTypeDetail;
        private DevExpress.XtraEditors.LabelControl lblPONumberDetail;
        private DevExpress.XtraEditors.LabelControl lblAccountDetail;
        private DevExpress.XtraEditors.LabelControl lblActivityDetail;
        private DevExpress.XtraEditors.LabelControl lblSubAccountDetail;
        private DevExpress.XtraEditors.LabelControl lblInvoiceNoDetail;
        private DevExpress.XtraEditors.LabelControl lblModeDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem52;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem54;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem56;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem51;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem53;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem55;
        private DevExpress.XtraLayout.LayoutControlGroup HeaderGroupDetail;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraEditors.LookUpEdit lkDocumentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem57;
    }
}