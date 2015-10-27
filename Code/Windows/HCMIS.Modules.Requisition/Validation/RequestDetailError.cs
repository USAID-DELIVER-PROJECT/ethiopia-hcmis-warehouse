using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Modules.Requisition.Domain;

namespace HCMIS.Modules.Requisition.Validation
{
    public  class RequestDetailError
    {
        private string _errorMessage;
        private readonly RequestErrorType _errorType;
        public RequestDetailError( RequestErrorType errorType)
        {
            _errorType = errorType;
        }

        public RequestErrorType ErrorType { get { return _errorType; } }
        public RequestDetail RequestDetail { get; set; }
    }
}


