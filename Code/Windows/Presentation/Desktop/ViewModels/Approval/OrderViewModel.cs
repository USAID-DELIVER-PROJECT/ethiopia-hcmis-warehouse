using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EthiopianCalendar;
using HCMIS.Modules.Requisition.Domain;
using Helpers;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class OrderViewModel
    {
        #region private Members
        
        private readonly Request _request;
        private readonly ICollection<StockInformation> _stockInformations;
        private readonly ICollection<ApprovedDetail> _approvedDetails;
        private readonly ICollection<Forcasting> _otherStockInformations;
        private readonly ConsumptionSetting _consumptionSetting;
        private ObservableCollection<OrderDetailViewModel> _orderDetails;
        private readonly ConsumptionSettingViewModel _consumptionSettingViewModel;
        public   ObservableCollection<PhysicalStoreViewModel> _distinctPhysicalStoresForAllItems;
        
        #endregion

     
        public OrderViewModel(Request request, ICollection<StockInformation> stockInformations,ICollection<ApprovedDetail> approvedDetails , ICollection<Forcasting> otherStockInformations,ConsumptionSetting consumptionSetting)
        {
            _request = request;
            _stockInformations = stockInformations;
            _approvedDetails = approvedDetails;
            _otherStockInformations = otherStockInformations;
            _consumptionSetting = consumptionSetting;
            _consumptionSettingViewModel = new ConsumptionSettingViewModel(consumptionSetting);
            LoadOrderDetails();

            if (BLL.Settings.AllowPreferedPhysicalStoreForAllItemsOnApproval) 
                LoadDistinctPhysicalStores();
        }


        public ConsumptionSettingViewModel ConsumptionSettingViewModel
        {
            get { return _consumptionSettingViewModel; }
        }

        public ObservableCollection<PhysicalStoreViewModel> DistinctPhysicalStoresForAllItems
        {
            get { return _distinctPhysicalStoresForAllItems ?? new ObservableCollection<PhysicalStoreViewModel>(); }
        }
        public OrderViewModel()
        {
            _request = new Request
                           {
                               Client = new Client(),
                               Mode = new Modes(),
                               OrderStatus = new OrderStatus(),
                               PaymentTerm = new PaymentTerm(),
                               RequestedDate = DateTime.Now

                           };
            _stockInformations = new Collection<StockInformation>();
            _approvedDetails = new Collection<ApprovedDetail>();
            _otherStockInformations = new Collection<Forcasting>();
            LoadOrderDetails();
        }

        
        #region Properties
        
        public string OrderNumber { get { return _request.OrderNumber; } }

        public string RequestedBy { get { return _request.Client.ClientName; } }

        public string LetterNumber { get { return _request.LetterNumber; } }

        public string OrderDate { get { return _request.RequestedDate.ToEthiopianDateString(); } }
        
        public string Woreda { get { return _request.Client.Woreda; } }
        
        public string Zone { get { return _request.Client.Zone; } }
        
        public string Region { get { return _request.Client.Region; }}
        
        public string InstitutionType { get { return _request.Client.InstitutionType; } }

        public string PaymentTerm { get { return _request.PaymentTerm.Name; } }

        public bool IsEnabled { get { return _request.RequestID != 0; } }

        public ObservableCollection<OrderDetailViewModel> OrderDetails { get { return _orderDetails??_orderDetails; } }
        
        public ICollection<ExpiryDateViewModel> ExpiryDateViewModels
        {

            get
            {
                var result = _stockInformations
                    .GroupBy(s => new {s.ExpiryDate},
                             (key, group) => new {Key = key.ExpiryDate, Sum = @group.Sum(s => s.Quantity)})
                             .Select(s => new ExpiryDateViewModel { Value = s.Key, Text = string.Format("{0: dd/M/yy}", s.Key), DaysAgo = s.Key == null?"-":((DateTime)s.Key).TimeAgo() })
                    .ToList();

                result.Add(new ExpiryDateViewModel
                               {
                                   Value = null,
                                   Text = "No Preferences"
                               });

                return result;
            }
        }
        
        #endregion

        #region private Methods
        private void LoadOrderDetails()
        {
            _orderDetails = new ObservableCollection<OrderDetailViewModel>(_request.RequestDetails.Select(
                r =>
                new OrderDetailViewModel(r,
                    _stockInformations.Where(s => s.Item.ItemID == r.Item.ItemID && s.Unit.UnitID == r.Unit.UnitID).ToList(),_approvedDetails.Where(s => s.Item.ItemID == r.Item.ItemID && s.Unit.UnitID == r.Unit.UnitID).ToList(),
                    _otherStockInformations.FirstOrDefault(s => s.Item == r.Item && s.Unit == r.Unit),_consumptionSetting)).ToList());
        }
        
        private void LoadDistinctPhysicalStores()
        {
            _distinctPhysicalStoresForAllItems = new ObservableCollection<PhysicalStoreViewModel>();
            foreach (
                var physicalStore in
                    _orderDetails.SelectMany(orderDetail => orderDetail.getPhysicalStoreViewModels(),
                        (orderDetail, p) =>
                            new PhysicalStoreViewModel {Name = p.Name, PhysicalStoreID = p.PhysicalStoreID})
                        .Where(
                            physicalStore =>
                                _distinctPhysicalStoresForAllItems.All(
                                    ps =>
                                        ps.PhysicalStoreID != physicalStore.PhysicalStoreID &&
                                        physicalStore.PhysicalStoreID != 0)))
                _distinctPhysicalStoresForAllItems.Add(physicalStore);
            _distinctPhysicalStoresForAllItems.Add(new PhysicalStoreViewModel
            {
                PhysicalStoreID = 0,
                Name = "No Preferences"
            });
        }

        #endregion

        #region Behaviors
        
        public void SplitRequest(OrderDetailViewModel orderDetailViewModel)
        {

            var newRequestDetail = new RequestDetail
                                       {
                                           Item = orderDetailViewModel.RequestDetail.Item,
                                           Unit = orderDetailViewModel.RequestDetail.Unit,
                                           RequestedQuantity = 0,
                                       };
            _request.RequestDetails.Add(newRequestDetail);
            var newOrderDetailViewModel = new OrderDetailViewModel(newRequestDetail,
                    _stockInformations.Where(s => s.Item.ItemID == newRequestDetail.Item.ItemID && s.Unit.UnitID == newRequestDetail.Unit.UnitID).ToList(), _approvedDetails.Where(s => s.Item.ItemID == newRequestDetail.Item.ItemID && s.Unit.UnitID == newRequestDetail.Unit.UnitID).ToList(),
                    _otherStockInformations.SingleOrDefault(s => s.Item == newRequestDetail.Item && s.Unit == newRequestDetail.Unit), _consumptionSetting);

            _orderDetails.Add(newOrderDetailViewModel);
            _orderDetails.Move(_orderDetails.IndexOf(newOrderDetailViewModel), _orderDetails.IndexOf(orderDetailViewModel) + 1);
        }

        public void RemoveDetail(OrderDetailViewModel orderDetailViewModel)
        {
            _request.RequestDetails.Remove(orderDetailViewModel.RequestDetail);
            _orderDetails.Remove(orderDetailViewModel);
        }
        #endregion
    }
}
