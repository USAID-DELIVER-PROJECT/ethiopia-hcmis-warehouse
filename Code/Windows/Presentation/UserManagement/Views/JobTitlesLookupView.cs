using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Helpers;
using HCMIS.Security.Models;
using HCMIS.Security.UserManagement.Helpers;

namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-LU-JT-FR")]
    public partial class JobTitlesLookupView : DevExpress.XtraEditors.XtraForm
    {
        private IUnitOfWork _repository = UnitOfWork.CreateInstance();

        public JobTitlesLookupView()
        {
            InitializeComponent();
            LoadJobTitles();
        }

        private void LoadJobTitles()
        {
            var jobTitles = _repository.JobTitles.GetAll();
            jobTitlesBindingSource.DataSource = jobTitles.ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var jobTitles = jobTitlesBindingSource.DataSource as List<JobTitle>;

            foreach (var jobTitle in jobTitles)
            {
                if (jobTitle.JobTitleID == null || jobTitle.JobTitleID == 0)
                    _repository.JobTitles.Add(jobTitle);
                else
                {
                    var item = _repository.JobTitles.FindBy(m => m.JobTitleID == jobTitle.JobTitleID).SingleOrDefault();
                    if(item == null)
                        continue;
                    bool changed = false;
                    if (jobTitle.Title != item.Title)
                    {
                        item.Title = jobTitle.Title;
                        changed = true;
                    }
                    if (changed)
                        _repository.JobTitles.Update(item);
                }
            }
            MessageBox.Show("Save Successful");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void repDelete_Click(object sender, EventArgs e)
        {
            var dr = jobTitlesBindingSource[gridView1.FocusedRowHandle];
            if (dr != null)
            {
                if (XtraMessageBox.Show("Are you sure you would like to delete this Job Title?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(((JobTitle)dr).JobTitleID);
                    _repository.JobTitles.DeleteBy(j => j.JobTitleID == id);
                    LoadJobTitles();
                    XtraMessageBox.Show("The Job Title has been deleted","Confirmation");
                }
                
            }
            

        }
    }
}
