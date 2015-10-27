using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HCMIS.Security.Models;

namespace HCMIS.Security.DataContext
{
    public class SecurityContext : DbContext
    {
        public SecurityContext()
            : base(Settings.ConnectionString)
        {
           
        }

        public SecurityContext(string connectionString)
            : base(connectionString)
        {
            
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Operation> Operations { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Activity> Accounts { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreUser> StoreUsers { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemGroup> MenuItemGroups { get; set; }
        public DbSet<GeneralInfo> GeneralInfos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOptional(u => u.CreatedBy).WithMany().HasForeignKey(c => c.CreatedByID);
            modelBuilder.Entity<Group>().HasOptional(g => g.Parent).WithMany().HasForeignKey(p => p.ParentID);
         
        }
    }
}
