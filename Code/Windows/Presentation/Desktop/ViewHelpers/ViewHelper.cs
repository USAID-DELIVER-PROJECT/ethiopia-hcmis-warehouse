using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BLL;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;
using System.Resources;
using HCMIS.Helpers;
using HCMIS.Security.Common;
using HCMIS.Desktop.Properties;

namespace HCMIS.Desktop.Helpers
{
    class ViewHelper
    {
        static Dictionary<string, Type> typesWithIdentifiers = new Dictionary<string, Type>();

        public static Form OpenLink(string formIdentifier)
        {            
            var type = GetTypeFromIdentifier(formIdentifier);
       
            if (type != null)
            {
                var form = (Form)Activator.CreateInstance(type);
                form.Load += new EventHandler(form_Load);
                form.Closed += new EventHandler(form_Closed);
                return form;
            }

            return null;
        }

        static void form_Closed(object sender, EventArgs e)
        {
            ((Form)sender).LogActivity("Close");
        }

        static void form_Load(object sender, EventArgs e)
        {
            var form = ((Form) sender);
            if (!form.HasPermission("Open"))
            {
                form.Controls.Clear();
                form.LogActivity("Access-Denied");
            }
        }

        static Type GetTypeFromIdentifier(string formIdentifier)
        {
           
           if (typesWithIdentifiers.Any(m => m.Key == formIdentifier))
               return typesWithIdentifiers.FirstOrDefault(m => m.Key == formIdentifier).Value;

           var assembly = Assembly.GetExecutingAssembly();
           var types = assembly.GetTypes().Where(t => typeof(Form).IsAssignableFrom(t) && Attribute.GetCustomAttributes(t).Any(attrib => attrib is FormIdentifierAttribute));
           var type = from t in types
                      where (Attribute.GetCustomAttributes(t).Single(attrib => attrib is FormIdentifierAttribute) as FormIdentifierAttribute).Identifier == formIdentifier
                      select t;
           typesWithIdentifiers.Add(formIdentifier,type.FirstOrDefault());
           return type.FirstOrDefault();
        }

        public static Bitmap LoadImageFromResource(string resourceName,int width, int height)
        {
            try
            {
                global::System.Resources.ResourceManager resourceManager =
                    new global::System.Resources.ResourceManager("HCMIS.Desktop.Properties.Resources",
                                                                 typeof(Resources).Assembly);
                if (resourceName == null)
                    return null;
                var bitmap = resourceManager.GetObject(resourceName.Trim(), null);
                if (bitmap == null)
                    return null;
                var icon = new Bitmap((Bitmap)bitmap, new Size(width, height));
                return icon;
            }
            catch
            {
                return null;
            }
        }

        public static void ShowErrorMessage(string ErrorMessage,Exception exception)
        {
            if (CurrentContext.LoggedInUser.UserType == BLL.UserType.Constants.SUPER_ADMINISTRATOR || CurrentContext.LoggedInUser.UserType == BLL.UserType.Constants.ADMIN)
            {
                XtraMessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show( ErrorMessage,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
