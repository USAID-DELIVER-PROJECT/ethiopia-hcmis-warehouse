
// Generated by MyGeneration Version # (1.3.0.9)

using System;
using DAL;
using System.Data;

namespace BLL
{
    /// <summary>
    /// Basically denotes on what type of paper printout the order is going to be printed
    /// </summary>
	public class PaymentType : _PaymentType
	{
		public PaymentType()
		{
		
		}

		public static class Constants
		{
            public static int CREDIT;
            public static int CASH;
            public static int STV;
            public static int DELIVERY_NOTE;
            public static int ERROR_CORRECTION;
            public static int INVENTORY;
            public static int DISPOSAL;
		}

        /// <summary>
        /// Gets the payment type ID.
        /// </summary>
        /// <param name="paymentTypeString">The payment type string.</param>
        /// <returns></returns>
        [Obsolete]
		public static int GetPaymentTypeID(string paymentTypeString)
		{
			if (string.Equals(paymentTypeString, "CREDIT", StringComparison.OrdinalIgnoreCase))
				return Constants.CREDIT;
			else if (string.Equals(paymentTypeString, "CASH", StringComparison.OrdinalIgnoreCase))
				return Constants.CASH;
            else if (string.Equals(paymentTypeString, "PROGRAM", StringComparison.OrdinalIgnoreCase) || string.Equals(paymentTypeString, "STV", StringComparison.OrdinalIgnoreCase))
				return Constants.STV;
            //else if (string.Equals(paymentTypeString, "TRANSFER", StringComparison.OrdinalIgnoreCase))
            //    return Constants.TRANSFER;
			else
				throw new Exception("Unrecognized payment type string");
		}

        /// <summary>
        /// Gets the payment type string.
        /// </summary>
        /// <param name="paymentTypeID">The payment type ID.</param>
        /// <returns></returns>
		public static string GetPaymentTypeString(int paymentTypeID)
		{
			PaymentType pType = new PaymentType();
			pType.LoadByPrimaryKey(paymentTypeID);
			if (pType.RowCount > 0)
				return pType.Name;
			return null;
		}

        /// <summary>
        /// Gets the allowed types.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="facilityID">The facility ID.</param>
        /// <returns></returns>
		public static DataView GetAllowedTypes(int mode, int? facilityID)
        {
            string inPaymentTypes = @"'STV'";
			var pt = new PaymentType();
			if (mode != Mode.Constants.HEALTH_PROGRAM)
			{
				inPaymentTypes = "'CRD', 'CAS'";
			}

			if (BLL.Settings.IsCenter || !facilityID.HasValue) //For center and for cases where the issue is going to be made for an entity other than a facility (e.g. Transfer to account or stores, etc.) the payment type needs to be STV.  This needs to be handled better though.
			{
                inPaymentTypes = "'STV'";
			}

			var query = HCMIS.Repository.Queries.PaymentType.SelectByCodes(inPaymentTypes);
			pt.LoadFromRawSql(query);
			return pt.DefaultView;
		}

    }
}