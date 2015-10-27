using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace HCMIS.Security.UserManagement.Helpers
{
    static class PanelHelper
    {
        public static void ShowInPanel(this DevExpress.XtraEditors.XtraForm form, PanelControl panel)
        {
            panel.Controls.Clear();
            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Parent = panel;
                form.Visible = true;
                //panel.Controls.Add(form);
                form.Dock = DockStyle.Fill;
            }
        }

        public static void ShowInPanel(this Form form, PanelControl panel)
        {
            panel.Controls.Clear();
            if (form != null)
            {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Parent = panel;
                form.Visible = true;
                //panel.Controls.Add(form);
                form.Dock = DockStyle.Fill;
            }
            
        }
    }
}
