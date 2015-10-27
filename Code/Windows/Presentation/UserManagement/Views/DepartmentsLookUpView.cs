using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCMIS.Security.Repository;
using HCMIS.Security.Models;
using HCMIS.Security.Helpers;
using HCMIS.Security.UserManagement.Helpers;
using DevExpress.XtraEditors;

namespace HCMIS.Security.UserManagement.Views
{
    [FormIdentifier("UM-LU-DE-FR")]
    public partial class DepartmentsLookUpView : XtraForm
    {
        private IUnitOfWork _repository = UnitOfWork.CreateInstance();
        public DepartmentsLookUpView()
        {
            InitializeComponent();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            var departments = _repository.Departments.GetAll();
            departmentsBindingSource.DataSource = departments.ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var departments = departmentsBindingSource.DataSource as List<Department>;
            
            foreach (var department in departments)
            {
                if (department.DepartmentID == null || department.DepartmentID == 0)
                {
                    _repository.Departments.Add(department);
                }
                else
                {
                    var item = _repository.Departments.FindBy(m => m.DepartmentID == department.DepartmentID).SingleOrDefault();
                    if (item == null)
                        continue;
                    bool changed = false;
                    if (item.Name != department.Name)
                    {
                        changed = true;
                        item.Name = department.Name;
                    }                    
                    if (changed)
                        _repository.Departments.Update(item);
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
            var dr = departmentsBindingSource[gridView1.FocusedRowHandle];
            if (dr != null)
            {
                if (XtraMessageBox.Show("Are you sure you would like to delete this Department?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(((Department)dr).DepartmentID);
                    _repository.Departments.DeleteBy(j => j.DepartmentID == id);
                    LoadDepartments();
                    XtraMessageBox.Show("The Department has been deleted", "Confirmation");
                }

            }
        }
    }
}
