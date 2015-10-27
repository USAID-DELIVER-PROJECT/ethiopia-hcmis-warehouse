namespace HCMIS.Desktop.Forms.WorkFlow
{
    partial class PurchaseOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseOrderForm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition3 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition4 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.btnEditInvoice = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblPOBy = new DevExpress.XtraEditors.LabelControl();
            this.lblLetterNo = new DevExpress.XtraEditors.LabelControl();
            this.lblSyncDate = new DevExpress.XtraEditors.LabelControl();
            this.lblShipper = new DevExpress.XtraEditors.LabelControl();
            this.lblPaymentType = new DevExpress.XtraEditors.LabelControl();
            this.lblPOStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderDate = new DevExpress.XtraEditors.LabelControl();
            this.lblInsurance = new DevExpress.XtraEditors.LabelControl();
            this.lblRemainingValue = new DevExpress.XtraEditors.LabelControl();
            this.lblNBE = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalValue = new DevExpress.XtraEditors.LabelControl();
            this.lblPOType = new DevExpress.XtraEditors.LabelControl();
            this.lblSupplier = new DevExpress.XtraEditors.LabelControl();
            this.lblRefNo = new DevExpress.XtraEditors.LabelControl();
            this.lblPONumber = new DevExpress.XtraEditors.LabelControl();
            this.lblActivity = new DevExpress.XtraEditors.LabelControl();
            this.lblSubAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.txtFilter = new DevExpress.XtraEditors.TextEdit();
            this.chkboxIsElectronic = new System.Windows.Forms.RadioButton();
            this.TabOrderTabs = new DevExpress.XtraTab.XtraTabControl();
            this.InvoicesTab = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.btnAddInvoice = new DevExpress.XtraEditors.SimpleButton();
            this.gridInvoice = new DevExpress.XtraGrid.GridControl();
            this.gridInvoiceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWayBilNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsurancePolicyNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferTransitNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsurance = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNBE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEditButton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tabPoDetail = new DevExpress.XtraTab.XtraTabPage();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.grdPoDetail = new DevExpress.XtraGrid.GridControl();
            this.grdPoDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManufacturer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPODetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddOrderDetail = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnEditOrder = new DevExpress.XtraEditors.SimpleButton();
            this.gridLkEditOrderType = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddOrder = new DevExpress.XtraEditors.SimpleButton();
            this.gridOrder = new DevExpress.XtraGrid.GridControl();
            this.gridOrderView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColIsElectronic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdColPOType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutSelectedOrderDetail = new DevExpress.XtraLayout.LayoutControlGroup();
            this.HeaderGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem44 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem48 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem42 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup7 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem50 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem37 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem40 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem46 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.LayoutEmptyDetails = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.simpleLabelItem4 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem5 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem6 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem7 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem8 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem9 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem10 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem11 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem14 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem18 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem19 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem20 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem21 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem22 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem23 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem24 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.simpleLabelItem26 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem38 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem28 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem39 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem41 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem43 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem45 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem49 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabOrderTabs)).BeginInit();
            this.TabOrderTabs.SuspendLayout();
            this.InvoicesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.tabPoDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPoDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPoDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLkEditOrderType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutSelectedOrderDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutEmptyDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Edit", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("btnEditInvoice.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.ReadOnly = true;
            this.btnEditInvoice.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnEditInvoice.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEditInvoice_ButtonClick);
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.lblPOBy);
            this.layoutControl1.Controls.Add(this.lblLetterNo);
            this.layoutControl1.Controls.Add(this.lblSyncDate);
            this.layoutControl1.Controls.Add(this.lblShipper);
            this.layoutControl1.Controls.Add(this.lblPaymentType);
            this.layoutControl1.Controls.Add(this.lblPOStatus);
            this.layoutControl1.Controls.Add(this.lblOrderDate);
            this.layoutControl1.Controls.Add(this.lblInsurance);
            this.layoutControl1.Controls.Add(this.lblRemainingValue);
            this.layoutControl1.Controls.Add(this.lblNBE);
            this.layoutControl1.Controls.Add(this.lblTotalValue);
            this.layoutControl1.Controls.Add(this.lblPOType);
            this.layoutControl1.Controls.Add(this.lblSupplier);
            this.layoutControl1.Controls.Add(this.lblRefNo);
            this.layoutControl1.Controls.Add(this.lblPONumber);
            this.layoutControl1.Controls.Add(this.lblActivity);
            this.layoutControl1.Controls.Add(this.lblSubAccount);
            this.layoutControl1.Controls.Add(this.lblAccount);
            this.layoutControl1.Controls.Add(this.lblMode);
            this.layoutControl1.Controls.Add(this.txtFilter);
            this.layoutControl1.Controls.Add(this.chkboxIsElectronic);
            this.layoutControl1.Controls.Add(this.TabOrderTabs);
            this.layoutControl1.Controls.Add(this.btnEditOrder);
            this.layoutControl1.Controls.Add(this.gridLkEditOrderType);
            this.layoutControl1.Controls.Add(this.btnAddOrder);
            this.layoutControl1.Controls.Add(this.gridOrder);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem21});
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-17, 244, 250, 595);
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1280, 691);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblPOBy
            // 
            this.lblPOBy.Location = new System.Drawing.Point(874, 193);
            this.lblPOBy.Name = "lblPOBy";
            this.lblPOBy.Size = new System.Drawing.Size(154, 16);
            this.lblPOBy.StyleController = this.layoutControl1;
            this.lblPOBy.TabIndex = 70;
            // 
            // lblLetterNo
            // 
            this.lblLetterNo.Location = new System.Drawing.Point(656, 146);
            this.lblLetterNo.Name = "lblLetterNo";
            this.lblLetterNo.Size = new System.Drawing.Size(162, 16);
            this.lblLetterNo.StyleController = this.layoutControl1;
            this.lblLetterNo.TabIndex = 70;
            // 
            // lblSyncDate
            // 
            this.lblSyncDate.Location = new System.Drawing.Point(912, 146);
            this.lblSyncDate.Name = "lblSyncDate";
            this.lblSyncDate.Size = new System.Drawing.Size(131, 16);
            this.lblSyncDate.StyleController = this.layoutControl1;
            this.lblSyncDate.TabIndex = 76;
            this.lblSyncDate.Click += new System.EventHandler(this.lblSyncDate_Click);
            // 
            // lblShipper
            // 
            this.lblShipper.Location = new System.Drawing.Point(657, 106);
            this.lblShipper.Name = "lblShipper";
            this.lblShipper.Size = new System.Drawing.Size(161, 16);
            this.lblShipper.StyleController = this.layoutControl1;
            this.lblShipper.TabIndex = 69;
            // 
            // lblPaymentType
            // 
            this.lblPaymentType.Location = new System.Drawing.Point(912, 106);
            this.lblPaymentType.Name = "lblPaymentType";
            this.lblPaymentType.Size = new System.Drawing.Size(131, 16);
            this.lblPaymentType.StyleController = this.layoutControl1;
            this.lblPaymentType.TabIndex = 68;
            // 
            // lblPOStatus
            // 
            this.lblPOStatus.Location = new System.Drawing.Point(1100, 193);
            this.lblPOStatus.Name = "lblPOStatus";
            this.lblPOStatus.Size = new System.Drawing.Size(161, 16);
            this.lblPOStatus.StyleController = this.layoutControl1;
            this.lblPOStatus.TabIndex = 75;
            this.lblPOStatus.Text = "N/A";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.Location = new System.Drawing.Point(874, 173);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(154, 16);
            this.lblOrderDate.StyleController = this.layoutControl1;
            this.lblOrderDate.TabIndex = 74;
            this.lblOrderDate.Click += new System.EventHandler(this.lblOrderDate_Click);
            // 
            // lblInsurance
            // 
            this.lblInsurance.Location = new System.Drawing.Point(710, 193);
            this.lblInsurance.Name = "lblInsurance";
            this.lblInsurance.Size = new System.Drawing.Size(93, 16);
            this.lblInsurance.StyleController = this.layoutControl1;
            this.lblInsurance.TabIndex = 73;
            this.lblInsurance.Click += new System.EventHandler(this.lblInsurance_Click);
            // 
            // lblRemainingValue
            // 
            this.lblRemainingValue.Location = new System.Drawing.Point(475, 193);
            this.lblRemainingValue.Name = "lblRemainingValue";
            this.lblRemainingValue.Size = new System.Drawing.Size(101, 16);
            this.lblRemainingValue.StyleController = this.layoutControl1;
            this.lblRemainingValue.TabIndex = 72;
            // 
            // lblNBE
            // 
            this.lblNBE.Location = new System.Drawing.Point(710, 173);
            this.lblNBE.Name = "lblNBE";
            this.lblNBE.Size = new System.Drawing.Size(93, 16);
            this.lblNBE.StyleController = this.layoutControl1;
            this.lblNBE.TabIndex = 71;
            this.lblNBE.Click += new System.EventHandler(this.lblNBE_Click);
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Location = new System.Drawing.Point(475, 173);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(101, 16);
            this.lblTotalValue.StyleController = this.layoutControl1;
            this.lblTotalValue.TabIndex = 70;
            this.lblTotalValue.Click += new System.EventHandler(this.lblTotalValue_Click);
            // 
            // lblPOType
            // 
            this.lblPOType.Location = new System.Drawing.Point(1100, 173);
            this.lblPOType.Name = "lblPOType";
            this.lblPOType.Size = new System.Drawing.Size(161, 16);
            this.lblPOType.StyleController = this.layoutControl1;
            this.lblPOType.TabIndex = 69;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(424, 106);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(168, 16);
            this.lblSupplier.StyleController = this.layoutControl1;
            this.lblSupplier.TabIndex = 68;
            // 
            // lblRefNo
            // 
            this.lblRefNo.Location = new System.Drawing.Point(425, 146);
            this.lblRefNo.Name = "lblRefNo";
            this.lblRefNo.Size = new System.Drawing.Size(167, 16);
            this.lblRefNo.StyleController = this.layoutControl1;
            this.lblRefNo.TabIndex = 67;
            // 
            // lblPONumber
            // 
            this.lblPONumber.Location = new System.Drawing.Point(457, 106);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(119, 16);
            this.lblPONumber.StyleController = this.layoutControl1;
            this.lblPONumber.TabIndex = 66;
            // 
            // lblActivity
            // 
            this.lblActivity.Location = new System.Drawing.Point(1099, 126);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(169, 16);
            this.lblActivity.StyleController = this.layoutControl1;
            this.lblActivity.TabIndex = 65;
            this.lblActivity.Text = "N/A";
            // 
            // lblSubAccount
            // 
            this.lblSubAccount.Location = new System.Drawing.Point(912, 126);
            this.lblSubAccount.Name = "lblSubAccount";
            this.lblSubAccount.Size = new System.Drawing.Size(131, 16);
            this.lblSubAccount.StyleController = this.layoutControl1;
            this.lblSubAccount.TabIndex = 64;
            this.lblSubAccount.Text = "N/A";
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(657, 126);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(161, 16);
            this.lblAccount.StyleController = this.layoutControl1;
            this.lblAccount.TabIndex = 63;
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(424, 126);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(168, 16);
            this.lblMode.StyleController = this.layoutControl1;
            this.lblMode.TabIndex = 62;
            this.lblMode.Click += new System.EventHandler(this.lblMode_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(62, 56);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(276, 20);
            this.txtFilter.StyleController = this.layoutControl1;
            this.txtFilter.TabIndex = 61;
            this.txtFilter.EditValueChanged += new System.EventHandler(this.txtFilter_EditValueChanged);
            // 
            // chkboxIsElectronic
            // 
            this.chkboxIsElectronic.Checked = true;
            this.chkboxIsElectronic.Enabled = false;
            this.chkboxIsElectronic.Location = new System.Drawing.Point(1047, 146);
            this.chkboxIsElectronic.Name = "chkboxIsElectronic";
            this.chkboxIsElectronic.Size = new System.Drawing.Size(221, 16);
            this.chkboxIsElectronic.TabIndex = 60;
            this.chkboxIsElectronic.TabStop = true;
            this.chkboxIsElectronic.Text = "Is Electronic";
            this.chkboxIsElectronic.UseVisualStyleBackColor = true;
            // 
            // TabOrderTabs
            // 
            this.TabOrderTabs.Location = new System.Drawing.Point(363, 253);
            this.TabOrderTabs.Name = "TabOrderTabs";
            this.TabOrderTabs.SelectedTabPage = this.InvoicesTab;
            this.TabOrderTabs.Size = new System.Drawing.Size(912, 433);
            this.TabOrderTabs.TabIndex = 4;
            this.TabOrderTabs.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.InvoicesTab,
            this.tabPoDetail});
            // 
            // InvoicesTab
            // 
            this.InvoicesTab.Controls.Add(this.layoutControl2);
            this.InvoicesTab.Name = "InvoicesTab";
            this.InvoicesTab.Size = new System.Drawing.Size(906, 405);
            this.InvoicesTab.Text = "Invoices";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.btnAddInvoice);
            this.layoutControl2.Controls.Add(this.gridInvoice);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(0, 0);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(405, 67, 250, 350);
            this.layoutControl2.Root = this.layoutControlGroup4;
            this.layoutControl2.Size = new System.Drawing.Size(906, 405);
            this.layoutControl2.TabIndex = 11;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Image = global::HCMIS.Desktop.Properties.Resources.add_16;
            this.btnAddInvoice.Location = new System.Drawing.Point(752, 371);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(142, 22);
            this.btnAddInvoice.StyleController = this.layoutControl2;
            this.btnAddInvoice.TabIndex = 13;
            this.btnAddInvoice.Text = "Add Invoice";
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddNewInvoice_Click);
            // 
            // gridInvoice
            // 
            this.gridInvoice.Location = new System.Drawing.Point(12, 12);
            this.gridInvoice.MainView = this.gridInvoiceView;
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Size = new System.Drawing.Size(882, 355);
            this.gridInvoice.TabIndex = 12;
            this.gridInvoice.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInvoiceView});
            this.gridInvoice.FocusedViewChanged += new DevExpress.XtraGrid.ViewFocusEventHandler(this.gridInvoice_FocusedViewChanged);
            this.gridInvoice.DoubleClick += new System.EventHandler(this.gridInvoiceView_DoubleClick);
            // 
            // gridInvoiceView
            // 
            this.gridInvoiceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceID,
            this.colInvoiceNo,
            this.colWayBilNo,
            this.colInsurancePolicyNo,
            this.colTransferTransitNo,
            this.colTotalValue,
            this.colInsurance,
            this.colNBE,
            this.colEditButton});
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
            this.gridInvoiceView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridInvoiceView.GridControl = this.gridInvoice;
            this.gridInvoiceView.Name = "gridInvoiceView";
            this.gridInvoiceView.OptionsCustomization.AllowColumnMoving = false;
            this.gridInvoiceView.OptionsCustomization.AllowColumnResizing = false;
            this.gridInvoiceView.OptionsCustomization.AllowFilter = false;
            this.gridInvoiceView.OptionsCustomization.AllowSort = false;
            this.gridInvoiceView.OptionsMenu.EnableColumnMenu = false;
            this.gridInvoiceView.OptionsMenu.EnableFooterMenu = false;
            this.gridInvoiceView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridInvoiceView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridInvoiceView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridInvoiceView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridInvoiceView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridInvoiceView.OptionsMenu.ShowSplitItem = false;
            this.gridInvoiceView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridInvoiceView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridInvoiceView.OptionsView.ShowGroupPanel = false;
            this.gridInvoiceView.OptionsView.ShowIndicator = false;
            this.gridInvoiceView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridInvoiceView_FocusedRowChanged);
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
            // colInvoiceNo
            // 
            this.colInvoiceNo.Caption = "Invoice No";
            this.colInvoiceNo.FieldName = "STVOrInvoiceNo";
            this.colInvoiceNo.Name = "colInvoiceNo";
            this.colInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colInvoiceNo.OptionsColumn.AllowFocus = false;
            this.colInvoiceNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsColumn.AllowIncrementalSearch = false;
            this.colInvoiceNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsColumn.AllowMove = false;
            this.colInvoiceNo.OptionsColumn.AllowShowHide = false;
            this.colInvoiceNo.OptionsColumn.AllowSize = false;
            this.colInvoiceNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colInvoiceNo.OptionsColumn.ShowInExpressionEditor = false;
            this.colInvoiceNo.OptionsColumn.TabStop = false;
            this.colInvoiceNo.OptionsFilter.AllowAutoFilter = false;
            this.colInvoiceNo.OptionsFilter.AllowFilter = false;
            this.colInvoiceNo.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colInvoiceNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNo.Visible = true;
            this.colInvoiceNo.VisibleIndex = 0;
            // 
            // colWayBilNo
            // 
            this.colWayBilNo.Caption = "Way Bill No";
            this.colWayBilNo.FieldName = "WayBillNo";
            this.colWayBilNo.Name = "colWayBilNo";
            this.colWayBilNo.OptionsColumn.AllowEdit = false;
            this.colWayBilNo.OptionsColumn.AllowFocus = false;
            this.colWayBilNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colWayBilNo.OptionsColumn.AllowIncrementalSearch = false;
            this.colWayBilNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colWayBilNo.OptionsColumn.AllowMove = false;
            this.colWayBilNo.OptionsColumn.AllowShowHide = false;
            this.colWayBilNo.OptionsColumn.AllowSize = false;
            this.colWayBilNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colWayBilNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colWayBilNo.OptionsColumn.ShowInExpressionEditor = false;
            this.colWayBilNo.OptionsColumn.TabStop = false;
            this.colWayBilNo.OptionsFilter.AllowAutoFilter = false;
            this.colWayBilNo.OptionsFilter.AllowFilter = false;
            this.colWayBilNo.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colWayBilNo.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colWayBilNo.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colWayBilNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colWayBilNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colWayBilNo.Visible = true;
            this.colWayBilNo.VisibleIndex = 1;
            // 
            // colInsurancePolicyNo
            // 
            this.colInsurancePolicyNo.Caption = "Insurance Policy No";
            this.colInsurancePolicyNo.FieldName = "InsurancePolicyNo";
            this.colInsurancePolicyNo.Name = "colInsurancePolicyNo";
            this.colInsurancePolicyNo.OptionsColumn.AllowEdit = false;
            this.colInsurancePolicyNo.OptionsColumn.AllowFocus = false;
            this.colInsurancePolicyNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurancePolicyNo.OptionsColumn.AllowIncrementalSearch = false;
            this.colInsurancePolicyNo.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurancePolicyNo.OptionsColumn.AllowMove = false;
            this.colInsurancePolicyNo.OptionsColumn.AllowShowHide = false;
            this.colInsurancePolicyNo.OptionsColumn.AllowSize = false;
            this.colInsurancePolicyNo.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurancePolicyNo.OptionsColumn.ShowInCustomizationForm = false;
            this.colInsurancePolicyNo.OptionsColumn.ShowInExpressionEditor = false;
            this.colInsurancePolicyNo.OptionsColumn.TabStop = false;
            this.colInsurancePolicyNo.OptionsFilter.AllowAutoFilter = false;
            this.colInsurancePolicyNo.OptionsFilter.AllowFilter = false;
            this.colInsurancePolicyNo.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurancePolicyNo.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurancePolicyNo.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colInsurancePolicyNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurancePolicyNo.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurancePolicyNo.Visible = true;
            this.colInsurancePolicyNo.VisibleIndex = 2;
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
            this.colTransferTransitNo.VisibleIndex = 3;
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
            this.colTotalValue.Visible = true;
            this.colTotalValue.VisibleIndex = 4;
            // 
            // colInsurance
            // 
            this.colInsurance.Caption = "Insurance";
            this.colInsurance.DisplayFormat.FormatString = "ETB ###,###,##0.#0";
            this.colInsurance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInsurance.FieldName = "proInsurance";
            this.colInsurance.Name = "colInsurance";
            this.colInsurance.OptionsColumn.AllowEdit = false;
            this.colInsurance.OptionsColumn.AllowFocus = false;
            this.colInsurance.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurance.OptionsColumn.AllowIncrementalSearch = false;
            this.colInsurance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurance.OptionsColumn.AllowMove = false;
            this.colInsurance.OptionsColumn.AllowShowHide = false;
            this.colInsurance.OptionsColumn.AllowSize = false;
            this.colInsurance.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurance.OptionsColumn.ShowInCustomizationForm = false;
            this.colInsurance.OptionsColumn.ShowInExpressionEditor = false;
            this.colInsurance.OptionsColumn.TabStop = false;
            this.colInsurance.OptionsFilter.AllowAutoFilter = false;
            this.colInsurance.OptionsFilter.AllowFilter = false;
            this.colInsurance.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurance.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurance.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colInsurance.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurance.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colInsurance.Visible = true;
            this.colInsurance.VisibleIndex = 5;
            // 
            // colNBE
            // 
            this.colNBE.Caption = "NBE";
            this.colNBE.DisplayFormat.FormatString = "ETB ###,###,##0.#0";
            this.colNBE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNBE.FieldName = "proNBE";
            this.colNBE.Name = "colNBE";
            this.colNBE.OptionsColumn.AllowEdit = false;
            this.colNBE.OptionsColumn.AllowFocus = false;
            this.colNBE.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNBE.OptionsColumn.AllowIncrementalSearch = false;
            this.colNBE.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colNBE.OptionsColumn.AllowMove = false;
            this.colNBE.OptionsColumn.AllowShowHide = false;
            this.colNBE.OptionsColumn.AllowSize = false;
            this.colNBE.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNBE.OptionsColumn.ShowInCustomizationForm = false;
            this.colNBE.OptionsColumn.ShowInExpressionEditor = false;
            this.colNBE.OptionsColumn.TabStop = false;
            this.colNBE.OptionsFilter.AllowAutoFilter = false;
            this.colNBE.OptionsFilter.AllowFilter = false;
            this.colNBE.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colNBE.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colNBE.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colNBE.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colNBE.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colNBE.Visible = true;
            this.colNBE.VisibleIndex = 6;
            // 
            // colEditButton
            // 
            this.colEditButton.ColumnEdit = this.btnEditInvoice;
            this.colEditButton.Name = "colEditButton";
            this.colEditButton.OptionsColumn.AllowEdit = false;
            this.colEditButton.OptionsColumn.AllowFocus = false;
            this.colEditButton.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colEditButton.OptionsColumn.AllowIncrementalSearch = false;
            this.colEditButton.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colEditButton.OptionsColumn.AllowMove = false;
            this.colEditButton.OptionsColumn.AllowShowHide = false;
            this.colEditButton.OptionsColumn.AllowSize = false;
            this.colEditButton.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colEditButton.OptionsColumn.ShowInCustomizationForm = false;
            this.colEditButton.OptionsColumn.ShowInExpressionEditor = false;
            this.colEditButton.OptionsColumn.TabStop = false;
            this.colEditButton.OptionsFilter.AllowAutoFilter = false;
            this.colEditButton.OptionsFilter.AllowFilter = false;
            this.colEditButton.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colEditButton.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colEditButton.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colEditButton.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colEditButton.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colEditButton.Visible = true;
            this.colEditButton.VisibleIndex = 7;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.emptySpaceItem6,
            this.layoutControlItem7});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(906, 405);
            this.layoutControlGroup4.Text = "layoutControlGroup4";
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridInvoice;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(886, 359);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(0, 359);
            this.emptySpaceItem6.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(740, 26);
            this.emptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnAddInvoice;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(740, 359);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // tabPoDetail
            // 
            this.tabPoDetail.Controls.Add(this.layoutControl3);
            this.tabPoDetail.Name = "tabPoDetail";
            this.tabPoDetail.Size = new System.Drawing.Size(906, 405);
            this.tabPoDetail.Text = "Order Details";
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.grdPoDetail);
            this.layoutControl3.Controls.Add(this.btnAddOrderDetail);
            this.layoutControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl3.Location = new System.Drawing.Point(0, 0);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(412, 43, 250, 350);
            this.layoutControl3.Root = this.layoutControlGroup5;
            this.layoutControl3.Size = new System.Drawing.Size(906, 405);
            this.layoutControl3.TabIndex = 61;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // grdPoDetail
            // 
            this.grdPoDetail.Location = new System.Drawing.Point(12, 12);
            this.grdPoDetail.MainView = this.grdPoDetailView;
            this.grdPoDetail.Name = "grdPoDetail";
            this.grdPoDetail.Size = new System.Drawing.Size(882, 355);
            this.grdPoDetail.TabIndex = 2;
            this.grdPoDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdPoDetailView});
            // 
            // grdPoDetailView
            // 
            this.grdPoDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.colManufacturer,
            this.gridColumn6,
            this.gridColumn7,
            this.colPODetailID});
            this.grdPoDetailView.GridControl = this.grdPoDetail;
            this.grdPoDetailView.Name = "grdPoDetailView";
            this.grdPoDetailView.OptionsBehavior.Editable = false;
            this.grdPoDetailView.OptionsCustomization.AllowColumnMoving = false;
            this.grdPoDetailView.OptionsCustomization.AllowColumnResizing = false;
            this.grdPoDetailView.OptionsCustomization.AllowFilter = false;
            this.grdPoDetailView.OptionsMenu.EnableColumnMenu = false;
            this.grdPoDetailView.OptionsMenu.EnableFooterMenu = false;
            this.grdPoDetailView.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdPoDetailView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.grdPoDetailView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.grdPoDetailView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.grdPoDetailView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grdPoDetailView.OptionsMenu.ShowSplitItem = false;
            this.grdPoDetailView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grdPoDetailView.OptionsView.ShowGroupPanel = false;
            this.grdPoDetailView.OptionsView.ShowIndicator = false;
            this.grdPoDetailView.DoubleClick += new System.EventHandler(this.grdPoDetailView_Click);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Item";
            this.gridColumn3.FieldName = "FullItemName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.AllowShowHide = false;
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn3.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn3.OptionsColumn.TabStop = false;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn3.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Unit";
            this.gridColumn5.FieldName = "Unit";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn5.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.AllowShowHide = false;
            this.gridColumn5.OptionsColumn.AllowSize = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn5.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn5.OptionsColumn.TabStop = false;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn5.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
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
            this.colManufacturer.OptionsColumn.ShowInCustomizationForm = false;
            this.colManufacturer.OptionsColumn.ShowInExpressionEditor = false;
            this.colManufacturer.OptionsColumn.TabStop = false;
            this.colManufacturer.OptionsFilter.AllowAutoFilter = false;
            this.colManufacturer.OptionsFilter.AllowFilter = false;
            this.colManufacturer.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colManufacturer.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colManufacturer.Visible = true;
            this.colManufacturer.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Quantity";
            this.gridColumn6.DisplayFormat.FormatString = "#,###.##";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "Quantity";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.AllowMove = false;
            this.gridColumn6.OptionsColumn.AllowShowHide = false;
            this.gridColumn6.OptionsColumn.AllowSize = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn6.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn6.OptionsColumn.TabStop = false;
            this.gridColumn6.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn6.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Total Cost";
            this.gridColumn7.DisplayFormat.FormatString = "#,###.##";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Amount";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.AllowShowHide = false;
            this.gridColumn7.OptionsColumn.AllowSize = false;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.ShowInCustomizationForm = false;
            this.gridColumn7.OptionsColumn.ShowInExpressionEditor = false;
            this.gridColumn7.OptionsColumn.TabStop = false;
            this.gridColumn7.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn7.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            // 
            // colPODetailID
            // 
            this.colPODetailID.Caption = "PurchaseOrderDetailID";
            this.colPODetailID.FieldName = "PurchaseOrderDetailID";
            this.colPODetailID.Name = "colPODetailID";
            this.colPODetailID.OptionsColumn.AllowEdit = false;
            this.colPODetailID.OptionsColumn.AllowFocus = false;
            this.colPODetailID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPODetailID.OptionsColumn.AllowIncrementalSearch = false;
            this.colPODetailID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPODetailID.OptionsColumn.AllowMove = false;
            this.colPODetailID.OptionsColumn.AllowShowHide = false;
            this.colPODetailID.OptionsColumn.AllowSize = false;
            this.colPODetailID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPODetailID.OptionsColumn.ShowInCustomizationForm = false;
            this.colPODetailID.OptionsColumn.ShowInExpressionEditor = false;
            this.colPODetailID.OptionsColumn.TabStop = false;
            this.colPODetailID.OptionsFilter.AllowAutoFilter = false;
            this.colPODetailID.OptionsFilter.AllowFilter = false;
            this.colPODetailID.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colPODetailID.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colPODetailID.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colPODetailID.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colPODetailID.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            // 
            // btnAddOrderDetail
            // 
            this.btnAddOrderDetail.Image = global::HCMIS.Desktop.Properties.Resources.add_16;
            this.btnAddOrderDetail.Location = new System.Drawing.Point(752, 371);
            this.btnAddOrderDetail.Name = "btnAddOrderDetail";
            this.btnAddOrderDetail.Size = new System.Drawing.Size(142, 22);
            this.btnAddOrderDetail.StyleController = this.layoutControl3;
            this.btnAddOrderDetail.TabIndex = 60;
            this.btnAddOrderDetail.Text = "Add/Edit Detail";
            this.btnAddOrderDetail.Click += new System.EventHandler(this.btnAddOrderDetail_Click);
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5";
            this.layoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup5.GroupBordersVisible = false;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem9,
            this.layoutControlItem10,
            this.emptySpaceItem7});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(906, 405);
            this.layoutControlGroup5.Text = "layoutControlGroup5";
            this.layoutControlGroup5.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.grdPoDetail;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(886, 359);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnAddOrderDetail;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(740, 359);
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
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(0, 359);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(740, 26);
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Image = global::HCMIS.Desktop.Properties.Resources.Edit2;
            this.btnEditOrder.Location = new System.Drawing.Point(1126, 220);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(142, 22);
            this.btnEditOrder.StyleController = this.layoutControl1;
            this.btnEditOrder.TabIndex = 59;
            this.btnEditOrder.Text = "Edit Order";
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // gridLkEditOrderType
            // 
            this.gridLkEditOrderType.Location = new System.Drawing.Point(62, 31);
            this.gridLkEditOrderType.Name = "gridLkEditOrderType";
            this.gridLkEditOrderType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLkEditOrderType.Properties.DisplayMember = "Name";
            this.gridLkEditOrderType.Properties.NullText = "All Orders";
            this.gridLkEditOrderType.Properties.ShowFooter = false;
            this.gridLkEditOrderType.Properties.ValueMember = "ID";
            this.gridLkEditOrderType.Properties.View = this.gridView1;
            this.gridLkEditOrderType.Size = new System.Drawing.Size(276, 20);
            this.gridLkEditOrderType.StyleController = this.layoutControl1;
            this.gridLkEditOrderType.TabIndex = 58;
            this.gridLkEditOrderType.EditValueChanged += new System.EventHandler(this.lkOrderType_EditValueChanged);
            this.gridLkEditOrderType.DoubleClick += new System.EventHandler(this.gridLkEditOrderType_DoubleClick);
            this.gridLkEditOrderType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridLkEditOrderType_KeyDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn4, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Order Type";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Mode";
            this.gridColumn4.FieldName = "Group";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Image = global::HCMIS.Desktop.Properties.Resources.add_16;
            this.btnAddOrder.Location = new System.Drawing.Point(203, 664);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(142, 22);
            this.btnAddOrder.StyleController = this.layoutControl1;
            this.btnAddOrder.TabIndex = 9;
            this.btnAddOrder.Text = "Add New Order";
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // gridOrder
            // 
            this.gridOrder.Location = new System.Drawing.Point(5, 87);
            this.gridOrder.MainView = this.gridOrderView;
            this.gridOrder.Name = "gridOrder";
            this.gridOrder.Padding = new System.Windows.Forms.Padding(2);
            this.gridOrder.Size = new System.Drawing.Size(340, 573);
            this.gridOrder.TabIndex = 1;
            this.gridOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridOrderView});
            this.gridOrder.Click += new System.EventHandler(this.gridOrder_Click);
            // 
            // gridOrderView
            // 
            this.gridOrderView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderNumber,
            this.colSupplierName,
            this.colID,
            this.grdColIsElectronic,
            this.grdColPOType});
            styleFormatCondition3.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            styleFormatCondition3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout);
            styleFormatCondition3.Appearance.Options.UseBackColor = true;
            styleFormatCondition3.Appearance.Options.UseFont = true;
            styleFormatCondition3.ApplyToRow = true;
            styleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition3.Expression = "[Status]>[CurrentStatus]";
            styleFormatCondition4.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            styleFormatCondition4.Appearance.Options.UseBackColor = true;
            styleFormatCondition4.ApplyToRow = true;
            styleFormatCondition4.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition4.Expression = "[Status]<[CurrentStatus]";
            this.gridOrderView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition3,
            styleFormatCondition4});
            this.gridOrderView.GridControl = this.gridOrder;
            this.gridOrderView.Name = "gridOrderView";
            this.gridOrderView.OptionsCustomization.AllowColumnMoving = false;
            this.gridOrderView.OptionsCustomization.AllowColumnResizing = false;
            this.gridOrderView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridOrderView.OptionsFilter.AllowFilterEditor = false;
            this.gridOrderView.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gridOrderView.OptionsFilter.AllowMRUFilterList = false;
            this.gridOrderView.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.gridOrderView.OptionsFilter.FilterEditorUseMenuForOperandsAndOperators = false;
            this.gridOrderView.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.gridOrderView.OptionsMenu.EnableColumnMenu = false;
            this.gridOrderView.OptionsMenu.EnableFooterMenu = false;
            this.gridOrderView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridOrderView.OptionsMenu.ShowAddNewSummaryItem = DevExpress.Utils.DefaultBoolean.False;
            this.gridOrderView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.gridOrderView.OptionsMenu.ShowDateTimeGroupIntervalItems = false;
            this.gridOrderView.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.gridOrderView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridOrderView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridOrderView.OptionsView.ShowGroupPanel = false;
            this.gridOrderView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridOrderView_FocusedRowChanged);
            this.gridOrderView.DoubleClick += new System.EventHandler(this.gridOrderView_DoubleClick);
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.Caption = "PO No";
            this.colOrderNumber.FieldName = "OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.OptionsColumn.AllowEdit = false;
            this.colOrderNumber.OptionsColumn.AllowFocus = false;
            this.colOrderNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNumber.OptionsColumn.AllowIncrementalSearch = false;
            this.colOrderNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNumber.OptionsColumn.AllowMove = false;
            this.colOrderNumber.OptionsColumn.AllowShowHide = false;
            this.colOrderNumber.OptionsColumn.AllowSize = false;
            this.colOrderNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNumber.OptionsColumn.ShowInCustomizationForm = false;
            this.colOrderNumber.OptionsColumn.ShowInExpressionEditor = false;
            this.colOrderNumber.OptionsColumn.TabStop = false;
            this.colOrderNumber.OptionsFilter.AllowAutoFilter = false;
            this.colOrderNumber.OptionsFilter.AllowFilter = false;
            this.colOrderNumber.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNumber.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colOrderNumber.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNumber.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colOrderNumber.Visible = true;
            this.colOrderNumber.VisibleIndex = 0;
            this.colOrderNumber.Width = 51;
            // 
            // colSupplierName
            // 
            this.colSupplierName.Caption = "Supplier";
            this.colSupplierName.FieldName = "Supplier";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.OptionsColumn.AllowEdit = false;
            this.colSupplierName.OptionsColumn.AllowFocus = false;
            this.colSupplierName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsColumn.AllowIncrementalSearch = false;
            this.colSupplierName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsColumn.AllowMove = false;
            this.colSupplierName.OptionsColumn.AllowShowHide = false;
            this.colSupplierName.OptionsColumn.AllowSize = false;
            this.colSupplierName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsColumn.ShowInCustomizationForm = false;
            this.colSupplierName.OptionsColumn.ShowInExpressionEditor = false;
            this.colSupplierName.OptionsColumn.TabStop = false;
            this.colSupplierName.OptionsFilter.AllowAutoFilter = false;
            this.colSupplierName.OptionsFilter.AllowFilter = false;
            this.colSupplierName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colSupplierName.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.Visible = true;
            this.colSupplierName.VisibleIndex = 1;
            this.colSupplierName.Width = 111;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.AllowFocus = false;
            this.colID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsColumn.AllowIncrementalSearch = false;
            this.colID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsColumn.AllowMove = false;
            this.colID.OptionsColumn.AllowShowHide = false;
            this.colID.OptionsColumn.AllowSize = false;
            this.colID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            this.colID.OptionsColumn.ShowInExpressionEditor = false;
            this.colID.OptionsColumn.TabStop = false;
            this.colID.OptionsFilter.AllowAutoFilter = false;
            this.colID.OptionsFilter.AllowFilter = false;
            this.colID.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colID.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            // 
            // grdColIsElectronic
            // 
            this.grdColIsElectronic.Caption = "IsElectronic";
            this.grdColIsElectronic.FieldName = "IsElectronicString";
            this.grdColIsElectronic.Name = "grdColIsElectronic";
            this.grdColIsElectronic.OptionsColumn.AllowEdit = false;
            this.grdColIsElectronic.OptionsColumn.AllowFocus = false;
            this.grdColIsElectronic.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdColIsElectronic.OptionsColumn.AllowIncrementalSearch = false;
            this.grdColIsElectronic.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.grdColIsElectronic.OptionsColumn.AllowMove = false;
            this.grdColIsElectronic.OptionsColumn.AllowShowHide = false;
            this.grdColIsElectronic.OptionsColumn.AllowSize = false;
            this.grdColIsElectronic.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdColIsElectronic.OptionsColumn.ReadOnly = true;
            this.grdColIsElectronic.OptionsColumn.ShowInCustomizationForm = false;
            this.grdColIsElectronic.OptionsColumn.ShowInExpressionEditor = false;
            this.grdColIsElectronic.OptionsColumn.TabStop = false;
            this.grdColIsElectronic.OptionsFilter.AllowAutoFilter = false;
            this.grdColIsElectronic.OptionsFilter.AllowFilter = false;
            this.grdColIsElectronic.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.grdColIsElectronic.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.grdColIsElectronic.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.grdColIsElectronic.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.grdColIsElectronic.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.grdColIsElectronic.Visible = true;
            this.grdColIsElectronic.VisibleIndex = 2;
            this.grdColIsElectronic.Width = 72;
            // 
            // grdColPOType
            // 
            this.grdColPOType.Caption = "PO Type";
            this.grdColPOType.FieldName = "Name";
            this.grdColPOType.Name = "grdColPOType";
            this.grdColPOType.OptionsColumn.AllowEdit = false;
            this.grdColPOType.OptionsColumn.AllowFocus = false;
            this.grdColPOType.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.grdColPOType.OptionsColumn.AllowIncrementalSearch = false;
            this.grdColPOType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.grdColPOType.OptionsColumn.AllowMove = false;
            this.grdColPOType.OptionsColumn.AllowShowHide = false;
            this.grdColPOType.OptionsColumn.AllowSize = false;
            this.grdColPOType.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.grdColPOType.OptionsColumn.ShowInCustomizationForm = false;
            this.grdColPOType.OptionsColumn.ShowInExpressionEditor = false;
            this.grdColPOType.OptionsColumn.TabStop = false;
            this.grdColPOType.OptionsFilter.AllowAutoFilter = false;
            this.grdColPOType.OptionsFilter.AllowFilter = false;
            this.grdColPOType.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.grdColPOType.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.grdColPOType.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.grdColPOType.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.grdColPOType.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.grdColPOType.Visible = true;
            this.grdColPOType.VisibleIndex = 3;
            this.grdColPOType.Width = 76;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem21.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem21.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem21.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem21.Control = this.lblPONumber;
            this.layoutControlItem21.CustomizationFormText = "Order Number:";
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem21.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(81, 20);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(210, 20);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.Text = "Order Number:";
            this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(82, 13);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.LayoutSelectedOrderDetail,
            this.LayoutEmptyDetails,
            this.emptySpaceItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1280, 691);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Purchase Orders";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem8,
            this.emptySpaceItem1,
            this.layoutControlGroup6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(350, 691);
            this.layoutControlGroup2.Text = "Orders";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridOrder;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 82);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(344, 577);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnAddOrder;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(198, 659);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 659);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(198, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "Filter";
            this.layoutControlGroup6.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem11});
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup6";
            this.layoutControlGroup6.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup6.Size = new System.Drawing.Size(344, 82);
            this.layoutControlGroup6.Text = "Filter";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridLkEditOrderType;
            this.layoutControlItem3.CustomizationFormText = "Order Type";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(100, 20);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(330, 25);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "PO Type:";
            this.layoutControlItem3.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(45, 13);
            this.layoutControlItem3.TextToControlDistance = 5;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtFilter;
            this.layoutControlItem11.CustomizationFormText = "Filter:";
            this.layoutControlItem11.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(330, 24);
            this.layoutControlItem11.Text = "Filter:";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(28, 13);
            this.layoutControlItem11.TextToControlDistance = 22;
            // 
            // LayoutSelectedOrderDetail
            // 
            this.LayoutSelectedOrderDetail.CustomizationFormText = "Purchase Order Details";
            this.LayoutSelectedOrderDetail.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.HeaderGroup,
            this.layoutControlItem6});
            this.LayoutSelectedOrderDetail.Location = new System.Drawing.Point(358, 75);
            this.LayoutSelectedOrderDetail.Name = "LayoutSelectedOrderDetail";
            this.LayoutSelectedOrderDetail.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.LayoutSelectedOrderDetail.Size = new System.Drawing.Size(922, 616);
            this.LayoutSelectedOrderDetail.Text = "Order Details";
            this.LayoutSelectedOrderDetail.TextVisible = false;
            this.LayoutSelectedOrderDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // HeaderGroup
            // 
            this.HeaderGroup.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.HeaderGroup.AppearanceGroup.Options.UseFont = true;
            this.HeaderGroup.CustomizationFormText = " ";
            this.HeaderGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12,
            this.layoutControlItem14,
            this.layoutControlItem16,
            this.layoutControlItem18,
            this.emptySpaceItem3,
            this.layoutControlItem2,
            this.layoutControlItem25,
            this.emptySpaceItem4,
            this.layoutControlItem44,
            this.layoutControlItem48,
            this.layoutControlItem42,
            this.layoutControlItem5,
            this.layoutControlGroup3,
            this.layoutControlGroup7,
            this.layoutControlGroup8,
            this.layoutControlGroup9,
            this.layoutControlItem46,
            this.layoutControlItem23});
            this.HeaderGroup.Location = new System.Drawing.Point(0, 0);
            this.HeaderGroup.Name = "HeaderGroup";
            this.HeaderGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.HeaderGroup.Size = new System.Drawing.Size(916, 173);
            this.HeaderGroup.Text = " ";
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem12.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem12.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem12.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem12.Control = this.lblMode;
            this.layoutControlItem12.CustomizationFormText = "Mode:";
            this.layoutControlItem12.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(39, 20);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(226, 20);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "Mode:";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(34, 13);
            this.layoutControlItem12.TextToControlDistance = 20;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem14.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem14.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem14.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem14.Control = this.lblAccount;
            this.layoutControlItem14.CustomizationFormText = "Account:";
            this.layoutControlItem14.Location = new System.Drawing.Point(226, 20);
            this.layoutControlItem14.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem14.MinSize = new System.Drawing.Size(52, 20);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(226, 20);
            this.layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem14.Text = "Account:";
            this.layoutControlItem14.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem14.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem14.TextToControlDistance = 12;
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem16.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem16.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem16.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem16.Control = this.lblSubAccount;
            this.layoutControlItem16.CustomizationFormText = "Sub Account:";
            this.layoutControlItem16.Location = new System.Drawing.Point(452, 20);
            this.layoutControlItem16.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem16.MinSize = new System.Drawing.Size(91, 20);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(225, 20);
            this.layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem16.Text = "Sub Account:";
            this.layoutControlItem16.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem16.TextSize = new System.Drawing.Size(73, 13);
            this.layoutControlItem16.TextToControlDistance = 17;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem18.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem18.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem18.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem18.Control = this.lblActivity;
            this.layoutControlItem18.CustomizationFormText = "Activity:";
            this.layoutControlItem18.Location = new System.Drawing.Point(677, 20);
            this.layoutControlItem18.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(225, 20);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.Text = "Activity:";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 114);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(756, 26);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnEditOrder;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(756, 114);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem25.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem25.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem25.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem25.Control = this.lblSupplier;
            this.layoutControlItem25.CustomizationFormText = "Supplier:";
            this.layoutControlItem25.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem25.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(51, 20);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(226, 20);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.Text = "Supplier:";
            this.layoutControlItem25.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem25.TextToControlDistance = 5;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(677, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(225, 20);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem44
            // 
            this.layoutControlItem44.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem44.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem44.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem44.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem44.Control = this.lblPaymentType;
            this.layoutControlItem44.CustomizationFormText = "Payment Type:";
            this.layoutControlItem44.Location = new System.Drawing.Point(452, 0);
            this.layoutControlItem44.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem44.MinSize = new System.Drawing.Size(94, 20);
            this.layoutControlItem44.Name = "layoutControlItem44";
            this.layoutControlItem44.Size = new System.Drawing.Size(225, 20);
            this.layoutControlItem44.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem44.Text = "Payment Type:";
            this.layoutControlItem44.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem44.TextSize = new System.Drawing.Size(85, 13);
            this.layoutControlItem44.TextToControlDistance = 5;
            // 
            // layoutControlItem48
            // 
            this.layoutControlItem48.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem48.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem48.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem48.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem48.Control = this.lblLetterNo;
            this.layoutControlItem48.CustomizationFormText = "Letter No:";
            this.layoutControlItem48.Location = new System.Drawing.Point(226, 40);
            this.layoutControlItem48.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem48.MinSize = new System.Drawing.Size(64, 20);
            this.layoutControlItem48.Name = "layoutControlItem48";
            this.layoutControlItem48.Size = new System.Drawing.Size(226, 20);
            this.layoutControlItem48.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem48.Text = "Letter No:";
            this.layoutControlItem48.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem48.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem48.TextToControlDistance = 5;
            // 
            // layoutControlItem42
            // 
            this.layoutControlItem42.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem42.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem42.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem42.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem42.Control = this.lblSyncDate;
            this.layoutControlItem42.CustomizationFormText = "Sync Date:";
            this.layoutControlItem42.Location = new System.Drawing.Point(452, 40);
            this.layoutControlItem42.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem42.MinSize = new System.Drawing.Size(62, 20);
            this.layoutControlItem42.Name = "layoutControlItem42";
            this.layoutControlItem42.Size = new System.Drawing.Size(225, 20);
            this.layoutControlItem42.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem42.Text = "Sync Date:";
            this.layoutControlItem42.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem42.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem42.TextToControlDistance = 30;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.chkboxIsElectronic;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(677, 40);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(24, 20);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(225, 20);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem29,
            this.layoutControlItem33});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 60);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup3.Size = new System.Drawing.Size(217, 54);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(-2, 2, 2, 2);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem29.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem29.Control = this.lblTotalValue;
            this.layoutControlItem29.CustomizationFormText = "layoutControlItem29";
            this.layoutControlItem29.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem29.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(66, 20);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(207, 20);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "Total Value:";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(66, 13);
            this.layoutControlItem29.TextToControlDistance = 36;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem33.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem33.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem33.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem33.Control = this.lblRemainingValue;
            this.layoutControlItem33.CustomizationFormText = "layoutControlItem33";
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem33.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem33.MinSize = new System.Drawing.Size(91, 20);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(207, 20);
            this.layoutControlItem33.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem33.Text = "Remaining Value:";
            this.layoutControlItem33.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(97, 13);
            this.layoutControlItem33.TextToControlDistance = 5;
            // 
            // layoutControlGroup7
            // 
            this.layoutControlGroup7.CustomizationFormText = "layoutControlGroup7";
            this.layoutControlGroup7.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem31,
            this.layoutControlItem35});
            this.layoutControlGroup7.Location = new System.Drawing.Point(217, 60);
            this.layoutControlGroup7.Name = "layoutControlGroup7";
            this.layoutControlGroup7.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup7.Size = new System.Drawing.Size(227, 54);
            this.layoutControlGroup7.Text = "layoutControlGroup7";
            this.layoutControlGroup7.TextVisible = false;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem31.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem31.Control = this.lblNBE;
            this.layoutControlItem31.CustomizationFormText = "layoutControlItem31";
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem31.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem31.MinSize = new System.Drawing.Size(108, 20);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(213, 20);
            this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem31.Text = "NBE Service Charge:";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(111, 13);
            this.layoutControlItem31.TextToControlDistance = 5;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem35.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem35.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem35.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem35.Control = this.lblInsurance;
            this.layoutControlItem35.CustomizationFormText = "layoutControlItem35";
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem35.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem35.MinSize = new System.Drawing.Size(61, 20);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(213, 20);
            this.layoutControlItem35.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem35.Text = "Insurance:";
            this.layoutControlItem35.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem35.TextToControlDistance = 56;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.CustomizationFormText = "layoutControlGroup8";
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem50,
            this.layoutControlItem37});
            this.layoutControlGroup8.Location = new System.Drawing.Point(444, 60);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup8.Size = new System.Drawing.Size(225, 54);
            this.layoutControlGroup8.Text = "layoutControlGroup8";
            this.layoutControlGroup8.TextVisible = false;
            // 
            // layoutControlItem50
            // 
            this.layoutControlItem50.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem50.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem50.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem50.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem50.Control = this.lblPOBy;
            this.layoutControlItem50.CustomizationFormText = "PO By:";
            this.layoutControlItem50.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem50.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem50.MinSize = new System.Drawing.Size(47, 20);
            this.layoutControlItem50.Name = "layoutControlItem50";
            this.layoutControlItem50.Size = new System.Drawing.Size(211, 20);
            this.layoutControlItem50.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem50.Text = "PO By:";
            this.layoutControlItem50.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem50.TextSize = new System.Drawing.Size(35, 13);
            this.layoutControlItem50.TextToControlDistance = 18;
            // 
            // layoutControlItem37
            // 
            this.layoutControlItem37.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem37.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem37.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem37.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem37.Control = this.lblOrderDate;
            this.layoutControlItem37.CustomizationFormText = "layoutControlItem37";
            this.layoutControlItem37.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem37.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem37.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem37.Name = "layoutControlItem37";
            this.layoutControlItem37.Size = new System.Drawing.Size(211, 20);
            this.layoutControlItem37.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem37.Text = "PO Date:";
            this.layoutControlItem37.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem37.TextSize = new System.Drawing.Size(48, 13);
            this.layoutControlItem37.TextToControlDistance = 5;
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.CustomizationFormText = "layoutControlGroup9";
            this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem27,
            this.layoutControlItem40});
            this.layoutControlGroup9.Location = new System.Drawing.Point(669, 60);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup9.Size = new System.Drawing.Size(233, 54);
            this.layoutControlGroup9.Text = "layoutControlGroup9";
            this.layoutControlGroup9.TextVisible = false;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem27.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem27.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem27.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem27.Control = this.lblPOType;
            this.layoutControlItem27.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem27.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem27.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(54, 20);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(219, 20);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "PO Type:";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem40
            // 
            this.layoutControlItem40.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem40.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem40.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem40.Control = this.lblPOStatus;
            this.layoutControlItem40.CustomizationFormText = "layoutControlItem40";
            this.layoutControlItem40.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem40.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem40.MinSize = new System.Drawing.Size(65, 20);
            this.layoutControlItem40.Name = "layoutControlItem40";
            this.layoutControlItem40.Size = new System.Drawing.Size(219, 20);
            this.layoutControlItem40.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem40.Text = "Status: ";
            this.layoutControlItem40.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem40.TextSize = new System.Drawing.Size(43, 13);
            this.layoutControlItem40.TextToControlDistance = 11;
            // 
            // layoutControlItem46
            // 
            this.layoutControlItem46.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem46.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem46.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem46.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem46.Control = this.lblShipper;
            this.layoutControlItem46.CustomizationFormText = "Shipper:";
            this.layoutControlItem46.Location = new System.Drawing.Point(226, 0);
            this.layoutControlItem46.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem46.MinSize = new System.Drawing.Size(65, 20);
            this.layoutControlItem46.Name = "layoutControlItem46";
            this.layoutControlItem46.Size = new System.Drawing.Size(226, 20);
            this.layoutControlItem46.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem46.Text = "Shipper:";
            this.layoutControlItem46.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem46.TextSize = new System.Drawing.Size(46, 13);
            this.layoutControlItem46.TextToControlDistance = 15;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem23.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem23.Control = this.lblRefNo;
            this.layoutControlItem23.CustomizationFormText = "Ref No:";
            this.layoutControlItem23.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem23.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(46, 20);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(226, 20);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.Text = "Ref No:";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(39, 13);
            this.layoutControlItem23.TextToControlDistance = 16;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.TabOrderTabs;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 173);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(916, 437);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // LayoutEmptyDetails
            // 
            this.LayoutEmptyDetails.CustomizationFormText = " ";
            this.LayoutEmptyDetails.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleLabelItem1});
            this.LayoutEmptyDetails.Location = new System.Drawing.Point(358, 0);
            this.LayoutEmptyDetails.Name = "LayoutEmptyDetails";
            this.LayoutEmptyDetails.Size = new System.Drawing.Size(922, 75);
            this.LayoutEmptyDetails.Text = " ";
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.simpleLabelItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleLabelItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.simpleLabelItem1.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.simpleLabelItem1.CustomizationFormText = "Please Select a Purchase Order From The Left";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.MinSize = new System.Drawing.Size(115, 17);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(898, 32);
            this.simpleLabelItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.simpleLabelItem1.Text = "Please Select Order";
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(110, 13);
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem9";
            this.emptySpaceItem9.Location = new System.Drawing.Point(350, 0);
            this.emptySpaceItem9.MaxSize = new System.Drawing.Size(8, 0);
            this.emptySpaceItem9.MinSize = new System.Drawing.Size(8, 24);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(8, 691);
            this.emptySpaceItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem9.Text = "emptySpaceItem9";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // simpleLabelItem4
            // 
            this.simpleLabelItem4.AllowHotTrack = false;
            this.simpleLabelItem4.CustomizationFormText = "LabellblTotalValue";
            this.simpleLabelItem4.Location = new System.Drawing.Point(224, 27);
            this.simpleLabelItem4.Name = "lblTotalValue";
            this.simpleLabelItem4.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem4.Text = "LabellblTotalValue";
            this.simpleLabelItem4.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem5
            // 
            this.simpleLabelItem5.AllowHotTrack = false;
            this.simpleLabelItem5.CustomizationFormText = "Total Value : ";
            this.simpleLabelItem5.Location = new System.Drawing.Point(0, 27);
            this.simpleLabelItem5.Name = "simpleLabelItem3";
            this.simpleLabelItem5.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem5.Text = "Total Value : ";
            this.simpleLabelItem5.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem6
            // 
            this.simpleLabelItem6.AllowHotTrack = false;
            this.simpleLabelItem6.CustomizationFormText = "Purchase Order Number : ";
            this.simpleLabelItem6.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem6.Name = "simpleLabelItem2";
            this.simpleLabelItem6.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem6.Text = "Purchase Order Number : ";
            this.simpleLabelItem6.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem7
            // 
            this.simpleLabelItem7.AllowHotTrack = false;
            this.simpleLabelItem7.CustomizationFormText = "LabellblPONumber";
            this.simpleLabelItem7.Location = new System.Drawing.Point(224, 0);
            this.simpleLabelItem7.Name = "lblPONumber";
            this.simpleLabelItem7.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem7.Text = "LabellblPONumber";
            this.simpleLabelItem7.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem8
            // 
            this.simpleLabelItem8.AllowHotTrack = false;
            this.simpleLabelItem8.CustomizationFormText = "Purchase Order Number : ";
            this.simpleLabelItem8.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem8.Name = "simpleLabelItem2";
            this.simpleLabelItem8.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem8.Text = "Purchase Order Number : ";
            this.simpleLabelItem8.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem9
            // 
            this.simpleLabelItem9.AllowHotTrack = false;
            this.simpleLabelItem9.CustomizationFormText = "Purchase Order Number : ";
            this.simpleLabelItem9.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem9.Name = "simpleLabelItem2";
            this.simpleLabelItem9.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem9.Text = "Purchase Order Number : ";
            this.simpleLabelItem9.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem10
            // 
            this.simpleLabelItem10.AllowHotTrack = false;
            this.simpleLabelItem10.CustomizationFormText = "LabellblPONumber";
            this.simpleLabelItem10.Location = new System.Drawing.Point(224, 0);
            this.simpleLabelItem10.Name = "lblPONumber";
            this.simpleLabelItem10.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem10.Text = "LabellblPONumber";
            this.simpleLabelItem10.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem11
            // 
            this.simpleLabelItem11.AllowHotTrack = false;
            this.simpleLabelItem11.CustomizationFormText = "Purchase Order Number : ";
            this.simpleLabelItem11.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem11.Name = "simpleLabelItem2";
            this.simpleLabelItem11.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem11.Text = "Purchase Order Number : ";
            this.simpleLabelItem11.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem14
            // 
            this.simpleLabelItem14.AllowHotTrack = false;
            this.simpleLabelItem14.CustomizationFormText = "LabellblPONumber";
            this.simpleLabelItem14.Location = new System.Drawing.Point(224, 0);
            this.simpleLabelItem14.Name = "lblPONumber";
            this.simpleLabelItem14.Size = new System.Drawing.Size(224, 17);
            this.simpleLabelItem14.Text = "LabellblPONumber";
            this.simpleLabelItem14.TextSize = new System.Drawing.Size(220, 13);
            // 
            // simpleLabelItem18
            // 
            this.simpleLabelItem18.AllowHotTrack = false;
            this.simpleLabelItem18.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem18.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem18.CustomizationFormText = "Account";
            this.simpleLabelItem18.Location = new System.Drawing.Point(340, 0);
            this.simpleLabelItem18.Name = "simpleLabelItem16";
            this.simpleLabelItem18.Size = new System.Drawing.Size(117, 17);
            this.simpleLabelItem18.Text = "Account";
            this.simpleLabelItem18.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleLabelItem19
            // 
            this.simpleLabelItem19.AllowHotTrack = false;
            this.simpleLabelItem19.CustomizationFormText = "LabellblAccount";
            this.simpleLabelItem19.Location = new System.Drawing.Point(115, 17);
            this.simpleLabelItem19.Name = "lblAccount";
            this.simpleLabelItem19.Size = new System.Drawing.Size(771, 17);
            this.simpleLabelItem19.Text = " ";
            this.simpleLabelItem19.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleLabelItem20
            // 
            this.simpleLabelItem20.AllowHotTrack = false;
            this.simpleLabelItem20.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem20.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem20.CustomizationFormText = "Account";
            this.simpleLabelItem20.Location = new System.Drawing.Point(0, 17);
            this.simpleLabelItem20.Name = "simpleLabelItem16";
            this.simpleLabelItem20.Size = new System.Drawing.Size(115, 17);
            this.simpleLabelItem20.Text = "Account";
            this.simpleLabelItem20.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleLabelItem21
            // 
            this.simpleLabelItem21.AllowHotTrack = false;
            this.simpleLabelItem21.CustomizationFormText = "LabellblAccount";
            this.simpleLabelItem21.Location = new System.Drawing.Point(115, 17);
            this.simpleLabelItem21.Name = "lblAccount";
            this.simpleLabelItem21.Size = new System.Drawing.Size(771, 17);
            this.simpleLabelItem21.Text = " ";
            this.simpleLabelItem21.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleLabelItem22
            // 
            this.simpleLabelItem22.AllowHotTrack = false;
            this.simpleLabelItem22.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem22.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem22.CustomizationFormText = "Account";
            this.simpleLabelItem22.Location = new System.Drawing.Point(0, 17);
            this.simpleLabelItem22.Name = "simpleLabelItem16";
            this.simpleLabelItem22.Size = new System.Drawing.Size(115, 17);
            this.simpleLabelItem22.Text = "Account";
            this.simpleLabelItem22.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleLabelItem23
            // 
            this.simpleLabelItem23.AllowHotTrack = false;
            this.simpleLabelItem23.CustomizationFormText = "LabellblAccount";
            this.simpleLabelItem23.Location = new System.Drawing.Point(115, 17);
            this.simpleLabelItem23.Name = "lblAccount";
            this.simpleLabelItem23.Size = new System.Drawing.Size(771, 17);
            this.simpleLabelItem23.Text = " ";
            this.simpleLabelItem23.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleLabelItem24
            // 
            this.simpleLabelItem24.AllowHotTrack = false;
            this.simpleLabelItem24.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleLabelItem24.AppearanceItemCaption.Options.UseFont = true;
            this.simpleLabelItem24.CustomizationFormText = "Insurance";
            this.simpleLabelItem24.Location = new System.Drawing.Point(397, 85);
            this.simpleLabelItem24.Name = "simpleLabelItem13";
            this.simpleLabelItem24.Size = new System.Drawing.Size(143, 17);
            this.simpleLabelItem24.Text = "Insurance:";
            this.simpleLabelItem24.TextSize = new System.Drawing.Size(111, 13);
            // 
            // simpleLabelItem26
            // 
            this.simpleLabelItem26.AllowHotTrack = false;
            this.simpleLabelItem26.CustomizationFormText = "LabellblInsurance";
            this.simpleLabelItem26.Location = new System.Drawing.Point(540, 85);
            this.simpleLabelItem26.Name = "lblInsurance";
            this.simpleLabelItem26.Size = new System.Drawing.Size(213, 17);
            this.simpleLabelItem26.Text = " ";
            this.simpleLabelItem26.TextSize = new System.Drawing.Size(111, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 50);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(857, 269);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 271);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(496, 23);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(742, 68);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(193, 17);
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem20.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem20.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem20.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem20.Control = this.txtFilter;
            this.layoutControlItem20.CustomizationFormText = "Letter Number";
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(281, 24);
            this.layoutControlItem20.Text = "Letter Number:";
            this.layoutControlItem20.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(85, 13);
            this.layoutControlItem20.TextToControlDistance = 9;
            // 
            // layoutControlItem38
            // 
            this.layoutControlItem38.Control = this.lblMode;
            this.layoutControlItem38.CustomizationFormText = "Order Number: ";
            this.layoutControlItem38.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem38.Name = "layoutControlItem38";
            this.layoutControlItem38.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem38.Text = "Order No.: ";
            this.layoutControlItem38.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem38.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem38.TextToControlDistance = 8;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.lblAccount;
            this.layoutControlItem13.CustomizationFormText = "Order Number: ";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem38";
            this.layoutControlItem13.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem13.Text = "Order No.: ";
            this.layoutControlItem13.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem13.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem13.TextToControlDistance = 8;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.lblSubAccount;
            this.layoutControlItem15.CustomizationFormText = "Order Number: ";
            this.layoutControlItem15.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem15.Name = "layoutControlItem38";
            this.layoutControlItem15.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem15.Text = "Order No.: ";
            this.layoutControlItem15.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem15.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem15.TextToControlDistance = 8;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.lblActivity;
            this.layoutControlItem17.CustomizationFormText = "Order Number: ";
            this.layoutControlItem17.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem17.Name = "layoutControlItem38";
            this.layoutControlItem17.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem17.Text = "Order No.: ";
            this.layoutControlItem17.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem17.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem17.TextToControlDistance = 8;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.lblPONumber;
            this.layoutControlItem19.CustomizationFormText = "Order Number: ";
            this.layoutControlItem19.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem19.Name = "layoutControlItem38";
            this.layoutControlItem19.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem19.Text = "Order No.: ";
            this.layoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem19.TextToControlDistance = 8;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.lblRefNo;
            this.layoutControlItem22.CustomizationFormText = "Order Number: ";
            this.layoutControlItem22.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem22.Name = "layoutControlItem38";
            this.layoutControlItem22.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem22.Text = "Order No.: ";
            this.layoutControlItem22.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem22.TextToControlDistance = 8;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.Control = this.lblSupplier;
            this.layoutControlItem24.CustomizationFormText = "Order Number: ";
            this.layoutControlItem24.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem24.Name = "layoutControlItem38";
            this.layoutControlItem24.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem24.Text = "Order No.: ";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem24.TextToControlDistance = 8;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.Control = this.lblPOType;
            this.layoutControlItem26.CustomizationFormText = "Order Number: ";
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem26.Name = "layoutControlItem38";
            this.layoutControlItem26.Size = new System.Drawing.Size(252, 22);
            this.layoutControlItem26.Text = "Order No.: ";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(55, 13);
            this.layoutControlItem26.TextToControlDistance = 8;
            // 
            // layoutControlItem28
            // 
            this.layoutControlItem28.Control = this.lblTotalValue;
            this.layoutControlItem28.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem28.Location = new System.Drawing.Point(0, 658);
            this.layoutControlItem28.Name = "layoutControlItem27";
            this.layoutControlItem28.Size = new System.Drawing.Size(1264, 17);
            this.layoutControlItem28.Text = "layoutControlItem27";
            this.layoutControlItem28.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem28.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem28.TextToControlDistance = 5;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.Control = this.lblNBE;
            this.layoutControlItem30.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 658);
            this.layoutControlItem30.Name = "layoutControlItem27";
            this.layoutControlItem30.Size = new System.Drawing.Size(1264, 17);
            this.layoutControlItem30.Text = "layoutControlItem27";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.Control = this.lblRemainingValue;
            this.layoutControlItem32.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 658);
            this.layoutControlItem32.Name = "layoutControlItem27";
            this.layoutControlItem32.Size = new System.Drawing.Size(1264, 17);
            this.layoutControlItem32.Text = "layoutControlItem27";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem32.TextToControlDistance = 5;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.Control = this.lblInsurance;
            this.layoutControlItem34.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem34.Location = new System.Drawing.Point(0, 658);
            this.layoutControlItem34.Name = "layoutControlItem27";
            this.layoutControlItem34.Size = new System.Drawing.Size(1264, 17);
            this.layoutControlItem34.Text = "layoutControlItem27";
            this.layoutControlItem34.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem34.TextToControlDistance = 5;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.lblOrderDate;
            this.layoutControlItem36.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem36.Location = new System.Drawing.Point(0, 658);
            this.layoutControlItem36.Name = "layoutControlItem27";
            this.layoutControlItem36.Size = new System.Drawing.Size(1264, 17);
            this.layoutControlItem36.Text = "layoutControlItem27";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem36.TextToControlDistance = 5;
            // 
            // layoutControlItem39
            // 
            this.layoutControlItem39.Control = this.lblPOStatus;
            this.layoutControlItem39.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem39.Location = new System.Drawing.Point(0, 658);
            this.layoutControlItem39.Name = "layoutControlItem27";
            this.layoutControlItem39.Size = new System.Drawing.Size(1264, 17);
            this.layoutControlItem39.Text = "layoutControlItem27";
            this.layoutControlItem39.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem39.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem39.TextToControlDistance = 5;
            // 
            // layoutControlItem41
            // 
            this.layoutControlItem41.Control = this.lblSyncDate;
            this.layoutControlItem41.CustomizationFormText = "layoutControlItem37";
            this.layoutControlItem41.Location = new System.Drawing.Point(0, 641);
            this.layoutControlItem41.Name = "layoutControlItem37";
            this.layoutControlItem41.Size = new System.Drawing.Size(1264, 17);
            this.layoutControlItem41.Text = "layoutControlItem37";
            this.layoutControlItem41.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem41.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem41.TextToControlDistance = 5;
            // 
            // layoutControlItem43
            // 
            this.layoutControlItem43.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem43.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem43.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem43.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem43.Control = this.lblPaymentType;
            this.layoutControlItem43.CustomizationFormText = "Ref No:";
            this.layoutControlItem43.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem43.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem43.MinSize = new System.Drawing.Size(46, 20);
            this.layoutControlItem43.Name = "layoutControlItem23";
            this.layoutControlItem43.Size = new System.Drawing.Size(210, 20);
            this.layoutControlItem43.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem43.Text = "Ref No:";
            this.layoutControlItem43.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem43.TextSize = new System.Drawing.Size(39, 13);
            this.layoutControlItem43.TextToControlDistance = 77;
            // 
            // layoutControlItem45
            // 
            this.layoutControlItem45.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem45.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem45.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem45.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem45.Control = this.lblShipper;
            this.layoutControlItem45.CustomizationFormText = "Ref No:";
            this.layoutControlItem45.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem45.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem45.MinSize = new System.Drawing.Size(46, 20);
            this.layoutControlItem45.Name = "layoutControlItem23";
            this.layoutControlItem45.Size = new System.Drawing.Size(210, 20);
            this.layoutControlItem45.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem45.Text = "Ref No:";
            this.layoutControlItem45.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem45.TextSize = new System.Drawing.Size(39, 13);
            this.layoutControlItem45.TextToControlDistance = 77;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem47.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem47.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem47.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem47.Control = this.lblLetterNo;
            this.layoutControlItem47.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem47.Location = new System.Drawing.Point(426, 0);
            this.layoutControlItem47.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem47.MinSize = new System.Drawing.Size(54, 20);
            this.layoutControlItem47.Name = "layoutControlItem27";
            this.layoutControlItem47.Size = new System.Drawing.Size(291, 20);
            this.layoutControlItem47.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem47.Text = "PO Type:";
            this.layoutControlItem47.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem47.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem47.TextToControlDistance = 16;
            // 
            // layoutControlItem49
            // 
            this.layoutControlItem49.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem49.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem49.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem49.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem49.Control = this.lblPOBy;
            this.layoutControlItem49.CustomizationFormText = "layoutControlItem27";
            this.layoutControlItem49.Location = new System.Drawing.Point(426, 0);
            this.layoutControlItem49.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem49.MinSize = new System.Drawing.Size(54, 20);
            this.layoutControlItem49.Name = "layoutControlItem27";
            this.layoutControlItem49.Size = new System.Drawing.Size(291, 20);
            this.layoutControlItem49.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem49.Text = "PO Type:";
            this.layoutControlItem49.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem49.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem49.TextToControlDistance = 16;
            // 
            // PurchaseOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 695);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PurchaseOrderForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Purchase Order Form";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnEditInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabOrderTabs)).EndInit();
            this.TabOrderTabs.ResumeLayout(false);
            this.InvoicesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.tabPoDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPoDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPoDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLkEditOrderType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridOrderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutSelectedOrderDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem42)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutEmptyDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem49)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridOrder;
        private DevExpress.XtraGrid.Views.Grid.GridView gridOrderView;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnAddOrder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutEmptyDetails;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutSelectedOrderDetail;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem4;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem5;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem6;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem7;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem8;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem9;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem10;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem11;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem14;
        private DevExpress.XtraEditors.GridLookUpEdit gridLkEditOrderType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnEditOrder;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem18;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem19;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem20;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem21;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem22;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem23;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem24;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem26;
        private DevExpress.XtraEditors.SimpleButton btnAddOrderDetail;
        private DevExpress.XtraTab.XtraTabControl TabOrderTabs;
        private DevExpress.XtraTab.XtraTabPage InvoicesTab;
        private DevExpress.XtraTab.XtraTabPage tabPoDetail;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl grdPoDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grdPoDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colManufacturer;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn colPODetailID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddInvoice;
        private DevExpress.XtraGrid.GridControl gridInvoice;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInvoiceView;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceID;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colWayBilNo;
        private DevExpress.XtraGrid.Columns.GridColumn colInsurancePolicyNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferTransitNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalValue;
        private DevExpress.XtraGrid.Columns.GridColumn colInsurance;
        private DevExpress.XtraGrid.Columns.GridColumn colNBE;
        private DevExpress.XtraGrid.Columns.GridColumn colEditButton;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnEditInvoice;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private System.Windows.Forms.RadioButton chkboxIsElectronic;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
        private DevExpress.XtraGrid.Columns.GridColumn grdColIsElectronic;
        private DevExpress.XtraEditors.TextEdit txtFilter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraGrid.Columns.GridColumn grdColPOType;
        private DevExpress.XtraEditors.LabelControl lblPONumber;
        private DevExpress.XtraEditors.LabelControl lblActivity;
        private DevExpress.XtraEditors.LabelControl lblSubAccount;
        private DevExpress.XtraEditors.LabelControl lblAccount;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem38;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraEditors.LabelControl lblPOType;
        private DevExpress.XtraEditors.LabelControl lblSupplier;
        private DevExpress.XtraEditors.LabelControl lblRefNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraEditors.LabelControl lblRemainingValue;
        private DevExpress.XtraEditors.LabelControl lblNBE;
        private DevExpress.XtraEditors.LabelControl lblTotalValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem28;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraEditors.LabelControl lblPOStatus;
        private DevExpress.XtraEditors.LabelControl lblOrderDate;
        private DevExpress.XtraEditors.LabelControl lblInsurance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem37;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem40;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem39;
        private DevExpress.XtraEditors.LabelControl lblSyncDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem42;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem41;
        private DevExpress.XtraLayout.LayoutControlGroup HeaderGroup;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.LabelControl lblShipper;
        private DevExpress.XtraEditors.LabelControl lblPaymentType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem43;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem45;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem44;
        private DevExpress.XtraEditors.LabelControl lblLetterNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem46;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem48;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup7;
        private DevExpress.XtraEditors.LabelControl lblPOBy;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem50;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem49;



    }
}