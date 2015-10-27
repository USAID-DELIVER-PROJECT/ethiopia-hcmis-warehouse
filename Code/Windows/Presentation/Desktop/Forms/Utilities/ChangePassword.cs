using System;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Helpers;

namespace HCMIS.Desktop
{
    [FormIdentifier("AD-CP-CP-FR","Change Password","")]
    public partial class ChangePassword : XtraForm
    {
        public ChangePassword()
        {
            InitializeComponent();
            userId = CurrentContext.UserId;
        }

        int userId = 0;
       
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            User us = new User();
            us.LoadByPrimaryKey(userId);
            txtUsername.Text = us.UserName;
            txtUsername.Enabled = false;
        }

        private void xpButton18_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirm.Text)
            {
                User us = new User();
                if (userId != 0)
                {
                    us.LoadByPrimaryKey(userId);
                    string userName = us.UserName;
                    us.GetUserByAccountInfo(userName, txtOldPass.Text);// .LoadByPrimaryKey(userId);
                    if (us.RowCount > 0)
                    {
                        if (txtPassword.Text != "")
                        {
                            us.SavePassword(txtPassword.Text);
                        }
                        //us.Password = txtPassword.Text;
                        us.Save();
                        XtraMessageBox.Show(@"Password changed!", @"Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XtraMessageBox.Show("Old Password is not correct!", "Invaild Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Password doesnt match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xpButton17_Click(object sender, EventArgs e)
        {
            txtOldPass.Text = "";
            txtConfirm.Text = "";
            txtPassword.Text = "";
        }
    }
}