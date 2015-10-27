using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EthiopianCalendar;

namespace BLL
{
   public class DateTimeHelper
    {
        /// <summary>
        /// Adds the ethiopian date field.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
       public static readonly string[] Months = { "መስከረም", "ጥቅምት", "ኅዳር", "ታኅሣሥ", "ጥር", "የካቲት", "መጋቢት", "ሚያዝያ", "ግንቦት", "ሰኔ", "ሐምሌ", "ነሐሴ", "ጳጉሜን" };

       public static MyGeneration.dOOdads.BusinessEntity AddEthiopianDateField(MyGeneration.dOOdads.BusinessEntity entity)
        {
            entity.AddColumn("Date", typeof(string));
            while (!entity.EOF)
            {
                entity.SetColumn("Date", EthiopianDate.EthiopianDate.GregorianToEthiopian(Convert.ToDateTime(entity.GetColumn("EurDate"))));
                entity.MoveNext();
            }
            return entity;
        }


        /// <summary>
        /// Gets the server date time.
        /// </summary>
        /// <value>
        /// The server date time.
        /// </value>
       public static DateTime ServerDateTime
       {
           get
           {
               ABC abc= new ABC();
               abc.RunQuery(HCMIS.Repository.Queries.DateTimeHelper.SelectGetDateAsDate());
               return Convert.ToDateTime(abc.GetColumn("DATE"));
           }
       }

       public static string EthiopianDateString
       {
           get { return ServerDateTime.ToEthiopianDateString(); }
       }
       

       public static string GetExpiryDateSpan(DateTime? receivedDate,DateTime? expDate)
       {
           if (expDate.Value < receivedDate.Value)
           {
               return "Expired On Receive";
           }

           TimeSpan? tsp = expDate.Value - receivedDate.Value;
           
           if (tsp != null)
           
           {
               TimeSpan ts = tsp.Value;
               string interpretation = "";
               if (ts.Days > 0)
               {
                   interpretation += string.Format("{0} days ", ts.Days);
               }
               
                   if (ts.Hours == 1)
                   {
                       if (interpretation != "")
                       {
                           interpretation += "and ";
                       }
                       interpretation += string.Format("{0} hour", ts.Hours);
                   }
                   else if (ts.Hours > 1)
                   {
                       if (interpretation != "")
                       {
                           interpretation += "and ";
                       }
                       interpretation += string.Format("{0} hours", ts.Hours);
                   }

                   if (ts.Minutes == 1)
                   {
                       if (interpretation != "")
                       {
                           interpretation += ", ";
                       }
                       interpretation += string.Format("a minute");
                   }
                   else if (ts.Minutes > 1)
                   {
                       if (interpretation != "")
                       {
                           interpretation += " and ";
                       }
                       interpretation += string.Format("{0} minutes", ts.Minutes);
                   }

               
               if (interpretation != "")
               {
                   return interpretation;
               }

           }
           return null;
       }

       public static string GetDateSpan(DateTime? startDate, DateTime? endDate)
       {
           if (endDate.Value < startDate.Value)
           {
               return "In the future";
           }

           TimeSpan? tsp = endDate.Value - startDate.Value;

           if (tsp != null)
           {
               TimeSpan ts = tsp.Value;
               string interpretation = "";
               if (ts.Days > 0)
               {
                   interpretation += string.Format("{0} days ", ts.Days);
               }

               if (ts.Hours == 1)
               {
                   if (interpretation != "")
                   {
                       interpretation += "and ";
                   }
                   interpretation += string.Format("{0} hour", ts.Hours);
               }
               else if (ts.Hours > 1)
               {
                   if (interpretation != "")
                   {
                       interpretation += "and ";
                   }
                   interpretation += string.Format("{0} hours", ts.Hours);
               }

               if (ts.Minutes == 1)
               {
                   if (interpretation != "")
                   {
                       interpretation += ", ";
                   }
                   interpretation += string.Format("a minute");
               }
               else if (ts.Minutes > 1)
               {
                   if (interpretation != "")
                   {
                       interpretation += " and ";
                   }
                   interpretation += string.Format("{0} minutes", ts.Minutes);
               }


               if (interpretation != "")
               {
                   return interpretation;
               }

           }
           return null;
       }
    }
}
