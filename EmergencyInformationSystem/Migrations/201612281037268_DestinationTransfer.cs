namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinationTransfer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransferReasons",
                c => new
                    {
                        TransferReasonId = c.Int(nullable: false, identity: true),
                        TransferReasonName = c.String(),
                        IsUseForEmpty = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransferReasonId);
            
            AddColumn("dbo.Destinations", "IsTransfer", c => c.Boolean(nullable: false));
            AddColumn("dbo.RescueRoomInfos", "TransferReasonId", c => c.Int());
            AddColumn("dbo.RescueRoomInfos", "TransferTarget", c => c.String());
            AddColumn("dbo.ObserveRoomInfos", "TransferReasonId", c => c.Int());
            AddColumn("dbo.ObserveRoomInfos", "TransferTarget", c => c.String());
            CreateIndex("dbo.RescueRoomInfos", "TransferReasonId");
            CreateIndex("dbo.ObserveRoomInfos", "TransferReasonId");
            AddForeignKey("dbo.ObserveRoomInfos", "TransferReasonId", "dbo.TransferReasons", "TransferReasonId");
            AddForeignKey("dbo.RescueRoomInfos", "TransferReasonId", "dbo.TransferReasons", "TransferReasonId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RescueRoomInfos", "TransferReasonId", "dbo.TransferReasons");
            DropForeignKey("dbo.ObserveRoomInfos", "TransferReasonId", "dbo.TransferReasons");
            DropIndex("dbo.ObserveRoomInfos", new[] { "TransferReasonId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "TransferReasonId" });
            DropColumn("dbo.ObserveRoomInfos", "TransferTarget");
            DropColumn("dbo.ObserveRoomInfos", "TransferReasonId");
            DropColumn("dbo.RescueRoomInfos", "TransferTarget");
            DropColumn("dbo.RescueRoomInfos", "TransferReasonId");
            DropColumn("dbo.Destinations", "IsTransfer");
            DropTable("dbo.TransferReasons");
        }
    }
}
