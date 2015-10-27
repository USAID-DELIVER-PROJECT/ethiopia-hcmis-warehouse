using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCMIS.Desktop.Helpers;
using HCMIS.Helpers;
using HCMIS.Desktop.Helpers;
using DevExpress.XtraEditors;

namespace HCMIS.Desktop.Forms.Utilities
{
    [FormIdentifier("AD-RG-RG-FR","Registration","")]
    public partial class Registrations : Form
    {
        public Registrations()
        {
            InitializeComponent();            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registrations_Load(object sender, EventArgs e)
        {
            SetPermission();
            string authenticationCode = RegistrationHelper.GetAuthenticationCode();
            if (!string.IsNullOrEmpty(authenticationCode))
            {
                if (XtraMessageBox.Show("HCMIS Already registered.  Trying to register again may invalidate your current registration information.  Proceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                {
                    this.Close();
                }
            }

            cboUserType.Properties.Items.AddRange(RegistrationHelper.UserTypesForHE());
        }

        private void SetPermission()
        {
            if (BLL.Settings.UseNewUserManagement)
            {
                btnRegister.Enabled = this.HasPermission("Register");
            }
        }

        private void cboUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFacilityID.Enabled = cboUserType.Text != "Individual User";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            HCMISRegistrations.RegistrationsSoapClient soapClient = new HCMISRegistrations.RegistrationsSoapClient();
            int? facilityID = null;

            if (txtFacilityID.Text != "")
                facilityID = int.Parse(txtFacilityID.Text);

            bool registered = false;
            int userType = RegistrationHelper.GetUserTypeID(cboUserType.Text);
            int registrationID=soapClient.RegisterNewUser(txtUserName.Text, userType, facilityID, txtAssemblyName.Text, Program.HCMISVersionString, txtAuthenticationCode.Text);
            registered = -1 != registrationID;
            if (registered)
            {
                //Save Authentication code to the registry
                int? userID = null;
                if (txtFacilityID.Text != "")
                    userID = int.Parse(txtFacilityID.Text);
                RegistrationHelper.SaveAuthenticationInfoToRegistry(txtAuthenticationCode.Text, userType, userID, registrationID);
                XtraMessageBox.Show("Successfully Registered.", "Registration");
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("Registration failed!", "Registration");
            }
        }
    }
}
