using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMIS.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FormIdentifierAttribute : Attribute
    {
        public FormIdentifierAttribute(string identifier,string title, string description)
        {
            _identifier = identifier;
            _title = title;
            _description = description;
        }

        private string _identifier;

        public string Identifier
        {
            get { return _identifier; }            
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }



    }
}
