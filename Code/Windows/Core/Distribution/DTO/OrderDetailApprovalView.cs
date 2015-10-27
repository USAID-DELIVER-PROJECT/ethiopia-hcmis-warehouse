using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Concrete.Models;
using AutoMapper;

namespace HCMIS.Core.Distribution.Domains
{
    public class OrderDetailApprovalOptions : OrderDetail
    {

        public OrderDetailApprovalOptions(OrderDetail od)
        {
            
        }

        // Choices of preference
        public IEnumerable<DateTime> ExpiryDates;

        public IEnumerable<Warehouse> Locations;

        public IEnumerable<HCMIS.Concrete.Models.Manufacturer> Manufacturers;

        // views
        public string FullItemName { get; set; }
        public string Unit { get; set; }
        public int AvailableQuantity { get; set; }

        
    }
}
