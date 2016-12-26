namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "Priority", c => c.Boolean(nullable: false));
            AddColumn("dbo.RescueRoomDrugRecords", "Usage", c => c.String());
            AddColumn("dbo.RescueRoomDrugRecords", "CFID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RescueRoomDrugRecords", "CFID");
            DropColumn("dbo.RescueRoomDrugRecords", "Usage");
            DropColumn("dbo.Destinations", "Priority");
        }
    }
}
