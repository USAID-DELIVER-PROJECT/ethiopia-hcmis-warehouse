using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Extensions.Enums.Attributes;

namespace HCMIS.Extensions.Enums
{
    public static class EnumExtension
    {
        public static string GetCode<TType>(this TType value ) where TType:IConvertible
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(TableCodeAttribute), false);
            var description = ((TableCodeAttribute)attributes[0]).TableCode;
            return description;
        }
    }
}
