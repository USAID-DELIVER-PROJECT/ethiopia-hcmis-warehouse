using System;
using System.Linq;

namespace HCMIS.Warehouse
{
    public static class TimeDescriptor
    {
        #region DateTime Extension
        public static string TimeAgo(this DateTime dateTimeObj)
        {
            return dateTimeObj.TimeAgo(DateTime.Now);
        }

        public static string TimeAgo(this DateTime dateTimeObj, DateTime referenceDateTime)
        {
            var isFutureDate = dateTimeObj > referenceDateTime;
            var timeSpan = isFutureDate ? (dateTimeObj.Subtract(referenceDateTime)) : referenceDateTime.Subtract(dateTimeObj);
            var description = Describe(timeSpan);
            if (isFutureDate)
            {
                return (string.Format("in {0}", description));
            }
            return description == "Just now" ? description : (string.Format("{0} ago", description));
        }

        #endregion

        #region TimeSpan Extension

        public static string TimeDifference(this DateTime dateTimeObj, DateTime referenceDateTime)
        {
            var isFutureDate = dateTimeObj > referenceDateTime;
            var timeSpan = isFutureDate ? (dateTimeObj.Subtract(referenceDateTime)) : referenceDateTime.Subtract(dateTimeObj);
            return Describe(timeSpan);
        }
        #endregion

        #region Timespan Descriptor
        static readonly string[] Names = {
                                         "day",
                                         "hour",
                                         "minute",
                                         "second"
                                     };

        public static string Describe(TimeSpan t)
        {
            int[] ints = {
                         t.Days,
                         t.Hours,
                         t.Minutes,
                         t.Seconds
                     };

            double[] doubles = {
                               t.TotalDays,
                               t.TotalHours,
                               t.TotalMinutes,
                               t.TotalSeconds
                           };

            var firstNonZero = ints
                .Select((value, index) => new { value, index })
                .FirstOrDefault(x => x.value != 0);
            if (firstNonZero == null)
            {
                return "Just now";
            }
            var i = firstNonZero.index;
           // var prefix = (i >= 3) ? "" : "about ";
            var quantity = (int)Math.Round(doubles[i]);
            return Tense(quantity, Names[i]);
        }

        public static string Tense(int quantity, string noun)
        {
            return quantity == 1
                ? "1 " + noun
                : string.Format("{0} {1}s", quantity, noun);
        }

        public static string ElapsedTime(this DateTime dateTimeObj, DateTime referenceDatetime)
        {
            var isFutureDate = dateTimeObj > referenceDatetime;
            var timeSpan = isFutureDate ? (dateTimeObj.Subtract(referenceDatetime)) : referenceDatetime.Subtract(dateTimeObj);
            var description = Describe(timeSpan);
            if (isFutureDate)
            {
                return (string.Format("in {0}", description));
            }
            return description;
        }
        #endregion
    }
    
}
