using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Modals;
using HCMIS.Desktop.Reports;
using HCMIS.Security;

namespace HCMIS.Desktop.Forms.WorkFlow
{
    [FormIdentifier("TR-IM-SM-TA","Internal Movements","")]
    public partial class InternalItemMovements : XtraForm
    {
        private int _palletLocationID = 0;
        private int _designatedItemID = 0;
        private int _pickFaceID = 0;
        public InternalItemMovements()
        {
            InitializeComponent();
        }

        private void InternalItemMovements_Load(object sender, EventArgs e)
        {
            SetPermissions();
            BindFormElements();

            // Hide the Pick face replenishment pages
            tbPickFace.Visible = false;
            tbPickFaceReplenishment.Visible = false;

            lkBoxSizes.DataSource = BLL.ItemManufacturer.PackageLevelKeys;
            RadioGroup1SelectedIndexChanged(new object(), new EventArgs());

            PhysicalStore ps=new PhysicalStore();
            ps.LoadAllPhysicalStoreswithClusterandWarehouseNames();
            lkPhysicalStore.Properties.DataSource = ps.DefaultView;
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnConsolidate.Enabled = this.HasPermission("Consolidate");
                btnMovePallet2.Enabled = btnMovePallet.Enabled = this.HasPermission("Move-Commodities");
                btnPrintShelfView.Enabled = this.HasPermission("Print-Shelf-Views");
            }
        }

