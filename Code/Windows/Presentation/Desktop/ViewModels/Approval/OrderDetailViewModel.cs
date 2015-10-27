using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HCMIS.Modules.Requisition.Domain;
using HCMIS.Modules.Requisition.Services;
using HCMIS.Desktop.Helpers;
using Helpers;

namespace HCMIS.Desktop.ViewModels.Approval
{
    public class OrderDetailViewModel
    {
        private readonly RequestDetail _requestDetail;
        private readonly ICollection<StockInformation> _stockInformations;
        private readonly ICollection<ApprovedDetail> _approvedDetails;
        private readonly Forcasting _forcasting;
        private readonly ConsumptionSetting _consumptionSetting;
        private bool _hasManyManufacturer;
        private bool _hasManyActivity;
        private bool _hasExpiryDatePreference;
        private bool _hasPhysicalStorePreference;
        private bool _allowAdd;
        private bool _allowRemove;

        public OrderDetailViewModel(RequestDetail requestDetail, ICollection<StockInformation> stockInformations, ICollection<ApprovedDetail> approvedDetails, Forcasting forcasting, ConsumptionSetting consumptionSetting)
        {
            _requestDetail = requestDetail;
            _stockInformations = stockInformations;
            _approvedDetails = approvedDetails;
            _forcasting = forcasting;
            _consumptionSetting = consumptionSetting;
            _hasManyActivity = getActivityViewModels().Count > 2;
            _hasManyManufacturer = getManufacturerViewModels().Count > 2;
            _hasExpiryDatePreference = getExpiryDateViewModels().Count > 2;
            _hasPhysicalStorePreference = getPhysicalStoreViewModels().Count > 2;
            _allowAdd = _hasManyActivity || _hasManyManufacturer || _hasExpiryDatePreference || _hasPhysicalStorePreference;
            _allowRemove = RequestedQuantity == 0;
            if (_requestDetail.ActivityGroup == null)
            {
                var stockInformation = _stockInformations.OrderBy(s => s.ExpiryDate).FirstOrDefault();
                if (stockInformation != null)
                {
                    _requestDetail.ActivityGroup = stockInformation.Activity;
                }
            }
            if (_requestDetail.IsFirstLoad)
            {
                if (_requestDetail.RequestedQuantity >= AvailableQuantity)
                {
                    _requestDetail.ApprovedQuantity = AvailableQuantity;
                }
            }
        }


        #region Item information Properties

        public RequestDetail RequestDetail
        {
            get
            {
                return _requestDetail;
            }
        }
        public int ItemID
        {
            get { return _requestDetail.Item.ItemID; }
        }

        public string ItemName
        {
            get { return _requestDetail.Item.ItemName; }
        }

        public string StockCode
        {
            get { return _requestDetail.Item.StockCode; }
        }

        public int UnitID
        {
            get { return _requestDetail.Unit.UnitID; }
        }

        public string Unit
        {
            get { return _requestDetail.Unit.Text; }
        }
        #endregion

        #region Pipeline Properties

        public decimal HubRequest
        {
            get { return 0; }
        }

        public decimal HubApproved
        {
            get { return 0; }
        }

        public decimal HubGIT
        {
            get { return 0; }
        }
        #endregion

        #region Hub State Properties

        public decimal MOS
        {
            get { return _forcasting != null ? _forcasting.getMos(SOH).Format() : 0; }
        }

        public decimal SOH { get { return _stockInformations.Sum(s => s.Quantity); } }

        public decimal AMC
        {
            get { return _forcasting != null ? _forcasting.getAmc() : 0; }
        }

        public int StockStatus
        {
            get { return _forcasting != null ? (Convert.ToInt32(_forcasting.getStockStatus(SOH, _consumptionSetting))) : 0; }
        }

        public string MOSCalculation
        {
            get { return String.Format("{0}/{1}", SOH.ToString("#,##0.##"), AMC.ToString("#,##0.##")); }
        }

        public string AMCCalculation
        {
            get { return _forcasting != null ? String.Format("({0}/({1}-{2}))*30", _forcasting.TotalIssued.ToString("#,##0.##"), _forcasting.FiscalYearDays.ToString("#,##0.##"), _forcasting.Dos.ToString("#,##0.##")) : ""; }
        }

