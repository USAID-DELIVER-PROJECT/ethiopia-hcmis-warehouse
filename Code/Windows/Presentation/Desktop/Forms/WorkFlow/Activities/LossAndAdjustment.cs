using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Converter;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.ViewHelpers;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("AC-LA-LA-FR","Loss And Adjustments","")]
    public partial class LossAndAdjustment : DevExpress.XtraEditors.XtraForm
    {
        public LossAndAdjustment()
        {
            InitializeComponent();
        }

        private void LossAndAdjustment_Load(object sender, EventArgs e)
        {
            colWriteOff.Visible = false;
            btnAdjustment.Visible = false;
            btnCommit.Visible = false;

            SetPermission();
            BindQuarantine();
            // load the item categories


            lkCategories.Properties.DataSource = BLL.CommodityType.GetAllTypes();
            lkStore.SetupActivityEditor().SetDefaultActivity();
            
            Shelf shelf = new Shelf();
            shelf.LoadAllShelves();
            //lkRacks.Properties.DataSource = shelf.DefaultView;

            Item itms = new Item();
            gridItemList.DataSource = itms.GetAllItems(1);

            LossAndAdjustmentReason dr = new LossAndAdjustmentReason();
            dr.LoadAll();
            lkDisposalReasons1.DataSource = dr.DefaultView;
            lkDisposalReason2.DataSource = dr.DefaultView;
            lkDisposalReason2.NullText = "Select Reason";
            newpalletlocationrepositoryItemGridLookUpEdit.NullText = "Select New Pallet Location";
           

            if(!BLL.Settings.UseNewUserManagement)
            {
                // adjust the buttons according to previlages
                if (CurrentContext.LoggedInUser.UserType == UserType.Constants.FINANCE ||
                    CurrentContext.LoggedInUser.UserType == UserType.Constants.SUPER_ADMINISTRATOR)
                {
                    colWriteOff.Visible = true;
                    btnAdjustment.Visible = true;
                    btnCommit.Visible = true;
                    gridColAdjustments.Visible = true;
                }
                else
                {
                    
                }
            }
            // set the default category
            lkCategories.ItemIndex = 0;
            lkCategories_EditValueChanged(null, null);
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                // adjust the buttons according to previlages
                if (this.HasPermission("Write-Off-Loss-And-Adjustment"))
                {
                    colWriteOff.Visible = true; 
                }
                if (this.HasPermission("Record-Adjustment"))
                {
                    btnAdjustment.Visible = true;
                    btnCommit.Visible = true;
                    gridColAdjustments.Visible = true;
                }
               
                btnMoveToQuaranteen.Enabled = this.HasPermission("Move-To-Quaranteen");
            }
            
        }

        private void BindQuarantine()
        {
            PalletLocation pl = new PalletLocation();
            DataTable dtbl = pl.GetQuaranteenItems();

            dtbl.Columns.Add("WriteOff", typeof(int));
            dtbl.Columns.Add("ReLocate", typeof(int));
            dtbl.Columns.Add("Reason", typeof(int));
            dtbl.Columns.Add("NewPalletLocation", typeof (int));
            gridQuaranteen.DataSource = dtbl;
        }

        private void itemListView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            PopulateItemDetails();
        }

        private void PopulateItemDetails()
        {
            int itemID = Convert.ToInt32(itemListView.GetFocusedDataRow()["ID"]);
            int unitID = Convert.ToInt32(itemListView.GetFocusedDataRow()["UnitID"]);
            Item itm = new Item();

            ReceiveDoc rec = new ReceiveDoc();
            DataTable dtbl = rec.GetRecievedItemsWithBalanceExcludeQuaranteen(itemID,unitID,chkShowAllFinished.Checked);
            dtbl.DefaultView.Sort = "ExpiryDate";
            PalletLocation.PopulatePalletLocationFor(dtbl);
            gridItemDetailList.DataSource = dtbl.DefaultView;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                ReceiveDoc rec = new ReceiveDoc();
                DataTable dtbl = rec.GetExpiredItemsWithBalanceExcludeQuaranteen();
                PalletLocation.PopulatePalletLocationFor(dtbl);
                gridItemDetailList.DataSource = dtbl.DefaultView;
            }
            else
            {
                PopulateItemDetails();
            }
        }

        private bool ValidateMoveToQuaranteen()
        {
            // do validation to check if both adjustment and loss are written
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                DataRow dr = gridView3.GetDataRow(i);
                dr.ClearErrors();
                if (dr["Loss"] != DBNull.Value && dr["Adjust"] != DBNull.Value)
                {
                    dr.SetColumnError("Loss", "Both Loss and Adjustment are filled");
                    dr.SetColumnError("Adjust", "Both Loss and Adjustment are filled");
                    XtraMessageBox.Show("You can not fill both Adjustment and Loss for the same row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (dr["Adjust"] != DBNull.Value)
                {
                    dr.SetColumnError("Adjust", "Expired Items could not be adjusted");
                    XtraMessageBox.Show("Adjustment values couldn't be used with move to quaranteen command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (dr["Loss"]!= DBNull.Value && Convert.ToInt32(dr["Loss"]) > Convert.ToInt32(dr["Balance"]))
                {
                    dr.SetColumnError("Loss", "Loss can not be greater than balance!");
                    XtraMessageBox.Show("The loss amount you specified is greater than the available balance. please fix it and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (dr["Loss"] != DBNull.Value && Convert.ToInt32(dr["Loss"]) <= 0)
                {
                    dr.SetColumnError("Loss", "Loss has to be filled in positive numbers.");
                    XtraMessageBox.Show("The loss amount you specified needs to be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }

        private void btnMoveToQuaranteen_Click(object sender, EventArgs e)
        {
            if (ValidateMoveToQuaranteen())
            {
                if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you want to move the items to Quarantine", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    InternalItemMovements ims = new InternalItemMovements();
                    PalletLocation pl = new PalletLocation();
                    int printNubmer = InternalTransfer.GetNewPrintNumber() + 1 ;
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                        DataRow dr = gridView3.GetDataRow(i);
                        if (dr["Loss"] != DBNull.Value)
                        {
                            int amount = Convert.ToInt32(dr["Loss"]);
                            int palletLocationID = Convert.ToInt32(dr["PalletLocationID"]);

                            ReceivePallet rp = new ReceivePallet();
                            ReceiveDoc rdoc = new ReceiveDoc();

                            rp.LoadByPrimaryKey(Convert.ToInt32(dr["ReceivePalletID"]));
                            rdoc.LoadByPrimaryKey(rp.ReceiveID);
                            amount *= rdoc.QtyPerPack;

                            if (rp.Balance - amount < rp.ReservedStock)
                            {
                                //Item has been reserved for a facility.  This needs to be handled.
                                DataTable dtble = rp.GetFacilitiesItemsReservedFor();
                                string facilities = "";
                                foreach(DataRow dRow in dtble.Rows)
                                {
                                    if (dr != null)
                                        facilities += dRow["Name"].ToString() + System.Environment.NewLine;
                                }
                                XtraMessageBox.Show("You cannot fill in a loss because the item in this location has been reserved to the following facilities:" + System.Environment.NewLine + facilities, "Exisiting reservations must be cancelled", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            var receiveDocID = Convert.ToInt32(dr["ID"]);
                            var rec = new ReceiveDoc();
                            rec.LoadByPrimaryKey(receiveDocID);

                            int qPalletLocationID = PalletLocation.GetQuaranteenPalletLocation(rec.PhysicalStoreID);
                            pl.LoadByPrimaryKey(qPalletLocationID);
                            if (pl.IsColumnNull("PalletID"))
                            {
                                Pallet p = new Pallet();
                                p.AddNew();
                                p.StorageTypeID = Convert.ToInt32( StorageType.Quaranteen);
                                p.Save();
                                pl.PalletID = p.ID;
                                pl.Save();
                            }

                            
                            ReceivePallet rp2 = new ReceivePallet();
                            ReceiveDoc rd = new ReceiveDoc();

                            
                            rd.LoadByPrimaryKey(rp.ReceiveID);
                            rp2.AddNew();

                            rp2.PalletID = pl.PalletID;
                            rp2.ReceiveID = rp.ReceiveID;
                            rp2.PalletLocationID = pl.ID;


                            // calculate the new balance
                            BLL.ItemManufacturer im = new BLL.ItemManufacturer();
                            //im.LoadDefaultReceiving(rd.ItemID, Convert.ToInt32(dr["ManufacturerID"]));
                            if (dr["BoxLevel"] == DBNull.Value)
                            {
                                dr["BoxLevel"] = 0;
                            }
                            im.LoadIMbyLevel(rd.ItemID, Convert.ToInt32(dr["ManufacturerID"]), Convert.ToInt32(dr["BoxLevel"]));
                            int packqty = (amount / im.QuantityInBasicUnit);
                            rp2.ReservedStock = 0;

                            BLL.ReceivePallet.MoveBalance(rp, rp2, amount);
                            //rp2.Balance = amount;
                            //rp.Balance -= rp2.Balance;

                            //rp.Save();                            
                            //rp2.Save();

                            pl.Confirmed = false;
                            pl.Save();
                            if (rp.Balance == 0 )
                            {
                                PalletLocation.GarbageCollection();
                            }

                            InternalTransfer it = new InternalTransfer();
                            it.AddNew();
                            it.ItemID = rd.ItemID;
                            it.BoxLevel = im.PackageLevel;
                            if (!rd.IsColumnNull("ExpDate"))
                            {
                                it.ExpireDate = rd.ExpDate;
                            }
                            it.BatchNumber = rd.BatchNo;
                            it.ManufacturerID = im.ManufacturerID;
                            it.FromPalletLocationID = palletLocationID;
                            it.ToPalletLocationID = qPalletLocationID;
                            it.QtyPerPack = im.QuantityInBasicUnit;
                            it.Packs = packqty;
                            it.ReceiveDocID = rp.ReceiveID;
                            it.QuantityInBU = rp2.Balance; //it.Packs * it.QtyPerPack;
                            it.Type = "ToQuaranteen";
                            it.IssuedDate = DateTime.Today;
                            it.Status = 0;
                            it.PrintNumber = printNubmer;
                            it.Save();
                        }
                    }

                   
                    gridConfirmationControl.DataSource = InternalTransfer.GetAllTransfers("ToQuaranteen");
                   
                    PopulateItemDetails();
                    XtraMessageBox.Show("Your items are marked for movement to Quarantine, please go to Internal Movements page to confirm!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ValidateMoveToAdjustments()
        {
            // do validation to check if both adjustment and loss are written
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                DataRow dr = gridView3.GetDataRow(i);
                dr.ClearErrors();
                if (dr["Loss"] != DBNull.Value && dr["Adjust"] != DBNull.Value)
                {
                    dr.SetColumnError("Loss", "Both Loss and Adjustment are filled");
                    dr.SetColumnError("Adjust", "Both Loss and Adjustment are filled");
                    XtraMessageBox.Show("You can not fill both Adjustment and Loss for the same row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (dr["Loss"] != DBNull.Value)
                {
                    dr.SetColumnError("Loss", "Loss could not be marked as Adjustment");
                    XtraMessageBox.Show("The loss values will not be processed with the adjustment command.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return false;
                }

                if (dr["Adjust"]!= DBNull.Value && dr["Reason"] != DBNull.Value && Convert.ToInt32(dr["Reason"]) <= 0)
                {
                    dr.SetColumnError("Reason", "Please select reason for adjustment");
                    XtraMessageBox.Show("Please select reason for adjustment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (dr["Adjust"] != DBNull.Value && Convert.ToInt32(dr["Adjust"]) <= 0)
                {
                    dr.SetColumnError("Adjust", "Adjustment value needs to be greater than zero");
                    XtraMessageBox.Show("Adjustment value needs to be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }

        private void btnAdjustments_Click(object sender, EventArgs e)
        {
            if (ValidateMoveToAdjustments())
            {
                if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you would like to commit this adjustment?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    
                    PalletLocation pl = new PalletLocation();
                    Pallet p = new Pallet();
                    ReceiveDoc rdoc = new ReceiveDoc();
                    ReceivePallet rp = new ReceivePallet();
                    int printNubmer = InternalTransfer.GetNewPrintNumber() + 1 ;
                    for (int i = 0; i < gridView3.RowCount; i++)
                    {
                         DataRow dr = gridView3.GetDataRow(i);
                         if (dr["Adjust"] != DBNull.Value)
                         {
                             

                             int amount = Convert.ToInt32(dr["Adjust"]);
                             rp.LoadByPrimaryKey(Convert.ToInt32(dr["ReceivePalletID"]));
                             rdoc.LoadByPrimaryKey(rp.ReceiveID);
                             
                             rdoc.NoOfPack += amount;
                             amount *= rdoc.QtyPerPack;
                             rp.Balance += amount;
                             if (rp.IsColumnNull("ReceivedQuantity"))
                             {
                                 rp.ReceivedQuantity = 0;
                             }
                             rp.ReceivedQuantity += amount;

                             rdoc.QuantityLeft += amount;
                             rdoc.Quantity += amount;

                             BLL.LossAndAdjustment d = new BLL.LossAndAdjustment();
                             d.AddNew();
                             d.GenerateRefNo();
                             d.ItemID = Convert.ToInt32(dr["ItemID"]);
                             d.ReasonId = Convert.ToInt32(dr["Reason"]);
                             d.RecID = rdoc.ID;
                             d.Quantity = amount;
                             d.BatchNo = rdoc.BatchNo;

                             CalendarLib.DateTimePickerEx edate = new CalendarLib.DateTimePickerEx();
                             edate.Value = DateTime.Today;

                             edate.CustomFormat = "MM/dd/yyyy";
                             d.Date = ConvertDate.DateConverter(edate.Text);

                             d.EurDate = DateTime.Today;
                             if (!rdoc.IsColumnNull("Cost"))
                             {
                                 d.Cost = Math.Abs(rdoc.Cost*amount);
                             }
                             d.StoreId = rdoc.StoreID;
                             d.Losses = false;
                             d.ApprovedBy = CurrentContext.UserId.ToString();
                             d.Save();
                             rdoc.Save();
                             rp.Save();
                             
                         }
                    }
                    PopulateItemDetails();
                    XtraMessageBox.Show("Items adjusted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            if (ValidateQuarantine())
            {

                MyGeneration.dOOdads.TransactionMgr transaction = MyGeneration.dOOdads.TransactionMgr.ThreadTransactionMgr();
                transaction.BeginTransaction();
                if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you want to commit the Loss and Adjustment on this screen?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    // do the actual commit here.
                    int printNubmer = InternalTransfer.GetNewPrintNumber() + 1;
                    PalletLocation pl = new PalletLocation();
                    Pallet p = new Pallet();
                    ReceiveDoc rdoc = new ReceiveDoc();
                    ReceivePallet rp = new ReceivePallet();
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        DataRow dr = gridView1.GetDataRow(i);
                        Double writeoff = 0;
                        Double reLocate = 0;
                        try
                        {
                            if (dr["WriteOff"] != DBNull.Value)
                            {
                                writeoff = Double.Parse(dr["WriteOff"].ToString());
                            }
                            if (dr["ReLocate"] != DBNull.Value)
                            {
                                reLocate = Double.Parse(dr["ReLocate"].ToString());
                            }
                        }
                        catch (Exception exc)
                        {
                        }

                        if(dr["WriteOff"] != DBNull.Value & writeoff>0)
                        {
                            if (Double.Parse(dr["WriteOff"].ToString()) > Double.Parse(dr["Balance"].ToString()))
                            {
                                XtraMessageBox.Show("Couldn't commit to the numbers you specified. Please specify number less than the balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            int writeoffAmout = Convert.ToInt32(dr["WriteOff"]);
                            int qtyPerPack = Convert.ToInt32(dr["QtyPerPack"]);
                            writeoffAmout *= qtyPerPack;
                            rp.LoadByPrimaryKey(Convert.ToInt32(dr["ReceivePalletID"]));
                            rdoc.LoadByPrimaryKey(rp.ReceiveID);
                            string x = dr["NewPalletLocation"].ToString();
                            rp.Balance -= writeoffAmout;
                            try
                            {
                              //  rp.ReceivedQuantity -= writeoffAmout;
                            }
                            catch { }
                            rdoc.QuantityLeft -= writeoffAmout;

                             ReceivePallet nrp =new ReceivePallet();
                             nrp.AddNew();
                             nrp.ReceiveID = rp.ReceiveID;
                             nrp.PalletID = pl.GetpalletidbyPalletLocationOrgetnew(int.Parse(dr["NewPalletLocation"].ToString()));
                            //nrp.ReceivedQuantity = rp.ReceivedQuantity;
                            nrp.Balance = writeoffAmout;
                            nrp.ReservedStock = 0;
                            //nrp.ReserveOrderID = rp.ReserveOrderID;
                            nrp.BoxSize = rp.BoxSize;
                            nrp.PalletLocationID = int.Parse(dr["NewPalletLocation"].ToString());
                            nrp.IsOriginalReceive = rp.IsOriginalReceive;
                            


                            BLL.LossAndAdjustment d = new BLL.LossAndAdjustment();
                            d.AddNew();
                            d.GenerateRefNo();
                            d.ItemID = Convert.ToInt32(dr["ItemID"]);
                            d.ReasonId = Convert.ToInt32(dr["Reason"]);
                            d.RecID = rdoc.ID;
                            d.Quantity = writeoffAmout;
                            d.BatchNo = rdoc.BatchNo;
                            
                            CalendarLib.DateTimePickerEx edate = new CalendarLib.DateTimePickerEx();
                            edate.Value = DateTime.Today;
                            //TODO: fix to an ethiopian date here
                            edate.CustomFormat = "MM/dd/yyyy";

                            d.Date = ConvertDate.DateConverter(edate.Text);

                            d.EurDate = DateTime.Today;
                             d.Cost = rdoc.IsColumnNull("Cost")? 0: Math.Abs(rdoc.Cost * writeoffAmout);
                            d.StoreId = rdoc.StoreID;
                            d.Losses = true;
                            //todo:
                            d.ApprovedBy = CurrentContext.UserId.ToString();
                            //d.Remarks

                             InternalTransfer it =new  InternalTransfer();
                             it.AddNew();
                            it.ItemID = d.ItemID;
                            it.FromPalletLocationID = pl.GetPalletLocationIDByPalletID(int.Parse(dr["PalletID"].ToString()));
                            it.ToPalletLocationID = nrp.PalletLocationID;
                            it.BatchNumber = d.BatchNo;
                            if (!rdoc.IsColumnNull("ExpDate"))
                            {
                                it.ExpireDate = rdoc.ExpDate;
                            }
                            it.ReceiveDocID = rdoc.ID;
                            it.ManufacturerID = rdoc.ManufacturerId;
                            it.QtyPerPack = Convert.ToInt32(dr["QtyPerPack"]);
                            it.Packs = rdoc.NoOfPack;
                            it.QuantityInBU = nrp.Balance;
                             

                            LossAndAdjustmentReason r = new LossAndAdjustmentReason();
                            it.Type = r.GetReasonByID(d.ReasonId);


                           // d.Save();
                            rdoc.Save();
                            rp.Save();

                            rdoc.QuantityLeft += writeoffAmout;
                             rdoc.Save();
                             nrp.Save();
                             it.Save();
                            int xs = it.ID;
                        }
                        else if (dr["ReLocate"] != DBNull.Value & reLocate > 0)
                         {
                             
                             if (dr["ReLocate"] != DBNull.Value)
                             {
                                 int amount = Convert.ToInt32(dr["ReLocate"]);
                                 int qtyPerPack = Convert.ToInt32(dr["QtyPerPack"]);
                                 amount *= qtyPerPack;
                                 rp.LoadByPrimaryKey(Convert.ToInt32(dr["ReceivePalletID"]));
                                 rdoc.LoadByPrimaryKey(rp.ReceiveID);
                                 int palletLocationID = Convert.ToInt32(dr["PalletLocationID"]);

                                 int qPalletLocationID =
                                     PalletLocation.GetQuaranteenPalletLocationByPalletLocationID(palletLocationID);//PalletLocation.GetQuaranteenPalletLocation(Convert.ToInt32(dr["ID"]));
                                 pl.LoadByPrimaryKey(qPalletLocationID);

                                 ReceivePallet rp2 = new ReceivePallet();
                                 ReceiveDoc rd = new ReceiveDoc();
                                 Pallet pallet = new Pallet();
                                 rp.LoadByPrimaryKey(Convert.ToInt32(dr["ReceivePalletID"]));
                                 rd.LoadByPrimaryKey(rp.ReceiveID);
                                 pallet.AddNew();
                                 Item item = new Item();
                                 item.LoadByPrimaryKey(rdoc.ItemID);
                                 if (item.StorageTypeID.ToString() == StorageType.BulkStore)
                                 {
                                     pallet.PalletNo = Pallet.GetLastPanelNumber();
                                     
                                 }
                                 pallet.Save();
                                 rp2.AddNew();
                                 rp2.PalletID = pl.GetpalletidbyPalletLocationOrgetnew(int.Parse(dr["NewPalletLocation"].ToString()));//pallet.ID;
                                 rp2.ReceiveID = rp.ReceiveID;
                                 rp2.IsOriginalReceive = rp.IsOriginalReceive;
                                 // calculate the new balance
                                 BLL.ItemManufacturer im = new BLL.ItemManufacturer();
                                 //im.LoadDefaultReceiving(rd.ItemID, Convert.ToInt32(dr["ManufacturerID"]));
                                 //im.LoadIMbyLevel(rd.ItemID, Convert.ToInt32(dr["ManufacturerID"]), Convert.ToInt32(dr["BoxLevel"]));
                                 //int packqty = (amount / im.QuantityInBasicUnit);
                                 rd.QuantityLeft -= amount;
                                 rp.Balance -= amount;
                                rd.Save();
                                rp.Save();

                                 rd.QuantityLeft += amount;
                                 rp2.Balance = amount;//packqty * im.QuantityInBasicUnit;
                                 rd.Save();
                                 
                                 rp2.BoxSize = rp.BoxSize;
                                 rp2.ReservedStock = 0;
                                 rp2.PalletLocationID= int.Parse(dr["NewPalletLocation"].ToString());
                                 rp2.Save();

                                 pl.Confirmed = false;
                                 pl.Save();

                                 // select the new pallet location here.
                              /*   XtraForm xdb = new XtraForm();
                                 xdb.Controls.Add(panelControl2);
                                 Item itms= new Item();
                                 itms.GetItemByPrimaryKey(Convert.ToInt32(dr["ItemID"]));
                                 lblItemName.Text = itms.FullItemName;
                                 panelControl2.Visible = true;
                                 panelControl2.Dock = DockStyle.Fill;
                                 xdb.Text = "Select Location for relocated Item";
                                 lkLocation.Properties.DataSource = PalletLocation.GetAllFreeFor(Convert.ToInt32(dr["ItemID"]));
                                 xdb.ShowDialog();
                                 
                                 PalletLocation pl2 = new PalletLocation();
                                 pl2.LoadByPrimaryKey(Convert.ToInt32(lkLocation.EditValue));
                                 pl2.PalletID = pallet.ID;
                                 pl2.Confirmed = false;
                                 pl2.Save();
                                 */
                                 InternalTransfer it = new InternalTransfer();
                                 
                                 it.AddNew();
                                 it.ItemID = rd.ItemID;
                                 it.BoxLevel = 0;// im.PackageLevel;
                                 //it.ExpireDate = rd.ExpDate;
                                 if (!rd.IsColumnNull("ExpDate"))
                                 {
                                     it.ExpireDate = rd.ExpDate;
                                 }
                                 it.BatchNumber = rd.BatchNo;
                                 it.ManufacturerID = Convert.ToInt32(dr["ManufacturerID"]);//im.ManufacturerID;
                                 it.FromPalletLocationID = qPalletLocationID;
                                 it.ToPalletLocationID = int.Parse(dr["NewPalletLocation"].ToString()); //pl2.ID;
                                 it.QtyPerPack = 1;
                                //it.Packs = pack qty;
                                 it.ReceiveDocID = rp.ReceiveID;
                                 it.QuantityInBU = amount;// it.QtyPerPack;
                                 it.Type = "ReLocation";
                                 it.IssuedDate = DateTime.Today;
                                 it.Status = 0;
                                 it.PrintNumber = printNubmer;
                                 it.Save();
                             }
                         }
                    }
                    transaction.CommitTransaction();
                    BindQuarantine();
                    XtraMessageBox.Show("Quarantine Write off/Adjustment was commitd.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool ValidateQuarantine()
        {
             // do validation to check if both adjustment and loss are written
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow dr = gridView1.GetDataRow(i);
                dr.ClearErrors();
                Double writeoff = 0;
                Double reLocate = 0;
                try
                {
                    if (dr["WriteOff"] != DBNull.Value)
                    {
                        writeoff = Double.Parse(dr["WriteOff"].ToString());
                    }
                    if (dr["ReLocate"] != DBNull.Value)
                    {
                        reLocate = Double.Parse(dr["ReLocate"].ToString());
                    }
                }
                catch (Exception exc)
                {
                }

                if ((Convert.ToBoolean(dr["IsExpired"]) && dr["ReLocate"]!= DBNull.Value) && (dr["ReLocate"] != DBNull.Value && Convert.ToInt32(dr["ReLocate"]) != 0))
                {
                    dr.SetColumnError("ReLocate", "Expired Item Couldn't be relocated");
                    XtraMessageBox.Show("Expired Item Couldn't be relocated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
               
                
                if ((dr["ReLocate"] != DBNull.Value || dr["WriteOff"] != DBNull.Value) && dr["Reason"] == DBNull.Value)
                {

                    if (writeoff != 0 || reLocate != 0)
                    {
                        dr.SetColumnError("Reason", "Please select reason of adjustment");
                        XtraMessageBox.Show("Please select reason for adjustment", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }
                if ((dr["ReLocate"] != DBNull.Value || dr["WriteOff"] != DBNull.Value) && dr["NewPalletLocation"] == DBNull.Value)
                {
                    if (writeoff != 0 || reLocate != 0)
                    {
                        dr.SetColumnError("NewPalletLocation", "Please select NewPalletLocation ");
                        XtraMessageBox.Show("Please select NewPalletLocation", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }

                if ((dr["ReLocate"] != DBNull.Value )&& Convert.ToInt32(dr["ReLocate"]) < 0 )
                {
                    dr.SetColumnError("ReLocate", "Please insert a Positive value");
                    return false;
                }
                if ((dr["WriteOff"] != DBNull.Value) && Convert.ToInt32(dr["WriteOff"]) < 0)
                {
                    dr.SetColumnError("WriteOff", "Please insert a Positive value");
                    return false;
                }
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            (panelControl2.Parent as XtraForm).Close();

        }

        private void btnCancelCommit_Click(object sender, EventArgs e)
        {
            LossAndAdjustment_Load(new object(), new EventArgs());
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page == xtraTabPage2)
            {
                LossAndAdjustment_Load(new object(), new EventArgs());
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            itemListView.ActiveFilterString = string.Format("FullItemName like '{0}%'", textEdit1.Text);
        }


        private void lkCategories_EditValueChanged(object sender, EventArgs e)
        {
            if (lkStore.EditValue!=null && lkStore.EditValue.ToString() != "")
            {
                int category = Convert.ToInt32(lkCategories.EditValue);

                int Store = Convert.ToInt32(lkStore.EditValue);
                gridItemList.DataSource = Item.GetActiveItemsByCommodityType(category, Store);
            }
        }

        private void lkStore_EditValueChanged(object sender, EventArgs e)
        {
            int category = Convert.ToInt32(lkCategories.EditValue);
            int Store = Convert.ToInt32(lkStore.EditValue);
            gridItemList.DataSource = Item.GetActiveItemsByCommodityType(category, Store);
        }

        private void gridView1_FocusedRowChanged(object sender,
            DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(ValidateForBindingNewPalletLocation()){
            DataRow dr = gridView1.GetFocusedDataRow();

            //for validation
            Double writeoff = 0;
            Double reLocate = 0;
            try
            {
                if (dr["WriteOff"] != DBNull.Value)
                {
                    writeoff = Double.Parse(dr["WriteOff"].ToString());
                }
                if (dr["ReLocate"] != DBNull.Value)
                {
                    reLocate = Double.Parse(dr["ReLocate"].ToString());
                }
            }
            catch (Exception exc)
            {
            }
            // bind data set to the repository item
            try
            {


                if (dr["WriteOff"] != DBNull.Value && writeoff>0)
                {
                    int palletid = int.Parse(dr["PalletID"].ToString());
                    PalletLocation pl = new PalletLocation();
                    newpalletlocationrepositoryItemGridLookUpEdit.DataSource =
                        pl.GetPalletLocationsOnTheSameStore(palletid);
                }
                else if (dr["ReLocate"] != DBNull.Value & reLocate>0)
                {
                    Item itms = new Item();
                    itms.GetItemByPrimaryKey(Convert.ToInt32(dr["ItemID"]));
                    newpalletlocationrepositoryItemGridLookUpEdit.DataSource =
                        PalletLocation.GetAllFreeForIntheSameStore(Convert.ToInt32(dr["ItemID"]),
                            int.Parse(dr["PalletID"].ToString()));
                }
                else
                {
                    newpalletlocationrepositoryItemGridLookUpEdit.DataSource = null;
                }

            }
            catch (Exception except)
            {
            }
        }

    }

        private bool ValidateForBindingNewPalletLocation()
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            dr.ClearErrors();

            //for validation
            Double writeoff = 0;
            Double reLocate = 0;
            try
            {
                if (dr["WriteOff"] != DBNull.Value)
                {
                    writeoff = Double.Parse(dr["WriteOff"].ToString());
                }
                if (dr["ReLocate"] != DBNull.Value)
                {
                    reLocate = Double.Parse(dr["ReLocate"].ToString());
                }
            }
            catch (Exception exc)
            {
            }

            if (dr["WriteOff"] != DBNull.Value && dr["ReLocate"] != DBNull.Value)
            {
                if (writeoff != 0 && reLocate != 0)
                {
                    dr.SetColumnError("WriteOff", "Both ReLocate and WriteOff are filled");
                    dr.SetColumnError("ReLocate", "Both ReLocate and WriteOff are filled");
                    XtraMessageBox.Show("You can not fill both WriteOff and ReLocate for the same row.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
                if (writeoff < 0)
                {
                    dr.SetColumnError("WriteOff", "WriteOff can not be less than 0!");
                    return false;

                }
                if (reLocate < 0)
                {
                    dr.SetColumnError("ReLocate", "ReLocate can not be less than 0!");
                    return false;
                }
            

            return true;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name != "gridColumn6")
            gridView1_FocusedRowChanged(null, null);
        }
        
    }
}