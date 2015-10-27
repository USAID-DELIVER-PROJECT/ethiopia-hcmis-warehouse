using System;
using System.Data;
using System.Linq;

namespace BLL.Helpers
{
    public class ReceiveDocConstraintHelper
    {
        private bool _isValid = true;

        public bool IsValid(DataTable dt)
        {
            var data = dt.AsEnumerable().GroupBy(a => new
            {
                ItemID = a.Field<int>("ItemID"),
                UnitID = a.Field<int>("UnitID"),
                ManufacturerID = a.Field<int>("ManufacturerID"),
                BatchNo = (a["BatchNumber"] != DBNull.Value) ? a.Field<string>("BatchNumber") : "",
                ExpiredDate = (a["ExpireDate"] != DBNull.Value) ? a.Field<DateTime>("ExpireDate") : DateTime.Now //Just giving it a dummy time.
            }).ToList();

            var duplicateRecords = data.Where(a => a.Count() > 1).Select(v => v.ToList());

            if (duplicateRecords.Any())
                _isValid = false;
            return _isValid;
        }

        public DataTable GroupByConstraints(DataTable dt)
        {
            var table = dt.AsEnumerable().GroupBy(a => new
            {
                ItemID = a.Field<int>("ItemID"),
                UnitID = a.Field<int>("UnitID"),
                ManufacturerID = a.Field<int>("ManufacturerID"),
                BatchNo = a.Field<string>("BatchNumber"),
                ExpiredDate = a.Field<DateTime?>("ExpireDate")
            }).Select(b =>
            {
                var row = b.First();
                row.SetField("Packs", b.Sum(c => c.Field<decimal>("Packs")));
                row.SetField("QuantityInBU", b.Sum(c => c.Field<decimal>("QuantityInBU")));
                return row;
            });

            return table.CopyToDataTable();
        }
    }
}