        public decimal AvailableQuantity
        {
            get
            {
                var availableStock = PreferenceCalculator.GetAvailableStock(_stockInformations,_approvedDetails,_requestDetail.ActivityGroup,
                                                                       _requestDetail.Manufacturer,
                                                                       _requestDetail.physicalStore, ExpiryDate);
                var result = availableStock.Sum(s => s.Quantity);
                _requestDetail.StockedOut = result < _requestDetail.RequestedQuantity && result == _requestDetail.ApprovedQuantity;
                return result;
            }
        }

        #endregion

        #region Preference Properties

        public string ActivityID
        {
            get
            {
                if (_requestDetail.ActivityGroup == null)
                {
                    return "0";
                }
                return _requestDetail.ActivityGroup.ActivityGroupID;
            }
            set
            {

                _requestDetail.ActivityGroup = _stockInformations.Select(s => s.Activity).FirstOrDefault(a => a.ActivityGroupID == value);

            }

        }

        public int ManufacturerID
        {
            get
            {
                if (_requestDetail.Manufacturer == null)
                {
                    return 0;
                }
                return _requestDetail.Manufacturer.ManufacturerID;
            }
            set
            {
                _requestDetail.Manufacturer = _stockInformations.Where(s => s.Manufacturer != null).Select(s => s.Manufacturer).FirstOrDefault(m => m.ManufacturerID == value);
            }
        }

        public int PhysicalStoreID
        {
            get
            {
                if (_requestDetail.physicalStore == null)
                {
                    return 0;
                } return _requestDetail.physicalStore.PhysicalStoreID;
            }
            set
            {
                _requestDetail.physicalStore = _stockInformations.Where(s => s.PhysicalStore != null).Select(s => s.PhysicalStore).FirstOrDefault(p => p.PhysicalStoreID == value);


            }
        }

        public DateTime? ExpiryDate
        {
            get {
                return _requestDetail.ExpiryDate;
                }
            set
            {
                _requestDetail.ExpiryDate = value;

            }
        }


        public ICollection<ActivityViewModel> getActivityViewModels()
        {
            var activities = _stockInformations.GroupBy(s => new {s.Activity}).Select(s => s.Key.Activity).ToList();
            var result = new Collection<ActivityViewModel>();
            foreach (var activity in activities)
            {
                var availableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails,
                                                                            activity,
                                                                            _requestDetail.Manufacturer,
                                                                            _requestDetail.physicalStore, ExpiryDate);

                result.Add(new ActivityViewModel()
                               {
                                   ActivityID = activity.ActivityGroupID,
                                   Name = activity.Name,
                                   IsDeliveryNote = activity.IsDeliveryNote,
                                   Quantity = availableStock.Sum(s => s.Quantity)
                               });
            }

            var noPAvailableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails, null,
                                                                           _requestDetail.Manufacturer,
                                                                           _requestDetail.physicalStore, ExpiryDate);

