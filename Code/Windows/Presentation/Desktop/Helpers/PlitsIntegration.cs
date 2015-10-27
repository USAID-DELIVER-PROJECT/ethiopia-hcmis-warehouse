using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.PLITSLookUpService;
using HCMIS.Desktop.PLITSTransactionalService;
using StockoutIndexBuilder;
using Order = BLL.Order;
using OrderDetail = BLL.OrderDetail;

namespace HCMIS.Desktop.Helpers
{

    class RRFServiceIntegration
    {

        #region VariableDecalaration

        public static string PlitsUserName
        {
            get
            {
                var arr = GeneralInfo.Current.Description.Split('|');
                return arr[2];
            }
        }


        public static string PlitsPassword
        {
            get
            {
                var arr = GeneralInfo.Current.Description.Split('|');
                return arr[3];
            }
        }

        public static int PharmacitucalsCommodityType;

        #endregion

        #region Transactions


        // Get and save PLITS approved order 


        public static bool PopulateHCMISOrdersFromPLITS()
        {

            var isSaved = BLL.Settings.IsCenter ? SaveBranchApprovedOrders() : SaveFacilityApprovedOrders();

            if (isSaved)
            {

                XtraMessageBox.Show("Approved order is successfully saved.", "Approved order", MessageBoxButtons.OK);
                return true;
            }

            return false; //This to be implemented.  If there is at least one order synced, this should return true.  Otherwise, it should return false.
        }



        // Save Branch and Facility approved order 

        public static bool SaveFacilityApprovedOrders()
        {
            using (var tsvc = new ServiceOrderClient())
            {

                if (GetFacilityApprovedOrdersCount() == 0)
                {
                    XtraMessageBox.Show("No approved order exist.", "Approved order count", MessageBoxButtons.OK);
                    return false;
                }
                var plitsApprovedOrders = tsvc.GetFacilityApprovedOrders(GetBranchID(), PlitsUserName, PlitsPassword);

                if (plitsApprovedOrders.Count == 0)
                    return false;
                var orderIDs = new Collection<int>();
                foreach (ApprovedOrder plitsApprovedOrder in plitsApprovedOrders)
                {


                    var orderID = BLL.Order.SavePLITSApprovedOrderToDatabase(OrderStatus.Constant.ORDER_FILLED, CurrentContext.UserId,
                                                                plitsApprovedOrder.Id,
                                                                Convert.ToInt32(plitsApprovedOrder.SupplyChainUnitId),
                                                                Convert.ToInt32(PaymentType.Constants.STV),
                                                                Convert.ToInt32(Mode.Constants.HEALTH_PROGRAM), "PLITS", "",
                                                                "", GetOrderDetail(plitsApprovedOrder.Id, plitsApprovedOrder.ApprovedOrderDetails));
                    orderIDs.Add(orderID);



                }

                Helpers.RRFServiceIntegration.ConfirmApprovedOrder(orderIDs);

                return true;
            }

        }

        public static bool SaveBranchApprovedOrders()
        {
            using (var tsvc = new ServiceOrderClient())
            {

                if (GetBranchApprovedOrdersCount() == 0)
                {
                    XtraMessageBox.Show("No approved order exist.", "Approved order count", MessageBoxButtons.OK);
                    return false;
                }

                var plitsApprovedOrders = tsvc.GetBranchApprovedOrders(PlitsUserName, PlitsPassword);
                foreach (ApprovedOrder plitsApprovedOrder in plitsApprovedOrders)
                {

                    BLL.Order.SavePLITSApprovedOrderToDatabase(OrderStatus.Constant.ORDER_FILLED, CurrentContext.UserId,
                                                               plitsApprovedOrder.Id,
                                                               Convert.ToInt32(GetBranchID()),
                                                               Convert.ToInt32(PaymentType.Constants.STV),
                                                               Convert.ToInt32(Mode.Constants.RDF), "PLITS", "",
                                                               "", GetOrderDetail(plitsApprovedOrder.Id, plitsApprovedOrder.ApprovedOrderDetails));
                }
                return true;
            }


        }


        // Get Branch and Facility approved order count

        private static int GetFacilityApprovedOrdersCount()
        {
            using (var tsvc = new ServiceOrderClient())
            {
                try
                {
                    return tsvc.GetFacilityApprovedOrdersCount(GetBranchID(), PlitsUserName, PlitsPassword);
                }
                catch (Exception e)
                {

                    throw e.InnerException;
                }

            }

        }

