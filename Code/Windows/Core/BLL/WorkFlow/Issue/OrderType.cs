using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class OrderType
    {
        public static class CONSTANTS
        {
            public static int STANDARD_ORDER;
            public static int CUSTOM_ISSUE_ORDER;
            public static int STORE_TO_STORE_TRANSFER;
            public static int HUB_TO_HUB_TRANSFER;
            public static int ACCOUNT_TO_ACCOUNT_TRANSFER;
            public static int ERROR_CORRECTION_TRANSFER;
            public static int PLITS;
            public static int INVENTORY;
            public static int BACK_ORDER;
        }
    }
}
