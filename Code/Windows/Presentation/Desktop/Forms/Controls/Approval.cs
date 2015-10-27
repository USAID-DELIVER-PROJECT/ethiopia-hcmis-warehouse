using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Desktop.ViewModels.Approval;
using HCMIS.Modules.Requisition.Domain;
using HCMIS.Modules.Requisition.Services;
using HCMIS.Modules.Requisition.Validation;

namespace HCMIS.Desktop.Forms.Controls
{
    public partial class Approval : XtraUserControl
    {
        #region private members
        private OrderViewModel _order;
        private readonly RequestRepository _requestService;
        private readonly StockInformationRepository _stockInformationRepository;
        private readonly ActivityRepository _activityRepository;
        private readonly ManufacturerRepository _manufacturerRepository;
        private readonly PhysicalStoreRepository _physicalRepository;
        private ConsumptionSetting consumptionSetting;
        private Request _request;

        private readonly ForcastingRepository _forcastingRepository;

        private bool _isCenter;
        private int _requestID;
        private DateTime _starttime;
        private BackgroundWorker _backgroundWorker;
        private readonly ConsumptionSettingRespository _consumptionRepository;

        #endregion

        public Approval()
        {
            _requestService = new RequestRepository();
            _stockInformationRepository = new StockInformationRepository();
            _forcastingRepository = new ForcastingRepository();
            _activityRepository = new ActivityRepository();
            _manufacturerRepository = new ManufacturerRepository();
            _physicalRepository = new PhysicalStoreRepository();
            _consumptionRepository = new ConsumptionSettingRespository();
            InitializeComponent();

            //Edit Valued Changed Listener
            lkManufacturer.EditValueChanged += ColumnLookup_EditValueChanged;
            lkActivity.EditValueChanged += ColumnLookup_EditValueChanged;
            lkExpiryPreference.EditValueChanged += ColumnLookup_EditValueChanged;
            lkPhysicalStorePreference.EditValueChanged += ColumnLookup_EditValueChanged;

            gridOrderDetailView.CellMerge += gridViewOrderDetailsForApproval_CellMerge;
            gridOrderDetailView.ShowingEditor += gridViewOrderDetailsForApproval_ShowingEditor;
        }

        public void Initialize()
        {
            LoadActivity();
            LoadManufacturer();
            LoadPhysicalStore();
            consumptionSetting = _consumptionRepository.FindCurrentSetting();
            requestBindingSource.DataSource = new OrderViewModel();
        }

        public void Flush()
        {
            requestBindingSource.DataSource = new OrderViewModel();
            gridOrderDetail.DataSource = null;
        }
        public void LoadOrder(int requestID, bool isCenter)
        {
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += backgroundWorker1_DoWork;
            _backgroundWorker.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;


            _requestID = requestID;
            _isCenter = isCenter;
            if (_isCenter)
            {
                LayoutMinMax.Visibility = LayoutVisibility.Never;
            }

            layoutDefaultPhysicalStore.Visibility = BLL.Settings.AllowPreferedPhysicalStoreForAllItemsOnApproval
                ? LayoutVisibility.Always
                : LayoutVisibility.Never;
            layoutProgressBar.Visibility = LayoutVisibility.Always;
            lbltotaltime.Text = string.Format("Loading ...");
            _starttime = DateTime.Now;

            if (_backgroundWorker.IsBusy)
            {
                _backgroundWorker.CancelAsync();
                //CachingHelper.ClearCaching();
            }
            _backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                _request = _requestService.FindSingle(_requestID);
                var stockInformation = _stockInformationRepository.GetStockInformationByOrderID(_requestID);
                var otherStockInformation = _forcastingRepository.GetForcastingByOrderID(_requestID);
                var approvedDetail = _stockInformationRepository.GetApprovedDetail(_requestID);
                var order = new OrderViewModel(_request, stockInformation,approvedDetail,otherStockInformation,consumptionSetting);

                _order = order;
            }
            catch (Exception)
            {
                _backgroundWorker.CancelAsync();
               //CachingHelper.ClearCaching();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            lkExpiryPreference.DataSource = _order.ExpiryDateViewModels;
            requestBindingSource.DataSource = _order;
            ConsumptionBindingSource.DataSource = _order.ConsumptionSettingViewModel;
            gridOrderDetail.DataSource = _order.OrderDetails;
            var endtime = DateTime.Now;
            lbltotaltime.Text = String.Format(@"{0:s\.f} seconds", (endtime - _starttime));
            layoutProgressBar.Visibility = LayoutVisibility.Never;


            if (BLL.Settings.AllowPreferedPhysicalStoreForAllItemsOnApproval)
            {
                LkUseDefaultPhysicalStore.EditValue = 0;
                LkUseDefaultPhysicalStore.Properties.DataSource = _order.DistinctPhysicalStoresForAllItems;
            }
        }

