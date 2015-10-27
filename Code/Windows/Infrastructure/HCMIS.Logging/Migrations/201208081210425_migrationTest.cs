namespace HCMIS.Logging.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class migrationTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("ActivityLog", "MigrationProperty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("ActivityLog", "MigrationProperty");
        }
    }
}
