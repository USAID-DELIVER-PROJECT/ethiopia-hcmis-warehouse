using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Configuration;
using DevExpress.XtraEditors;

namespace HCMIS.Security.UserManagement
 
{
    public class ViewHelper
    {
        #region MessageBox Helper Methods

        public static void ShowGenericErrorDialog()
        {
            XtraMessageBox.Show(Properties.Resources.ERROR_MESSAGE, Properties.Resources.ERROR_TITLE, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void ShowSaveError()
        {
            XtraMessageBox.Show(Properties.Resources.SAVE_ERROR, Properties.Resources.SAVE_ERROR_TITLE, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void ShowDeleteError()
        {
            XtraMessageBox.Show(Properties.Resources.DELETE_ERROR, Properties.Resources.DELETE_ERROR_TITLE, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public static void ShowSuccessMessage(string message)
        {
            XtraMessageBox.Show(message, Properties.Resources.SUCCESS_TITLE, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void ShowGenericSuccessMessage()
        {
            ShowSuccessMessage(Properties.Resources.SUCCESS_MESSAGE);
        }


        public static void ShowErrorMessage(string message)
        {
            XtraMessageBox.Show(message, Properties.Resources.ERROR_TITLE, MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays detailed error information using MessageBox class. This method depends on the verboseMode configuration item
        /// found in app.config. If verboseMode is enabled then this method will messages from the current exception and its associated
        /// innerException.
        /// </summary>
        /// <param name="message">User friendly error message describing the task the user was doing. Eg: Error occured while saving employee information.</param>
        /// <param name="exception">The exception that was thrown by the method under execution.</param>
        public static void ShowErrorMessage(string message, Exception exception)
        {
            var verboseMode = Convert.ToBoolean(ConfigurationManager.AppSettings["verboseMode"]);
            var msg = new StringBuilder();

            if (verboseMode)
            {
                if (null != exception)
                {
                    msg.Append(Environment.NewLine);
                    msg.Append("Primary Error: " + Environment.NewLine);
                    msg.Append(exception.Message);
                    if (null != exception.InnerException)
                    {
                        msg.Append(Environment.NewLine);
                        msg.Append("Internal Error:" + Environment.NewLine);
                        msg.Append(exception.InnerException.Message);
                    }
                }
            }

            ShowErrorMessage(message + Environment.NewLine + msg);
        }


        public static void ShowGenericErrorMessage()
        {
            ShowErrorMessage(Properties.Resources.ERROR_MESSAGE);
        }

        public static DialogResult ShowConfirmDialog(string question)
        {
            return XtraMessageBox.Show(question, Properties.Resources.ACTION_CONFIRM_TITLE, MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Question);
        }

        public static DialogResult Conformation(string confirm)
        {
            return XtraMessageBox.Show(confirm, Properties.Resources.ACTION_CONFIRM_TITLE, MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Question);
        }
        #endregion

        #region Screen Management

        public static int LeftPositionForForm(int percentage)
        {
            // Get the width of the primary screen
            var screenWidth = Screen.PrimaryScreen.Bounds.Width;

            // Based on the percentage parameter calculate the left position
            var left = screenWidth / percentage;
            return Convert.ToInt32(left);
        }

        public static int TopPositionForForm(int percentage)
        {
            // Get the width of the primary screen
            var screenHeight = Screen.PrimaryScreen.Bounds.Height;

            // Based on the percentage parameter calculate the left position
            var top = screenHeight / percentage;
            return Convert.ToInt32(top);
        }

        public static int GetWidthForForm(int percentage)
        {
            var left = LeftPositionForForm(percentage);
            var width = Screen.PrimaryScreen.Bounds.Width - (left * 2);
            return width;
        }

        public static int GetHeightForForm(int percentage)
        {
            var top = TopPositionForForm(percentage);
            var height = Screen.PrimaryScreen.Bounds.Height - (top * 2);
            return height;
        }
        #endregion
    }
}
