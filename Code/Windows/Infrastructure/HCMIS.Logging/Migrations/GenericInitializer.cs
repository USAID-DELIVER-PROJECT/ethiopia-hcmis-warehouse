using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;

namespace HCMIS.Logging.Migrations
{
    class GenericInitializer<T> : IDatabaseInitializer<T> where T:DbContext
    {
        public void InitializeDatabase(T context)
        {
            try
            {
                if (context.Database.Exists())
                {
                    //if (!context.Database.CompatibleWithModel(true))
                    //{
                    //    var configuration = new Configuration();
                    //    var migrator = new DbMigrator(configuration);

                    //    var scriptor = new MigratorScriptingDecorator(migrator);
                    //    var script = scriptor.ScriptUpdate(null, null);
                    //    Console.WriteLine(script);

                    //    migrator.Update();

                    //    var pending = migrator.GetPendingMigrations();

                    //    //context.Database.Delete();
                    //}
                }
                else
                {
                    context.Database.Create();
                }
            }
            catch
            {
                // if the model doesn't look like the database,
                // skip this particular problem and work on those that you can work on
            }
        }
    }
}
