using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;

namespace HCMIS.Desktop.Modals
{
    public partial class SplitPallet : XtraForm
    {
        PalletLocation _pl;
        ReceivePallet _rpl;
        Item _itm;
        public SplitPallet()
        {
            InitializeComponent();
        }

        public void LoadPalletLocation(int palletId,int shlefId=0)
        {
            _pl = new BLL.PalletLocation();
            _pl.loadByPalletID(palletId);

            txtPalletLocation.Text = _pl.FullName;
            lblStorageType.Text = _pl.FullName;

            _rpl = new BLL.ReceivePallet();
            gridMovement.DataSource = _rpl.GetPalletLocationReadyForMovement( palletId );

            _itm = new BLL.Item();
            _itm.LoadByPrimaryKey(Convert.ToInt32(_rpl.GetColumn("ItemID")));
            txtItemName.Text = _itm.FullItemName;
            lblItemName.Text = _itm.FullItemName;

            lkFreePalletLocations.Properties.DataSource = BLL.PalletLocation.GetAllFreeFor(_itm.ID, shlefId);
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            // Validation 
            foreach (DataRowView drv in _rpl.DefaultView)
            {
                int Balance = Convert.ToInt32(drv["Balance"]);
                int splited = Convert.ToInt32(drv["BalanceToMove"]);
                if (Balance < splited)
                {
                    XtraMessageBox.Show("Couldn't split to the numbers you specified. Please specify number less than the balance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // validate the selected pallet location
            if (lkFreePalletLocations.EditValue == null)
            {
                XtraMessageBox.Show("Please select a valid destination pallet location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //
            

            PalletLocation destinationPalletLocatin = new PalletLocation();
            destinationPalletLocatin.LoadByPrimaryKey(Convert.ToInt32(lkFreePalletLocations.EditValue));
            if (destinationPalletLocatin.IsColumnNull("PalletID"))//The Pallet Location is empty
            {
                Pallet pallet = new Pallet();
                pallet.AddNew();
                pallet.Save();
                destinationPalletLocatin.PalletID = pallet.ID;
                destinationPalletLocatin.Save();
            }
            // THIS HAS BEEN REMOVED AS PER RUTH'S SUGGESTION THAT: THE SYSTEM SHOULD NOT BLOCK IF THE WAREHOUSE MANAGER WANTES TO USE 
            //else if (destinationPalletLocatin.StorageTypeID.ToString() != BLL.StorageType.Free) //If the pallet location is not empty and it is not free storage, you can't put more on it.
            //{
            //    // the thingy has not been moved
            //    XtraMessageBox.Show("The selected Pallet location is not Empty. Please select another location.", "Error splitting");
            //    return;
            //}

            foreach (DataRowView drv in _rpl.DefaultView)
            {
                int balanceToMove = Convert.ToInt32(drv["BalanceToMove"]);
                int qtyPerPack = Convert.ToInt32(drv["QtyPerPack"]);
                balanceToMove *= qtyPerPack;
                if (balanceToMove > 0)
                {
                    ReceivePallet rpSource = new ReceivePallet();
                    ReceivePallet rpDestination = new ReceivePallet();
                    
                    rpSource.LoadByPrimaryKey(Convert.ToInt32(drv["ID"]));
                    
                    rpDestination.AddNew();

                    //rpDestination.Balance = balanceToMove;//
                    if (!rpSource.IsColumnNull("BoxSize"))
                    {
                        rpDestination.BoxSize = rpSource.BoxSize;
                    }
                    else
                    {
                        rpDestination.BoxSize = 1;
                    }
                    rpDestination.ReceivedQuantity = balanceToMove;
                    rpDestination.PalletID = destinationPalletLocatin.PalletID;//pallet.ID;
                    rpDestination.PalletLocationID = destinationPalletLocatin.ID;
                    rpDestination.ReceiveID = rpSource.ReceiveID;
                    if (!rpSource.IsColumnNull("ReceivedQuantity"))
                        rpSource.ReceivedQuantity -= balanceToMove;
                    //rpSource.Balance -= balanceToMove;//

                    rpDestination.ReservedStock = 0;
                    rpDestination.IsOriginalReceive = false;
                    BLL.ReceivePallet.MoveBalance(rpSource, rpDestination, balanceToMove);
                    //rpSource.Save();
                    //rpDestination.Save();
                }
            }
            XtraMessageBox.Show("The pallet was split.", "Success");
            this.Close();
        }

        private void SplitPallet_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
