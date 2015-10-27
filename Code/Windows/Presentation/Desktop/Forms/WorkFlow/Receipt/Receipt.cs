using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using BLL;
using BLL.WorkFlow.Receipt;
using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout.Utils;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Modals;
using HCMIS.Desktop.ViewHelpers;
using HCMIS.Desktop.ViewModels.Receive;
using HCMIS.Helpers;
using Helpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    public enum StandardReceiptType
    {
        NotSet = 0,
        iGRV = 1,
        GRV = 2,
        iGRVOnline = 3
    }

    public enum DeliveryNoteType
    {
        NotSet = 0,
        Automatic = 1,
        Manual = 2
    }


    [FormIdentifier("RE-RE-SL-FR", "Receipt Form", "Receipt Form")]
    public partial class Receipt : XtraForm
    {
        public Receipt()
        {
            InitializeComponent();
        }

        #region Member Variables

        // TOFIX: not all the variables here are important

        //DataTable _dtDrugChoiceItems = null;
        //DataTable _dtSuppliesChoiceItems = null;
        private Dictionary<int, Dictionary<int, DataTable>> ItemChoices =
            new Dictionary<int, Dictionary<int, DataTable>>();

        // Data Tables that are used on second step of the receive process
        private DataTable _dtRecGrid = new DataTable();
        private DataTable _dtSelectedTable = null;

        // Data Table that is used on palletization step

        private DataTable _dtPalletizedItemList = null;
        private DataTable _dtNonPalletizedItemList = null;

        // Data Tables that will be used on put away (last step)
        private DataTable _dtPutAwayPalletized = null;
        private DataTable _dtPutAwayNonPalletized = null;
        private int _LastOrdering = 0;
        private bool srm = false;
        private bool beginningBalance = false;
        private StandardReceiptType standardRecType = StandardReceiptType.NotSet;
        private DeliveryNoteType deliveryNoteType = DeliveryNoteType.NotSet;
        private bool hasPreviousReceive = false;
        private string _chosenAccountType = "";
        private string _chosenSupplier = "";
        private string _deliveryNoteSetting = "";

        private int storeID = 0;
        private int _receiptID = 0;
        private int _supplierID = 0;
        // During palletizing we need to cache a single Line sumed receiveDoc into respective Orginal receiveDocLines: this happens when we need to merge two diffrent receDoc but have the same item information and physicalStore
        private Dictionary<string, List<string>> _revDocRelatePalletGuid = new Dictionary<string, List<string>>();

        private bool _isElectronic = false;
        private bool _isNonElectronicReceiveOnly = false;
        private int _receiptTypeID;
        #endregion

        private void ReceiveingForm_Load(object sender, EventArgs e)
        {
            SetPermissions();
            LoadDecimalFormatings();
            //Bind ReceiptType
            cboReceiveType.Properties.DataSource = ReceiptType.GetAllReceiptTypesForReceive();
            cboReceiveType.EditValue = ReceiptType.CONSTANTS.STANDARD_RECEIPT;

            //Bind the Receiving units Types Lookup
            InstitutionType institutionsTypes = new InstitutionType();
            institutionsTypes.LoadAll();
            institutionsTypes.Sort = "Name ASC";
            lkType.Properties.DataSource = institutionsTypes.DefaultView;
            lkType.EditValue = InstitutionType.Constants.HEALTH_CENTER;
            //---            

            //Bind the Ownership Type Lookup
            LoadOwnershipType();
            lkOwnership.EditValue = OwnershipType.Constants.Public;
            LoadReceivingUnits();
            //----------------------------
            // reset the receiving date
            dtRecDate.Value = DateTimeHelper.ServerDateTime;
            // Load the logical stores and populate the combo boxes
            //lkStoreType.Properties.DataSource = BLL.StoreType.GetStoreTypesForAUser(NewMainWindow.UserId).DefaultView;
            lkAccounts.SetupActivityEditor().SetDefaultActivity();

            // Load the possible suppliers and populate


          
            // Load all occupied Pallet location list for the consolidate lookup editManuf2
            repoLKConsolidate.DataSource = PalletLocation.GetAllOccupied();

            // load the receiving unit's to the combo box 
            Institution rus = new Institution();
            rus.LoadAll();
            lkFacilitySelection.Properties.DataSource = rus.DefaultView;

            lkStorageType.DataSource = StorageType.AllStorageTypes;

            // bulkPalletLocationLookup.DataSource = PalletLocation.GetAllFree(StorageType.BulkStore);
            nonBulkPalletLocationLookup.DataSource = PalletLocation.GetAllFreeNonBulk();
            //OnSelectedFilterChanged(new object(), new DevExpress.XtraEditors.Controls.ChangingEventArgs(null,"Drug"));

            // load all item Units
            ItemUnit itemUnit = new ItemUnit();
            itemUnit.LoadAll();
            editUnits.DataSource = itemUnit.DefaultView;

            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkCategories.ItemIndex = 0;

            // Get the default who's receiving this
            txtReceivedBy.Text = CurrentContext.LoggedInUserName;

            // for RDF, Hide the packs column on receipt
            if (BLL.Settings.IsRdfMode)
            {
                colPacks.Visible = false;
            }

            //lcDeliveryNoteCheck.Visibility = BLL.Settings.HandleDeliveryNotes ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            colPricePerPack.Visible = !BLL.Settings.HandleGRV && srm != true;
            lcRefNoInput.Visibility =
                lcRefNo.Visibility =
                    BLL.Settings.HandleGRV
                        ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            if (BLL.Settings.IsCenter)
            {
                colShipper.Visible = false;
                colPercentReceived.Visible = true;
                colPrintedDate.Visible = false;
                PalletizeTab.PageVisible = false;
                txtPassCode.Enabled = false;
                lcPassCode .Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                tabReceiveTabs.TabPages[3].Text = "Step Three - Store Selection";
            }


            //Load the allowed Warehouses
            DataView PossibleWarehouses = BLL.Warehouse.getActiveWarehouseWithCluster(CurrentContext.UserId);
            lkWarehouse.Properties.DataSource = PossibleWarehouses;
            if (PossibleWarehouses.Count > 0)
            {
                lkWarehouse.EditValue = ((DataView)lkWarehouse.Properties.DataSource)[0]["ID"];
            }

            //Load IsElectronicReceiveOnly Setting
            LoadIsPOElectronicSetting();
        }

        private void SetPermissions()
        {
            btnSave.Enabled = btnSaveButton.Enabled = this.HasPermission("Save-Receipt");

        }

        private void LoadDecimalFormatings()
        {
            string sharps = Helpers.FormattingHelpers.GetNumberFormatting();
            colButtonConsolidate.DisplayFormat.FormatString = sharps;
            repoPricePerPackEdit.Mask.EditMask = sharps;
        }

        private void LoadOwnershipType()
        {
            //Clear  Selection
            lkOwnership.EditValue = null;
            //Bind the Ownership Type Lookup

            DataTable ownershiptype =
                OwnershipType.GetOwnershipTypeByRegionAndNumberRU(Convert.ToInt32(lkType.EditValue), storeID, true);
            lkOwnership.Properties.DataSource = ownershiptype.DefaultView;

            if (ownershiptype.Rows.Count != 0)

                lkOwnership.Properties.NullText = " Select Ownership Type";
            else
                lkOwnership.Properties.NullText = "";
        }

        private void LoadReceivingUnits()
        {
            // Load and bind the applicable receiving units

            int woredaID = Convert.ToInt32(lkWoreda.EditValue);
            int zoneID = Convert.ToInt32(lkZone.EditValue);
            int ruType = Convert.ToInt32(lkType.EditValue);
            int ownershipType = Convert.ToInt32(lkOwnership.EditValue);
            Boolean Inprocess = false;
            int ActiveStatus = -1;
            lkForFacility.Properties.DataSource =
                Institution.LoadReceivingUnitByFilter(woredaID, zoneID, ruType, ownershipType, ActiveStatus, Inprocess,
                    storeID, true).DefaultView;

        }

        #region First Step

        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            PopulateReceiveGrid();
        }

        private void PopulateReceiveGrid()
        {
            if (lkCategories.EditValue == null || lkAccounts.EditValue == null || lkCategories.EditValue == "" ||
                lkAccounts.EditValue == "" || cboReceiveType.EditValue == null ||
                (Convert.ToInt32(cboReceiveType.EditValue) == ReceiptType.CONSTANTS.STOCK_RETURN && !chkSRMForOldSystemIssues.Checked))
            {
                gridItemsChoice.DataSource = null;
                return;
            }
            int category = Convert.ToInt32(lkCategories.EditValue);
            int storeID = int.Parse(lkAccounts.EditValue.ToString());
            if (ItemChoices.ContainsKey(category))
            {
                if (ItemChoices[category].ContainsKey(storeID))
                {
                    gridItemsChoice.DataSource = ItemChoices[category][storeID];
                }
                else
                {
                    PopulateDictionary(category, storeID);
                }
            }
            else
            {
                PopulateDictionary(category, storeID);
            }
        }

        private void PopulateDictionary(int category, int storeID)
        {
            DataTable dtItem = Item.GetActiveItemsByCommodityTypeForReceiveScreen(category,
                int.Parse(lkAccounts.EditValue.ToString()));
            // add a flag field to the data table
            if (_dtSelectedTable == null)
            {
                _dtSelectedTable = dtItem.Clone();

                gridSelected.DataSource = _dtSelectedTable;
            }

            if (!ItemChoices.ContainsKey(category))
            {
                Dictionary<int, DataTable> dict = new Dictionary<int, DataTable>();
                dict.Add(storeID, dtItem);
                ItemChoices.Add(category, dict);
            }

            else
            {
                ItemChoices[category].Add(storeID, dtItem);
            }

            ItemChoices[category][storeID] = dtItem;
            gridItemsChoice.DataSource = dtItem;
        }

        private void gridItemChoiceView_RowClick(object sender, RowClickEventArgs e)
        {
            DataRow dr = gridItemChoiceView.GetFocusedDataRow();

            if (!Convert.ToBoolean(dr["HasManufacturer"]))
            {
                XtraMessageBox.Show(
                    "There is no manufacturer set up to supply this Item. please add a manufacturer and try again.",
                    "Manufacturer Not Set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;
            dr["IsSelected"] = !b;
            OnItemCheckedChanged(new object(), new EventArgs());
        }

        private void OnItemCheckedChanged(object sender, EventArgs e)
        {

            DataRow dr = gridItemChoiceView.GetFocusedDataRow();
            if (dr == null)
                return;
            SelectAnItem(dr);
        }

        private void SelectAnItem(DataRow dr)
        {
            bool b = (dr["IsSelected"] != DBNull.Value) ? Convert.ToBoolean(dr["IsSelected"]) : false;

            if (b)
            {
                _dtSelectedTable.ImportRow(dr);
                gridSelected.DataSource = _dtSelectedTable;
            }
            else
            {
                _dtSelectedTable.PrimaryKey = new DataColumn[] { _dtSelectedTable.Columns["ID"] };
                DataTable discrepancyTable = (DataTable)grdShortageOrDamaged.DataSource;

                int id = Convert.ToInt32(dr["ID"]);
                DataRow rw = _dtSelectedTable.Rows.Find(id);



                if (rw != null)
                {

                    _dtSelectedTable.Rows.Remove(rw);
                    try
                    {
                        DataRow[] dataRows = _dtRecGrid.Select(String.Format("ID = {0}", dr["ID"]));
                        // dtRecGrid.Rows.Remove(dtRecGrid.Rows.Find(dr["ID"]));
                        foreach (DataRow r in dataRows)
                        {

                            // Remove the Discrepancy (if it exists)
                            if (discrepancyTable != null)
                            {
                                var rows = from DataRow v in discrepancyTable.AsEnumerable()
                                           where v["GUID"] == r["GUID"]
                                           select v;
                                if (rows.Count() > 0)
                                {
                                    foreach (var row in rows)
                                    {
                                        discrepancyTable.Rows.Remove(row);
                                    }
                                }
                            }
                            // Remove the selected item from the receive grid.
                            r.Delete();
                        }
                    }
                    catch
                    {
                    }
                }

            }

        }


        private void OnFilterByItemNameChanged(object sender, EventArgs e)
        {
            gridItemChoiceView.ActiveFilterString = "[FullItemName] Like '" + txtItemName.Text + "%'";
        }

        private void PopulateListToGrid()
        {
            Item itm = new Item();

            if (_dtRecGrid.Columns.Count == 0)
            {
                string[] str =
                {
                    "ID", "Stock Code", "Item Name", "BoxLevel", "Unit", "Price/Pack", "Manufacturer",
                    "Batch No", "Expiry Date", "BasicUnitPerQ", "LevelView2"
                };
                foreach (string col in str)
                {
                    if (col.Contains("Date"))
                        _dtRecGrid.Columns.Add(col, typeof(DateTime));
                    else
                        _dtRecGrid.Columns.Add(col);
                }
                
                _dtRecGrid.Columns.Add("BU Qty", typeof (decimal));
                _dtRecGrid.Columns.Add("Pack Qty", typeof (decimal));
                _dtRecGrid.Columns.Add("NotReceived", typeof(decimal));
                _dtRecGrid.Columns.Add("IsDamaged", typeof (bool));
                _dtRecGrid.Columns.Add("Ordering", typeof (int));

                _dtRecGrid.Columns.Add("PalletComposition");
                _dtRecGrid.Columns.Add("PC", typeof(DataTable));
                _dtRecGrid.Columns.Add("UnitID", typeof(int));
                _dtRecGrid.Columns.Add("IssuedQty");
                _dtRecGrid.Columns.Add("IssueDocID"); //For srm only
                _dtRecGrid.Columns.Add("InvoicedQty", typeof(decimal));
                _dtRecGrid.Columns.Add("OriginalInvoicedQty", typeof(decimal));
                _dtRecGrid.Columns.Add("RemainingQty"); //For hasPreviousReceive is True
                _dtRecGrid.Columns.Add("StockCode");
                _dtRecGrid.Columns.Add("GUID");
                _dtRecGrid.Columns.Add("Margin");
                _dtRecGrid.Columns.Add("ShortageReasonID", typeof(int));

                _dtRecGrid.Columns.Add("Copy", typeof (string));
                _dtRecGrid.Columns.Add("CopyGUID");
                _dtRecGrid.Columns.Add("IsCopied",typeof(bool));
                    //this column will be used during splitting an Item on a Draft receive.
                _dtRecGrid.Columns.Add("Store", typeof (string));
            }

            int count = 1;
            // Bind the manufacturer editor
            BLL.Manufacturer mfs = new Manufacturer();
            BLL.ItemManufacturer imf = new BLL.ItemManufacturer();
            mfs.LoadAll();
            editManufacturer.DataSource = mfs.DefaultView;

            editManuf2.DataSource = mfs.DefaultView;
            editManuf3.DataSource = mfs.DefaultView;
            EditRecivingBoxLevels.DataSource = BLL.ItemManufacturer.PackageLevelKeys;
            DataTable dtbl = (DataTable)gridSelected.DataSource;

            //bool srm = false;
            srm = Convert.ToInt32(cboReceiveType.EditValue) == ReceiptType.CONSTANTS.STOCK_RETURN;

            foreach (DataRow lst in dtbl.Rows)
            {

                if (lst["IsSelected"] == DBNull.Value || Convert.ToBoolean(lst["IsSelected"]))
                {
                    string itemName = lst["FullItemName"].ToString();


                    bool validateSRM = srm && !chkSRMForOldSystemIssues.Checked;

                    DataRow dr = _dtRecGrid.NewRow();
                    dr["ID"] = lst["ID"];
                    dr["StockCode"] = dr["Stock Code"] =lst["StockCode"];
                    dr["Item Name"] = itemName;

                    if (validateSRM || hasPreviousReceive || (standardRecType == StandardReceiptType.iGRVOnline) ||
                        (deliveryNoteType == DeliveryNoteType.Automatic))
                    {
                        dr["Unit"] = lst["Unit"];
                        dr["Manufacturer"] = lst["ManufacturerID"];
                        dr["Batch No"] = lst["BatchNo"];
                        dr["UnitID"] = lst["UnitID"];
                        dr["Expiry Date"] = lst["ExpDate"];
                        if (validateSRM)
                        {
                            dr["IssuedQty"] = lst["IssuedQty"];
                            dr["IssueDocID"] = lst["IssueDocID"];
                        }
                        if (hasPreviousReceive)
                        {
                            dr["OriginalInvoicedQty"] = lst["InvoicedNoOfPack"];
                            dr["InvoicedQty"] = lst["InvoicedNoOfPack"];
                            dr["RemainingQty"] = lst["RemainingQty"];
                        }
                        if (standardRecType == StandardReceiptType.iGRVOnline)
                        {
                            dr["OriginalInvoicedQty"] = lst["InvoicedNoOfPack"];
                            dr["InvoicedQty"] = lst["InvoicedNoOfPack"];
                            dr["Price/Pack"] = lst["UnitPrice"];
                            dr["Margin"] = lst["Margin"];
                        }
                        if (deliveryNoteType == DeliveryNoteType.Automatic)
                        { 
                            dr["OriginalInvoicedQty"] = lst["InvoicedNoOfPack"];
                            dr["InvoicedQty"] = lst["InvoicedNoOfPack"];
                            dr["Price/Pack"] = lst["UnitPrice"];
                            dr["Margin"] = lst["Margin"];
                        }
                    }


                    count++;
                    lst["IsSelected"] = false;
                   
                    dr["Ordering"] = _LastOrdering++;
                    dr["GUID"] = Guid.NewGuid();
                    dr["Copy"] = "Orginal";
                    dr["IsCopied"] = false;
                    dr["CopyGUID"] = Guid.NewGuid();
                    dr["IsDamaged"] = false;
                    _dtRecGrid.Rows.Add(dr);

                }
            }
            _dtRecGrid.DefaultView.Sort = "Ordering";
            receivingGrid.DataSource = _dtRecGrid.DefaultView;

            repoLkEditNotReceivedReason.DataSource = BLL.ShortageReasons.GetAllReasons();
            if (srm)
            {
                lcRemark.Text = "Reason for SRM";
            }
            dtRecDate.CustomFormat = "MMM dd,yyyy";
        }

        private bool IsFirstTabValid()
        {
            // check if the receive is being saved with a future date
            // it can receive date +1 
            if (dtRecDate.Value > BLL.DateTimeHelper.ServerDateTime)
            {
                XtraMessageBox.Show("You cannot receive in a future date. please correct the date and try again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!dxValidateAccount.Validate())
            {
                //XtraMessageBox.Show("Please select Account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Check if Supplier is selected
            if (!srm && !beginningBalance)
            {
                if (BLL.Settings.IsCenter && !dxValidateReceiveInvoice.Validate())
                {
                    return false;
                }

                
            }

            if (dxValidatePassCode.Validate() && _isElectronic && !_isNonElectronicReceiveOnly)
            {

                if (standardRecType.Equals(StandardReceiptType.iGRVOnline) ||
                    deliveryNoteType == DeliveryNoteType.Automatic)
                {
                    if (dxValidatePassCode.Validate())
                    {
                        var receipt = new ReceiptInvoice();

                        receipt.GetPrintedDate(Convert.ToInt32(lkReceiptInvoice.EditValue));
                        var printedDate = (DateTime)receipt.GetColumn("PrintedDate");

                        try
                        {
                            var hourAndminute = printedDate.ToString("h:mm tt").Split(' ')[0].Replace(":", string.Empty);

                            if (hourAndminute != txtPassCode.Text)
                            {
                                XtraMessageBox.Show(
                                    "Value entered in the pass code is not correct.  Please enter the printed Hour and Minute from the STV .",
                                    "Pass Code Incorrect");
                                return false;
                            }
                        }
                        catch (FormatException ex)
                        {
                            XtraMessageBox.Show(
                                "Value format entered in the pass code is not correct.  Please use this format : mm/dd/yyyy",
                                "Pass Code Incorrect");
                            return false;
                        }
                    }

                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        #endregion

        #region Step two

        private bool IsRecieveGridValid()
        {
            bool valid = true;
            for (int i = 0; i < gridRecieveView.RowCount; i++)
            {
                DataRow dr = gridRecieveView.GetDataRow(i);
                Item itm = new Item();
                itm.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));
                dr.ClearErrors();

                if (!BLL.Settings.HandleGRV && srm != true)
                //The price is entered right here if we don't handle the GRVs
                {
                    //Unless it is a receive by delivery note, price needs to be entered.
                    //txtSTVNo.Text = txtRefNo.Text;
                    if ((dr["Price/Pack"] == DBNull.Value || dr["Price/Pack"] == null ||
                         dr["Price/Pack"].ToString() == "") && deliveryNoteType == DeliveryNoteType.NotSet)
                    {
                        dr.SetColumnError("Price/Pack", @"Please fill the cost");

                        valid = false;
                    }

                    //If it is a delivery note receive, it cannot have price.
                    //var pricePerPack = "";
                    if (dr["Price/Pack"] != DBNull.Value && dr["Price/Pack"] != null)
                    {
                      var  pricePerPack = Convert.ToString(dr["Price/Pack"]);

                        if ((deliveryNoteType != DeliveryNoteType.NotSet) &&
                            (pricePerPack != "" && Convert.ToDouble(pricePerPack) != 0))
                        {
                            dr.SetColumnError("Price/Pack", @"A Delivery note receive cannot have price information");

                            valid = false;
                        }
                    }

                }

                // Require batch if the store (account type) is the program/Free store or if the EnforceBatch Setting is set to true.
                bool enforceBatch = BLL.Settings.EnforceBatchTracking;
                //Check if Empty before checking Batch
                if (lkAccounts.EditValue != null)
                {
                    var activity = new Activity();
                    activity.LoadByPrimaryKey(int.Parse(lkAccounts.EditValue.ToString()));

                    if (activity.IsHealthProgram() || enforceBatch)
                    {
                        if ((!itm.IsColumnNull("NeedExpiryBatch") && itm.NeedExpiryBatch) &&
                            (dr["Batch No"] == DBNull.Value || dr["Batch No"].ToString() == ""))
                        {
                            dr.SetColumnError("Batch No", @"Can not be Null");
                            valid = false;
                        }
                    }
                }

                if (dr["UnitID"] == DBNull.Value)
                {
                    dr.SetColumnError("UnitID", @"Can not be Null");
                    valid = false;
                }

                if (dr["Pack Qty"] == DBNull.Value)
                {
                    dr.SetColumnError("Pack Qty", @"Can not be Null");
                    valid = false;
                }

                else
                {
                    if (srm && !chkSRMForOldSystemIssues.Checked &&
                        Convert.ToDecimal(dr["Pack Qty"]) > Convert.ToDecimal(dr["IssuedQty"]))
                    {
                        dr.SetColumnError("Pack Qty", @"Can not exceed issued quantity!");
                        valid = false;
                        XtraMessageBox.Show(
                            "Returned quantity cannot be greater than the issued quantity.  Please review the grid.",
                            "SRM Error");
                    }
                }


                if ((!itm.IsColumnNull("NeedExpiryBatch") && itm.NeedExpiryBatch) && (dr["Expiry Date"] == DBNull.Value))
                {
                    dr.SetColumnError("Expiry Date", @"Can not be Null");
                    //gridRecieveView.SetColumnError(gridRecieveView.Columns[], );
                    valid = false;
                }
                else
                {
                    if (dr["Expiry Date"] != DBNull.Value)
                    {
                        DateTime expiryDate = Convert.ToDateTime(dr["Expiry Date"]);
                        if (DateTime.Today.Subtract(expiryDate).Days > 0)
                        {
                            dr["IsDamaged"] = true;
                        }
                    }
                }

                if (dr["Manufacturer"] == DBNull.Value || dr["Manufacturer"].ToString() == "")
                {
                    dr.SetColumnError("Manufacturer", @"Manufacturer cannot be left null");
                    valid = false;
                }
                gridRecieveView.RefreshData();
            }
            if (!beginningBalance && (deliveryNoteType == DeliveryNoteType.NotSet) && !srm && !BLL.Settings.HandleGRV &&
                !dxValidateRefNo.Validate())
            {
                //XtraMessageBox.Show("Please Fill the Goods Receive Note Number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valid = false;
            }
            else
            {
                // TODO: check if the reference number is unique.


            }


            return valid && ValidateStep2() && ValidateStep2DuplicateRows();
        }

        private bool ValidateStep2DuplicateRows()
        {
            bool valid = true;
            gridRecieveView.ClearColumnErrors();

            if (gridRecieveView.RowCount != 0)
            {
                for (int i = 0; i < gridRecieveView.RowCount; i++)
                {
                    DataRow dri = gridRecieveView.GetDataRow(i);
                    for (int j = i + 1; j < gridRecieveView.RowCount; j++)
                    {
                        DataRow drj = gridRecieveView.GetDataRow(j);
                        if (
                            ((string)dri["Item Name"]).Equals(
                                (string)drj["Item Name"]) &&
                            ((int)dri["UnitID"]).Equals(
                                (int)drj["UnitID"]) &&
                            ((string)dri["Manufacturer"]).Equals(
                                (string)drj["Manufacturer"]) &&
                            ((string)dri["Batch No"]).Equals(
                                (string)drj["Batch No"]) &&
                            ((DateTime)dri["Expiry Date"]).Equals(
                                (DateTime)drj["Expiry Date"])
                            )
                        {
                            if (dri["Copy"].ToString() == "Orginal" && srm) continue;
                            valid = false;

                            dri.SetColumnError("Item Name", @"Duplicate Rows");
                            dri.SetColumnError("UnitID", @"Duplicate Rows");
                            dri.SetColumnError("Manufacturer", @"Duplicate Rows");
                            dri.SetColumnError("Batch No", @"Duplicate Rows");
                            dri.SetColumnError("Expiry Date", @"Duplicate Rows");
                            drj.SetColumnError("Item Name", @"Duplicate Rows");
                            drj.SetColumnError("UnitID", @"Duplicate Rows");
                            drj.SetColumnError("Manufacturer", @"Duplicate Rows");
                            drj.SetColumnError("Batch No", @"Duplicate Rows");
                            drj.SetColumnError("Expiry Date", @"Duplicate Rows");

                            XtraMessageBox.Show(
                                "Duplicate rows by Item Name, Manufacturer, Unit, Batch No and Expiry Date is not allowed.",
                                "Duplicate Rows", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            return valid;
        }

        private void OnAnyCellValueChangedOnRecieveGrid(object sender,CellValueChangedEventArgs e)
        {
            var invoiceNo = lkReceiptInvoice.Text;
            var IsElectronic = ReceiptInvoice.IsInvoiceElectronic(invoiceNo);

            GridView view = sender as GridView;
            // make general calculations
            gridRecieveView.RefreshData();
            DataRow dr = gridRecieveView.GetFocusedDataRow();
            dr.ClearErrors();

            int manufid = Convert.ToInt32(dr["Manufacturer"]);
            int itemid = Convert.ToInt32(dr["ID"]);
            int unitid = Convert.ToInt32(dr["UnitID"]);
            string batchNofilter = (Convert.ToString(dr["Batch No"]).Equals("")) ? "" : string.Format(" And [Batch No] = '{0}'", Convert.ToString(dr["Batch No"]));
            string filterString = string.Format(
                "ID = '{0}' AND UnitID = '{1}' AND Manufacturer = '{2}' {3} ", itemid, unitid, manufid, batchNofilter);

            if (dr["Manufacturer"] != DBNull.Value && dr["Manufacturer"] != null && dr["Manufacturer"].ToString() != "")
            {
                BLL.ItemManufacturer im = new BLL.ItemManufacturer();
                im.LoadIMbyLevel(itemid, manufid, 0);
                im.LoadDefaultReceiving(itemid, manufid);
                //dr["Manufacturer"] = manufid;
                dr["BoxLevel"] = im.PackageLevel;
                dr["BasicUnitPerQ"] = im.QuantityInBasicUnit;
                if (dr["Pack Qty"] != DBNull.Value && dr["Pack Qty"] != string.Empty)
                    dr["BU Qty"] = (im.QuantityInBasicUnit * Convert.ToDecimal(dr["Pack Qty"]));
                dr["LevelView2"] = im.LevelView2;
            }

            if ((view.FocusedColumn.FieldName == "Manufacturer") || (view.FocusedColumn.FieldName == "Pack Qty"))
            {
                SuggestComposition();
            }

            //if the item is expired then it's considered as damaged
            if (dr["Expiry Date"] != DBNull.Value &&
                Convert.ToDateTime(dr["Expiry Date"]) <= DateTimeHelper.ServerDateTime)
            {
                dr["IsDamaged"] = true;
            }

            decimal invoicedQty = 0;
            decimal receivedQty = 0;
            decimal difference = 0;
            decimal remainingQty = 0;

            if (dr["InvoicedQty"] != DBNull.Value && dr["Pack Qty"] != DBNull.Value && dr["Pack Qty"] != string.Empty)
            {
                var receiveGridDataSource = (gridRecieveView.DataSource as DataView).ToTable();
                var invRows = receiveGridDataSource.Select(filterString);

                invoicedQty = invRows.Sum(r => r.Field<decimal>("OriginalInvoicedQty"));

                var rows = receiveGridDataSource.Select(filterString);

                receivedQty = rows.CopyToDataTable().Select("[Pack Qty] IS NOT NULL").Sum(r => r.Field<decimal>("Pack Qty"));
              
                difference = invoicedQty - receivedQty;
                
                //update NotReceivedColumn
                _dtRecGrid.Select(filterString).ToList<DataRow>().ForEach(r => r["NotReceived"] = difference);

                if (!BLL.Settings.AllowBonusReceive && hasPreviousReceive && dr["RemainingQty"] != DBNull.Value)
                {
                    remainingQty = Convert.ToDecimal(dr["RemainingQty"]);
                    if (remainingQty - receivedQty < 0)
                    {
                        dr.SetColumnError("Pack Qty", "Unable to receive a quantity more than remaining Qty ");
                        dr["Pack Qty"] = DBNull.Value;
                        difference = 0;
                    }
                }

            }
            if (srm && Convert.ToBoolean(dr["IsDamaged"]))
            {
                dr["ShortageReasonID"] = ShortageReasons.Constants.DAMAGED;
            }

            if (difference > 0)
            {
                //int invoicedQty = Convert.ToInt32(dr["InvoicedQty"]);
                //int receivedQty = Convert.ToInt32(dr["Pack Qty"]);
                //int difference = invoicedQty - receivedQty;
                DataTable filteredTbl;
                DataRow newDataRow = null;

                lcShortageOrDamage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                DataTable tbl = _dtRecGrid.Clone();

                bool notEntered = true;

                if (grdShortageOrDamaged.DataSource != null && (grdShortageOrDamaged.DataSource as DataTable).Rows.Count != 0)
                {
                    //tbl = ((DataView) grdViewShortageOrDamaged.DataSource).ToTable();
                    var dataView = (DataTable) grdShortageOrDamaged.DataSource;


                    DataRow[] filteredTable = dataView.Select(filterString);

                    if (filteredTable.Length > 0) //If the item/row is already in the descrepancy grid
                    {
                        notEntered = false;
                        //TODO: We're using the first one for now.  If there are more than one.  Needs to be handled.

                        foreach (DataRow drShortages in filteredTable)
                        {
                            if (filteredTable.Length == 1)
                            {
                                drShortages["Pack Qty"] = difference;
                            }
                            else
                            {
                                drShortages["Pack Qty"] = DBNull.Value;
                            }


                            newDataRow = drShortages;

                            //drShortages["Pack Qty"] = difference; //Commented out because we don't want to change user modified values.
                            drShortages["ManufacturerName"] = editManufacturer.GetDisplayText(dr["Manufacturer"]);
                            drShortages["UnitText"] = editUnits.GetDisplayText(dr["UnitID"]);
                            drShortages["UnitID"] = dr["UnitID"];
                            drShortages["Unit"] = dr["Unit"];
                            drShortages["Batch No"] = dr["Batch No"];
                            drShortages["Expiry Date"] = dr["Expiry Date"];
                            drShortages["Item Name"] = dr["Item Name"];
                            drShortages["Stock Code"] = dr["Stock Code"];
                            drShortages["Manufacturer"] = dr["Manufacturer"];
                            drShortages["ID"] = dr["ID"];
                            drShortages["GUID"] = dr["GUID"];

                        }
                    }
                }

                if (grdShortageOrDamaged.DataSource != null && (grdShortageOrDamaged.DataSource as DataTable).Rows.Count == 0 || notEntered)
                {
                    if (grdViewShortageOrDamaged.DataSource != null)
                        tbl = ((DataView)grdViewShortageOrDamaged.DataSource).ToTable();

                    if (!tbl.Columns.Contains(("ShortageReasonID")))
                    {
                        tbl.Columns.Add("ShortageReasonID", typeof(int));
                    }
                    if (!tbl.Columns.Contains("ManufacturerName"))
                    {
                        tbl.Columns.Add("ManufacturerName");
                    }
                    if (!tbl.Columns.Contains("UnitText"))
                    {
                        tbl.Columns.Add("UnitText");
                    }
                }

                bool isNewRow = false;

                if (newDataRow == null)
                {
                    dr.EndEdit();
                    if (tbl != null)
                    {
                        var rows = tbl.Select(filterString);
                        isNewRow = rows.Count() == 0;
                    }
                    if (tbl == null || isNewRow)
                    {
                        tbl.ImportRow(dr);
                        newDataRow = tbl.Rows[tbl.Rows.Count - 1];
                        newDataRow["Pack Qty"] = difference;
                        newDataRow["ManufacturerName"] = editManufacturer.GetDisplayText(dr["Manufacturer"]);
                        newDataRow["UnitText"] = editUnits.GetDisplayText(dr["UnitID"]);
                
                    }
                }

                if (hasPreviousReceive && difference > 0 && difference == (invoicedQty - remainingQty))
                {
                    newDataRow["ShortageReasonID"] = BLL.ShortageReasons.Constants.NOT_RECEIVED;
                }

                if (tbl.Rows.Count != 0)
                {
                    foreach (DataRow d in tbl.Rows)
                    {
                        d["IsDamaged"] = true;
                        d["OriginalInvoicedQty"] = 0;
                    }
                    grdShortageOrDamaged.DataSource = tbl;
                }

            }

            else if (difference == 0 && grdViewShortageOrDamaged.RowCount != 0)
            {
                       RemoveFromDiscrepancyByFilter(filterString);
            }

        }

        private void RemoveFromDiscrepancy(string guid)
        {
            if (grdViewShortageOrDamaged.RowCount > 0)
            {
                //tbl = ((DataView) grdViewShortageOrDamaged.DataSource).ToTable();
                var dataView = ((DataTable)grdShortageOrDamaged.DataSource).AsDataView();
                string filter =
                    string.Format(
                        "[GUID]='{0}'",
                        guid);

                foreach (DataRow dr in dataView.Table.Select(filter))
                {
                    dataView.Table.Rows.Remove(dr);
                }
            }

            if (grdViewShortageOrDamaged.RowCount == 0)
            {
                grdShortageOrDamaged.DataSource = null;
                lcShortageOrDamage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void RemoveFromDiscrepancyByFilter(string filter)
        {
            if (grdViewShortageOrDamaged.RowCount > 0)
            {
                //tbl = ((DataView) grdViewShortageOrDamaged.DataSource).ToTable();
                var dataView = ((DataTable)grdShortageOrDamaged.DataSource).AsDataView();

                foreach (DataRow dr in dataView.Table.Select(filter))
                {
                    dataView.Table.Rows.Remove(dr);
                }
            }

            if (grdViewShortageOrDamaged.RowCount == 0)
            {
                grdShortageOrDamaged.DataSource = null;
                lcShortageOrDamage.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void repositoryItemButtonEdit11_Click(object sender, EventArgs e)
        {
            ReceivePackage rp = new ReceivePackage();
            rp.StartPosition = FormStartPosition.CenterScreen;
            rp.ShowDialog();
        }

   
        private void btnPlusMinusMain_ButtonClick(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Split")
            {
                DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
                DataRow drNew = _dtRecGrid.NewRow();
                drNew.ItemArray = dr.ItemArray;
                if (dr["Copy"] == DBNull.Value || Convert.ToString(dr["Copy"]) == "Orginal")
                {
                    dr["Copy"] = "Orginal";
                    drNew["Copy"] = "Orginal";
                }
                drNew["IsCopied"] = true;
                drNew["GUID"] = Guid.NewGuid();
                drNew["CopyGUID"] = dr["CopyGUID"];
                drNew["Pack Qty"] = DBNull.Value;
                drNew["OriginalInvoicedQty"] = 0;
                _dtRecGrid.Rows.Add(drNew);
                _dtRecGrid.DefaultView.Sort = "Ordering, Stock Code";
            }
            else
            {
                DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
                if (Convert.ToBoolean(dr["IsCopied"]) || (colRemainingQty.Visible && dr["RemainingQty"] != DBNull.Value && Convert.ToDecimal(dr["RemainingQty"]) <= 0) || (Convert.ToDecimal(dr["Pack Qty"]) == 0) && srm) //~ Let us allow them to remove an entry with a full receive, Note: a negetive remaining qty show there was a bonus receive ~//
                {
                    RemoveFromDiscrepancy(dr["GUID"].ToString());
                    _dtRecGrid.Rows.Remove(dr);
                }
            }
        }

        private void repositoryItemRichTextEdit1_Click(object sender, EventArgs e)
        {
            //XtraMessageBox.Show("I am here");
            DataRow dr = gridRecieveView.GetFocusedDataRow();
            if (dr["PC"] != DBNull.Value)
            {
                decimal sku = Convert.ToDecimal(dr["Pack Qty"]);
                string ItemName = dr["Item Name"].ToString();
                string BatchNo = dr["Batch No"].ToString();
                ReceiveComposition rc = new ReceiveComposition();
                rc.ShowFor(this, ItemName, sku, dr["PC"] as DataTable, BatchNo);
            }
        }

        private void gridRecieveView_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colSelectManufacturer)
            {
                if (e.CellValue == null || e.CellValue.ToString() == "")
                {
                    e.DisplayText = "Select Manufacturer";
                }
            }
        }

        private void SuggestComposition()
        {
            DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
            if (dr["Pack Qty"].ToString() == "")
            {
                return;
            }
            decimal qty = Convert.ToDecimal(dr["Pack Qty"]);
            //if (qty > 0)
            //{

            if (dr["Manufacturer"] != null && dr["Manufacturer"].ToString() != "")
            {
                int manufID;
                int plevel;
                int itemId;

                try
                {
                    manufID = Convert.ToInt32(dr["Manufacturer"]);
                    plevel = Convert.ToInt32(dr["BoxLevel"]);
                    itemId = Convert.ToInt32(dr["ID"]);
                }
                catch
                {
                    return;
                }
                BLL.ItemManufacturer im = new BLL.ItemManufacturer();
                im.LoadIMbyLevel(itemId, manufID, 0);
                dr["BU Qty"] = (im.QuantityInBasicUnit * qty);
                //dr["LevelView2"] = im.LevelView2;

                DataTable dtbl = im.SuggestComposition(itemId, manufID, qty);
                dr["PalletComposition"] = im.ConvertCompositionToString(dtbl);
                dr["PC"] = dtbl;
                //}
            }
        }

        private void OnAnyPopupOpenedOnRecieveGrid(object sender, EventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn.FieldName == "UnitID")
            {
                LookUpEdit lke = (LookUpEdit)view.ActiveEditor;
                lke.EditValue = null;
                DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
                int id = Convert.ToInt32(dr["ID"]);
                ItemUnit itemUnit = new ItemUnit();
                itemUnit.LoadAllForItem(id);
                lke.Properties.DataSource = itemUnit.DefaultView;
            }

            if (view.FocusedColumn.FieldName == "Manufacturer")
            {
                LookUpEdit lke = (LookUpEdit)view.ActiveEditor;
                lke.EditValue = null;
                DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
                int id = Convert.ToInt32(dr["ID"]);
                Manufacturer mfs = new Manufacturer();
                mfs.LoadForItem(id);
                lke.Properties.DataSource = mfs.DefaultView;
            }
            if (view.FocusedColumn.FieldName == "BoxLevel")
            {
                LookUpEdit lke = (LookUpEdit)view.ActiveEditor;
                DataRow dr = gridRecieveView.GetDataRow(gridRecieveView.GetSelectedRows()[0]);
                int id = Convert.ToInt32(dr["ID"]);
                if (dr["Manufacturer"].ToString() != "")
                {
                    int manuf = Convert.ToInt32(dr["Manufacturer"]);
                    BLL.ItemManufacturer imf = new BLL.ItemManufacturer();
                    lke.Properties.DataSource = imf.LoadLevelsFor2(id, manuf);
                }
                else
                {
                    lke.Properties.DataSource = null;
                }

            }
        }

        private void chkDeliveryNote_CheckedChanged(object sender, EventArgs e)
        {
            CheckEdit chkDeliveryNote = (CheckEdit)sender;
        }

        #endregion

        #region Step three

        private int GetPalletID(string palletNumber)
        {
            Pallet plt = new Pallet();
            plt.LoadByPalletNumber(palletNumber);
            if (plt.RowCount == 0)
            {
                plt.AddNew();
                plt.PalletNo = Convert.ToInt32(palletNumber);
                plt.Save();
            }
            return plt.ID;
        }

        private void OnDividePalletsClicked(object sender, EventArgs e)
        {
            DataRow dr = gridPalletizedView.GetFocusedDataRow();
            //DataRow newRow = dtRecGrid.NewRow();
            decimal qty = Convert.ToDecimal(dr["Pack Qty"]);
            if (qty > 1)
            {
                decimal qty2 = qty / 2;
                dr["Pack Qty"] = (qty2);
                _dtPalletizedItemList.ImportRow(dr);
                dr["Pack Qty"] = (qty - qty2);
                _dtPalletizedItemList.DefaultView.Sort = "ID, Expiry Date";

            }
            CalculateVolumes();
        }

        private void OnRePalletizeClicked(object sender, EventArgs e)
        {
            PalletizeRecievedItems();
        }

        private bool PalletizationIsValid()
        {
            if (_dtPalletizedItemList == null)
            {
                return false;
            }
            bool valid = true;
            // check if the items are of equal quantity
            DataTable palletized = _dtPalletizedItemList.DefaultView.ToTable(); //(true, "Ordering", "Expiry Date");

            foreach (DataRow dr in palletized.Rows)
            {
                string guid = dr["GUID"].ToString();
                DataRow[] arrReceive = null;
                arrReceive = _dtRecGrid.Select(string.Format("[GUID] = '{0}'", guid));
                DataRow[] arrPalletized = null;
                arrPalletized = _dtPalletizedItemList.Select(string.Format("[GUID] = '{0}'", guid));
                DataRow[] arrNonPalletized = null;
                arrNonPalletized = _dtNonPalletizedItemList.Select(string.Format("[GUID] = '{0}'", guid));
                DataView dataView = null;
                if (grdShortageOrDamaged.DataSource != null)
                {
                    dataView = ((DataTable)grdShortageOrDamaged.DataSource).AsDataView();
                    dataView.RowFilter = string.Format("[GUID]='{0}' and [ShortageReasonID] = {1}", guid,
                        BLL.ShortageReasons.Constants.DAMAGED);
                    //Since we want to do quantity verification only, we need the damaged ones only.  This is because unlike the other type of discrepancies, the damaged adds quantity to the stock.
                }
                DataRowCollection arrDamaged = null;
                if (dataView != null)
                    arrDamaged = dataView.ToTable().Rows;

                // find sum of BU Qty in arr,
                decimal receiveQty = 0;
                decimal palletizedQty = 0;
                decimal nonPalletizedQty = 0;
                decimal damagedQty = 0;

                if (arrReceive != null)
                {
                    foreach (DataRow d in arrReceive)
                    {
                        d.ClearErrors();
                        receiveQty += Convert.ToDecimal(d["Pack Qty"]);
                    }
                }
                if (arrPalletized != null)
                {
                    foreach (DataRow d in arrPalletized)
                    {
                        d.ClearErrors();
                        palletizedQty += Convert.ToDecimal(d["Pack Qty"]);
                    }
                }

                if (arrNonPalletized != null)
                {
                    foreach (DataRow d in arrNonPalletized)
                    {
                        d.ClearErrors();
                        nonPalletizedQty += Convert.ToDecimal(d["Pack Qty"]);
                    }
                }

                if (arrDamaged != null)
                {
                    foreach (DataRow d in arrDamaged)
                    {
                        d.ClearErrors();
                        damagedQty += Convert.ToDecimal(d["Pack Qty"]);
                    }
                }

                if (receiveQty != (palletizedQty + nonPalletizedQty - damagedQty))
                {
                    foreach (DataRow d in arrPalletized)
                    {
                        d.SetColumnError("Pack Qty",
                            String.Format("Sum should be equal to what's specified in Step two({0})", receiveQty));
                    }
                    // this was an error
                    valid = false;

                }
            }

            Pallet plt = new Pallet();
            // check if the pallet # don't allow null or 0
            foreach (DataRow dr in _dtPalletizedItemList.Rows)
            {

                if (dr["PalletNumber"] == DBNull.Value || dr["PalletNumber"].ToString().Equals("") ||
                    Convert.ToInt32(dr["PalletNumber"]) == 0)
                {
                    dr.SetColumnError("PalletNumber", "The Pallet Number you specified is Already Used.");
                    valid = false;
                    continue;
                }
            }

            // check if same expiry on a single pallet location rule is held
            DataTable PalletNumbers = _dtPalletizedItemList.DefaultView.ToTable(true, "PalletNumber");
            foreach (DataRow dr in PalletNumbers.Rows)
            {
                // validate if the pallet number specified is not already used



                plt.LoadByPalletNumber(dr["PalletNumber"].ToString());

                if (plt.RowCount > 0)
                {
                    // there is an existing pallet number in the pallet list

                    DataRow[] darr =
                        _dtPalletizedItemList.Select(string.Format("PalletNumber = '{0}'", dr["PalletNumber"]));
                    foreach (DataRow d in darr)
                    {

                        if (!Convert.ToBoolean(d["Consolidate"]))
                        {
                            d.SetColumnError("PalletNumber", "The Pallet Number you specified is Already Used.");
                            valid = false;
                        }
                    }

                    continue;
                }

                DataRow[] arr1 = _dtPalletizedItemList.Select(string.Format("PalletNumber = '{0}'", dr["PalletNumber"]));
                int ItemID = 0;
                DateTime ExpiryDate = DateTime.Today;
                foreach (DataRow drw in arr1)
                {
                    if (ItemID == 0)
                    {
                        ItemID = Convert.ToInt32(drw["ID"]);
                        if (drw["Expiry Date"] != DBNull.Value)
                        {
                            ExpiryDate = Convert.ToDateTime(drw["Expiry Date"]);
                        }
                    }
                    else
                    {
                        //Validate if the same Item,with same Epiry date is in the same pallet
                        if (ItemID != Convert.ToInt32(drw["ID"]))
                        {
                            drw.SetColumnError("Item Name", "Different Items couldn't be put on the same pallet.");
                            valid = false;
                        }
                        if (drw["Expiry Date"] != DBNull.Value)
                        {
                            if (ExpiryDate.Subtract(Convert.ToDateTime(drw["Expiry Date"])).Days != 0)
                            {
                                drw.SetColumnError("Expiry Date",
                                    "Items With Different Expiry Date couldn't be put on the same pallet.");
                                valid = false;
                            }
                        }
                    }
                }
            }


            return valid;
        }

        internal void UpdateComposition(DataTable dataTable)
        {
            DataRow dr = gridRecieveView.GetFocusedDataRow();
            BLL.ItemManufacturer im = new BLL.ItemManufacturer();
            dr["PC"] = dataTable;
            dr["PalletComposition"] = im.ConvertCompositionToString(dataTable);
        }

        private void gridPalletizedView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            DataRow drv = gridPalletizedView.GetDataRow(e.RowHandle);
            if (e.Column == columnPalletNumber)
            {

                if (Convert.ToBoolean(drv["CanConsolidate"]))
                {
                    e.RepositoryItem = repoLKConsolidate;
                }
                else
                {
                    e.RepositoryItem = repoPalletNo;
                }

            }
            if (e.Column == colButtonConsolidate)
            {
                if (!Convert.ToBoolean(drv["CanConsolidate"]))
                {
                    e.RepositoryItem = null;
                }
            }
        }

        private void repoPalletNo_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridPalletizedView.GetFocusedDataRow();
            // check if the item is consolidable
            PalletLocation pll = new PalletLocation();
            pll.LoadConsolidationOption(Convert.ToInt32(dr["ID"]), Convert.ToDateTime(dr["Expiry Date"]),
                Convert.ToInt32(dr["BoxLevel"]), Convert.ToInt32(lkAccounts.EditValue));

            if (pll.RowCount > 0)
            {
                dr["PalletNumber"] = DBNull.Value;
                dr["CanConsolidate"] = true;
            }
            else
            {
                dr["CanConsolidate"] = false;
            }
            dr["Consolidate"] = false;
            dr.EndEdit();
            gridPalletizedView.RefreshData();
            //btnNextStep3.Focus();
        }

        private void gridPalletizedView_ShownEditor(object sender, EventArgs e)
        {
            DataRow dr = gridPalletizedView.GetFocusedDataRow();
            // check if the item is consolidable
            PalletLocation pll = new PalletLocation();

            DateTime? dt = null;
            if (dr["Expiry Date"] != DBNull.Value)
            {
                dt = Convert.ToDateTime(dr["Expiry Date"]);
            }
            pll.LoadConsolidationOption(Convert.ToInt32(dr["ID"]), dt, Convert.ToInt32(dr["BoxLevel"]),
                Convert.ToInt32(lkAccounts.EditValue));

            //DataRowView drv = pll.DefaultView.AddNew();
            //drv["Label"] = "New Pallet";
            //drv["ID"] = 0;


            GridView view = sender as GridView;
            if (view.FocusedColumn == columnPalletNumber)
            {
                try
                {
                    LookUpEdit lke = (LookUpEdit)view.ActiveEditor;
                    lke.EditValue = null;

                    lke.Properties.DataSource = pll.DefaultView;
                }
                catch
                {
                }
            }
        }

        private void repoLKConsolidate_EditValueChanging(object sender,
            DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            //btnNextStep3.Focus();
        }

        private void repoLKConsolidate_EditValueChanged(object sender, EventArgs e)
        {
            DataRow dr = gridPalletizedView.GetFocusedDataRow();
            if (dr["PalletNumber"] != DBNull.Value && Convert.ToInt32(dr["PalletNumber"]) == 0)
            {
                dr["PalletNumber"] = DBNull.Value;
                dr["Consolidate"] = false;
                dr["CanConsolidate"] = false;
                dr.EndEdit();
            }
            else
            {
                dr["Consolidate"] = true;
            }
            dr.EndEdit();
            gridPalletizedView.RefreshData();
        }

        private void btnConsolidate_Click(object sender, EventArgs e)
        {
            DataRow dr = gridPalletizedView.GetFocusedDataRow();
            dr.ClearErrors();
            //// check if the item is consolidable
            PalletLocation pll = new PalletLocation();
            DateTime? dt = null;
            if (dr["Expiry Date"] != DBNull.Value)
            {
                dt = Convert.ToDateTime(dr["Expiry Date"]);
            }
            pll.LoadConsolidationOption(Convert.ToInt32(dr["ID"]), dt, Convert.ToInt32(dr["BoxLevel"]),
                Convert.ToInt32(lkAccounts.EditValue));

            if (Convert.ToBoolean(dr["CanConsolidate"]))
            {

                dr["CanConsolidate"] = false;
                dr["Consolidate"] = false;
                dr.EndEdit();
            }
            else
            {
                if (pll.RowCount > 0)
                {
                    dr["PalletNumber"] = DBNull.Value;
                    dr["CanConsolidate"] = true;
                }
                else
                {
                    dr["CanConsolidate"] = false;
                }
                dr["Consolidate"] = false;
                dr.EndEdit();
            }
            gridPalletizedView.InvalidateRow(gridPalletizedView.FocusedRowHandle);

        }

        private void PalletizeRecievedItems()
        {
            if (_dtPalletizedItemList == null)
            {
                _dtPalletizedItemList = _dtRecGrid.Clone();

                _dtPalletizedItemList.Columns.Add("PalletNumber");
                _dtPalletizedItemList.Columns.Add("Multiplier");
                _dtPalletizedItemList.Columns.Add("Volume");
                _dtPalletizedItemList.Columns.Add("BoxSizeDisplay");
                _dtPalletizedItemList.Columns.Add("Consolidate", typeof(bool));
                _dtPalletizedItemList.Columns.Add("CanConsolidate", typeof(bool));
                _dtPalletizedItemList.Columns.Add("PutAwayLocation", typeof(bool));
                _dtPalletizedItemList.Columns.Add("IsStoredInFreeStorageType", typeof(bool));
                _dtPalletizedItemList.Columns.Add("Index", typeof(int));
                //_dtPalletizedItemList.Columns.Add("GUID", typeof(string));

                _dtNonPalletizedItemList = _dtRecGrid.Clone();
                _dtNonPalletizedItemList.Columns.Add("Volume");
                _dtNonPalletizedItemList.Columns.Add("StorageTypeID");
                //_dtNonPalletizedItemList.Columns.Add("GUID", typeof(string));
                _dtNonPalletizedItemList.Columns.Add("Index", typeof(int));
                _dtNonPalletizedItemList.Columns.Add("Multiplier");
                _dtNonPalletizedItemList.Columns.Add("BoxSizeDisplay");


                // dtNonPalletizedItemList.Columns.Add("IsDamaged", typeof(bool));
            }
            else
            {
                _dtPalletizedItemList.Clear();
                _dtNonPalletizedItemList.Clear();
            }

            BLL.Item item = new Item();
            int lastPalletId = Pallet.GetLastPanelNumber();
            DateTime lastExpireDate = new DateTime();
            int previousProductId = 0;
            _dtRecGrid.DefaultView.Sort = "Ordering, ID, Expiry Date";
            int i = 0;
            DataRow r, rw;
            foreach (DataRowView drv in _dtRecGrid.DefaultView)
            {
                r = drv.Row;
                item.LoadByPrimaryKey(Convert.ToInt32(r["ID"]));
                int productID = 0;
                if (Convert.ToString(item.StorageTypeID) == StorageType.BulkStore &&
                    (r["IsDamaged"] != DBNull.Value && !Convert.ToBoolean(r["IsDamaged"])))
                {
                    DataTable dtbl = r["PC"] as DataTable;
                    foreach (DataRow rr in dtbl.Rows)
                    {
                        //if (Convert.ToInt32(rr["Qty"]) == 0)
                        //    continue;
                        _dtPalletizedItemList.ImportRow(r);
                        productID = Convert.ToInt32(r["ID"]);
                        rw = _dtPalletizedItemList.Rows[_dtPalletizedItemList.Rows.Count - 1];
                        rw["Pack Qty"] = rr["Qty"];
                        rw["BoxLevel"] = rr["BSize"];
                        rw["BoxSizeDisplay"] = rr["BoxSize"];
                        rw["Multiplier"] = rr["SKUM"];
                        int bs = Convert.ToInt32(rr["BSize"]);
                        // check if the item is consolidable
                        PalletLocation pll = new PalletLocation();
                        DateTime expiry = DateTime.MaxValue;

                        if (r["Expiry Date"] != DBNull.Value)
                        {
                            expiry = Convert.ToDateTime(r["Expiry Date"]);
                        }

                        pll.LoadConsolidationOption(productID, expiry, bs, Convert.ToInt32(lkAccounts.EditValue));
                        bool consolidate = false;
                        if (pll.RowCount > 0)
                        {
                            rw["CanConsolidate"] = true;
                            consolidate = true;
                        }
                        else
                        {
                            rw["CanConsolidate"] = false;
                        }
                        rw["Consolidate"] = false;

                        if (consolidate)
                        {

                        }
                        else if (r["Expiry Date"] != DBNull.Value && previousProductId == productID &&
                                 lastExpireDate.Subtract(Convert.ToDateTime(r["Expiry Date"])).Days == 0)
                        {
                            rw["PalletNumber"] = lastPalletId;
                        }
                        else
                        {
                            lastPalletId++;
                            rw["PalletNumber"] = lastPalletId;
                            lastExpireDate = DateTime.MaxValue;
                            if (r["Expiry Date"] != DBNull.Value)
                            {
                                lastExpireDate = Convert.ToDateTime(r["Expiry Date"]);
                            }
                            productID = Convert.ToInt32(r["ID"]);
                            previousProductId = productID;
                        }
                        rw["Index"] = i;
                    }
                }
                else
                {
                    // Put it in the putaway list

                    DataTable dtbl = r["PC"] as DataTable;
                    if (dtbl != null)
                    {
                        foreach (DataRow rr in dtbl.Rows)
                        {
                            if (Convert.ToInt32(rr["Qty"]) == 0)
                                continue;
                            _dtNonPalletizedItemList.ImportRow(r);
                            productID = Convert.ToInt32(r["ID"]);
                            rw = _dtNonPalletizedItemList.Rows[_dtNonPalletizedItemList.Rows.Count - 1];
                            rw["Pack Qty"] = rr["Qty"];
                            rw["BoxLevel"] = rr["BSize"];
                            rw["BoxSizeDisplay"] = rr["BoxSize"];
                            rw["Multiplier"] = rr["SKUM"];
                            rw["Index"] = i;
                        }
                    }

                }

                i++;
                previousProductId = Convert.ToInt32(r["ID"]);
                lastExpireDate = DateTime.MaxValue;
                if (r["Expiry Date"] != DBNull.Value)
                {
                    lastExpireDate = Convert.ToDateTime(r["Expiry Date"]);
                }
            }

            // now palletize the Damaged
            DataView dvShortage = grdViewShortageOrDamaged.DataSource as DataView;
            if (dvShortage != null && dvShortage.ToTable().Rows.Count > 0)
            {
                dvShortage.RowFilter = string.Format("[ShortageReasonID]={0}", ShortageReasons.Constants.DAMAGED);

                foreach (DataRow drDamages in dvShortage.ToTable().Rows)
                {
                    _dtNonPalletizedItemList.ImportRow(drDamages);
                    //productID = Convert.ToInt32(drDamages["ID"]);
                    rw = _dtNonPalletizedItemList.Rows[_dtNonPalletizedItemList.Rows.Count - 1];
                    rw["BoxLevel"] = 0;
                    rw["BoxSizeDisplay"] = 1;
                    BLL.ItemUnit iu = new ItemUnit();
                    iu.LoadByPrimaryKey(Convert.ToInt32(drDamages["UnitID"]));
                    rw["ID"] = iu.ItemID;
                    rw["Manufacturer"] = drDamages["Manufacturer"];
                    rw["Multiplier"] = iu.QtyPerUnit;
                    rw["IsDamaged"] = true;
                    rw["Index"] = i++;
                }
                dvShortage.RowFilter = null;
            }


            PalletizedGrid.DataSource = _dtPalletizedItemList;
            gridNonPalletized.DataSource = _dtNonPalletizedItemList;
            CalculateVolumes();

        }

        #endregion

        #region Step four

        private void btnSaveReceipt_Click(object sender, EventArgs e)
        {
            if (!IsDuplicateRowsInPutAway() || !IsPutawayValid() || !IsSumOfPalletizedQtyEqualsToReceivedQty())
            {
                return;
            }
            if (
                XtraMessageBox.Show("Are you sure you want to save this transaction?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    UpdateQuantityAndPhysicalStores();
                }
                catch (Exception ex)
                {
                    tabReceiveTabs.SelectedTabPageIndex = 1;
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // start the transaction
                MyGeneration.dOOdads.TransactionMgr mgr = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                try
                {

                    mgr.BeginTransaction();
                    // save the recieve
                    SaveReceive();
                    // save the palletization
                    // save the put away.
                    mgr.CommitTransaction();
                    PrintPutaway();

                    XtraMessageBox.Show("Your Receive has been saved!", "Confirmation", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ResetFields();
                }
                catch (Exception exp)
                {
                    mgr.RollbackTransaction();
                    BLL.User user = new User();
                    //user.LoadByPrimaryKey(NewMainWindow.UserId);
                    user = CurrentContext.LoggedInUser;
                    if (user.UserType == UserType.Constants.ADMIN ||
                        user.UserType == UserType.Constants.SUPER_ADMINISTRATOR)
                    {
                        XtraMessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ErrorHandler.Handle(exp);
                    }
                    else
                    {
                        XtraMessageBox.Show(
                            "There was an Error saving this receipt. Please contact the administrator for support!",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ErrorHandler.Handle(exp);
                    }
                }
            }
            else
            {

            }

            _revDocRelatePalletGuid.Clear(); // clear cached pallets
        }

        private void btnPrintPutaway_Click(object sender, EventArgs e)
        {

            // do the validation
            if (IsPutawayValid())
            {
                PrintPutaway();
            }
        }

        private void SavePalletization(ReceiveDoc rec, DataRowView drow) //, string guid)
        {
            if ((rec.Quantity == 0 && !rec.IsColumnNull("ShortageReasonID") && rec.ShortageReasonID == ShortageReasons.Constants.NOT_RECEIVED) || (rec.Quantity == 0 && rec.IsColumnNull("ShortageReasonID")))
            {
                HandleFullNotReceivedAndMultipleBatchPalletlization(rec,drow);
                return;
            }
            string guid;

            BLL.ReceivePallet rp = new ReceivePallet();
            Pallet pallet = new Pallet();
            PalletLocation pl = new PalletLocation();
            ItemUnit itemUnit = new ItemUnit();

            BLL.ItemManufacturer im = new BLL.ItemManufacturer();

            guid = rec.GetColumn("GUID").ToString();
            var isDamaged = Convert.ToBoolean(rec.GetColumn("IsDamaged"));
            //DataRow[] r = _dtPalletizedItemList.Select(string.Format("Index = '{0}'", i));
            DataRow[] r =
                _dtPalletizedItemList.Select(string.Format("GUID = '{0}' AND IsDamaged = {1}", guid, isDamaged));
            if (r.Length > 0)
            {
                foreach (DataRow rw in r)
                {
                    rp.AddNew();
                    rp.IsOriginalReceive = true;
                    if (Convert.ToBoolean(rw["Consolidate"]))
                    {
                        try
                        {
                            DataRow dr =
                                _dtPutAwayPalletized.Select(string.Format("PalletNumber={0}",
                                    Convert.ToInt32(rw["PalletNumber"])))[0]; //Assuming we only need one.
                            if (rw["IsStoredInFreeStorageType"] != null)
                            {
                                if (Convert.ToBoolean(rw["IsStoredInFreeStorageType"]) == true)
                                {
                                    pl.LoadByPrimaryKey(Convert.ToInt32(dr["PutAwayLocation"]));
                                }
                            }
                        }
                        catch
                        {
                            pl.LoadByPalletNumber(Convert.ToInt32(rw["PalletNumber"]));
                        }
                        try
                        {
                            rp.PalletID = pl.PalletID;
                            rp.PalletLocationID = pl.ID;
                        }
                        catch
                        {
                            rp.PalletID = GetPalletID(rw["PalletNumber"].ToString());
                            try
                            {
                                rp.PalletLocationID = PalletLocation.GetPalletLocationID(rp.PalletID);
                            }
                            catch
                            {
                                DataRow dr =
                                    _dtPutAwayPalletized.Select(string.Format("PalletNumber={0}",
                                        Convert.ToInt32(rw["PalletNumber"])))[0];
                                pl.LoadByPrimaryKey(Convert.ToInt32(dr["PutAwayLocation"]));
                                pl.PalletID = rp.PalletID;
                                pl.Save();
                                rp.PalletLocationID = pl.ID;
                            }
                        }


                        //// if the putaway is on a pick face, increase the amount stored on the pick face
                        //if (pl.StorageTypeID.ToString() == StorageType.PickFace)
                        //{
                        //    PickFace pf = new PickFace();

                        //    pf.LoadPickFaceFor(rec.ItemID, Convert.ToInt32(cboStores.EditValue));
                        //    if (pf.RowCount > 0)
                        //    {
                        //        if (pf.IsColumnNull("Balance"))
                        //        {
                        //            pf.Balance = 0;
                        //        }

                        //        pf.Balance += Convert.ToInt32(rp.Balance);
                        //        pf.Save();
                        //    }
                        //}
                    }
                    else
                    {
                        var palletNumber = Convert.ToInt32(rw["PalletNumber"]);
                        DataRow dr = _dtPutAwayPalletized.Select(string.Format("PalletNumber={0}", palletNumber))[0];
                        //Assuming we only need one.
                        pl.LoadByPrimaryKey(Convert.ToInt32(dr["PutAwayLocation"]));
                        rp.PalletID = GetPalletID(rw["PalletNumber"].ToString());
                        pl.PalletID = rp.PalletID;
                        rp.PalletLocationID = pl.ID; //PalletLocation.GetPalletLocationID(rp.PalletID);
                        pl.Save();
                    }

                    rp.ReservedStock = 0;
                    im.LoadIMbyLevel(Convert.ToInt32(rw["ID"]), Convert.ToInt32(rw["Manufacturer"]),
                        Convert.ToInt32(rw["BoxLevel"]));

                    int qtyPerPack = im.QuantityInBasicUnit;

                    if (rw["UnitID"] != DBNull.Value)
                    {
                        itemUnit.LoadByPrimaryKey(Convert.ToInt32(rw["UnitID"]));
                        qtyPerPack = itemUnit.QtyPerUnit;
                    }

                    rp.ReceivedQuantity = rp.Balance = (Convert.ToDecimal(rw["Pack Qty"]) * Convert.ToDecimal(qtyPerPack));
                    rp.BoxSize = Convert.ToInt32(rw["BoxLevel"]);
                    if (rec.IsColumnNull("PhysicalStoreID") && !rp.IsColumnNull("PalletLocationID"))
                    {
                        PalletLocation l = new PalletLocation();
                        l.LoadByPrimaryKey(rp.PalletLocationID);
                        rec.PhysicalStoreID = (l.PhysicalStoreID);

                        PhysicalStore physicalStore = new PhysicalStore();
                        physicalStore.LoadByPrimaryKey(l.PhysicalStoreID);
                        rec.InventoryPeriodID = physicalStore.CurrentInventoryPeriodID;
                    }

                    if (Convert.ToBoolean(rw["Consolidate"]))
                    {
                        try
                        {
                            // if the putaway is on a pick face, increase the amount stored on the pick face
                            if (pl.StorageTypeID.ToString() == StorageType.PickFace)
                            {
                                PickFace pf = new PickFace();

                                pf.LoadPickFaceFor(rec.ItemID, Convert.ToInt32(lkAccounts.EditValue));
                                if (pf.RowCount > 0)
                                {
                                    if (pf.IsColumnNull("Balance"))
                                    {
                                        pf.Balance = 0;
                                    }

                                    pf.Balance += Convert.ToInt32(rp.Balance);
                                    pf.Save();
                                }
                            }
                        }
                        catch
                        {

                        }
                    }

                }
            }


            //r = _dtPutAwayNonPalletized.Select(string.Format("Index = '{0}'", i));
            string filterQuery = _revDocRelatePalletGuid.ContainsKey(guid)
                ? string.Format("{0} AND IsDamaged = {1}", GetFilterByGuid(_revDocRelatePalletGuid[guid]), isDamaged)
                : string.Format("GUID = '{0}' AND IsDamaged = {1} ", guid, isDamaged);
            r = _dtPutAwayNonPalletized.Select(filterQuery);
            if (r.Length > 0)
            {
                // Save the palletization and the putaway here,// this was supposed to be out of here but it is easlier to implement here.
                foreach (DataRow rw in r)
                {
                    pl.LoadByPrimaryKey(Convert.ToInt32(rw["PutAwayLocation"]));
                    if (pl.IsColumnNull("PalletID"))
                    {
                        pallet.AddNew();
                        pallet.Save();
                    }
                    else
                    {
                        pallet.LoadByPrimaryKey(pl.PalletID);
                    }
                    rp.AddNew();
                    rp.IsOriginalReceive = true;
                    rp.PalletID = pallet.ID;
                    rp.PalletLocationID = pl.ID;
                    // rp.ReceiveID = rec.ID;
                    rp.ReservedStock = 0;
                    im.LoadIMbyLevel(Convert.ToInt32(rw["ID"]), Convert.ToInt32(rw["Manufacturer"]),
                        Convert.ToInt32(rw["BoxLevel"]));

                    int qtyPerPack = im.QuantityInBasicUnit;

                    if (rw["UnitID"] != DBNull.Value)
                    {
                        itemUnit.LoadByPrimaryKey(Convert.ToInt32(rw["UnitID"]));
                        qtyPerPack = itemUnit.QtyPerUnit;
                    }

                    rp.ReceivedQuantity =
                        rp.Balance = (Convert.ToDecimal(rw["Palletized Quantity"]) * Convert.ToDecimal(qtyPerPack));
                    rp.BoxSize = Convert.ToInt32(rw["BoxLevel"]);
                    //Get the putaway location

                    pl.Save();
                    if (pl.IsColumnNull("PalletID"))
                    {
                        pl.PalletID = pallet.ID;
                        pl.Confirmed = false;
                        pl.Save();
                    }
                }
            }
            if (rec.IsColumnNull("PhysicalStoreID") && !rp.IsColumnNull("PalletLocationID"))
            {
                PalletLocation l = new PalletLocation();
                l.LoadByPrimaryKey(rp.PalletLocationID);
                PhysicalStore physicalStore = new PhysicalStore();
                physicalStore.LoadByPrimaryKey(l.PhysicalStoreID);
                rec.PhysicalStoreID = (l.PhysicalStoreID);
                // we can take any of the pallet location physical store. as we have one entry on receiveDoc per Store.
                if (physicalStore.IsColumnNull("CurrentInventoryPeriodID"))
                {
                    XtraMessageBox.Show(string.Format("Please Set InventoryPeriod for '{0}' PhysicalStore!",
                        physicalStore.Name), "Empty InventoryPeriod", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception(string.Format("Please Set InventoryPeriod for '{0}' PhysicalStore!",
                        physicalStore.Name));
                }
                rec.InventoryPeriodID = physicalStore.CurrentInventoryPeriodID;

            }

            rec.Save();
            rp.Rewind();
            while (!rp.EOF)
            {
                rp.ReceiveID = rec.ID;
                rp.MoveNext();
            }
            rp.Save();
            SavePutAwayItems();
        }

        private string GetFilterByGuid(IList<string> list)
        {
            var query = string.Format("GUID = '{0}'", list[0]);
            foreach (var guid in list)
            {
                if (guid == list[0])
                {
                    /*Do nothing*/
                }
                else
                {
                    query += string.Format(" OR GUID = '{0}'", guid);
                }
            }
            return query;
        }

        private void SavePutAwayItems()
        {
            PalletLocation pl = new PalletLocation();
            Pallet pallet = new Pallet();
            foreach (DataRow rw in _dtPutAwayPalletized.Rows)
            {
                pl.LoadByPrimaryKey(Convert.ToInt32(rw["PutAwayLocation"]));
                if (pl.IsColumnNull("PalletID"))
                {
                    pl.PalletID = GetPalletID(rw["PalletNumber"].ToString());
                    pl.Confirmed = false;
                    pallet.LoadByPrimaryKey(pl.PalletID);
                    pl.UsedVolume = pallet.CalculateCurrentVolume(pl.PalletID);
                    pl.Save();
                }
                else
                {

                }
            }
        }

        private bool IsPutawayValid()
        {
            // Check if there is any Empty Put away location
            Dictionary<int, string> keyed = new Dictionary<int, string>();
            Boolean isValid = true;

            // Validate Non Palletized locations
            foreach (DataRow dr in _dtPutAwayNonPalletized.Rows)
            {
                dr.ClearErrors();
                if (dr["PutAwayLocation"] == null || dr["PutAwayLocation"].ToString() == "")
                {
                    dr.SetColumnError("PutAwayLocation", "Cannot be null");
                    isValid = false;
                }
                if (dr["Palletized Quantity"] == null || dr["Palletized Quantity"].ToString() == "")
                {
                    dr.SetColumnError("Palletized Quantity", "Cannot be null");
                    isValid = false;
                }
            }

            //validate Palletized putaway
            foreach (DataRow dr in _dtPutAwayPalletized.Rows)
            {
                dr.ClearErrors();
                if (dr["PutAwayLocation"] == null)
                {
                    dr.SetColumnError("PutAwayLocation", "Cannot be null");
                    isValid = false;
                }
                else
                {
                    //If it is not free, different pallets cannot be put on the same location.
                    int putAwayLocation = int.Parse(dr["PutAwayLocation"].ToString());
                    BLL.PalletLocation pl = new PalletLocation();
                    pl.LoadByPrimaryKey(putAwayLocation);
                    BLL.Shelf shelf = new Shelf();
                    shelf.LoadByPrimaryKey(pl.ShelfID);

                    if (shelf.ShelfStorageType.ToString() != BLL.StorageType.Free)
                    {
                        try
                        {
                            keyed.Add(Convert.ToInt32(dr["PutAwayLocation"]), "");
                        }
                        catch
                        {
                            dr.SetColumnError("PutAwayLocation", "Different Pallets put on the same Location");
                            isValid = false;
                        }
                    }
                    else
                    {
                        ////If the location type is free.  We allow consolidation
                        DataRow[] rows =
                            _dtPalletizedItemList.Select(string.Format("PalletNumber={0}", dr["PalletNumber"].ToString()));
                        foreach (DataRow row in rows)
                        {
                            row["Consolidate"] = true;
                            row["IsStoredInFreeStorageType"] = true;
                        }
                    }
                }

            }
            return isValid;
        }

        private bool IsDuplicateRowsInPutAway()
        {
            bool valid = true;
            gridPutAwayNonPalletizedView.ClearColumnErrors();
            if (gridPutAwayNonPalletizedView.RowCount != 0)
            {
                for (int i = 0; i < gridPutAwayNonPalletizedView.RowCount; i++)
                {
                    DataRow dri = gridPutAwayNonPalletizedView.GetDataRow(i);
                    for (int j = i + 1; j < gridPutAwayNonPalletizedView.RowCount; j++)
                    {
                        DataRow drj = gridPutAwayNonPalletizedView.GetDataRow(j);
                        if (
                            ((string)dri["Item Name"]).Equals(
                                (string)drj["Item Name"]) &&
                            ((int)dri["UnitID"]) ==
                            (int)drj["UnitID"] &&
                            ((int)dri["Manufacturer"]) ==
                            (int)drj["Manufacturer"] &&
                            ((string)dri["PutAwayLocation"]).Equals(
                                (string)drj["PutAwayLocation"]) &&
                            (dri["Batch No"]).Equals(
                                drj["Batch No"]) &&
                            (dri["Expiry Date"]).Equals(
                                drj["Expiry Date"])
                            )
                        {
                            valid = false;

                            dri.SetColumnError("Item Name", @"Duplicate Rows");
                            dri.SetColumnError("Batch No", @"Duplicate Rows");
                            dri.SetColumnError("Expiry Date", @"Duplicate Rows");
                            dri.SetColumnError("PutAwayLocation", @"Duplicate Rows");

                            drj.SetColumnError("Item Name", @"Duplicate Rows");
                            drj.SetColumnError("Batch No", @"Duplicate Rows");
                            drj.SetColumnError("Expiry Date", @"Duplicate Rows");
                            drj.SetColumnError("PutAwayLocation", @"Duplicate Rows");

                            XtraMessageBox.Show("Please use different pallet locations for the duplicate rows.",
                                "Duplicate Rows", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }
            }
            return valid;
        }

        private bool IsSumOfPalletizedQtyEqualsToReceivedQty()
        {
            bool valid = true;
            try
            {
                var dataView = new DataView(_dtPutAwayNonPalletized);
                var distinctRows = dataView.ToTable(true, "ID", "Item Name", "UnitID", "Batch No", "Expiry Date",
                    "Pack Qty", "IsDamaged");

                foreach (DataRowView dr in distinctRows.DefaultView)
                {
                    if (dr["IsDamaged"] != DBNull.Value && Convert.ToBoolean(dr["IsDamaged"])) continue;
                    var filter = string.Format(@"[ID] = '{0}' AND
                                             [UnitID] = '{1}' AND 
                                             [Pack Qty] = '{2}' ", Convert.ToInt32(dr["ID"]),
                        Convert.ToInt32(dr["UnitID"]), Convert.ToDecimal(dr["Pack Qty"]));

                    if (dr["Batch No"] != DBNull.Value)
                        filter += string.Format(@" AND [Batch No] ='{0}'", Convert.ToString(dr["Batch No"]));
                    if (dr["Expiry Date"] != DBNull.Value)
                        filter += string.Format(@" AND [Expiry Date] ='{0}'", Convert.ToDateTime(dr["Expiry Date"]));

                    var filteredRows = _dtPutAwayNonPalletized.Select(filter);

                    var packQty = Convert.ToDecimal(filteredRows[0]["Pack Qty"]);
                    decimal sumOfPalletizedQty =
                        filteredRows.Where(r => Convert.ToBoolean(r["IsDamaged"]) == false)
                            .Sum(r => Convert.ToDecimal(r["Palletized Quantity"]));
                    valid = (packQty == sumOfPalletizedQty);
                    if (!valid) break;
                }

                if (!valid)
                {
                    XtraMessageBox.Show("Received quantity is not equal to sum of Palletized quantities",
                        "Palletization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return valid;
        }

        private void CalculateVolumes()
        {
            BLL.ItemManufacturer im = new BLL.ItemManufacturer();

            foreach (DataRow dr in _dtPalletizedItemList.Rows)
            {
                //dr.EndEdit();

                int itemID = Convert.ToInt32(dr["ID"]);
                int manufID = Convert.ToInt32(dr["Manufacturer"]);
                int plevel = Convert.ToInt32(dr["BoxLevel"]);

                im.LoadManufacturerItemRelationsFor(itemID, manufID, plevel);
                double packQty = Convert.ToDouble(dr["Pack Qty"]);
                dr["Volume"] = (im.BoxHeight * im.BoxWidth * im.BoxLength * packQty);

            }

            foreach (DataRow dr in _dtNonPalletizedItemList.Rows)
            {

                int itemID = Convert.ToInt32(dr["ID"]);
                int manufID = Convert.ToInt32(dr["Manufacturer"]);
                int plevel = Convert.ToInt32(dr["BoxLevel"]);

                im.LoadManufacturerItemRelationsFor(itemID, manufID, plevel);
                dr["Volume"] = (im.BoxHeight * im.BoxWidth * im.BoxLength * Convert.ToDouble(dr["Pack Qty"]));

            }
        }

        private void OnAnyPutawayPopup(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            var activeEditorName = view.ActiveEditor.GetType().Name;

            if (activeEditorName.Equals("GridLookUpEdit"))
            {
                GridLookUpEdit lke = (GridLookUpEdit)view.ActiveEditor;

                if (!dxWarehouseSelection.Validate())
                {
                    //TODO: please show an error message here
                    lke.Properties.DataSource = null;
                    return;
                }

                if (view.FocusedColumn.FieldName == "PutAwayLocation")
                {

                    DataRow dr = view.GetFocusedDataRow();
                    if (dr.Table.Columns.IndexOf("Consolidate") >= 0 && Convert.ToBoolean(dr["Consolidate"]))
                    {
                        XtraMessageBox.Show(
                            "You have choosen to Consolidate this Item, and there fore you cannot select another location for it.",
                            "Consolidation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //LookUpEdit lke = (LookUpEdit)view.ActiveEditor;

                    if (dr.Table.Columns.Contains("IsDamaged") && dr["IsDamaged"] != DBNull.Value &&
                        Convert.ToBoolean(dr["IsDamaged"]))
                    {

                        var dt = PalletLocation.GetPalletLocation(true, Convert.ToInt32(lkWarehouse.EditValue));

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            XtraMessageBox.Show("The warehouse you have choosen doesn't have any Suspended Area",
                                "No PalletLocation Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        lke.Properties.DataSource = dt;
                    }
                    else
                    {
                        var dt = PalletLocation.GetPalletLocation(false, Convert.ToInt32(lkWarehouse.EditValue));

                        if (dt == null || dt.Rows.Count == 0)
                        {
                            XtraMessageBox.Show(
                                "The warehouse you have choosen doesn't have any palletLocation where this Item can be stored, Please check the item's Storage Type setting!",
                                "No PalletLocation Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }

                        lke.Properties.DataSource = dt;
                    }
                }
            }

        }

        private void UpdateQuantityAndPhysicalStores()
        {
            var dataTable = gridPutAwayNonPalletized.DataSource as DataTable;
            decimal currentBonusInvQty = 0;
            string currentGuiParam = "";
            var orginalGuidCurrentInvQty = new Dictionary<string, decimal>();

            if (dataTable != null)
                foreach (DataRow drow in dataTable.Rows)
                {
                    if (drow["IsDamaged"] != DBNull.Value && Convert.ToBoolean(drow["IsDamaged"])) continue;
                    var dr = _dtRecGrid.Select(String.Format("GUID = '{0}'", Convert.ToString(drow["GUID"])))[0];

                    bool currentRowIsOrginal = (dr["Copy"].ToString() == "Orginal" || dr["Copy"] == DBNull.Value);
                    currentGuiParam = currentRowIsOrginal ? "GUID" : "Copy";

                    if (drow["PutAwayLocation"] != DBNull.Value)
                    {
                        var plocation = new PalletLocation();
                        plocation.LoadByPrimaryKey(Convert.ToInt32(drow["PutAwayLocation"]));
                        dr["Store"] = (plocation.PhysicalStoreID);
                    }
                    if (drow["Palletized Quantity"] != DBNull.Value)
                    {
                        dr["Pack Qty"] = drow["Palletized Quantity"];

                        bool hasBonus = !srm && dr["InvoicedQty"] != DBNull.Value &&
                                        (Convert.ToDecimal(dr["InvoicedQty"]) < Convert.ToDecimal(drow["Pack Qty"]));

                        if (hasBonus && !orginalGuidCurrentInvQty.Any())
                            GetCurrentBonusInvQty(out orginalGuidCurrentInvQty);
                        if (!hasBonus)
                        {
                            dr["InvoicedQty"] = (currentRowIsOrginal)
                                ? Convert.ToDecimal(dr["Pack Qty"]) +
                                  HasShortageQty(dr["GUID"].ToString())
                                : Convert.ToDecimal(dr["Pack Qty"]);
                        }
                        else
                        {

                            currentBonusInvQty = orginalGuidCurrentInvQty[dr[currentGuiParam].ToString()];

                            if (Convert.ToDecimal(dr["Pack Qty"]) >= currentBonusInvQty && currentBonusInvQty >= 0)
                            {
                                dr["InvoicedQty"] = currentBonusInvQty;
                                orginalGuidCurrentInvQty[dr[currentGuiParam].ToString()] -=
                                    Convert.ToDecimal(dr["Pack Qty"]);

                            }
                            else
                            {
                                if (currentBonusInvQty <= 0)
                                    dr["InvoicedQty"] = 0;
                                else
                                {
                                    dr["InvoicedQty"] = (currentBonusInvQty >= Convert.ToDecimal(dr["Pack Qty"]))
                                        ? Convert.ToDecimal(dr["Pack Qty"])
                                        : currentBonusInvQty;
                                    orginalGuidCurrentInvQty[dr[currentGuiParam].ToString()] -=
                                        Convert.ToDecimal(dr["Pack Qty"]);
                                }
                            }
                        }
                    }
                }
        }

        private void GetCurrentBonusInvQty(out Dictionary<string, decimal> orginalGuidCurrentInvQty)
        {
            orginalGuidCurrentInvQty = new Dictionary<string, decimal>();
            var orginalRows = _dtRecGrid.Select(String.Format("Copy = '{0}'", "Orginal"));
            var orginalsWithBonus = orginalRows.Where(orginalRow => HasBonus(orginalRow["GUID"].ToString()));

            foreach (var dr in orginalsWithBonus)
            {
                orginalGuidCurrentInvQty[dr["GUID"].ToString()] = Convert.ToDecimal(dr["InvoicedQty"]);
            }
        }

        private bool HasBonus(string orgnalBonusGuid)
        {
            var dataTable = gridPutAwayNonPalletized.DataSource as DataTable;
            if (dataTable != null)
            {
                var dr = _dtRecGrid.Select(String.Format("GUID = '{0}'", orgnalBonusGuid))[0];
                var rows =
                    dataTable.Select(String.Format("{1} < [Pack Qty] And GUID = '{0}' ", orgnalBonusGuid,
                        Convert.ToDecimal(dr["InvoicedQty"])));
                return rows.Any();
            }
            return false;
        }

        private bool IS_StoreUpdated()
        {
            return
                _dtRecGrid.Rows.Cast<DataRow>()
                    .All(dr => dr["Store"] != DBNull.Value && (dr["Pack Qty"] != DBNull.Value));
        }

        private void PutAwayRecievedItems(bool reset)
        {
            if (_dtPutAwayNonPalletized == null || reset == true)
            {
                // Prep the data tables
                _dtPutAwayNonPalletized = new DataTable();
                _dtPutAwayPalletized = new DataTable();

                _dtPutAwayPalletized.Columns.Add("ID");
                _dtPutAwayPalletized.Columns.Add("Item Name");
                _dtPutAwayPalletized.Columns.Add("PalletNumber");
                _dtPutAwayPalletized.Columns.Add("Expiry Date", typeof(DateTime));
                _dtPutAwayPalletized.Columns.Add("PutAwayLocation");
                _dtPutAwayPalletized.Columns.Add("Consolidate", typeof(bool));
                _dtPutAwayPalletized.Columns.Add("Notes");
                _dtPutAwayPalletized.Columns.Add("Volume");
                _dtPutAwayPalletized.Columns.Add("Stock Code");

                _dtPutAwayNonPalletized.Columns.Add("ID");
                _dtPutAwayNonPalletized.Columns.Add("Item Name");
                _dtPutAwayNonPalletized.Columns.Add("Pack Qty", typeof(decimal));
                _dtPutAwayNonPalletized.Columns.Add("Expiry Date", typeof(DateTime));
                _dtPutAwayNonPalletized.Columns.Add("PutAwayLocation");
                _dtPutAwayNonPalletized.Columns.Add("Batch No");
                _dtPutAwayNonPalletized.Columns.Add("StorageType");
                _dtPutAwayNonPalletized.Columns.Add("BoxLevel", typeof(int));
                _dtPutAwayNonPalletized.Columns.Add("Index");
                _dtPutAwayNonPalletized.Columns.Add("BasicUnitPerQ");
                _dtPutAwayNonPalletized.Columns.Add("IsDamaged", typeof(bool));
                _dtPutAwayNonPalletized.Columns.Add("Volume");
                _dtPutAwayNonPalletized.Columns.Add("Manufacturer", typeof(int));
                _dtPutAwayNonPalletized.Columns.Add("UnitID", typeof(int));
                _dtPutAwayNonPalletized.Columns.Add("Stock Code");
                _dtPutAwayNonPalletized.Columns.Add("GUID");
                _dtPutAwayNonPalletized.Columns.Add("Palletized Quantity", typeof(decimal));
                // import the neccessary data tables
                _dtPalletizedItemList.DefaultView.Sort = "Ordering, PalletNumber";

                int prevPalletID = 0;
                int palletID = 0;
                DataRow LastDr = null;
                foreach (DataRowView drv in _dtPalletizedItemList.DefaultView)
                {
                    DataRow dr = drv.Row;
                    palletID = Convert.ToInt32(drv["PalletNumber"]);
                    if (palletID != prevPalletID)
                    {
                        _dtPutAwayPalletized.ImportRow(dr);
                        LastDr = _dtPutAwayPalletized.Rows[_dtPutAwayPalletized.Rows.Count - 1];
                        LastDr.EndEdit();
                        if (Convert.ToBoolean(LastDr["Consolidate"]))
                        {
                            int plid;
                            LastDr["PutAwayLocation"] = plid = Convert.ToInt32(drv["PalletNumber"]);
                            PalletLocation plc = new PalletLocation();
                            plc.LoadByPrimaryKey(plid);
                            Pallet plt = new Pallet();
                            plt.LoadByPrimaryKey(plc.PalletID);
                            LastDr["PalletNumber"] = (!plt.IsColumnNull("PalletNo")) ? plt.PalletNo : 0;
                        }
                    }
                    else
                    {
                        // add the volume
                        LastDr["Volume"] = Convert.ToDouble(LastDr["Volume"]) + Convert.ToDouble(dr["Volume"]);
                    }
                    prevPalletID = palletID;
                }
                //int quarantine = PalletLocation.GetQuaranteenPalletLocation();
                foreach (DataRowView drv in _dtNonPalletizedItemList.DefaultView)
                {
                    _dtPutAwayNonPalletized.ImportRow(drv.Row);

                    DataRow dr = _dtPutAwayNonPalletized.Rows[_dtPutAwayNonPalletized.Rows.Count - 1];
                    dr.ClearErrors();
                }
                foreach (DataRowView dr in _dtPutAwayNonPalletized.DefaultView)
                {
                    dr["Palletized Quantity"] = dr["Pack Qty"];
                }


                // Bind the data tables with the grids
                //gridPutAwayPalletized.DataSource = _dtPutAwayPalletized;
                //gridPutAwayPalletizedView.SelectRow(0);
                gridPutAwayNonPalletized.DataSource = _dtPutAwayNonPalletized;
                //gridPutAwayPalletizedView.SelectRow(0);
            }
        }

        private void PrintPutaway()
        {
            // Show Column
            // Confirmation.Visible = true;
            Confirmation1.Visible = true;
            //gridPutAwayPalletized.ShowPrintPreview();

            if (gridPutAwayNonPalletized.DataSource != null &&
                (gridPutAwayNonPalletized.DataSource as DataTable).Rows.Count > 0)
            {
                //  gridPutAwayNonPalletized.ShowPrintPreview();
            }

            // TODO: Fix this to show all the appropriate items
            //compositeLink1.PrintingSystem = new DevExpress.XtraPrinting.PrintingSystem();
            //compositeLink1.ShowPreview();

            HCMIS.Desktop.Reports.GoodsReceivingNote note = new HCMIS.Desktop.Reports.GoodsReceivingNote();
            BLL.Receipt rct = new BLL.Receipt();
            var activity = new Activity();
            activity.LoadByPrimaryKey(storeID);
            note.xrLabelAccounts.Text = activity.FullActivityName;
            note.DataSource = rct.GetReceiptInformationForGRN(_receiptID);

            if (BLL.Settings.IsCenter)
            {
                note.xrPOrderNo.Visible = false;
                note.xrPOrderNoValue.Visible = false;
                note.xrAirWayNo.Visible = false;
                note.xrAirWayNoValue.Visible = false;
                note.xrTransitTransferNo.Visible = false;
                note.xrTransitTransferNoValue.Visible = false;
                note.xrInsurancePolicyNo.Visible = false;
                note.xrInsurancePolicyNoValue.Visible = false;
            }

            //note.ShowPreviewDialog();

            // Hide Column
            Confirmation1.Visible = false;
            //Confirmation.Visible = false;
        }

        private void SaveReceive()
        {
            // Merge all Receives with Same Item information and Assigned to Same PhysicalStore as One Item , Quantity Sumed UP!
            MergeReceiveDocLines();



            BLL.ReceiveDoc rec = new ReceiveDoc();

            ////int receiptTypeID = srm
            ////    ? ReceiptType.CONSTANTS.STOCK_RETURN
            ////    : (deliveryNoteType != DeliveryNoteType.NotSet)
            ////        ? ReceiptType.CONSTANTS.DELIVERY_NOTE
            ////        : beginningBalance
            ////            ? ReceiptType.CONSTANTS.BEGINNING_BALANCE
            ////            : ReceiptType.CONSTANTS.STANDARD_RECEIPT;
            int receiptID;
            int warehouseID = Convert.ToInt32(lkWarehouse.EditValue);

            receiptID = SaveRelevantReceiptHeaders(_receiptTypeID, warehouseID);

            DataTable zeroQuantitiesDueToMultipleBatch = null;
            DataRow [] zeroQuantityRows =
                _dtRecGrid.Select(string.Format("[Pack Qty] = 0"),"[Ordering] ASC ");


            if (zeroQuantityRows.Any() && zeroQuantityRows.Any(r => r["ShortageReasonID"] == DBNull.Value))
            {
                zeroQuantityRows = CheckAndRemoveIfFullNotReceiveEntry(zeroQuantityRows);
                if (zeroQuantityRows.Any())
                    zeroQuantitiesDueToMultipleBatch =
                        zeroQuantityRows.Where(r => r["ShortageReasonID"] == DBNull.Value).CopyToDataTable();
            }

            var mergeableTables = _dtRecGrid.Select(string.Format("[Pack Qty] > 0 "), "[Ordering] ASC ");
            DataTable mergedDataTable = null;
            if (mergeableTables.Any())
            {
                mergedDataTable =
                    _dtRecGrid.Select(string.Format("[Pack Qty] > 0 "), "[Ordering] ASC ").CopyToDataTable();

                if (zeroQuantitiesDueToMultipleBatch != null)
                    mergedDataTable.Merge(zeroQuantitiesDueToMultipleBatch);

                if (grdShortageOrDamaged.DataSource != null)
                {
                    var shortageOrDamage = (DataTable) grdShortageOrDamaged.DataSource;
                    mergedDataTable.Merge(shortageOrDamage);
                }
            }
            else
            {
                if (grdShortageOrDamaged.DataSource != null)
                {
                    var shortageOrDamage = (DataTable)grdShortageOrDamaged.DataSource;
                    if (zeroQuantitiesDueToMultipleBatch != null)
                        shortageOrDamage.Merge(zeroQuantitiesDueToMultipleBatch);
                    //~ {"[ShortageReasonID] ASC} --> Just to give priority among shortages to Damaged reasons as we will create a receiveDoc entry for this ~//
                    mergedDataTable = mergedDataTable == null ? shortageOrDamage.Select(string.Format("[Pack Qty] >= 0 "), "[ShortageReasonID] ASC ").CopyToDataTable() : shortageOrDamage;
                  

                }
            }



            foreach (DataRowView dr in mergedDataTable.DefaultView)
            {
                var shortageReasonID = dr["ShortageReasonID"];

                var onlyOneEntryFound = _dtRecGrid.Select(String.Format("GUID = '{0}'", dr["GUID"]));

                bool zeroQtyDueTomultipleBatchFound = (Convert.ToDecimal(dr["Pack Qty"]) == 0) && (shortageReasonID == DBNull.Value) && (onlyOneEntryFound.Count() == 1);
                bool fullNotReceivedEntry = (Convert.ToDecimal(dr["BU Qty"]) == 0) && (shortageReasonID != DBNull.Value) && (Convert.ToInt32(shortageReasonID) == ShortageReasons.Constants.NOT_RECEIVED) && (onlyOneEntryFound.Count() == 1);
                if (fullNotReceivedEntry)
                {
                    dr["Pack Qty"] = 0;
                }

                var item = new Item();
                item.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));


                if (item.NeedExpiryBatch || (shortageReasonID == DBNull.Value && ((dr["Expiry Date"] != DBNull.Value) && (Convert.ToDateTime(dr["Expiry Date"]) <= DateTimeHelper.ServerDateTime))))
                {

                    var expDate = Convert.ToDateTime(dr["Expiry Date"]);

                    if ((shortageReasonID == DBNull.Value && expDate > DateTimeHelper.ServerDateTime) || zeroQtyDueTomultipleBatchFound)
                    {
                        AddNewReceiveDoc(rec, receiptID, dr);
                    }
                    else
                    {
                        //for physically Damaged receives and expired receives
                        if ((shortageReasonID != DBNull.Value && Convert.ToInt32(shortageReasonID) == ShortageReasons.Constants.DAMAGED) || (shortageReasonID == DBNull.Value && expDate <= DateTimeHelper.ServerDateTime) || fullNotReceivedEntry)
                        {
                            AddNewReceiveDoc(rec, receiptID, dr, true);
                            if (shortageReasonID == DBNull.Value)
                            {
                                dr["ShortageReasonID"] = ShortageReasons.Constants.DAMAGED;
                            }
                        }
                        else
                        {

                            HandleReceiveDocShortage(dr, rec);
                        }
                    }
                }
                else
                {

                    if ((shortageReasonID == DBNull.Value) || zeroQtyDueTomultipleBatchFound)
                    {
                        AddNewReceiveDoc(rec, receiptID, dr);
                    }
                    else
                    {
                        //for physically Damaged receives
                        if (shortageReasonID != DBNull.Value && Convert.ToInt32(shortageReasonID) == ShortageReasons.Constants.DAMAGED || fullNotReceivedEntry)
                        {
                            AddNewReceiveDoc(rec, receiptID, dr, true);
                        }
                        else
                        {
                            HandleReceiveDocShortage(dr, rec);
                        }

                    }
                }

            }

            rec.SetStatusAsReceived(CurrentContext.UserId);

            BLL.Receipt receiptStatus = new BLL.Receipt();
            receiptStatus.LoadByPrimaryKey(receiptID);
            receiptStatus.ChangeStatus(ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED, null,
                this.GetFormIdentifier(), CurrentContext.UserId, "Received");
            if (!BLL.Settings.HandleGRV) //If HandleGRV is true, the price isn't entered in the receive stage meaning
            {
                rec.Rewind();
                while (!rec.EOF)
                {
                    if (!ReceiveDoc.DoesPriceNeedToBeChanged(rec.StoreID, rec.ItemID, rec.UnitID, rec.ManufacturerId) &&
                        (deliveryNoteType == DeliveryNoteType.NotSet))
                    {
                        rec.SellingPrice = rec.Cost;
                        rec.UnitCost = Convert.ToDecimal(rec.Cost);
                        // Added by Heny In order to display Unit Cost on Vaccine 
                        rec.Margin = 0;
                    }
                    rec.MoveNext();
                }
            }

            rec.Save(); //TODO: To be removed after the ShortageReasonID in receviedoc is discontinued.

            //SavePalletization(rdDamaged);
            _revDocRelatePalletGuid.Clear();
        }

        private DataRow[] CheckAndRemoveIfFullNotReceiveEntry(DataRow[] zeroQuantityRows)
        {
            var grdShortageDt = grdShortageOrDamaged.DataSource as DataTable;
            if (grdShortageDt != null)
                foreach (DataRow dr in grdShortageDt.Rows.Cast<DataRow>().Where(dr => Convert.ToBoolean(dr["IsDamaged"]) && (dr["ShortageReasonID"] != DBNull.Value
                                                                                                                             &&
                                                                                                                             ((Convert.ToInt32(dr["ShortageReasonID"]) ==
                                                                                                                             ShortageReasons.Constants.NOT_RECEIVED) ||
                                                                                                                             (Convert.ToInt32(dr["ShortageReasonID"]) ==
                                                                                                                             ShortageReasons.Constants.DAMAGED)))))
                {
                    //~ Remove Full NotReceived Row with quantity zero since it has been treated a row from gridShortage ~//
                    var dtZeroQtyRows = zeroQuantityRows.CopyToDataTable();
                    var rowToBeRemoved =
                        dtZeroQtyRows.Select(string.Format("CopyGUID = '{0}'", dr["CopyGUID"]));
                    if (!rowToBeRemoved.Any()) continue;

                    //~ Full Damaged Case ~//
                    if(Convert.ToInt32(dr["ShortageReasonID"]) == ShortageReasons.Constants.DAMAGED)
                    {
                        dr["Pack Qty"] = dr["BU Qty"] = dr["InvoicedQty"] = dr["OriginalInvoicedQty"] = rowToBeRemoved[0]["OriginalInvoicedQty"];
                        dtZeroQtyRows.Rows.Remove(rowToBeRemoved[0]);
                        zeroQuantityRows = dtZeroQtyRows.Select();
                        if (zeroQuantityRows.Any()) { continue; } else { break; }
                    }
                    //~ If it has been splitted to diffrent reasons than Not Received only ~//
                    var diffrentShortages = grdShortageDt.Select(string.Format("CopyGUID = '{0}'", rowToBeRemoved[0]["CopyGUID"]));
                    if (diffrentShortages.Count() >1)
                    {
                        foreach (var splittedShortage in diffrentShortages)
                        {
                            splittedShortage["InvoicedQty"] = splittedShortage["OriginalInvoicedQty"] = splittedShortage["Pack Qty"];
                        }
                        dtZeroQtyRows.Rows.Remove(rowToBeRemoved[0]);
                        zeroQuantityRows = dtZeroQtyRows.Select();
                        if (zeroQuantityRows.Any()) { continue; } else { break; }
                    }
                    //~ Update Columns Before Remove ~//
                    dr["Pack Qty"] = rowToBeRemoved[0]["Pack Qty"];
                    dr["BU Qty"] = rowToBeRemoved[0]["BU Qty"];
                    dr["InvoicedQty"] = rowToBeRemoved[0]["InvoicedQty"];
                    dr["OriginalInvoicedQty"] = rowToBeRemoved[0]["OriginalInvoicedQty"];

                    dtZeroQtyRows.Rows.Remove(rowToBeRemoved[0]);
                    zeroQuantityRows = dtZeroQtyRows.Select();
                }

            return zeroQuantityRows;
        }

        /// <summary>
        /// This method handles Receive of an Item with full NotReceived Reason
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="dr"></param>
        private void HandleFullNotReceivedAndMultipleBatchPalletlization(ReceiveDoc rec,DataRowView dr)
        {
            DataRow firstEntry = null;
            bool noSoundItems = false;
            // Here: We Can Use One of the Items on a receipt //
            if ((rec.Quantity == 0 && !rec.IsColumnNull("ShortageReasonID") &&
                 rec.ShortageReasonID == ShortageReasons.Constants.NOT_RECEIVED))
            {
                firstEntry =
                    rec.DefaultView.Table.Select(String.Format("[ID] > 0 AND [IsDamaged] = 0")).FirstOrDefault();
            }

            //~ This is a multiple batch case ~//
            if ((rec.Quantity == 0 && rec.IsColumnNull("ShortageReasonID")))
            {
                  var oneAmongMultipleBatchsAndDbSavedGuid =
                        _dtRecGrid.Select(string.Format("CopyGUID = '{0}' And IsCopied = 1 ", dr["CopyGUID"]));

                DataRow[] dbSavedcounts = oneAmongMultipleBatchsAndDbSavedGuid.Any()
                    ? rec.DefaultView.Table.Select(String.Format("GUID = '{0}'",
                        oneAmongMultipleBatchsAndDbSavedGuid[0]["GUID"]))
                    : oneAmongMultipleBatchsAndDbSavedGuid;

                firstEntry = dbSavedcounts.Any()
                    ? dbSavedcounts.FirstOrDefault()
                    : rec.DefaultView.Table.Select(String.Format("[ID] > 0 AND [IsDamaged] = 0")).FirstOrDefault();
            }
            // If we cant find any normal receive in this receipt let's just use one of receiveDocID's randomly: This is just to save a not received Entry with zero quantity! (an awful recent request!)~//
            if (firstEntry == null && ((rec.Quantity == 0 && !rec.IsColumnNull("ShortageReasonID") &&
                rec.ShortageReasonID == ShortageReasons.Constants.NOT_RECEIVED)))
            {
                firstEntry =
                    rec.DefaultView.Table.Select(String.Format("[ID] > 0")).FirstOrDefault();
                if (firstEntry != null)
                {
                    noSoundItems = true;

                }
            }
            // This is  a Zero Quantity ReceiveDoc //
            if (firstEntry != null)
            {
                rec.PhysicalStoreID = Convert.ToInt16(firstEntry["PhysicalStoreID"]);
                rec.InventoryPeriodID = Convert.ToInt16(firstEntry["InventoryPeriodID"]);
                rec.Save();

                // Lets Create a Zero ReceivePallet in the same palletlocation as one of the Items in the receipt //
                var oneOfrecievePallet = new BLL.ReceivePallet();
                oneOfrecievePallet.LoadByReceiveDocID(Convert.ToInt16(firstEntry["ID"]));

                var newReceivePallet = new BLL.ReceivePallet();
                newReceivePallet.AddNew();
                newReceivePallet.IsOriginalReceive = true;
                newReceivePallet.ReceiveID = rec.ID;
                newReceivePallet.Balance = newReceivePallet.ReceivedQuantity = newReceivePallet.ReservedStock = 0;
                newReceivePallet.PalletID = oneOfrecievePallet.PalletID;
                newReceivePallet.PalletLocationID = oneOfrecievePallet.PalletLocationID;
                newReceivePallet.BoxSize = oneOfrecievePallet.BoxSize;
                newReceivePallet.Save();
            }

            if (!rec.IsColumnNull("ShortageReasonID") && rec.ShortageReasonID == BLL.ShortageReasons.Constants.NOT_RECEIVED)
            {
                var recShortage = new ReceiveDocShortage();
                recShortage.AddNew();
                recShortage.ShortageReasonID = rec.ShortageReasonID;
                recShortage.ReceiveDocID = rec.ID;
                recShortage.NoOfPacks = Convert.ToDecimal(dr["InvoicedQty"]);
                recShortage.Save();
            }
        }

        private void MergeReceiveDocLines()
        {
            var dtLines = new DataTable();
            var physicalStores = new List<int>();
            dtLines = _dtRecGrid;
            var orginalRows = dtLines.Select(String.Format("Copy = '{0}'", "Orginal"));
            foreach (DataRow dr in orginalRows)
            {
                if (dr["IsDamaged"] != DBNull.Value && Convert.ToBoolean(dr["IsDamaged"])) continue;
                var duplicates = dtLines.Select(String.Format("GUID = '{0}' OR Copy = '{0}'", dr["GUID"]));
                //including the orginal

                // Find all diffrent Stores among duplicates : if any?
                foreach (DataRow duplicate in duplicates)
                {
                    if (duplicate["Store"] != DBNull.Value && !physicalStores.Contains(Convert.ToInt32(duplicate["Store"])))
                    {
                        physicalStores.Add(Convert.ToInt32(duplicate["Store"]));
                    }
                }

                #region Here: There is only one physical store though palletlocations on this store are diffrent

                if (physicalStores.Count == 1)
                // All pallets are in the same physical store. so we will merge them as one.
                {
                    Decimal quantity = 0, bonInvQty = 0;
                    bool bonus = false;
                    foreach (DataRow duplicate in duplicates)
                    {
                        quantity += Convert.ToDecimal(duplicate["Pack Qty"]);
                        if (HasBonus(dr["GUID"].ToString()))
                        {
                            bonInvQty += Convert.ToDecimal(duplicate["InvoicedQty"]);
                            bonus = true;
                        }

                        if (!_revDocRelatePalletGuid.ContainsKey(dr["GUID"].ToString()))
                            _revDocRelatePalletGuid.Add(dr["GUID"].ToString(), new List<string> { dr["GUID"].ToString() });
                        // KEY for the dictionary: Orginal row
                        if (duplicate["GUID"] != dr["GUID"])
                        {
                            _revDocRelatePalletGuid[dr["GUID"].ToString()].Add(duplicate["GUID"].ToString());
                            // Values for the above key: dictionary
                            _dtRecGrid.Rows.Remove(
                                _dtRecGrid.Select(String.Format("GUID = '{0}'", duplicate["GUID"]))[0]);
                        }
                    }
                    DataRow mergedRow = _dtRecGrid.Select(String.Format("GUID = '{0}'", dr["GUID"]))[0];
                    // so the orginal only left, copies of same physical store were removed!
                    mergedRow["Pack Qty"] = quantity;

                    if (!bonus)
                    {
                        mergedRow["InvoicedQty"] = quantity + HasShortageQty(dr["GUID"].ToString());
                    }
                    else
                    {
                        mergedRow["InvoicedQty"] = bonInvQty;
                    }
                }

                #endregion
                #region Here: On One orginal row diffrent copies of it with different Physicalstore Detected!

                else
                {
                    foreach (var store in physicalStores)
                    {
                        var duplicatesInOneStore =
                            dtLines.Select(String.Format("Store = '{0}' And ( Copy = '{1}' OR GUID = '{1}' )", store,
                                dr["GUID"]));
                        if (duplicatesInOneStore.Count() <= 1)
                        {
                            // Do nothing !//
                        }

                        #region Here:Lets merge all palletlocations on this store as one row.

                        else
                        {
                            bool orginalRowExistInthisStore = false;
                            var takeFirstRow = duplicatesInOneStore[0]["GUID"];
                            if (!_revDocRelatePalletGuid.ContainsKey(takeFirstRow.ToString()))
                                _revDocRelatePalletGuid.Add(takeFirstRow.ToString(),
                                    new List<string> { takeFirstRow.ToString() });
                            Decimal quantity = 0, bonInvQty = 0;
                            bool bonus = false;

                            foreach (DataRow duplicate in duplicatesInOneStore)
                            {
                                if (!orginalRowExistInthisStore)
                                    orginalRowExistInthisStore = duplicate["Copy"].ToString() == "Orginal";
                                quantity += Convert.ToDecimal(duplicate["Pack Qty"]);

                                if (HasBonus(dr["GUID"].ToString()))
                                {
                                    bonInvQty += Convert.ToDecimal(duplicate["InvoicedQty"]);
                                    bonus = true;
                                }

                                if (duplicate["GUID"] != takeFirstRow)
                                {
                                    _revDocRelatePalletGuid[takeFirstRow.ToString()].Add(duplicate["GUID"].ToString());
                                    _dtRecGrid.Rows.Remove(
                                        _dtRecGrid.Select(String.Format("GUID = '{0}'", duplicate["GUID"]))[0]);
                                }
                            }
                            DataRow mergedRow =
                                _dtRecGrid.Select(String.Format("GUID = '{0}'", takeFirstRow.ToString()))[0];
                            mergedRow["Pack Qty"] = mergedRow["BU Qty"] = quantity;

                            if (!bonus)
                            {
                                // no bonus here! //
                                mergedRow["InvoicedQty"] = orginalRowExistInthisStore
                                    ? quantity + HasShortageQty(dr["GUID"].ToString())
                                    : quantity;
                            }
                            else
                            {
                                mergedRow["InvoicedQty"] = bonInvQty;
                            }

                        }

                        #endregion

                    }
                }

                #endregion

                physicalStores.Clear();
                // tasks related with one orginal row finished: so clear count of physical store.
            }

        }

        private Decimal HasShortageQty(string orginalGuid)
        {
            if (grdShortageOrDamaged.DataSource == null) return 0;
            var dataView = ((DataTable)grdShortageOrDamaged.DataSource).AsDataView();
            dataView.RowFilter = string.Format("[GUID]='{0}'", orginalGuid);
            var rows = dataView.ToTable().DefaultView;

            if (rows.Count <= 0) return 0;
            var shrtQuantity =
                (from DataRowView dRow in rows
                 where dRow["ShortageReasonID"] != DBNull.Value && Convert.ToInt32(dRow["ShortageReasonID"]) != ShortageReasons.Constants.DAMAGED
                 select Convert.ToDecimal(dRow["Pack Qty"])).Sum();
            return shrtQuantity;
        }

        private int SaveRelevantReceiptHeaders(int receiptTypeID, int warehouseID)
        {
            int receiptID;
            var receipt = new BLL.Receipt();
            var sup = new BLL.Supplier();

            if (lkReceiptInvoice.EditValue != null && Convert.ToInt32(lkReceiptInvoice.EditValue) != -1)
            {
                receiptID = receipt.AddNewReceipt(receiptTypeID, warehouseID, CurrentContext.UserId,
                    Convert.ToInt32(lkReceiptInvoice.EditValue), txtEditTransferNo.Text,
                    ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED);
                // , txtTransitNo.Text, txtInsuranceNo.Text, txtWayBillNo.Text);
            }
            else
            {
                //PO and ReceiptInvoice created automatically.
                //Needs to be fixed.
                BLL.PO po = new PO();
                BLL.ReceiptInvoice rctInvoice = new ReceiptInvoice();

                po.AddNew();
                var serverDateTime = DateTimeHelper.ServerDateTime;
                po.PODate = serverDateTime;
                po.DateOfEntry = serverDateTime;
                po.PurchaseType = POType.INVENTORY;
                po.IsElectronic = false;
                po.POFinalized = false;
                po.Rowguid = Guid.NewGuid();
                po.Identifier = "00000";

                po.PaymentTypeID = BLL.PaymentType.Constants.STV;
                po.TermOfPayement = BLL.PaymentTerm.Internal;
                po.PurchaseOrderStatusID = PurchaseOrderStatus.Processed;

                rctInvoice.AddNew();

                po.StoreID = Convert.ToInt32(lkAccounts.EditValue);
                Activity acc = new Activity();
                acc.LoadByPrimaryKey(po.StoreID);
                po.ModeID = acc.ModeID;

                //po.PONumber = srm ? lkSTVInvoiceNo.EditValue.ToString() : (deliveryNote ? txtRefNo.Text : (beginningBalance ? "BeginningBalance" : String.Empty));


                if (lcSTVNo.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                {
                    po.PONumber = srm && !chkSRMForOldSystemIssues.Checked
                        ? txtSTVNo.Text
                        : ((deliveryNoteType != DeliveryNoteType.NotSet)
                            ? txtSTVNo.Text
                            : (beginningBalance
                                ? "BeginningBalance"
                                : (srm && chkSRMForOldSystemIssues.Checked
                                    ? txtSTVInvoiceNoOldSystem.Text
                                    : txtRefNo.Text)));
                }
                else
                {
                    po.PONumber = srm && !chkSRMForOldSystemIssues.Checked
                        ? lkSTVInvoiceNo.Text
                        : ((deliveryNoteType != DeliveryNoteType.NotSet)
                            ? txtRefNo.Text
                            : (beginningBalance
                                ? "BeginningBalance"
                                : (srm && chkSRMForOldSystemIssues.Checked
                                    ? txtSTVInvoiceNoOldSystem.Text
                                    : txtRefNo.Text)));
                }

                   //TODO: Ugly hack, supplier. To be fixed.
                    if (srm)
                    {
                        po.SupplierID = BLL.Supplier.CONSTANTS.RETURNED_FROM_FACILITY;

                        //Let's put Finance Required stuff here.
                        po.Insurance = 0;
                        po.ExhangeRate = 1;
                        rctInvoice.ExchangeRate = 1;
                        rctInvoice.Insurance = 0;

                        rctInvoice.InvoiceTypeID = ReceiptInvoiceType.InvoiceType.LOCAL_PURCHASE;


                        if (chkSRMForOldSystemIssues.Checked)
                        {
                            if (lkForFacility.EditValue == null)
                                throw new Exception("Facility not chosen!");
                            po.RefNo = lkForFacility.EditValue.ToString();
                        }
                    }
                   
                po.SavedbyUserID = CurrentContext.LoggedInUser.ID;
                po.Save();

                rctInvoice.POID = po.ID;
                if (lcSTVNo.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always)
                {
                    rctInvoice.STVOrInvoiceNo = srm && !chkSRMForOldSystemIssues.Checked
                        ? txtSTVNo.Text
                        : ((deliveryNoteType != DeliveryNoteType.NotSet)
                            ? txtSTVNo.Text
                            : (beginningBalance
                                ? "BeginningBalance"
                                : (srm && chkSRMForOldSystemIssues.Checked
                                    ? txtSTVInvoiceNoOldSystem.Text
                                    : txtSTVNo.Text)));
                }
                else
                {
                    rctInvoice.STVOrInvoiceNo = srm && !chkSRMForOldSystemIssues.Checked
                        ? lkSTVInvoiceNo.Text
                        : ((deliveryNoteType != DeliveryNoteType.NotSet)
                            ? txtRefNo.Text
                            : (beginningBalance
                                ? "BeginningBalance"
                                : (srm && chkSRMForOldSystemIssues.Checked
                                    ? txtSTVInvoiceNoOldSystem.Text
                                    : txtRefNo.Text)));
                }
                rctInvoice.DateOfEntry = DateTimeHelper.ServerDateTime;
                rctInvoice.ActivityID = po.StoreID;
                rctInvoice.SavedByUserID = CurrentContext.LoggedInUser.ID;
                rctInvoice.IsDeliveryNote = false;

                rctInvoice.Rowguid = Guid.NewGuid();
                rctInvoice.PrintedDate = po.DateOfEntry;
                rctInvoice.IsVoided = false;
                rctInvoice.ShippingSite = " ";
                rctInvoice.IsConvertedFromDeliveryNote = false;
                rctInvoice.IsDeliveryNote = false;
                rctInvoice.DocumentTypeID = DocumentType.CONSTANTS.SRM;

                rctInvoice.Save();

                receiptID = receipt.AddNewReceipt(receiptTypeID, warehouseID, CurrentContext.UserId, rctInvoice.ID,
                    txtTransitTransferVoucherNo.Text, ReceiptConfirmationStatus.Constants.RECEIVE_ENTERED);

                //receiptID = receipt.AddNewReceipt(receiptTypeID, NewMainWindow.UserId);
            }
            return receiptID;
        }

        private void AddNewReceiveDoc(BLL.ReceiveDoc rec, int receiptID, DataRowView dr, bool isDamaged = false)
        {
            rec.AddNew();
            FillInReceiveDocInformation(rec, receiptID, dr);
            SavePalletization(rec, dr);
            if (isDamaged)
            {
                HandleReceiveDocShortage(dr, rec, rec.ID);
            }
        }

        /// <summary>
        /// Needs to be the first function to be called when saving a new receive doc entry.
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="receiptID"></param>
        /// <param name="dr"></param>
        private void FillInReceiveDocInformation(ReceiveDoc rec, int receiptID, DataRowView dr)
        {
            try
            {
                rec.GetColumn("GUID");
            }
            catch
            {
                rec.AddColumn("GUID", typeof(string));
                //rec.AddColumn("IsDamaged", typeof(bool));
                //This is only used if the Check box is used to receive damaged receives (For SRM only)
            }

            rec.StoreID = Convert.ToInt32(lkAccounts.EditValue);
            rec.RefNo = txtRefNo.Text;
            rec.Remark = txtRemark.Text;


            rec.ReceivedBy = CurrentContext.LoggedInUserName;

            DateTime xx = dtRecDate.Value;
            dtRecDate.CustomFormat = "MM/dd/yyyy";
            DateTime dtRec = new DateTime();
            rec.Date = ConvertDate.DateConverter(dtRecDate.Text);
            dtRec = ConvertDate.DateConverter(dtRecDate.Text);
            rec.EurDate = BLL.DateTimeHelper.ServerDateTime;
            rec.ItemID = Convert.ToInt32(dr["ID"]);
            rec.NoOfPack = Convert.ToDecimal(dr["Pack Qty"]);
            rec.SetColumn("GUID", dr["GUID"].ToString());
            rec.IsDamaged = Convert.ToBoolean(dr["IsDamaged"]);

            if (standardRecType == StandardReceiptType.iGRVOnline)
            {
                rec.SetColumn("PricePerPack", dr["Price/Pack"]);
                rec.SetColumn("Margin", dr["Margin"]);
                rec.SetColumn("UnitCost", dr["Price/Pack"]);
            }

            //TODO: This if is a garbage. Remove
            if (dr["InvoicedQty"] == DBNull.Value)
            {
                rec.InvoicedNoOfPack = rec.NoOfPack;
            }

            rec.InvoicedNoOfPack = srm ? Convert.ToDecimal(dr["IssuedQty"]) : Convert.ToDecimal(dr["OriginalInvoicedQty"]);

            rec.ManufacturerId = Convert.ToInt32(dr["Manufacturer"]);
            BLL.ItemManufacturer im = new BLL.ItemManufacturer();

            im.LoadIMbyLevel(rec.ItemID, rec.ManufacturerId, 0);
            if (dr["UnitID"] != DBNull.Value)
            {
                // if unit has been set, pick the qty per pack from the unit
                rec.UnitID = Convert.ToInt32(dr["UnitID"]);
                ItemUnit itemUnit = new ItemUnit();
                itemUnit.LoadByPrimaryKey(rec.UnitID);

                rec.QtyPerPack = itemUnit.QtyPerUnit;
            }
            else
            {
                rec.QtyPerPack = im.QuantityInBasicUnit;
            }
            rec.Quantity = rec.QuantityLeft = rec.NoOfPack * rec.QtyPerPack;

            try
            {
                if ((deliveryNoteType == DeliveryNoteType.NotSet))
                {
                    if (!BLL.Settings.HandleGRV && !srm)
                    {
                        rec.PricePerPack = Convert.ToDouble(dr["Price/Pack"]);
                        double pre = (Convert.ToDouble(dr["Price/Pack"]) / 1); //rec.QtyPerPack);
                        rec.Cost = pre;
                    }
                    rec.DeliveryNote = false;
                }
                else
                {
                    rec.DeliveryNote = true;
                    if (deliveryNoteType == DeliveryNoteType.Automatic)
                    {
                        rec.SetColumn("PricePerPack", dr["Price/Pack"]);
                        rec.SetColumn("Margin", dr["Margin"]);
                        rec.SetColumn("UnitCost", dr["Price/Pack"]);
                    }
                }
            }
            catch
            {
                // catch the error if the recieve doesn't have cost information
                // NOTE: this shall never happen.
            }

            if (dr["Batch No"] != DBNull.Value)
            {
                rec.BatchNo = dr["Batch No"].ToString(); // receivingGrid.Rows[i].Cells[8].Value.ToString();
            }

            if (dr["Expiry Date"] != DBNull.Value)
            {
                rec.ExpDate = Convert.ToDateTime(dr["Expiry Date"]); //receivingGrid.Rows[i].Cells[9].Value);
            }

            if (!srm)
            {
                rec.SupplierID = _supplierID; 
            }
            else 
            {
                rec.SupplierID = BLL.Supplier.CONSTANTS.RETURNED_FROM_FACILITY;
                //TODO: Returned From Supplier: To be removed.  This is an unacceptable hack.
                rec.RefNo = lkSTVInvoiceNo.Text;
                if (string.IsNullOrEmpty(txtRemark.Text))
                {
                    XtraMessageBox.Show(
                        "Please enter the reason for the SRM.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    throw new Exception("Reason not entered for SRM");
                }
                else
                {
                    rec.Remark = txtRemark.Text;
                }
            }
            

            rec.ReturnedStock = srm;

            if (srm && !chkSRMForOldSystemIssues.Checked)
            {
                rec.ReturnedFromIssueDocID = int.Parse(dr["IssueDocID"].ToString());
                int issueDocID = int.Parse(dr["IssueDocID"].ToString());
                BLL.IssueDoc iss = new IssueDoc();
                iss.LoadByPrimaryKey(issueDocID);
                BLL.ReceiveDoc rd = new ReceiveDoc();
                rd.LoadByPrimaryKey(iss.RecievDocID);
                //If it was a delivery note, then the return will not have price information associated with it.

                // HW-2189 
                decimal? UnitCost, SellingPrice, Margin;
                UnitCost = SellingPrice = Margin = null;

                if (!BLL.Settings.HandleGRV)
                {
                    if (!iss.IsColumnNull("UnitCost") && iss.IsColumnNull("SellingPrice"))
                    {
                        UnitCost = iss.UnitCost;
                        SellingPrice = iss.SellingPrice;
                        Margin = !iss.IsColumnNull("Margin") ? iss.Margin : 0;
                    }
                    else if (!iss.IsColumnNull("Cost"))
                    {
                        Margin = !rd.IsColumnNull("Margin") ? Convert.ToDecimal(rd.Margin) : 0;
                        SellingPrice = Convert.ToDecimal(iss.Cost / Convert.ToDouble(iss.NoOfPack));
                        UnitCost = BLL.Settings.IsCenter ? SellingPrice : SellingPrice / Convert.ToDecimal(Margin + 1);
                    }
                }
                else
                {
                    if (!iss.IsColumnNull("UnitCost") && iss.IsColumnNull("SellingPrice") && iss.UnitCost != 0 &&
                        iss.SellingPrice != 0)
                    {
                        UnitCost = iss.UnitCost;
                        SellingPrice = iss.SellingPrice;
                        Margin = !iss.IsColumnNull("Margin") ? iss.Margin : 0;
                    }
                    else if (!iss.IsColumnNull("Cost") && iss.Cost != 0)
                    {
                        Margin = !rd.IsColumnNull("Margin") ? Convert.ToDecimal(rd.Margin) : 0;
                        SellingPrice = Convert.ToDecimal(iss.Cost / Convert.ToDouble(iss.NoOfPack));
                        UnitCost = BLL.Settings.IsCenter ? SellingPrice : SellingPrice / Convert.ToDecimal(Margin + 1);
                    }
                }

                if (UnitCost.HasValue)
                {
                    rec.PricePerPack = Convert.ToDouble(UnitCost);
                    rec.Cost = Convert.ToDouble(UnitCost);
                    rec.UnitCost = UnitCost.Value;
                }

                if (SellingPrice.HasValue)
                {
                    rec.SellingPrice = Convert.ToDouble(SellingPrice);
                }

                if (Margin.HasValue)
                {
                    rec.Margin = Convert.ToDouble(Margin);
                }

                if (!rd.IsColumnNull("SupplierID"))
                    rec.SupplierID = rd.SupplierID;
            }

            rec.ReceiptID = receiptID;
            if (BLL.Settings.HandleGRV && !beginningBalance)
            {
                rec.RefNo = receiptID.ToString();
            }
            else if (beginningBalance)
            {
                rec.RefNo = "BeginningBalance";
            }

            //Needs to be fixed! Garbage
            string batch = DateTimeHelper.ServerDateTime.Day.ToString() + DateTimeHelper.ServerDateTime.Hour.ToString() +
                           DateTimeHelper.ServerDateTime.Minute.ToString() + rec.ItemID.ToString();
            rec.LocalBatchNo = batch;
            rec.Out = false;
            rec.IsApproved = false;
            if (dr["ShortageReasonID"] != DBNull.Value)
            {
                rec.ShortageReasonID = Convert.ToInt32(dr["ShortageReasonID"]);
            }
            var item = new Item();
            item.LoadByPrimaryKey(Convert.ToInt32(dr["id"]));

            if (dr["ShortageReasonID"] == DBNull.Value && (item.NeedExpiryBatch || rec.ExpDate <= DateTimeHelper.ServerDateTime))
            {
                rec.ShortageReasonID = ShortageReasons.Constants.DAMAGED;
            }


            dtRecDate.Value = xx;
            _receiptID = receiptID; //Assign it to the global variable so it can be used later on.
        }

        /// <summary>
        /// This needs to be called after FillInReceiveDocInformation has been called.
        /// </summary>
        /// <param name="rec">ReceiveDoc should be passed to this function having been saved and with the id field different from null</param>
        /// <param name="dr">ReceiveDoc should be passed to this function having been saved and with the id field different from null</param>
        private void HandleReceiveDocShortage(DataRowView dr, ReceiveDoc rec, int receiveDocID = 0)
        {
            var recShortage = new ReceiveDocShortage();
            bool shortagetoBeAdded = false;

            if (receiveDocID == 0)
            {
                receiveDocID = Convert.ToInt32(rec.DefaultView.Table.Select(String.Format("GUID = '{0}'", dr["GUID"]))[0]["ID"]);
                shortagetoBeAdded = true;
            }

            //if (rec.GetColumn("ShortageReasonID") == System.DBNull.Value || Convert.ToInt32(rec.GetColumn("ShortageReasonID")) == 1) return;

            if ((srm && Convert.ToBoolean(dr["IsDamaged"])) || (Convert.ToDecimal(dr["InvoicedQty"]) >= Convert.ToDecimal(dr["Pack Qty"])))
            {
                var item = new Item();
                item.LoadByPrimaryKey(Convert.ToInt32(dr["id"]));

                if (dr["ShortageReasonID"] == DBNull.Value &&  rec.ExpDate <= DateTimeHelper.ServerDateTime)
                {
                    dr["ShortageReasonID"] = ShortageReasons.Constants.DAMAGED;
                }

                if (dr["ShortageReasonID"] != DBNull.Value && (!(Convert.ToDecimal(dr["Pack Qty"]) == 0 && Convert.ToInt32(dr["ShortageReasonID"]) == ShortageReasons.Constants.NOT_RECEIVED)))
                {
                    int shortageReasonID = Convert.ToInt32(dr["ShortageReasonID"]);

                    recShortage.AddNew();
                    recShortage.ShortageReasonID = shortageReasonID;
                    recShortage.ReceiveDocID = receiveDocID;
                    recShortage.NoOfPacks = Convert.ToDecimal(dr["Pack Qty"]);

                    if (shortagetoBeAdded)
                    {
                        var receiveDoc = new ReceiveDoc();
                        receiveDoc.LoadByPrimaryKey(receiveDocID);
                        if (receiveDoc.InvoicedNoOfPack!=0 && receiveDoc.Quantity >= receiveDoc.InvoicedNoOfPack)
                        {
                            receiveDoc.InvoicedNoOfPack = receiveDoc.Quantity + recShortage.NoOfPacks;
                            receiveDoc.Save();
                        }

                    }
                }
                else
                {
                    XtraMessageBox.Show(
                        "Please enter the reason for the discrepancy in invoiced vs. received qty.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            recShortage.Save();
        }

        private void ResetFields()
        {
            try
            {
                tabReceiveTabs.SelectedTabPageIndex = 0;
                if (_dtNonPalletizedItemList != null)
                    _dtNonPalletizedItemList.Clear();

                // discrepancy details are handled on the fly on the grid 
                // this is to reset it
                var dataTable = ((DataTable)grdShortageOrDamaged.DataSource);
                if (dataTable != null)
                {
                    dataTable.Clear();
                }

                if (_dtPalletizedItemList != null)
                    _dtPalletizedItemList.Clear();
                if (_dtPutAwayNonPalletized != null)
                    _dtPutAwayNonPalletized.Clear();
                if (_dtPutAwayPalletized != null)
                    _dtPutAwayPalletized.Clear();
                if (_dtRecGrid != null)
                    _dtRecGrid.Clear();

                if (_dtSelectedTable != null)
                {
                    _dtSelectedTable.Clear();
                }

                ItemChoices.Clear();
                //lkCategories_EditValueChanged(null, null);
                lkAccounts.EditValue = null;
                cboStores_EditValueChanged(null, null);

                txtReceivedBy.Text = "";
                txtRemark.Text = "";
                dtRecDate.Value = DateTimeHelper.ServerDateTime;
                txtItemName.Text = "";
                txtRefNo.Text = "";

                lkAccounts.EditValue = null;
            }
            catch
            {

            }
        }
        private void ResetFieldsForSrm()
        {
            try
            {
                tabReceiveTabs.SelectedTabPageIndex = 0;
                if (_dtNonPalletizedItemList != null)
                    _dtNonPalletizedItemList.Clear();

           
                if (_dtPalletizedItemList != null)
                    _dtPalletizedItemList.Clear();
                if (_dtPutAwayNonPalletized != null)
                    _dtPutAwayNonPalletized.Clear();
                if (_dtPutAwayPalletized != null)
                    _dtPutAwayPalletized.Clear();
                if (_dtRecGrid != null)
                    _dtRecGrid.Clear();

                if (_dtSelectedTable != null)
                {
                    _dtSelectedTable.Clear();
                }

                ItemChoices.Clear();

                txtReceivedBy.Text = "";
                txtRemark.Text = "";
                dtRecDate.Value = DateTimeHelper.ServerDateTime;
            }
            catch
            {

            }
        }

        private void btnPrintPalletization_Click(object sender, EventArgs e)
        {
            colSplitPallet.Visible = false;
            compositeLink2.ShowPreview();
            colSplitPallet.Visible = true;
        }

        #endregion

        #region Step Navigation Code

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void OnTabSelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            //PopulateCatTree("Drug");
            if (e.PrevPage.Name == "TabReceive")
            {
                if (e.Page == PalletizeTab || e.Page == PutAwayTab)
                {
                    //Do validation
                    if (!IsRecieveGridValid())
                    {
                        e.Cancel = true;
                        return;
                    }
                    RepairInvoicedQuantitiesBasedOnDamaged();
                }
            }

            if (e.Page.Name == "TabReceive" && e.PrevPage.Name == "TabSelection")
            {
                if (!IsFirstTabValid())
                {
                    e.Cancel = true;
                    return;
                }

                //check if any item was selected here.
                if (_dtSelectedTable != null && _dtSelectedTable.Rows.Count > 0)
                {
                    PopulateListToGrid();
                }
                else
                {
                    if (tabReceiveTabs.SelectedTabPageIndex == 0)
                    {
                        e.Cancel = true;
                        XtraMessageBox.Show("Please select a list of commodities you would like to receive to continue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
            }


            if (e.Page.Name == "PalletizeTab")
            {

                if (e.PrevPage.Name == TabSelection.Name)
                {
                    e.Cancel = true;
                    return;
                }
                if (e.PrevPage == PutAwayTab)
                {
                    if (DialogResult.No == XtraMessageBox.Show("Would you like to reset the palletization and start again?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    };


                }
                //if (!ItemsPalletized)
                {
                    PalletizeRecievedItems();

                }
            }

            if (e.Page.Name == "PutAwayTab")
            {

                if (PalletizationIsValid())
                {
                    if (e.PrevPage.Name == TabSelection.Name)
                    {
                        e.Cancel = true;
                        return;
                    }
                    //if (!ItemsPutAwaysed)
                    {
                        PutAwayRecievedItems(true);
                    }
                }
                else
                {
                    XtraMessageBox.Show("The Palletization is not valid, Please correct your entries and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }

            }
            if (e.Page.Name == "TabReceive" && (e.PrevPage.Name == "PalletizeTab" || e.PrevPage.Name == "PutAwayTab"))
            {
                ReverseInvoicedQuantitiesBasedOnDamaged();
            }
        }


        private void btnNext1_Click(object sender, EventArgs e)
        {
            tabReceiveTabs.SelectedTabPage = TabReceive;
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {


            if (BLL.Settings.IsCenter)
            {
                PalletizeRecievedItems();
                tabReceiveTabs.SelectedTabPage = PutAwayTab;
                txtPassCode.Enabled = false;
                lcPassCode .Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
            {
                tabReceiveTabs.SelectedTabPage = PalletizeTab;
            }
        }

        private bool ValidateStep2()
        {
            //TODO: Do a better validation here
            var invoiceNo = lkReceiptInvoice.Text;
            var IsElectronic = ReceiptInvoice.IsInvoiceElectronic(invoiceNo);

            if (lcRefNo.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always && !dxValidateRefNo.Validate())
            {
                XtraMessageBox.Show("Please input STV/Invoice inorder to proceed.", "Input Invoice", MessageBoxButtons.OK);
                return false;
            }
            //TODO: use the dx validation provider.
            //or This has to be done on the first step.
            if (BLL.Settings.IsCenter && lcReceiptInvoice.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Always && lkReceiptInvoice.Enabled == true && lkReceiptInvoice.EditValue == null)
            {
                XtraMessageBox.Show("Please choose invoice to proceed.", "Choose Invoice", MessageBoxButtons.OK);
                return false;
            }

            if (srm && !dxValidateRemark.Validate())
            {
                XtraMessageBox.Show("Please fill in the reason for the SRM to proceed.", "SRM Reason", MessageBoxButtons.OK);
                return false;
            }

            // Are all required fields filled in the grid?
            // and are those fields that accept decimal and not abused?
            bool isValid = true;
            foreach (DataRow dr in _dtRecGrid.Rows)
            {
                Item item = new Item();
                item.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));
                dr.ClearErrors();

                if (Convert.ToInt32(cboReceiveType.EditValue) != ReceiptType.CONSTANTS.STOCK_RETURN && !beginningBalance && dr["InvoicedQty"] == DBNull.Value)
                {
                    dr.SetColumnError("InvoicedQty", "Invoiced Quantity Cannot be Blank");
                    isValid = false;
                }
                else
                {

                    if (!item.ProcessInDecimal)
                    {
                        if (Convert.ToInt32(cboReceiveType.EditValue) != ReceiptType.CONSTANTS.STOCK_RETURN && dr["InvoicedQty"] != DBNull.Value && Convert.ToDecimal(dr["InvoicedQty"]) % 1 != 0)
                        {
                            dr.SetColumnError("InvoicedQty", "Invoiced Quantity Cannot Decimal for this Item");
                            isValid = false;
                        }

                    }
                }

                if (dr["Pack Qty"] == DBNull.Value)
                {
                    dr.SetColumnError("Pack Qty", "Received Quantity Cannot be Blank");
                    isValid = false;
                }
                else
                {
                    if (Convert.ToDecimal(dr["Pack Qty"]) % 1 != 0 && !item.ProcessInDecimal)
                    {
                        dr.SetColumnError("Pack Qty", "Invoiced Quantity Cannot Decimal for this Item");
                        isValid = false;
                    }
                }
            }

            // Before continuing to the next validation ... check if the previous once have passed.
            if (!isValid)
            {
                return false;
            }
            // do all the descrepancies have entry on the detail?
            isValid = true;
            DataTable descrepancyDetails = (DataTable)grdShortageOrDamaged.DataSource;

            foreach (DataRow dr in _dtRecGrid.Rows)
            {
                dr.ClearErrors();
                // find the descrepancy - if there is any
                decimal descrepancy = 0;
                decimal splittedQty = 0;

                if (Convert.ToInt32(cboReceiveType.EditValue) != ReceiptType.CONSTANTS.STOCK_RETURN && dr["InvoicedQty"] != DBNull.Value)
                {
                     descrepancy = Convert.ToDecimal(dr["NotReceived"]);
                    //dr["GUID"];
                }

                // if the descrepancy is 0, then there need not be any entry down there

               decimal sumOfDetails = 0;

               if (descrepancyDetails != null && descrepancyDetails.Rows.Count != 0)
               {
                   string batchNofilter = (Convert.ToString(dr["Batch No"]).Equals("")) ? "" : string.Format(" And [Batch No] = '{0}'", Convert.ToString(dr["Batch No"]));
                   string filterString = string.Format("ID = '{0}' AND UnitID = '{1}' AND Manufacturer = '{2}' {3} ", dr["ID"], dr["UnitID"], dr["Manufacturer"], batchNofilter);

                   if (!descrepancyDetails.Select(filterString).Any()) continue; //~Splitted Batch Case! Since Our Descrepancy is only one let us jump the Copied ones!~//
                    sumOfDetails =
                        descrepancyDetails.Select(filterString).Sum(r => r.Field<decimal>("Pack Qty"));

                }

                if (descrepancy <= 0)
                {
                    if (sumOfDetails > 0)
                    {
                        isValid = false;
                        dr.SetColumnError("Pack Qty", "This desrepancy Detail is not neccessary.");
                    }
                }
                // else, is the sum of the descrepancies = the actual discrepancy documented with the details?
                else
                {

                    if (sumOfDetails == 0)
                    {
                        dr.SetColumnError("Pack Qty", "There is no valid descrepancy detail. Please revisit your entries.");
                        isValid = false;
                    }
                    else if (sumOfDetails != descrepancy)
                    {
                        dr.SetColumnError("Pack Qty", "The descrepancy don't match with the sum of details you specified below.");
                        isValid = false;
                    }

                }
            }

            // is the reason specified?
            if (descrepancyDetails != null)
            {
                foreach (DataRow dr in descrepancyDetails.Rows)
                {
                    dr.ClearErrors();

                    if (dr["ShortageReasonID"] == DBNull.Value)
                    {
                        dr.SetColumnError("ShortageReasonID", "You should select the descrepancy reason.");
                        isValid = false;
                    }

                }
            }
            return isValid;
        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            tabReceiveTabs.SelectedTabPage = PutAwayTab;
        }

        #endregion

        private void cboStores_EditValueChanged(object sender, EventArgs e)
        {
            lkRegion.Enabled = true;
            _chosenAccountType = lkAccounts.Text;
            if (lkAccounts.EditValue != null)
            {
                PopulateReceiveGrid();
                if (!chkSRMForOldSystemIssues.Checked)
                {
                    lkRegion.Enabled = true;
                    storeID = int.Parse(lkAccounts.EditValue.ToString());
                    //Bind the Region Lookup (Zone and Woredas will be bind after selection Region)
                    lkRegion.Properties.DataSource = BLL.Region.GetAllRegions(true, storeID).DefaultView;
                    //lkRegion.EditValue = GeneralInfo.Current.Region;
                }
            }
            else
            {
                gridItemsChoice.DataSource = null;
            }
        }

        private void LoadItemsFromSTVInvoice(int storeID, int stvPrintedID)
        {
            BLL.Issue stv = new BLL.Issue();
            stv.LoadByStoreIDAndPrintedID(storeID, stvPrintedID);
            if (stv.RowCount == 0)
            {
                XtraMessageBox.Show("Invalid STV/Invoice number!", "Error");
                return;
            }

            DataTable tbl = BLL.Item.GetItemsBySTVInvoiceNoForStockReturn(stv.ID, storeID);

            _dtSelectedTable = tbl.Clone();
            gridSelected.DataSource = _dtSelectedTable;

            foreach (DataRow dr in tbl.Rows)
            {
                SelectAnItem(dr);
            }
        }

        private void LoadItemsFromSTVInvoice(int stvID)
        {
            BLL.Issue stv = new BLL.Issue();
            stv.LoadByPrimaryKey(stvID);
            if (stv.RowCount == 0)
            {
                XtraMessageBox.Show("Invalid STV/Invoice number!", "Error");
                return;
            }
            ResetFieldsForSrm();
            DataTable tbl = BLL.Item.GetItemsBySTVInvoiceNoForStockReturn(stv.ID, stv.StoreID); //TODO: The function contains storeID for the moment. Just not to change the function structure but needs to be corrected.

            _dtSelectedTable = tbl.Clone();
            gridSelected.DataSource = _dtSelectedTable;

            foreach (DataRow dr in tbl.Rows)
            {
                SelectAnItem(dr);
            }
        }

        private void LoadItemsFromTransferredReceiptInvoiceDetail(int receiptInvoiceID)
        {
            BLL.ReceiptInvoice receiptInvoice = new ReceiptInvoice();
            receiptInvoice.LoadByPrimaryKey(receiptInvoiceID);
            if (receiptInvoice.RowCount == 0)
            {
                XtraMessageBox.Show("Invalid STV/Invoice number!", "Error");
                return;
            }

            DataTable tbl = BLL.Item.GetItemsByReceiptInvoiceNoForSTVTransfer(receiptInvoice.ID);

            _dtSelectedTable = tbl.Clone();
            gridSelected.DataSource = _dtSelectedTable;

            foreach (DataRow dr in tbl.Rows)
            {
                SelectAnItem(dr);
            }
        }

        #region Load Functions

        private void LoadZones()
        {
            //Clear Zone Selection
            lkZone.EditValue = null;
            // Bind the Zone Lookup
            DataTable zone = Zone.GetZoneByRegionAndNumberRU(Convert.ToInt32(lkRegion.EditValue), storeID, true);
            lkZone.Properties.DataSource = zone.DefaultView;
            //check if Zone Lookup Has 
            if (zone.Rows.Count != 0)
                lkWoreda.Properties.NullText = " Select Zone";
            else
                lkWoreda.Properties.NullText = "";
            LoadReceivingUnits();

        }

        private void LoadWoredas()
        {
            //Clear Zone Selection
            lkWoreda.EditValue = null;
            //Bind the Woreda Lookup

            DataTable woreda = Woreda.GetWoredaByZoneAndNumberRU(Convert.ToInt32(lkZone.EditValue), storeID, true);
            lkWoreda.Properties.DataSource = woreda.DefaultView; ;

            if (woreda.Rows.Count != 0)

                lkWoreda.Properties.NullText = " Select Woreda";
            else
                lkWoreda.Properties.NullText = "";

        }
        private void LoadFacilityType()
        {
            //Clear  Selection
            lkType.EditValue = null;
            //Bind the Ownership Type Lookup

            DataTable Facilitytype = InstitutionType.GetReceivingUnitTypeByRegionAndNumberRU(Convert.ToInt32(lkWoreda.EditValue), storeID, true);
            lkType.Properties.DataSource = Facilitytype.DefaultView; ;

            if (Facilitytype.Rows.Count != 0)

                lkType.Properties.NullText = " Select Facility Type";
            else
                lkType.Properties.NullText = "";
        }
        #endregion

        #region Lookup Edit Value Changed

        private void lkRegion_EditValueChanged(object sender, EventArgs e)
        {
            
            LoadZones();
            //LoadWoredas();
            //LoadReceivingUnits();
            if (lkRegion.Enabled == true)
                lkZone.Enabled = true;
        }

        //private void cboStores_TextChanged(object sender, EventArgs e)
        //{
        //    cboStores_EditValueChanged(null, null);
        //}
        private void lkZone_EditValueChanged(object sender, EventArgs e)
        {
            LoadWoredas();
            if (lkZone.Enabled == true)
                lkWoreda.Enabled = true;
        }

        private void lkWoreda_EditValueChanged(object sender, EventArgs e)
        {
            //LoadReceivingUnits();
            LoadFacilityType();
            if (lkWoreda.Enabled == true)
                lkType.Enabled = true;
        }

        private void lkOwnership_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
            if (lkOwnership.Enabled == true)
                lkForFacility.Enabled = true;
        }

        private void lkType_EditValueChanged(object sender, EventArgs e)
        {
            LoadOwnershipType();
            if (lkType.Enabled == true)
                lkOwnership.Enabled = true;
        }

        private void lkForFacility_EditValueChanged(object sender, EventArgs e)
        {
            if (lkAccounts.EditValue == null && !chkSRMForOldSystemIssues.Checked)
            {
                XtraMessageBox.Show("Please choose account type!", "Choose Account Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lkSTVInvoiceNo.Properties.DataSource = null;
                lkForFacility.EditValue = null;
                lkSTVInvoiceNo.Enabled = false;
                return;
            }

            if (!chkSRMForOldSystemIssues.Checked)
            {
                int facilityID = int.Parse(lkForFacility.EditValue.ToString());
                int storeID = int.Parse(lkAccounts.EditValue.ToString());
                lkSTVInvoiceNo.Properties.DataSource = BLL.Issue.GetLogForFacility(storeID, facilityID);
                if (lkForFacility.Enabled == true)
                    lkSTVInvoiceNo.Enabled = true;
            }
        }

        private void lkSTVInvoiceNo_EditValueChanged(object sender, EventArgs e)
        {
            if (ValidateForSRM() == false)
            {
                lkSTVInvoiceNo.EditValue = null;
                return;
            }
            int storeID = int.Parse(lkAccounts.EditValue.ToString());
            int stvID = int.Parse(lkSTVInvoiceNo.EditValue.ToString());
            // LoadItemsFromSTVInvoice(storeID, stvID);
            LoadItemsFromSTVInvoice(stvID);
        }
        #endregion

        private bool ValidateForSRM()
        {
            if (lkAccounts.EditValue == null)
            {
                XtraMessageBox.Show("Please choose account type!", "Choose Account Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (lkSTVInvoiceNo.EditValue == null)
            {
                XtraMessageBox.Show("Please choose a valid stv/invoice number!", "Choose Account Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void lkForFacility_TextChanged(object sender, EventArgs e)
        {
            lkForFacility_EditValueChanged(null, null);
        }

        private void grdLkEditAccounts_EditValueChanged(object sender, EventArgs e)
        {
            _chosenAccountType = lkAccounts.Text;
            if (lkAccounts.EditValue != null)
            {
                PopulateReceiveGrid();
                lkRegion.Enabled = true;
                storeID = int.Parse(lkAccounts.EditValue.ToString());
                //Bind the Region Lookup (Zone and Woredas will be bind after selection Region)
                lkRegion.Properties.DataSource = BLL.Region.GetAllRegions(true, storeID).DefaultView;
                //lkRegion.EditValue = GeneralInfo.Current.Region;
            }
            else
            {
                gridItemsChoice.DataSource = null;
            }
        }

        private void lkReceiptInvoice_EditValueChanged(object sender, EventArgs e)
        {
         
            ResetFields();


            if (lkReceiptInvoice.EditValue != null)
            {
                if ((standardRecType == StandardReceiptType.iGRVOnline || deliveryNoteType == DeliveryNoteType.Automatic) && lkReceiptInvoice.EditValue.Equals(-1))
                {
                    HandleReceiptTypeChange(true);
                    return;
                }

                if (standardRecType == StandardReceiptType.iGRV && !lkReceiptInvoice.EditValue.Equals(-1))
                {
                    //This means, the hub has chosen an invoice other than "Not Found" from the list of invoices.  Therefore, we want to change the receipt type to be iGRV-Online.
                    HandleReceiptTypeChange();
                }

                BLL.ReceiptInvoice rctInvoice = new ReceiptInvoice();
                rctInvoice.LoadByPrimaryKey(Convert.ToInt32(lkReceiptInvoice.EditValue));
                var po = new PO();
                po.LoadByPrimaryKey(rctInvoice.POID);

                if (po.IsElectronic == true)
                {
                    rdIsElectronic.Checked = true;
                    lblSyncDate.Text = rctInvoice.DateOfEntry.ToShortDateString();
                    txtPassCode.Enabled = true;
                    lcPassCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    rdIsElectronic.Checked = false;
                    lblSyncDate.Text = "-";
                    txtPassCode.Enabled = false;
                    lcPassCode.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                lblOrderNo.Text = po.PONumber;
                lblOrderNum.Text = po.PONumber;

                if (!rctInvoice.IsColumnNull("DocumentTypeID"))
                {
                    var doctype = new BLL.DocumentType();
                    doctype.LoadByPrimaryKey(rctInvoice.DocumentTypeID);
                    lblDeliveryNote.Text = doctype.Name;
                    lblHeaderDoc.Text = doctype.Name;
                }
                else
                {
                    lblDeliveryNote.Text = "-";
                    lblHeaderDoc.Text = "-";
                }

                var mode = new Mode();
                mode.LoadByPrimaryKey(po.ModeID);
                lblMode.Text = mode.TypeName;
                lblAccount.Text = "-";
                lblSubAccount.Text = "-";
                lblActivity.Text = "-";
                lblReferenceNo.Text = po.RefNo;

                var payment = new PaymentType();
                payment.LoadByPrimaryKey(po.PaymentTypeID);
                lblPaymentType.Text = payment.Name;
                lblHeaderPayment.Text = payment.Name;

                //if (po.IsColumnNull("NBE"))
                //{
                //    lblNebService.Text = Convert.ToString(po.NBE);
                //}
                //else 
                //{
                //    lblNebService.Text = "-";
                //}

                if (po.Remaining != -1)
                    lblRemainingValue.Text = po.Remaining.ToString();
                else
                    lblRemainingValue.Text = "-";

                if (po.TotalValue != -1)
                    lblTotalValue.Text = po.Remaining.ToString();
                else
                    lblTotalValue.Text = "-";

                if (po.Insurance != -1)
                    lblChargeInsurance.Text = po.Insurance.ToString();
                else
                    lblChargeInsurance.Text = "-";

                if (po.NBE != -1)
                    lblNebService.Text = po.NBE.ToString();
                else
                    lblNebService.Text = "-";

                lblOrderDate.Text = po.PODate.ToShortDateString();
                lblReceiptDate.Text = rctInvoice.DateOfEntry.ToShortDateString();

                var user = new User();
                user.LoadByPrimaryKey(po.SavedbyUserID);
                lblOrderBy.Text =  user.FullName;

                var sup = new Supplier();
               
                

                lkAccounts.EditValue = rctInvoice.ActivityID;
                var act = new Activity();
                act.LoadByPrimaryKey(rctInvoice.ActivityID);
                _supplierID = rctInvoice.GetSupplier();
                sup.LoadByPrimaryKey(_supplierID);
                
                lblSupplier.Text = sup.CompanyName;
                lblOrdSup.Text = sup.CompanyName;
                lblInvoiceNo.Text = rctInvoice.STVOrInvoiceNo;

               
                lblInvAccount.Text = act.AccountName ?? "-";
                lblInvActivity.Text = act.Name ?? "-";
                lblAct.Text = act.FullActivityName ?? "-";
                lblInvSubAccount.Text = act.SubAccountName ?? "-";
                lblInvMode.Text = act.ModeName ?? "-";
                lblInvTotalValue.Text = rctInvoice.TotalFOBValue.ToString("N");
                lblInsurancePolicy.Text = rctInvoice.InsurancePolicyNo == " "? rctInvoice.InsurancePolicyNo : "-";


                var poType = new POType();
                poType.LoadByPrimaryKey(po.PurchaseType);
                lblOrderType.Text = poType.Name ?? "-";
                lblPOType.Text = poType.Name ?? "-";

                var poStatus = new PurchaseOrderStatus();
                poStatus.LoadByPrimaryKey(po.PurchaseOrderStatusID);
                lblOrderStatus.Text = poStatus.Name ?? "-";

                var it = new InvoiceType();
                it.LoadByPrimaryKey(rctInvoice.InvoiceTypeID);
                lblInvType.Text = it.Name;
                lblInvDate.Text = rctInvoice.DateOfEntry.ToShortDateString();

                mode.LoadByPrimaryKey(rctInvoice.ActivityID);
              
                lblWayBillNo.Text = rctInvoice.WayBillNo;

                txtTransitTransferVoucherNo.Text = rctInvoice.TransitTransferNo;
                txtEditTransferNo.Text = rctInvoice.TransitTransferNo;

                lblInsurancePolicyNo.Text = rctInvoice.InsurancePolicyNo;
                BLL.PO order = new PO();
                order.LoadByPrimaryKey(rctInvoice.POID);
                lblRefNo.Text = order.RefNo;
                lblPoNo.Text = order.PONumber;

                DataTable relatedReceives = rctInvoice.GetRelatedReceives();

                hasPreviousReceive = false;
              
                if (relatedReceives.Rows.Count > 0)
                {
                    XtraMessageBox.Show(
                        "The Invoice you have selected has previous associated receives",
                        "Invoice Detail", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        colSelectedManufactuerer.Visible = true;
                        colSelectedUnit.Visible = true;
                        colSelectionLineNo.Visible = true;
                        colSelectedReceiveQty.Visible = true;
                        colSelectedInvoiceQty.Visible = true;
                        hasPreviousReceive = true;
                        gridItemsChoice.Enabled = false;
                        colRemainingQty.VisibleIndex = 9;
                        lcItemChoiceGrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        _dtSelectedTable = relatedReceives.Clone();
                        gridSelected.DataSource = _dtSelectedTable;

                        foreach (DataRow dr in relatedReceives.Rows)
                        {
                            SelectAnItem(dr);
                        }
                }
                else
                {
                    hasPreviousReceive = false;
                    colSelectedManufactuerer.Visible = false;
                    colSelectedUnit.Visible = false;
                    colSelectionLineNo.Visible = false;
                    colSelectedReceiveQty.Visible = false;
                    colSelectedInvoiceQty.Visible = false;
                    colRemainingQty.Visible = false;
                    gridItemsChoice.Enabled = true;
                    lcItemChoiceGrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }

                if (lkAccounts.EditValue != null)
                {
                  //  lcInvoiceDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }

                if (standardRecType == StandardReceiptType.iGRVOnline || standardRecType == StandardReceiptType.GRV || deliveryNoteType == DeliveryNoteType.Automatic)
                {
                    if (!hasPreviousReceive) LoadItemsFromTransferredReceiptInvoiceDetail(rctInvoice.ID);
                    txtRefNo.Text = lkReceiptInvoice.Text;
                    colSelectedReceiveQty.Visible = true;
                    lcItemChoiceGrid.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lkAccounts.Enabled = false;
                }
                else
                {
                    lkAccounts.Enabled = !BLL.Settings.IsCenter;
                }

                if(!BLL.Settings.IsCenter)
                {  //Passcode Textbox
                    var dataRowView = lkReceiptInvoice.GetSelectedDataRow() as DataRowView;
                    if (dataRowView != null)
                        _isElectronic = Convert.ToBoolean(dataRowView["IsElectronic"]);

                    lcPassCode.Visibility = (!_isNonElectronicReceiveOnly) && (_isElectronic) && (standardRecType == StandardReceiptType.iGRVOnline || deliveryNoteType == DeliveryNoteType.Automatic)
                                            ? LayoutVisibility.Always
                                            : LayoutVisibility.Never;
                    txtPassCode.Text = "HHMM";
                }

            }
        }

        private void btnPlusMinusSub_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == "Split")
            {
                DataRow dr = grdViewShortageOrDamaged.GetFocusedDataRow();
                var dataView = ((DataTable)grdShortageOrDamaged.DataSource);
                dataView.ImportRow(dr);
            }
            else
            {
                DataRow dr = grdViewShortageOrDamaged.GetFocusedDataRow();
                var dataView = ((DataTable)grdShortageOrDamaged.DataSource);

                //DataRow newRow = dtRecGrid.NewRow();
                dataView.Rows.Remove(dr);

                //dtRecGrid.ImportRow(dr);
                //dtRecGrid.DefaultView.Sort = "Ordering, Stock Code";
            }
        }

        private void chkSRMForOldSystemIssues_CheckedChanged(object sender, EventArgs e)
        {
            OldSystemSRM(chkSRMForOldSystemIssues.Checked);
            if (chkSRMForOldSystemIssues.Checked)
            {
                lkForFacility.Properties.DataSource = BLL.Institution.GetAllReceivingUnits().DefaultView;
            }

        }

        private void OldSystemSRM(bool isEnabled)
        {
            txtSTVInvoiceNoOldSystem.Enabled = isEnabled;
            lkForFacility.Enabled = isEnabled;
            lkRegion.Enabled = !isEnabled;
            lkZone.Enabled = !isEnabled;
            lkWoreda.Enabled = !isEnabled;
            lkType.Enabled = !isEnabled;
            lkOwnership.Enabled = !isEnabled;
            lkSTVInvoiceNo.Enabled = !isEnabled;
            lkCategories.Enabled = txtItemName.Enabled = isEnabled;
            gridItemsChoice.Enabled = isEnabled;
            lcItemChoiceGrid.Visibility = isEnabled ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            colQtyIssued.Visible = !isEnabled;
            colSelectManufacturer.OptionsColumn.AllowEdit = colUnits.OptionsColumn.AllowEdit = colPricePerPack.OptionsColumn.AllowEdit = colPacks.OptionsColumn.AllowEdit = colBatchNo.OptionsColumn.AllowEdit = colExpiryDate.OptionsColumn.AllowEdit = isEnabled;
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {
            // reset the locations that were already selected
            if (_dtPutAwayNonPalletized != null)
            {
                foreach (DataRow dr in _dtPutAwayNonPalletized.Rows)
                {
                    dr["PutAwayLocation"] = null;
                    dr["Palletized Quantity"] = DBNull.Value;
                }
            }

            if (_dtPutAwayPalletized != null)
            {
                foreach (DataRow dr in _dtPutAwayPalletized.Rows)
                {
                    dr["PutAwayLocation"] = null;
                }
            }
        }

        private void lkReceiptInvoice_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //// Ask for confirmation here. 
            //if (XtraMessageBox.Show("Changing the Selected Invoice will reset the form. Are you sure you would like to continue?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            //{
            //    e.Cancel = true;
            //}
        }

        private void cboReceiveType_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

            if (cboReceiveType.EditValue != null && XtraMessageBox.Show("Are you sure you want to change the receive type? this will reset the form and will require you to start over.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                ResetFields();
                lkReceiptInvoice.EditValue = null;
            }
        }

        private void cboReceiveType_EditValueChanged(object sender, EventArgs e)
        {
            layoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always; 
            HandleReceiptTypeChange();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="useManualReceiveForHub">Used only for hub.  Make true if the user declines to use auto receive (eReceive) </param>
        private void HandleReceiptTypeChange(bool useManualReceiveForHub = false)
        {
            if (cboReceiveType.EditValue == null) return;
            _receiptTypeID = Convert.ToInt32(cboReceiveType.EditValue);

            // On all the Receive Modes, Remove the unit column on the selection except the SRM.
            
            colSelectedBatchNo.Visible = false;
            colSelectedExpiry.Visible = false;
            colSelectedManufactuerer.Visible = false;
            colSelectedQuantityIssued.Visible = false;
            colSelectedUnit.Visible = false;
            colSelectionLineNo.Visible = false;
            hasPreviousReceive = false;
            lcReceiptInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

            // Generally show the receipt invoice only for the center implementation
            if (BLL.Settings.IsCenter)
            {
                lcRefNoInput.Visibility = LayoutVisibility.Never;
                lcReceiptInvoice.Visibility = LayoutVisibility.Always;
            }
            else
            {
                lcRefNoInput.Visibility = LayoutVisibility.Always;
                //lcReceiptInvoice.Visibility = LayoutVisibility.Never;
            }
            if (_receiptTypeID == ReceiptType.CONSTANTS.STANDARD_RECEIPT || _receiptTypeID == ReceiptType.CONSTANTS.LOCAL_PURCHASE)
            {
                layoutControlGroup8.Visibility = LayoutVisibility.Never;
                lcPassCode.Visibility = LayoutVisibility.Always;

                lcReceiptInvoice.Visibility = LayoutVisibility.Always;

                layoutControlItem47.Visibility = LayoutVisibility.Never;
                deliveryNoteType = DeliveryNoteType.NotSet;
                beginningBalance = false;
                srm = false;

                standardRecType = useManualReceiveForHub ? StandardReceiptType.iGRV : StandardReceiptType.iGRVOnline;

                if (standardRecType == StandardReceiptType.iGRVOnline)
                {
                    //Similar code to the SRM
                    //make the two columns visible.
                    //colSelectedUnit.Visible = true;
                    colSelectionLineNo.VisibleIndex = 0;
                    colSelectedUnit.VisibleIndex = 3;
                    colSelectedManufactuerer.VisibleIndex = 4;
                    colSelectedBatchNo.VisibleIndex = 5;
                    colSelectedExpiry.VisibleIndex = 6;
                    colSelectedQuantityIssued.Visible = false;

                    lcRefNoInput.Visibility = LayoutVisibility.Never;
                    lcReceiptInvoice.Visibility = LayoutVisibility.Always;
                    if (BLL.Settings.IsCenter)
                    {
                        lkReceiptInvoice.Properties.DataSource =
                            BLL.ReceiptInvoice.GetIncompleteInvoicesForCenter(CurrentContext.UserId, false);

                    }
                    else
                    {
                        if (_receiptTypeID == ReceiptType.CONSTANTS.STANDARD_RECEIPT)
                        {
                            lkReceiptInvoice.Properties.DataSource =
                                BLL.ReceiptInvoice.GetIncompleteInvoices(CurrentContext.UserId, POType.E_PURCHASE_ORDER,
                                    DocumentType.CONSTANTS.STV);
                        }
                        else if (_receiptTypeID == ReceiptType.CONSTANTS.LOCAL_PURCHASE)
                        {
                            lkReceiptInvoice.Properties.DataSource =
                                BLL.ReceiptInvoice.GetIncompleteInvoices(CurrentContext.UserId, POType.DIRECT_VENDOR_TRANSFER,
                                    DocumentType.CONSTANTS.STV);
                        }
                    }
                }
            }
            else if (_receiptTypeID == ReceiptType.CONSTANTS.DELIVERY_NOTE || _receiptTypeID == ReceiptType.CONSTANTS.MANUAL_DELIVERY_NOTE)
            {
                layoutControlItem47.Visibility = LayoutVisibility.Never;
                layoutControlGroup8.Visibility = LayoutVisibility.Never;
                lcPassCode.Visibility = LayoutVisibility.Always;

                lcReceiptInvoice.Visibility = LayoutVisibility.Always;

                beginningBalance = false;
                srm = false;
                standardRecType = StandardReceiptType.NotSet;


                deliveryNoteType = useManualReceiveForHub ? DeliveryNoteType.Manual : DeliveryNoteType.Automatic;

                if (deliveryNoteType == DeliveryNoteType.Automatic)
                {
                    colSelectionLineNo.VisibleIndex = 0;
                    colSelectedUnit.VisibleIndex = 3;
                    colSelectedManufactuerer.VisibleIndex = 4;
                    colSelectedBatchNo.VisibleIndex = 5;
                    colSelectedExpiry.VisibleIndex = 6;
                    colSelectedQuantityIssued.Visible = false;

                    //Populate LookUps
                    lcRefNoInput.Visibility = LayoutVisibility.Never;
                    lcReceiptInvoice.Visibility = LayoutVisibility.Always;
                    if (BLL.Settings.IsCenter)
                    {
                        lkReceiptInvoice.Properties.DataSource =
                            BLL.ReceiptInvoice.GetIncompleteInvoicesForCenter(CurrentContext.UserId, true);
                    }else
                    {
                        if (_receiptTypeID == ReceiptType.CONSTANTS.DELIVERY_NOTE)
                        {
                            lkReceiptInvoice.Properties.DataSource =
                                BLL.ReceiptInvoice.GetIncompleteInvoices(CurrentContext.UserId, POType.E_PURCHASE_ORDER,
                                    DocumentType.CONSTANTS.DLVN);
                        }
                        else if (_receiptTypeID == ReceiptType.CONSTANTS.MANUAL_DELIVERY_NOTE)
                        {
                            lkReceiptInvoice.Properties.DataSource =
                                BLL.ReceiptInvoice.GetIncompleteInvoices(CurrentContext.UserId, POType.MANUAL_DELIVERYNOTE,
                                    DocumentType.CONSTANTS.DLVN);
                        }
                    }
                }

            }
            else if (_receiptTypeID == ReceiptType.CONSTANTS.STOCK_RETURN)
            {
                
                deliveryNoteType = DeliveryNoteType.NotSet;
                beginningBalance = false;
                srm = true;
                layoutControlItem47.Visibility = LayoutVisibility.Always;
                lcReceiptInvoice.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                standardRecType = StandardReceiptType.NotSet;
                layoutControlGroup8.Visibility = LayoutVisibility.Always;
                lcPassCode.Visibility = LayoutVisibility.Never;
                lkRegion.Enabled = false;
                lcReceiptInvoice.Visibility = LayoutVisibility.Never;
                //make the two columns visible.
                //colSelectedUnit.Visible = true;
                txtPassCode.Visible = false;
                colSelectionLineNo.VisibleIndex = 0;
                colSelectedUnit.VisibleIndex = 3;
                colSelectedManufactuerer.VisibleIndex = 4;
                colSelectedBatchNo.VisibleIndex = 5;
                colSelectedExpiry.VisibleIndex = 6;

                colQtyIssued.VisibleIndex = 8;
                colSelectedQuantityIssued.VisibleIndex = 7;
                colDamaged.VisibleIndex = 9;

            }

            if (deliveryNoteType != DeliveryNoteType.NotSet)
            {
                lcRefNoInput.CustomizationFormText = "Delivery Note No";
                lcRefNoInput.Text = "Delivery Note No";
                txtRefNo.Text = "";
                lcRefNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                lcRefNoInput.CustomizationFormText = "STV/Invoice";
                lcRefNoInput.Text = "STV/Invoice";
                txtRefNo.Text = "";
            }

            if (lcReceiptInvoice.Visibility == DevExpress.XtraLayout.Utils.LayoutVisibility.Never || Convert.ToInt32(lkReceiptInvoice.EditValue).Equals(-1)) //If it equals -1, this means the receipt invoice hasn't been found.
            {
                if (srm || beginningBalance || standardRecType == StandardReceiptType.iGRVOnline || deliveryNoteType == DeliveryNoteType.Automatic)
                {
                    lcRefNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    lcRefNo.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
            }

            //
            //lcSRM.Visibility = srm
            //                       ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            //                       : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            lkCategories.Enabled = txtItemName.Enabled = !(srm || (standardRecType == StandardReceiptType.iGRVOnline) || (deliveryNoteType == DeliveryNoteType.Automatic));
            gridItemsChoice.Enabled = !(srm || (standardRecType == StandardReceiptType.iGRVOnline) || (deliveryNoteType == DeliveryNoteType.Automatic));

            lcItemChoiceGrid.Visibility = (srm || (standardRecType == StandardReceiptType.iGRVOnline) || (deliveryNoteType == DeliveryNoteType.Automatic))
                                              ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                                              : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            colQtyIssued.Visible = srm;
            colRemainingQty.Visible = hasPreviousReceive;
            //colPlusMinus.Visible = colStockCode.Visible = !srm;
            colSelectManufacturer.OptionsColumn.AllowEdit =
                colUnits.OptionsColumn.AllowEdit =
                colPricePerPack.OptionsColumn.AllowEdit =
                colPacks.OptionsColumn.AllowEdit = !(srm || (standardRecType == StandardReceiptType.iGRVOnline) || (deliveryNoteType == DeliveryNoteType.Automatic));
            colInvoicedQty.OptionsColumn.AllowEdit = (standardRecType != StandardReceiptType.iGRVOnline) && (deliveryNoteType != DeliveryNoteType.Automatic);
            colBatchNo.OptionsColumn.AllowEdit = colExpiryDate.OptionsColumn.AllowEdit = !srm;
            colInvoicedQty.Visible = beginningBalance ? false : (srm ? false : true);
            ////lcSTVNo.Visibility = beginningBalance ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never : DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
           
            //lcInvoiceDetail.Visibility = standardRecType == StandardReceiptType.NotSet || deliveryNoteType == DeliveryNoteType.NotSet
            //                                 ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            //                                 : (lkReceiptInvoice.EditValue == null
            //                                        ? DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            //                                        : DevExpress.XtraLayout.Utils.LayoutVisibility.Always);
            //Load IsElectronicReceiveOnly Setting
            LoadIsPOElectronicSetting();

            colNotReceived.Visible = !srm && (!beginningBalance);

            lkReceiptInvoice.Enabled = srm ? false : ((deliveryNoteType != DeliveryNoteType.NotSet) ? true : (beginningBalance ? false : true));

            lkAccounts.Enabled = srm
                                     ? true
                                     : ((deliveryNoteType != DeliveryNoteType.NotSet)
                                            ? true
                                            : (beginningBalance ? true : (!BLL.Settings.IsCenter ? true : false)));

           


            if (srm)
            {
                colQtyReceived.Caption = "Returned Qty";
                colDamaged.Visible = true;
            }
            else if (beginningBalance)
            {
                colQtyReceived.Caption = "Physical Count";
                colDamaged.Visible = true;
            }
            else
            {
                colQtyReceived.Caption = "Received Qty";
                colDamaged.Visible = false;
            }

            if (BLL.Settings.HandleDeliveryNotes)
            {
                //lcDeliveryNoteCheck.Visibility = !srm ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                if ((deliveryNoteType != DeliveryNoteType.NotSet) && srm)
                {
                    deliveryNoteType = DeliveryNoteType.NotSet;
                }
            }
        }

        private void btnTransferredSTV_Click(object sender, EventArgs e)
        {
            DocumentTransferReceipt transferReceipt = new DocumentTransferReceipt();
            transferReceipt.ShowDialog();
        }

        private void cboReceiveType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void repositoryItemButtonEditPutAwaySplit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow focuseddr = gridPutAwayNonPalletizedView.GetFocusedDataRow();
            DataRow newdr = focuseddr.Table.NewRow();
            newdr.ItemArray = focuseddr.ItemArray;
            var guid = focuseddr["GUID"].ToString();
            var dataView = ((DataTable)gridPutAwayNonPalletized.DataSource);

            if (e.Button.Caption == "Split")
            {
                var newGuid = CreateReplicaOndtRecGrid(guid);//Then create a replica from Orginal Item and return new guid.
                newdr["GUID"] = newGuid;
                //Reset Palletized Quantities
                focuseddr["Palletized Quantity"] = newdr["Palletized Quantity"] = DBNull.Value;
                dataView.Rows.Add(newdr);
                dataView.DefaultView.Sort = "ID, Index, Item Name, Expiry Date, Batch No ASC";
            }
            else
            {
                _dtRecGrid.Rows.Remove(_dtRecGrid.Select(String.Format(" GUID = '{0}'", guid))[0]);
                dataView.Rows.Remove(focuseddr);
            }

        }

        private string CreateReplicaOndtRecGrid(string guid)
        {
            DataRow dr = _dtRecGrid.Select(String.Format(" GUID = '{0}'", guid))[0];
            DataRow drNew = _dtRecGrid.NewRow();
            drNew.ItemArray = dr.ItemArray;
            if (dr["Copy"] == DBNull.Value || Convert.ToString(dr["Copy"]) == "Orginal")
            {
                dr["Copy"] = "Orginal";
                drNew["Copy"] = dr["GUID"];
            }
            else { drNew["Copy"] = dr["Copy"]; }

            drNew["GUID"] = Guid.NewGuid();
            drNew["Pack Qty"] = DBNull.Value;
            _dtRecGrid.Rows.Add(drNew);
            _dtRecGrid.DefaultView.Sort = "Ordering, Stock Code";
            return drNew["GUID"].ToString();
        }


        private void gridPutAwayNonPalletizedView_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column != colReceivedQuantity) return;
            var itemName1 = gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle1, colItemName4).ToString();
            var itemName2 = gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle2, colItemName4).ToString();
            var unit1 = Convert.ToInt16(gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle1, colUnit4));
            var unit2 = Convert.ToInt16(gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle2, colUnit4));
            var manufacturer1 = Convert.ToInt16(gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle1, colManufacturer4));
            var manufacturer2 = Convert.ToInt16(gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle2, colManufacturer4));
            var batchNo1 = gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle1, colBatchNo4).ToString();
            var batchNo2 = gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle2, colBatchNo4).ToString();
            var expDate1 = gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle1, colExpiry2).ToString();
            var expDate2 = gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle2, colExpiry2).ToString();
            var recQty1 =
                Convert.ToDecimal(gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle1, colReceivedQuantity));
            var recQty2 =
                Convert.ToDecimal(gridPutAwayNonPalletizedView.GetRowCellValue(e.RowHandle2, colReceivedQuantity));

            e.Merge = itemName1.Equals(itemName2) &&
                      unit1 == unit2 &&
                      manufacturer1 == manufacturer2 &&
                      batchNo1.Equals(batchNo2) &&
                      expDate1.Equals(expDate2) &&
                      recQty1 == recQty2;
            e.Handled = true;
        }

        #region Translation to ViewModel

        private IList<ReceiveInvoiceViewModel> ToReceiveInvoiceViewModels(DataView dataView)
        {
            var dataTable = dataView.ToTable();
            var receiveInvoicesViewModels = dataTable.AsEnumerable().Select(invoice => new ReceiveInvoiceViewModel
            {
                ID = (Int32)(invoice["ID"]),
                InvoiceTypeID = (Int32)(invoice["InvoiceTypeID"]),
                STVOrInvoiceNo = (string)(invoice["STVOrInvoiceNo"]),
                DateOfEntry = (DateTime)(invoice["DateOfEntry"]),
                TotalValue = (double)(invoice["TotalValue"]),
                PrintedDate = (DateTime)(invoice["PrintedDate"]),
                ActivityName = (string)(invoice["ActivityName"]),
                AccountName = (string)(invoice["AccountName"]),
                SubAccountName = (string)(invoice["SubAccountName"]),
                Mode = (string)(invoice["Mode"]),
                PONo = (string)(invoice["PONo"]),
                SupplierName = (string)(invoice["SupplierName"]),
                Shipper = (string)(invoice)["Shipper"],
                PrintedDateString = ((DateTime)(invoice["PrintedDate"])).TimeAgo()
            }).ToList();

            return receiveInvoicesViewModels;
        }
        #endregion

        private void RepairInvoicedQuantitiesBasedOnDamaged()
        {
            var grdShortageDt = grdShortageOrDamaged.DataSource as DataTable;
            if (grdShortageDt != null)
                foreach (DataRow dr in grdShortageDt.Rows.Cast<DataRow>().Where(dr => Convert.ToBoolean(dr["IsDamaged"]) && (dr["ShortageReasonID"] != DBNull.Value
                                                                                                                             &&
                                                                                                                             Convert.ToInt32(dr["ShortageReasonID"]) ==
                                                                                                                             ShortageReasons.Constants.DAMAGED)))
                {
                    //~ Repair InvoicedQuantity ~//
                    dr["InvoicedQty"] = dr["Pack Qty"];

                    DataRow soundItem = _dtRecGrid.Select(string.Format("GUID = '{0}'", dr["GUID"]))[0];
                    soundItem["InvoicedQty"] = soundItem["Pack Qty"];
                }
        }
        private void ReverseInvoicedQuantitiesBasedOnDamaged()
        {
            var grdShortageDt = grdShortageOrDamaged.DataSource as DataTable;
            if (grdShortageDt != null)
                foreach (
                    DataRow dr in
                        grdShortageDt.Rows.Cast<DataRow>()
                            .Where(dr => Convert.ToBoolean(dr["IsDamaged"]) && (dr["ShortageReasonID"] != DBNull.Value))
                    )
                {
                    if (    //~ Just wrong Code : in the above code a repair code is applied if there is one damaged found ~//
                        !grdShortageDt.Select(string.Format("[ShortageReasonID] = {0} ",
                            BLL.ShortageReasons.Constants.DAMAGED)).Any()) return;

                    //~ Reverse InvoicedQuantity ~//
                    if ((Convert.ToDecimal(dr["BU Qty"]) == 0) && (dr["ShortageReasonID"] != DBNull.Value) && (Convert.ToInt32(dr["ShortageReasonID"]) == ShortageReasons.Constants.NOT_RECEIVED)) continue; // This is a full notReceivedEntry

                    //decimal realInvoicedQty = Convert.ToDecimal(dr["Pack Qty"]);
                    DataRow soundItem = _dtRecGrid.Select(string.Format("GUID = '{0}'", dr["GUID"]))[0];
                    soundItem["InvoicedQty"] = Convert.ToDecimal(soundItem["OriginalInvoicedQty"]);
                }
        }
        private void LoadIsPOElectronicSetting()
        {
            var softwareSetting = new SoftwareSettings();
            var settingDT = softwareSetting.GetValue("IsElectronicReceiveOnly");
            if (settingDT.Rows.Count != 0)
            {
                _isNonElectronicReceiveOnly = bool.Parse(settingDT.Rows[0].Field<string>("Value").ToLower());
            }
        }

        private void gridRecieveView_CellMerge(object sender, CellMergeEventArgs e)
        {
            if (e.Column.FieldName == "StockCode" || e.Column.FieldName == "Item Name" || e.Column.FieldName == "UnitID" || e.Column.FieldName == "Manufacturer" || e.Column.FieldName == "NotReceived" || e.Column.FieldName == "InvoicedQty" )
            {
                var dr1 = (sender as GridView).GetDataRow(e.RowHandle1);
                var dr2 = (sender as GridView).GetDataRow(e.RowHandle2);
                e.Merge = dr1["Item Name"].ToString() == dr2["Item Name"].ToString() && dr1["UnitID"].ToString() == dr2["UnitID"].ToString()
                              && dr1["Manufacturer"].ToString() == dr2["Manufacturer"].ToString() && dr1["CopyGUID"].ToString() == dr2["CopyGUID"].ToString();

                e.Handled = true;

            }
        }

        private void gridLookUpEdit1View_RowStyle(object sender, RowStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool isElectronic = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle,"IsElectronic"));
                bool active = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "Active"));
                if (isElectronic)
                {
                    e.Appearance.BackColor = Color.LightBlue;
                }
                if (!active)
                {
                    e.Appearance.BackColor = Color.DarkGray;
                   
                    e.Appearance.Font = new Font(view.Appearance.Row.Font,FontStyle.Italic);
                    e.Appearance.ForeColor = Color.White;
                }
                
            }
        }


        private void ShowTooltip(string text)
        {
            var toolTipControlInfo = new ToolTipControlInfo
            {
                Object = MousePosition,
                ImmediateToolTip = true,
                Text = text
            };
            toolTip.ShowHint(toolTipControlInfo);
            
        }

        private void lblInsurancePolicyNo_MouseEnter(object sender, EventArgs e)
        {
            if (lkReceiptInvoice.EditValue != null)
            {
                var receiptInvoice = new ReceiptInvoice();
                receiptInvoice.LoadByPrimaryKey((int)lkReceiptInvoice.EditValue);
                ShowTooltip(receiptInvoice.PrintedDate.ToString());
            }
        }

        private void lblWaybill_MouseEnter(object sender, EventArgs e)
        {
            if (lkReceiptInvoice.EditValue != null)
            {
                var receiptInvoice = new ReceiptInvoice();
                receiptInvoice.LoadByPrimaryKey((int)lkReceiptInvoice.EditValue);
                ShowTooltip(receiptInvoice.PrintedDate.ToString());
            }
        }

        private void lblInsurancePolicyNo_MouseLeave(object sender, EventArgs e)
        {
            toolTip.HideHint();
        }

        private void lblWaybill_MouseLeave(object sender, EventArgs e)
        {
            toolTip.HideHint();
        }

        private void txtPassCode_Click(object sender, EventArgs e)
        {
            if (txtPassCode.Text == "HHMM")
            {
                txtPassCode.Text = string.Empty;
            }
        }

        private void gridLookUpEdit1View_MouseDown(object sender, MouseEventArgs e)
        {
            GridView gridView = sender as GridView;
            GridHitInfo hitInfo = gridView.CalcHitInfo(e.Location);
            if (hitInfo.InRow && hitInfo.RowHandle >= 0)
            {
                bool active = Convert.ToBoolean(gridView.GetRowCellValue(hitInfo.RowHandle, "Active"));
                if (!active)
                {
                    ((DevExpress.Utils.DXMouseEventArgs) (e)).Handled = true;
                }
            }

        }

        private void PalletizedGrid_Click(object sender, EventArgs e)
        {

        }

        private void gridPutAwayNonPalletized_Click(object sender, EventArgs e)
        {

        }

        private void lblInvDate_Click(object sender, EventArgs e)
        {

        }

        private void lblPOType_Click(object sender, EventArgs e)
        {

        }

        }
    }
