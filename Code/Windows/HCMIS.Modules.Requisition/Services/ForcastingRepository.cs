using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Services
{
    public class ForcastingRepository
    {
        private readonly ItemRepository _itemRepository;
        private readonly UnitRepository _unitOfIssueRepository;

        public ForcastingRepository()
        {
            _itemRepository = new ItemRepository();
            _unitOfIssueRepository = new UnitRepository();
            
        }
        public ICollection<Forcasting> GetForcastingByOrderID(int orderId)
        {
            var orderDetail = new BLL.OrderDetail();
            var ForcastingTable = orderDetail.LoadForcastingByOrderID(orderId).DefaultView;
            ICollection<Forcasting> Forcastings = new Collection<Forcasting>();

            foreach (DataRowView ForcastingRow in ForcastingTable)
            {
                var itemID = Convert.ToInt32(ForcastingRow["ItemID"]);
                var unitID = Convert.ToInt32(ForcastingRow["UnitID"]);

                var Forcasting = new Forcasting
                                               {
                                                   Item = _itemRepository.FindSingle(Convert.ToInt32(itemID)),
                                                   Unit = _unitOfIssueRepository.FindSingle(Convert.ToInt32(unitID)),
                                                   TotalIssued = Convert.ToDecimal(ForcastingRow["TotalIssued"]),
                                                   Dos = Convert.ToDecimal(ForcastingRow["DOS"]),
                                                   FiscalYearDays = Convert.ToInt32(ForcastingRow["FiscalYearDays"])
                                               };
                Forcastings.Add(Forcasting);


            }
            return Forcastings;
        }
    }
}
