using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace HCMIS.Logging.Models
{
    public class LoggingContext : DbContext
    {
        public LoggingContext()
            : base(LogManager.ConnectionString)
        {
        }

        public LoggingContext(string name)
            : base(name)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().ToTable("dbo.Log");
            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<Log> Logs { get; set; }
    }
}
