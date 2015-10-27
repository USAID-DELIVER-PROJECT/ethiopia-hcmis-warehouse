using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace HCMIS.Security.Models
{
    class SecurityDataContext : DbContext
    {
        public SecurityDataContext()
            : base(Settings.ConnectionString)
        {
        }

        public SecurityDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
