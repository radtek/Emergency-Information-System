namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RescueRoomDrugRecordDefinitionAddField2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RescueRoomDrugRecordDefinitions", "GreenPathCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RescueRoomDrugRecordDefinitions", "GreenPathCode");
        }
    }
}
