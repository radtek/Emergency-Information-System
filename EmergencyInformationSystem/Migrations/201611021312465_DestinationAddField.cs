namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinationAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "IsGotoRescueRoom", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsGotoObserveRoom", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destinations", "IsGotoObserveRoom");
            DropColumn("dbo.Destinations", "IsGotoRescueRoom");
        }
    }
}
