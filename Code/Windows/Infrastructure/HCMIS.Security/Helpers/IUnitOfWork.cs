using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Repository;

namespace HCMIS.Security.Helpers
{
    public interface IUnitOfWork: IDisposable
    {
        UserRepository Users { get; set; }
        AccountRepository Accounts { get; set; }
        DepartmentRepository Departments { get; set; }
        GroupRepository Groups { get; set; }
        JobTitleRepository JobTitles { get; set; }
        OperationRepository Operations { get; set; }
        ResourceTypeRepository ResourceTypes { get; set; }
        StoreRepository Stores { get; set; }
        AccountUserRepository AccountUsers { get; set; }
        StoreUserRepository StoreUsers { get; set; }
        UserGroupRepository UserGroups { get; set; }
        GroupPermissionRepository GroupPermissions { get; set; }
        MenuItemRepository MenuItems { get; set; }
        MenuItemGroupRepository MenuItemGroups { get; set; }
        GeneralInfoRepository GeneralInfo { get; set; }

        IEnumerable<T1> RawSql<T1>(string query);
    }
}