        private void LoadManufacturer()
        {
            var result = _manufacturerRepository.FindAll()
              .Select(
                  s =>
                  new ManufacturerViewModel { ManufacturerID = s.ManufacturerID, Name = s.Name, CountryOfOrigin = s.CountryOfOrigin }).
              ToList();

            result.Add(new ManufacturerViewModel
                           {
                               ManufacturerID = 0,
                               Name = "No Preferences"
                           });

            lkManufacturer.DataSource = result;
        }

        private void LoadActivity()
        {
            var activities = _activityRepository.FindAll()
                 .Select(
                     a =>
                     new ActivityViewModel
                     {
                         ActivityID = a.ActivityGroupID,
                         Name = a.Name,
                         IsDeliveryNote = a.IsDeliveryNote,
                     }).ToList();

            activities.Add(new ActivityViewModel
                               {
                                   ActivityID = "0",
                                   Name = "All Activities",
                                   IsDeliveryNote = false
                               });
            lkActivity.DataSource = activities;
        }

        private void LoadPhysicalStore()
        {

            var result = _physicalRepository.FindAll()
                .Select(
                    s =>
                    new PhysicalStoreViewModel { PhysicalStoreID = s.PhysicalStoreID, Name = s.Name })
                .
                ToList();

            result.Add(new PhysicalStoreViewModel
                           {
                               PhysicalStoreID = 0,
                               Name = "No Preferences"
                           });

            lkPhysicalStorePreference.DataSource = result;

        }


        private void gridViewOrderDetailsForApproval_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var orderDetail = (gridOrderDetailView.GetFocusedRow() as OrderDetailViewModel);
            if (view != null && orderDetail != null && view.ActiveEditor is LookUpEdit)
            {
                var edit = view.ActiveEditor as LookUpEdit;

                if (view.FocusedColumn.FieldName == "ActivityID")
                {
                    edit.Properties.DataSource = orderDetail.getActivityViewModels();
                }
                else if (view.FocusedColumn.FieldName == "ManufacturerID")
                {
                    edit.Properties.DataSource = orderDetail.getManufacturerViewModels();
                }
                else if (view.FocusedColumn.FieldName == "ExpiryDate")
                {
                    edit.Properties.DataSource = orderDetail.getExpiryDateViewModels();
                }
                else if (view.FocusedColumn.FieldName == "PhysicalStoreID")
                {
                    edit.Properties.DataSource = orderDetail.getPhysicalStoreViewModels();
                }
            }
        }

        private void gridViewOrderDetailsForApproval_ShowingEditor(object sender, CancelEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            var orderDetail = (gridOrderDetailView.GetFocusedRow() as OrderDetailViewModel);
            if (view != null && orderDetail != null)
            {
                
                if (view.FocusedColumn.FieldName == "ActivityID")
                {
                    var activities = orderDetail.getActivityViewModels(); 
                    if((activities.Count <= 2 && orderDetail.ActivityID != "0" && activities.Any(a=>a.ActivityID == orderDetail.ActivityID)) || activities.Count < 2)
                    {
                        e.Cancel = true;
                        view.FocusedColumn = colApprovedQuantity1;
                    }
                   
                }
                else if (view.FocusedColumn.FieldName == "ManufacturerID" && orderDetail.getManufacturerViewModels().Count < 2)
                {
                    e.Cancel = true;
                    view.FocusedColumn = colApprovedQuantity1;
                }
                else if (view.FocusedColumn.FieldName == "ExpiryDate" && orderDetail.getExpiryDateViewModels().Count < 2)
                {
                    e.Cancel = true;
                    view.FocusedColumn = colApprovedQuantity1;
                }
                else if (view.FocusedColumn.FieldName == "PhysicalStoreID" && orderDetail.getPhysicalStoreViewModels().Count < 2)
                {
                    e.Cancel = true;
                    view.FocusedColumn = colApprovedQuantity1;
                }
            }
        }

