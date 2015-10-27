using System;
using HCMIS.Modules.Requisition.Helpers;

namespace HCMIS.Modules.Requisition.Services
{
    public class EnumService<T>where T:IConvertible
    {
        public static T GetEnum(string code)
        {
            var enums = typeof (T).GetMembers();
            foreach (var enumeration in enums)
            {
                
                var attribute =enumeration.GetCustomAttributes(typeof (CodeAttribute), false);
                if(attribute.Length > 0 && ((CodeAttribute) attribute[0]).Code == code)
                {
                    return (T) Enum.Parse(typeof(T),enumeration.Name); ;
                }
                
            }
            throw new Exception("Code Does not Exist for this enum Type");
        }
        public static string GetCode(T value)
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(CodeAttribute), false);
            var description = ((CodeAttribute)attributes[0]).Code;
            return description;
        }

    }
}
