namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForPorfessional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RescueRoomInfos", "ProfessionalTarget", c => c.String());
            AddColumn("dbo.ObserveRoomInfos", "ProfessionalTarget", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ObserveRoomInfos", "ProfessionalTarget");
            DropColumn("dbo.RescueRoomInfos", "ProfessionalTarget");
        }
    }
}
