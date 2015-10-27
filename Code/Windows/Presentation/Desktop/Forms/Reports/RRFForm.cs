using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout.Utils;
using HCMIS.Desktop.DirectoryServices;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.PLITSLookUpService;
using HCMIS.Desktop.PLITSTransactionalService;
using HCMIS.Desktop.Views;
using HCMIS.Helpers;
using Order = HCMIS.Desktop.PLITSTransactionalService.Order;
using OrderDetail = HCMIS.Desktop.PLITSTransactionalService.OrderDetail;

namespace HCMIS.Desktop.Forms.Reports
{
    [FormIdentifier("DI-RR-RR-FR", "RRF", "Generate RRF")]
    public partial class RrfForm : XtraForm
    {
        private int _storeID;
        private int _fromYear;
        private int _toYear;
        private int _fromMonth;
        private int _toMonth;
        private DataTable _tblRrf;
        private DataTable tblRRF;

        public RrfForm()
        {
            InitializeComponent();
        }

        private void RrfFormLoad(object sender, EventArgs e)
        {
            PopulateTheMonthCombos(cboFromMonth);
            PopulateTheMonthCombos(cboToMonth);
            PopulateTheYearCombo(cboFromYear);
            PopulateTheYearCombo(cboToYear);
            var stor = new Activity();
            stor.LoadAll();
            cboStores.Properties.DataSource = stor.DefaultView;
            PopulateRrFs();
            WindowVisibility(false);
            EnableDisableStatusCheck();

            btnAutoPushToPFSA.Enabled = BLL.Settings.AllowOnlineOrders;

        }

        private void PopulateRrFs()
        {
            var rrf = new RRF();
            grdRRF.DataSource = rrf.GetSavedRRFForDisplay();
            grdRRF.RefreshDataSource();
        }

        private void SetEndingMonthAndYear(int startingMonth, int startingYear)
        {
            if (startingMonth <= 11)
            {
                cboToMonth.EditValue = startingMonth + 1;
                cboToYear.EditValue = startingYear;
            }

            else //If the starting month is the 12th month. (The period will be from Nehassie of last year - Meskerem of the next year)
            {
                cboToMonth.EditValue = 1;
                cboToYear.EditValue = startingYear + 1;
            }
        }

        private static int GetStartingMonth(int currentMonth)
        {
            int startingMonth;
            if (currentMonth > 2)
            {
                startingMonth = currentMonth - 2;
            }
            else
            {
                startingMonth = 12 - currentMonth - 1;
            }

            return startingMonth;
        }

        private static int GetStartingYear(int currentMonth, int currentYear)
        {
            if (currentMonth <= 2)
            {
                return currentYear - 1;
            }
            return currentYear;
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void PopulateList()
        {
            _storeID = Convert.ToInt32(cboStores.EditValue);
            
            Items itm = new Items();

            _fromMonth = int.Parse(cboFromMonth.EditValue.ToString());
            _toMonth = int.Parse(cboToMonth.EditValue.ToString());
            _toYear = int.Parse(cboToYear.EditValue.ToString());
            _fromYear = int.Parse(cboFromYear.EditValue.ToString());

            var rrfHelper = new RRFItemHelper();
            _tblRrf = rrfHelper.GetRRFReport(_storeID, _fromYear, _fromMonth, _toYear, _toMonth);
            gridItemsChoice.DataSource = _tblRrf;

            ChooseGridView();
        }

        private static void PopulateTheYearCombo(ComboBoxEdit combo)
        {
            int[] years = new int[25];
            for (int i = 0; i < 25; i++)
            {
                years[i] = 2003 + i;
            }
            combo.Properties.Items.AddRange(years);
        }

        private static void PopulateTheMonthCombos(ComboBoxEdit combo)
        {
            int[] months = new int[12];
            for (int i = 0; i < 12; i++)
            {
                months[i] = i + 1;
            }
            combo.Properties.Items.AddRange(months);
        }

        private void cboStores_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboStores.EditValue == null) return;
            PopulateList();
        }

