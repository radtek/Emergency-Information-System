namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckAllTimeStampAndUpdateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GreenPathCategories", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.GreenPathCategories", "UpdateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.RescueResults", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.RescueResults", "UpdateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RescueResults", "UpdateTime");
            DropColumn("dbo.RescueResults", "TimeStamp");
            DropColumn("dbo.GreenPathCategories", "UpdateTime");
            DropColumn("dbo.GreenPathCategories", "TimeStamp");
        }
    }
}
