namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "IsUseForSubscription", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsClassifiedToInDepartment", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsClassifiedToOutDepartment", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsClassifiedLeave", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsClassifiedToOther", c => c.Boolean(nullable: false));
            DropColumn("dbo.Destinations", "IsBelongToInDepartment");
            DropColumn("dbo.Destinations", "IsBelongToOutDepartment");
            DropColumn("dbo.Destinations", "IsLeave");
            DropColumn("dbo.Destinations", "IsBelongToOther");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Destinations", "IsBelongToOther", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsLeave", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsBelongToOutDepartment", c => c.Boolean(nullable: false));
            AddColumn("dbo.Destinations", "IsBelongToInDepartment", c => c.Boolean(nullable: false));
            DropColumn("dbo.Destinations", "IsClassifiedToOther");
            DropColumn("dbo.Destinations", "IsClassifiedLeave");
            DropColumn("dbo.Destinations", "IsClassifiedToOutDepartment");
            DropColumn("dbo.Destinations", "IsClassifiedToInDepartment");
            DropColumn("dbo.Destinations", "IsUseForSubscription");
        }
    }
}