        private void dt_ValueChanged(object sender, EventArgs e)
        {
            //// TOFIX here,
            //// First day of 2003 is the first day of start of RRF
            //DateTime startDate = EthDate.EthiopianToGregorian("1/1/2003");
            //if (dtFrom.Value.Subtract(startDate).Days < 0)
            //{
            //    dtFrom.CustomFormat = "d/MM/yyyy";
            //    dtFrom.Value = startDate;
            //}
            //cboStores_SelectedValueChanged(null, null);
            //dtFrom.CustomFormat = "MMMM dd, yyyy";
        }

       
        private void btnAutoPushToPFSA_Click(object sender, EventArgs e)
        {
            if(!BLL.Settings.AllowOnlineOrders)
            {
                return;
            }
            var orders = GetOrders();
            var ginf = new GeneralInfo();
            ginf.LoadAll();
            var serviceModel = CompileOrder(ginf.FacilityID, orders);
            Send(serviceModel);
           
        }

        private int SaveRRF()
        {
            RRF rrf = new RRF();
            if (rrf.RRFExists(_storeID, _fromYear, _fromMonth, _toYear, _toMonth))
            {
                if (XtraMessageBox.Show("RRF Exists on disk, are you sure you want to replace it?", "RRF Save",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return -1;
            }
            int rrfID = rrf.AddNewRRF(_storeID, _fromYear, _fromMonth, _toYear, _toMonth, true);
            BLL.Item itm = new BLL.Item();
            DataTable dtbl1 = new DataTable();
            if (gridItemChoiceView.DataSource != null) dtbl1 = ((DataView)gridItemChoiceView.DataSource).Table;
            foreach (DataRow dr in dtbl1.Rows)
            {
                int itemID = Convert.ToInt32(dr["ID"]);
                int requestedqty = Convert.ToInt32(dr["Quantity"]);
                int storeID = int.Parse(cboStores.EditValue.ToString());
                RRFDetail rrfDetail = new RRFDetail();
                rrfDetail.AddNewRRFDetail(rrfID, storeID, itemID, requestedqty);

            }
            return rrf.ID;
        }

        public Collection<Order> GetOrders()
        {
            var orders = new Collection<Order>();
            _tblRrf = (DataTable)gridItemsChoice.DataSource;
            tblRRF = (DataTable)gridItemsChoice.DataSource;

            var info = new GeneralInfo();
            info.LoadAll();

            var client1 = new ServiceRRFLookupClient();
            var req = new GetCurrentReportingPeriodRequest
            {
                Password = RRFServiceIntegration.PlitsPassword,
                UserName = RRFServiceIntegration.PlitsUserName,
                Supplychainunitid = RRFServiceIntegration.GetBranchID()
            };

            var branchReq = new GetBranchRRFormRequest
            {
                UserName = RRFServiceIntegration.PlitsUserName,
                Password = RRFServiceIntegration.PlitsPassword,
                Supplychainunitid = RRFServiceIntegration.GetBranchID()
            };

            var formReq = new GetFormsRequest
            {
                Password = RRFServiceIntegration.PlitsPassword,
                UserName = RRFServiceIntegration.PlitsUserName,
                Supplychainunitid = RRFServiceIntegration.GetBranchID()
            };

            var forms = client1.GetForms(formReq).GetFormsResult;
            var formid = forms[0].Id;

            var periods = client1.GetCurrentReportingPeriod(req).GetCurrentReportingPeriodResult;
            var period = periods[0].Id;


            branchReq.Formid = formid;
            branchReq.Reportingperiodid = period;

            
            var chosenCatId = 91;//RRFHelper.GetRrfCategoryId(cboStores.Text);
            var rrfs = client1.GetBranchRRForm(branchReq).GetBranchRRFormResult;
            var formCategories = rrfs.First().FormCategories;
            var chosenCategoryBody = formCategories.First(x => x.Id == chosenCatId); //Hard coding to be removed.
            var items = chosenCategoryBody.Pharmaceuticals; //Let's just store the items here (May not be required)

            var user = new User();
            user.LoadByPrimaryKey(CurrentContext.LoggedInUser.ID);
            var order = new HCMIS.Desktop.PLITSTransactionalService.Order
            {
                //Id = (int)rrf["Id"],
                RequestCompletedDate = BLL.DateTimeHelper.ServerDateTime,//Convert.ToDateTime(rrf["DateOfSubmissionEth"]),
                OrderCompletedBy = user.FullName,
                RequestVerifiedDate = BLL.DateTimeHelper.ServerDateTime,
                OrderTypeId = 1, //This needs to be changed to constant class or something. 1 - Regular, 2 - Emergency'
                SubmittedBy = user.FullName,
                SubmittedDate = BLL.DateTimeHelper.ServerDateTime,
                SupplyChainUnitId = Helpers.RRFServiceIntegration.GetBranchID(),
                OrderStatus = 1,//TODO: hardcoding
                FormId = formid,//TODO: hardcoding
                ReportingPeriodId = period  //TODO: hardcoding
            };

            // order.OrderTypeId = (int)tblrrf.Rows[i]["RRfTpyeId"];
            // Set order properties

            //order.FormId = rrfForm.Id; //Form.ID? or RRFForm.ID? - doesn't make sense
            //  order.ReportingPeriodId = periods[0].Id; //Asked again here?  Because RRFForm already contains this.

            var details = new Collection<OrderDetail>();
            int i = 0;
            var xx = tblRRF.Rows.Count;
             
            foreach (DataRow rrfLine in tblRRF.Rows)
            {
                var detail = new PLITSTransactionalService.OrderDetail();
                var hcmisItemID = Convert.ToInt32(rrfLine["ID"]);
                var rrFormPharmaceutical = items.FirstOrDefault(x => x.PharmaceuticalId == Convert.ToInt32(rrfLine["ID"]));
                if (rrfLine != null && rrFormPharmaceutical!=null)
                {

                    detail.BeginningBalance = Convert.ToInt32(rrfLine["BeginingBalance"]);
                    //DaysOutOfStock daysOfStockOut = new DaysOutOfStock() { NumberOfDaysOutOfStock = 1 };
                    //detail.DaysOutOfStocks.Add(daysOfStockOut);//Convert.ToInt32(rrfLine["DaysOutOfStock"]);
                    int eBalance = Convert.ToInt32(rrfLine["SOH"]);
                    detail.EndingBalance = eBalance == 0 ? 1 : eBalance;  //To make sure ending balance is not zero.
                    //detail.ItemId = Convert.ToInt32(rrfLine["ID"]); //Needs to come from the Code column of Items table.
                    detail.QuantityReceived = Convert.ToInt32(rrfLine["Received"]);
                    detail.QuantityOrdered = Convert.ToInt32(rrfLine["Quantity"]);
                    detail.LossAdjustment = Convert.ToInt32(rrfLine["LossAdj"]);

                    
                    if (rrFormPharmaceutical != null)
                        detail.ItemId = rrFormPharmaceutical.ItemId;
                    else
                        throw new Exception("Item ID Mismatch");


                    var rdDoc = new ReceiveDoc();
                    var lossAndAdjustment = new LossAndAdjustment();
                    rdDoc.GetAllWithQuantityLeft(hcmisItemID, _storeID);
                    lossAndAdjustment.GetLossAdjustmentsForLastRRFPeriod(hcmisItemID, _storeID, periods[0].StartDate,
                                                                periods[0].EndDate);
                    int receiveDocEntries = rdDoc.RowCount;
                    int disposalEntries = lossAndAdjustment.RowCount;




                    rdDoc.Rewind();
                    for (var j = 0; j < receiveDocEntries; j++)
                    {
                        var exp = new Expiry
                                      {
                                          Amount = Convert.ToInt32(rdDoc.QuantityLeft),
                                          BatchNo = rdDoc.BatchNo,
                                          ExpiryDate = rdDoc.ExpDate
                                      };
                        detail.Expiries.Add(exp);
                        rdDoc.MoveNext();
                    }

                    lossAndAdjustment.Rewind();
                    for (var j = 0; j < disposalEntries; j++)
                    {
                        var adj = new Adjustment
                                      {Amount = Convert.ToInt32(lossAndAdjustment.Quantity), TypeId = 11, ReasonId = 39};

                        detail.Adjustments.Add(adj);
                        lossAndAdjustment.MoveNext();
                    }

                    var stockoutIndexedLists = StockoutIndexBuilder.Builder.GetStockOutHistory(hcmisItemID, _storeID);
                    

                    for (int j = 0; j < stockoutIndexedLists.Count; j++)
                    {
                        var dos = new DaysOutOfStock
                                      {
                                          NumberOfDaysOutOfStock = stockoutIndexedLists[j].NumberOfDays,
                                          StockOutReasonId = 5
                                      };

                        detail.DaysOutOfStocks.Add(dos);
                    }

                    details.Add(detail);
                }
                
            }
            order.OrderDetails = details;
            orders.Add(order);


            // loop through each record and create order & order details objects
            return orders;

            //var user = new User();
            //user.LoadByPrimaryKey(NewMainWindow.LoggedInUser.ID);
            //foreach (DataRow rrf in tblRRF.Rows)
            //{
            //    var order = new HCMIS.Desktop.PLITSTransactionalService.Order
            //    {
            //        Id = (int)rrf["Id"],
            //        RequestCompletedDate = DateTime.Now,//Convert.ToDateTime(rrf["DateOfSubmissionEth"]),
            //        OrderCompletedBy = user.FullName,
            //        RequestVerifiedDate = DateTime.Now,
            //        OrderTypeId = 1, //This needs to be changed to constant class or something. 1 - Regular, 2 - Emergency'
            //        SubmittedBy = user.FullName,
            //        SubmittedDate = DateTime.Now,
            //        SupplyChainUnitId = RRFServiceIntegration.BranchID,
            //        OrderStatus = 1,
            //        FormId = formid
            //    };
            //    // order.OrderTypeId = (int)tblrrf.Rows[i]["RRfTpyeId"];
            //    // Set order properties

            //    //order.FormId = rrfForm.Id; //Form.ID? or RRFForm.ID? - doesn't make sense
            //    //  order.ReportingPeriodId = periods[0].Id; //Asked again here?  Because RRFForm already contains this.

            //    var details = new Collection<OrderDetail>();

            //    foreach (DataRow rrfLine in tblRRF.Rows)
            //    {
            //        var detail = new PLITSTransactionalService.OrderDetail();
            //        var rrFormPharmaceutical = items.FirstOrDefault(x => x.ItemId == Convert.ToInt32(rrfLine["ID"]));
            //        if (rrfLine != null && rrFormPharmaceutical != null)
            //        //detail.Adjustments[0].Amount =  (int)rrfLine["Adjustments"];
            //        {
            //            detail.BeginningBalance = Convert.ToInt32(rrfLine["BeginingBalance"]);
            //            //detail.DaysOutOfStocks = Convert.ToInt32(rrfLine["DaysOutOfStock"]);
            //            detail.EndingBalance = Convert.ToInt32(rrfLine["SOH"]);
            //            //detail.ItemId = Convert.ToInt32(rrfLine["ID"]); //Needs to come from the Code column of Items table.
            //            detail.QuantityReceived = Convert.ToInt32(rrfLine["Received"]);
            //            detail.QuantityOrdered = Convert.ToInt32(rrfLine["Quantity"]);
            //            detail.LossAdjustment = Convert.ToInt32(rrfLine["LossAdj"]);

            //            if (rrFormPharmaceutical != null)
            //                detail.PharmaceuticalId = rrFormPharmaceutical.PharmaceuticalId;
            //            //  detail.PharmaceuticalId = Convert.ToInt32(rrfLine["ItemID"]);
            //            // detail.PharmaceuticalId = pharId;

            //        }
            //        details.Add(detail);
            //    }
            //    order.OrderDetails = details;
            //    orders.Add(order);
            //}

            //// loop through each record and create order & order details objects
            //return orders;
        }

        /// <summary>
        /// Compiles a RRF Order that will be used by Send() method
        /// </summary>
        /// <returns>FacilityOrderViewModel</returns>
        private BranchOrderViewModel CompileOrder(int facilityID, System.Collections.ObjectModel.Collection<PLITSTransactionalService.Order> orders)
        {
            var fOrder = new BranchOrderViewModel
                             {
                                 FacilityID = RRFServiceIntegration.GetBranchID() ,
                                 Username = RRFServiceIntegration.PlitsUserName,
                                 Password = RRFServiceIntegration.PlitsPassword,
                                 Orders = orders
                             };
            Send(fOrder);
            return fOrder;
        }

        private void Send(BranchOrderViewModel fOrder)
        {
            var client = new ServiceOrderClient(new BasicHttpBinding(BasicHttpSecurityMode.None)
            {
                MaxReceivedMessageSize = 2147483647,
                MaxBufferSize = 2147483647,
                MaxBufferPoolSize = 2147483647

            },
                                               (new EndpointAddress("http://172.16.51.247:40301/Order/ServiceOrder.svc")));
            var result = client.SubmitBranchOrders(RRFServiceIntegration.GetBranchID(), fOrder.Orders, Helpers.RRFServiceIntegration.PlitsUserName, Helpers.RRFServiceIntegration.PlitsPassword);
            client.Close();
            var Message="";
            foreach (var ValidationMessage in result[0].ValidationMessages)
            {
                Message += ValidationMessage + "\n";
            }
            XtraMessageBox.Show(Message, "Order");
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            ProgressCheckingVisibility(true);
            btnCheckStatus.Enabled = false;
            bwRRFStatusCheck.RunWorkerAsync();
        }

        private void ProgressCheckingVisibility(bool visible)
        {
            lcCheckingProgress.Visibility = visible ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private void ProgressSubmitVisibility(bool visible)
        {
            lcSendingProgress.Visibility = visible ? LayoutVisibility.Always : LayoutVisibility.Never;
        }

        private void chkCalculateInPacks_CheckedChanged(object sender, EventArgs e)
        {
            ChooseGridView();
        }

        private void ChooseGridView()
        {
            gridItemsChoice.MainView = gridItemChoiceView;
        }

        private void cboFromYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFromMonth.EditValue == null || cboFromYear.EditValue == null) return;
            SetEndingMonthAndYear(Convert.ToInt32(cboFromMonth.EditValue), Convert.ToInt32(cboFromYear.EditValue));
            PopulateList();
        }

        private void cboFromMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFromMonth.EditValue == null || cboFromYear.EditValue == null) return;
            SetEndingMonthAndYear(Convert.ToInt32(cboFromMonth.EditValue), Convert.ToInt32(cboFromYear.EditValue));
            PopulateList();
        }

        private void grdRRF_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = grdViewRRFList.GetFocusedDataRow();
            if (dr == null)
                return;
            int rrfID = Convert.ToInt32(dr["ID"]);
            ShowRRFDetailWindow(rrfID);
            WindowVisibility(true);
        }

        private void ShowRRFDetailWindow(int rrfID)
        {
            Cursor = Cursors.WaitCursor;
            RRF rrf = new RRF();
            rrf.LoadByPrimaryKey(rrfID);
            cboFromMonth.EditValue = rrf.FromMonth;
            cboFromYear.EditValue = rrf.FromYear;
            cboToMonth.EditValue = rrf.ToMonth;
            cboToYear.EditValue = rrf.ToYear;
            cboStores.EditValue = rrf.RRFType;
            PopulateList();
            //Handle Edits here (Populate exact values from the database)
            if (!rrf.IsColumnNull("LastRRFStatus"))
            {
                if (rrf.LastRRFStatus == "" || rrf.LastRRFStatus.Contains("not") || rrf.LastRRFStatus.Contains("Not"))
                    btnAutoPushToPFSA.Enabled = true;
                else
                {
                    btnAutoPushToPFSA.Enabled = false;
                }
            }
            else
                btnAutoPushToPFSA.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WindowVisibility(false);
        }

        private void WindowVisibility(bool rrfDetailVisible)
        {
            if (rrfDetailVisible)
            {
                lcRRFInformation.Visibility = LayoutVisibility.Always;
                lcRRFList.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lcRRFInformation.Visibility = LayoutVisibility.Never;
                lcRRFList.Visibility = LayoutVisibility.Always;
            }

        }

        private void btnNewRRF_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var ethiopianDate = new EthiopianDate.EthiopianDate();
            int currentMonth = ethiopianDate.Month;
            int currentYear = ethiopianDate.Year;
            int startingMonth = GetStartingMonth(currentMonth);
            int startingYear = GetStartingYear(currentMonth, currentYear);
            cboFromMonth.EditValue = startingMonth;
            cboFromYear.EditValue = startingYear;
            SetEndingMonthAndYear(startingMonth, startingYear);
            cboStores.ItemIndex = 0;
            WindowVisibility(true);
            Cursor = Cursors.Default;

        }

        private void grdRRF_Click(object sender, EventArgs e)
        {
            EnableDisableStatusCheck();
        }

        private void EnableDisableStatusCheck()
        {
            try
            {

                btnCheckStatus.Enabled = grdViewRRFList.GetFocusedDataRow()["LastRRFStatus"].ToString() != "Order Dispatched";
            }
            catch
            {
                btnCheckStatus.Enabled = false;
            }
        }

        private void bwRRFSubmit_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void bwRRFSubmit_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //ProgressSubmitVisibility(false);
            //btnAutoPushToPFSA.Enabled = true;
        }

        private void gridItemChoiceView_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "gridColumn40")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
        }

        private void grdViewInPacks_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "gridColumn41")
                if (Convert.ToDecimal(e.Value) <= 0) e.DisplayText = "0";
        }


    }
}