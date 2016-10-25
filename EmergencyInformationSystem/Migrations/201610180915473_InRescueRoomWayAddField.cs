namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InRescueRoomWayAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InRescueRoomWays", "IsUseForEmpty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InRescueRoomWays", "IsUseForEmpty");
        }
    }
}
