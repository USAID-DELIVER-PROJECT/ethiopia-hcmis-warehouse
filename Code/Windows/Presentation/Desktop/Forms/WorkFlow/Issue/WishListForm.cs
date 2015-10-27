using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout.Utils;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Desktop.Views;
using HCMIS.Helpers;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Desktop.ImitationHCTS;
using Helpers;
using Order = BLL.Order;
using OrderDetail = BLL.OrderDetail;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.ViewModels;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    // Declare Requisition Type
    public enum RequisitionType
    {
        Demand = 3,
        Consumption = 4,
        History = 5,
        Population = 6,
    }
    //Range of days for history Type
    public enum Range {_2_Week =14,_Month =30,_6_Month =180,_Year =365, _Ever = -1};

    //[FormIdentifier("RQ-MA-NR-FR","Create new Requisition","")]
    public partial class WishListForm : XtraForm
    {
        #region Member Variables
        // For the first tab (Drug selection)
        //static Dictionary<int, DataTable> ItemChoices = new Dictionary<int, DataTable>();
        Dictionary<int, Dictionary<int, DataTable>> ItemChoices = new Dictionary<int, Dictionary<int, DataTable>>();

        // where all the selected items are stored
        DataTable _dtSelectedTable = null;

        // table that stores order for approval
        DataView _dvOrderTable = null;
        private int? OrderID;

        bool _gridIsValid = true;

        // declaring the Requisition Type
        RequisitionType Type =  RequisitionType.Demand;
        #endregion

        public WishListForm()
        {
            InitializeComponent();
            if (!BLL.Settings.IsVaccine)
            {
                VolumeMetricsPage.PageVisible = false;
                xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
                //xtraTabControl1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.WhenNeeded;
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Select the first comodity category
            //lkCategoires.ItemIndex = 0;

            BindFormElements();
            ResetOrder();
            EnableDisableButtons();

            if (BLL.Settings.IsCenter)
            {
                RequisitionTypelayoutControlItem.Visibility = LayoutVisibility.Never;
                HideUnhideColumn(null);
            }
            else
            {
                RequisitionTypelayoutControlItem.Visibility = LayoutVisibility.Always;
                HideUnhideColumn(RequisitionType.Demand);
            }
        }

        #region step one

        private void gridItemChoiceView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;
            dr["IsSelected"] = !b;
            OnItemCheckedChanged(new object(), new EventArgs());
            txtItemName.SelectAll();
            txtItemName.Focus();
        }

        private void BindFormElements()
        {
            // Find the next order number and write it on the order ID Field
            // The order ID is generated here in code

            DataTable tbl = BLL.CommodityType.GetAllTypes();
            tbl.Rows.Add(0, "All");
            lkCategoires.Properties.DataSource = tbl;
            //lkCategoires.ItemIndex = 0;
            lkCategoires.EditValue = 0;
            lkRequisitionType.EditValue = RequisitionType.Demand;
            // lkPeriod.Visible = false;


            //Bind the Region Lookup (Zone and Woredas will be bind after selection Region)
            lkRegion.Properties.DataSource = BLL.Region.GetAllRegions().DefaultView;
            if (!GeneralInfo.Current.IsColumnNull("Region"))
            {
                lkRegion.EditValue = GeneralInfo.Current.Region;
            }
            else
            {
                lkRegion.Properties.NullText = "Select Region";
            }
            //Bind the Receiving units Types Lookup
            InstitutionType institutionsTypes = new InstitutionType();
            institutionsTypes.LoadAll();
            institutionsTypes.Sort = "Name ASC";
            lkType.Properties.DataSource = institutionsTypes.DefaultView;
            lkType.EditValue = InstitutionType.Constants.HEALTH_CENTER;

            //Bind the Ownership Type Lookup
            LoadOwnershipType();
            lkOwnership.EditValue = OwnershipType.Constants.Public;
            LoadReceivingUnits();

            // txtRefNo.Text = Order.GetNextOrderReference();

            // bind the selected data table to the hidden grid on the CDR request screen

            LoadReceivingUnits();
            // load all the logical stores that exist in the system.
            lkModes.SetupModeEditor().SetDefaultMode();
            //if (BLL.Stores.GetDefaultStore(NewMainWindow.UserId).RowCount > 0 && !BLL.Stores.GetDefaultStore(NewMainWindow.UserId).IsColumnNull("ID"))
            //{
            //    lkModes.EditValue = BLL.Stores.GetDefaultStore(NewMainWindow.UserId).ID;
            //}
            //else
            //{
            //    lkModes.ItemIndex = 0;
            //    //lkModes.EditValue = null;
            //}
            //lkModes_EditValueChanged(null, null);
            boxSizedList.DataSource = BLL.ItemManufacturer.PackageLevelKeys;

            // Load all RRF Period 
            var periods = BLL.Period.GetAllPeriods();
            lkPeriod.Properties.DataSource = periods.DefaultView;

           // requisition Type: for the Time being it is hard coded 
            var requisitionTypes = Enum.GetValues(typeof(RequisitionType)).Cast<RequisitionType>()
                           .Select(e => new { Value = (int)e, Description = e.ToString() })
                           .ToList();
            //For this release - Mrach-20 remove consumption Type
            requisitionTypes.RemoveAt(requisitionTypes.IndexOf(new { Value = (int)RequisitionType.Consumption, Description = "Consumption" }));
            lkRequisitionType.Properties.DataSource = requisitionTypes;
        }

        /// <summary>
        /// there is diffrent reqtypeID across hubs
        /// so lets use the names as an identify
        /// </summary>
        /// <param name="requisitionTypeName"></param>
        /// <returns></returns>
        private int GetRealValueForRequisitionTypeByName(string requisitionTypeName)
        {
            int realReqTypeID = -1;
            BLL.RequisitionType requisitionType = new BLL.RequisitionType();
            requisitionType.LoadAll();
            DataTable _requisitionTypes = requisitionType.DefaultView.Table;
            DataRow[] dataRows = _requisitionTypes.Select(string.Format(@"Name = '{0}'", requisitionTypeName));
           if(dataRows.Any())
           {
              realReqTypeID = Convert.ToInt32(dataRows[0]["RequisitionTypeID"]);
           }
           return realReqTypeID;
        }
        /// <summary>
        /// Get fake or Local enum RequisitionType By real reqTypeID
        /// </summary>
        /// <param name="reqTypeID"></param>
        /// <returns></returns>
        private RequisitionType GetfakeLocalenumRequisitionTypeByrealTypeID(int reqTypeID)//fake one , local one not same accross hubs
        {
            string fakeReqTypeName;
            RequisitionType localRequisitionType = 0;  
            BLL.RequisitionType requisitionType = new BLL.RequisitionType();
            requisitionType.LoadAll();
            DataTable _requisitionTypes = requisitionType.DefaultView.Table;
            DataRow[] dataRows = _requisitionTypes.Select(string.Format(@"RequisitionTypeID ={0}", reqTypeID));
            if (dataRows.Any())
            {
                fakeReqTypeName = Convert.ToString(dataRows[0]["Name"]);
                localRequisitionType = (RequisitionType)Enum.GetValues(typeof(RequisitionType)).Cast<RequisitionType>()
                    .Select(e => new { Value = (int)e, Description = e.ToString() })
                    .ToList().Where(n => n.Description == fakeReqTypeName).Select(v => v.Value).FirstOrDefault();
            }
            return localRequisitionType;
        }
        private void LoadReceivingUnits()
        {
            Size s = new Size(800, 100);
            lkForFacility.Properties.PopupFormMinSize = s;
           
            lkForFacility.Properties.DataSource = Institution.GetAllReceivingUnits().DefaultView;
           

        }

        private void OnItemCheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            if (dr == null)
                return;
            // Determine if the selection is to select or deselect the specific raw of item
            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;

            if (b)
            {
                if (lkForFacility.EditValue != null && dxValidation1stTab.Validate(lkForFacility))
                {
                    //Check if the item is restricted for the chosen Receiving Unit                    
                    int itemID = int.Parse(dr["ID"].ToString());
                    int ruID = int.Parse(lkForFacility.EditValue.ToString());

                    Item itm = new Item();
                    int allowStatus = itm.GetItemAllowStatus(itemID, ruID);
                    if (allowStatus == -1)
                    {
                        XtraMessageBox.Show(string.Format("{0} is restricted to {1}", dr["FullItemName"], lkForFacility.Text), "Item Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dr["IsSelected"] = false;
                        return;
                    }

                    // copy the selected item to the selected items data table.
                    _dtSelectedTable.ImportRow(dr);
                    if (_dvOrderTable == null)
                    {
                        BindMainOrderGrid();
                    }
                    _dvOrderTable.Table.ImportRow(dr);
                    _dvOrderTable.Table.Rows[_dvOrderTable.Table.Rows.Count - 1]["ID"] = DBNull.Value;
                    _dvOrderTable.Table.Rows[_dvOrderTable.Table.Rows.Count - 1]["ItemID"] = dr["ID"];
                    if (BLL.Settings.IsRdfMode)
                    {
                        _dvOrderTable.Table.Rows[_dvOrderTable.Table.Rows.Count - 1]["QtyPerPack"] = dr["QtyPerUnit"];
                    }
                    else
                    {
                        _dvOrderTable.Table.Rows[_dvOrderTable.Table.Rows.Count - 1]["QtyPerPack"] = BLL.ItemManufacturer.GetDefaultBuInSKU(Convert.ToInt32(dr["ID"]));
                    }
                }
                else
                {
                    dr["isSelected"] = false;
                    XtraMessageBox.Show("Please choose facility first!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // This section is to remove from the selected table the item that is being deselected
                // TODO: what are these all try catches? 
                // TOFIX: this needs to seriously consider cleaning up.
                try
                {
                    _dtSelectedTable.PrimaryKey = new DataColumn[] { _dtSelectedTable.Columns["ID"], _dtSelectedTable.Columns["UnitID"] };
                    int id = Convert.ToInt32(dr["ID"]);
                    int unitId = Convert.ToInt32(dr["UnitID"]);
                    DataRow rw = _dtSelectedTable.Rows.Find(new Object[] {
                        id,
                        unitId
                    });

                    if (rw != null)
                    {
                        _dtSelectedTable.Rows.Remove(rw);

                        //if (Type != RequisitionType.History) 
                        //     {
                        try
                        {
                            DataRow[] dataRows =
                                _dvOrderTable.Table.Select(String.Format("ItemID = {0} and UnitID = {1}", dr["ID"],
                                                                         dr["UnitID"]));
                            // dtRecGrid.Rows.Remove(dtRecGrid.Rows.Find(dr["ID"]));
                            foreach (DataRow r in dataRows)
                            {
                                if (r["ID"] != DBNull.Value && Type != RequisitionType.History)
                                {
                                    BLL.OrderDetail od = new BLL.OrderDetail();
                                    od.LoadByPrimaryKey(Convert.ToInt32(r["ID"]));
                                    od.MarkAsDeleted();
                                    od.Save();
                                }
                                r.Delete();
                                r.EndEdit();
                            }
                        }
                        catch
                        {

                        }

                    }
                }
                catch (Exception ex) { throw (ex); }
            }
            EnableDisableButtons();
        }

        private void HideUnhideColumn(RequisitionType? type)
        {
            //colDamaged.Visible = colExpired.Visible = colSOH.Visible = InstitutionIType.IsVaccine(GeneralInfo.Current);
            if (type != null)
            {
                colDamaged.Visible = colExpired.Visible = colSOH.Visible = (type == RequisitionType.Population);
                ColBeginningBalance.Visible = ColDOS.Visible = ColLoss.Visible = ColAdjustment.Visible = ColConsumption.Visible = ColMaxStockQuantity.Visible = ColQuantityNeedMax.Visible = ColQuantityReceived.Visible = (type == RequisitionType.Consumption);

                colSOH.Caption = type == RequisitionType.Population ? "rSOH" : "E.B";
                lkPeriod.Enabled = (type == RequisitionType.Consumption);
                NoRequisitionlayout.Visibility = LastVisitlayout.Visibility = LayoutVisibility.Always;
                progressBarlayoutControlItem.ContentVisible = (type == RequisitionType.History);
                lkRange.Enabled = ShowStockOutCheckBox.Enabled = (type == RequisitionType.History);
                // adjust colmuns Visibility  index
                switch (type)
                {
                    case RequisitionType.Demand:
                        ColStockCode.VisibleIndex = 0; ColItemNameOrderDetail.VisibleIndex = 1; ColUnit.VisibleIndex = 2; colPacks.VisibleIndex = 3;
                        break;
                    case RequisitionType.Population:
                        ColStockCode.VisibleIndex = 0; ColItemNameOrderDetail.VisibleIndex = 1; ColUnit.VisibleIndex = 2;
                        colDamaged.VisibleIndex = 3; colExpired.VisibleIndex = 4; colSOH.VisibleIndex = 5; colPacks.VisibleIndex = 6;
                        break;
                    case RequisitionType.Consumption:
                        ColStockCode.VisibleIndex = 0; ColItemNameOrderDetail.VisibleIndex = 1; ColUnit.VisibleIndex = 2;
                        ColBeginningBalance.VisibleIndex = 3; ColLoss.VisibleIndex = 4; ColAdjustment.VisibleIndex = 5; colSOH.VisibleIndex = 6; ColQuantityReceived.VisibleIndex = 7;
                        ColDOS.VisibleIndex = 8; ColQuantityNeedMax.VisibleIndex = 9; ColMaxStockQuantity.VisibleIndex = 10; ColConsumption.VisibleIndex = 11; colPacks.VisibleIndex = 12;
                        break;
                    case RequisitionType.History:
                        ColStockCode.VisibleIndex = 0; ColItemNameOrderDetail.VisibleIndex = 1; ColUnit.VisibleIndex = 2; colPacks.VisibleIndex = 3;
                        ShowStockOutCheckBox.CheckState = CheckState.Checked;
                        break;
                }
            }
            else
            {
                NoRequisitionlayout.Visibility = LastVisitlayout.Visibility = LayoutVisibility.Never;
                LastVisitlabel.Visible = NoOfVisitLabel.Visible = !BLL.Settings.IsCenter;
                colDamaged.Visible = colExpired.Visible = colSOH.Visible = (InstitutionIType.IsVaccine(GeneralInfo.Current)) && (!BLL.Settings.IsCenter);
                ColBeginningBalance.Visible = ColDOS.Visible = ColLoss.Visible = ColAdjustment.Visible = ColConsumption.Visible = ColMaxStockQuantity.Visible = ColQuantityNeedMax.Visible = ColQuantityReceived.Visible = !BLL.Settings.IsCenter;
                ColStockCode.VisibleIndex = 0; ColItemNameOrderDetail.VisibleIndex = 1; ColUnit.VisibleIndex = 2; colPacks.VisibleIndex = 3;
                lkPeriod.Enabled = !BLL.Settings.IsCenter;

            }
        }

        private void EnableDisableButtons()
        {
            if (_dvOrderTable == null || _dvOrderTable.Count == 0)
            {
                // disable the buttons
                //btnCancelOne.Enabled = false;
                btnSaveAndForward.Enabled = false;
                btnSaveOrder.Enabled = false;
                simpleButton1.Enabled = false;
            }
            else
            {
                // enable the buttons

                btnCancelOne.Enabled = true;
                btnSaveAndForward.Enabled = true;
                btnSaveOrder.Enabled = true;
                simpleButton1.Enabled = true;
            }

        }

        private void OnFilterByItemNameChanged(object sender, EventArgs e)
        {
            // done when items are filtered.
            gridItemChoiceView.ActiveFilterString = String.Format("[FullItemName] Like '{0}%'", txtItemName.Text);
        }

        private void OnOrderCellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow dr = gridOrderView.GetFocusedDataRow();
            dr.ClearErrors();

            if (e.Column.Name == colPacks.Name || e.Column.Name == colsQtyPerPack.Name)
            {

                try
                {
                    int qtyPerPack = Convert.ToInt32(dr["QtyPerPack"]);
                    decimal pack = Convert.ToDecimal(dr["Pack"]);
                    dr["Quantity"] = qtyPerPack * pack;
                }
                catch
                {
                    if (dr["Pack"] == DBNull.Value)
                    {
                        dr.SetColumnError("Pack", @"Pack couldn't be left empty");
                    }
                    if (dr["QtyPerPack"] == DBNull.Value)
                    {
                        dr.SetColumnError("QtyPerPack", @"Quantity per pack couldn't be left empty");
                    }
                }
            }

            try
            {
                if (dr["BeginningBalance"] == DBNull.Value || dr["QuantityReceived"] == DBNull.Value ||
                    dr["Loss"] == DBNull.Value || dr["Adjustment"] == DBNull.Value || dr["StockOnHand"] == DBNull.Value)
                    return;
                var consmption = Convert.ToDecimal(dr["BeginningBalance"]) +
                                 Convert.ToDecimal(dr["QuantityReceived"]) +
                                 (Convert.ToDecimal(dr["Loss"]) +
                                  Convert.ToDecimal(dr["Adjustment"])) -
                                 Convert.ToDecimal(dr["StockOnHand"]);
                dr["Consumption"] = Decimal.Round(consmption, 2);

                var maxStockQuantity = (consmption*120)/(60 - Convert.ToDecimal(dr["DOS"]));
                dr["MaxStockQuantity"] = Decimal.Round(maxStockQuantity, 2);

                var quantityneedMax = maxStockQuantity - Convert.ToDecimal(dr["StockOnHand"]);
                dr["QuantityNeedMax"] = Decimal.Round(quantityneedMax, 2);
            }
            catch { }
        }

        private void BindMainOrderGrid()
        {
            // Given some items are already selected on the first step of the order process (CDR Request)
            // Bind the second grid with the selected items for the quantity to be filled by the HCMIS Operator

            if (_dtSelectedTable != null && OrderID == null)
            {
                BLL.OrderDetail or = new BLL.OrderDetail();
                or.LoadByPrimaryKey(-1);
                _dvOrderTable = or.DefaultView;
                _dvOrderTable.Table.Columns.Add("FullItemName");
                _dvOrderTable.Table.Columns.Add("StockCode");
                _dvOrderTable.Table.Columns.Add("Unit");
                // RRf Columns 
                _dvOrderTable.Table.Columns.Add("BeginningBalance");
                _dvOrderTable.Table.Columns.Add("Adjustment");
                _dvOrderTable.Table.Columns.Add("Loss");
                _dvOrderTable.Table.Columns.Add("DOS");
                _dvOrderTable.Table.Columns.Add("Consumption");
                _dvOrderTable.Table.Columns.Add("MaxStockQuantity");
                _dvOrderTable.Table.Columns.Add("QuantityNeedMax");
                _dvOrderTable.Table.Columns.Add("QuantityReceived");
            }
            orderGrid.DataSource = _dvOrderTable;
        }

        private void SaveOrderAsDraft(object sender, EventArgs e)
        {
            if (ValidateForm())
            {

                Order.SaveOrderToDatabase(OrderStatus.Constant.DRAFT_WISHLIST, CurrentContext.UserId, OrderID, (Type == RequisitionType.Population || Type == RequisitionType.History) ? GetRealValueForRequisitionTypeByName(RequisitionType.Demand.ToString()) : GetRealValueForRequisitionTypeByName(Type.ToString()),
                                          Convert.ToInt32(lkForFacility.EditValue),
                                          Convert.ToInt32(lkPaymentType.EditValue),
                                          Convert.ToInt32(lkModes.EditValue), txtRemark.Text, txtLetterNumber.Text,
                                          txtContactPerson.Text, _dvOrderTable, Convert.ToInt32(lkPeriod.EditValue));
                XtraMessageBox.Show("Your requisition has been saved", "Confirmation", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                OpenManageRequisition();
            }
        }

        private void btnSaveAndForward_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && (Order.SaveOrderToDatabase(OrderStatus.Constant.ORDER_FILLED, CurrentContext.UserId, OrderID, Convert.ToInt32(GetRealValueForRequisitionTypeByName(((RequisitionType)lkRequisitionType.EditValue).ToString())), Convert.ToInt32(lkForFacility.EditValue), Convert.ToInt32(lkPaymentType.EditValue), Convert.ToInt32(lkModes.EditValue), txtRemark.Text, txtLetterNumber.Text, txtContactPerson.Text, _dvOrderTable)))
            {
                OpenManageRequisition();
            }
        }

        private void OpenManageRequisition()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                MainWindow.Instance.OpenPage("RQ-MA-MR-VW");
            }


        }
        
        private void ResetOrder()
        {

            PopulateItemsList();
            lkPeriod.EditValue = null;
            lkForFacility.EditValue = lkForFacility.EditValue = null;
            lkPaymentType.EditValue = null;
            txtContactPerson.EditValue = null;
            txtRefNo.Text = "New Order";
            labelControl4.Text = "New Order";
            foreach (var x in ItemChoices.Values)
            {
                foreach (var y in x.Values)
                {
                    foreach (DataRowView v in y.DefaultView)
                    {
                        v["IsSelected"] = false;
                    }
                }
            }
            OrderID = null;
            if (_dtSelectedTable != null)
                _dtSelectedTable.Clear();
            txtItemName.Text = "";
            EnableDisableButtons();
        }

        private bool ValidateForm()
        {
            _gridIsValid = true;

            if (gridOrderView.RowCount == 0)
            {
                XtraMessageBox.Show("You cannot save an Empty Wish list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!dxValidation1stTab.Validate())
            {
                return false;
            }


            if (lkPaymentType.Text == "Credit" && txtLetterNumber.Text == "")
            {

                XtraMessageBox.Show("You cannot save credit sales without letter number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (lkForFacility.EditValue == null)
            {
                XtraMessageBox.Show("Please Fill Receiving Unit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            for (int i = 0; i < gridOrderView.RowCount; i++)
            {

                DataRow dr = gridOrderView.GetDataRow(i);
                dr.ClearErrors();

                if (dr["Quantity"] == DBNull.Value)
                {

                    _gridIsValid = false;
                    dr.SetColumnError("Pack", @"Quantity couldn't be left empty");
                }
                // check if decimal is allowed.
                if (dr["Pack"] != DBNull.Value && Convert.ToDecimal(dr["Pack"]) % 1 != 0)
                {
                    Item itm = new Item();
                    itm.LoadByPrimaryKey(Convert.ToInt32(dr["ItemID"]));
                    if (!itm.ProcessInDecimal)
                    {
                        _gridIsValid = false;
                        dr.SetColumnError("Pack", @"Quantity couldn't be decimal for this Item.");
                    }
                }
            }

            return _gridIsValid;
        }

        private void gridOrderView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {

            if (e.Column == colsQtyPerPack)
            {
                if (e.CellValue.ToString() == "")
                {
                    e.Appearance.BackColor = Color.FromArgb(244, 244, 244);
                }
            }
            else if (e.Column == colPacks)
            {
                DataRow dr = gridOrderView.GetDataRow(e.RowHandle);
                if (dr["QtyPerPack"] == null || dr["QtyPerPack"].ToString() == "")
                {
                    e.Appearance.BackColor = Color.FromArgb(244, 244, 244);
                }
            }
        }

        private void gridOrderView_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gridOrderView.FocusedColumn == colPacks)
            {
                DataRow dr = gridOrderView.GetFocusedDataRow();
                if (dr["QtyPerPack"] == null || dr["QtyPerPack"].ToString() == "")
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        private void lkForFacility_EditValueChanged(object sender, EventArgs e)
        {
            if (lkForFacility.EditValue == null)
                return;
            FacilityChanged(lkForFacility);

            Institution ru = new Institution();
            ru.LoadByPrimaryKey(Convert.ToInt32(lkForFacility.EditValue));

            if (!ru.IsColumnNull("Woreda"))
            {
                BLL.Woreda woreda = new BLL.Woreda();
                woreda.LoadByPrimaryKey(ru.Woreda);

                BLL.Zone zone = new BLL.Zone();
                zone.LoadByPrimaryKey(woreda.ZoneID);

                lkRegion.EditValue = zone.RegionId;
                lkZone.EditValue = zone.ID;
                lkWoreda.EditValue = ru.Woreda;

            }

            lkOwnership.EditValue = ru.Ownership;

            lkType.EditValue = ru.RUType;

            //Fill facility visit history
            DataRow facilityHis = BLL.Issue.GetVisitHistoryForFacility((int)lkForFacility.EditValue);
            NoOfVisitLabel.Text = facilityHis != null ? Convert.ToInt32(facilityHis["VisitCount"]).ToString(CultureInfo.InvariantCulture) : "0";
            LastVisitlabel.Text = facilityHis != null ? Convert.ToDateTime(facilityHis["LastVisit"]).TimeAgo() : "Never";

            //Reset Requisitoin Type
            if(!BLL.Settings.IsCenter && OrderID == null && Type == RequisitionType.History) lkRequisitionType_EditValueChanged(null, null);

        }

        private void FacilityChanged(GridLookUpEdit lkRecUnit)
        {
            if (lkRecUnit.EditValue != null)
            {
                int facilityID = Convert.ToInt32(lkRecUnit.EditValue);
                Institution institution = new Institution();
                institution.LoadByPrimaryKey(facilityID);
                string facilityPaymentType = "";
                if (!institution.IsColumnNull("PaymentTypeID"))
                    facilityPaymentType = PaymentType.GetPaymentTypeString(institution.PaymentTypeID);

                txtVatRegistration.Text = (!institution.IsColumnNull("VATNo")) ? institution.VATNo : "";

                labelControl2.Text = (!institution.IsColumnNull("VATNo")) ? institution.VATNo : "";
                txtTin.Text = (!institution.IsColumnNull("TinNo")) ? institution.TinNo : "";

                labelControl1.Text = (!institution.IsColumnNull("TinNo")) ? institution.TinNo : "";

                txtRegistrationNo.Text = (!institution.IsColumnNull("LicenseNo")) ? institution.LicenseNo : "";

                labelControl3.Text = (!institution.IsColumnNull("LicenseNo")) ? institution.LicenseNo : "";
            }
        }

        private void lkCategoires_EditValueChanged(object sender, EventArgs e)
        {

            PopulateItemsList();
        }

        private void PopulateItemsList()
        {

            if (lkCategoires.EditValue == null || lkModes.EditValue == null || lkCategoires.EditValue == "" || lkModes.EditValue == "")
            {
                gridItemsChoice.DataSource = null;
                return;
            }
            int category = Convert.ToInt32(lkCategoires.EditValue);
            int storeTypeID = int.Parse(lkModes.EditValue.ToString());
            if (ItemChoices.ContainsKey(category))
            {
                if (ItemChoices[category].ContainsKey(storeTypeID))
                {
                    gridItemsChoice.DataSource = ItemChoices[category][storeTypeID];

                }
                else
                {
                    PopulateDictionary(category, storeTypeID);
                }
            }
            else
            {
                PopulateDictionary(category, storeTypeID);
            }
        }

        private void PopulateDictionary(int category, int storeTypeID)
        {
            DataTable dtItem = Item.GetCommodityForRequisition(category, int.Parse(lkModes.EditValue.ToString()));
            // add a flag field to the data table
            if (_dtSelectedTable == null)
            {
                _dtSelectedTable = dtItem.Clone();

                gridItemsChoice.DataSource = _dtSelectedTable;
            }

            if (!ItemChoices.ContainsKey(category))
            {
                Dictionary<int, DataTable> dict = new Dictionary<int, DataTable>();
                dict.Add(storeTypeID, dtItem);
                ItemChoices.Add(category, dict);
            }

            else
            {
                ItemChoices[category].Add(storeTypeID, dtItem);
            }

            ItemChoices[category][storeTypeID] = dtItem;
            gridItemsChoice.DataSource = dtItem;
        }

        private void gridOrderView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void lblLoadRU_Click(object sender, EventArgs e)
        {
            LoadReceivingUnits();
        }

        private void lkModes_EditValueChanged(object sender, EventArgs e)
        {
            int mode = Convert.ToInt32(lkModes.EditValue);
            lkPaymentType.Properties.DataSource = PaymentType.GetAllowedTypes(mode, 0);
            if (BLL.Settings.IsCenter)
                lkPaymentType.EditValue = BLL.PaymentType.Constants.STV;

            PopulateItemsList();
            if (Type == RequisitionType.History && lkForFacility.EditValue != null && lkModes.EditValue != null && !BLL.Settings.IsCenter) LoadCommodityHistoryForFacility();
        }

        public void EditRequisition(int orderID)
        {
            OrderID = orderID;
            Order ord = new Order();
            ord.LoadByPrimaryKey(orderID);
            txtRefNo.Text = ord.RefNo;
            txtLetterNumber.Text = ord.LetterNo;
            labelControl4.Text = ord.RefNo;
            Institution ru = new Institution();
            ru.LoadByPrimaryKey(ord.RequestedBy);

            if (!ru.IsColumnNull("Zone"))
            {
                // Just because the region Property on the Receiving Unit is not working as desired.
                Zone zone = new Zone();
                zone.LoadByPrimaryKey(ru.Zone);

                lkRegion.EditValue = zone.RegionId;
                lkZone.EditValue = ru.Zone;
            }
            lkForFacility.EditValue = ru.ID;

            lkModes.EditValue = ord.FromStore;
            lkModes_EditValueChanged(null, null);

            lkPaymentType.EditValue = ord.PaymentTypeID;
            txtContactPerson.EditValue = ord.ContactPerson;

            BLL.OrderDetail or = new BLL.OrderDetail();
            or.LoadAllByOrderID(orderID);

            DataView selectables = (DataView)gridItemChoiceView.DataSource;

            if (_dtSelectedTable != null)
            {
                _dtSelectedTable.Clear();
            }
            else
            {
                PopulateItemsList();
            }

            while (!or.EOF)
            {
                // select the items and put it in the dtselected table.
                if (selectables != null)
                {
                    DataRow[] dataRows = selectables.Table.Select(String.Format("ID = {0} and UnitID = {1}", or.ItemID, or.UnitID));
                    if (dataRows.Length > 0)
                    {
                        _dtSelectedTable.ImportRow(dataRows[0]);
                        dataRows[0]["IsSelected"] = true;
                    }
                }
                or.MoveNext();
            }

            _dvOrderTable = or.DefaultView;
            orderGrid.DataSource = _dvOrderTable;
            EnableDisableButtons();
        }

        private void btnCancelOne_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                OpenManageRequisition();
            }
        }

        #region Load Functions

        private void LoadZones()
        {
            //Clear Zone Selection
           
            lkZone.EditValue = null;
            // Bind the Zone Lookup
            DataTable zone = Zone.GetZoneByRegionAndNumberRU(Convert.ToInt32(lkRegion.EditValue));
            lkZone.Properties.DataSource = zone.DefaultView;
            //check if Zone Lookup Has 
            if (zone.Rows.Count > 0)
                lkZone.Properties.NullText = "Select Zone";
            else
                lkRegion.Properties.NullText = "Select Region";
            LoadReceivingUnits();

        }

        private void LoadWoredas()
        {
            //Clear Zone Selection
            lkWoreda.EditValue = null;
            //Bind the Woreda Lookup

            DataTable woreda = Woreda.GetWoredaByZoneAndNumberRU(Convert.ToInt32(lkZone.EditValue));
            lkWoreda.Properties.DataSource = woreda.DefaultView; ;

            if (woreda.Rows.Count != 0)

                lkWoreda.Properties.NullText = " Select Woreda";
            else
                lkWoreda.Properties.NullText = "";

        }

        private void LoadCommodityHistoryForFacility(int range = -1)
        {
            if(range == -1)lkRange.EditValue =  (int) Range._Ever;
            DataTable dtHisotryItem = Item.GetCommodityHistoryByFacilityForRequisition((int)lkForFacility.EditValue, int.Parse(lkModes.EditValue.ToString()),range);
            DataView selectables = (DataView)gridItemChoiceView.DataSource;

            var dataHistoryRows = dtHisotryItem.Select();
            foreach (var dtHisItem in dataHistoryRows)
            {
                DataRow[] dataRows = selectables.Table.Select(String.Format("ID = {0} and UnitID = {1}", Convert.ToInt32(dtHisItem["ItemID"]), Convert.ToInt32(dtHisItem["UnitID"])));
                if (dataRows.Length > 0)
                {
                    var itemRow = _dtSelectedTable.Select(String.Format("ID = {0} and UnitID = {1}",
                                                          Convert.ToInt32(dtHisItem["ItemID"]),
                                                          Convert.ToInt32(dtHisItem["UnitID"])));
                    if (itemRow.Length == 0) _dtSelectedTable.ImportRow(dataRows[0]);
                    dataRows[0]["IsSelected"] = true;
                }
            }
            _dvOrderTable = dtHisotryItem.DefaultView;
            orderGrid.DataSource = _dvOrderTable;
            EnableDisableButtons();

            var ranges = Enum.GetValues(typeof(Range)).Cast<Range>()
                           .Select(e => new { Value = (int)e, Range = e.ToString().Replace('_', '\0') })
                           .ToList();
            lkRange.Properties.DataSource = ranges;
            ShowStockOutCheckBox.CheckState = CheckState.Checked;

//lkRange.Enabled = false;
            
            ShowStockOutCheckBox.Enabled = dataHistoryRows.Any();

        }
        #endregion

        #region Filter Events

        private void lkRegion_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
            LoadZones();
            LoadWoredas();
        }

        private void lkZone_EditValueChanged(object sender, EventArgs e)
        {
            LoadWoredas();
        }

        private void lkOwnership_EditValueChanged(object sender, EventArgs e)
        {
            LoadFacilityType();
        }

        private void lkType_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
        }
        private void lkWoreda_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
            LoadOwnershipType();
        }
        private void LoadOwnershipType()
        {
            //Clear  Selection
            lkOwnership.EditValue = null;
            //Bind the Ownership Type Lookup

            DataTable ownershiptype = OwnershipType.GetOwnershipTypeByRegionAndNumberRU(Convert.ToInt32(lkWoreda.EditValue));
            lkOwnership.Properties.DataSource = ownershiptype.DefaultView; ;

            if (ownershiptype.Rows.Count != 0)

                lkOwnership.Properties.NullText = " Select Ownership Type";
            else
                lkOwnership.Properties.NullText = "";
        }
        private void LoadFacilityType()
        {
            //Clear  Selection
            lkType.EditValue = null;
            //Bind the Ownership Type Lookup

            DataTable Facilitytype = InstitutionType.GetReceivingUnitTypeByRegionAndNumberRU(Convert.ToInt32(lkWoreda.EditValue), Convert.ToInt32(lkOwnership.EditValue));
            lkType.Properties.DataSource = Facilitytype.DefaultView; ;

            if (Facilitytype.Rows.Count != 0)

                lkType.Properties.NullText = "Select Facility Type";
            else
                lkType.Properties.NullText = "";
        }

        private void lkPeriod_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void lkRequisitionType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void lkRequisitionType_EditValueChanged(object sender, EventArgs e)
        {

            var type = (RequisitionType)lkRequisitionType.EditValue;
            Type = type;

            HideUnhideColumn(Type);
            ClearOrderGrid();
            if (type == RequisitionType.History && lkForFacility.EditValue != null && lkModes.EditValue != null && ! BLL.Settings.IsCenter) LoadCommodityHistoryForFacility();

        }

        private void ClearOrderGrid()
        {
            DataView selectables = (DataView)gridItemChoiceView.DataSource;
            if (selectables != null)
            {
                foreach (var dataRows in selectables.Table.Select())
                {
                    dataRows["IsSelected"] = false;
                }
            }

            orderGrid.DataSource = null;
            _dvOrderTable = null;
            _dtSelectedTable.Clear();
          //  EnableDisableButtons();
        }

        #endregion

        private void multiFacilityDialog_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                MultiFacilityRequisition requisition = new MultiFacilityRequisition(OrderID,
                                                                                    Convert.ToInt32(
                                                                                        lkForFacility.EditValue),
                                                                                    Convert.ToInt32(
                                                                                        lkPaymentType.EditValue),
                                                                                    Convert.ToInt32(lkModes.EditValue),
                                                                                    txtRemark.Text, txtLetterNumber.Text,
                                                                                    txtContactPerson.Text, _dvOrderTable);
                if (requisition.ShowDialog(this) == DialogResult.OK)
                {
                    OpenManageRequisition();
                }
            }
        }
        
        private void ShowStockOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowStockOutCheckBox.CheckState == CheckState.Unchecked)
            {
                DataView selectables = (DataView)gridItemChoiceView.DataSource;
                DataTable dtHisotryItemWithStockedOut = _dvOrderTable.Table;
                var dataHistoryRows = dtHisotryItemWithStockedOut.Select();
                foreach (var dtHisItem in dataHistoryRows)
                {
                    if (Convert.ToBoolean(dtHisItem["StockedOut"]))
                    {
                        var itemRow = selectables.Table.Select(String.Format("ID = {0} and UnitID = {1}",
                                                          Convert.ToInt32(dtHisItem["ItemID"]),
                                                          Convert.ToInt32(dtHisItem["UnitID"])));
                        itemRow[0]["IsSelected"] = false;
                        dtHisotryItemWithStockedOut.Rows.Remove(dtHisItem);
                    }

                    
                }

                DataView dtHisotryItemWithStock = dtHisotryItemWithStockedOut.AsDataView();
                _dvOrderTable = dtHisotryItemWithStock;
                orderGrid.DataSource = _dvOrderTable;
                EnableDisableButtons();
            }

            else if (ShowStockOutCheckBox.CheckState == CheckState.Checked)
            {
               
            }
        }

        #region Volume Metrices
        private void lkRange_EditValueChanged(object sender, EventArgs e)
        {
            ClearOrderGrid();
            if (Type == RequisitionType.History && lkForFacility.EditValue != null && lkModes.EditValue != null && !BLL.Settings.IsCenter) LoadCommodityHistoryForFacility((int)lkRange.EditValue);

        }


        #region Events
            
            private void grdVolumeGridView_CellValueChanged(object sender, CellValueChangedEventArgs e)
            {

            }

            private void lkContainerTypes_EditValueChanged(object sender, EventArgs e)
            {
                volumetricsCanvas.Invalidate();
            }

            private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
            {
                if (e.Page == VolumeMetricsPage && orderGrid.DataSource != null && ((DataView)orderGrid.DataSource).Table.Rows.Count > 0)
                {
                    BindShippingContainers();
                    BindVolumeData();
                    volumetricsCanvas.Invalidate();
                    cboRequiredContainer.Text = "";
                    lastSelectedIndex = -1;
                }
                else
                {
                    xtraTabControl1.SelectedTabPage = ItemSelectionPage;
                }
            }

            private void cboAvailableHolders_SelectedIndexChanged(object sender, EventArgs e)
            {
                //if (cboAvailableHolders.SelectedIndex != -1)
                    volumetricsCanvas.Invalidate();
            }

            private void cboRequiredContainer_SelectedIndexChanged(object sender, EventArgs e)
            {
                    volumetricsCanvas.Invalidate();// CalculateVolumeMetrics();
            }
    

            private void volumetricsCanvas_Paint(object sender, PaintEventArgs e)
            {
                    CalculateVolumeMetrics();
            }

        #endregion

        #region Bind Data

        private void BindShippingContainers()
            {
                ShippingContainerType shippingContainerType = new ShippingContainerType();
                shippingContainerType.LoadAll();
                lkContainerTypes.Properties.DataSource = shippingContainerType.DefaultView;

            }

        private void BindVolumeData()
        {
            DataTable selectedItems = (orderGrid.DataSource as DataView).Table;
            VolumeMetrics vm = new VolumeMetrics();
            ItemUnitBase iub = new ItemUnitBase();
            vm.LoadVolumeDataForItems(selectedItems.AsEnumerable().Select(t => t.Field<int>("ItemID")).ToArray<int>());
            iub.LoadAll();
      
            DataTable allVolumeData = vm.DefaultView.Table;

            if (orderGrid.DataSource == null) return;

            DataTable units = iub.DefaultView.Table ;

            var volDataTemp = (from v in allVolumeData.AsEnumerable()
                           join u in units.AsEnumerable()
                           on 
                           new 
                           { 
                                 ItemID = v.Field<int>("ItemID")
                               , UnitID = v.Field<int>("UnitOfIssueID")
                           }
                           equals
                           new 
                           { 
                                 ItemID = u.Field<int>("ItemID")
                               , UnitID = u.Field<int>("UnitOfIssueID")
                           }
                           join s in selectedItems.AsEnumerable()
                           on 
                           new 
                           { 
                                ItemID = u.Field<int>("ItemID")
                               , UnitID = u.Field<int>("ID") 
                           }
                           equals
                           new 
                           {
                                 ItemID = s.Field<int>("ItemID")
                               , UnitID = s.Field<int>("UnitID") 
                           }
                           select new ItemVolumeQuantityViewModel
                           {
                               ItemID = v.Field<int>("ItemID"),
                               UnitID = s.Field<int>("UnitID"),
                               HeightMM = v.Field<int?>("HeightMM") ?? 1,
                               WidthMM = v.Field<int?>("WidthMM") ?? 1,
                               DepthMM = v.Field<int?>("LengthMM") ?? 1,
                               Weight = v.Field<int?>("WeightG") ?? 1,
                               Quantity = s.Field<decimal?>("Pack") ?? 0
                           }).ToList();

            var volData = new List<ItemVolumeQuantityViewModel>();

            foreach (ItemVolumeQuantityViewModel i in volDataTemp)
            {
                if (!volData.Any(t => t.ItemID == i.ItemID && t.UnitID == i.UnitID))
                    volData.Add(i);
            }

            grdVolumeGrid.DataSource = volData;
        }

        #endregion

        #region Calculation

        int lastSelectedIndex = -1;

        private void CalculateVolumeMetrics()
        {
            double singleContainerSpace = GetUnitContainerVolume(), VolumeNeeded = GetRequiredVolume();
            lblAvailableVolume.Text = "Available Space: " + Math.Round(singleContainerSpace, 3) + " m3";
            lblVolumeNeeded.Text = "Required Space: " + Math.Round(VolumeNeeded, 3) + " m3";
            
            double requiredNumberOfContainers = VolumeNeeded / singleContainerSpace;

            int selectedIndex = cboRequiredContainer.SelectedIndex;

            cboRequiredContainer.Items.Clear();
            for (int i = 1; i <= (int)Math.Ceiling(requiredNumberOfContainers); i++)
                cboRequiredContainer.Items.Add(i);

            if (selectedIndex != -1 && selectedIndex < cboRequiredContainer.Items.Count)
                cboRequiredContainer.SelectedValue = selectedIndex + 1;
            else if (selectedIndex == -1 || selectedIndex > cboRequiredContainer.Items.Count)
            {
                cboRequiredContainer.SelectedValue = cboRequiredContainer.Items.Count;
                cboRequiredContainer.Text = cboRequiredContainer.Items.Count.ToString();
            }

            Draw(singleContainerSpace, VolumeNeeded, requiredNumberOfContainers, selectedIndex == -1 ? cboRequiredContainer.Items.Count - 1 : selectedIndex);

        }

        private double GetUnitContainerVolume()
        {
            double AvailableStorageVolume = 0;
            int containerID = 0;
            if(int.TryParse(lkContainerTypes.EditValue.ToString(), out containerID))
            {
                ShippingContainerType sct = new ShippingContainerType();
                sct.LoadByPrimaryKey(containerID);

                var dr = sct.DefaultView.Table.Rows[0]; //(DataRow)lkContainerTypes.EditValue;

                AvailableStorageVolume = Convert.ToDouble(dr["HeightMM"])/1000 * Convert.ToDouble(dr["WidthMM"])/1000 * Convert.ToDouble(dr["LengthMM"])/1000;
          
                return AvailableStorageVolume;
            }

            return 0;
          }

        private double GetRequiredVolume()
        {
            double VolumeNeeded = 0;
            if (grdVolumeGridView.DataSource != null)
            {
                var dt = (List<ItemVolumeQuantityViewModel>)grdVolumeGridView.DataSource;

                foreach (ItemVolumeQuantityViewModel dr in dt)
                {
                    VolumeNeeded += (double) (dr.WidthMM / 1000) *  (double)(dr.HeightMM / 1000) * (double)(dr.DepthMM / 1000) * (double) dr.Quantity;
                }
            }
            return VolumeNeeded;
        }

        public int GetProperWidth(int NoOfSquares)
        {
            if (NoOfSquares == 0) return 0;
            return (int)Math.Sqrt(volumetricsCanvas.Width * volumetricsCanvas.Height / (3 * NoOfSquares));
        }

        #endregion

        #region Drawing

        public void Draw(double singleContainerSpace, double neededSpace, double requiredContainers, int availableContainers)
        {
            int canvasHeight = volumetricsCanvas.Height, canvasWidth = volumetricsCanvas.Width;

            if (singleContainerSpace == 0) return;

            var meter = volumetricsCanvas.Width / 2;
            Graphics G = volumetricsCanvas.CreateGraphics();
            G.Clear(Color.White);
            int x = 5, y = 5, xOrgin = 5, yOrigin = 5, squareSide = GetProperWidth((int)Math.Ceiling(requiredContainers));

            int r = (int)Math.Ceiling(requiredContainers);

            for (int i = 0; i < r; i++)
            {
                if (i <= availableContainers)
                {
                    if (x + squareSide <= canvasWidth)
                    {
                        DrawSquare(Color.LightGreen, 1, G, x, y, squareSide);//(int)item.Height * meter / 1000);
                        x += squareSide;
                    }
                    else
                    {
                        x = xOrgin;
                        y += squareSide + 2;
                        DrawSquare(Color.LightGreen, 1, G, x, y, squareSide);//(int)item.Height * meter / 1000);
                        x += squareSide;
                    }
                }
                else
                {
                    if (x + squareSide <= canvasWidth)
                    {
                        if (requiredContainers < 1)
                            DrawSquare(Color.LightBlue, 1, G, x, y, squareSide, true, true);//(int)item.Height * meter / 1000);
                        else
                            DrawSquare(Color.LightBlue, 1, G, x, y, squareSide);//(int)item.Height * meter / 1000);
                        x += squareSide;
                    }
                    else
                    {
                        x = xOrgin;
                        y += squareSide + 2;
                        DrawSquare(Color.LightBlue, 1, G, x, y, squareSide);//(int)item.Height * meter / 1000);
                        x += squareSide;
                    }
                }

            }
        }

        public void DrawSquare(Color color, int brushWidth, Graphics G, int x, int y, int side, bool fill = true, bool strike = false)
        {
            String tag = "";
            Rectangle rect = new Rectangle(x, y, side, side);

            if (fill)
            {
                Pen pen = new Pen(Color.Gray, 2);
                SolidBrush fillBrush = new SolidBrush(color);
                G.FillRectangle(fillBrush, rect);
                G.DrawLine(pen, x + side, y, x + side, y + side);
                G.DrawLine(pen, x, y + side, x + side, y + side);

                if (strike)
                {
                    pen = new Pen(Color.White, 3);
                }
            }
            else
            {
                Pen pen = new Pen(color, brushWidth);
                G.DrawLine(pen, x, y, x + side, y + side);
                G.DrawRectangle(pen, rect);
            }
        }
   
        #endregion

        private void orderGrid_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void gridItemsChoice_Click(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

    }
}
