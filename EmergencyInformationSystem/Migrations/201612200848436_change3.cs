namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "Priority2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destinations", "Priority2");
        }
    }
}
