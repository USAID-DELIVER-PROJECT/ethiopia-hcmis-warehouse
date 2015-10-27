using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BLL;
using DevExpress.XtraLayout.Utils;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class ReceivingUnitsDetails : DevExpress.XtraEditors.XtraForm
    {
        public ReceivingUnitsDetails()
        {
            InitializeComponent();
        }
        public ReceivingUnitsDetails(int ReceivingUnitID)
        {
            InitializeComponent();
            ID = ReceivingUnitID;

        }
        int ID = -1;
        private int receivingUnitId = 0;
      
        private void ReceivingUnitsDetails_Load(object sender, EventArgs e)
        {
            LoadReceivingUnits();
           
            if (ID != -1)
            {
                

                lcExistingInstitutions.Visibility = LayoutVisibility.Never;
                lcIsUsedInFacility.Visibility = LayoutVisibility.Always;

                int selected = ID;
                Institution recUnit = new Institution();
                recUnit.LoadByPrimaryKey(selected);
                txtReceivingUnit.Text = recUnit.IsColumnNull("Name") ? "" : recUnit.Name;;
                txtReceivingUnit.Enabled = false;
                txtDescription.Text = recUnit.IsColumnNull("Description") ? "" : recUnit.Description;
                txtPhone.Text = recUnit.IsColumnNull("Phone") ? "" : recUnit.Phone;
                
                if (!recUnit.IsColumnNull("Ownership"))
                    lkOwnership.EditValue = recUnit.Ownership;
                if (!recUnit.IsColumnNull("RUType"))
                    lkRUType.EditValue = recUnit.RUType;
                txtLicenseNo.Text = recUnit.IsColumnNull("LicenseNo") ? "" : recUnit.LicenseNo;
                txtVATNo.Text = recUnit.IsColumnNull("VATNo") ? "" : recUnit.VATNo;
                txtTinNo.Text = recUnit.IsColumnNull("TinNo") ? "" : recUnit.TinNo;
                
                chkIsInstitutionUsedAtFacility.Checked = recUnit.IsColumnNull("IsUsedAtFacility") ? false : recUnit.IsUsedAtFacility;
                dtRegistration.Value = recUnit.IsColumnNull("DateOfRegistration") ? DateTimeHelper.ServerDateTime : recUnit.DateOfRegistration;
                if (!recUnit.IsColumnNull("Woreda"))
                {
                    BLL.Woreda woreda = new Woreda();
                    woreda.LoadByPrimaryKey(recUnit.Woreda);

                    BLL.Zone zone = new Zone();
                    zone.LoadByPrimaryKey(woreda.ZoneID);

                    BLL.Region region = new BLL.Region();
                    region.LoadByPrimaryKey(zone.RegionId);

                    lkRegion.EditValue = region.ID;

                    lkZone.Properties.DataSource = BLL.Zone.GetZoneByRegion(region.ID).DefaultView;
                    lkZone.EditValue = zone.ID;

                    Woreda.GetWoredaByZone(zone.ID);
                    lkWoreda.Properties.DataSource = woreda.DefaultView;
                    lkWoreda.EditValue = recUnit.Woreda;
                }
                else if (!recUnit.IsColumnNull("Zone")) //We allow the Woreda to be empty so, let's check the zone now.
                {
                    BLL.Zone zone = new Zone();
                    zone.LoadByPrimaryKey(recUnit.Zone);

                    BLL.Region region = new BLL.Region();
                    region.LoadByPrimaryKey(zone.RegionId);

                    lkRegion.EditValue = region.ID;

                    lkZone.Properties.DataSource = BLL.Zone.GetZoneByRegion(region.ID).DefaultView;
                    lkZone.EditValue = zone.ID;
                }
                else
                {
                    lkRegion.EditValue = null;
                    lkZone.EditValue = null;
                    lkWoreda.EditValue = null;
                }

                Route r = new Route();
                r.LoadAll();
                lkRoute.Properties.DataSource = r.DefaultView;

                lkRoute.EditValue = (recUnit.IsColumnNull("Route")) ? 0 : recUnit.Route;
                receivingUnitId = recUnit.ID;

                bool isItDraft = !recUnit.IsColumnNull("IsDraft") && recUnit.IsDraft &&
                                 (BLL.Order.GetTotalForAnInstitution(recUnit.ID) == 0);
                    
                lkRegion.Enabled = isItDraft;
                lkZone.Enabled = isItDraft;
                lkWoreda.Enabled = isItDraft;
                lkRUType.Enabled = isItDraft;
                lkOwnership.Enabled = isItDraft;
                txtReceivingUnit.Enabled = isItDraft;

            }
            else
            {
                lcExistingInstitutions.Visibility=LayoutVisibility.Always;
                lcIsUsedInFacility.Visibility = LayoutVisibility.Never;
            }

            
            
        }

private void LoadReceivingUnits()
{
            BLL.Region reg = new BLL.Region();
            reg.LoadAll();
            lkRegion.Properties.DataSource = reg.DefaultView;

            BLL.InstitutionType ruType = new InstitutionType();
            ruType.Where.IsActive.Value = 1;
            ruType.Query.Load();
            lkRUType.Properties.DataSource = ruType.DefaultView;

            BLL.OwnershipType ownershipType = new OwnershipType();
            ownershipType.LoadAll();
            lkOwnership.Properties.DataSource = ownershipType.DefaultView;

            Route r = new Route();
            r.LoadAll();
            lkRoute.Properties.DataSource = r.DefaultView;	
}
         
       
        private void lkOwnership_EditValueChanged(object sender, EventArgs e)
        {
            if (lkOwnership.EditValue == null)
                return;

            bool isPrivate = BLL.OwnershipType.IsPrivate(int.Parse(lkOwnership.EditValue.ToString()));

            if (isPrivate)
            {
                groupPrivateDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                groupPrivateDetail.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void lkRegion_EditValueChanged(object sender, EventArgs e)
        {
            LoadZones();
            LoadWoredas();
        }

        private void lkZone_EditValueChanged(object sender, EventArgs e)
        {
            LoadWoredas();
        }

        private void btnIssueSave_Click(object sender, EventArgs e)
        {
              // do the validation here
            if (issueLocationValidation.Validate())
            {
                Institution recUnit = new Institution();

                if (ID != -1) //This is not new.
                {
                    recUnit.LoadByPrimaryKey(receivingUnitId);
                    recUnit.IsUsedAtFacility = chkIsInstitutionUsedAtFacility.Checked;
                }
                else
                {
                    recUnit.AddNew();
                    recUnit.IsDraft = true; //If it is locally added, we mark it as draft until confirmed centrally.
                    recUnit.Active = true;
                    recUnit.IsUsedAtFacility = true;
                    recUnit.IsLocalSite = true;
                    recUnit.OperationalStatus = true;
                    recUnit.Rowguid = Guid.NewGuid();
                    recUnit.NUrowguid = Guid.NewGuid();
                    recUnit.ModifiedBy = CurrentContext.LoggedInUser.ID.ToString();
                    recUnit.ModifiedDate = DateTimeHelper.ServerDateTime;
                    recUnit.SN = 1; //Saving default value here.  The actual value to come from the directory services.
                }

                recUnit.Name = txtReceivingUnit.Text;
                recUnit.Phone = txtPhone.Text;
                recUnit.Description = txtDescription.Text;
                recUnit.Route = Convert.ToInt32(lkRoute.EditValue);
                recUnit.Ownership = Convert.ToInt32(lkOwnership.EditValue);
                recUnit.RUType = Convert.ToInt32(lkRUType.EditValue);
                
                if (lkWoreda.EditValue != null) recUnit.Woreda = int.Parse(lkWoreda.EditValue.ToString());
                if (lkZone.EditValue != null) recUnit.Zone = int.Parse(lkZone.EditValue.ToString());

                if (BLL.OwnershipType.IsPrivate(recUnit.Ownership))
                {
                    if (string.IsNullOrEmpty(txtLicenseNo.Text))
                    {
                        XtraMessageBox.Show("Please fill in the license number!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    recUnit.LicenseNo = txtLicenseNo.Text;
                    recUnit.VATNo = txtVATNo.Text;
                    recUnit.TinNo = txtTinNo.Text;
                    recUnit.DateOfRegistration = dtRegistration.Value;
                }
                if (ID == -1)
                {
                    if (XtraMessageBox.Show(string.Format("Are you sure you want to add a new Receiving Unit", recUnit.Name.ToString()), "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        recUnit.Save();
                        this.Close();
                    }
                }
                else if (XtraMessageBox.Show(string.Format("Are you sure you want to save change to {0}", recUnit.Name.ToString()), "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                        recUnit.Save();
                        this.Close();
                }   
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadZones()
        {
            //Clear Zone Selection
            lkZone.EditValue = null;
            // Bind the Zone Lookup
            DataView zone = Zone.GetZoneByRegion(Convert.ToInt32(lkRegion.EditValue)).DefaultView;
            lkZone.Properties.DataSource = zone;
            //check if Zone Lookup Has 
            if (zone.ToTable().Rows.Count != 0)
                lkWoreda.Properties.NullText = " Select Zone";
            else
                lkWoreda.Properties.NullText = "";
        }

        private void LoadWoredas()
        {
            //Clear Zone Selection
            lkWoreda.EditValue = null;
            //Bind the Woreda Lookup

            DataView woreda = Woreda.GetWoredaByZone(Convert.ToInt32(lkZone.EditValue)).DefaultView;
            lkWoreda.Properties.DataSource = woreda; ;

            if (woreda.ToTable().Rows.Count != 0)

                lkWoreda.Properties.NullText = " Select Woreda";
            else
                lkWoreda.Properties.NullText = "";
        }

        private void lkWoreda_EditValueChanged(object sender, EventArgs e)
        {
            var woredaID = Convert.ToInt32(lkWoreda.EditValue);
            var institutions = BLL.Institution.LoadReceivingUnitByFilter(woredaID);
            
            institutions.AddNew();
            institutions.SetColumn("InstitutionName", "-Issue location not listed-");

            lkExistingInstitutions.Properties.DataSource = institutions.DefaultView;
        }

        private void lkExistingInstitutions_EditValueChanged(object sender, EventArgs e)
        {
            bool institutionNotHere = lkExistingInstitutions.EditValue.ToString().Equals("-Issue location not listed-");
            txtReceivingUnit.Enabled = institutionNotHere;
            if(institutionNotHere)
            {
                txtReceivingUnit.Text = String.Empty;
            }

        }
        

    }
}