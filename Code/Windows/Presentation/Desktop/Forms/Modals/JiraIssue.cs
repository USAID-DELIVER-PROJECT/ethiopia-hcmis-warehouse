using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraEditors;
using HCMIS.Desktop.Views;
using HCMIS.Desktop.Helpers;

namespace HCMIS.Desktop.Forms.Modals
{
    public partial class JiraIssue : XtraForm
    {
        public JiraIssue()
        {
            InitializeComponent();
        }

        private void JiraIssue_Load(object sender, EventArgs e)
        {
             txtReportedBy.Text = JiraHelper.UserName;
             txtPassword.Text = JiraHelper.Password;
             txtSite.Text = GeneralInfo.Current.HospitalName;
                // txtReportedBy.Text = NewMainWindow.LoggedInUserName;
             screenShot.Image = JiraHelper.Image;
        }
       

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (dxValidationProvider1.Validate())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        if (!JiraHelper.Login(txtReportedBy.Text, txtPassword.Text))
                        {
                            if (
                                XtraMessageBox.Show(
                                    "The username/password you entered is not applicable.  Would you like to continue submit?",
                                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        JiraHelper.UserName = txtReportedBy.Text;
                        JiraHelper.Password = txtPassword.Text;
                    }

                    var issue = JiraHelper.CreateIssue("HW", txtSummary.Text, txtDescription.Text, lkPriority.Text,
                                                       lkType.Text);
                    //issue.AddComment("My Comment is that this is a good test");
                    issue.CustomFields.Add("Site Name",
                                           new string[]
                                               {
                                                   GeneralInfo.Current.HospitalName
                                               }
                        );
                    issue.CustomFields.Add("Current User", new string[]
                                                               {
                                                                   string.Format("{0}, {1}, {2}",
                                                                                 CurrentContext.LoggedInUserName,
                                                                                 CurrentContext.LoggedInUser.FullName,
                                                                                 txtReportedBy.Text
                                                                       )
                                                               }
                        );
                    issue.CustomFields.Add("Current Version",new string[]
                                                                 {
                                                                     cboCurrentVersion.Text
                                                                 });

                    if (MainWindow.Instance != null)
                    {
                        if (!string.IsNullOrEmpty(MainWindow.Instance.CurrentFormIdentifier))
                        {
                            // now let's send the page identifier
                            // try to find the component if possible.
                            //issue.CustomFields.Add("Form ID", new string[]
                            //                                      {
                            //                                          MainWindow.Instance.CurrentFormIdentifier
                            //                                      });
                        }
                    }

                    issue.CustomFields.Add("Version", new string[]
                                                          {
                                                              Program.HCMISVersionString
                                                          });

                    issue.Reporter = txtReportedBy.Text;

                   


                    issue.SaveChanges();

                    JiraHelper.AttachScreenShot(issue, screenShot.Image);
                    XtraMessageBox.Show("The issue has been successfully reported.", "Confirmation",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    XtraMessageBox.Show("Please check if you have internet connection and try again.","No Connection",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
               
               
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
