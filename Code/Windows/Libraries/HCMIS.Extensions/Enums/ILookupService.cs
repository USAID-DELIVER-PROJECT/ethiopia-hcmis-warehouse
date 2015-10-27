using System;

namespace HCMIS.Extensions.Enums
{
    public interface ILookupService<TType> where TType : class
    {
        TType Get(IConvertible value);
    }
}
