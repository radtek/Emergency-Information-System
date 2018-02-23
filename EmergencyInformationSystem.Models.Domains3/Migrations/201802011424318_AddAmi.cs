namespace EmergencyInformationSystem.Models.Domains3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GreenPathAmiInfos",
                c => new
                    {
                        GreenPathAmiInfoId = c.Guid(nullable: false),
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        OccurrenceTime = c.DateTime(),
                        EcgFirstTime = c.DateTime(),
                        EcgSecondTime = c.DateTime(),
                        Remarks = c.String(),
                        FinishPathTime = c.DateTime(),
                        IsHeldUp = c.Boolean(nullable: false),
                        Problem = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GreenPathAmiInfoId)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.GeneralRoomInfoId, cascadeDelete: true)
                .Index(t => t.GeneralRoomInfoId, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GreenPathAmiInfos", "GeneralRoomInfoId", "dbo.GeneralRoomInfos");
            DropIndex("dbo.GreenPathAmiInfos", new[] { "GeneralRoomInfoId" });
            DropTable("dbo.GreenPathAmiInfos");
        }
    }
}
