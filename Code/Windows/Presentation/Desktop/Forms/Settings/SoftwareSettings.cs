using System;
using System.Data;
using BLL;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;

namespace HCMIS.Desktop.Forms.Settings
{
    [FormIdentifier("AD-SS-SS-FR","Software Settings","")]
    public partial class SoftwareSettingForm : DevExpress.XtraEditors.XtraForm
    {
        public SoftwareSettingForm()
        {
            InitializeComponent();
        }

        private void SoftwareSettings_Load(object sender, EventArgs e)
        {
            SetPermission();
            grdSettings.DataSource = SoftwareSettings.GetAllSettings();
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                grdSettings.Enabled = this.HasPermission("Save");
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
             DataRow dr = grdSettingsView.GetFocusedDataRow();
             if (dr != null)
             {
                 int selected = Convert.ToInt32(dr["ID"]);
                 SoftwareSettings softwareSetting = new SoftwareSettings();
                 softwareSetting.LoadByPrimaryKey(selected);
                 softwareSetting.Value = dr["Value"].ToString();
                 softwareSetting.Save();

             }
        }

        private void btnRefreshSettings_Click(object sender, EventArgs e)
        {
            BLL.Settings settings = new BLL.Settings();
            settings.IterateThroughAllProperties();
            SoftwareSettings_Load(null, null);
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            grdSettingsView.ActiveFilterString = "Name like '%" + txtFind.Text + "%'";
        }
    }
}