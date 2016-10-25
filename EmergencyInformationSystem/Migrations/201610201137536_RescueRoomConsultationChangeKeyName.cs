namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RescueRoomConsultationChangeKeyName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RescueRoomConsultations");
            AddColumn("dbo.RescueRoomConsultations", "RescueRoomConsultationId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.RescueRoomConsultations", "RescueRoomConsultationId");
            DropColumn("dbo.RescueRoomConsultations", "ConsultationInfoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RescueRoomConsultations", "ConsultationInfoId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.RescueRoomConsultations");
            DropColumn("dbo.RescueRoomConsultations", "RescueRoomConsultationId");
            AddPrimaryKey("dbo.RescueRoomConsultations", "ConsultationInfoId");
        }
    }
}
