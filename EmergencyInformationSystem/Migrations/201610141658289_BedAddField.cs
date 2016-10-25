namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BedAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Beds", "IsUseForEmpty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Beds", "IsUseForEmpty");
        }
    }
}
