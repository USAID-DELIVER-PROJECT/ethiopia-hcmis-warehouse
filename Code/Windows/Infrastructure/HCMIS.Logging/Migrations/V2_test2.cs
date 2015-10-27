namespace HCMIS.Logging.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("ActivityLog", "IPAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("ActivityLog", "IPAddress");
        }
    }
}
