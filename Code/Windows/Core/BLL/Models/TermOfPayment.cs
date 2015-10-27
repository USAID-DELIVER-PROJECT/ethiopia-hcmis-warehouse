using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class TermOfPayment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<TermOfPayment> List = new List<TermOfPayment>()
        {
            new TermOfPayment(){ ID = 1, Name="L/C",Description ="Letter of Credit"},
            new TermOfPayment(){ ID = 2, Name="PIA",Description ="Payement In Advance"},
            new TermOfPayment(){ ID = 3, Name="C/A",Description ="Cash Account"},
            new TermOfPayment(){ ID = 4, Name="Contra",Description ="Payment from the customer offset against the value of supplies purchased from the customer"},
            new TermOfPayment(){ ID = 5, Name="NET 30",Description ="Payement 30 days After Invoice Date"},
            new TermOfPayment(){ ID = 6, Name="NET 60",Description ="Payement 60 days After Invoice Date"},
            new TermOfPayment(){ ID = 7, Name="Internal",Description ="Internal"}  

        };
    }
}