        private void gridViewOrderDetailsForApproval_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column != colRequestedQuantity) return;

            var itemName1 = gridOrderDetailView.GetRowCellValue(e.RowHandle1, colItemName).ToString();
            var unit1 = gridOrderDetailView.GetRowCellValue(e.RowHandle1, colUnit).ToString();
            var itemName2 = gridOrderDetailView.GetRowCellValue(e.RowHandle2, colItemName).ToString();
            var unit2 = gridOrderDetailView.GetRowCellValue(e.RowHandle2, colUnit).ToString();

            e.Merge = itemName1.Equals(itemName2) && unit1.Equals(unit2);
            e.Handled = true;
        }

        private void ColumnLookup_EditValueChanged(object sender, EventArgs e)
        {
            var orderDetail = (gridOrderDetailView.GetFocusedRow() as OrderDetailViewModel);
            if (orderDetail != null)
            {
                gridOrderDetailView.PostEditor();
                gridOrderDetailView.FocusedColumn = colApprovedQuantity1;
            }
        }

        public void SaveDraftOrder(int userID)
        {
            if (ValidateOrderDetail())
            {
                _requestService.Save(_request, userID);
            }
        }

        public bool ApproveOrder(int userID)
        {
            if (ValidateOrderDetail())
            {
                _requestService.Save(_request, userID, OrderStatus.Approved);
                _order = null;
                return true;
            }
            return false;
        }

        public bool HasStockOut()
        {
            return _request.RequestDetails.Any(s => s.StockedOut);
        }

        private bool ValidateOrderDetail()
        {

            var excessApproved = _order.OrderDetails.FirstOrDefault(o => o.ApprovedQuantity > o.AvailableQuantity);
            if (excessApproved != null)
            {
                XtraMessageBox.Show(
                    string.Format(
                        "The item {0} has an approved quantity greater than the SOH {1}.  Please correct quantity before approving the order.", excessApproved.ItemName, excessApproved.AvailableQuantity.ToString("#,##0.##")), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var requestValidation = new RequestValidation();
            requestValidation.Validate(_request);
            if (!requestValidation.Errors.Any())
            {
                return true;
            }
            foreach (var error in requestValidation.Errors)
            {

                if (error.ErrorType == RequestErrorType.NoApprovedQuantity)
                {
                    gridOrderDetailView.SetColumnError(colApprovedQuantity1, "No quantity approved for Client");
                }
                else if (error.ErrorType == RequestErrorType.DuplicateRequestDetail)
                {


                    XtraMessageBox.Show(
                        string.Format(
                            "The item {0} has a split entries with the same preference.  Please change preference to approve the order.", error.RequestDetail.Item.ItemName), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;

                }
                else if (error.ErrorType == RequestErrorType.NoActivitySelected)
                {
                    XtraMessageBox.Show(string.Format("Please select activity for item {0}",
                                                      error.RequestDetail.Item.ItemName), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return false;
        }

        private void gridOrderDetailView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = String.Format("{0}", e.RowHandle + 1);
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            gridOrderDetailView.ActiveFilterString = string.Format(chkShowStockedOut.Checked ? "ItemName like '{0}%' and AvailableQuantity >0" : "ItemName like '{0}%'", txtFilter.EditValue);
        }

        public bool ShowPipeline
        {
            get { return gridBandPipeline.Visible; }
            set { gridBandPipeline.Visible = value; }
        }

        public bool ShowAMCandMOS
        {
            get
            {
                return colAmc.Visible && colMos.Visible && LayoutMinMax.Visibility == LayoutVisibility.Always;
            }
            set
            {
                LayoutMinMax.Visibility = value ? LayoutVisibility.Always : LayoutVisibility.Never;
                colMos.Visible = colAmc.Visible = value;
            }

        }

        private void btnSplit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {

            var focused = (OrderDetailViewModel)gridOrderDetailView.GetFocusedRow();
            switch (e.Button.Kind)
            {
                case ButtonPredefines.Minus:
                    {
                        if (focused.AllowRemove)
                        {

                            gridOrderDetailView.FocusedRowHandle--;
                            _order.RemoveDetail(focused);

                        }
                        else
                        {
                            XtraMessageBox.Show(
                                string.Format("The item {0} cannot be removed.Please Return to Requisition to remove this Entry"
                                        , focused.ItemName), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);


                        }

                    }
                    break;
                case ButtonPredefines.Plus:
                    {
                        if (focused.AllowAdd)
                        {

                            _order.SplitRequest(focused);
                        }
                        else
                        {
                            XtraMessageBox.Show(
                                string.Format("The item {0} cannot have  more than one entries.There is not Preference Available"
                                        , focused.ItemName), "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);



                        }
                    }
                    break;

            }


        }

        private void gridOrderDetailView_DoubleClick(object sender, EventArgs e)
        {
            var orderDetail = (OrderDetailViewModel)gridOrderDetailView.GetFocusedRow();
            if (orderDetail != null)
            {
                var orderDetailForm = new OrderDetailForm(orderDetail.ItemID, orderDetail.UnitID) { StartPosition = FormStartPosition.CenterParent };
                this.Enabled = false;
                orderDetailForm.ShowDialog();
                this.Enabled = true;
            }
        }

        private void toolTip_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gridOrderDetail)
                return;
            ToolTipControlInfo info = null;

            var view = gridOrderDetail.GetViewAt(e.ControlMousePosition) as BandedGridView;
            if (view == null) return;
            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            var orderDetailViewModel = (OrderDetailViewModel)gridOrderDetailView.GetRow(hi.RowHandle);

            if (hi.HitTest == GridHitTest.RowCell)
            {
                object o = hi.HitTest.ToString() + hi.ToString();
                string text = "";

                if (hi.Column.FieldName == "ItemName")
                {
                    text = orderDetailViewModel.ItemName;
                }

                if (hi.Column.FieldName == "AMC")
                {
                    text = orderDetailViewModel.AMCCalculation;
                }

                if (hi.Column.FieldName == "MOS")
                {
                    text = orderDetailViewModel.MOSCalculation;
                }

                if (hi.Column == colManufacturer)
                {
                    var manufacturer = _manufacturerRepository.FindSingle(orderDetailViewModel.ManufacturerID);
                    if (manufacturer != null)
                    {
                        text = string.Format("{0} - {1}", manufacturer.Name, manufacturer.CountryOfOrigin);
                    }
                }

                if (hi.Column.FieldName == "ExpiryDate")
                {
                    text = string.Format("{0: dd/M/yy}", orderDetailViewModel.ExpiryDate);
                }

                info = new ToolTipControlInfo(o, text);
            }

            if (info != null)
                e.Info = info;

        }

        private void Approval_Load(object sender, EventArgs e)
        {
            toolTip.AddClientControl(gridOrderDetail);
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridOrderDetailView.Focus();
                gridOrderDetailView.FocusedColumn = colApprovedQuantity1;
            }
        }

        private void txtApprovedQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridOrderDetailView.FocusedRowHandle++;
            }
        }

        private void LkUseDefaultPhysicalStore_EditValueChanged(object sender, EventArgs e)
        {

            if ((int)LkUseDefaultPhysicalStore.EditValue != 0)
            {
                foreach (var requestDetail in _order.OrderDetails)
                {
                    requestDetail.PhysicalStoreID = (int) LkUseDefaultPhysicalStore.EditValue;
                    requestDetail.HasPhysicalStorePreference = true;
                }
            }
            else
            {
                foreach (var requestDetail in _order.OrderDetails)
                {
                    requestDetail.PhysicalStoreID = 0;
                    requestDetail.HasPhysicalStorePreference = false;
                }
            }
            gridOrderDetail.RefreshDataSource();
        }
        
    }
}