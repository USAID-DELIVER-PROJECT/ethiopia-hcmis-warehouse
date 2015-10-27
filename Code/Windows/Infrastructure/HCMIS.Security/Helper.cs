using HCMIS.Security.Common;
using System.Threading;
using HCMIS.Security.Helpers;
using System.Linq;
using HCMIS.Security.Models;

namespace HCMIS.Security
{
   public static class Helper
    {
       public static UserIdentity CurrentUser
       {
           get { return (UserIdentity) Thread.CurrentPrincipal.Identity; }
       }

       public static SecurityPrincipal CurrentPrincipal
       {
           get { return Thread.CurrentPrincipal as SecurityPrincipal; }
       }

       // TODO: move this method to appropriate class
       public static void CreateOperation(string formIdentifier, string operationName)
       {
           try
           {
               // check if the operation exists
               UnitOfWork repository = UnitOfWork.CreateInstance();
               var operations =
                   repository.Operations.FindBy(o => o.Name == operationName && o.MenuItem.URL == formIdentifier).
                       SingleOrDefault();
               //  if not create it
               if (operations == null)
               {
                   var Operation = new Operation();
                   Operation.Name = operationName;
                   Operation.MenuItemID =
                       repository.MenuItems.FindBy(m => m.URL == formIdentifier).SingleOrDefault().MenuItemID;
                   repository.Operations.Add(Operation);
               }
           }
           catch { }



       }
    }
}