        private static int GetBranchApprovedOrdersCount()
        {
            using (var tsvc = new ServiceOrderClient())
            {
                return tsvc.GetBranchApprovedOrdersCount(PlitsUserName, PlitsPassword);
            }

        }


        private static void ConfirmBranchApprovedOrder(int hcmisOrderID)
        {
            var tsvc = new ServiceOrderClient();
            var issuedList = new Collection<Issuance>();

            BLL.Order order = new Order();
            order.LoadByPrimaryKey(hcmisOrderID);

            var collOrders = new Collection<int>();
            while (!order.EOF)
            {
                collOrders.Add(order.HCTSReferenceID);
                order.MoveNext();
            }

            try
            {
                tsvc.ConfirmBranchApprovedOrders(collOrders, PlitsUserName, PlitsPassword);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }

        }


        private static void ConfirmFacilityApprovdOrder(int hcmisOrderID)
        {
            var tsvc = new ServiceOrderClient();
            var issuedList = new Collection<Issuance>();

            BLL.Order order = new Order();
            order.LoadByPrimaryKey(hcmisOrderID);

            var collOrders = new Collection<int>();
            while (!order.EOF)
            {
                collOrders.Add(order.HCTSReferenceID);
                order.MoveNext();
            }
            try
            {
                tsvc.ConfirmFacilityApprovedOrders(GetBranchID(), collOrders, PlitsUserName, PlitsPassword);
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        // Submit Branch and Facility Issues

        private static void SubmitFacilityIssues(int hcmisOrderID)
        {
            var tsvc = new ServiceOrderClient();
            var issuedList = new Collection<Issuance>();

            BLL.OrderDetail hcmisOrderDetail = new OrderDetail();
            hcmisOrderDetail.LoadOrderDetailsWithIssueAndPicklistForPLITS(hcmisOrderID);

            while (!hcmisOrderDetail.EOF)
            {
                var issuance = new Issuance
                                 {
                                     DateIssued = Convert.ToDateTime(hcmisOrderDetail.GetColumn("EurDate")),
                                     ApprovedOrderDetailId = Convert.ToInt32(hcmisOrderDetail.GetColumn("HACTOrderDetailID")),
                                     QuantityIssued = Convert.ToInt32(hcmisOrderDetail.GetColumn("NoOfPack"))
                                 };
                issuedList.Add(issuance);
                hcmisOrderDetail.MoveNext();
            }



            var validationmessage = tsvc.SubmitFacilityIssues(GetBranchID(), issuedList, PlitsUserName, PlitsPassword);
            XtraMessageBox.Show(validationmessage[0].Message, "Issuance", MessageBoxButtons.OK);
        }


        private static void SubmitBranchIssues(int hcmisOrderID)
        {
            var tsvc = new ServiceOrderClient();
            var issuedList = new Collection<Issuance>();

            BLL.OrderDetail hcmisOrderDetail = new OrderDetail();
            hcmisOrderDetail.LoadOrderDetailsWithIssueAndPicklistForPLITS(hcmisOrderID);

            while (!hcmisOrderDetail.EOF)
            {
                var issuance = new Issuance
                {
                    DateIssued = Convert.ToDateTime(hcmisOrderDetail.GetColumn("EurDate")),
                    ApprovedOrderDetailId = Convert.ToInt32(hcmisOrderDetail.GetColumn("HACTOrderDetailID")),
                    QuantityIssued = Convert.ToInt32(hcmisOrderDetail.GetColumn("NoOfPack"))
                };
                issuedList.Add(issuance);
                hcmisOrderDetail.MoveNext();
            }


            var validationmessage = tsvc.SubmitBranchIssues(issuedList, PlitsUserName, PlitsPassword);
            XtraMessageBox.Show(validationmessage[0].Message, "Issuance", MessageBoxButtons.OK);




        }

        // Get Order and order Detail

        private static Collection<int> GetapprovedOrderIDs()
        {
            var orderIDs = new Collection<int>();
            var o = new Order();
            foreach (var order in o.GetPLITSApprovedOrders(CurrentContext.UserId, Mode.Constants.RDF))
            {
                orderIDs.Add(Convert.ToInt32(o.ID));
            }

            return orderIDs;
        }

        private static BLL.OrderDetail GetOrderDetail(int? orderID, IEnumerable<ApprovedOrderDetail> plitsApprovedOrderDetails)
        {
            var hcmisOrderDetail = new BLL.OrderDetail();
            //var plitsApprovedOrderDetails = plitsApprovedOrderDetail as List<ApprovedOrderDetail> ?? plitsApprovedOrderDetail.ToList();
            foreach (var plitsOrderDetail in plitsApprovedOrderDetails)
            {
                hcmisOrderDetail.AddNew();
                hcmisOrderDetail.ItemID = plitsOrderDetail.PharmaceuticalId;
                hcmisOrderDetail.HACTOrderDetailID = plitsOrderDetail.Id;
                hcmisOrderDetail.Pack = Convert.ToDecimal(plitsOrderDetail.ApprovedQty);

                BLL.ItemUnit iu = new ItemUnit();
                iu.LoadAllForItem(plitsOrderDetail.PharmaceuticalId); //Just load it by item id.  This loads a collection but we just pick and use the first one. :)

                if (iu.RowCount == 0)
                {
                    hcmisOrderDetail.QtyPerPack = iu.QtyPerUnit;
                    hcmisOrderDetail.Quantity = hcmisOrderDetail.Pack * iu.QtyPerUnit;
                    hcmisOrderDetail.UnitID = iu.ID;
                    throw new Exception(string.Format("IU Not Configured correctly for item: {0}",
                                                      plitsOrderDetail.PharmaceuticalId));
                }

                hcmisOrderDetail.QtyPerPack = iu.QtyPerUnit;
                hcmisOrderDetail.Quantity = hcmisOrderDetail.Pack * iu.QtyPerUnit;
                hcmisOrderDetail.UnitID = iu.ID;
            }


            return hcmisOrderDetail;
        }

        #endregion

        #region Helpers


        public static int GetBranchID()
        {
            var x = new BLL.GeneralInfo();
            x.LoadAll();
            return x.FacilityID;
        }


        #endregion


        internal static void ConfirmApprovedOrder(Collection<int> orderIDs)
        {
            foreach (var orderID in orderIDs)
            {
                if (BLL.Order.IsItAnOnlineOrder(orderID))
                {

                    if (BLL.Settings.IsCenter)
                    {
                        ConfirmBranchApprovedOrder(orderID);
                    }
                    else
                    {
                        ConfirmFacilityApprovdOrder(orderID);
                    }



                }
            }


        }

        internal static void SubmitOnlineIssue(int _orderID)
        {
            if (BLL.Order.IsItAnOnlineOrder(_orderID))
            {
                if (BLL.Settings.IsCenter)
                {
                    SubmitBranchIssues(_orderID);
                }
                else
                {
                    SubmitFacilityIssues(_orderID);
                }
            }

        }
    }

    public class RRFItemHelper : Item
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="fromYear">In Ethiopian Calendar</param>
        /// <param name="fromMonth">In Ethiopian Calendar</param>
        /// <param name="toYear">In Ethiopian Calendar</param>
        /// <param name="toMonth">In Ethiopian Calendar</param>
        /// <returns></returns>
        public DataTable GetRRFReport(int storeId, int fromYear, int fromMonth, int toYear, int toMonth)
        {
            var startDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 1, fromMonth, fromYear));
            var endDate = EthiopianDate.EthiopianDate.EthiopianToGregorian(String.Format("{0}/{1}/{2}", 30, toMonth, toYear));
            if (fromMonth != 1)
                fromMonth--;
            else
            {
                fromYear--;
                fromMonth = 12;//Because SOH returns stock until the end of the month
            }
            DataTable dtbl = Balance.GetSohForAllItems(storeId, RRFServiceIntegration.PharmacitucalsCommodityType,
                                                       fromYear, fromMonth);
            DataTable dtbl2 = Balance.GetSohForAllItems(storeId, RRFServiceIntegration.PharmacitucalsCommodityType,
                                                        toYear, toMonth);


