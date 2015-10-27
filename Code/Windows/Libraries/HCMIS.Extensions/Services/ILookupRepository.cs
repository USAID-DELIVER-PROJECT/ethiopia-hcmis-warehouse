using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Extensions.Binding;

namespace HCMIS.Extensions.Services
{
    public interface ILookupRepository
    {
        IQueryable<TType> Get<TType>()where TType:class;
        ICollection<LookUpModel> GetLookups<TEnum>(EnumDescriptor enumDescriptor) where TEnum : IConvertible;
        ICollection<LookUpModel> GetLookups<TEnum>() where TEnum : IConvertible;
        BindingManager BindingManager { get; set; }
    }
}
