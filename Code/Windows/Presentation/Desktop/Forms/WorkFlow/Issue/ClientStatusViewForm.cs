using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using HCMIS.Desktop.Forms.Settings;


namespace HCMIS.Desktop.Forms.WorkFlow
{
    public partial class ClientStatusViewForm : DevExpress.XtraEditors.XtraForm
    {

        #region Initialization and Binding
          
            public ClientStatusViewForm()
            {
                InitializeComponent();
            }

            private void ClientStatusViewForm_Load(object sender, EventArgs e)
            {
                BindFormElements();
            }

            private void BindFormElements()
            {
                //Bind the Region Lookup (Zone and Woredas will be bind after selection Region)
                lkRegion.Properties.DataSource = BLL.Region.GetAllRegions().DefaultView;
                lkRegion.EditValue = GeneralInfo.Current.Region;
            
                //Bind the Receiving units Types Lookup
                InstitutionType institutionsTypes = new InstitutionType();
                institutionsTypes.LoadAll();
                institutionsTypes.Sort = "Name ASC";
                lkType.Properties.DataSource = institutionsTypes.DefaultView;
                lkType.EditValue = InstitutionType.Constants.HEALTH_CENTER;
               
                //Bind the Ownership Type Lookup
                OwnershipType ownershipTypes = new OwnershipType();
                ownershipTypes.LoadAll();
                ownershipTypes.Sort = "Name ASC";
                lkOwnership.Properties.DataSource = ownershipTypes.DefaultView;
                lkOwnership.EditValue = OwnershipType.Constants.Public;

                //Bind the Active lookup
                lkActive.Properties.ValueMember = lkActive.Properties.DisplayMember = "Column";
                lkActive.Properties.DataSource = new string[3] { "All", "Active", "InActive"};
                lkActive.ItemIndex = 0;
                LoadReceivingUnits();
                }

        #endregion

        #region Filter Events
            
            private void lkRegion_EditValueChanged(object sender, EventArgs e)
            {
                LoadZones();
                LoadWoredas();
                LoadReceivingUnits();
           
            }

            private void lkZone_EditValueChanged(object sender, EventArgs e)
            {
                LoadWoredas();
            }

            private void lkOwnership_EditValueChanged(object sender, EventArgs e)
            {
                LoadReceivingUnits();
                grdClientStatus.Focus();
            }

            private void lkWoreda_EditValueChanged(object sender, EventArgs e)
            {
                LoadReceivingUnits();
                LoadOwnership();
                LoadRUType();
            
            }

            private void LoadOwnership()
            {
 
            }

            private void LoadRUType()
            {
     
            }
         

            private void lkType_EditValueChanged(object sender, EventArgs e)
            {
                LoadReceivingUnits();
            
            }

            private void lkActive_EditValueChanged(object sender, EventArgs e)
            {
                LoadReceivingUnits();
            }
        
            private void chkEditShowInProcess_CheckedChanged(object sender, EventArgs e)
            {
                LoadReceivingUnits();
            }

        #endregion

        #region Other Events
            
            private void chkEditInprocess_CheckedChanged(object sender, EventArgs e)
            {
                DataRow dr = grdViewClientStatus.GetFocusedDataRow();
                int id = Convert.ToInt32(dr["ID"]);
                BLL.Institution ru = new BLL.Institution();
                ru.LoadByPrimaryKey(id); 
                bool PreviousValue;
                if (!dr.IsNull("InProcess"))
                    PreviousValue = Convert.ToBoolean(dr["InProcess"]);
                else
                    PreviousValue = false;
                if (!Convert.ToBoolean(dr["Active"]))
                {
                    ru.InProcess = PreviousValue;
                    LoadReceivingUnits();
                    XtraMessageBox.Show(string.Format("The {0} is inactive, you are not allow to change any status", dr["Name"].ToString().ToUpper()), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (XtraMessageBox.Show(string.Format("Are you sure you want to allow {0} to get service ", dr["Name"].ToString()), "Are you Sure", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    ru.InProcess = !PreviousValue;
                    ru.Save();
                }
                else
                ru.InProcess = PreviousValue;
                LoadReceivingUnits();
            
            }

            private void grdViewClientStatus_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Return)
                {
                    chkEditInprocess_CheckedChanged(sender, e);
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

        #endregion 

        #region Load Functions
    
            private void LoadZones()
            {
                //Clear Zone Selection
                lkZone.EditValue = null;
                // Bind the Zone Lookup
                DataTable zone =  Zone.GetZoneByRegionAndNumberRU(Convert.ToInt32(lkRegion.EditValue));
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
                lkWoreda.Properties.DataSource = woreda.DefaultView;;
            
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
                Boolean Inprocess = Convert.ToBoolean(chkEditShowInProcess.Checked);
                grdClientStatus.DataSource = BLL.Institution.LoadReceivingUnitByFilter(woredaID, zoneID, ruType, ownershipType,ActiveStatus,Inprocess,false).DefaultView;
                if((lkZone.EditValue == null)|| (lkWoreda.EditValue == null))
                {
                    btnAddReceivingUnit.Enabled = false;
                }
                else
                {
                    btnAddReceivingUnit.Enabled = true;
                }



            }
        #endregion

        private void btnAddReceivingUnit_Click(object sender, EventArgs e)
            {
                int ActiveStatus;
                int regionId = Convert.ToInt32(lkRegion.EditValue);
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
             //   ReceivingUnitsForm con = new ReceivingUnitsForm(regionId, woredaID, zoneID, ruType, ownershipType, ActiveStatus);
             //   con.ShowDialog();
                Institution recUnit = new Institution();
                recUnit.LoadAll();
                LoadReceivingUnits();
            }

    }
}