            var dt1 = new DateTime(fromYear, fromMonth, DateTime.DaysInMonth(fromYear, fromMonth));
            var dt2 = new DateTime(toYear, toMonth, DateTime.DaysInMonth(toYear, toMonth));

            var query = string.Format("select distinct Item.ID, isnull(Quantity,0) as Quantity ,UnitID from Item left join (select distinct ItemID,UnitID, sum(Quantity) as Quantity from ReceiveDoc where [Date] between '{0}' and '{1}' and" + " StoreID = {2} group by ItemID ,UnitID) as A on Item.ID = A.ItemID", dt1, dt2, storeId);
            LoadFromRawSql(query);
            var received = DataTable;

            query = string.Format("select distinct Item.ID, isnull(Quantity,0) as Quantity ,UnitID from Item left join (select distinct ItemID,UnitID, sum(Quantity) Quantity from IssueDoc id where [Date] between '{0}' and '{1}' and StoreID = {2} group by ItemID,UnitID) as A on Item.ID = A.ItemID", dt1, dt2, storeId);
            LoadFromRawSql(query);
            var issued = DataTable;

            query = string.Format("select distinct Item.ID, isnull(Quantity,0) as Quantity ,U from Item left join (select distinct ItemID,sum(case when Losses = 1 then -Quantity else Quantity end) Quantity from LossAndAdjustment d where [Date] between '{0}' and '{1}' and d.StoreID = {2} group by ItemID) as A on Item.ID = A.ItemID", dt1, dt2, storeId);
            LoadFromRawSql(query);
            DataTable lost = DataTable;

