using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HCMIS.Security.Models;
using HCMIS.Security.Helpers;
using HCMIS.Security.UserManagement.Helpers;

namespace HCMIS.Security.UserManagement
{
    [FormIdentifier("UM-RT-RV-FR")]
    public partial class ResourceTypesView : DevExpress.XtraEditors.XtraForm
    {
        static readonly IUnitOfWork _repository = UnitOfWork.CreateInstance();
        public ResourceTypesView()
        {
            InitializeComponent();
            LoadItems();
        }

        private void LoadItems()
        {
            
            resourceTypeBindingSource.DataSource = _repository.ResourceTypes.GetAll().ToList();
        }       

        private void Save()
        {
            var resourceTypes = resourceTypeBindingSource.DataSource as List<ResourceType>;
            foreach (var resourceType in resourceTypes)
            {
                if (resourceType.ResourceTypeID == null || resourceType.ResourceTypeID == 0)
                {
                    _repository.ResourceTypes.Add(resourceType);
                }
                else
                {
                    var item = _repository.ResourceTypes.FindBy(m => m.ResourceTypeID == resourceType.ResourceTypeID).SingleOrDefault();
                    if (item != null || item.Name != resourceType.Name)
                    {
                        item.Name = resourceType.Name;
                        _repository.ResourceTypes.Update(item);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
