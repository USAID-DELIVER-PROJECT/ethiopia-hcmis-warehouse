using System;

namespace HCMIS.Modules.Requisition.Helpers
{
    public class CodeAttribute : Attribute
    {
        private readonly string _code;

        public CodeAttribute(string code)
        {
            _code = code;
        }

        public string Code { get { return _code; } }
    }
}
