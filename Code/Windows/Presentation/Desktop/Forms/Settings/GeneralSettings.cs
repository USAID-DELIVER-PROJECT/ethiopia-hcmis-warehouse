using System;
using System.ComponentModel;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Helpers;
using HCMIS.Desktop.Views;
using HCMIS.Helpers;

namespace HCMIS.Desktop
{
    [FormIdentifier("PF-HS-HD-FR","Hub/Center Settings","")]
    public partial class Hospital : XtraForm
    {
        public Hospital()
        {
            InitializeComponent();
        }

        
        int _hospitalId = 0;
        private void Hospital_Load(object sender, EventArgs e)
        {
            SetPermission();
           BLL.Region reg = new BLL.Region();
            reg.LoadAll();
            //cboRegion.DataSource = reg.DefaultView;
            Zone zon = new Zone();
            zon.LoadAll();
            //cboZone.DataSource = zon.DefaultView;
            Woreda wor = new Woreda();
            wor.LoadAll();
            //cboWoreda.DataSource = wor.DefaultView;
            PopulateFields();
          
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnSave.Enabled = this.HasPermission("Save");
            }
        }

       

        private void PopulateFields()
        {
            txtHUBName.Text = GeneralInfo.Current.HospitalName;
            txtPhone.Text = GeneralInfo.Current.Telephone;
            txtContactPerson.Text = GeneralInfo.Current.HospitalContact;
            //txtHubID.Text = GeneralInfo.Current.HubID;
            if(!GeneralInfo.Current.IsColumnNull("FacilityID"))
            {
                txtHubID.Text = GeneralInfo.Current.FacilityID.ToString();    
            }
            
            if(GeneralInfo.Current.Description != null)
            {
                string[] arr = GeneralInfo.Current.Description.Split('|');
                if(arr.Length == 4)
                {
                    txtDDUserName.Text = arr[0];
                    txtDSPassword.Text = arr[1];
                    txtHCTSUserName.Text = arr[2];
                    txtHCTSPassword.Text = arr[3];
                }
            }
            txtDescription.Text = GeneralInfo.Current.Description;
            _hospitalId = GeneralInfo.Current.ID;
        }

        

     

        public static System.Configuration.AppSettingsReader readApp = new System.Configuration.AppSettingsReader();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_hospitalId != 0)
            {
                if (XtraMessageBox.Show(@"Are You sure, You want to save the changes to General Info.?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GeneralInfo.Current.LoadByPrimaryKey(_hospitalId);
                    GeneralInfo.Current.HospitalName = txtHUBName.Text;
                    GeneralInfo.Current.HospitalContact = txtContactPerson.Text;
                    GeneralInfo.Current.Telephone = txtPhone.Text;
                    GeneralInfo.Current.FacilityID = Convert.ToInt32(txtHubID.EditValue);
                    //GeneralInfo.Current.Description = txtDescription.Text;

                    GeneralInfo.Current.Description = string.Format(@"{0}|{1}|{2}|{3}", txtDDUserName.Text,
                                                                    txtDSPassword.Text, txtHCTSUserName.Text,
                                                                    txtHCTSPassword.Text);

                    GeneralInfo.Current.Save();

                    PopulateFields();
                    this.Parent.Parent.Text = GeneralInfo.Current.HospitalName + @" - Ethiopian Health Commodity Management Information System(HCMS)";

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PopulateFields();
        }

        private void btnLoadLogo_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                GeneralInfo.Current.SaveImage(openFileDialog1.FileName);
                XtraMessageBox.Show("File has been successfully uploaded", "Success...",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
                var mainWindow = Parent as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.PaintApplicationContext();
                }
            
            }

       
        
    }
}