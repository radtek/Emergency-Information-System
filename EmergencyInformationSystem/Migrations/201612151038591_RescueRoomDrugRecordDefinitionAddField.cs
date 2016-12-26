namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RescueRoomDrugRecordDefinitionAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RescueRoomDrugRecordDefinitions", "DrugName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RescueRoomDrugRecordDefinitions", "DrugName");
        }
    }
}
