
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Shared;
using HCMIS.Shared.Connection;
using System.Linq;

namespace Shared.Forms
{
    public partial class ConnectionChoices : DevExpress.XtraEditors.XtraForm
    {
        private Dictionary<string, string> HistoricConnectionStrings = new Dictionary<string,string>();
        public ConnectionChoices()
        {
            InitializeComponent();
        }

        private void ConnectionChoices_Load(object sender, System.EventArgs e)
        {

        }

        private void btnAdvanced_Click(object sender, System.EventArgs e)
        {
            new AdvancedConnectionManager(new ConnectionString(), this).Show();
            this.Hide();
        }

        private void listConnections_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (listConnections.SelectedItem != null)
            {
                string key = listConnections.SelectedItem.ToString();
                ConnectionString connectionString = new ConnectionString();
                connectionString.Parse( HistoricConnectionStrings[key]);
                lblPreview.Text = connectionString.ToVisibleString();
            }
           
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
           this.Close();
        }

        private void listConnections_DoubleClick(object sender, System.EventArgs e)
        {
            string key = listConnections.SelectedValue.ToString();
            string connString  = HistoricConnectionStrings[key];
            ConnectionString connectionString = new ConnectionString();
            connectionString.Parse(connString);
            lblPreview.Text = connectionString.ToVisibleString();
            connectionString.Name = key;

            new AdvancedConnectionManager( connectionString, this ).Show(this);
            this.Hide();
        }

        private void ConnectionChoices_Shown(object sender, System.EventArgs e)
        {
            RefreshConnectionList();
        }

        public void RefreshConnectionList()
        {
            listConnections.Items.Clear();
          

            HistoricConnectionStrings = ConnectionHelper.GetHistoricConnections();
            for (int i = 0; i < HistoricConnectionStrings.Keys.Count;i++ )
            {
                listConnections.Items.Add(HistoricConnectionStrings.Keys.ElementAt(i));
            }
            listConnections.SelectedItem = lblName.Text = ConnectionHelper.CurrentConnection.Name;
            chkSupportMachine.Checked = ConnectionHelper.IsLiveInstallation;
            lblConnection.Text = ConnectionHelper.CurrentConnection.ToVisibleString();

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure you would like to change the default connection?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string key = listConnections.SelectedValue.ToString();
               

                string connString =  HistoricConnectionStrings[key];
                ConnectionString connectionString = new ConnectionString();

                connectionString.Parse(connString);
                connectionString.Name = key;
                connectionString.SaveAsDefault();
                lblPreview.Text = connectionString.ToVisibleString();

                XtraMessageBox.Show("The new default has been set.");
                ConnectionHelper.CurrentConnection = connectionString;
                this.Close();
            }
        }

        private void chkSupportMachine_CheckedChanged(object sender, System.EventArgs e)
        {
            ConnectionHelper.IsLiveInstallation = chkSupportMachine.Checked;
        }
        
    }
}