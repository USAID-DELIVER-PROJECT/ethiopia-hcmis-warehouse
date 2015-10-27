using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using HCMIS.Desktop.Views;
using HCMIS.Helpers;
using HCMIS.Logging;
using HCMIS.Logging.Loggers;

namespace HCMIS.Desktop.Helpers
{
    static class FormHelper
    {
        
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

        public static void ReplaceMe(this Form form, Form newForm)
        {
            var parent = form.Parent;
            form.Parent.Controls.Clear();
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Visible = true;
            newForm.Parent = parent;
            newForm.Dock = DockStyle.Fill;
        }

        public static string GetFormIdentifier(this Form form)
        {

                if (form.Modal)
                {
                    return MainWindow.Instance.CurrentFormIdentifier;
                }
                var attributes = Attribute.GetCustomAttributes(form.GetType());
                var attribute = attributes.Where(a => a is FormIdentifierAttribute).FirstOrDefault() as FormIdentifierAttribute;
                if (attribute == null)
                {
                    return "";
                }
                return attribute.Identifier;
        
        }

        public static bool HasPermission(this Form form, string operation )
        {
            // check if the operation is registerd or not
            // if not ... take one step to register it
            // do this only in debug mode.
            //if (System.Diagnostics.Debugger.IsAttached)
            {
                Security.Helper.CreateOperation(form.GetFormIdentifier(), operation);
            }
            return HCMIS.Security.Helper.CurrentPrincipal.HasPermission(form.GetFormIdentifier(), operation);
        }

        public static bool HasPermission(this Form form, string formIdentifier, string operation)
        {
            return HCMIS.Security.Helper.CurrentPrincipal.HasPermission(formIdentifier, operation);
        }

        public static void LogActivity(this Form form, string activityName)
        {
            LogActivity(form,activityName,0);
        }

        public static void LogActivity(this Form form, string activityName,int primaryKey)
        {
            form.LogActivity(form.GetFormIdentifier(), activityName, primaryKey);
        }

        public static void LogActivity(this Form form, string formIdentifier, string activityName, int primaryKey)
        {
            // Remove this try catch ... when the logging has been found working
            try
            {
                ActivityLogger log = new ActivityLogger(form);
                log.SaveAction(HCMIS.Security.Helper.CurrentUser.UserID, primaryKey, form.GetFormIdentifier(), activityName);
            }
            catch
            {
                
            }
        }


 }
}