        private void BindFormElements()
        {
            Activity stores = new Activity();
            stores.LoadAll();
            cmbLogicalStore.Properties.DataSource = stores.DefaultView;
            stores.Rewind();
            cmbLogicalStore.EditValue = stores.ID;
            radioLogicalStore_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void OnPickFaceStockLevelRowClicked(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            BindPickFaceDetailAndReplenismehmnent();
        }

        private void BindPickFaceDetailAndReplenismehmnent()
        {
            DataRow dr = gridPickFaceStockLevelView.GetFocusedDataRow();
            PickFace pf = new PickFace();
            _palletLocationID = Convert.ToInt32(dr["PalletLocationID"]);
            _designatedItemID = Convert.ToInt32(dr["DesignatedItem"]);
            
            _pickFaceID = Convert.ToInt32(dr["ID"]);
          
            int storeID = Convert.ToInt32(cmbLogicalStore.EditValue);
            gridPickFaceDetails.DataSource = pf.GetDetailItemsFor(_pickFaceID, _palletLocationID);
            gridReplenishmentChoice.DataSource = pf.GetReplenishmentListFor(_designatedItemID, storeID);
        }

        private void OnReplenishClicked(object sender, EventArgs e)
        {
            PalletLocation pl = new PalletLocation();
            PickFace pf = new PickFace();
            DataRow dr = gridPickFaceStockLevelView.GetFocusedDataRow();
            DataRow dr2 = gridReplenishmentChoiceView.GetFocusedDataRow();
            if (dr2 != null)
            {
                // check if the replenishment is from allowed location.
                //
                if (!Convert.ToBoolean(dr2["CanReplenish"]))
                {
                    XtraMessageBox.Show("Please choose replenishment from the first to expire items", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                pl.LoadByPrimaryKey(_palletLocationID);
                pf.LoadByPrimaryKey(_pickFaceID);
                if (pf.IsColumnNull("Balance"))
                {
                    pf.Balance = 0;
                }

                if (pl.IsColumnNull("PalletID"))
                {
                    Pallet pallet = new Pallet();
                    pallet.AddNew();
                    pallet.StorageTypeID = Convert.ToInt32(StorageType.PickFace);
                    pallet.Save();
                    pl.PalletID = pallet.ID;
                    pl.Save();
                }

                ReceivePallet rp = new ReceivePallet();
                ReceivePallet rp2 = new ReceivePallet();
                ReceiveDoc rd = new ReceiveDoc();
                rp.LoadByPrimaryKey(Convert.ToInt32(dr2["ReceivePalletID"]));
                rp2.AddNew();
                rp2.IsOriginalReceive = false;
                rp2.PalletID = pl.PalletID;
                rp2.ReceiveID = rp.ReceiveID;
                rp2.BoxSize = rp.BoxSize;
                
                // calculate the new balance
                BLL.ItemManufacturer im = new BLL.ItemManufacturer();
                im.LoadIMbyLevel(_designatedItemID, Convert.ToInt32(dr2["ManufacturerID"]),Convert.ToInt32(dr2["BoxSize"]));
                if (rp.IsColumnNull("ReservedStock"))
                {
                    rp.ReservedStock = 0;
                }
                //if (rp.Balance - rp.ReservedStock < im.QuantityInBasicUnit )
                //{
                //    XtraMessageBox.Show("You cannot replenish the pick face from this location because the items are reserved for Issue. Please replenish from another receive.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //    return;
                //}
                BLL.ItemManufacturer imff = new BLL.ItemManufacturer();
                imff.LoadOuterBoxForItemManufacturer(im.ItemID,im.ManufacturerID);
                if (imff.PackageLevel > im.PackageLevel && rp.Balance < imff.QuantityInBasicUnit)
                {
                    rp2.Balance = rp.Balance;
                }
                else if (rp.Balance - rp.ReservedStock > im.QuantityInBasicUnit)
                {
                    rp2.ReceivedQuantity = rp2.Balance = im.QuantityInBasicUnit;
                }
                else
                {
                    rp2.Balance = rp.Balance;
                }
                rp2.ReservedStock = 0;
                rp.Balance -= rp2.Balance;
                if (rp.IsColumnNull("ReceivedQuantity"))
                {
                    rp.ReceivedQuantity = rp.Balance + rp2.Balance;
                }
                rp.ReceivedQuantity -= rp2.Balance;
                rp.Save();
                rp2.Save();
                pl.Confirmed = false;
                pl.Save();
                pf.Balance += Convert.ToInt32(rp2.Balance);
                pf.Save();
                PalletLocation pl2 = new PalletLocation();
                pl2.LoadLocationForPallet(rp.PalletID);
                rd.LoadByPrimaryKey(rp2.ReceiveID);
                // Now update the screen accordingly.
                dr["Balance"] = pf.Balance;// Convert.ToInt32(dr["Balance"]) + rp2.Balance;

                InternalTransfer it = new InternalTransfer();

                it.AddNew();
                it.ItemID = _designatedItemID;
                it.BoxLevel = im.PackageLevel;
                it.ExpireDate = rd.ExpDate;
                it.BatchNumber = rd.BatchNo;
                it.ManufacturerID = im.ManufacturerID;
                it.FromPalletLocationID = pl2.ID;
                it.ToPalletLocationID = _palletLocationID;
                it.IssuedDate = DateTimeHelper.ServerDateTime;
                it.QtyPerPack = im.QuantityInBasicUnit;
                it.Packs = 1;
                it.ReceiveDocID = rp.ReceiveID;
                it.QuantityInBU = it.Packs * it.QtyPerPack;
                it.Type = "PickFace";
                it.Status = 0;
                it.Save();

                BindPickFaceDetailAndReplenismehmnent();
                XtraMessageBox.Show("Your Pick Face is updated, please print the replenishment list and confirm the stock movement", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ConfirmStockMovement(object sender, EventArgs e)
        {

            for (int i = 0; i < gridConfirmationView.RowCount; i++)
            {
                DataRow dr = gridConfirmationView.GetDataRow(i);
                if (Convert.ToBoolean(dr["IsSelected"]))
                {
                    InternalTransfer it = new InternalTransfer();
                    it.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));
                    it.Status = 1;
                    it.Save();
                }
            }
            BindConfirmationGrid();
        }

        private void OnSelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if (e.Page.Name == tbPickFaceReplenishment.Name)
            {
                // Bind the confirmation table.
                BindConfirmationGrid();
            }
            if (e.Page.Name == tbSuggestedMovement.Name)
            {
                BindPalletMovement();
            }
            if (e.Page == tbConsolidation)
            {
                BindConsolidation();
            }
        }

        private void BindConsolidation()
        {
            ReceiveDoc rd = new ReceiveDoc();
            rd.LoadUniqueReceivedItems();
            gridItems.DataSource = rd.DefaultView;
        }

        private void BindPalletMovement()
        {
            PalletLocation pl = new PalletLocation();
            DataView dv = pl.RecommendPalletMovments();
            gridPalletMovement.DataSource = dv;

        }

        private void BindConfirmationGrid()
        {
            gridConfirmationControl.DataSource = BLL.InternalTransfer.GetAllTransfers("PickFace");
        }

        private void BtnMovePalletClick(object sender, EventArgs e)
        {
            DataRow dr = gridPalletMovementView.GetFocusedDataRow();
            if (dr != null)
            {
                PalletLocation pl = new PalletLocation();
                pl.LoadByPrimaryKey(Convert.ToInt32(dr["FromID"]));
                PalletLocation pl2 = new PalletLocation();
                pl2.LoadByPrimaryKey(Convert.ToInt32(dr["ToID"]));
                if (pl2.IsColumnNull("PalletID"))
                {
                    pl2.PalletID = pl.PalletID;
                    pl.SetColumnNull("PalletID");
                    pl2.Save();
                    pl.Save();
                    XtraMessageBox.Show("The pallet Movement is confirmed!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BindPalletMovement();
            }
        }

        private void RadioGroup1SelectedIndexChanged(object sender, EventArgs e)
        {
            gridControl1.DataSource = BLL.InternalTransfer.GetAllTransfers(radioGroup1.EditValue.ToString());
        }

        private void btnConfirm2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                DataRow dr = gridView1.GetDataRow(i);
                if (Convert.ToBoolean(dr["IsSelected"]))
                {
                    InternalTransfer it = new InternalTransfer();
                    it.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));
                    it.Status = 1;
                    it.Save();
                }
            }
            XtraMessageBox.Show("Confirmation Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            gridControl1.DataSource = BLL.InternalTransfer.GetAllTransfers(radioGroup1.EditValue.ToString());
        }

        private void radioLogicalStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            PickFace pf = new PickFace();
            gridPickFaceStockLevel.DataSource = pf.GetPickFaceStockLevel(Convert.ToInt32(cmbLogicalStore.EditValue));
        }

        private void btnPrintReplenishList_Click(object sender, EventArgs e)
        {
            DataView dv = BLL.InternalTransfer.GetAllTransfers("PickFace");
            PickFaceReplenishment pfr = new PickFaceReplenishment();

            DataSet dst = new DataSet();
            dv.Table.TableName = "PickFaceReplenishment";
            dst.Tables.Add(dv.Table);

            pfr.DataSource = dst;
            pfr.ShowPreviewDialog();
            
        }

        private void lkStorageType2_EditValueChanged(object sender, EventArgs e)
        {
            Shelf shlf = new Shelf();
            int storageType = Convert.ToInt32(lkStorageType2.EditValue);
            shlf.LoadShelvesByStorageType(storageType.ToString(),(int)lkPhysicalStore.EditValue);
            lkRackID2.Properties.DataSource = shlf.DefaultView;
            if (shlf.RowCount > 0)
            {
                lkRackID2.EditValue = shlf.ID;
            }
            else
            {
                gridItemMovementView.Columns.Clear();
                gridItemDetailByLocation.DataSource = null;
            }
        }
        int selectedRackID = 0;
        private void lkRackID2_EditValueChanged(object sender, EventArgs e)
        {
            selectedRackID = Convert.ToInt32(lkRackID2.EditValue);

            gridItemDetailByLocation.DataSource = null;
            if (!bw.IsBusy)
            {
                bw.RunWorkerAsync();
            }
            
            // THIS OPTION HAS BEEN DISABLED FOR THE TIME BEING
            //lkFrom.Properties.DataSource = PalletLocation.GetNonFree(selectedRackID);
            //lkTo.Properties.DataSource = PalletLocation.GetFreeIn(selectedRackID);
            gridItemMovementView.Columns.Clear();

            var src = new ShelfRowColumn();
            src.LoadColumnsForShelf(selectedRackID);
            while (!src.EOF)
            {
                GridColumn gc = gridItemMovementView.Columns.Add();
                gc.FieldName = src.Index.ToString();
                gc.Caption = src.Label;
                gc.Visible = true;
                repositoryItemButtonEdit1.AllowFocused = true;
                gc.ColumnEdit = repositoryItemButtonEdit1;
                src.MoveNext();
            }

           
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dtbl = PalletLocation.GetIDItemDataTableFor(selectedRackID, bw);
            e.Result = dtbl;
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridItemDetailByLocation.DataSource = e.Result;
            gridItemDetailByLocation.Refresh();
            
        }

        private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            DataRow dr = gridItemMovementView.GetDataRow(e.RowHandle);
            int index = (e.Column.Caption == "") ? 1 : Convert.ToInt32(e.Column.Caption) - 1;

            if (dr[String.Format("Pallet{0}", index)] != DBNull.Value)
            {
                e.DisplayText = dr["Pallet" + index].ToString();
            }
            else
            {
                e.DisplayText = dr[String.Format("Pallet{0}", index)].ToString();
            }
            Rectangle box = e.Bounds;
            string balanceField = string.Format("ItemID{0}", index);
            if (dr.IsNull(String.Format("PercentageUsed{0}", index)))
            {
                box.Width = 0;
            }
            else
            {
                int width = Convert.ToInt32(Convert.ToDouble(box.Width) * Convert.ToDouble(dr[String.Format("PercentageUsed{0}", index)]) / 100);
                if (width > box.Width)
                {
                    width = box.Width;
                }
                box.Width = width;
            }

            if (box.Width > 0)
            {
                Brush b = new SolidBrush(Color.FromArgb(51, 153, 255));
                e.Graphics.FillRectangle(b, box);
                box.X += box.Width;
                box.Width = e.Bounds.Width - box.Width;
                b = new SolidBrush(Color.FromArgb(173, 216, 239));
                e.Graphics.FillRectangle(b, box);
            }
            else if (box.Width == 0 && dr[balanceField] != DBNull.Value && Convert.ToInt32(dr[balanceField]) > 0)
            {
                // this is when we are not sure abou the volume of the items
                Brush b = new SolidBrush(Color.FromArgb(173, 216, 239));
                e.Graphics.FillRectangle(b, e.Bounds);
            }

            if ((gridItemMovementView.FocusedValue != null && e.CellValue != DBNull.Value &&
                e.CellValue is int && Convert.ToInt32(e.CellValue) > 0 &&
                gridItemMovementView.FocusedValue != DBNull.Value &&
                gridItemMovementView.FocusedValue is int &&
                Convert.ToInt32(gridItemMovementView.FocusedValue) > 0) || (gridItemMovementView.FocusedValue == null) && Convert.ToInt32(e.CellValue) > 0)
            {
                var pl = new PalletLocation();
                pl.LoadByPrimaryKey(Convert.ToInt32(e.CellValue));
                 if (pl.RowCount > 0 && !pl.IsColumnNull("PalletID") && e.Column.Name != "colRow")
                {
                    Brush b = new SolidBrush(Color.FromArgb(173, 200, 0));
                    e.Graphics.FillRectangle(b, e.Bounds);
                }
            }
            e.Handled = false;
        }


