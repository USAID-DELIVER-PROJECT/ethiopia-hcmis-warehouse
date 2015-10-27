namespace HCMIS.Logging.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class V1_test : DbMigration
    {
        public override void Up()
        {
            AddColumn("ActivityLog", "MACAddress", c => c.String());
            AddColumn("ActivityLog", "PCName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("ActivityLog", "PCName");
            DropColumn("ActivityLog", "MACAddress");
        }
    }
}
