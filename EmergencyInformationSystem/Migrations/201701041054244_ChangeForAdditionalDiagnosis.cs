namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeForAdditionalDiagnosis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RescueRoomInfos", "AdditionalDiagnosis", c => c.String());
            AddColumn("dbo.ObserveRoomInfos", "AdditionalDiagnosis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ObserveRoomInfos", "AdditionalDiagnosis");
            DropColumn("dbo.RescueRoomInfos", "AdditionalDiagnosis");
        }
    }
}
