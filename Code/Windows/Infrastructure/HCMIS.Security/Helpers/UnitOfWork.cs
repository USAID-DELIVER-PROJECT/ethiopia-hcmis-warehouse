using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMIS.Security.Repository;
using HCMIS.Security.DataContext;

namespace HCMIS.Security.Helpers
{
    public class UnitOfWork : IUnitOfWork
    {
        private static UnitOfWork _Instance = null;

        private SecurityContext context = new SecurityContext();

        private UnitOfWork()
        {
            RefreshContext();
        }

        public static UnitOfWork CreateInstance()
        {
            if (_Instance == null)
            {
                _Instance = new UnitOfWork();
            }
            return _Instance;
        }

        #region Fields
        private AccountRepository _accounts;
        private AccountUserRepository _accountUsers;
        private DepartmentRepository _departments;
        private GroupRepository _groups;
        private GroupPermissionRepository _groupPermissions;
        private JobTitleRepository _jobTitles;
        private OperationRepository _operations;
        
        private ResourceTypeRepository _resourceTypes;
        private StoreRepository _stores;
        private UserRepository _users;
        private UserGroupRepository _userGroups;
        private StoreUserRepository _storeUsers;
        private MenuItemRepository _menuItems;
        private MenuItemGroupRepository _menuItemGroups;
        private GeneralInfoRepository _generalInfo;
        #endregion

        #region Properties
        public StoreUserRepository StoreUsers
        {
            get { return _storeUsers ?? (_storeUsers = new StoreUserRepository(context)); }
            set { _storeUsers = value; }
        }


        public UserGroupRepository UserGroups
        {
            get { return _userGroups ?? (_userGroups = new UserGroupRepository(context)); }
            set { _userGroups = value; }
        }


        public UserRepository Users
        {
            get { return _users ?? (_users = new UserRepository(context)); }
            set { _users = value; }
        }


        public StoreRepository Stores
        {
            get { return _stores ?? (_stores = new StoreRepository(context)); }
            set { _stores = value; }
        }


        public ResourceTypeRepository ResourceTypes
        {
            get { return _resourceTypes ?? (_resourceTypes = new ResourceTypeRepository(context)); }
            set { _resourceTypes = value; }
        }



        public OperationRepository Operations
        {
            get { return _operations ?? (_operations = new OperationRepository(context)); }
            set { _operations = value; }
        }


        public JobTitleRepository JobTitles
        {
            get { return _jobTitles ?? (_jobTitles = new JobTitleRepository(context)); }
            set { _jobTitles = value; }
        }


        public GroupPermissionRepository GroupPermissions
        {
            get { return _groupPermissions ?? (_groupPermissions = new GroupPermissionRepository(context)); }
            set { _groupPermissions = value; }
        }


        public GroupRepository Groups
        {
            get { return _groups ?? (_groups = new GroupRepository(context)); }
            set { _groups = value; }
        }


        public DepartmentRepository Departments
        {
            get { return _departments ?? (_departments = new DepartmentRepository(context)); }
            set { _departments = value; }
        }


        public AccountUserRepository AccountUsers
        {
            get { return _accountUsers ?? (_accountUsers = new AccountUserRepository(context)); }
            set { _accountUsers = value; }
        }


        public AccountRepository Accounts
        {
            get { return _accounts ?? (_accounts = new AccountRepository(context)); }
            set { _accounts = value; }
        }

        public MenuItemRepository MenuItems
        {
            get { return _menuItems ?? (_menuItems = new MenuItemRepository(context)); }
            set { _menuItems = value; }
        }

        public MenuItemGroupRepository MenuItemGroups
        {
            get { return _menuItemGroups ?? (_menuItemGroups = new MenuItemGroupRepository(context)); }
            set { _menuItemGroups = value; }
        }

        public GeneralInfoRepository GeneralInfo
        {
            get { return _generalInfo ?? (_generalInfo = new GeneralInfoRepository(context)); }
            set { _generalInfo = value; }
        }

        #endregion


        public void Dispose()
        {
            context.Dispose();
          //  context = new SecurityContext();
        }

        public void RefreshContext()
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.LazyLoadingEnabled = true;
            context.Configuration.AutoDetectChangesEnabled = true;
        }

        public IEnumerable<T> RawSql<T>(string query)
        {
            return context.Database.SqlQuery<T>(query);

        } 
    }        
}
