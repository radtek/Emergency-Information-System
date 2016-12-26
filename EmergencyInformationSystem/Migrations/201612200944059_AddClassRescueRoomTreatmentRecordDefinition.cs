namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassRescueRoomTreatmentRecordDefinition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RescueRoomTreatmentRecordDefinitions",
                c => new
                    {
                        RescueRoomTreatmentRecordDefinitionId = c.Int(nullable: false, identity: true),
                        TreatmentCode = c.String(),
                        TreatmentName = c.String(),
                        GreenPathCode = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RescueRoomTreatmentRecordDefinitionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RescueRoomTreatmentRecordDefinitions");
        }
    }
}
