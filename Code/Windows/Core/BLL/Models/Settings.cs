
using System;
using System.Reflection;
using System.Collections.Generic;
namespace BLL
{
    public class Settings
    {
        // TODO: Remove the hardcode

        #region ForAllSettings
        /// <summary>
        /// Run this once to go through the database and create all the properties.
        /// </summary>
        public void IterateThroughAllProperties()
        {
            System.Type settingType = this.GetType();
            IList<PropertyInfo> properties = new List<PropertyInfo>(settingType.GetProperties());

            foreach (PropertyInfo prop in properties)
            {
                var propValue = prop.GetValue(this, null); //We just want to get the property here so that every one of them will be created
            }

        }


        #endregion

        #region CenterSetting

        private static bool _isCenter = false;

        public static bool IsCenter
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("IsCenter"))
                {
                    _isCenter = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("IsCenter", "False");
                    _isCenter = false;
                }
                return _isCenter;
            }
            set { _isCenter = value; }
        }

        private static bool _allowPreferedPhysicalStoreForAllItemsOnApproval  = false;
        public static bool AllowPreferedPhysicalStoreForAllItemsOnApproval
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("AllowPreferedPhysicalStoreForAllItemsOnApproval"))
                {
                    _allowPreferedPhysicalStoreForAllItemsOnApproval = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("AllowPreferedPhysicalStoreForAllItemsOnApproval", "False");
                    _allowPreferedPhysicalStoreForAllItemsOnApproval = false;
                }
                return _allowPreferedPhysicalStoreForAllItemsOnApproval;
            }
            set
            { _allowPreferedPhysicalStoreForAllItemsOnApproval = value; }
        }
        private static bool _IsDamageIncludedOnTotalFOB = false;
        public static bool IsDamageIncludedOnTotalFOB
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("IsDamageIncludedOnTotalFOB"))
                {
                    _IsDamageIncludedOnTotalFOB = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("IsDamageIncludedOnTotalFOB", "False");
                    _IsDamageIncludedOnTotalFOB = false;
                }
                return _IsDamageIncludedOnTotalFOB;
            }
            set { _IsDamageIncludedOnTotalFOB = value; }
        }

       
        /// <summary>
        /// Disables Invoice and PO edit after certain step of the receive
        /// </summary>
        private static int _DisableInvoiceEditAfterStepNo = 5;
        public static int DisableInvoiceEditAfterStepNo
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("DisableInvoiceEditAfterStep No"))
                {

                    _DisableInvoiceEditAfterStepNo = Convert.ToInt32(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("DisableInvoiceEditAfterStep No", "5");
               
                    _DisableInvoiceEditAfterStepNo = 5;
                }
                return _DisableInvoiceEditAfterStepNo;
            }
            set { _DisableInvoiceEditAfterStepNo = value; }
        }
        #endregion

        private static bool _issueUnPricedCommodities = false;
        
        public static bool IssueUnPricedCommodities
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("IssueUnPricedCommodities"))
                {
                    _issueUnPricedCommodities = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("IssueUnPricedCommodities", "False");
                    _issueUnPricedCommodities = false;
                }
                return _issueUnPricedCommodities;
            }

            set { _issueUnPricedCommodities = value; }
        }

        private static string _insuranceFormula = "(({0} * 0.0032) * 0.05) + ({0} * 0.0032) + 5";

        public static string InsuranceFormula
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("InsuranceFormula"))
                {
                    _insuranceFormula = Instance.Value;
                    if (_insuranceFormula == "Undefined")
                    {
                        BLL.SoftwareSettings.SetValue("InsuranceFormula", "(({0} * 0.0032) * 0.05) + ({0} * 0.0032) + 5");
                        _insuranceFormula = _insuranceFormula = "(({0} * 0.0032) * 0.05) + ({0} * 0.0032) + 5";
                    }
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("InsuranceFormula", "(({0} * 0.0032) * 0.05) + ({0} * 0.0032) + 5");
                    _insuranceFormula = "(({0} * 0.0032) * 0.05) + ({0} * 0.0032) + 5";
                }
                return _insuranceFormula;
            }
            set { _insuranceFormula = value; }
        }

        private static bool _useHeadedStv = true;

        ///<summary>
        /// Decides if the header of the STV should be printed or not.
        ///</summary>
        public static bool UseHeadedSTV
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("UseHeadedPaper"))
                {
                    _useHeadedStv = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    _useHeadedStv = true;
                }

                return _useHeadedStv;
            }
            set { _useHeadedStv = value; }
        }

        private static bool _useMovingAverageConfirmation = false;

        public static bool UseMovingAverageConfirmation
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("UseMovingAverageConfirmation"))
                {
                    _useMovingAverageConfirmation = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("UseMovingAverageConfirmation", "False");
                    _useMovingAverageConfirmation = false;
                }
                return _useMovingAverageConfirmation;
            }
            set { _useMovingAverageConfirmation = value; }
        }
        
        private static bool _useReceiveCostConfirmation = false;

        public static bool UseReceiveCostConfirmation
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("UseReceiveCostConfirmation"))
                {
                    _useReceiveCostConfirmation = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("UseReceiveCostConfirmation", "False");
                    _useReceiveCostConfirmation = false;
                }
                return _useReceiveCostConfirmation;
            }
            set { _useReceiveCostConfirmation = value; }
        }

        private static bool _ConsiderFullyReservedItemsAsStockedOut;
        
        public static bool ConsiderFullyReservedItemsAsStockedOut
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("FullyReservedItemsConsideredStockedOut"))
                {
                    _ConsiderFullyReservedItemsAsStockedOut = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("FullyReservedItemsConsideredStockedOut", "False");
                    _ConsiderFullyReservedItemsAsStockedOut = false;
                }
                return _ConsiderFullyReservedItemsAsStockedOut;
            }
            set { _ConsiderFullyReservedItemsAsStockedOut = value; }
        }

        /// <summary>
        /// Always returns true.  This property has essentially been depreacated.
        /// </summary>
        public static bool IsRdfMode
        {
            get
            {
                return true;
            }
        }


        ///<summary>
        /// Provides the long mesurement unit for display
        ///</summary>
        public static string LongMeasurmentUnit
        {
            get { return "Meter"; }
        }

        /// <summary>
        /// Provides the short Mesurment unit for display
        /// </summary>
        public static string ShortMeasurmentUnit
        {
            get { return "M"; }
        }

        #region PrintingProperties

        private static bool _useCustomSizedPaperForPrinting;
        public static bool UseCustomSizedPaperForPrinting
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                //Printing related settings.
                if (Instance.LoadValue("UseCustomSizedPaperForPrinting"))
                {
                    _useCustomSizedPaperForPrinting = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    _useCustomSizedPaperForPrinting = false;
                }
                return _useCustomSizedPaperForPrinting;
            }
            set { _useCustomSizedPaperForPrinting = value; }
        }

        private static double _paperWidth;
        public static double PaperWidth
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PaperWidth"))
                {
                    BLL.Settings.PaperWidth = Convert.ToDouble(Instance.Value);
                }
                else
                {
                    //If the width hasn't been correctly set, we make the printing use non custom size.
                    BLL.Settings.UseCustomSizedPaperForPrinting = false;
                }
                return _paperWidth;
            }
            set
            {
                _paperWidth = value;
            }
        }

        private static double _paperHeight;
        public static double PaperHeight
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PaperHeight"))
                {
                    BLL.Settings.PaperHeight = Convert.ToDouble(Instance.Value);
                }
                else
                {
                    //If the height hasn't been correctly set, we make the printing use non custom size.
                    BLL.Settings.UseCustomSizedPaperForPrinting = false;
                }
                return _paperHeight;
            }
            set
            {
                _paperHeight = value;
            }
        }

        private static bool _UseCustomSizedPaperForPrintingCredit;
        public static bool UseCustomSizedPaperForPrintingCredit
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                //Printing related settings.
                if (Instance.LoadValue("UseCustomSizedPaperForPrintingCredit"))
                {
                    _UseCustomSizedPaperForPrintingCredit = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("UseCustomSizedPaperForPrintingCredit", "True");
                    _UseCustomSizedPaperForPrintingCredit = true;
                }
                return _UseCustomSizedPaperForPrintingCredit;
            }
            set { _UseCustomSizedPaperForPrintingCredit = value; }
        }

        private static double _PaperWidthCredit;
        public static double PaperWidthCredit
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PaperWidthCredit"))
                {
                    BLL.Settings.PaperWidthCredit = Convert.ToDouble(Instance.Value);
                }
                else
                {
                    //If the width hasn't been correctly set, we make the printing use non custom size.
                    BLL.SoftwareSettings.SetValue("PaperWidthCredit", "3050");
                    BLL.Settings.UseCustomSizedPaperForPrintingCredit = false;
                }
                return _PaperWidthCredit;
            }
            set
            {
                _PaperWidthCredit = value;
            }
        }

        private static double _PaperHeightCredit;
        public static double PaperHeightCredit
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PaperHeightCredit"))
                {
                    BLL.Settings.PaperHeightCredit = Convert.ToDouble(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("PaperHeightCredit", "2450");
                    //If the height hasn't been correctly set, we make the printing use non custom size.
                    BLL.Settings.UseCustomSizedPaperForPrintingCredit = false;
                }
                return _PaperHeightCredit;
            }
            set
            {
                _PaperHeightCredit = value;
            }
        }

        //Cash---------------------------------------------------------------

        private static bool _UseCustomSizedPaperForPrintingCash;
        public static bool UseCustomSizedPaperForPrintingCash
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                //Printing related settings.
                if (Instance.LoadValue("UseCustomSizedPaperForPrintingCash"))
                {
                    _UseCustomSizedPaperForPrintingCash = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("UseCustomSizedPaperForPrintingCash", "True");
                    _UseCustomSizedPaperForPrintingCash = true;
                }
                return _UseCustomSizedPaperForPrintingCash;
            }
            set { _UseCustomSizedPaperForPrintingCash = value; }
        }

        private static double _PaperWidthCash;
        public static double PaperWidthCash
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PaperWidthCash"))
                {
                    BLL.Settings.PaperWidthCash = Convert.ToDouble(Instance.Value);
                }
                else
                {
                    //If the width hasn't been correctly set, we make the printing use non custom size.
                    BLL.SoftwareSettings.SetValue("PaperWidthCash", "3050");
                    BLL.Settings.UseCustomSizedPaperForPrintingCash = false;
                }
                return _PaperWidthCash;
            }
            set
            {
                _PaperWidthCash = value;
            }
        }

        private static double _PaperHeightCash;
        public static double PaperHeightCash
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PaperHeightCash"))
                {
                    BLL.Settings.PaperHeightCash = Convert.ToDouble(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("PaperHeightCash", "2450");
                    //If the height hasn't been correctly set, we make the printing use non custom size.
                    BLL.Settings.UseCustomSizedPaperForPrintingCash = false;
                }
                return _PaperHeightCash;
            }
            set
            {
                _PaperHeightCash = value;
            }
        }





        //--------------------------------------------------------------------



        #endregion

        private static bool _printMultipleCommodityTypesPerPage;
        public static bool PrintMultipleCommodityTypesPerPage
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PrintMultipleCommodityTypesPerPage"))
                {
                    _printMultipleCommodityTypesPerPage = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("PrintMultipleCommodityTypesPerPage", "False");
                    _printMultipleCommodityTypesPerPage = false;
                }
                return _printMultipleCommodityTypesPerPage;
            }
            set
            {
                _printMultipleCommodityTypesPerPage = value;
            }
        }


        private static bool _ShowMultipleStoresOnSTV;

        public static bool ShowMultipleStoresOnSTV
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("ShowMultipleStoresOnSTV"))
                {
                    _ShowMultipleStoresOnSTV = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("ShowMultipleStoresOnSTV", "True");
                    _ShowMultipleStoresOnSTV = true;
                }
                return _ShowMultipleStoresOnSTV;
            }
            set
            {
                _ShowMultipleStoresOnSTV = value;
            }
        }

        private static bool _privateCanGetFromMDGAndPBSLoaded = false;
        private static bool _privateCanGetFromMDGAndPBS;
        public static bool PrivateCanGetFromMDGAndPBS
        {
            get
            {
                if (!_privateCanGetFromMDGAndPBSLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("PrivateCanGetFromMDGAndPBS"))
                    {
                        _privateCanGetFromMDGAndPBS = Convert.ToBoolean(Instance.Value);
                        _privateCanGetFromMDGAndPBSLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("PrivateCanGetFromMDGAndPBS", "False");
                        _privateCanGetFromMDGAndPBS = false;
                    }
                }
                return _privateCanGetFromMDGAndPBS;
            }
            set
            {
                _privateCanGetFromMDGAndPBS = value;
            }
        }

        private static int _noOfDigitsAfterTheDecimalPoint;
        public static int NoOfDigitsAfterTheDecimalPoint
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("NoOfDigitsAfterTheDecimalPoint"))
                {
                    _noOfDigitsAfterTheDecimalPoint = int.Parse(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("NoOfDigitsAfterTheDecimalPoint", "2");
                    _noOfDigitsAfterTheDecimalPoint = 2;
                }
                return _noOfDigitsAfterTheDecimalPoint;
            }
            set
            {
                _noOfDigitsAfterTheDecimalPoint = value;
            }
        }

        private static bool _enforceBatchTracking;
        public static bool EnforceBatchTracking
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("EnforceBatchTracking"))
                {
                    _enforceBatchTracking = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("EnforceBatchTracking", "False");
                    _enforceBatchTracking = false;
                }
                return _enforceBatchTracking;
            }
            set
            {
                _enforceBatchTracking = value;
            }
        }

        private static bool _allowPreferredManufacturersLoaded = false;
        private static bool _allowPreferredManufacturers;
        public static bool AllowPreferredManufacturers
        {
            get
            {
                if (!_allowPreferredManufacturersLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("AllowPreferredManufacturers"))
                    {
                        _allowPreferredManufacturers = Convert.ToBoolean(Instance.Value);
                        _allowPreferredManufacturersLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("AllowPreferredManufacturers", "False");
                        _allowPreferredManufacturers = false;
                    }
                }
                return _allowPreferredManufacturers;
            }
            set
            {
                _allowPreferredManufacturers = value;
            }
        }

        private static bool _handleDeliveryNotesLoaded = false;
        private static bool _handleDeliveryNotes;
        public static bool HandleDeliveryNotes
        {
            get
            {
                if (!_handleDeliveryNotesLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("HandleDeliveryNotes"))
                    {
                        _handleDeliveryNotes = Convert.ToBoolean(Instance.Value);
                        _handleDeliveryNotesLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("HandleDeliveryNotes", "False");
                        _handleDeliveryNotes = false;
                    }
                }
                return _handleDeliveryNotes;
            }
            set
            {
                _handleDeliveryNotes = value;
            }
        }

        /// <summary>
        /// Make this 0 to leave reserved picklists indefinitely.
        /// </summary>
        private static int _noOfDaysPicklistStaysAfterPrinting;
        public static int NoOfDaysPicklistStaysAfterPrinting
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("NoOfDaysPicklistStaysAfterPrinting"))
                {
                    _noOfDaysPicklistStaysAfterPrinting = int.Parse(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("NoOfDaysPicklistStaysAfterPrinting", "3");
                    _noOfDaysPicklistStaysAfterPrinting = 3;
                }
                return _noOfDaysPicklistStaysAfterPrinting;
            }
            set
            {
                _noOfDaysPicklistStaysAfterPrinting = value;
            }
        }

        private static bool _allowPreferredPhysicalStoreLoaded = false;
        private static bool _allowPreferredPhysicalStore;
        public static bool AllowPreferredPhysicalStore
        {
            get
            {
                if (!_allowPreferredPhysicalStoreLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("AllowPreferredPhysicalStore"))
                    {
                        _allowPreferredPhysicalStore = Convert.ToBoolean(Instance.Value);
                        _allowPreferredPhysicalStoreLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("AllowPreferredPhysicalStore", "False");
                        _allowPreferredPhysicalStore = false;
                    }
                }
                return _allowPreferredPhysicalStore;
            }
            set
            {
                _allowPreferredPhysicalStore = value;
            }
        }

        private static bool _allowPreferredExpiryLoaded = false;
        private static bool _allowPreferredExpiry;
        public static bool AllowPreferredExpiry
        {
            get
            {
                if (!_allowPreferredExpiryLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("AllowPreferredExpiry"))
                    {
                        _allowPreferredExpiry = Convert.ToBoolean(Instance.Value);
                        _allowPreferredExpiryLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("AllowPreferredExpiry", "False");
                        _allowPreferredExpiry = false;
                    }
                }
                return _allowPreferredExpiry;
            }
            set
            {
                _allowPreferredExpiry = value;
            }
        }

        private static bool _handleGRV;
        public static bool HandleGRV
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("HandleGRV"))
                {
                    _handleGRV = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("HandleGRV", "False");
                    _handleGRV = false;
                }
                return _handleGRV;
            }
            set
            {
                _handleGRV = value;
            }
        }

        private static bool _blockWhenExpectingPriceChangeLoaded = false;
        private static bool _blockWhenExpectingPriceChange;
        public static bool BlockWhenExpectingPriceChange
        {
            get
            {
                if (!_blockWhenExpectingPriceChangeLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("BlockWhenExpectingPriceChange"))
                    {
                        _blockWhenExpectingPriceChange = Convert.ToBoolean(Instance.Value);
                        _blockWhenExpectingPriceChangeLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("BlockWhenExpectingPriceChange", "True");
                        _blockWhenExpectingPriceChange = true;
                    }
                }
                return _blockWhenExpectingPriceChange;
            }
            set
            {
                _blockWhenExpectingPriceChange = value;
            }
        }


        private static bool _skipBeginningBalancePricing;
        public static bool SkipBeginningBalancePricing
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("SkipBeginningBalancePricing"))
                {
                    _skipBeginningBalancePricing = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("SkipBeginningBalancePricing", "False");
                    _skipBeginningBalancePricing = false;
                }
                return _skipBeginningBalancePricing;
            }
            set
            {
                _skipBeginningBalancePricing = value;
            }
        }


        
        private static bool _DisableBeginningCosting;
        public static bool DisableBeginningCosting
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("DisableBeginningCosting"))
                {
                    _DisableBeginningCosting = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("DisableBeginningCosting", "True");
                    _DisableBeginningCosting = false;
                }
                return _DisableBeginningCosting;
            }
            set
            {
                _DisableBeginningCosting = value;
            }
        }

        private static bool _DisableBeginningBalanceReceipt;
        public static bool DisableBeginningBalanceReceipt
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("DisableBeginningBalanceReceipt"))
                {
                    _DisableBeginningBalanceReceipt = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("DisableBeginningBalanceReceipt", "False");
                    _DisableBeginningBalanceReceipt = false;
                }
                return _DisableBeginningBalanceReceipt;
            }
            set
            {
                _DisableBeginningBalanceReceipt = value;
            }
        }

        private static bool _ShowBeginningBalanceOnGRNF;
        public static bool ShowBeginningBalanceOnGRNF
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("ShowBeginningBalanceOnGRNF"))
                {
                    _ShowBeginningBalanceOnGRNF = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("ShowBeginningBalanceOnGRNF", "False");
                    _ShowBeginningBalanceOnGRNF = false;
                }
                return _ShowBeginningBalanceOnGRNF;
            }
            set
            {
                _ShowBeginningBalanceOnGRNF = value;
            }
        }

        private static bool _ShowMissingSTVsOnIssueLog;
        public static bool ShowMissingSTVsOnIssueLog
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("ShowMissingSTVsOnIssueLog"))
                {
                    _ShowMissingSTVsOnIssueLog = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("ShowMissingSTVsOnIssueLog", "False");
                    _ShowMissingSTVsOnIssueLog = false;
                }
                return _ShowMissingSTVsOnIssueLog;
            }
            set
            {
                _ShowMissingSTVsOnIssueLog = value;
            }
        }

        private static bool _isCheckQuotaOnIssueLoaded = false;
        private static bool _CheckQuotaOnIssue = false;
        public static bool CheckQuotaOnIssue
        {
            get
            {
                if (!_isCheckQuotaOnIssueLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("CheckQuotaOnIssue"))
                    {
                        _CheckQuotaOnIssue = Convert.ToBoolean(Instance.Value);
                        _isCheckQuotaOnIssueLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("CheckQuotaOnIssue", "False");
                        _CheckQuotaOnIssue = false;
                    }
                }
                return _CheckQuotaOnIssue;
            }

            set { _CheckQuotaOnIssue = value; }
        }

        private static bool _doNotIssueNearExpiryItemsLoaded = false;
        private static bool _doNotIssueNearExpiryItems;
        public static bool DoNotIssueNearExpiryItems
        {
            get
            {
                if (!_doNotIssueNearExpiryItemsLoaded)
                {
                    SoftwareSettings Instance = new SoftwareSettings();
                    if (Instance.LoadValue("DoNotIssueNearExpiryItems"))
                    {
                        _doNotIssueNearExpiryItems = Convert.ToBoolean(Instance.Value);
                        _doNotIssueNearExpiryItemsLoaded = true;
                    }
                    else
                    {
                        BLL.SoftwareSettings.SetValue("DoNotIssueNearExpiryItems", "True");
                        _doNotIssueNearExpiryItems = true;
                    }
                }
                return _doNotIssueNearExpiryItems;
            }

            set { _doNotIssueNearExpiryItems = value; }
        }


        private static bool _AllowCustomIssueOrder;
        public static bool AllowCustomIssueOrder
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("AllowCustomIssueOrder"))
                {
                    _AllowCustomIssueOrder = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("AllowCustomIssueOrder", "False");
                    _AllowCustomIssueOrder = false;
                }

                return _AllowCustomIssueOrder;
            }

            set { _AllowCustomIssueOrder = value; }
        }

      
        // non-new user management setting is not allowed
        public static bool UseNewUserManagement
        {
            get { return true; }
        }

        /// <summary>
        /// When this is set to true, it should use the smaller credit printout paper
        /// </summary>
        private static bool _UseSmallerCreditPrintout;
        public static bool UseSmallerCreditPrintout
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("UseSmallerCreditPrintout"))
                {
                    _UseSmallerCreditPrintout = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("UseSmallerCreditPrintout", "False");
                    _UseSmallerCreditPrintout = false;
                }

                return _UseSmallerCreditPrintout;
            }

            set { _UseSmallerCreditPrintout = value; }
        }


        /// <summary>
        /// When this is set to true, it should use the smaller cash printout paper
        /// </summary>
        private static bool _UseSmallerCashPrintout;
        public static bool UseSmallerCashPrintout
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("UseSmallerCashPrintout"))
                {
                    _UseSmallerCashPrintout = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("UseSmallerCashPrintout", "False");
                    _UseSmallerCashPrintout = false;
                }

                return _UseSmallerCashPrintout;
            }

            set { _UseSmallerCashPrintout = value; }
        }


        /// <summary>
        /// When this is set to true, online orders to/from PLITS is enabled.
        /// </summary>
        private static bool _AllowOnlineOrders;
        public static bool AllowOnlineOrders
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("AllowOnlineOrders"))
                {
                    _AllowOnlineOrders = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("AllowOnlineOrders", "False");
                    _AllowOnlineOrders = false;
                }

                return _AllowOnlineOrders;
            }

            set { _AllowOnlineOrders = value; }
        }


        /// <summary>
        /// When this is set to true, back orders are enabled.
        /// </summary>
        private static bool _EnableBackOrders;
        public static bool EnableBackOrders
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("EnableBackOrders"))
                {
                    _EnableBackOrders = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("EnableBackOrders", "False");
                    _EnableBackOrders = false;
                }

                return _EnableBackOrders;
            }

            set { _EnableBackOrders = value; }
        }
        //

        private static string _BugTrackingURL;

        public static string BugTrackingURL
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("BugTrackingURL"))
                {
                    _BugTrackingURL = (Instance.Value);
                }
                else
                {
                    BLL.SoftwareSettings.SetValue("BugTrackingURL", @"http://jira.hcmis.org");
                    _BugTrackingURL = @"http://jira.hcmis.org";
                }

                return _BugTrackingURL;
            }
            set
            {
                _BugTrackingURL = value;
            }
        }

        private static bool _allowBonusReceive = false;

        public static bool AllowBonusReceive
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("AllowBonusReceive"))
                {
                    _allowBonusReceive = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("AllowBonusReceive", "False");
                    _allowBonusReceive = false;
                }
                return _allowBonusReceive;
            }
            set { _allowBonusReceive = value; }
        }

        private static bool _useCostTier = false;
        public static bool UseCostTier
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("UseCostTier"))
                {
                    _useCostTier = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("UseCostTier", "False");
                    _useCostTier = false;
                }
                return _useCostTier;
            }
            set { _useCostTier = value; }
        }


        private static bool _autoCancelExpiredPicklists = false;

        public static bool AutoCancelExpiredPicklists
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("AutoCancelExpiredPicklists"))
                {
                    _autoCancelExpiredPicklists = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("AutoCancelExpiredPicklists", "False");
                    _autoCancelExpiredPicklists = false;
                }
                return _autoCancelExpiredPicklists;
            }
            set { _autoCancelExpiredPicklists = value; }
        }

        private static bool _localvsTender;
        private static short _grnfCopies;
        private static bool _printUserNameOnInvoice;
        private static bool _showAllForWishList;
        private static int _stvCopies;

        public static bool LocalvsTender
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("LocalvsTender"))
                {
                    _localvsTender = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("LocalvsTender", "False");
                    _localvsTender = false;
                }
                return _localvsTender;
            }
            set { _localvsTender = value; }
        }

        public static short GRNFCopies
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("GRNFCopies"))
                {
                    _grnfCopies = Convert.ToInt16(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("GRNFCopies", "3");
                    _grnfCopies = 3;
                }
                return _grnfCopies;
            }
            set { _grnfCopies = value; }
        }

        public static bool PrintUserNameOnInvoice
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("PrintUserNameOnInvoice"))
                {
                    _printUserNameOnInvoice = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("PrintUserNameOnInvoice", "True");
                    _printUserNameOnInvoice = true;
                } 
                return _printUserNameOnInvoice;
            }
            set { _printUserNameOnInvoice = value; }
        }

        public static bool ShowAllForWishList
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("ShowAllForWishList"))
                {
                    _showAllForWishList = Convert.ToBoolean(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("ShowAllForWishList", "False");
                    _showAllForWishList = false;
                }
                return _showAllForWishList;
            }
            set { _showAllForWishList = value; }
        }

        public static int STVCopies
        {
            get
            {
                SoftwareSettings Instance = new SoftwareSettings();
                if (Instance.LoadValue("STVCopies"))
                {
                    _stvCopies = Convert.ToInt16(Instance.Value);
                }
                else
                {
                    // return the default value
                    BLL.SoftwareSettings.SetValue("STVCopies", "3");
                    _stvCopies = 3;
                }
                return _stvCopies;
            }
            set { _stvCopies = value; }
        }

        public static bool IsVaccine
        {
            /*
             handlegrv = false
            iscenter = false
            on Generalinfo the column value of
            institutionitye = 2
                         */
            get
            {
                return HandleGRV == false && IsCenter == false && GeneralInfo.Current.InstitutionITypeID == 2;
            }
        }
    }
}