        internal void ShowTabs(string p)
        {
            if (p == "PickList")
            {
                tbSuggestedMovement.PageVisible = false;
                tbOtherMovements.PageVisible = false;
                tbManualMovement.PageVisible = false;
                tbConsolidation.PageVisible = false;
            }
            else
            {
                tbPickFace.PageVisible = false;
                tbPickFaceReplenishment.PageVisible = false;
                lkStorageType2.EditValue = 1;
            }
        }

        private void btnMovePallet_Click(object sender, EventArgs e)
        {

            if (dxMoveValidation.Validate() && lkFrom.EditValue != null && lkTo.EditValue != null)
            {
                int from = Convert.ToInt32(lkFrom.EditValue);
                int to = Convert.ToInt32(lkTo.EditValue);
                if (PalletLocation.Move(from, to))
                {
                    XtraMessageBox.Show("Pallet Moved!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lkRackID2_EditValueChanged(new object(), new EventArgs());
                }
            }else
            {
                XtraMessageBox.Show("Please fill the From and To Pallet Locations", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                ShelfRowColumn srr = new ShelfRowColumn();
                srr.LoadRowForShelf(selectedRackID, (gridItemMovementView.DataRowCount - e.RowHandle)-1);
                if (srr.RowCount > 0)
                {
                    e.Info.DisplayText = srr.Label;
                }
            }
        }

    
        private void gridView5_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dr = gridView5.GetFocusedDataRow();
            if (dr != null)
            {
                // go show the source view
                PalletLocation pl = new PalletLocation();
                gridSources.DataSource = pl.GetLocationForItems(Convert.ToInt32(dr["ID"]));
                gridView3_RowClick(null, null);
            }
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            PalletLocation pl = new PalletLocation();
            DataRow dr = gridView3.GetFocusedDataRow();
            if (dr != null)
            {
                DataRow dr2 = gridView5.GetFocusedDataRow();
                int excludePalletLocationID = Convert.ToInt32(dr["ID"]);
                int itemID = Convert.ToInt32(dr2["ID"]);
                gridDestination.DataSource = pl.GetLocationForItemsExclude(itemID, excludePalletLocationID);
            }
        }

        private void btnConsolidate_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView4.GetFocusedDataRow();
            if (dr != null)
            {
                if (DialogResult.Yes == XtraMessageBox.Show("Are you sure you want to consolidate the two pallets? you will not be able to undo this change.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    DataRow dr2 = gridView3.GetFocusedDataRow();
                    PalletLocation pl = new PalletLocation();
                    pl.LoadByPrimaryKey( Convert.ToInt32(dr2["ID"]) );

                    int sourcePalletID = pl.PalletID;
                    pl.LoadByPrimaryKey(Convert.ToInt32(dr["ID"]));
                    int destinationPalletID = pl.PalletID;

                    ReceivePallet rp = new ReceivePallet();
                    rp.Consolidate(sourcePalletID, destinationPalletID);
                    pl.LoadByPrimaryKey(Convert.ToInt32(dr2["ID"]));
                    pl.SetColumnNull("PalletID");
                    pl.Save();
                    XtraMessageBox.Show("Items Consolidated.", "Items Consolidated");

                    gridView5_RowClick(null, null);
                }
            }
        }

        Object prev = null;
       
        private void btnPrintRackView_Click(object sender, EventArgs e)
        {
            // first correctly bind the  pallet numbers
            for (int i = 0; i < gridItemMovementView.Columns.Count; i++)
            {
                gridItemMovementView.Columns[i].FieldName = String.Format("Pallet{0}", i);
            }
            // then try to correct all the others
            printRackView.PrintDlg();
           

        }


        private void repositoryItemButtonEdit1_DoubleClick(object sender, EventArgs e)
        {
            Pallet pallet = new Pallet();
            PalletLocation pl = new PalletLocation();
            if (gridItemMovementView.FocusedValue != null )
            {
                prev = gridItemMovementView.FocusedValue;
                pl.LoadByPrimaryKey(Convert.ToInt32(gridItemMovementView.FocusedValue));
                if (!pl.IsColumnNull("PalletID"))
                {
                    pallet.GetAllItemsInPallet(pl.PalletID);
                    gridControl2.DataSource = pallet.DefaultView;
                    pallet.GetAllItemsInPalletSKUTotal(pl.PalletID);
                    Label l = new Label();
                    l.Dock = DockStyle.Bottom;

                    XtraForm f = new XtraForm();
                    //gridControl2.Parent = null;
                    f.ShowInTaskbar = false;
                    f.Width = gridControl2.Width;
                    if (pallet.RowCount > 0 && !pallet.IsColumnNull("Total"))
                    {

                        l.Text = string.Format("Total SKU: {0}", pallet.GetColumn("Total").ToString());
                    }
                    else
                    {
                        l.Text = "Total SKU: 0";
                    }
                    f.Controls.Add(l);

                    pallet.LoadByPrimaryKey(pl.PalletID);
                    if (!pallet.IsColumnNull("PalletNo"))
                    {
                        f.Text = String.Format("Pallet Number: {0}", pallet.PalletNo);

                    }
                    f.Controls.Add(gridControl2);

                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.ShowDialog();
                }
            }
        }

     
        int selectedPalletLocationID = 0;
        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            if (BLL.Settings.UseNewUserManagement && !this.HasPermission("Move-Commodities"))
            {
                return;
            }

            PalletLocation pl = new PalletLocation();
            if (gridItemMovementView.FocusedValue != null && prev != gridItemMovementView.FocusedValue)
            {
                prev = gridItemMovementView.FocusedValue;
                pl.LoadByPrimaryKey(Convert.ToInt32(gridItemMovementView.FocusedValue));

                PalletLocation pll = new PalletLocation();
                pll.LoadByPrimaryKey(selectedPalletLocationID);
               

                if (pll.RowCount > 0)
                {
                    if (!pll.IsColumnNull("PalletID") && pl.IsColumnNull("PalletID"))
                    {
                        if(pll.StorageTypeID.ToString() == StorageType.PickFace)
                        {
                            XtraMessageBox.Show(
                                "You cannot use Internal Movements to move Pick Face Locations. Please use the customize drug list screen.","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        }
                        else if(XtraMessageBox.Show("Are you sure you want to move pallet?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes){
                            //TODO: implement the moving logic here.
                            if (PalletLocation.Move(pll.ID, pl.ID))
                            {
                                lkRackID2_EditValueChanged( new object(), new EventArgs() );
                                gridItemMovementView.RefreshRow( gridItemMovementView.FocusedRowHandle );
                                gridItemDetailByLocation.Refresh();
                            }
                        }
                    }
                }
                selectedPalletLocationID = Convert.ToInt32(gridItemMovementView.FocusedValue);
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            repositoryItemButtonEdit1_DoubleClick(null, null);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridConfirmationView.RowCount; i++)
            {
                DataRow dr = gridConfirmationView.GetDataRow(i);
                dr["IsSelected"] = true;
                dr.EndEdit();
            }
        }

        private void returnToBulkStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataRow dr = gridPickFaceDetailView.GetFocusedDataRow();
            if (dr != null)
            {
                int ReceivePalletID = Convert.ToInt32(dr["ID"]);
                ReceivePallet rp = new ReceivePallet();
                rp.LoadByPrimaryKey(ReceivePalletID);

                ReceiveDoc rd = new ReceiveDoc();
                rd.LoadByPrimaryKey(rp.ReceiveID);

                BLL.ItemManufacturer imf = new BLL.ItemManufacturer();
                imf.LoadIMbyLevel(rd.ItemID, rd.ManufacturerId, rp.BoxSize);

                int QuantityToReturn = Convert.ToInt32(((rp.Balance - rp.ReservedStock) / imf.QuantityInBasicUnit) * imf.QuantityInBasicUnit);
                InternalTransfer itfr = new InternalTransfer();
                
                
            }
        }

        private void tsmSplit_Click(object sender, EventArgs e)
        {
            var pl = new PalletLocation();
            prev = gridItemMovementView.FocusedValue;
            if (gridItemMovementView.FocusedValue != null && prev != DBNull.Value && Convert.ToInt32(gridItemMovementView.FocusedValue)>0)
            {
                pl.LoadByPrimaryKey(Convert.ToInt32(gridItemMovementView.FocusedValue));
                if (prev != DBNull.Value && !pl.IsColumnNull("PalletID"))
                {
                    var sp = new SplitPallet();
                    sp.LoadPalletLocation(pl.PalletID, (int) lkRackID2.EditValue);
                    sp.ShowDialog();
                    lkRackID2_EditValueChanged(new object(), new EventArgs());

                }
            }
        }

        private void splitMenu_Opening(object sender, CancelEventArgs e)
        {
            if (gridItemMovementView.FocusedValue != null && gridItemMovementView.FocusedValue != DBNull.Value &&
                Convert.ToInt32(gridItemMovementView.FocusedValue) > 0)
            {
                var pl = new PalletLocation();
                prev = gridItemMovementView.FocusedValue;
                pl.LoadByPrimaryKey(Convert.ToInt32(gridItemMovementView.FocusedValue));
                if (pl.IsColumnNull("PalletID"))
                {
                    e.Cancel = true;
                }
            }
        }

        private void lkPhysicalStore_EditValueChanged(object sender, EventArgs e)
        {
            StorageType stt = new StorageType();
            stt.LoadDistictStoreTypeForPhysicalStore((int)lkPhysicalStore.EditValue);
            lkStorageType2.Properties.DataSource = stt.DefaultView;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtItemName_EditValueChanged(object sender, EventArgs e)
        {
            gridView5.ActiveFilterString = string.Format("FullItemName like '{0}%'", txtItemName.Text);
          
        }

        private void lkTo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tbManualMovement_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }


}