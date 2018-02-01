namespace EmergencyInformationSystem.Models.Domains2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "ControllerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "ControllerName");
        }
    }
}
