using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Helpers;

namespace HCMIS.Security.UserManagement.ViewModels
{
    class ViewModelBase
    {
        private IUnitOfWork _repository;

        protected IUnitOfWork Repository
        {
            get { return _repository ?? (_repository = UnitOfWork.CreateInstance()); }
        }
    }
}
