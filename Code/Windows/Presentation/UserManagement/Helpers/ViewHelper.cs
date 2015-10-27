using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using HCMIS.Security.UserManagement.ViewModels;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;
using HCMIS.Security.UserManagement.Properties;
using System.Resources;

namespace HCMIS.Security.UserManagement.Helpers
{
    class ViewHelper
    {
      
        public static Form OpenLink(string formIdentifier)
        {            
            var type = GetTypeFromIdentifier(formIdentifier);
            if (type != null)
            {
                return (Form)Activator.CreateInstance(type);
            }
            return null;
        }

        static Type GetTypeFromIdentifier(string formIdentifier)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().Where(t => typeof(Form).IsAssignableFrom(t) && Attribute.GetCustomAttributes(t).Any(attrib => attrib is FormIdentifierAttribute));
            var type = from t in types
                       where (Attribute.GetCustomAttributes(t).Single(attrib => attrib is FormIdentifierAttribute) as FormIdentifierAttribute).Identifier == formIdentifier
                       select t;
            return type.FirstOrDefault();
        }

        public static Bitmap LoadImageFromResource(string resourceName)
        {

            global::System.Resources.ResourceManager resourceManager = new global::System.Resources.ResourceManager("HCMIS.Security.UserManagement.Properties.Resources", typeof(Resources).Assembly);
            var bitmap = resourceManager.GetObject(resourceName.Trim(),null);
            if (bitmap == null)
                return null;
            var icon = new Bitmap((Bitmap)bitmap, new Size(24,24));            
            return icon;
        }
        
    }
}
