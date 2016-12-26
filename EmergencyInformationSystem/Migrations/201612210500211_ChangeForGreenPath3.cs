namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForGreenPath3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Destinations", "IsUseForGreenPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Destinations", "IsUseForGreenPath", c => c.Boolean(nullable: false));
        }
    }
}
