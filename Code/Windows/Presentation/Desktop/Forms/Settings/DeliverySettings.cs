using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BLL;
using DAL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Forms.Modals;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Settings
{
    [FormIdentifier("PF-DS-DR-FR","Delivery Settings","")]
    public partial class DeliverySettings : XtraForm
    {
        public DeliverySettings()
        {
            InitializeComponent();
        }

        private Route route = new Route();
        private Institution rusForRoute = new Institution();

        private void HospitalSettings_Load(object sender, EventArgs e)
        {
            SetPermissions();
            
            Supplier sup = new Supplier();
            sup.LoadAll();
            PopulateSupplier(sup);

            PopulateStores();

            Shelf slf = new Shelf();
            DataTable dtSlf = slf.GetShelves();
            PopulateShelves(dtSlf.DefaultView);

            LoadIssueLocations();

            AdjustLabelsForHub();
            
        }

        private void LoadIssueLocations()
        {
            Institution recUnit = new Institution();
            recUnit.LoadAllActiveForDeliverySettingsPage();
            PopulateReceivingUnit(recUnit);
        }

        private void SetPermissions()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnAddRoute.Enabled = this.HasPermission("Add-Route");
                btnAddIssueLocation.Enabled = this.HasPermission("Add-Receiving-Unit");
                
                // hack to populate the permission on open
                this.HasPermission("Edit-Receiving-Unit");

            }
        }

        private void AdjustLabelsForHub()
        {
            this.Name = "Hub Settings";

            Route r = new Route();
            r.LoadAll();
            gridRoute.DataSource = r.DefaultView;
        }

        #region  Supplier

        private int supplierId = 0;

        private void PopulateSupplier(Supplier sup)
        {
            lstSuppliers1.DataSource = sup.DefaultView;
        }


        private void xpButton1_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            ResetSupplier();
        }

        private void btnSupplierSave_Click(object sender, EventArgs e)
        {
            if (supplierValidation.Validate())
            {
                Supplier sup = new Supplier();
                if (supplierId != 0)
                    sup.LoadByPrimaryKey(supplierId);
                else
                    sup.AddNew();
                sup.CompanyInfo = cboCompanyInfo.EditValue.ToString();
                sup.CompanyName = txtCompanyName.Text;
                sup.Address = txtAddress.Text;
                sup.ContactPerson = txtContactPerson.Text;
                sup.Telephone = txtTelephone.Text;
                sup.IsActive = ckIsActive.Checked;
                sup.Mobile = txtMobile.Text;
                sup.Email = txtEmail.Text;
                sup.Save();
                sup.LoadAll();
                PopulateSupplier(sup);
                ResetSupplier();
            }
            else
            {
                txtCompanyName.BackColor = Color.FromArgb(251, 214, 214);
            }
        }

        private void ResetSupplier()
        {
            txtCompanyName.Text = "";
            txtAddress.Text = "";
            txtContactPerson.Text = "";
            txtMobile.Text = "";
            txtTelephone.Text = "";
            ckIsActive.Checked = true;
            supplierId = 0;
            cboCompanyInfo.EditValue = "";
            txtEmail.Text = "";
            btnSupplierSave.Text = "Save";
            txtCompanyName.BackColor = Color.White;
        }

        #endregion

        #region Stores

        private int storeId = 0;

        private void PopulateStores()
        {
            Activity str = new Activity();
            str.LoadAll();
            gridStores.DataSource = str.DefaultView;
        }

        private void xpButton8_Click(object sender, EventArgs e)
        {
            ResetStores();
        }

        private void ResetStores()
        {
            txtStore.Text = "";
            txtLocation.Text = "";
            storeId = 0;
            txtStore.BackColor = Color.White;
        }

        #endregion

        #region Shelf

        private int shelfId = 0;

        private void PopulateShelves(DataView dtSlf)
        {
            gridBinLocation.DataSource = dtSlf;

            Activity str = new Activity();
            str.LoadAll();
            cboStore.DataSource = str.DefaultView;
        }


        private void xpButton10_Click(object sender, EventArgs e)
        {
            ResetLocations();
        }

        private void btnSaveShelf_Click(object sender, EventArgs e)
        {
            Shelf slf = new Shelf();
            if (shelfId != 0)
                slf.LoadByPrimaryKey(shelfId);
            else
                slf.AddNew();
            slf.ShelfCode = txtShelf.Text;
            slf.ShelfStorageType = int.Parse(cboType.SelectedItem.ToString());
            slf.Save();
            DataTable dtSlf = slf.GetShelves();
            PopulateShelves(dtSlf.DefaultView);
            ResetLocations();
        }

        private void xpButton11_Click(object sender, EventArgs e)
        {
            ResetLocations();
        }

        private void ResetLocations()
        {
            txtShelf.Text = "";
            txtPhyStore.Text = "";
            shelfId = 0;
            cboStore.SelectedIndex = -1;
            cboType.SelectedIndex = 3;
            btnLocationsave.Text = "Save";
        }

        #endregion

        #region Receiving Unit

        private int receivingUnitId = 0;
        private bool isAddingNew;

        private void PopulateReceivingUnit(Institution recUnit)
        {
            gridReceivingUnit.DataSource = recUnit.DefaultView;
        }

        
        #endregion

        private void txtCompanyName_TextChanged(object sender, EventArgs e)
        {
            txtCompanyName.BackColor = Color.White;
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            txtRouteName.Text = "";
            route.AddNew();
            gridReceivingUnits.DataSource = null;
            btnAddRoute.Enabled = false;
        }


        private void btnSaveRoute_Click(object sender, EventArgs e)
        {
            if (routeValidation.Validate())
            {
                if (route.RowCount == 0)
                {
                    route.AddNew();
                }

                route.Name = txtRouteName.Text;
                route.Save();

                if (rusForRoute.RowCount > 0)
                {
                    rusForRoute.Save();
                }
                Route r = new Route();
                r.LoadAll();
                gridRoute.DataSource = r.DefaultView;

                btnAddRoute.Enabled = (BLL.Settings.UseNewUserManagement) ? this.HasPermission("Add-Route") : true;


                XtraMessageBox.Show("Your changes have been saved.", "Confirmation", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void gridView1_FocusedRowChanged(object sender,
                                                 DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();

            int selected = Convert.ToInt32(dr["ID"]);
            Supplier sup = new Supplier();
            sup.LoadByPrimaryKey(selected);
            txtCompanyName.Text = sup.CompanyName;
            txtAddress.Text = sup.Address;
            txtContactPerson.Text = sup.ContactPerson;
            txtMobile.Text = sup.Mobile;
            txtTelephone.Text = sup.Telephone;
            txtEmail.Text = sup.Email;
            ckIsActive.Checked = sup.IsActive;
            supplierId = sup.ID;
            cboCompanyInfo.EditValue = sup.CompanyInfo;

            btnSupplierSave.Text = "Update";
        }

        private void gridBinLocationView_FocusedRowChanged(object sender,
                                                           DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridBinLocationView.GetFocusedDataRow();

            if (dr != null)
            {
                int selected = Convert.ToInt32(dr["ID"]);
                Shelf slf = new Shelf();
                slf.LoadByPrimaryKey(selected);
                if (slf.RowCount > 0)
                {
                    txtShelf.Text = slf.ShelfCode;
                    if (!slf.IsColumnNull("StoreID"))
                        cboStore.SelectedValue = slf.StoreID.ToString();
                    if (!slf.IsColumnNull("ShelfStorageType"))
                    {
                        cboType.SelectedValue = slf.ShelfStorageType;
                    }
                    shelfId = slf.ID;
                }
                btnLocationsave.Text = "Update";
            }
        }

        private void gridViewRoutes_FocusedRowChanged(object sender,
                                                      DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridViewRoutes.GetFocusedDataRow();
            route.LoadByPrimaryKey(Convert.ToInt32(dr["RouteID"]));
            txtRouteName.Text = route.Name;
            btnAddRoute.Enabled = !BLL.Settings.UseNewUserManagement || this.HasPermission("Add-Route");
            rusForRoute.GetAllUnderRoute(route.RouteID);
            gridReceivingUnits.DataSource = rusForRoute.DefaultView;
        }

        private void gridStoresView_FocusedRowChanged(object sender,
                                                      DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridStoresView.GetFocusedDataRow();
            if (dr != null)
            {
                int selected = Convert.ToInt32(dr["ID"]);
                var activity = new Activity();
                activity.LoadByPrimaryKey(selected);
                txtStore.Text = activity.Name;
                txtStoreType.Text = activity.AccountName;
                storeId = activity.ID;
            }
        }
        

        private void btnCancelSupplier_Click(object sender, EventArgs e)
        {
            //TODO: implement cancel supplier actions here
        }

        private void txtRUNameFilter_EditValueChanged(object sender, EventArgs e)
        {
            gridReceivingUnitView.ActiveFilterString = "[Name] Like '" + txtRUNameFilter.Text + "%'";
        }
        
        private void repositoryItemChkUsesMovingAvg_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridStoresView.GetFocusedDataRow();
            int selected = Convert.ToInt32(dr["ID"]);
            Activity str = new Activity();
            str.LoadByPrimaryKey(selected);
            str.Save();
            PopulateStores();
        }

        private void gridReceivingUnitView_DoubleClick(object sender, EventArgs e)
        {
            var dr = gridReceivingUnitView.GetFocusedDataRow();
            int receivingUnitID = Convert.ToInt32(dr["ID"]);

            Modals.ReceivingUnitsDetails recDetail = new ReceivingUnitsDetails(receivingUnitID);
            recDetail.ShowDialog();
            LoadIssueLocations();

        }

        private void btnAddIssueLocation_Click(object sender, EventArgs e)
        {
            Modals.ReceivingUnitsDetails recDetail = new ReceivingUnitsDetails();
            var result = recDetail.ShowDialog();
            LoadIssueLocations();
        }




    }
}