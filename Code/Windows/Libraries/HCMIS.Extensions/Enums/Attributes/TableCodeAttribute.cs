using System;

namespace HCMIS.Extensions.Enums.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class TableCodeAttribute : Attribute
    {
        private readonly string _tableCode;

        public TableCodeAttribute(string tableCode)
        {
            _tableCode = tableCode;
        }

        public string TableCode
        {
            get { return _tableCode; }
        }
    }
}
