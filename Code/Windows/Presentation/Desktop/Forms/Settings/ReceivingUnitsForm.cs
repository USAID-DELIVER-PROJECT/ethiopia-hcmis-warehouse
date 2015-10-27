using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Forms.Modals;

namespace HCMIS.Desktop.Forms.Settings
{
    public partial class ReceivingUnitsForm : DevExpress.XtraEditors.XtraForm
    {
        #region Declaration

        private int regionId = 0;
        private int woredaID = 0;
        private int zoneID = 0;
        private int ruType = 0;
        private int ownershipType = 0;
        private int activeStatus = 0;
        
        #endregion

        #region Initialization and Binding
        
        public ReceivingUnitsForm()
        {
            InitializeComponent();
            regionId = GeneralInfo.Current.Region;
            ruType = InstitutionType.Constants.HEALTH_CENTER;
            ownershipType = OwnershipType.Constants.Public;
        }
       
        public ReceivingUnitsForm( int regionId, int woredaID, int zoneID,int  ruType, int ownershipType,int activeStatus)
        {
            InitializeComponent();
            this.regionId = regionId;
            this.woredaID = woredaID;
            this.zoneID = zoneID;
            this.ruType = ruType;
            this.ownershipType = ownershipType;
            this.activeStatus = activeStatus;
        }

        private void BindFormElements()
        {
            //Bind the Region Lookup (Zone and Woredas will be bind after selection Region)
            lkRegion.Properties.DataSource = BLL.Region.GetAllRegions().DefaultView;
            lkRegion.EditValue = regionId;

            //Bind the Receiving units Types Lookup
            InstitutionType institutionsTypes = new InstitutionType();
            institutionsTypes.LoadAll();
            institutionsTypes.Sort = "Name ASC";
            lkType.Properties.DataSource = institutionsTypes.DefaultView;
            lkType.EditValue = ruType;

            //Bind the Ownership Type Lookup
            OwnershipType ownershipTypes = new OwnershipType();
            ownershipTypes.LoadAll();
            ownershipTypes.Sort = "Name ASC";
            lkOwnership.Properties.DataSource = ownershipTypes.DefaultView;
            lkOwnership.EditValue = OwnershipType.Constants.Public;

            //Bind the Active lookup
            lkActive.Properties.ValueMember = lkActive.Properties.DisplayMember = "Column";
            lkActive.Properties.DataSource = new string[3] { "All", "Active", "InActive" };
            lkActive.ItemIndex = 0;
            
            //Bind the others
            LoadZones();
            lkZone.EditValue = zoneID;

            LoadWoredas();
            lkWoreda.EditValue = woredaID;

            LoadReceivingUnits();
        }
        #endregion
    
        #region Load Functions

        private void LoadZones()
        {
            //Clear Zone Selection
            lkZone.EditValue = null;
            // Bind the Zone Lookup
            DataTable zone = Zone.GetZoneByRegionAndNumberRU(Convert.ToInt32(lkRegion.EditValue));
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

            DataTable woreda = Woreda.GetWoredaByZoneAndNumberRU(Convert.ToInt32(lkZone.EditValue));
            lkWoreda.Properties.DataSource = woreda.DefaultView; ;

            if (woreda.Rows.Count != 0)

                lkWoreda.Properties.NullText = " Select Woreda";
            else
                lkWoreda.Properties.NullText = "";
        }

        private void LoadReceivingUnits()
        {
            int ActiveStatus;
            int woredaID = Convert.ToInt32(lkWoreda.EditValue);
            int zoneID = Convert.ToInt32(lkZone.EditValue);
            int ruType = Convert.ToInt32(lkType.EditValue);
            int ownershipType = Convert.ToInt32(lkOwnership.EditValue);
            if (lkActive.Text.ToString().Equals("Active"))
                ActiveStatus = 1;
            else if (lkActive.Text.ToString().Equals("InActive"))
                ActiveStatus = 0;
            else
                ActiveStatus = -1;
            grdReceivingUnit.DataSource = BLL.Institution.LoadReceivingUnitByFilter(woredaID, zoneID, ruType, ownershipType, ActiveStatus, false,false).DefaultView;
            //if ((lkZone.EditValue == null) || (lkWoreda.EditValue == null))
            //{
            //    btnAddReceivingUnit.Enabled = false;
            //}
            //else
            //{
            //    btnAddReceivingUnit.Enabled = true;
            //}



        } 
        
        private void ReceivingUnitsForm_Load(object sender, EventArgs e)
        {
            BindFormElements();
        }

        #endregion

        #region Filter Events
        private void lkZone_EditValueChanged(object sender, EventArgs e)
        {
            LoadWoredas();
        }

        private void lkWoreda_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
        }

        private void lkRegion_EditValueChanged(object sender, EventArgs e)
        {
            LoadZones();
            LoadWoredas();
            LoadReceivingUnits();
        }

        private void lkOwnership_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
        }

        private void lkType_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
        }

        private void lkActive_EditValueChanged(object sender, EventArgs e)
        {
            LoadReceivingUnits();
        }

        private void txtRUNameFilter_EditValueChanged(object sender, EventArgs e)
        {

            grdReceivingUnit.DataSource = Institution.LoadReceivingUnitByFilter(txtRUNameFilter.Text).DefaultView;
            //  PopulateReceivingUnit(recUnit);
      
        }

        private void txtRUNameFilter_Properties_Enter(object sender, EventArgs e)
        {

        }

        private void txtRUNameFilter_Enter(object sender, EventArgs e)
        {
            grdReceivingUnit.DataSource = Institution.LoadReceivingUnitByFilter(txtRUNameFilter.Text).DefaultView;  
          //  PopulateReceivingUnit(recUnit);

        }
        #endregion

        private void grdReceivingUnit_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = grdViewReceivingUnit.GetFocusedDataRow();
            if (dr != null)
            {
                int itemId = Convert.ToInt32(dr["ID"]);
                ReceivingUnitsDetails con = new ReceivingUnitsDetails(itemId);
                con.ShowDialog();
            }
        }

        private void btnAddReceivingUnit_Click(object sender, EventArgs e)
        {
            if (this.Modal)
            {
                this.Hide();
                ReceivingUnitsDetails con = new ReceivingUnitsDetails(-1);
                con.ShowDialog();
                this.Show();   
            }
            else
            {
                ReceivingUnitsDetails con = new ReceivingUnitsDetails(-1);
                con.ShowDialog();
            }
        }

        private void grdViewClientStatus_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.RowCount != 0) return;

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

            e.Graphics.DrawString("No records found, please use filter...", e.Appearance.Font, SystemBrushes.ControlDark,
        new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);

        }
    }
}