            query = string.Format("select distinct Item.ID,Item.StockCodeDACA,Item.Cost, case Item.Cost when 0 then 1 else isnull(Item.Cost,1) end as QtyPerPack from Item");
            LoadFromRawSql(query);

            var preferredPackSizetbl = DataTable;

            new Item();
            //DataTable daysOutOfStock = GetItemsWithLastIssuedOrDisposedDate();
            var x = (from y in dtbl.AsEnumerable() join z in dtbl2.AsEnumerable()
                     on y["ID"] equals z["ID"] join p in preferredPackSizetbl.AsEnumerable()
                     on y["ID"] equals p["ID"] where Convert.ToInt32(y["EverReceived"]) == 1
                     select new
                     {
                         ID = y["ID"],
                         FullItemName = y["FullItemName"],
                         Unit = y["Unit"],
                         StockCode = y["StockCode"],
                         BeginingBalance = Convert.ToInt32(y["SOH"]),
                         SOH = Convert.ToInt32(z["SOH"]),
                         Max = Convert.ToInt32(z["Max"]),
                         QtyPerPack = Convert.ToInt32(p["QtyPerPack"]),
                         StockCodeDACA = p["StockCodeDACA"]
                     }).Distinct().ToArray();

            var m = (from n in x join z in received.AsEnumerable() on n.ID equals z["ID"]
                     select new
                     {
                         n.ID,
                         n.FullItemName,
                         n.Unit,
                         n.StockCode,
                         n.BeginingBalance,
                         n.SOH,
                         n.Max,
                         n.QtyPerPack,
                         n.StockCodeDACA,
                         Received = z["Quantity"]
                     }).ToArray();

            var l = (from n in m join z in issued.AsEnumerable() on n.ID equals z["ID"]
                     select
                         new
                         {
                             n.ID,
                             n.FullItemName,
                             n.Unit,
                             n.StockCode,
                             n.BeginingBalance,
                             n.SOH,
                             Max = Convert.ToInt32(z["Quantity"]) * 2,
                             n.StockCodeDACA,
                             n.QtyPerPack,
                             n.Received,
                             Issued = Convert.ToInt32(z["Quantity"])
                         }).ToArray();

            var t = (from n in l join z in lost.AsEnumerable() on n.ID equals z["ID"]
                     select new
                     {
                         n.ID,
                         n.FullItemName,
                         n.Unit,
                         n.StockCode,
                         n.BeginingBalance,
                         n.SOH,
                         n.Max,
                         n.StockCodeDACA,
                         n.QtyPerPack,
                         n.Received,
                         n.Issued,
                         LossAdj = z["Quantity"],
                         Quantity = (n.Max - n.SOH < 0) ? 0 : n.Max - n.SOH
                     }).ToArray();

            //var t1 = (from n in t join z in daysOutOfStock.AsEnumerable() on n.ID equals z["ID"]
            //          select
            //              new
            //              {
            //                  n.ID,
            //                  n.FullItemName,
            //                  n.Unit,
            //                  n.StockCode,
            //                  n.BeginingBalance,
            //                  n.SOH,
            //                  n.Max,
            //                  n.StockCodeDACA,
            //                  n.QtyPerPack,
            //                  n.Received,
            //                  n.Issued,
            //                  n.LossAdj,
            //                  Quantity = (n.Max - n.SOH < 0) ? 0 : n.Max - n.SOH,
            //                  DaysOutOfStock = Builder.CalculateStockoutDays(Convert.ToInt32(n.ID), storeId, startDate, endDate)//Builder.CalculateStockoutDays(Convert.ToInt32(ID), storeId, startDate,endDate) DBNull.Value ? 0 : (Convert.ToInt32(z["DaysOutOfStock"]) < 60 ? z["DaysOutOfStock"] : 0)
            //              }).ToArray();

