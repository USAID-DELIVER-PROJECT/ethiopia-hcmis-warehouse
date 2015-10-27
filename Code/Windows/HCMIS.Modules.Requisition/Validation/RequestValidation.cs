using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Validation
{
    public class RequestValidation
    {
        public RequestValidation()
        {
            Errors = new Collection<RequestDetailError>();
        }
        public bool Validate(Request request)
        {
            return CheckApprovedQuantity(request.RequestDetails) && CheckActivitySelect(request.RequestDetails) && CheckSplit(request.RequestDetails)  ;
        }
        
        public bool CheckSplit(ICollection<RequestDetail> requestDetails)
        {
            var result =
                requestDetails.GroupBy(
                    rd =>
                    new
                        {
                            rd.Item.ItemID,
                            rd.Unit.UnitID,
                            rd.ActivityGroup,
                            rd.Manufacturer,
                            rd.physicalStore,
                            rd.ExpiryDate
                        }, (key, group) =>
                           new
                           {
                               itemID = key.ItemID,
                               unitID = key.UnitID,
                               value = @group.Count(),
                               requestDetailID = group.Max(s => s.RequestDetailId)
                           }).Where(s => s.value > 1).ToList();
            if (!result.Any())
            {
                return true;
            }
            foreach (var requestInfo in result)
            {

                Errors.Add(new RequestDetailError(RequestErrorType.DuplicateRequestDetail) { RequestDetail = requestDetails.FirstOrDefault(s => s.RequestDetailId == requestInfo.requestDetailID) });
            }
            return false;

        }
   
        public bool CheckActivitySelect(ICollection<RequestDetail> requestDetails)
        {
            var result =requestDetails.Where(s => s.ActivityGroup == null && s.ApprovedQuantity > 0);
            if(!result.Any())
            {
                return true;
            }
            foreach (var requestInfo in result)
            {

                Errors.Add(new RequestDetailError(RequestErrorType.NoActivitySelected) { RequestDetail = requestDetails.FirstOrDefault(s => s.RequestDetailId == requestInfo.RequestDetailId) });
            }
            return false;
        }

        public bool CheckApprovedQuantity(IEnumerable<RequestDetail> requestDetail)
        {
            if (requestDetail.Sum(s => s.ApprovedQuantity) > 0)
            {
                return true;
            }
            Errors.Add(new RequestDetailError(RequestErrorType.NoApprovedQuantity));
            return false;
        }

        public ICollection<RequestDetailError> Errors { get; set; }
    }
}
