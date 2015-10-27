using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using BLL;
using HCMIS.Desktop.Views;

namespace HCMIS.Desktop.Helpers
{
    public class ErrorHandler
    {
        public static void Handle(Exception exp)
        {
            try
            {
                StackTrace st = new StackTrace(exp, true);
                StackFrame[] frames = st.GetFrames();
                int index = 0;
                StackFrame frame = frames[0];
                String filename = frame.GetFileName();
                
                //TODO: Log the Error here.
                LogAppError errorLog = new LogAppError();
                errorLog.AddNew();
                if(BLL.Settings.UseNewUserManagement && MainWindow.Instance != null)
                {
                    errorLog.StatusCode = MainWindow.Instance.CurrentFormIdentifier;
                }
                errorLog.Type = exp.GetType().ToString();
                errorLog.Message = exp.Message;
                errorLog.UserID = CurrentContext.UserId;
                errorLog.Time = DateTimeHelper.ServerDateTime;
                errorLog.Details = "";
                if(st != null)
                {
                    errorLog.Details = st.ToString();
                }
                errorLog.Save();

                if (User.GetUserType(CurrentContext.UserId) == UserType.Constants.ADMIN ||
                    User.GetUserType(CurrentContext.UserId) == UserType.Constants.SUPER_ADMINISTRATOR)
                {
                    //NewMainWindow.Instance.ShowWarningFor(exp.GetType().ToString(), String.Format(@"|{0}|-{1}:{2},{3}", filename, frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber()));
                   
                    //XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Error: " + exp.GetType().ToString() + Environment.NewLine + exp.Message + Environment.NewLine + String.Format(@"|{0}|-{1}:{2},{3}", filename, frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber()), "Error : " + errorLog.ID, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); 
                }
                
            }
            catch
            {
            }
        }


    }



}
