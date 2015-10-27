

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Shared;
using HCMIS.Shared.Connection;

namespace Shared.Forms
{
    public partial class AdvancedConnectionManager : DevExpress.XtraEditors.XtraForm
    {
        private ConnectionString connectionString = null;
        private string previousKeyName;

        private Form Caller;

        public AdvancedConnectionManager(ConnectionString cString, Form parent)
        {
            Caller = parent;

            connectionString = cString;
            previousKeyName = cString.Name;
            InitializeComponent();
        }

        private void AdvancedConnectionManager_Load(object sender, System.EventArgs e)
        {
            this.connectionStringBindingSource.DataSource = connectionString;

            // a hack to have the integrated security mode selected
            chkIntegratedSecurity.Checked = Convert.ToBoolean(connectionString.IntegratedSecurity);

        }

        private void chkIntegratedSecurity_CheckedChanged(object sender, System.EventArgs e)
        {
            txtUserName.Enabled = txtPassword.Enabled = !chkIntegratedSecurity.Checked;
            if (chkIntegratedSecurity.Checked)
            {
                connectionString.IntegratedSecurity = "true";
            }
            else
            {
                connectionString.IntegratedSecurity = "false";
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Caller.Show();
            this.Close();
        }

        private void btnPreview_Click(object sender, System.EventArgs e)
        {
            lblPreview.Text = connectionString.ToVisibleString();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                RegistryHelper helper = new RegistryHelper();
                if (!string.IsNullOrEmpty(previousKeyName))
                {
                    helper.Delete(ConnectionHelper.SavedConnectionKey, previousKeyName);
                }
                helper.Write(ConnectionHelper.SavedConnectionKey, connectionString.Name, EncriptionHelper.EncryptString(connectionString.ToString(), "hcmis-warehouse"));
                connectionString.SaveAsDefault();
                XtraMessageBox.Show("Your changes have been saved");
                Caller.Show();
                ((ConnectionChoices)Caller).RefreshConnectionList();
                this.Close();
            }

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
             try
            {
                SqlConnection connection = new SqlConnection(connectionString.ToString());
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {

                    MessageBox.Show("Connection is Successful, ServerVersion is:" + connection.ServerVersion, "Success", MessageBoxButtons.OK,MessageBoxIcon.None);
                }
                connection.Close();
                btnTestConnection.Image = HCMIS.Shared.Properties.Resources.Check;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Has Failed");

                btnTestConnection.Image = HCMIS.Shared.Properties.Resources.Cross;
            }
        }


    }
}