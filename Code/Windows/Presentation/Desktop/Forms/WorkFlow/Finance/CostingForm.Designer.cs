namespace HCMIS.Desktop.Forms.WorkFlow
{
    partial class CostingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CostingForm));
            this.gridGRVs = new DevExpress.XtraGrid.GridControl();
            this.gridGRVsView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colInvoiceNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiptID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPGRV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Account = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn66 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEditReceivingCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.lkPalletLocations = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.textEditMargin = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblSubTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblGrandTotal = new DevExpress.XtraEditors.LabelControl();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lblInsurance = new DevExpress.XtraEditors.LabelControl();
            this.lblAmount = new DevExpress.XtraEditors.LabelControl();
            this.txtGrandTotal = new DevExpress.XtraEditors.TextEdit();
            this.txtSubTotal = new DevExpress.XtraEditors.TextEdit();
            this.lblConfirmedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblConfirmedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblReceivedBy = new DevExpress.XtraEditors.LabelControl();
            this.lblRecieptDate = new DevExpress.XtraEditors.LabelControl();
            this.lblOrderNo = new DevExpress.XtraEditors.LabelControl();
            this.lblWarehouse = new DevExpress.XtraEditors.LabelControl();
            this.lblCluster = new DevExpress.XtraEditors.LabelControl();
            this.lblActivity = new DevExpress.XtraEditors.LabelControl();
            this.lblSubAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblAccount = new DevExpress.XtraEditors.LabelControl();
            this.lblMode = new DevExpress.XtraEditors.LabelControl();
            this.lblRecieptStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblSupplier = new DevExpress.XtraEditors.LabelControl();
            this.lblReceiptType = new DevExpress.XtraEditors.LabelControl();
            this.txtOtherExpense = new DevExpress.XtraEditors.TextEdit();
            this.btnSTV = new DevExpress.XtraEditors.SimpleButton();
            this.txtSTVNo = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridCostBuild = new DevExpress.XtraGrid.GridControl();
            this.gridCostBuildUpView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCostBuildName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostBuildValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.gridPreviousBalance = new DevExpress.XtraGrid.GridControl();
            this.gridPreviousBalanceView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn49 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn65 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn64 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn52 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn58 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn59 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn60 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn61 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridFinal = new DevExpress.XtraGrid.GridControl();
            this.gridFinalView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn42 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn45 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn46 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn55 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridMovingAverage = new DevExpress.XtraGrid.GridControl();
            this.gridMovingAverageView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridUnitCost = new DevExpress.XtraGrid.GridControl();
            this.gridUnitCostView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.txtInsurance = new DevExpress.XtraEditors.TextEdit();
            this.gridInvoiceDetail = new DevExpress.XtraGrid.GridControl();
            this.gridInvoiceDetailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtInvoiceCost = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lkAccount = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn96 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn97 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn98 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem32 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem33 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup9 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup8 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.Accounts = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem36 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem10 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.NoSelection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.NoSelectCaption = new DevExpress.XtraLayout.SimpleLabelItem();
            this.Selection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.tabContralGRVDetail = new DevExpress.XtraLayout.TabbedControlGroup();
            this.grpTabInvoiceValue = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutInsurance = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcReturnForEdit = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem8 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem7 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutSTVNo = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem19 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem22 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grpTabUnitCost = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem11 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem12 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.grpTabMovingAverage = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grpTabFinalize = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.headerSection = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lgMode = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem26 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem20 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem23 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem27 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem24 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem25 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem29 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem21 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lgReceiptType = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem34 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem35 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem31 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem30 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem9 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dxValidationStep1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.layoutControlGroup13 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup11 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink(this.components);
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem47 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem69 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem70 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem71 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem77 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup6 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.dxValidationProvider2 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.layoutControlItem17 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridGRVs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGRVsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditReceivingCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPalletLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrandTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherExpense.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTVNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCostBuild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCostBuildUpView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreviousBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreviousBalanceView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinalView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovingAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovingAverageView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnitCostView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoSelectCaption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Selection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabContralGRVDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabInvoiceValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutInsurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcReturnForEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSTVNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabMovingAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabFinalize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerSection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgReceiptType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationStep1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink2.ImageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem69)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem70)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem71)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem77)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).BeginInit();
            this.SuspendLayout();
            // 
            // gridGRVs
            // 
            this.gridGRVs.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridGRVs.Location = new System.Drawing.Point(13, 94);
            this.gridGRVs.MainView = this.gridGRVsView;
            this.gridGRVs.Name = "gridGRVs";
            this.gridGRVs.Size = new System.Drawing.Size(265, 479);
            this.gridGRVs.TabIndex = 0;
            this.gridGRVs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridGRVsView});
            this.gridGRVs.Click += new System.EventHandler(this.gridGRVs_Click);
            // 
            // gridGRVsView
            // 
            this.gridGRVsView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colInvoiceNumber,
            this.colReceiptID,
            this.colPGRV,
            this.colSupplierName,
            this.colID,
            this.Account,
            this.gridColumn66});
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
            this.gridGRVsView.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
            this.gridGRVsView.GridControl = this.gridGRVs;
            this.gridGRVsView.GroupCount = 1;
            this.gridGRVsView.Name = "gridGRVsView";
            this.gridGRVsView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridGRVsView.OptionsCustomization.AllowColumnMoving = false;
            this.gridGRVsView.OptionsCustomization.AllowColumnResizing = false;
            this.gridGRVsView.OptionsMenu.EnableColumnMenu = false;
            this.gridGRVsView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridGRVsView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridGRVsView.OptionsView.ShowGroupPanel = false;
            this.gridGRVsView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colInvoiceNumber, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colInvoiceNumber
            // 
            this.colInvoiceNumber.Caption = "Invoice No";
            this.colInvoiceNumber.FieldName = "InvoiceNumber";
            this.colInvoiceNumber.Name = "colInvoiceNumber";
            this.colInvoiceNumber.OptionsColumn.AllowEdit = false;
            this.colInvoiceNumber.OptionsColumn.AllowFocus = false;
            this.colInvoiceNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNumber.OptionsColumn.AllowIncrementalSearch = false;
            this.colInvoiceNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNumber.OptionsColumn.AllowMove = false;
            this.colInvoiceNumber.OptionsColumn.AllowShowHide = false;
            this.colInvoiceNumber.OptionsColumn.AllowSize = false;
            this.colInvoiceNumber.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNumber.OptionsColumn.FixedWidth = true;
            this.colInvoiceNumber.OptionsColumn.ReadOnly = true;
            this.colInvoiceNumber.OptionsFilter.AllowAutoFilter = false;
            this.colInvoiceNumber.OptionsFilter.AllowFilter = false;
            this.colInvoiceNumber.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNumber.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colInvoiceNumber.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colReceiptID
            // 
            this.colReceiptID.Caption = "pGRV";
            this.colReceiptID.FieldName = "ReceiptID";
            this.colReceiptID.Name = "colReceiptID";
            this.colReceiptID.OptionsColumn.AllowEdit = false;
            this.colReceiptID.OptionsColumn.AllowFocus = false;
            this.colReceiptID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colReceiptID.OptionsColumn.AllowIncrementalSearch = false;
            this.colReceiptID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colReceiptID.OptionsColumn.AllowMove = false;
            this.colReceiptID.OptionsColumn.AllowShowHide = false;
            this.colReceiptID.OptionsColumn.AllowSize = false;
            this.colReceiptID.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colReceiptID.OptionsColumn.FixedWidth = true;
            this.colReceiptID.OptionsColumn.ReadOnly = true;
            this.colReceiptID.OptionsFilter.AllowAutoFilter = false;
            this.colReceiptID.OptionsFilter.AllowFilter = false;
            this.colReceiptID.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colReceiptID.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colReceiptID.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // colPGRV
            // 
            this.colPGRV.Caption = "GRNF";
            this.colPGRV.DisplayFormat.FormatString = "00000";
            this.colPGRV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colPGRV.FieldName = "RefNo";
            this.colPGRV.Name = "colPGRV";
            this.colPGRV.OptionsColumn.AllowEdit = false;
            this.colPGRV.OptionsColumn.AllowFocus = false;
            this.colPGRV.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPGRV.OptionsColumn.AllowIncrementalSearch = false;
            this.colPGRV.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colPGRV.OptionsColumn.AllowMove = false;
            this.colPGRV.OptionsColumn.AllowShowHide = false;
            this.colPGRV.OptionsColumn.AllowSize = false;
            this.colPGRV.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPGRV.OptionsColumn.FixedWidth = true;
            this.colPGRV.OptionsColumn.ReadOnly = true;
            this.colPGRV.OptionsFilter.AllowAutoFilter = false;
            this.colPGRV.OptionsFilter.AllowFilter = false;
            this.colPGRV.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colPGRV.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colPGRV.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colPGRV.Visible = true;
            this.colPGRV.VisibleIndex = 0;
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
            this.colSupplierName.OptionsColumn.FixedWidth = true;
            this.colSupplierName.OptionsColumn.ReadOnly = true;
            this.colSupplierName.OptionsFilter.AllowAutoFilter = false;
            this.colSupplierName.OptionsFilter.AllowFilter = false;
            this.colSupplierName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colSupplierName.OptionsFilter.ImmediateUpdateAutoFilter = false;
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
            this.colID.OptionsColumn.FixedWidth = true;
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.OptionsFilter.AllowAutoFilter = false;
            this.colID.OptionsFilter.AllowFilter = false;
            this.colID.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colID.OptionsFilter.ImmediateUpdateAutoFilter = false;
            // 
            // Account
            // 
            this.Account.Caption = "Activity";
            this.Account.FieldName = "StoreGroup";
            this.Account.Name = "Account";
            // 
            // gridColumn66
            // 
            this.gridColumn66.Caption = "gridColumn66";
            this.gridColumn66.FieldName = "StoreID";
            this.gridColumn66.Name = "gridColumn66";
            // 
            // textEditReceivingCost
            // 
            this.textEditReceivingCost.AutoHeight = false;
            this.textEditReceivingCost.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.textEditReceivingCost.Mask.EditMask = "###,###,##0.#0";
            this.textEditReceivingCost.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditReceivingCost.Name = "textEditReceivingCost";
            // 
            // lkPalletLocations
            // 
            this.lkPalletLocations.AutoHeight = false;
            this.lkPalletLocations.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkPalletLocations.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PalletLocationName", "PalletLocationName")});
            this.lkPalletLocations.DisplayMember = "PalletLocationName";
            this.lkPalletLocations.Name = "lkPalletLocations";
            this.lkPalletLocations.ValueMember = "ID";
            // 
            // textEditMargin
            // 
            this.textEditMargin.AutoHeight = false;
            this.textEditMargin.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
            this.textEditMargin.Mask.EditMask = "p2";
            this.textEditMargin.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditMargin.Mask.SaveLiteral = false;
            this.textEditMargin.Mask.UseMaskAsDisplayFormat = true;
            this.textEditMargin.Name = "textEditMargin";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.lblSubTotal);
            this.layoutControl1.Controls.Add(this.lblGrandTotal);
            this.layoutControl1.Controls.Add(this.btnNext);
            this.layoutControl1.Controls.Add(this.textEdit1);
            this.layoutControl1.Controls.Add(this.lblInsurance);
            this.layoutControl1.Controls.Add(this.lblAmount);
            this.layoutControl1.Controls.Add(this.txtGrandTotal);
            this.layoutControl1.Controls.Add(this.txtSubTotal);
            this.layoutControl1.Controls.Add(this.lblConfirmedDate);
            this.layoutControl1.Controls.Add(this.lblConfirmedBy);
            this.layoutControl1.Controls.Add(this.lblReceivedBy);
            this.layoutControl1.Controls.Add(this.lblRecieptDate);
            this.layoutControl1.Controls.Add(this.lblOrderNo);
            this.layoutControl1.Controls.Add(this.lblWarehouse);
            this.layoutControl1.Controls.Add(this.lblCluster);
            this.layoutControl1.Controls.Add(this.lblActivity);
            this.layoutControl1.Controls.Add(this.lblSubAccount);
            this.layoutControl1.Controls.Add(this.lblAccount);
            this.layoutControl1.Controls.Add(this.lblMode);
            this.layoutControl1.Controls.Add(this.lblRecieptStatus);
            this.layoutControl1.Controls.Add(this.lblSupplier);
            this.layoutControl1.Controls.Add(this.lblReceiptType);
            this.layoutControl1.Controls.Add(this.txtOtherExpense);
            this.layoutControl1.Controls.Add(this.btnSTV);
            this.layoutControl1.Controls.Add(this.txtSTVNo);
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.gridCostBuild);
            this.layoutControl1.Controls.Add(this.gridSplitContainer1);
            this.layoutControl1.Controls.Add(this.gridFinal);
            this.layoutControl1.Controls.Add(this.gridMovingAverage);
            this.layoutControl1.Controls.Add(this.gridUnitCost);
            this.layoutControl1.Controls.Add(this.btnBack);
            this.layoutControl1.Controls.Add(this.txtInsurance);
            this.layoutControl1.Controls.Add(this.gridInvoiceDetail);
            this.layoutControl1.Controls.Add(this.lkAccount);
            this.layoutControl1.Controls.Add(this.btnReturn);
            this.layoutControl1.Controls.Add(this.gridGRVs);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem12,
            this.layoutControlItem11,
            this.layoutControlItem32,
            this.layoutControlItem33});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(243, 85, 250, 549);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1049, 586);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.Location = new System.Drawing.Point(912, 441);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(110, 20);
            this.lblSubTotal.StyleController = this.layoutControl1;
            this.lblSubTotal.TabIndex = 98;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.Location = new System.Drawing.Point(913, 513);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(109, 20);
            this.lblGrandTotal.StyleController = this.layoutControl1;
            this.lblGrandTotal.TabIndex = 97;
            // 
            // btnNext
            // 
            this.btnNext.Image = global::HCMIS.Desktop.Properties.Resources.Forward;
            this.btnNext.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(892, 549);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(142, 22);
            this.btnNext.StyleController = this.layoutControl1;
            this.btnNext.TabIndex = 72;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(53, 63);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(218, 20);
            this.textEdit1.StyleController = this.layoutControl1;
            this.textEdit1.TabIndex = 96;
            this.textEdit1.EditValueChanged += new System.EventHandler(this.textEdit1_EditValueChanged);
            // 
            // lblInsurance
            // 
            this.lblInsurance.Location = new System.Drawing.Point(724, 166);
            this.lblInsurance.Name = "lblInsurance";
            this.lblInsurance.Size = new System.Drawing.Size(22, 16);
            this.lblInsurance.StyleController = this.layoutControl1;
            this.lblInsurance.TabIndex = 93;
            // 
            // lblAmount
            // 
            this.lblAmount.Location = new System.Drawing.Point(733, 146);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(13, 16);
            this.lblAmount.StyleController = this.layoutControl1;
            this.lblAmount.TabIndex = 92;
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Location = new System.Drawing.Point(913, 496);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(109, 20);
            this.txtGrandTotal.StyleController = this.layoutControl1;
            this.txtGrandTotal.TabIndex = 75;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(913, 448);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(109, 20);
            this.txtSubTotal.StyleController = this.layoutControl1;
            this.txtSubTotal.TabIndex = 74;
            // 
            // lblConfirmedDate
            // 
            this.lblConfirmedDate.Location = new System.Drawing.Point(608, 143);
            this.lblConfirmedDate.Name = "lblConfirmedDate";
            this.lblConfirmedDate.Size = new System.Drawing.Size(56, 16);
            this.lblConfirmedDate.StyleController = this.layoutControl1;
            this.lblConfirmedDate.TabIndex = 95;
            // 
            // lblConfirmedBy
            // 
            this.lblConfirmedBy.Location = new System.Drawing.Point(606, 163);
            this.lblConfirmedBy.Name = "lblConfirmedBy";
            this.lblConfirmedBy.Size = new System.Drawing.Size(58, 16);
            this.lblConfirmedBy.StyleController = this.layoutControl1;
            this.lblConfirmedBy.TabIndex = 94;
            // 
            // lblReceivedBy
            // 
            this.lblReceivedBy.Location = new System.Drawing.Point(385, 163);
            this.lblReceivedBy.Name = "lblReceivedBy";
            this.lblReceivedBy.Size = new System.Drawing.Size(81, 16);
            this.lblReceivedBy.StyleController = this.layoutControl1;
            this.lblReceivedBy.TabIndex = 91;
            // 
            // lblRecieptDate
            // 
            this.lblRecieptDate.Location = new System.Drawing.Point(386, 143);
            this.lblRecieptDate.Name = "lblRecieptDate";
            this.lblRecieptDate.Size = new System.Drawing.Size(80, 16);
            this.lblRecieptDate.StyleController = this.layoutControl1;
            this.lblRecieptDate.TabIndex = 90;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.Location = new System.Drawing.Point(548, 79);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(479, 13);
            this.lblOrderNo.StyleController = this.layoutControl1;
            this.lblOrderNo.TabIndex = 89;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.Location = new System.Drawing.Point(551, 116);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(127, 16);
            this.lblWarehouse.StyleController = this.layoutControl1;
            this.lblWarehouse.TabIndex = 87;
            // 
            // lblCluster
            // 
            this.lblCluster.Location = new System.Drawing.Point(355, 116);
            this.lblCluster.Name = "lblCluster";
            this.lblCluster.Size = new System.Drawing.Size(120, 16);
            this.lblCluster.StyleController = this.layoutControl1;
            this.lblCluster.TabIndex = 86;
            // 
            // lblActivity
            // 
            this.lblActivity.Location = new System.Drawing.Point(930, 96);
            this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(97, 16);
            this.lblActivity.StyleController = this.layoutControl1;
            this.lblActivity.TabIndex = 85;
            // 
            // lblSubAccount
            // 
            this.lblSubAccount.Location = new System.Drawing.Point(760, 96);
            this.lblSubAccount.Name = "lblSubAccount";
            this.lblSubAccount.Size = new System.Drawing.Size(96, 16);
            this.lblSubAccount.StyleController = this.layoutControl1;
            this.lblSubAccount.TabIndex = 84;
            // 
            // lblAccount
            // 
            this.lblAccount.Location = new System.Drawing.Point(551, 96);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(127, 16);
            this.lblAccount.StyleController = this.layoutControl1;
            this.lblAccount.TabIndex = 83;
            // 
            // lblMode
            // 
            this.lblMode.Location = new System.Drawing.Point(355, 96);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(120, 16);
            this.lblMode.StyleController = this.layoutControl1;
            this.lblMode.TabIndex = 82;
            // 
            // lblRecieptStatus
            // 
            this.lblRecieptStatus.Location = new System.Drawing.Point(727, 143);
            this.lblRecieptStatus.Name = "lblRecieptStatus";
            this.lblRecieptStatus.Size = new System.Drawing.Size(122, 16);
            this.lblRecieptStatus.StyleController = this.layoutControl1;
            this.lblRecieptStatus.TabIndex = 81;
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(355, 79);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(119, 13);
            this.lblSupplier.StyleController = this.layoutControl1;
            this.lblSupplier.TabIndex = 80;
            // 
            // lblReceiptType
            // 
            this.lblReceiptType.Location = new System.Drawing.Point(728, 163);
            this.lblReceiptType.Name = "lblReceiptType";
            this.lblReceiptType.Size = new System.Drawing.Size(121, 16);
            this.lblReceiptType.StyleController = this.layoutControl1;
            this.lblReceiptType.TabIndex = 79;
            this.lblReceiptType.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtOtherExpense
            // 
            this.txtOtherExpense.Location = new System.Drawing.Point(913, 489);
            this.txtOtherExpense.Name = "txtOtherExpense";
            this.txtOtherExpense.Size = new System.Drawing.Size(109, 20);
            this.txtOtherExpense.StyleController = this.layoutControl1;
            this.txtOtherExpense.TabIndex = 73;
            this.txtOtherExpense.EditValueChanged += new System.EventHandler(this.txtOtherExpense_EditValueChanged);
            // 
            // btnSTV
            // 
            this.btnSTV.Location = new System.Drawing.Point(624, 234);
            this.btnSTV.Name = "btnSTV";
            this.btnSTV.Size = new System.Drawing.Size(39, 22);
            this.btnSTV.StyleController = this.layoutControl1;
            this.btnSTV.TabIndex = 78;
            this.btnSTV.Text = "Save";
            this.btnSTV.Click += new System.EventHandler(this.btnSTV_Click);
            // 
            // txtSTVNo
            // 
            this.txtSTVNo.Location = new System.Drawing.Point(450, 234);
            this.txtSTVNo.Name = "txtSTVNo";
            this.txtSTVNo.Size = new System.Drawing.Size(170, 20);
            this.txtSTVNo.StyleController = this.layoutControl1;
            this.txtSTVNo.TabIndex = 77;
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(880, 511);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 22);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save and Print";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridCostBuild
            // 
            this.gridCostBuild.Location = new System.Drawing.Point(730, 414);
            this.gridCostBuild.MainView = this.gridCostBuildUpView;
            this.gridCostBuild.Name = "gridCostBuild";
            this.gridCostBuild.Size = new System.Drawing.Size(292, 107);
            this.gridCostBuild.TabIndex = 76;
            this.gridCostBuild.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridCostBuildUpView});
            // 
            // gridCostBuildUpView
            // 
            this.gridCostBuildUpView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCostBuildName,
            this.colCostBuildValue});
            this.gridCostBuildUpView.GridControl = this.gridCostBuild;
            this.gridCostBuildUpView.Name = "gridCostBuildUpView";
            this.gridCostBuildUpView.OptionsView.ShowGroupPanel = false;
            this.gridCostBuildUpView.OptionsView.ShowIndicator = false;
            // 
            // colCostBuildName
            // 
            this.colCostBuildName.Caption = "Name";
            this.colCostBuildName.FieldName = "Name";
            this.colCostBuildName.Name = "colCostBuildName";
            this.colCostBuildName.OptionsColumn.AllowEdit = false;
            this.colCostBuildName.OptionsColumn.AllowFocus = false;
            this.colCostBuildName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildName.OptionsColumn.AllowIncrementalSearch = false;
            this.colCostBuildName.OptionsColumn.AllowMove = false;
            this.colCostBuildName.OptionsColumn.AllowShowHide = false;
            this.colCostBuildName.OptionsColumn.AllowSize = false;
            this.colCostBuildName.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildName.OptionsFilter.AllowAutoFilter = false;
            this.colCostBuildName.OptionsFilter.AllowFilter = false;
            this.colCostBuildName.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildName.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildName.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCostBuildName.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildName.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildName.Visible = true;
            this.colCostBuildName.VisibleIndex = 0;
            this.colCostBuildName.Width = 932;
            // 
            // colCostBuildValue
            // 
            this.colCostBuildValue.Caption = "Value";
            this.colCostBuildValue.DisplayFormat.FormatString = "#,##0.#0";
            this.colCostBuildValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCostBuildValue.FieldName = "Value";
            this.colCostBuildValue.Name = "colCostBuildValue";
            this.colCostBuildValue.OptionsColumn.AllowEdit = false;
            this.colCostBuildValue.OptionsColumn.AllowFocus = false;
            this.colCostBuildValue.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildValue.OptionsColumn.AllowIncrementalSearch = false;
            this.colCostBuildValue.OptionsColumn.AllowMove = false;
            this.colCostBuildValue.OptionsColumn.AllowShowHide = false;
            this.colCostBuildValue.OptionsColumn.AllowSize = false;
            this.colCostBuildValue.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildValue.OptionsFilter.AllowAutoFilter = false;
            this.colCostBuildValue.OptionsFilter.AllowFilter = false;
            this.colCostBuildValue.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildValue.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildValue.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colCostBuildValue.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildValue.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colCostBuildValue.Visible = true;
            this.colCostBuildValue.VisibleIndex = 1;
            this.colCostBuildValue.Width = 264;
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Grid = this.gridPreviousBalance;
            this.gridSplitContainer1.Location = new System.Drawing.Point(306, 436);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Panel1.Controls.Add(this.gridPreviousBalance);
            this.gridSplitContainer1.Panel1.Text = "Panel1";
            this.gridSplitContainer1.Panel2.Text = "Panel2";
            this.gridSplitContainer1.Size = new System.Drawing.Size(716, 97);
            this.gridSplitContainer1.TabIndex = 73;
            this.gridSplitContainer1.Text = "gridSplitContainer1";
            // 
            // gridPreviousBalance
            // 
            this.gridPreviousBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPreviousBalance.Location = new System.Drawing.Point(0, 0);
            this.gridPreviousBalance.MainView = this.gridPreviousBalanceView;
            this.gridPreviousBalance.Name = "gridPreviousBalance";
            this.gridPreviousBalance.Size = new System.Drawing.Size(716, 97);
            this.gridPreviousBalance.TabIndex = 0;
            this.gridPreviousBalance.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPreviousBalanceView,
            this.gridView1});
            // 
            // gridPreviousBalanceView
            // 
            this.gridPreviousBalanceView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn32,
            this.gridColumn34,
            this.gridColumn48,
            this.gridColumn49,
            this.gridColumn65,
            this.gridColumn64,
            this.gridColumn50,
            this.gridColumn51,
            this.gridColumn52,
            this.colActivity});
            this.gridPreviousBalanceView.GridControl = this.gridPreviousBalance;
            this.gridPreviousBalanceView.Name = "gridPreviousBalanceView";
            this.gridPreviousBalanceView.OptionsMenu.EnableFooterMenu = false;
            this.gridPreviousBalanceView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Stack Code";
            this.gridColumn32.FieldName = "StackCode";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.OptionsColumn.AllowFocus = false;
            this.gridColumn32.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn32.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsColumn.AllowMove = false;
            this.gridColumn32.OptionsColumn.AllowShowHide = false;
            this.gridColumn32.OptionsColumn.AllowSize = false;
            this.gridColumn32.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn32.OptionsFilter.AllowFilter = false;
            this.gridColumn32.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn32.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 0;
            this.gridColumn32.Width = 108;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Item";
            this.gridColumn34.FieldName = "FullItemName";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowFocus = false;
            this.gridColumn34.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn34.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsColumn.AllowMove = false;
            this.gridColumn34.OptionsColumn.AllowShowHide = false;
            this.gridColumn34.OptionsColumn.AllowSize = false;
            this.gridColumn34.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn34.OptionsFilter.AllowFilter = false;
            this.gridColumn34.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn34.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 1;
            this.gridColumn34.Width = 400;
            // 
            // gridColumn48
            // 
            this.gridColumn48.Caption = "Manufacturer";
            this.gridColumn48.FieldName = "ManufacturerName";
            this.gridColumn48.Name = "gridColumn48";
            this.gridColumn48.OptionsColumn.AllowEdit = false;
            this.gridColumn48.OptionsColumn.AllowFocus = false;
            this.gridColumn48.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn48.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsColumn.AllowMove = false;
            this.gridColumn48.OptionsColumn.AllowShowHide = false;
            this.gridColumn48.OptionsColumn.AllowSize = false;
            this.gridColumn48.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn48.OptionsFilter.AllowFilter = false;
            this.gridColumn48.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn48.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn48.Visible = true;
            this.gridColumn48.VisibleIndex = 2;
            this.gridColumn48.Width = 187;
            // 
            // gridColumn49
            // 
            this.gridColumn49.Caption = "Unit";
            this.gridColumn49.FieldName = "ItemUnitName";
            this.gridColumn49.Name = "gridColumn49";
            this.gridColumn49.OptionsColumn.AllowEdit = false;
            this.gridColumn49.OptionsColumn.AllowFocus = false;
            this.gridColumn49.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn49.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsColumn.AllowMove = false;
            this.gridColumn49.OptionsColumn.AllowShowHide = false;
            this.gridColumn49.OptionsColumn.AllowSize = false;
            this.gridColumn49.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn49.OptionsFilter.AllowFilter = false;
            this.gridColumn49.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn49.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn49.Visible = true;
            this.gridColumn49.VisibleIndex = 3;
            this.gridColumn49.Width = 85;
            // 
            // gridColumn65
            // 
            this.gridColumn65.Caption = "Expired";
            this.gridColumn65.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn65.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn65.FieldName = "ExpiredQty";
            this.gridColumn65.Name = "gridColumn65";
            this.gridColumn65.OptionsColumn.AllowEdit = false;
            this.gridColumn65.OptionsColumn.AllowFocus = false;
            this.gridColumn65.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn65.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.OptionsColumn.AllowMove = false;
            this.gridColumn65.OptionsColumn.AllowShowHide = false;
            this.gridColumn65.OptionsColumn.AllowSize = false;
            this.gridColumn65.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn65.OptionsFilter.AllowFilter = false;
            this.gridColumn65.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn65.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn65.Visible = true;
            this.gridColumn65.VisibleIndex = 4;
            // 
            // gridColumn64
            // 
            this.gridColumn64.Caption = "Damaged";
            this.gridColumn64.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn64.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn64.FieldName = "DamagedQty";
            this.gridColumn64.Name = "gridColumn64";
            this.gridColumn64.OptionsColumn.AllowEdit = false;
            this.gridColumn64.OptionsColumn.AllowFocus = false;
            this.gridColumn64.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn64.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.OptionsColumn.AllowMove = false;
            this.gridColumn64.OptionsColumn.AllowShowHide = false;
            this.gridColumn64.OptionsColumn.AllowSize = false;
            this.gridColumn64.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn64.OptionsFilter.AllowFilter = false;
            this.gridColumn64.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn64.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn64.Visible = true;
            this.gridColumn64.VisibleIndex = 5;
            // 
            // gridColumn50
            // 
            this.gridColumn50.Caption = "Previous Balance";
            this.gridColumn50.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn50.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn50.FieldName = "PreviousQty";
            this.gridColumn50.Name = "gridColumn50";
            this.gridColumn50.OptionsColumn.AllowEdit = false;
            this.gridColumn50.OptionsColumn.AllowFocus = false;
            this.gridColumn50.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn50.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsColumn.AllowMove = false;
            this.gridColumn50.OptionsColumn.AllowShowHide = false;
            this.gridColumn50.OptionsColumn.AllowSize = false;
            this.gridColumn50.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn50.OptionsFilter.AllowFilter = false;
            this.gridColumn50.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn50.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn50.Visible = true;
            this.gridColumn50.VisibleIndex = 7;
            this.gridColumn50.Width = 137;
            // 
            // gridColumn51
            // 
            this.gridColumn51.Caption = "Unit Cost";
            this.gridColumn51.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn51.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn51.FieldName = "UnitCost";
            this.gridColumn51.Name = "gridColumn51";
            this.gridColumn51.OptionsColumn.AllowEdit = false;
            this.gridColumn51.OptionsColumn.AllowFocus = false;
            this.gridColumn51.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn51.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsColumn.AllowMove = false;
            this.gridColumn51.OptionsColumn.AllowShowHide = false;
            this.gridColumn51.OptionsColumn.AllowSize = false;
            this.gridColumn51.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn51.OptionsFilter.AllowFilter = false;
            this.gridColumn51.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn51.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn51.Visible = true;
            this.gridColumn51.VisibleIndex = 6;
            this.gridColumn51.Width = 84;
            // 
            // gridColumn52
            // 
            this.gridColumn52.Caption = "Total Cost";
            this.gridColumn52.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn52.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn52.FieldName = "TotalCost";
            this.gridColumn52.Name = "gridColumn52";
            this.gridColumn52.OptionsColumn.AllowEdit = false;
            this.gridColumn52.OptionsColumn.AllowFocus = false;
            this.gridColumn52.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn52.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsColumn.AllowMove = false;
            this.gridColumn52.OptionsColumn.AllowShowHide = false;
            this.gridColumn52.OptionsColumn.AllowSize = false;
            this.gridColumn52.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn52.OptionsFilter.AllowFilter = false;
            this.gridColumn52.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn52.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn52.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn52.Visible = true;
            this.gridColumn52.VisibleIndex = 8;
            this.gridColumn52.Width = 179;
            // 
            // colActivity
            // 
            this.colActivity.Caption = "Activity";
            this.colActivity.FieldName = "Activity";
            this.colActivity.Name = "colActivity";
            this.colActivity.OptionsColumn.AllowEdit = false;
            this.colActivity.OptionsColumn.AllowFocus = false;
            this.colActivity.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colActivity.OptionsColumn.AllowIncrementalSearch = false;
            this.colActivity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colActivity.OptionsColumn.AllowMove = false;
            this.colActivity.OptionsColumn.AllowShowHide = false;
            this.colActivity.OptionsColumn.AllowSize = false;
            this.colActivity.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colActivity.OptionsFilter.AllowAutoFilter = false;
            this.colActivity.OptionsFilter.AllowFilter = false;
            this.colActivity.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.colActivity.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.colActivity.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.colActivity.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.colActivity.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.colActivity.Visible = true;
            this.colActivity.VisibleIndex = 9;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn56,
            this.gridColumn57,
            this.gridColumn58,
            this.gridColumn59,
            this.gridColumn60,
            this.gridColumn61,
            this.gridColumn62,
            this.gridColumn63});
            this.gridView1.GridControl = this.gridPreviousBalance;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn56
            // 
            this.gridColumn56.Caption = "Stack Code";
            this.gridColumn56.FieldName = "Stack Code";
            this.gridColumn56.Name = "gridColumn56";
            this.gridColumn56.Visible = true;
            this.gridColumn56.VisibleIndex = 0;
            // 
            // gridColumn57
            // 
            this.gridColumn57.Caption = "Item Name";
            this.gridColumn57.FieldName = "FullItemName";
            this.gridColumn57.Name = "gridColumn57";
            this.gridColumn57.Visible = true;
            this.gridColumn57.VisibleIndex = 1;
            // 
            // gridColumn58
            // 
            this.gridColumn58.Caption = "Manufacturer";
            this.gridColumn58.Name = "gridColumn58";
            this.gridColumn58.Visible = true;
            this.gridColumn58.VisibleIndex = 2;
            // 
            // gridColumn59
            // 
            this.gridColumn59.Caption = "gridColumn51";
            this.gridColumn59.Name = "gridColumn59";
            this.gridColumn59.Visible = true;
            this.gridColumn59.VisibleIndex = 3;
            // 
            // gridColumn60
            // 
            this.gridColumn60.Caption = "gridColumn52";
            this.gridColumn60.Name = "gridColumn60";
            this.gridColumn60.Visible = true;
            this.gridColumn60.VisibleIndex = 4;
            // 
            // gridColumn61
            // 
            this.gridColumn61.Caption = "gridColumn53";
            this.gridColumn61.Name = "gridColumn61";
            this.gridColumn61.Visible = true;
            this.gridColumn61.VisibleIndex = 5;
            // 
            // gridColumn62
            // 
            this.gridColumn62.Caption = "gridColumn54";
            this.gridColumn62.Name = "gridColumn62";
            this.gridColumn62.Visible = true;
            this.gridColumn62.VisibleIndex = 6;
            // 
            // gridColumn63
            // 
            this.gridColumn63.Caption = "gridColumn55";
            this.gridColumn63.Name = "gridColumn63";
            this.gridColumn63.Visible = true;
            this.gridColumn63.VisibleIndex = 7;
            // 
            // gridFinal
            // 
            this.gridFinal.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridFinal.Location = new System.Drawing.Point(306, 231);
            this.gridFinal.MainView = this.gridFinalView;
            this.gridFinal.Name = "gridFinal";
            this.gridFinal.Size = new System.Drawing.Size(716, 276);
            this.gridFinal.TabIndex = 72;
            this.gridFinal.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridFinalView});
            // 
            // gridFinalView
            // 
            this.gridFinalView.ColumnPanelRowHeight = 40;
            this.gridFinalView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41,
            this.gridColumn42,
            this.gridColumn43,
            this.gridColumn44,
            this.gridColumn45,
            this.gridColumn46,
            this.gridColumn47,
            this.gridColumn53,
            this.gridColumn54,
            this.gridColumn55});
            this.gridFinalView.GridControl = this.gridFinal;
            this.gridFinalView.Name = "gridFinalView";
            this.gridFinalView.OptionsMenu.EnableFooterMenu = false;
            this.gridFinalView.OptionsView.ShowFooter = true;
            this.gridFinalView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "Stack Code";
            this.gridColumn39.FieldName = "StackCode";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.OptionsColumn.AllowFocus = false;
            this.gridColumn39.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn39.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsColumn.AllowMove = false;
            this.gridColumn39.OptionsColumn.AllowShowHide = false;
            this.gridColumn39.OptionsColumn.AllowSize = false;
            this.gridColumn39.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn39.OptionsFilter.AllowFilter = false;
            this.gridColumn39.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn39.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 0;
            this.gridColumn39.Width = 98;
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "Item";
            this.gridColumn40.FieldName = "FullItemName";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.OptionsColumn.AllowFocus = false;
            this.gridColumn40.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn40.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsColumn.AllowMove = false;
            this.gridColumn40.OptionsColumn.AllowShowHide = false;
            this.gridColumn40.OptionsColumn.AllowSize = false;
            this.gridColumn40.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn40.OptionsFilter.AllowFilter = false;
            this.gridColumn40.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn40.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 1;
            this.gridColumn40.Width = 327;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "Manufacturer";
            this.gridColumn41.FieldName = "ManufacturerName";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.AllowEdit = false;
            this.gridColumn41.OptionsColumn.AllowFocus = false;
            this.gridColumn41.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn41.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsColumn.AllowMove = false;
            this.gridColumn41.OptionsColumn.AllowShowHide = false;
            this.gridColumn41.OptionsColumn.AllowSize = false;
            this.gridColumn41.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn41.OptionsFilter.AllowFilter = false;
            this.gridColumn41.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn41.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn41.Visible = true;
            this.gridColumn41.VisibleIndex = 2;
            this.gridColumn41.Width = 166;
            // 
            // gridColumn42
            // 
            this.gridColumn42.Caption = "Unit";
            this.gridColumn42.FieldName = "ItemUnitName";
            this.gridColumn42.Name = "gridColumn42";
            this.gridColumn42.OptionsColumn.AllowEdit = false;
            this.gridColumn42.OptionsColumn.AllowFocus = false;
            this.gridColumn42.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn42.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsColumn.AllowMove = false;
            this.gridColumn42.OptionsColumn.AllowShowHide = false;
            this.gridColumn42.OptionsColumn.AllowSize = false;
            this.gridColumn42.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn42.OptionsFilter.AllowFilter = false;
            this.gridColumn42.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn42.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn42.Visible = true;
            this.gridColumn42.VisibleIndex = 3;
            this.gridColumn42.Width = 50;
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "Invoice Qty";
            this.gridColumn43.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn43.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn43.FieldName = "InvoiceQty";
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.OptionsColumn.AllowEdit = false;
            this.gridColumn43.OptionsColumn.AllowFocus = false;
            this.gridColumn43.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn43.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsColumn.AllowMove = false;
            this.gridColumn43.OptionsColumn.AllowShowHide = false;
            this.gridColumn43.OptionsColumn.AllowSize = false;
            this.gridColumn43.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn43.OptionsFilter.AllowFilter = false;
            this.gridColumn43.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn43.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn43.Width = 88;
            // 
            // gridColumn44
            // 
            this.gridColumn44.Caption = "Received Qty";
            this.gridColumn44.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn44.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn44.FieldName = "ReceivedQty";
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.OptionsColumn.AllowEdit = false;
            this.gridColumn44.OptionsColumn.AllowFocus = false;
            this.gridColumn44.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn44.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsColumn.AllowMove = false;
            this.gridColumn44.OptionsColumn.AllowShowHide = false;
            this.gridColumn44.OptionsColumn.AllowSize = false;
            this.gridColumn44.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn44.OptionsFilter.AllowFilter = false;
            this.gridColumn44.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn44.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn44.Visible = true;
            this.gridColumn44.VisibleIndex = 4;
            this.gridColumn44.Width = 63;
            // 
            // gridColumn45
            // 
            this.gridColumn45.Caption = "Invoice Value";
            this.gridColumn45.FieldName = "InvoiceCost";
            this.gridColumn45.Name = "gridColumn45";
            this.gridColumn45.OptionsColumn.AllowEdit = false;
            this.gridColumn45.OptionsColumn.AllowFocus = false;
            this.gridColumn45.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn45.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.OptionsColumn.AllowMove = false;
            this.gridColumn45.OptionsColumn.AllowShowHide = false;
            this.gridColumn45.OptionsColumn.AllowSize = false;
            this.gridColumn45.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn45.OptionsFilter.AllowFilter = false;
            this.gridColumn45.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn45.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn45.Width = 76;
            // 
            // gridColumn46
            // 
            this.gridColumn46.Caption = "Unit Cost";
            this.gridColumn46.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn46.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn46.FieldName = "UnitCost";
            this.gridColumn46.Name = "gridColumn46";
            this.gridColumn46.OptionsColumn.AllowEdit = false;
            this.gridColumn46.OptionsColumn.AllowFocus = false;
            this.gridColumn46.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn46.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsColumn.AllowMove = false;
            this.gridColumn46.OptionsColumn.AllowShowHide = false;
            this.gridColumn46.OptionsColumn.AllowSize = false;
            this.gridColumn46.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn46.OptionsFilter.AllowFilter = false;
            this.gridColumn46.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn46.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn46.Visible = true;
            this.gridColumn46.VisibleIndex = 5;
            this.gridColumn46.Width = 55;
            // 
            // gridColumn47
            // 
            this.gridColumn47.Caption = "Total Cost";
            this.gridColumn47.DisplayFormat.FormatString = "#,##0.#0 ";
            this.gridColumn47.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn47.FieldName = "TotalCost";
            this.gridColumn47.Name = "gridColumn47";
            this.gridColumn47.OptionsColumn.AllowEdit = false;
            this.gridColumn47.OptionsColumn.AllowFocus = false;
            this.gridColumn47.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn47.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsColumn.AllowMove = false;
            this.gridColumn47.OptionsColumn.AllowShowHide = false;
            this.gridColumn47.OptionsColumn.AllowSize = false;
            this.gridColumn47.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn47.OptionsFilter.AllowFilter = false;
            this.gridColumn47.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn47.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn47.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", "{0:c2}")});
            this.gridColumn47.Visible = true;
            this.gridColumn47.VisibleIndex = 6;
            this.gridColumn47.Width = 69;
            // 
            // gridColumn53
            // 
            this.gridColumn53.Caption = "Average Cost";
            this.gridColumn53.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn53.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn53.FieldName = "AverageCost";
            this.gridColumn53.Name = "gridColumn53";
            this.gridColumn53.OptionsColumn.AllowEdit = false;
            this.gridColumn53.OptionsColumn.AllowFocus = false;
            this.gridColumn53.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn53.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsColumn.AllowMove = false;
            this.gridColumn53.OptionsColumn.AllowShowHide = false;
            this.gridColumn53.OptionsColumn.AllowSize = false;
            this.gridColumn53.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn53.OptionsFilter.AllowFilter = false;
            this.gridColumn53.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn53.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn53.Visible = true;
            this.gridColumn53.VisibleIndex = 7;
            this.gridColumn53.Width = 51;
            // 
            // gridColumn54
            // 
            this.gridColumn54.Caption = "Margin";
            this.gridColumn54.DisplayFormat.FormatString = "#,##0.## %";
            this.gridColumn54.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn54.FieldName = "Margin";
            this.gridColumn54.Name = "gridColumn54";
            this.gridColumn54.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn54.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsColumn.AllowMove = false;
            this.gridColumn54.OptionsColumn.AllowShowHide = false;
            this.gridColumn54.OptionsColumn.AllowSize = false;
            this.gridColumn54.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn54.OptionsFilter.AllowFilter = false;
            this.gridColumn54.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn54.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn54.Visible = true;
            this.gridColumn54.VisibleIndex = 8;
            this.gridColumn54.Width = 40;
            // 
            // gridColumn55
            // 
            this.gridColumn55.Caption = "Selling Price";
            this.gridColumn55.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn55.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn55.FieldName = "SellingPrice";
            this.gridColumn55.Name = "gridColumn55";
            this.gridColumn55.OptionsColumn.AllowEdit = false;
            this.gridColumn55.OptionsColumn.AllowFocus = false;
            this.gridColumn55.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn55.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsColumn.AllowMove = false;
            this.gridColumn55.OptionsColumn.AllowShowHide = false;
            this.gridColumn55.OptionsColumn.AllowSize = false;
            this.gridColumn55.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn55.OptionsFilter.AllowFilter = false;
            this.gridColumn55.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn55.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn55.Visible = true;
            this.gridColumn55.VisibleIndex = 9;
            this.gridColumn55.Width = 97;
            // 
            // gridMovingAverage
            // 
            this.gridMovingAverage.Location = new System.Drawing.Point(306, 231);
            this.gridMovingAverage.MainView = this.gridMovingAverageView;
            this.gridMovingAverage.Name = "gridMovingAverage";
            this.gridMovingAverage.Size = new System.Drawing.Size(716, 185);
            this.gridMovingAverage.TabIndex = 72;
            this.gridMovingAverage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMovingAverageView,
            this.gridView2});
            // 
            // gridMovingAverageView
            // 
            this.gridMovingAverageView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn33,
            this.gridColumn36,
            this.gridColumn38});
            this.gridMovingAverageView.GridControl = this.gridMovingAverage;
            this.gridMovingAverageView.Name = "gridMovingAverageView";
            this.gridMovingAverageView.OptionsMenu.EnableFooterMenu = false;
            this.gridMovingAverageView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Stack Code";
            this.gridColumn28.FieldName = "StackCode";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowFocus = false;
            this.gridColumn28.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn28.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsColumn.AllowMove = false;
            this.gridColumn28.OptionsColumn.AllowShowHide = false;
            this.gridColumn28.OptionsColumn.AllowSize = false;
            this.gridColumn28.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn28.OptionsFilter.AllowFilter = false;
            this.gridColumn28.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn28.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 0;
            this.gridColumn28.Width = 108;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Item";
            this.gridColumn29.FieldName = "FullItemName";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.AllowFocus = false;
            this.gridColumn29.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn29.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsColumn.AllowMove = false;
            this.gridColumn29.OptionsColumn.AllowShowHide = false;
            this.gridColumn29.OptionsColumn.AllowSize = false;
            this.gridColumn29.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsColumn.ReadOnly = true;
            this.gridColumn29.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn29.OptionsFilter.AllowFilter = false;
            this.gridColumn29.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn29.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 1;
            this.gridColumn29.Width = 400;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Manufacturer";
            this.gridColumn30.FieldName = "ManufacturerName";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.AllowFocus = false;
            this.gridColumn30.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn30.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsColumn.AllowMove = false;
            this.gridColumn30.OptionsColumn.AllowShowHide = false;
            this.gridColumn30.OptionsColumn.AllowSize = false;
            this.gridColumn30.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsColumn.ReadOnly = true;
            this.gridColumn30.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn30.OptionsFilter.AllowFilter = false;
            this.gridColumn30.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn30.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 2;
            this.gridColumn30.Width = 187;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Unit";
            this.gridColumn31.FieldName = "ItemUnitName";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsColumn.AllowFocus = false;
            this.gridColumn31.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn31.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsColumn.AllowMove = false;
            this.gridColumn31.OptionsColumn.AllowShowHide = false;
            this.gridColumn31.OptionsColumn.AllowSize = false;
            this.gridColumn31.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsColumn.ReadOnly = true;
            this.gridColumn31.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn31.OptionsFilter.AllowFilter = false;
            this.gridColumn31.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn31.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 3;
            this.gridColumn31.Width = 85;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Received Qty";
            this.gridColumn33.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn33.FieldName = "ReceivedQty";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            this.gridColumn33.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn33.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsColumn.AllowMove = false;
            this.gridColumn33.OptionsColumn.AllowShowHide = false;
            this.gridColumn33.OptionsColumn.AllowSize = false;
            this.gridColumn33.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsColumn.ReadOnly = true;
            this.gridColumn33.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn33.OptionsFilter.AllowFilter = false;
            this.gridColumn33.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn33.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 4;
            this.gridColumn33.Width = 137;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Unit Cost";
            this.gridColumn36.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn36.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn36.FieldName = "UnitCost";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            this.gridColumn36.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn36.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.AllowMove = false;
            this.gridColumn36.OptionsColumn.AllowShowHide = false;
            this.gridColumn36.OptionsColumn.AllowSize = false;
            this.gridColumn36.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsColumn.ReadOnly = true;
            this.gridColumn36.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn36.OptionsFilter.AllowFilter = false;
            this.gridColumn36.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn36.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 5;
            this.gridColumn36.Width = 84;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "Total Cost";
            this.gridColumn38.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn38.FieldName = "TotalCost";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.AllowFocus = false;
            this.gridColumn38.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn38.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsColumn.AllowMove = false;
            this.gridColumn38.OptionsColumn.AllowShowHide = false;
            this.gridColumn38.OptionsColumn.AllowSize = false;
            this.gridColumn38.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsColumn.ReadOnly = true;
            this.gridColumn38.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn38.OptionsFilter.AllowFilter = false;
            this.gridColumn38.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn38.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn38.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 6;
            this.gridColumn38.Width = 179;
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27});
            this.gridView2.GridControl = this.gridMovingAverage;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsMenu.EnableFooterMenu = false;
            this.gridView2.OptionsView.ShowFooter = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Stack Code";
            this.gridColumn19.FieldName = "StackCode";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            this.gridColumn19.Width = 94;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Item Name";
            this.gridColumn20.FieldName = "FullItemName";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 1;
            this.gridColumn20.Width = 391;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Manufacturer";
            this.gridColumn21.FieldName = "ManufacturerName";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 2;
            this.gridColumn21.Width = 190;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Unit";
            this.gridColumn22.FieldName = "ItemUnitName";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 3;
            this.gridColumn22.Width = 80;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Invoice Qty";
            this.gridColumn23.FieldName = "InvoiceQty";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 4;
            this.gridColumn23.Width = 66;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Received Qty";
            this.gridColumn24.FieldName = "ReceivedQty";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 5;
            this.gridColumn24.Width = 72;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Invoice Value";
            this.gridColumn25.FieldName = "InvoiceCost";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 6;
            this.gridColumn25.Width = 90;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Unit Cost";
            this.gridColumn26.DisplayFormat.FormatString = "###,###,##0.#0";
            this.gridColumn26.FieldName = "UnitCost";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 7;
            this.gridColumn26.Width = 93;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Total Cost";
            this.gridColumn27.DisplayFormat.FormatString = "###,###,##0.#0";
            this.gridColumn27.FieldName = "TotalCost";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", "###,###,##0.#0")});
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 8;
            this.gridColumn27.Width = 104;
            // 
            // gridUnitCost
            // 
            this.gridUnitCost.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridUnitCost.Location = new System.Drawing.Point(306, 231);
            this.gridUnitCost.MainView = this.gridUnitCostView;
            this.gridUnitCost.Name = "gridUnitCost";
            this.gridUnitCost.Size = new System.Drawing.Size(716, 158);
            this.gridUnitCost.TabIndex = 71;
            this.gridUnitCost.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridUnitCostView});
            // 
            // gridUnitCostView
            // 
            this.gridUnitCostView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn18,
            this.gridColumn16,
            this.gridColumn17});
            this.gridUnitCostView.GridControl = this.gridUnitCost;
            this.gridUnitCostView.Name = "gridUnitCostView";
            this.gridUnitCostView.OptionsMenu.EnableFooterMenu = false;
            this.gridUnitCostView.OptionsView.ShowFooter = true;
            this.gridUnitCostView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Stack Code";
            this.gridColumn10.FieldName = "StackCode";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn10.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsColumn.AllowMove = false;
            this.gridColumn10.OptionsColumn.AllowShowHide = false;
            this.gridColumn10.OptionsColumn.AllowSize = false;
            this.gridColumn10.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn10.OptionsFilter.AllowFilter = false;
            this.gridColumn10.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn10.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 94;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Item";
            this.gridColumn11.FieldName = "FullItemName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn11.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsColumn.AllowMove = false;
            this.gridColumn11.OptionsColumn.AllowShowHide = false;
            this.gridColumn11.OptionsColumn.AllowSize = false;
            this.gridColumn11.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn11.OptionsFilter.AllowFilter = false;
            this.gridColumn11.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn11.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            this.gridColumn11.Width = 391;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Manufacturer";
            this.gridColumn12.FieldName = "ManufacturerName";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn12.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsColumn.AllowMove = false;
            this.gridColumn12.OptionsColumn.AllowShowHide = false;
            this.gridColumn12.OptionsColumn.AllowSize = false;
            this.gridColumn12.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn12.OptionsFilter.AllowFilter = false;
            this.gridColumn12.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn12.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 190;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Unit";
            this.gridColumn13.FieldName = "ItemUnitName";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn13.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.AllowShowHide = false;
            this.gridColumn13.OptionsColumn.AllowSize = false;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn13.OptionsFilter.AllowFilter = false;
            this.gridColumn13.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn13.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            this.gridColumn13.Width = 80;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Invoice Qty";
            this.gridColumn14.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "InvoiceQty";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn14.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.AllowMove = false;
            this.gridColumn14.OptionsColumn.AllowShowHide = false;
            this.gridColumn14.OptionsColumn.AllowSize = false;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn14.OptionsFilter.AllowFilter = false;
            this.gridColumn14.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn14.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 4;
            this.gridColumn14.Width = 66;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Received Qty";
            this.gridColumn15.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "ReceivedQty";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn15.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsColumn.AllowMove = false;
            this.gridColumn15.OptionsColumn.AllowShowHide = false;
            this.gridColumn15.OptionsColumn.AllowSize = false;
            this.gridColumn15.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn15.OptionsFilter.AllowFilter = false;
            this.gridColumn15.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn15.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            this.gridColumn15.Width = 72;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Invoice Value";
            this.gridColumn18.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn18.FieldName = "InvoiceCost";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn18.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsColumn.AllowMove = false;
            this.gridColumn18.OptionsColumn.AllowShowHide = false;
            this.gridColumn18.OptionsColumn.AllowSize = false;
            this.gridColumn18.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn18.OptionsFilter.AllowFilter = false;
            this.gridColumn18.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn18.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 6;
            this.gridColumn18.Width = 90;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Unit Cost";
            this.gridColumn16.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "UnitCost";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn16.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsColumn.AllowMove = false;
            this.gridColumn16.OptionsColumn.AllowShowHide = false;
            this.gridColumn16.OptionsColumn.AllowSize = false;
            this.gridColumn16.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn16.OptionsFilter.AllowFilter = false;
            this.gridColumn16.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn16.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 7;
            this.gridColumn16.Width = 93;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Total Cost";
            this.gridColumn17.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "TotalCost";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn17.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsColumn.AllowMove = false;
            this.gridColumn17.OptionsColumn.AllowShowHide = false;
            this.gridColumn17.OptionsColumn.AllowSize = false;
            this.gridColumn17.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn17.OptionsFilter.AllowFilter = false;
            this.gridColumn17.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn17.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn17.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 8;
            this.gridColumn17.Width = 104;
            // 
            // btnBack
            // 
            this.btnBack.Image = global::HCMIS.Desktop.Properties.Resources.Back1;
            this.btnBack.Location = new System.Drawing.Point(294, 549);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(142, 22);
            this.btnBack.StyleController = this.layoutControl1;
            this.btnBack.TabIndex = 72;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtInsurance
            // 
            this.txtInsurance.Location = new System.Drawing.Point(913, 465);
            this.txtInsurance.Name = "txtInsurance";
            this.txtInsurance.Size = new System.Drawing.Size(109, 20);
            this.txtInsurance.StyleController = this.layoutControl1;
            this.txtInsurance.TabIndex = 72;
            this.txtInsurance.EditValueChanged += new System.EventHandler(this.txtInsurance_EditValueChanged);
            // 
            // gridInvoiceDetail
            // 
            this.gridInvoiceDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridInvoiceDetail.Location = new System.Drawing.Point(306, 263);
            this.gridInvoiceDetail.MainView = this.gridInvoiceDetailView;
            this.gridInvoiceDetail.Name = "gridInvoiceDetail";
            this.gridInvoiceDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.txtInvoiceCost});
            this.gridInvoiceDetail.Size = new System.Drawing.Size(716, 174);
            this.gridInvoiceDetail.TabIndex = 70;
            this.gridInvoiceDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridInvoiceDetailView});
            // 
            // gridInvoiceDetailView
            // 
            this.gridInvoiceDetailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridInvoiceDetailView.GridControl = this.gridInvoiceDetail;
            this.gridInvoiceDetailView.Name = "gridInvoiceDetailView";
            this.gridInvoiceDetailView.OptionsView.ShowGroupPanel = false;
            this.gridInvoiceDetailView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridInvoiceDetailView_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Stack Code";
            this.gridColumn1.FieldName = "StackCode";
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
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn1.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 94;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Item";
            this.gridColumn2.FieldName = "FullItemName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.AllowShowHide = false;
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn2.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 391;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Manufacturer";
            this.gridColumn3.FieldName = "ManufacturerName";
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
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn3.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 190;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Unit";
            this.gridColumn4.FieldName = "ItemUnitName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn4.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsColumn.AllowMove = false;
            this.gridColumn4.OptionsColumn.AllowShowHide = false;
            this.gridColumn4.OptionsColumn.AllowSize = false;
            this.gridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn4.OptionsFilter.AllowFilter = false;
            this.gridColumn4.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn4.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Invoice Qty";
            this.gridColumn5.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "InvoiceQty";
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
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn5.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 69;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Received Qty";
            this.gridColumn6.DisplayFormat.FormatString = "#,##0.##";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "ReceivedQty";
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
            this.gridColumn6.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn6.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            this.gridColumn6.Width = 86;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Invoice Cost";
            this.gridColumn7.ColumnEdit = this.txtInvoiceCost;
            this.gridColumn7.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "InvoiceCost";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsColumn.AllowMove = false;
            this.gridColumn7.OptionsColumn.AllowShowHide = false;
            this.gridColumn7.OptionsColumn.AllowSize = false;
            this.gridColumn7.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilter = false;
            this.gridColumn7.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn7.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 97;
            // 
            // txtInvoiceCost
            // 
            this.txtInvoiceCost.AutoHeight = false;
            this.txtInvoiceCost.DisplayFormat.FormatString = "#,##0.#0";
            this.txtInvoiceCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtInvoiceCost.Name = "txtInvoiceCost";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Total Cost";
            this.gridColumn8.DisplayFormat.FormatString = "#,##0.#0";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "TotalInvoiceCost";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsColumn.AllowMove = false;
            this.gridColumn8.OptionsColumn.AllowShowHide = false;
            this.gridColumn8.OptionsColumn.AllowSize = false;
            this.gridColumn8.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn8.OptionsFilter.AllowFilter = false;
            this.gridColumn8.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn8.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCost", "###,###,##0.#0")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Margin";
            this.gridColumn9.DisplayFormat.FormatString = "#,##0.## %";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "Margin";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowIncrementalSearch = false;
            this.gridColumn9.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.AllowShowHide = false;
            this.gridColumn9.OptionsColumn.AllowSize = false;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn9.OptionsFilter.AllowFilter = false;
            this.gridColumn9.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn9.OptionsFilter.ImmediateUpdatePopupDateFilterOnCheck = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.OptionsFilter.ImmediateUpdatePopupDateFilterOnDateChange = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 73;
            // 
            // lkAccount
            // 
            this.lkAccount.Location = new System.Drawing.Point(53, 39);
            this.lkAccount.Name = "lkAccount";
            this.lkAccount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkAccount.Properties.DisplayMember = "Name";
            this.lkAccount.Properties.NullText = "Select Account";
            this.lkAccount.Properties.ShowFooter = false;
            this.lkAccount.Properties.ValueMember = "ID";
            this.lkAccount.Properties.View = this.gridView5;
            this.lkAccount.Size = new System.Drawing.Size(218, 20);
            this.lkAccount.StyleController = this.layoutControl1;
            this.lkAccount.TabIndex = 69;
            this.lkAccount.EditValueChanged += new System.EventHandler(this.lkAccount_EditValueChanged);
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn96,
            this.gridColumn37,
            this.gridColumn97,
            this.gridColumn98});
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.GroupCount = 3;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            this.gridView5.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn37, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn97, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn96, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "ID";
            this.gridColumn35.FieldName = "ID";
            this.gridColumn35.Name = "gridColumn35";
            // 
            // gridColumn96
            // 
            this.gridColumn96.Caption = "Sub Account";
            this.gridColumn96.FieldName = "StoreGroupDivision";
            this.gridColumn96.Name = "gridColumn96";
            this.gridColumn96.Visible = true;
            this.gridColumn96.VisibleIndex = 0;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Mode";
            this.gridColumn37.FieldName = "StoreType";
            this.gridColumn37.Name = "gridColumn37";
            // 
            // gridColumn97
            // 
            this.gridColumn97.Caption = "Account";
            this.gridColumn97.FieldName = "StoreGroup";
            this.gridColumn97.Name = "gridColumn97";
            // 
            // gridColumn98
            // 
            this.gridColumn98.Caption = "SSA";
            this.gridColumn98.FieldName = "Name";
            this.gridColumn98.Name = "gridColumn98";
            this.gridColumn98.Visible = true;
            this.gridColumn98.VisibleIndex = 0;
            this.gridColumn98.Width = 83;
            // 
            // btnReturn
            // 
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.Location = new System.Drawing.Point(306, 511);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(142, 22);
            this.btnReturn.StyleController = this.layoutControl1;
            this.btnReturn.TabIndex = 16;
            this.btnReturn.Text = "Return";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.Control = this.txtGrandTotal;
            this.layoutControlItem12.CustomizationFormText = "Grand Total";
            this.layoutControlItem12.Location = new System.Drawing.Point(527, 262);
            this.layoutControlItem12.MaxSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem12.MinSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(193, 24);
            this.layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem12.Text = "Grand Total";
            this.layoutControlItem12.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem12.TextSize = new System.Drawing.Size(75, 0);
            this.layoutControlItem12.TextToControlDistance = 5;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.Control = this.txtSubTotal;
            this.layoutControlItem11.CustomizationFormText = "Sub Total";
            this.layoutControlItem11.Location = new System.Drawing.Point(527, 214);
            this.layoutControlItem11.MaxSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem11.MinSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(193, 24);
            this.layoutControlItem11.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem11.Text = "Sub Total";
            this.layoutControlItem11.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem11.TextSize = new System.Drawing.Size(75, 20);
            this.layoutControlItem11.TextToControlDistance = 5;
            // 
            // layoutControlItem32
            // 
            this.layoutControlItem32.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem32.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem32.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem32.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem32.Control = this.lblAmount;
            this.layoutControlItem32.CustomizationFormText = "Amount:";
            this.layoutControlItem32.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem32.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem32.MinSize = new System.Drawing.Size(73, 20);
            this.layoutControlItem32.Name = "layoutControlItem32";
            this.layoutControlItem32.Size = new System.Drawing.Size(91, 20);
            this.layoutControlItem32.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem32.Text = "Grand Total:";
            this.layoutControlItem32.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem32.TextSize = new System.Drawing.Size(69, 13);
            this.layoutControlItem32.TextToControlDistance = 5;
            // 
            // layoutControlItem33
            // 
            this.layoutControlItem33.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem33.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem33.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem33.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem33.Control = this.lblInsurance;
            this.layoutControlItem33.CustomizationFormText = "Insurance:";
            this.layoutControlItem33.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem33.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem33.MinSize = new System.Drawing.Size(69, 20);
            this.layoutControlItem33.Name = "layoutControlItem33";
            this.layoutControlItem33.Size = new System.Drawing.Size(91, 20);
            this.layoutControlItem33.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem33.Text = "Insurance:";
            this.layoutControlItem33.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem33.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem33.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup9,
            this.NoSelection,
            this.Selection});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1049, 586);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup9
            // 
            this.layoutControlGroup9.CustomizationFormText = "Select New Receipt";
            this.layoutControlGroup9.DefaultLayoutType = DevExpress.XtraLayout.Utils.LayoutType.Horizontal;
            this.layoutControlGroup9.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup9.ExpandButtonMode = DevExpress.Utils.Controls.ExpandButtonMode.Inverted;
            this.layoutControlGroup9.ExpandOnDoubleClick = true;
            this.layoutControlGroup9.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlGroup8,
            this.emptySpaceItem10});
            this.layoutControlGroup9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup9.Name = "layoutControlGroup9";
            this.layoutControlGroup9.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup9.Size = new System.Drawing.Size(279, 566);
            this.layoutControlGroup9.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup9.Text = "Select New Receipt";
            this.layoutControlGroup9.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlGroup9.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridGRVs;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 81);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(269, 483);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup8
            // 
            this.layoutControlGroup8.CustomizationFormText = "Filter";
            this.layoutControlGroup8.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.Accounts,
            this.layoutControlItem36});
            this.layoutControlGroup8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup8.Name = "layoutControlGroup8";
            this.layoutControlGroup8.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup8.Size = new System.Drawing.Size(269, 81);
            this.layoutControlGroup8.Text = "Filter";
            // 
            // Accounts
            // 
            this.Accounts.Control = this.lkAccount;
            this.Accounts.CustomizationFormText = "Accounts";
            this.Accounts.Location = new System.Drawing.Point(0, 0);
            this.Accounts.Name = "Accounts";
            this.Accounts.Size = new System.Drawing.Size(255, 24);
            this.Accounts.Text = "Mode:";
            this.Accounts.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.Accounts.TextSize = new System.Drawing.Size(30, 13);
            this.Accounts.TextToControlDistance = 3;
            // 
            // layoutControlItem36
            // 
            this.layoutControlItem36.Control = this.textEdit1;
            this.layoutControlItem36.CustomizationFormText = "Filter:";
            this.layoutControlItem36.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem36.Name = "layoutControlItem36";
            this.layoutControlItem36.Size = new System.Drawing.Size(255, 24);
            this.layoutControlItem36.Text = "Filter:";
            this.layoutControlItem36.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem36.TextSize = new System.Drawing.Size(28, 13);
            this.layoutControlItem36.TextToControlDistance = 5;
            // 
            // emptySpaceItem10
            // 
            this.emptySpaceItem10.AllowHotTrack = false;
            this.emptySpaceItem10.CustomizationFormText = "emptySpaceItem10";
            this.emptySpaceItem10.Location = new System.Drawing.Point(269, 0);
            this.emptySpaceItem10.MinSize = new System.Drawing.Size(8, 10);
            this.emptySpaceItem10.Name = "emptySpaceItem10";
            this.emptySpaceItem10.Size = new System.Drawing.Size(8, 564);
            this.emptySpaceItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem10.Text = "emptySpaceItem10";
            this.emptySpaceItem10.TextSize = new System.Drawing.Size(0, 0);
            // 
            // NoSelection
            // 
            this.NoSelection.CustomizationFormText = "NoSelection";
            this.NoSelection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.NoSelectCaption});
            this.NoSelection.Location = new System.Drawing.Point(279, 0);
            this.NoSelection.Name = "NoSelection";
            this.NoSelection.Size = new System.Drawing.Size(750, 41);
            this.NoSelection.Text = "NoSelection";
            this.NoSelection.TextVisible = false;
            this.NoSelection.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // NoSelectCaption
            // 
            this.NoSelectCaption.AllowHotTrack = false;
            this.NoSelectCaption.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoSelectCaption.AppearanceItemCaption.Options.UseFont = true;
            this.NoSelectCaption.AppearanceItemCaption.Options.UseTextOptions = true;
            this.NoSelectCaption.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NoSelectCaption.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.NoSelectCaption.CustomizationFormText = "Select GRNF For Costing";
            this.NoSelectCaption.Location = new System.Drawing.Point(0, 0);
            this.NoSelectCaption.MinSize = new System.Drawing.Size(137, 17);
            this.NoSelectCaption.Name = "NoSelectCaption";
            this.NoSelectCaption.Size = new System.Drawing.Size(726, 17);
            this.NoSelectCaption.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.NoSelectCaption.Text = "Select GRNF For Costing";
            this.NoSelectCaption.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.NoSelectCaption.TextSize = new System.Drawing.Size(133, 13);
            // 
            // Selection
            // 
            this.Selection.CustomizationFormText = "Selection";
            this.Selection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.tabContralGRVDetail,
            this.layoutControlItem10,
            this.headerSection,
            this.layoutControlItem3,
            this.emptySpaceItem2});
            this.Selection.Location = new System.Drawing.Point(279, 41);
            this.Selection.Name = "Selection";
            this.Selection.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Selection.Size = new System.Drawing.Size(750, 525);
            this.Selection.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, -1, 2);
            this.Selection.Text = "Selection";
            this.Selection.TextVisible = false;
            // 
            // tabContralGRVDetail
            // 
            this.tabContralGRVDetail.CustomizationFormText = "tabbedControlGroup1";
            this.tabContralGRVDetail.Location = new System.Drawing.Point(0, 144);
            this.tabContralGRVDetail.MultiLine = DevExpress.Utils.DefaultBoolean.True;
            this.tabContralGRVDetail.Name = "tabContralGRVDetail";
            this.tabContralGRVDetail.SelectedTabPage = this.grpTabInvoiceValue;
            this.tabContralGRVDetail.SelectedTabPageIndex = 0;
            this.tabContralGRVDetail.Size = new System.Drawing.Size(744, 352);
            this.tabContralGRVDetail.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.grpTabInvoiceValue,
            this.grpTabUnitCost,
            this.grpTabMovingAverage,
            this.grpTabFinalize});
            this.tabContralGRVDetail.Text = "tabContralGRVDetail";
            this.tabContralGRVDetail.SelectedPageChanged += new DevExpress.XtraLayout.LayoutTabPageChangedEventHandler(this.tabContralGRVDetail_SelectedPageChanged);
            // 
            // grpTabInvoiceValue
            // 
            this.grpTabInvoiceValue.CustomizationFormText = "Invoice Value";
            this.grpTabInvoiceValue.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutInsurance,
            this.lcReturnForEdit,
            this.emptySpaceItem8,
            this.emptySpaceItem7,
            this.layoutSTVNo,
            this.layoutControlItem18,
            this.layoutControlItem19,
            this.layoutControlItem22});
            this.grpTabInvoiceValue.Location = new System.Drawing.Point(0, 0);
            this.grpTabInvoiceValue.Name = "grpTabInvoiceValue";
            this.grpTabInvoiceValue.Size = new System.Drawing.Size(720, 306);
            this.grpTabInvoiceValue.Text = "Step 1: Enter Invoice Value";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridInvoiceDetail;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 32);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(720, 178);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutInsurance
            // 
            this.layoutInsurance.Control = this.txtInsurance;
            this.layoutInsurance.CustomizationFormText = "Insurance";
            this.layoutInsurance.Location = new System.Drawing.Point(527, 234);
            this.layoutInsurance.MaxSize = new System.Drawing.Size(193, 24);
            this.layoutInsurance.MinSize = new System.Drawing.Size(193, 24);
            this.layoutInsurance.Name = "layoutInsurance";
            this.layoutInsurance.Size = new System.Drawing.Size(193, 24);
            this.layoutInsurance.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutInsurance.Text = "Insurance";
            this.layoutInsurance.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutInsurance.TextSize = new System.Drawing.Size(75, 13);
            this.layoutInsurance.TextToControlDistance = 5;
            // 
            // lcReturnForEdit
            // 
            this.lcReturnForEdit.Control = this.btnReturn;
            this.lcReturnForEdit.CustomizationFormText = "layoutControlItem4";
            this.lcReturnForEdit.Location = new System.Drawing.Point(0, 280);
            this.lcReturnForEdit.MaxSize = new System.Drawing.Size(146, 26);
            this.lcReturnForEdit.MinSize = new System.Drawing.Size(146, 26);
            this.lcReturnForEdit.Name = "lcReturnForEdit";
            this.lcReturnForEdit.Size = new System.Drawing.Size(146, 26);
            this.lcReturnForEdit.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lcReturnForEdit.Text = "lcReturnForEdit";
            this.lcReturnForEdit.TextSize = new System.Drawing.Size(0, 0);
            this.lcReturnForEdit.TextToControlDistance = 0;
            this.lcReturnForEdit.TextVisible = false;
            // 
            // emptySpaceItem8
            // 
            this.emptySpaceItem8.AllowHotTrack = false;
            this.emptySpaceItem8.CustomizationFormText = "emptySpaceItem8";
            this.emptySpaceItem8.Location = new System.Drawing.Point(146, 210);
            this.emptySpaceItem8.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem8.Name = "emptySpaceItem8";
            this.emptySpaceItem8.Size = new System.Drawing.Size(381, 96);
            this.emptySpaceItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem8.Text = "emptySpaceItem8";
            this.emptySpaceItem8.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem7
            // 
            this.emptySpaceItem7.AllowHotTrack = false;
            this.emptySpaceItem7.CustomizationFormText = "emptySpaceItem7";
            this.emptySpaceItem7.Location = new System.Drawing.Point(0, 210);
            this.emptySpaceItem7.MaxSize = new System.Drawing.Size(146, 70);
            this.emptySpaceItem7.MinSize = new System.Drawing.Size(146, 70);
            this.emptySpaceItem7.Name = "emptySpaceItem7";
            this.emptySpaceItem7.Size = new System.Drawing.Size(146, 70);
            this.emptySpaceItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem7.Text = "emptySpaceItem7";
            this.emptySpaceItem7.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutSTVNo
            // 
            this.layoutSTVNo.CustomizationFormText = "layoutSTVNo";
            this.layoutSTVNo.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.layoutControlItem13,
            this.layoutControlItem16});
            this.layoutSTVNo.Location = new System.Drawing.Point(0, 0);
            this.layoutSTVNo.Name = "layoutSTVNo";
            this.layoutSTVNo.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutSTVNo.Size = new System.Drawing.Size(720, 32);
            this.layoutSTVNo.Text = "layoutSTVNo";
            this.layoutSTVNo.TextVisible = false;
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(358, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(356, 26);
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.txtSTVNo;
            this.layoutControlItem13.CustomizationFormText = "STV No";
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(315, 26);
            this.layoutControlItem13.Text = "STV No";
            this.layoutControlItem13.TextSize = new System.Drawing.Size(138, 13);
            // 
            // layoutControlItem16
            // 
            this.layoutControlItem16.Control = this.btnSTV;
            this.layoutControlItem16.CustomizationFormText = "layoutControlItem16";
            this.layoutControlItem16.Location = new System.Drawing.Point(315, 0);
            this.layoutControlItem16.Name = "layoutControlItem16";
            this.layoutControlItem16.Size = new System.Drawing.Size(43, 26);
            this.layoutControlItem16.Text = "layoutControlItem16";
            this.layoutControlItem16.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem16.TextToControlDistance = 0;
            this.layoutControlItem16.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.txtOtherExpense;
            this.layoutControlItem18.CustomizationFormText = "Other Expense";
            this.layoutControlItem18.Location = new System.Drawing.Point(527, 258);
            this.layoutControlItem18.MaxSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem18.MinSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(193, 24);
            this.layoutControlItem18.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem18.Text = "Other Expense";
            this.layoutControlItem18.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.layoutControlItem18.TextSize = new System.Drawing.Size(75, 20);
            this.layoutControlItem18.TextToControlDistance = 5;
            // 
            // layoutControlItem19
            // 
            this.layoutControlItem19.Control = this.lblGrandTotal;
            this.layoutControlItem19.CustomizationFormText = "Grand Total:";
            this.layoutControlItem19.Location = new System.Drawing.Point(527, 282);
            this.layoutControlItem19.MaxSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem19.MinSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem19.Name = "layoutControlItem19";
            this.layoutControlItem19.Size = new System.Drawing.Size(193, 24);
            this.layoutControlItem19.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem19.Text = "Grand Total:";
            this.layoutControlItem19.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem19.TextSize = new System.Drawing.Size(60, 13);
            this.layoutControlItem19.TextToControlDistance = 20;
            // 
            // layoutControlItem22
            // 
            this.layoutControlItem22.Control = this.lblSubTotal;
            this.layoutControlItem22.CustomizationFormText = "Sub Total:";
            this.layoutControlItem22.Location = new System.Drawing.Point(527, 210);
            this.layoutControlItem22.MaxSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem22.MinSize = new System.Drawing.Size(193, 24);
            this.layoutControlItem22.Name = "layoutControlItem22";
            this.layoutControlItem22.Size = new System.Drawing.Size(193, 24);
            this.layoutControlItem22.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem22.Text = "Sub Total:";
            this.layoutControlItem22.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem22.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem22.TextToControlDistance = 30;
            // 
            // grpTabUnitCost
            // 
            this.grpTabUnitCost.CustomizationFormText = "Unit Cost/Cost Coefficient";
            this.grpTabUnitCost.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4,
            this.layoutControlItem14,
            this.emptySpaceItem4,
            this.emptySpaceItem11,
            this.emptySpaceItem12});
            this.grpTabUnitCost.Location = new System.Drawing.Point(0, 0);
            this.grpTabUnitCost.Name = "grpTabUnitCost";
            this.grpTabUnitCost.Size = new System.Drawing.Size(720, 306);
            this.grpTabUnitCost.Text = "Step 2: Determine Unit Cost";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridUnitCost;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(720, 162);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem14
            // 
            this.layoutControlItem14.Control = this.gridCostBuild;
            this.layoutControlItem14.CustomizationFormText = "layoutControlItem14";
            this.layoutControlItem14.Location = new System.Drawing.Point(424, 183);
            this.layoutControlItem14.Name = "layoutControlItem14";
            this.layoutControlItem14.Size = new System.Drawing.Size(296, 111);
            this.layoutControlItem14.Text = "layoutControlItem14";
            this.layoutControlItem14.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem14.TextToControlDistance = 0;
            this.layoutControlItem14.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 162);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(424, 144);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem11
            // 
            this.emptySpaceItem11.AllowHotTrack = false;
            this.emptySpaceItem11.CustomizationFormText = "emptySpaceItem11";
            this.emptySpaceItem11.Location = new System.Drawing.Point(424, 162);
            this.emptySpaceItem11.Name = "emptySpaceItem11";
            this.emptySpaceItem11.Size = new System.Drawing.Size(296, 21);
            this.emptySpaceItem11.Text = "emptySpaceItem11";
            this.emptySpaceItem11.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem12
            // 
            this.emptySpaceItem12.AllowHotTrack = false;
            this.emptySpaceItem12.CustomizationFormText = "emptySpaceItem12";
            this.emptySpaceItem12.Location = new System.Drawing.Point(424, 294);
            this.emptySpaceItem12.Name = "emptySpaceItem12";
            this.emptySpaceItem12.Size = new System.Drawing.Size(296, 12);
            this.emptySpaceItem12.Text = "emptySpaceItem12";
            this.emptySpaceItem12.TextSize = new System.Drawing.Size(0, 0);
            // 
            // grpTabMovingAverage
            // 
            this.grpTabMovingAverage.CustomizationFormText = "Moving Average";
            this.grpTabMovingAverage.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem8});
            this.grpTabMovingAverage.Location = new System.Drawing.Point(0, 0);
            this.grpTabMovingAverage.Name = "grpTabMovingAverage";
            this.grpTabMovingAverage.Size = new System.Drawing.Size(720, 306);
            this.grpTabMovingAverage.Text = "Step 3: Calculate Moving Average";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.gridMovingAverage;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(720, 189);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.gridSplitContainer1;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 189);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(720, 117);
            this.layoutControlItem8.Text = "Previous Stock and Unit Cost";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(138, 13);
            // 
            // grpTabFinalize
            // 
            this.grpTabFinalize.CustomizationFormText = "Finalize";
            this.grpTabFinalize.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem15,
            this.emptySpaceItem5});
            this.grpTabFinalize.Location = new System.Drawing.Point(0, 0);
            this.grpTabFinalize.Name = "grpTabFinalize";
            this.grpTabFinalize.Size = new System.Drawing.Size(720, 306);
            this.grpTabFinalize.Text = "Step 4: Finalize Costs";
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridFinal;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(720, 280);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem15
            // 
            this.layoutControlItem15.Control = this.btnSave;
            this.layoutControlItem15.CustomizationFormText = "layoutControlItem15";
            this.layoutControlItem15.Location = new System.Drawing.Point(574, 280);
            this.layoutControlItem15.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem15.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem15.Name = "layoutControlItem15";
            this.layoutControlItem15.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem15.Text = "layoutControlItem15";
            this.layoutControlItem15.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem15.TextToControlDistance = 0;
            this.layoutControlItem15.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.CustomizationFormText = "emptySpaceItem5";
            this.emptySpaceItem5.Location = new System.Drawing.Point(0, 280);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(574, 26);
            this.emptySpaceItem5.Text = "emptySpaceItem5";
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnBack;
            this.layoutControlItem10.CustomizationFormText = "layoutControlItem10";
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 496);
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
            // headerSection
            // 
            this.headerSection.AppearanceGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.headerSection.AppearanceGroup.Options.UseFont = true;
            this.headerSection.CustomizationFormText = " ";
            this.headerSection.ExpandButtonVisible = true;
            this.headerSection.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lgMode,
            this.layoutControlItem26,
            this.layoutControlItem20,
            this.layoutControlItem23,
            this.layoutControlItem27,
            this.layoutControlItem24,
            this.layoutControlItem25,
            this.layoutControlItem29,
            this.emptySpaceItem6,
            this.layoutControlGroup4,
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup5});
            this.headerSection.Location = new System.Drawing.Point(0, 0);
            this.headerSection.Name = "headerSection";
            this.headerSection.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.headerSection.Size = new System.Drawing.Size(744, 144);
            this.headerSection.Text = " ";
            // 
            // lgMode
            // 
            this.lgMode.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lgMode.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.lgMode.AppearanceItemCaption.Options.UseFont = true;
            this.lgMode.AppearanceItemCaption.Options.UseForeColor = true;
            this.lgMode.Control = this.lblMode;
            this.lgMode.CustomizationFormText = "Mode:";
            this.lgMode.Location = new System.Drawing.Point(0, 17);
            this.lgMode.MaxSize = new System.Drawing.Size(0, 20);
            this.lgMode.MinSize = new System.Drawing.Size(67, 20);
            this.lgMode.Name = "lgMode";
            this.lgMode.Size = new System.Drawing.Size(178, 20);
            this.lgMode.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lgMode.Text = "Mode:";
            this.lgMode.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lgMode.TextSize = new System.Drawing.Size(34, 13);
            this.lgMode.TextToControlDistance = 20;
            // 
            // layoutControlItem26
            // 
            this.layoutControlItem26.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem26.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem26.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem26.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem26.Control = this.lblCluster;
            this.layoutControlItem26.CustomizationFormText = "Cluster:";
            this.layoutControlItem26.Location = new System.Drawing.Point(0, 37);
            this.layoutControlItem26.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem26.MinSize = new System.Drawing.Size(67, 20);
            this.layoutControlItem26.Name = "layoutControlItem26";
            this.layoutControlItem26.Size = new System.Drawing.Size(178, 20);
            this.layoutControlItem26.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem26.Text = "Cluster:";
            this.layoutControlItem26.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem26.TextSize = new System.Drawing.Size(43, 13);
            this.layoutControlItem26.TextToControlDistance = 11;
            // 
            // layoutControlItem20
            // 
            this.layoutControlItem20.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem20.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem20.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem20.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem20.Control = this.lblSupplier;
            this.layoutControlItem20.CustomizationFormText = "Supplier:";
            this.layoutControlItem20.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem20.MinSize = new System.Drawing.Size(51, 17);
            this.layoutControlItem20.Name = "layoutControlItem20";
            this.layoutControlItem20.Size = new System.Drawing.Size(177, 17);
            this.layoutControlItem20.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem20.Text = "Supplier:";
            this.layoutControlItem20.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem20.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem20.TextToControlDistance = 5;
            // 
            // layoutControlItem23
            // 
            this.layoutControlItem23.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem23.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem23.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem23.Control = this.lblAccount;
            this.layoutControlItem23.CustomizationFormText = "Account:";
            this.layoutControlItem23.Location = new System.Drawing.Point(178, 17);
            this.layoutControlItem23.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem23.Name = "layoutControlItem23";
            this.layoutControlItem23.Size = new System.Drawing.Size(203, 20);
            this.layoutControlItem23.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem23.Text = "Account:";
            this.layoutControlItem23.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem23.TextSize = new System.Drawing.Size(49, 13);
            this.layoutControlItem23.TextToControlDistance = 23;
            // 
            // layoutControlItem27
            // 
            this.layoutControlItem27.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem27.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem27.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem27.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem27.Control = this.lblWarehouse;
            this.layoutControlItem27.CustomizationFormText = "Warehouse:";
            this.layoutControlItem27.Location = new System.Drawing.Point(178, 37);
            this.layoutControlItem27.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem27.Name = "layoutControlItem27";
            this.layoutControlItem27.Size = new System.Drawing.Size(203, 20);
            this.layoutControlItem27.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem27.Text = "Warehouse:";
            this.layoutControlItem27.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem27.TextSize = new System.Drawing.Size(67, 13);
            this.layoutControlItem27.TextToControlDistance = 5;
            // 
            // layoutControlItem24
            // 
            this.layoutControlItem24.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem24.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem24.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem24.Control = this.lblSubAccount;
            this.layoutControlItem24.CustomizationFormText = "Sub Account:";
            this.layoutControlItem24.Location = new System.Drawing.Point(381, 17);
            this.layoutControlItem24.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem24.Name = "layoutControlItem24";
            this.layoutControlItem24.Size = new System.Drawing.Size(178, 20);
            this.layoutControlItem24.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem24.Text = "Sub Account:";
            this.layoutControlItem24.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem24.TextSize = new System.Drawing.Size(73, 13);
            this.layoutControlItem24.TextToControlDistance = 5;
            // 
            // layoutControlItem25
            // 
            this.layoutControlItem25.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem25.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem25.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem25.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem25.Control = this.lblActivity;
            this.layoutControlItem25.CustomizationFormText = "Activity:";
            this.layoutControlItem25.Location = new System.Drawing.Point(559, 17);
            this.layoutControlItem25.MinSize = new System.Drawing.Size(49, 17);
            this.layoutControlItem25.Name = "layoutControlItem25";
            this.layoutControlItem25.Size = new System.Drawing.Size(171, 20);
            this.layoutControlItem25.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem25.Text = "Activity:";
            this.layoutControlItem25.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem25.TextSize = new System.Drawing.Size(47, 13);
            this.layoutControlItem25.TextToControlDistance = 23;
            // 
            // layoutControlItem29
            // 
            this.layoutControlItem29.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem29.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem29.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem29.Control = this.lblOrderNo;
            this.layoutControlItem29.CustomizationFormText = "Order No:";
            this.layoutControlItem29.Location = new System.Drawing.Point(177, 0);
            this.layoutControlItem29.MinSize = new System.Drawing.Size(73, 17);
            this.layoutControlItem29.Name = "layoutControlItem29";
            this.layoutControlItem29.Size = new System.Drawing.Size(553, 17);
            this.layoutControlItem29.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem29.Text = "PO Number:";
            this.layoutControlItem29.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem29.TextSize = new System.Drawing.Size(65, 13);
            this.layoutControlItem29.TextToControlDistance = 5;
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.CustomizationFormText = "emptySpaceItem6";
            this.emptySpaceItem6.Location = new System.Drawing.Point(381, 37);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(349, 20);
            this.emptySpaceItem6.Text = "emptySpaceItem6";
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "layoutControlGroup4";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem21,
            this.lgReceiptType});
            this.layoutControlGroup4.Location = new System.Drawing.Point(374, 57);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup4.Size = new System.Drawing.Size(185, 54);
            this.layoutControlGroup4.Text = "layoutControlGroup4";
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlItem21
            // 
            this.layoutControlItem21.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem21.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem21.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem21.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem21.Control = this.lblRecieptStatus;
            this.layoutControlItem21.CustomizationFormText = "Receipt Status:";
            this.layoutControlItem21.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem21.MinSize = new System.Drawing.Size(67, 17);
            this.layoutControlItem21.Name = "layoutControlItem21";
            this.layoutControlItem21.Size = new System.Drawing.Size(171, 20);
            this.layoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem21.Text = "Status:";
            this.layoutControlItem21.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem21.TextSize = new System.Drawing.Size(40, 13);
            this.layoutControlItem21.TextToControlDistance = 5;
            // 
            // lgReceiptType
            // 
            this.lgReceiptType.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lgReceiptType.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.lgReceiptType.AppearanceItemCaption.Options.UseFont = true;
            this.lgReceiptType.AppearanceItemCaption.Options.UseForeColor = true;
            this.lgReceiptType.Control = this.lblReceiptType;
            this.lgReceiptType.CustomizationFormText = "Receipt Type:";
            this.lgReceiptType.Location = new System.Drawing.Point(0, 20);
            this.lgReceiptType.MaxSize = new System.Drawing.Size(0, 20);
            this.lgReceiptType.MinSize = new System.Drawing.Size(76, 20);
            this.lgReceiptType.Name = "lgReceiptType";
            this.lgReceiptType.Size = new System.Drawing.Size(171, 20);
            this.lgReceiptType.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.lgReceiptType.Text = "Type:";
            this.lgReceiptType.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.lgReceiptType.TextSize = new System.Drawing.Size(31, 13);
            this.lgReceiptType.TextToControlDistance = 15;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "layoutControlGroup2";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem34,
            this.layoutControlItem35});
            this.layoutControlGroup2.Location = new System.Drawing.Point(176, 57);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup2.Size = new System.Drawing.Size(198, 54);
            this.layoutControlGroup2.Text = "layoutControlGroup2";
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem34
            // 
            this.layoutControlItem34.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem34.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem34.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem34.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem34.Control = this.lblConfirmedBy;
            this.layoutControlItem34.CustomizationFormText = "Confirmed By:";
            this.layoutControlItem34.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem34.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem34.MinSize = new System.Drawing.Size(73, 20);
            this.layoutControlItem34.Name = "layoutControlItem34";
            this.layoutControlItem34.Size = new System.Drawing.Size(184, 20);
            this.layoutControlItem34.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem34.Text = "Cost Confirmed By:";
            this.layoutControlItem34.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem34.TextSize = new System.Drawing.Size(106, 13);
            this.layoutControlItem34.TextToControlDistance = 16;
            // 
            // layoutControlItem35
            // 
            this.layoutControlItem35.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem35.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem35.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem35.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem35.Control = this.lblConfirmedDate;
            this.layoutControlItem35.CustomizationFormText = "Confirmed Date:";
            this.layoutControlItem35.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem35.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem35.MinSize = new System.Drawing.Size(100, 20);
            this.layoutControlItem35.Name = "layoutControlItem35";
            this.layoutControlItem35.Size = new System.Drawing.Size(184, 20);
            this.layoutControlItem35.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem35.Text = "Cost Confirmed Date:";
            this.layoutControlItem35.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem35.TextSize = new System.Drawing.Size(119, 13);
            this.layoutControlItem35.TextToControlDistance = 5;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "layoutControlGroup3";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem31,
            this.layoutControlItem30});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 57);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup3.Size = new System.Drawing.Size(176, 54);
            this.layoutControlGroup3.Spacing = new DevExpress.XtraLayout.Utils.Padding(-1, 2, 2, 2);
            this.layoutControlGroup3.Text = "layoutControlGroup3";
            this.layoutControlGroup3.TextVisible = false;
            // 
            // layoutControlItem31
            // 
            this.layoutControlItem31.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem31.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem31.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem31.Control = this.lblReceivedBy;
            this.layoutControlItem31.CustomizationFormText = "Received by:";
            this.layoutControlItem31.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem31.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem31.MinSize = new System.Drawing.Size(84, 20);
            this.layoutControlItem31.Name = "layoutControlItem31";
            this.layoutControlItem31.Size = new System.Drawing.Size(165, 20);
            this.layoutControlItem31.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem31.Text = "Received by:";
            this.layoutControlItem31.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem31.TextSize = new System.Drawing.Size(72, 13);
            this.layoutControlItem31.TextToControlDistance = 8;
            // 
            // layoutControlItem30
            // 
            this.layoutControlItem30.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem30.AppearanceItemCaption.ForeColor = System.Drawing.Color.Gray;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem30.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem30.Control = this.lblRecieptDate;
            this.layoutControlItem30.CustomizationFormText = "Receipt Date:";
            this.layoutControlItem30.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem30.MaxSize = new System.Drawing.Size(0, 20);
            this.layoutControlItem30.MinSize = new System.Drawing.Size(85, 20);
            this.layoutControlItem30.Name = "layoutControlItem30";
            this.layoutControlItem30.Size = new System.Drawing.Size(165, 20);
            this.layoutControlItem30.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem30.Text = "Receipt Date:";
            this.layoutControlItem30.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem30.TextSize = new System.Drawing.Size(76, 13);
            this.layoutControlItem30.TextToControlDistance = 5;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem9});
            this.layoutControlGroup5.Location = new System.Drawing.Point(559, 57);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup5.Size = new System.Drawing.Size(171, 54);
            this.layoutControlGroup5.Text = "layoutControlGroup5";
            this.layoutControlGroup5.TextVisible = false;
            // 
            // emptySpaceItem9
            // 
            this.emptySpaceItem9.AllowHotTrack = false;
            this.emptySpaceItem9.CustomizationFormText = "emptySpaceItem9";
            this.emptySpaceItem9.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem9.Name = "emptySpaceItem9";
            this.emptySpaceItem9.Size = new System.Drawing.Size(157, 40);
            this.emptySpaceItem9.Text = "emptySpaceItem9";
            this.emptySpaceItem9.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnNext;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(598, 496);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(146, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(146, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(146, 496);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(104, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(452, 26);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup13
            // 
            this.layoutControlGroup13.CustomizationFormText = "STV No.";
            this.layoutControlGroup13.Location = new System.Drawing.Point(0, 201);
            this.layoutControlGroup13.Name = "layoutControlGroup12";
            this.layoutControlGroup13.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup13.Size = new System.Drawing.Size(278, 67);
            this.layoutControlGroup13.Text = "STV No.";
            // 
            // layoutControlGroup11
            // 
            this.layoutControlGroup11.CustomizationFormText = "layoutControlGroup11";
            this.layoutControlGroup11.Location = new System.Drawing.Point(0, 50);
            this.layoutControlGroup11.Name = "layoutControlGroup11";
            this.layoutControlGroup11.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup11.Size = new System.Drawing.Size(732, 115);
            this.layoutControlGroup11.Text = "layoutControlGroup11";
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1,
            this.printableComponentLink2});
            // 
            // printableComponentLink1
            // 
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.ImageCollection.Images.SetKeyName(0, "PFSALogo.jpg");
            this.printableComponentLink1.Margins = new System.Drawing.Printing.Margins(100, 100, 200, 100);
            this.printableComponentLink1.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "[Image 0]\r\n\r\nJournal Entry",
                "[Date Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // printableComponentLink2
            // 
            // 
            // 
            // 
            this.printableComponentLink2.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink2.ImageCollection.ImageStream")));
            this.printableComponentLink2.ImageCollection.Images.SetKeyName(0, "PFSALogo.jpg");
            this.printableComponentLink2.Margins = new System.Drawing.Printing.Margins(100, 100, 200, 100);
            this.printableComponentLink2.PageHeaderFooter = new DevExpress.XtraPrinting.PageHeaderFooter(new DevExpress.XtraPrinting.PageHeaderArea(new string[] {
                "",
                "[Image 0]\r\n\r\nCost Build up",
                "\r\n\r\n[Date Printed]"}, new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near), new DevExpress.XtraPrinting.PageFooterArea(new string[] {
                "",
                "",
                "[Page #]"}, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))), DevExpress.XtraPrinting.BrickAlignment.Near));
            this.printableComponentLink2.PrintingSystemBase = this.printingSystem1;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.CustomizationFormText = "Order No";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(216, 24);
            this.layoutControlItem5.Text = "Order No";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem5.TextToControlDistance = 5;
            // 
            // layoutControlItem47
            // 
            this.layoutControlItem47.CustomizationFormText = "Invoice No";
            this.layoutControlItem47.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem47.Name = "layoutControlItem8";
            this.layoutControlItem47.Size = new System.Drawing.Size(216, 24);
            this.layoutControlItem47.Text = "Invoice No";
            this.layoutControlItem47.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem47.TextToControlDistance = 5;
            // 
            // layoutControlItem69
            // 
            this.layoutControlItem69.CustomizationFormText = "Way Bill/Airway Bill";
            this.layoutControlItem69.Location = new System.Drawing.Point(216, 0);
            this.layoutControlItem69.Name = "layoutControlItem6";
            this.layoutControlItem69.Size = new System.Drawing.Size(212, 24);
            this.layoutControlItem69.Text = "Way Bill/Airway Bill";
            this.layoutControlItem69.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem69.TextToControlDistance = 5;
            // 
            // layoutControlItem70
            // 
            this.layoutControlItem70.CustomizationFormText = "Transfer Voucher No";
            this.layoutControlItem70.Location = new System.Drawing.Point(428, 0);
            this.layoutControlItem70.Name = "layoutControlItem7";
            this.layoutControlItem70.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem70.Text = "Transfer Voucher No";
            this.layoutControlItem70.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem70.TextToControlDistance = 5;
            // 
            // layoutControlItem71
            // 
            this.layoutControlItem71.CustomizationFormText = "Activity";
            this.layoutControlItem71.Location = new System.Drawing.Point(428, 24);
            this.layoutControlItem71.Name = "layoutControlItem9";
            this.layoutControlItem71.Size = new System.Drawing.Size(233, 24);
            this.layoutControlItem71.Text = "Activity";
            this.layoutControlItem71.TextSize = new System.Drawing.Size(99, 13);
            this.layoutControlItem71.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 315);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(714, 10);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem77
            // 
            this.layoutControlItem77.CustomizationFormText = "layoutControlItem77";
            this.layoutControlItem77.Location = new System.Drawing.Point(0, 421);
            this.layoutControlItem77.Name = "layoutControlItem77";
            this.layoutControlItem77.Size = new System.Drawing.Size(714, 25);
            this.layoutControlItem77.Text = "layoutControlItem77";
            this.layoutControlItem77.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem77.TextToControlDistance = 5;
            // 
            // layoutControlGroup6
            // 
            this.layoutControlGroup6.CustomizationFormText = "MovingAverage";
            this.layoutControlGroup6.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup6.Name = "layoutControlGroup4";
            this.layoutControlGroup6.OptionsItemText.TextToControlDistance = 5;
            this.layoutControlGroup6.Size = new System.Drawing.Size(762, 420);
            this.layoutControlGroup6.Text = "MovingAverage";
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnNext;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem9.Location = new System.Drawing.Point(924, 490);
            this.layoutControlItem9.Name = "layoutControlItem3";
            this.layoutControlItem9.Size = new System.Drawing.Size(105, 26);
            this.layoutControlItem9.Text = "layoutControlItem3";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem17
            // 
            this.layoutControlItem17.Control = this.btnNext;
            this.layoutControlItem17.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem17.Location = new System.Drawing.Point(891, 532);
            this.layoutControlItem17.Name = "layoutControlItem3";
            this.layoutControlItem17.Size = new System.Drawing.Size(138, 34);
            this.layoutControlItem17.Text = "layoutControlItem3";
            this.layoutControlItem17.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem17.TextToControlDistance = 0;
            this.layoutControlItem17.TextVisible = false;
            // 
            // CostingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 586);
            this.Controls.Add(this.layoutControl1);
            this.Name = "CostingForm";
            this.Text = "Costing";
            this.Load += new System.EventHandler(this.PutAwayListsLoad);
            ((System.ComponentModel.ISupportInitialize)(this.gridGRVs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGRVsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditReceivingCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkPalletLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGrandTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOtherExpense.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSTVNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCostBuild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCostBuildUpView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPreviousBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreviousBalanceView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinalView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovingAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMovingAverageView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUnitCostView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInsurance.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceDetailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkAccount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Accounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoSelection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoSelectCaption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Selection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabContralGRVDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabInvoiceValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutInsurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcReturnForEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutSTVNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabMovingAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpTabFinalize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerSection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lgReceiptType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationStep1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink1.ImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printableComponentLink2.ImageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem69)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem70)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem71)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem77)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem17)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridGRVs;
        private DevExpress.XtraGrid.Views.Grid.GridView gridGRVsView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkPalletLocations;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textEditReceivingCost;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraLayout.LayoutControlItem lcReturnForEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit textEditMargin;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationStep1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup13;
        private DevExpress.XtraGrid.Columns.GridColumn colInvoiceNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup11;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink2;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.XtraEditors.GridLookUpEdit lkAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn96;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn97;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn98;
        private DevExpress.XtraLayout.LayoutControlItem Accounts;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup9;
        private DevExpress.XtraGrid.Columns.GridColumn colPGRV;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem47;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem69;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem70;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem71;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem77;
        private DevExpress.XtraGrid.GridControl gridUnitCost;
        private DevExpress.XtraGrid.Views.Grid.GridView gridUnitCostView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraEditors.TextEdit txtInsurance;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraGrid.GridControl gridInvoiceDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridInvoiceDetailView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraLayout.TabbedControlGroup tabContralGRVDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl gridFinal;
        private DevExpress.XtraGrid.GridControl gridMovingAverage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMovingAverageView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup6;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraGrid.GridControl gridPreviousBalance;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPreviousBalanceView;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn58;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn59;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn60;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn61;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn63;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn49;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn51;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn52;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraEditors.TextEdit txtGrandTotal;
        private DevExpress.XtraEditors.TextEdit txtSubTotal;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtInvoiceCost;
        private DevExpress.XtraGrid.GridControl gridCostBuild;
        private DevExpress.XtraGrid.Views.Grid.GridView gridCostBuildUpView;
        private DevExpress.XtraGrid.Columns.GridColumn colCostBuildName;
        private DevExpress.XtraGrid.Columns.GridColumn colCostBuildValue;
        private DevExpress.XtraGrid.Views.Grid.GridView gridFinalView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn42;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn45;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn46;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn55;
        private DevExpress.XtraLayout.LayoutControlGroup grpTabFinalize;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlGroup grpTabMovingAverage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.LayoutControlGroup grpTabInvoiceValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutInsurance;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem8;
        private DevExpress.XtraEditors.SimpleButton btnSTV;
        private DevExpress.XtraEditors.TextEdit txtSTVNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutSTVNo;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem17;
        private DevExpress.XtraEditors.TextEdit txtOtherExpense;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlGroup NoSelection;
        private DevExpress.XtraLayout.LayoutControlGroup Selection;
        private DevExpress.XtraLayout.SimpleLabelItem NoSelectCaption;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn65;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn64;
        private DevExpress.XtraGrid.Columns.GridColumn colActivity;
        private DevExpress.XtraEditors.LabelControl lblReceiptType;
        private DevExpress.XtraLayout.LayoutControlItem lgReceiptType;
        private DevExpress.XtraEditors.LabelControl lblSupplier;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem20;
        private DevExpress.XtraEditors.LabelControl lblRecieptStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem21;
        private DevExpress.XtraEditors.LabelControl lblMode;
        private DevExpress.XtraLayout.LayoutControlItem lgMode;
        private DevExpress.XtraEditors.LabelControl lblSubAccount;
        private DevExpress.XtraEditors.LabelControl lblAccount;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem23;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem24;
        private DevExpress.XtraEditors.LabelControl lblActivity;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem25;
        private DevExpress.XtraEditors.LabelControl lblWarehouse;
        private DevExpress.XtraEditors.LabelControl lblCluster;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem26;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem27;
        private DevExpress.XtraEditors.LabelControl lblOrderNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem29;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraLayout.LayoutControlGroup headerSection;
        private DevExpress.XtraEditors.LabelControl lblReceivedBy;
        private DevExpress.XtraEditors.LabelControl lblRecieptDate;
        private DevExpress.XtraEditors.LabelControl lblInsurance;
        private DevExpress.XtraEditors.LabelControl lblAmount;
        private DevExpress.XtraEditors.LabelControl lblConfirmedDate;
        private DevExpress.XtraEditors.LabelControl lblConfirmedBy;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem36;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup grpTabUnitCost;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem10;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem32;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem33;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem34;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem35;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem31;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem30;
        private DevExpress.XtraGrid.Columns.GridColumn Account;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn66;
        private DevExpress.XtraEditors.LabelControl lblGrandTotal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem19;
        private DevExpress.XtraEditors.LabelControl lblSubTotal;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem22;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem11;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem12;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem9;
    }
}
