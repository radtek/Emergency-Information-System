namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RescueRoomDrugRecordDefinitions", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.RescueRoomDrugRecordDefinitions", "UpdateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RescueRoomDrugRecordDefinitions", "UpdateTime");
            DropColumn("dbo.RescueRoomDrugRecordDefinitions", "TimeStamp");
        }
    }
}
