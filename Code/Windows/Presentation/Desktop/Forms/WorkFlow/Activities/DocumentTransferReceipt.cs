using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraLayout.Utils;
using HCMIS.DocumentExchange.Documents;
using HCMIS.DocumentExchange.Documents.XmlMappings;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    public partial class DocumentTransferReceipt : Form
    {
        public DocumentTransferReceipt()
        {
            InitializeComponent();
        }

        private BLL.Receipt receipt = new BLL.Receipt();
        private BLL.ReceiveDoc receiveDoc = new ReceiveDoc();
        private int STVNo;
        private BLL.ReceiveDocShortage receiveDocShortage = new ReceiveDocShortage();

        private void DocumentTransferReceipt_Load(object sender, EventArgs e)
        {
            grdLocations.DataSource = PalletLocation.GetAllFree(StorageType.BulkStore);
            grdDamagedLocations.DataSource = PalletLocation.GetQuaranteen(CurrentContext.UserId);
            repoLKReason.DataSource = ShortageReasons.GetAllReasons();

            LoadTransferredSTVs();

            DataView PossibleWarehouses = BLL.Warehouse.GetWarehouseWithCluster(CurrentContext.UserId);
            lkWarehouse.Properties.DataSource = PossibleWarehouses;
            if (PossibleWarehouses.Count > 0)
            {
                lkWarehouse.EditValue = ((DataView)lkWarehouse.Properties.DataSource)[0]["ID"];
            }
        }

        private void LoadTransferredSTVs()
        {
            BLL.Document documents = new BLL.Document();
            documents.LoadSTVsNotYetReceived();
            documents.AddColumn("PrintedDate", typeof(DateTime));
            documents.AddColumn("Sender", typeof(string));
            documents.AddColumn("Account", typeof(string));
            documents.AddColumn("DocumentNumber", typeof(string));

            while (!documents.EOF)
            {
                HCMIS.DocumentExchange.Documents.XmlMappings.STV stv = STV.Load(documents.DocumentContent);
                documents.SetColumn("PrintedDate", stv.PrintedDate);
                documents.SetColumn("Sender", stv.Sender);
                documents.SetColumn("Account", stv.Account);
                documents.SetColumn("DocumentNumber", stv.DocumentNumber);
                documents.MoveNext();
            }
            grdReceivedSTVs.DataSource = documents.DefaultView;
        }

        private void grdViewReceivedSTVs_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadSTVDetails();
        }



        private void LoadSTVDetails()
        {
            int documentID = Convert.ToInt32(grdViewReceivedSTVs.GetFocusedDataRow()["DocumentID"]);
            BLL.Document document = new Document();
            document.LoadByPrimaryKey(documentID);
            DocumentExchange.Documents.XmlMappings.STV stv =
                DocumentExchange.Documents.XmlMappings.STV.Load(document.DocumentContent);

            //Clean up the receivedoc entry
            receiveDoc.FlushData();
            STVNo = Convert.ToInt32(stv.DocumentNumber);

            lblDaysAgo.Text = string.Format("Printed: {0}", Helpers.DateTimeFunctions.GetDateSpan(stv.PrintedDate));
            for (int i = 0; i < stv.DocumentDetails.Count; i++)
            {
                STVDetail detail = stv.DocumentDetails[i];
                receiveDoc.AddNew();

                //Add columns for display purposes and for storing temporary information
                if (!receiveDoc.DefaultView.ToTable().Columns.Contains("FullItemName"))
                {
                    receiveDoc.AddColumn("FullItemName", typeof(string));
                    receiveDoc.AddColumn("UnitName", typeof(string));
                    receiveDoc.AddColumn("ManufacturerName", typeof(string));
                    receiveDoc.AddColumn("ActivityName", typeof(string));
                    receiveDoc.AddColumn("StockCode", typeof(string));
                    receiveDoc.AddColumn("PalletLocationID", typeof(int));
                    receiveDoc.AddColumn("GUID", typeof(string));
                }

                //Fill in the data
                receiveDoc.ItemID = detail.ItemID;
                receiveDoc.UnitID = detail.UnitID;
                receiveDoc.StoreID = detail.ActivityID;
                receiveDoc.ManufacturerId = detail.ManufacturerID;
                receiveDoc.SetColumn("BatchNo", detail.BatchNumber);
                receiveDoc.SetColumn("ExpDate", detail.ExpiryDate);
                receiveDoc.SetColumn("GUID", Guid.NewGuid());

                BLL.Item item = new Item();
                item.LoadByPrimaryKey(detail.ItemID);
                receiveDoc.SetColumn("FullItemName", item.FullItemName);

                BLL.ItemUnit unit = new ItemUnit();
                unit.LoadByPrimaryKey(detail.UnitID);
                receiveDoc.SetColumn("UnitName", unit.Text);
                receiveDoc.QtyPerPack = unit.QtyPerUnit;

                BLL.Manufacturer manufacturer = new Manufacturer();
                manufacturer.LoadByPrimaryKey(detail.ManufacturerID);
                receiveDoc.SetColumn("ManufacturerName", manufacturer.Name);
                var activity = new Activity();
                activity.LoadByPrimaryKey(detail.ActivityID);
                receiveDoc.SetColumn("ActivityName", activity.FullActivityName);

                receiveDoc.SetColumn("StockCode", item.StockCode);

                //Financial Info
                receiveDoc.InvoicedNoOfPack = detail.Quantity;
                receiveDoc.Margin = detail.Margin;
                receiveDoc.PricePerPack = detail.UnitPrice;
            }

            grdSTVDetails.DataSource = receiveDoc.DefaultView;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int warehouseID = Convert.ToInt32(lkWarehouse.EditValue);

            receiveDoc.Rewind();
            var po = new BLL.PO();
            var receiptInvoice = new BLL.ReceiptInvoice();

            while (!receiveDoc.EOF)
            {
                //Handle the PO.
                //int receiptID;
                if (po.RowCount == 0 || po.StoreID != receiveDoc.StoreID)
                {
                    Supplier supplier = new Supplier();
                    po = BLL.PO.CreatePOforStandard(OrderType.CONSTANTS.STANDARD_ORDER, receiveDoc.StoreID,
                                                    supplier.GetHubHomeOfficeSupplierID(), "",CurrentContext.LoggedInUser.ID);
                    //Should we receive it as hub to hub transfer? We're now using Standard order.
                    receipt = BLL.ReceiptInvoice.CreateAutomaticReceiptInvoiceForSTVTransfer(po.ID, warehouseID, STVNo,
                                                                                             CurrentContext.UserId);
                }

                receiveDoc.Quantity = receiveDoc.QtyPerPack * receiveDoc.NoOfPack;
                receiveDoc.ReceiptID = receipt.ID;
                receiveDoc.MoveNext();
            }
            receiveDoc.Save();

            //Save the location
            receiveDoc.Rewind();

            BLL.ReceivePallet receivePallet = new ReceivePallet();
            while (!receiveDoc.EOF)
            {
                //Save Location Information
                BLL.PalletLocation palletLocation = new PalletLocation();

                receivePallet.AddNew();

                int palletLocationID = Convert.ToInt32(receiveDoc.GetColumn("PalletLocationID"));
                receivePallet.PalletLocationID = palletLocationID;

                palletLocation.LoadByPrimaryKey(palletLocationID);

                receivePallet.PalletID = palletLocation.PalletID;
                receivePallet.ReceivedQuantity = receiveDoc.Quantity;
                receivePallet.Balance = receiveDoc.Quantity;
                receivePallet.ReceiveID = receiveDoc.ID;
                receivePallet.ReservedStock = 0;


                //Save Discrepancy information if there is any
                receiveDocShortage.Rewind();
                while (receiveDocShortage.FindNextByGUID(receiveDoc.GetColumn("GUID").ToString()))
                {
                    receiveDocShortage.ReceiveDocID = receiveDoc.ID;

                    if (receiveDocShortage.ShortageReasonID == ShortageReasons.Constants.DAMAGED)
                    {
                        receiveDoc.NoOfPack += receiveDocShortage.NoOfPacks;
                        receiveDoc.Quantity += receiveDocShortage.NoOfPacks*receiveDoc.QtyPerPack;
                        
                        palletLocationID = Convert.ToInt32(receiveDocShortage.GetColumn("PalletLocationID"));
                        receivePallet.AddNew();
                        receivePallet.PalletLocationID = palletLocationID;
                        palletLocation.LoadByPrimaryKey(palletLocationID);

                        receivePallet.PalletID = palletLocation.PalletID;
                        receivePallet.ReceivedQuantity = receiveDocShortage.NoOfPacks*receiveDoc.QtyPerPack;
                        receivePallet.Balance = receiveDocShortage.NoOfPacks*receiveDoc.QtyPerPack;
                        receivePallet.ReceiveID = receiveDoc.ID;
                        receivePallet.ReservedStock = 0;
                    }
                }

                receiveDoc.MoveNext();
            }
            receivePallet.IsOriginalReceive = true;
            receivePallet.Save();
        }

        private void lkWarehouse_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void grdViewSTVDetails_ShownEditor(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            if (view.FocusedColumn.FieldName != "PalletLocationID")
            {
                return;
            }

            var lke = (GridLookUpEdit)view.ActiveEditor;

            var selectedRow = view.GetFocusedDataRow();
            var itemID = Convert.ToInt32(selectedRow["ItemID"]);
            var warehouseID = Convert.ToInt32(lkWarehouse.EditValue);

            lke.Properties.DataSource =
                PalletLocation.GetAllFreeFor(itemID, 0, CurrentContext.UserId).AsEnumerable().Where(
                    l => Convert.ToInt32(l["WarehouseID"]) == warehouseID).CopyToDataTable();

        }

        private void grdViewSTVDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal invoicedQty;
            decimal receivedQty;
            decimal difference = 0;
            var row = grdViewSTVDetails.GetFocusedDataRow();
            string guid = row["GUID"].ToString();

            receiveDoc.FindByGUID(guid);

            if (!receiveDoc.IsColumnNull("InvoicedNoOfPack"))
            {
                invoicedQty = receiveDoc.InvoicedNoOfPack;
                receivedQty = receiveDoc.NoOfPack;
                difference = invoicedQty - receivedQty;
            }

            if (difference > 0)
            {
                lcDiscrepancy.Visibility = LayoutVisibility.Always;
                bool notEntered = true;
                bool isNewRow = true;

                if (receiveDocShortage.RowCount > 0)
                {
                    var noOfDiscrepancyEntries = receiveDocShortage.CountByGUID(guid);

                    if (receiveDocShortage.FindFirstByGUID(guid))
                    {
                        notEntered = false;

                        for (int i = 0; i < noOfDiscrepancyEntries; i++)
                        {
                            receiveDocShortage.SetColumn("ManufacturerName", Manufacturer.GetName(receiveDoc.ManufacturerId));
                            receiveDocShortage.SetColumn("UnitName", ItemUnit.GetUnitText(receiveDoc.UnitID));
                            receiveDocShortage.SetColumn("BatchNo", receiveDoc.GetColumn("BatchNo"));
                            receiveDocShortage.SetColumn("ExpDate", receiveDoc.GetColumn("ExpDate"));
                            receiveDocShortage.SetColumn("FullItemName", receiveDoc.GetColumn("FullItemName"));
                            receiveDocShortage.SetColumn("StockCode", receiveDoc.GetColumn("StockCode"));
                            receiveDocShortage.SetColumn("GUID", receiveDoc.GetColumn("GUID"));
                            if (noOfDiscrepancyEntries > 1)
                            {
                                receiveDocShortage.SetColumnNull("NoOfPacks");
                            }
                            else
                            {
                                receiveDocShortage.NoOfPacks = difference;
                            }
                        }
                    }
                }

                if (receiveDocShortage.RowCount == 0 || notEntered)
                {
                    //Prepare the columns used for display

                }

                if (notEntered)
                {
                    receiveDocShortage.AddNew();

                    if (!receiveDocShortage.DefaultView.ToTable().Columns.Contains("FullItemName"))
                    {
                        receiveDocShortage.AddColumn("FullItemName", typeof(string));
                        receiveDocShortage.AddColumn("UnitName", typeof(string));
                        receiveDocShortage.AddColumn("ManufacturerName", typeof(string));
                        receiveDocShortage.AddColumn("StockCode", typeof(string));
                        receiveDocShortage.AddColumn("ExpDate", typeof(string));
                        receiveDocShortage.AddColumn("BatchNo", typeof(string));
                        receiveDocShortage.AddColumn("PalletLocationID", typeof(int));
                        receiveDocShortage.AddColumn("GUID", typeof(string));
                    }

                    receiveDocShortage.SetColumn("FullItemName", receiveDoc.GetColumn("FullItemName"));
                    receiveDocShortage.SetColumn("UnitName", receiveDoc.GetColumn("UnitName"));
                    receiveDocShortage.SetColumn("ManufacturerName", receiveDoc.GetColumn("ManufacturerName"));
                    receiveDocShortage.SetColumn("StockCode", receiveDoc.GetColumn("StockCode"));
                    receiveDocShortage.SetColumn("ExpDate", receiveDoc.GetColumn("ExpDate"));
                    receiveDocShortage.SetColumn("BatchNo", receiveDoc.GetColumn("BatchNo"));
                    receiveDocShortage.SetColumn("GUID", receiveDoc.GetColumn("GUID"));
                    receiveDocShortage.NoOfPacks = difference;
                }
            }

            else if (difference == 0 && receiveDocShortage.RowCount != 0)
            {
                RemoveFromDiscrepancy(guid);
            }

            if (receiveDocShortage.RowCount != 0)
                grdDiscrepancy.DataSource = receiveDocShortage.DefaultView;
            else
                lcDiscrepancy.Visibility = LayoutVisibility.Never;
        }


        private void RemoveFromDiscrepancy(string guid)
        {
            if (receiveDocShortage.RowCount > 0)
            {
                receiveDocShortage.Rewind();
                while (receiveDocShortage.FindNextByGUID(guid))
                {
                    receiveDocShortage.MarkAsDeleted();
                }
                grdDiscrepancy.DataSource = receiveDocShortage.DefaultView;
            }

            if (receiveDocShortage.RowCount == 0)
            {
                grdDiscrepancy.DataSource = null;
                lcDiscrepancy.Visibility = LayoutVisibility.Never;
            }
        }

        private void grdViewDiscrepancy_ShownEditor(object sender, EventArgs e)
        {
            var view = (GridView)sender;
            if (view.FocusedColumn.FieldName != "PalletLocationID")
            {
                return;
            }

            var lke = (GridLookUpEdit)view.ActiveEditor;

            var selectedRow = view.GetFocusedDataRow();
            var warehouseID = Convert.ToInt32(lkWarehouse.EditValue);
            var shortageReasonID = selectedRow["ShortageReasonID"];

            if (shortageReasonID == DBNull.Value)
            {
                lke.Properties.DataSource = null;
            }

            else
            {
                if (Convert.ToInt32(shortageReasonID) != ShortageReasons.Constants.DAMAGED)
                {
                    lke.Properties.DataSource = null;
                }
                else
                {
                    lke.Properties.DataSource =
                        PalletLocation.GetQuaranteen(CurrentContext.UserId).AsEnumerable().Where(
                            l => Convert.ToInt32(l["WarehouseID"]) == warehouseID).CopyToDataTable();
                }
            }
        }

        private void grdViewDiscrepancy_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = grdViewDiscrepancy.GetFocusedDataRow();
            var discrepancyReason = row["ShortageReasonID"];

            if (discrepancyReason != DBNull.Value)
            {
                if(Convert.ToInt32(discrepancyReason)!=ShortageReasons.Constants.DAMAGED) //Location can be chosen only for damaged items receive.
                {
                    row["PalletLocationID"] = DBNull.Value;
                }
            }
        }
    }
}