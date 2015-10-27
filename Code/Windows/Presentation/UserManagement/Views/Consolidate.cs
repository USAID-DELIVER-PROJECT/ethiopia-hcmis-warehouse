using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.DataContext;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;
using HCMIS.Security.UserManagement.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    public partial class Consolidate : XtraForm
    {
        private int _userID;
        private IUnitOfWork repository;
        private User CurrentUser;
        public Consolidate(IUnitOfWork uow,int userID)
        {
            _userID = userID;
            InitializeComponent();
            repository = uow;
            
        }

        private void LoadUser()
        {
            CurrentUser = repository.Users.FindBy(u => u.UserID == _userID).FirstOrDefault();
            fromFullName.Text = CurrentUser.FullName;
            fromUserName.Text = CurrentUser.UserName;
            fromLastLogin.Text = (CurrentUser.LastLogin == null)?"":CurrentUser.LastLogin.ToString();
            lkAlternatives.Properties.DataSource = repository.Users.FindBy(u => u.UserID != _userID && u.IsActive == true).OrderBy(u=>u.UserName).ToList();
        }
        

        private void Consolidate_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to consolidate and delete?", "are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int toUserID = Convert.ToInt32(lkAlternatives.EditValue);
                DirtyDBHelper.ConsolidateUser(_userID, toUserID);
                this.Close();
            }
        }

        private void lkAlternatives_EditValueChanged(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(lkAlternatives.EditValue);
            var user = repository.Users.FindBy(u => u.UserID == userID).FirstOrDefault();
            toFullName.Text = user.FullName;
            toLastLogin.Text = user.LastLogin.ToString();
        }
    }
}