            var t2 = (from n in t
                      select
                          new
                          {
                              n.ID,
                              n.FullItemName,
                              n.Unit,
                              n.StockCode,
                              n.BeginingBalance,
                              n.SOH,
                              n.Max,
                              n.StockCodeDACA,
                              n.QtyPerPack,
                              n.Received,
                              n.Issued,
                              n.LossAdj,
                              Quantity = (n.Max - n.SOH < 0) ? 0 : n.Max - n.SOH,
                              //DaysOutOfStock = Builder.CalculateStockoutDays(Convert.ToInt32(n.ID), storeId, startDate, endDate),//TODO: This is a quick fix.  We need to take stock status from the last three months.
                              //TODO: This is a quick fix.  We need to take stock status from the last three months.
                             // MaxStockQty = ((120 * n.Issued) / (60 - Convert.ToInt32(Builder.CalculateStockoutDays(Convert.ToInt32(n.ID), storeId, startDate, endDate),)))
                          }).ToArray();

            //return t;
            // Converting shit into antoher shit.
            // Just because i was not able to read the elemntes of the anonymus type in another method
            var value = new DataTable();
            value.Columns.Add("ID", typeof(int));
            value.Columns.Add("FullItemName");
            value.Columns.Add("Unit");
            value.Columns.Add("StockCode");
            value.Columns.Add("BeginingBalance", typeof(int));
            value.Columns.Add("SOH", typeof(int));
            value.Columns.Add("Max", typeof(int));
            value.Columns.Add("StockCodeDACA", typeof(string));
            value.Columns.Add("QtyPerPack", typeof(int));
            value.Columns.Add("Issued", typeof(int));
            value.Columns.Add("Received", typeof(int));
            value.Columns.Add("LossAdj", typeof(int));
            value.Columns.Add("Quantity", typeof(int));
            //value.Columns.Add("DaysOutOfStock", typeof(int));
            //value.Columns.Add("MaxStockQty", typeof(int));
            foreach (var v in t2)
            {
                DataRowView drv = value.DefaultView.AddNew();
                drv["ID"] = v.ID;
                drv["FullItemName"] = v.FullItemName;
                drv["Unit"] = v.Unit;
                drv["StockCode"] = v.StockCode;
                drv["BeginingBalance"] = v.BeginingBalance;
                drv["SOH"] = v.SOH;
                drv["Max"] = v.Max;
                drv["StockCodeDACA"] = v.StockCodeDACA;
                drv["QtyPerPack"] = v.QtyPerPack;
                drv["Issued"] = v.Issued;
                drv["Received"] = v.Received;
                drv["LossAdj"] = v.LossAdj;
                drv["Quantity"] = v.Quantity;
                //drv["DaysOutOfStock"] = Builder.CalculateStockoutDays(Convert.ToInt32(drv["ID"]), storeId, startDate, endDate);
                //drv["MaxStockQty"] = v.MaxStockQty;

            }

            return value;

        }


        public DataTable GetItemsWithLastIssuedOrDisposedDate()
        {
            var query = "select distinct * from Item itm left join (select ItemID, DATEDIFF(dd,max(Date),GETDATE()) as DaysOutOfStock from (select ItemID,Date from (select id.ItemID ItemID,max(id.EurDate) Date from IssueDoc id where id.ItemID in (select ItemID from ReceiveDoc rd group by ItemID having sum(rd.QuantityLeft)=0) group by id.ItemID) x union (select d.ItemID ItemID,max(d.EurDate) Date from LossAndAdjustment d where ItemID in (select ItemID from ReceiveDoc rd group by ItemID having sum(rd.QuantityLeft)=0) group by d.ItemID)) x group by x.ItemID ) as y on itm.ID=y.ItemID";
            this.LoadFromRawSql(query);
            return this.DataTable;
        }

    }

    public class BranchOrderViewModel
    {
        public int FacilityID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Collection<PLITSTransactionalService.Order> Orders { get; set; }
    }

    public class RRFHelper
    {

        public static int GetRrfCategoryId(string activityName)
        {
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



            var formcategories = client1.GetBranchRRForm(branchReq).GetBranchRRFormResult.First().FormCategories.ToList();

            switch (activityName)
            {
                case "Malaria":
                    return formcategories[0].Id;
                case "Leprosy":
                    return formcategories[1].Id;
                case "OI":
                    return formcategories[2].Id;
                case "Emergency":
                    return formcategories[3].Id;
                case "Family Health":
                    return formcategories[4].Id;
                case "RDF MDG":
                    return formcategories[5].Id;
                case "":
                    return formcategories[6].Id;

            }
            return 0;
        }



    }
}
