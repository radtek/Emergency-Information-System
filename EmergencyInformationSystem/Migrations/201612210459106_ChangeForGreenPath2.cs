namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForGreenPath2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GreenPathAmis", "DestinationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GreenPathAmis", "DestinationId", c => c.Int(nullable: false));
        }
    }
}
