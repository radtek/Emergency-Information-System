namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectRescueRoomInfoAndObserveRoomInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RescueRoomInfos", "NextObserveRoomInfo_ObserveRoomInfoId", c => c.Guid());
            AddColumn("dbo.ObserveRoomInfos", "NextRescueRoomInfo_RescueRoomInfoId", c => c.Int());
            CreateIndex("dbo.RescueRoomInfos", "NextObserveRoomInfo_ObserveRoomInfoId");
            CreateIndex("dbo.ObserveRoomInfos", "NextRescueRoomInfo_RescueRoomInfoId");
            AddForeignKey("dbo.ObserveRoomInfos", "NextRescueRoomInfo_RescueRoomInfoId", "dbo.RescueRoomInfos", "RescueRoomInfoId");
            AddForeignKey("dbo.RescueRoomInfos", "NextObserveRoomInfo_ObserveRoomInfoId", "dbo.ObserveRoomInfos", "ObserveRoomInfoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RescueRoomInfos", "NextObserveRoomInfo_ObserveRoomInfoId", "dbo.ObserveRoomInfos");
            DropForeignKey("dbo.ObserveRoomInfos", "NextRescueRoomInfo_RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropIndex("dbo.ObserveRoomInfos", new[] { "NextRescueRoomInfo_RescueRoomInfoId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "NextObserveRoomInfo_ObserveRoomInfoId" });
            DropColumn("dbo.ObserveRoomInfos", "NextRescueRoomInfo_RescueRoomInfoId");
            DropColumn("dbo.RescueRoomInfos", "NextObserveRoomInfo_ObserveRoomInfoId");
        }
    }
}
