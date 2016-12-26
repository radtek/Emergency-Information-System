namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForGreenPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "IsUseForGreenPath", c => c.Boolean(nullable: false));
            AddColumn("dbo.GreenPathAmis", "DestinationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GreenPathAmis", "DestinationId");
            DropColumn("dbo.Destinations", "IsUseForGreenPath");
        }
    }
}
