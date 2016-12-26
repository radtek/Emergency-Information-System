namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassRescueRoomDrugRecordDefinition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RescueRoomDrugRecordDefinitions",
                c => new
                    {
                        RescueRoomDrugRecordDefinitionId = c.Int(nullable: false, identity: true),
                        DrugCode = c.String(),
                    })
                .PrimaryKey(t => t.RescueRoomDrugRecordDefinitionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RescueRoomDrugRecordDefinitions");
        }
    }
}
