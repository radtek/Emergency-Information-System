namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassRescueRoomTreatmentRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RescueRoomTreatmentRecords",
                c => new
                    {
                        RescueRoomTreatmentRecordId = c.Guid(nullable: false),
                        RescueRoomInfoId = c.Int(nullable: false),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        GoodsName = c.String(),
                        DosageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DosageUnit = c.String(),
                        PrescriptionTime = c.DateTime(),
                        Usage = c.String(),
                        CFMXID = c.Guid(nullable: false),
                        CFID = c.Guid(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RescueRoomTreatmentRecordId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RescueRoomTreatmentRecords", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropIndex("dbo.RescueRoomTreatmentRecords", new[] { "RescueRoomInfoId" });
            DropTable("dbo.RescueRoomTreatmentRecords");
        }
    }
}
