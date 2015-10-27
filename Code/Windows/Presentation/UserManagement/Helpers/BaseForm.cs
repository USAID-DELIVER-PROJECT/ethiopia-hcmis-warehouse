using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HCMIS.Security.Common;
using HCMIS.Security.UserManagement.Properties;

namespace HCMIS.Security.UserManagement.Helpers
{
    public class BaseForm : Form, INotifyPropertyChanged
    {
        #region Fields
        private SecurityPrincipal _principal;
        #endregion

        #region Properties

        protected internal SecurityPrincipal Principal
        {
            get { return this._principal; }
            set
            {
                if (this._principal == value)
                    return;
                this._principal = value;
                this.OnPropertyChanged("Principal");
            }
        }

        public virtual string FormName { get; protected set; }

        #endregion

        #region Constructor
        public BaseForm()
        {
            
        }
        public BaseForm(string formName)
        {
            this.FormName = formName;
            this.Enabled = false;
            Principal = Thread.CurrentPrincipal as SecurityPrincipal;
            

        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }

        }
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(907, 507);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }

    }
}
