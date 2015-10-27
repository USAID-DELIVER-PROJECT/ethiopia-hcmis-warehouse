using System;
using System.Data;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Helpers;

namespace HCMIS.Desktop
{
    [FormIdentifier("AD-UA-MU-FR","User Accounts","")]
    public partial class UserAccounts : XtraForm
    {
        public UserAccounts()
        {
            InitializeComponent();
        }
        int userId = 0;


        private void UserAccounts_Load(object sender, EventArgs e)
        {
            PopulateUser();
        }

        private void PopulateUser()
        {
            User us = new User();
            gridUsers.DataSource = us.GetUsers();

            UserType uType = new UserType();
            uType.LoadAllButSysAdmin();
            cboUserType.DataSource = uType.DefaultView;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isNew = false;
            if (txtConfirm.Text == txtPassword.Text && cboUserType.SelectedValue != null)
            {
                User us = new User();
                if (userId != 0)
                {
                    us.LoadByPrimaryKey(userId);
                }
                else
                {
                    us.AddNew();
                    isNew = true;
                }

                us.UserName = txtUsername.Text;
                us.FullName = txtFullName.Text;
                us.Address = txtAddress.Text;
                us.Mobile = txtMobile.Text;
                us.Active = ckActive.Checked;
                us.UserType = Convert.ToInt32(cboUserType.SelectedValue);
                us.Save();
                int userID = us.ID;
                // DO MD5
                if (txtPassword.Text != "")
                {
                    us.SavePassword(txtPassword.Text);
                }

                RefreshUserStoreGrid(userID);
                PopulateUser();
                XtraMessageBox.Show("Your changes have been saved!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show("Password doesnt match or you didnt select User Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            userId = 0;
            txtPassword.Text = "";
            txtConfirm.Text = "";
            txtFullName.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtUsername.Text = "";
            ckActive.Checked = true;
            cboUserType.SelectedIndex = -1;
        }

        private void gridUserView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridUserView.GetFocusedDataRow();

            if (dr != null)
            {
                int selected = Convert.ToInt32(dr["ID"]);
                User us = new User();
                us.LoadByPrimaryKey(selected);
                txtFullName.Text = us.FullName;
                txtAddress.Text = us.Address;
                txtMobile.Text = us.Mobile;
                ckActive.Checked = us.Active;
                cboUserType.SelectedValue = us.UserType.ToString();
                txtUsername.Text = us.UserName;

                userId = us.ID;
                RefreshUserStoreGrid(us.ID);
                RefreshUserPhysicalStoreGrid(us.ID);
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridViewUserStoreMatrix.GetFocusedDataRow();
            int ID = int.Parse(dr["ID"].ToString());
            BLL.UserActivity userStore = new UserActivity();
            userStore.LoadByPrimaryKey(ID);
            userStore.CanAccess = !userStore.CanAccess;
            userStore.Save();
            RefreshUserStoreGrid(userStore.UserID);
        }

        private void RefreshUserStoreGrid(int userID)
        {
            BLL.Activity stores=new Activity();
            stores.LoadAll();
            BLL.UserActivity userStore = new UserActivity();
            userStore.LoadByUserID(userID);
            if (userStore.RowCount == 0)
            {
                BLL.UserActivity usrStore = new UserActivity();
                usrStore.GenerateMatrixForANewUser(userID);
                RefreshUserStoreGrid(userID);
            }
            else if (userStore.RowCount == stores.RowCount)
            {
                grdUserStoreMatrix.DataSource = userStore.DefaultView;
                lcUserStoreMatrix.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                BLL.UserActivity usrStore = new UserActivity();
                usrStore.RenewMatrixForAUser(userID);
                RefreshUserStoreGrid(userID);
            }
        }

        private void repositoryItemCheckEditIsDefault_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridViewUserStoreMatrix.GetFocusedDataRow();
            int ID = int.Parse(dr["ID"].ToString());
            BLL.UserActivity userStore = new UserActivity();
            userStore.LoadByPrimaryKey(ID);
            userStore.MakeDefault();
            RefreshUserStoreGrid(userStore.UserID);
        }

        private void RefreshUserPhysicalStoreGrid(int userID)
        {
            BLL.PhysicalStore phyStores = new PhysicalStore();
            phyStores.LoadAll();
            BLL.UserPhysicalStore userPhyStore = new UserPhysicalStore();
            userPhyStore.LoadAllEntriesByUserID(userID);

            if (BLL.UserPhysicalStore.DoesItNeedToBeRefreshed(userID))
            {
                BLL.UserPhysicalStore usrPhyStore = new UserPhysicalStore();
                usrPhyStore.RenewMatrixForAUser(userID);
                
            }

            if (userPhyStore.RowCount == 0)
            {
                BLL.UserPhysicalStore usrPhyStore = new UserPhysicalStore();
                usrPhyStore.GenerateMatrixForANewUser(userID);
                RefreshUserPhysicalStoreGrid(userID);
            }
            else if (userPhyStore.RowCount >= phyStores.RowCount)
            {
                grdUserPhysicalStoreMatrix.DataSource = userPhyStore.DefaultView;
                lcUserPhysicalStoreMatrix.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                BLL.UserPhysicalStore usrStore = new UserPhysicalStore();
                usrStore.RenewMatrixForAUser(userID);
                RefreshUserPhysicalStoreGrid(userID);
            }
        }

        private void repoItemChkPhysicalStoreAllowed_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridViewUserPhysicalStoreMatrix.GetFocusedDataRow();
            int ID = int.Parse(dr["ID"].ToString());
            BLL.UserPhysicalStore userPhyStore = new UserPhysicalStore();
            userPhyStore.LoadByPrimaryKey(ID);
            userPhyStore.CanAccess = !userPhyStore.CanAccess;
            userPhyStore.Save();
            RefreshUserPhysicalStoreGrid(userPhyStore.UserID);
        }

        private void repoItemChkPhysicalStoreDefault_CheckedChanged(object sender, EventArgs e)
        {
            DataRow dr = gridViewUserPhysicalStoreMatrix.GetFocusedDataRow();
            int ID = int.Parse(dr["ID"].ToString());
            BLL.UserPhysicalStore userPhyStore = new UserPhysicalStore();
            userPhyStore.LoadByPrimaryKey(ID);
            userPhyStore.MakeDefault();
            RefreshUserPhysicalStoreGrid(userPhyStore.UserID);
        }


    }
}
