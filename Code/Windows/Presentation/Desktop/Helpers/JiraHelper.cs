using System.Drawing;
using System.Windows.Forms;
using Atlassian.Jira;
using System.IO;
using System.Drawing.Imaging;

namespace HCMIS.Desktop.Helpers
{
    public class JiraHelper
    {
        public static string JIRA_PATH;
        private static bool IsInitialized = false;

        private static Atlassian.Jira.Jira jira;

        public static string UserName;
        public static string Password;

        public static Bitmap Image;

        static JiraHelper()
        {
            JIRA_PATH = BLL.Settings.BugTrackingURL;
            IsInitialized = true;
        }

        public static void SetupHelper()
        {
            
            jira = new Jira(JiraHelper.JIRA_PATH, "warehouse", "warehouse");
            IsInitialized = true;
        }

        public static bool Login(string userName, string password)
        {
            try
            {
                jira = new Jira(JiraHelper.JIRA_PATH, userName, password);
                return true;
            }
            catch
            {
                SetupHelper();
                return false;
            }
        }


        public static Issue CreateIssue(string project, string title, string description,string priority, string type)
        {
           
            Issue issue = jira.CreateIssue(project);
            issue.Summary = title;
            issue.Description = description;
            issue.Type = type;
            issue.Priority = priority;
            return issue;
        }

        public static void AttachScreenShot(Issue issue, Image img)
        {
            if (img != null)
            {
                issue.AddAttachment("screenshot.png", ConvertImage(img));
            }
            issue.SaveChanges();
        }

        public static void TakeScreenshot(Form form)
        {
            if (!IsInitialized)
            {
                SetupHelper();
            }
             CaptureControlShot(form);
        }

        /// <summary>
        /// Gets a bitmap image of the specified control.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static byte[] CaptureControlShot(Control control)
        {
            // get control bounding rectangle
            Rectangle bounds = control.Bounds;

            // create the new bitmap that holds the image of the control
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

            // copy controls image data to the bitmaps graphics device
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.CopyFromScreen(control.Location, Point.Empty, bounds.Size);
            }
            Image = bitmap;
            return ConvertImage(bitmap);
        }

        private static byte[] ConvertImage(Image img)
        {
            MemoryStream stream = new MemoryStream();
            img.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }

        
    }
}
