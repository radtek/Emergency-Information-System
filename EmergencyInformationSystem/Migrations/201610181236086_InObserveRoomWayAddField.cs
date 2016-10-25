namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InObserveRoomWayAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InObserveRoomWays", "IsUseForEmpty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InObserveRoomWays", "IsUseForEmpty");
        }
    }
}
