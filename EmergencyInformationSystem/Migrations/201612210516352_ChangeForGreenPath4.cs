namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForGreenPath4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GreenPathAmis", "IsHeldUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GreenPathAmis", "IsHeldUp");
        }
    }
}
