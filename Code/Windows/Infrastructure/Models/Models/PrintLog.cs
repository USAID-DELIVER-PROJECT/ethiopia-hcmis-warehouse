using System;
using System.Collections.Generic;

namespace HCMIS.Concrete.Models
{
    public class PrintLog
    {
        public PrintLog()
        {
            
        }

        public int ID { get; set; }
        public string Type { get; set; }
        public int Reference { get; set; }
        public string Printer{get;set; }
        public byte[] Value { get; set; }
        public DateTime PrintedDate { get; set; }
        public bool IsPrinted { get; set; }
        public int PrintedBy { get; set; }


        
    }
}