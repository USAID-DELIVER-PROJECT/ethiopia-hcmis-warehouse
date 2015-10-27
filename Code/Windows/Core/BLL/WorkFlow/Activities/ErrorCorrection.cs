using DAL;

namespace BLL.WorkFlow.Activities
{
    public class ErrorCorrection : _ErrorCorrection
    {

        public static void Log(BLL.Issue issue,BLL.Receipt receipt,decimal conversionfactor)
        {
            var errorCorrection = new ErrorCorrection();
            errorCorrection.AddNew();
            errorCorrection.UserID = CurrentContext.LoggedInUser.ID;
            errorCorrection.IssueID = issue.ID;
            errorCorrection.ReceiptID = receipt.ID;
            errorCorrection.ConversionFactor = conversionfactor;
            errorCorrection.Save();
        }
    }
}
