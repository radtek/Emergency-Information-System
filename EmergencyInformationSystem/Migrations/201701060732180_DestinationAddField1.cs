namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DestinationAddField1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "IsProfessional", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destinations", "IsProfessional");
        }
    }
}