            result.Add(new ActivityViewModel() {
                                   ActivityID = "0",
                                   Name = "All Activities",
                                   IsDeliveryNote = false,
                                   Quantity = noPAvailableStock.Sum(s => s.Quantity)
                               });
            return result.Where(r => r.Quantity > 0).ToList();

        }

        public string ExpiryDateString
        {
            get { return ExpiryDate == null ? "-" : ((DateTime)ExpiryDate).TimeAgo(); }
        }

        public ICollection<ManufacturerViewModel> getManufacturerViewModels()
        {
            var manufacturers = _stockInformations.GroupBy(s => new { s.Manufacturer }).Select(s => s.Key.Manufacturer).ToList();
            var result = new Collection<ManufacturerViewModel>();

            foreach (var manufacturer in manufacturers)
            {

                var availableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails,
                                                                            _requestDetail.ActivityGroup,
                                                                            manufacturer, _requestDetail.physicalStore,
                                                                            ExpiryDate);
                result.Add(new ManufacturerViewModel()
                               {
                                   ManufacturerID = manufacturer.ManufacturerID,
                                   Name = manufacturer.Name,
                                   CountryOfOrigin = manufacturer.CountryOfOrigin,
                                   Quantity = availableStock.Sum(s => s.Quantity)
                               })
                    ;
            }
            var noPAvailableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails, _requestDetail.ActivityGroup, null,
                                                                   _requestDetail.physicalStore, ExpiryDate);
            result.Add(new ManufacturerViewModel()
                           {
                               ManufacturerID = 0,
                               Name = "No Preferences",
                               Quantity = noPAvailableStock.Sum(s => s.Quantity)
                           });

            return result.Where(r => r.Quantity > 0).ToList();
        }

        public ICollection<PhysicalStoreViewModel> getPhysicalStoreViewModels()
        {
            var physicalStores = _stockInformations.GroupBy(s => new { s.PhysicalStore }).Select(s => s.Key.PhysicalStore).ToList();
            var result = new Collection<PhysicalStoreViewModel>();

            ICollection<StockInformation> availableStock;
            foreach (var physicalStore in physicalStores)
            {
                availableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails, _requestDetail.ActivityGroup,
                                                                   _requestDetail.Manufacturer,
                                                                   physicalStore, ExpiryDate);
                result.Add(new PhysicalStoreViewModel
                {
                    PhysicalStoreID = physicalStore.PhysicalStoreID,
                    Name = physicalStore.Name,
                    Quantity = availableStock.Sum(s => s.Quantity)
                });
            }

         
             availableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails, _requestDetail.ActivityGroup,
                                                               _requestDetail.Manufacturer,
                                                               null, ExpiryDate);
            result.Add(new PhysicalStoreViewModel()
                           {
                               PhysicalStoreID = 0,
                               Name = "No Preferences",
                               Quantity = availableStock.Sum(s => s.Quantity)
                           });

            return result.Where(r => r.Quantity > 0).ToList();
        }

        public ICollection<ExpiryDateViewModel> getExpiryDateViewModels()
        {
            var expiryDates = _stockInformations.GroupBy(s => new { s.ExpiryDate }).Select(s => s.Key.ExpiryDate).ToList();
            var result = new Collection<ExpiryDateViewModel>();
            ICollection<StockInformation> availableStock; foreach (var expiryDate in expiryDates)
            {
                
                availableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails,_requestDetail.ActivityGroup,
                                                                      _requestDetail.Manufacturer,
                                                                      _requestDetail.physicalStore, expiryDate);
                result.Add(
                   new ExpiryDateViewModel()
                   {
                       Value = expiryDate,
                       Text = string.Format("{0: dd/M/yyyy}", expiryDate),
                       DaysAgo = expiryDate == null? "-" : ((DateTime)expiryDate).TimeAgo(),
                       Quantity = availableStock.Sum(s => s.Quantity)
                   })
                ;
            }
             availableStock = PreferenceCalculator.GetAvailableStock(_stockInformations, _approvedDetails,_requestDetail.ActivityGroup,
                                                                   _requestDetail.Manufacturer,
                                                                   _requestDetail.physicalStore, null);
            result.Add(new ExpiryDateViewModel()
            {
                Value = null,
                Text = "No Preferences",
                Quantity = availableStock.Select(s => s.Quantity).Sum()
            });


            return result.Where(r => r.Quantity > 0).ToList();
        }

        public bool HasManyActivity
        {
            get { return _hasManyActivity; }
            set { _hasManyActivity = value; }
        }

        public bool HasManyManufacturer
        {
            get { return _hasManyManufacturer; }
            set { _hasManyManufacturer = value; }
        }

        public bool HasExpiryDatePreference
        {
            get { return _hasExpiryDatePreference; }
            set { _hasExpiryDatePreference = value; }
        }

        public bool HasPhysicalStorePreference
        {
            get { return _hasPhysicalStorePreference; }
            set { _hasPhysicalStorePreference = value; }
        }

        public bool AllowAdd
        {
            get { return _allowAdd; }
            set { _allowAdd = value; }
        }

        public bool AllowRemove
        {
            get { return _allowRemove; }
            set { _allowRemove = value; }
        }

        #endregion

        #region Client Information Properties

        public decimal ApprovedQuantity
        {
            get { return _requestDetail.ApprovedQuantity; }
            set
            {
                _requestDetail.StockedOut = AvailableQuantity < _requestDetail.RequestedQuantity && AvailableQuantity == value;
                _requestDetail.ApprovedQuantity = value;
            }
        }

        public decimal RequestedQuantity
        {
            get { return _requestDetail.RequestedQuantity; }
        }

        #endregion
    }
}

