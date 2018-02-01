namespace EmergencyInformationSystem.Models.Domains3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialGeneral : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beds",
                c => new
                    {
                        BedId = c.Guid(nullable: false),
                        BedName = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        IsUseForRescueRoom = c.Boolean(nullable: false),
                        IsUseForObserveRoom = c.Boolean(nullable: false),
                        IsUseForResuscitateRoom = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BedId)
                .Index(t => t.BedName, unique: true);
            
            CreateTable(
                "dbo.CriticalLevels",
                c => new
                    {
                        CriticalLevelId = c.Guid(nullable: false),
                        CriticalLevelName = c.String(nullable: false, maxLength: 30),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CriticalLevelId)
                .Index(t => t.CriticalLevelName, unique: true);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Guid(nullable: false),
                        DestinationName = c.String(nullable: false, maxLength: 30),
                        Priority2 = c.Int(nullable: false),
                        IsUseForRescueRoom = c.Boolean(nullable: false),
                        IsUseForObserveRoom = c.Boolean(nullable: false),
                        IsUseForResuscitateRoom = c.Boolean(nullable: false),
                        IsUseForSubscription = c.Boolean(nullable: false),
                        IsUseForConsultation = c.Boolean(nullable: false),
                        IsToInDepartment = c.Boolean(nullable: false),
                        IsToOutDepartment = c.Boolean(nullable: false),
                        IsToLeave = c.Boolean(nullable: false),
                        IsToOther = c.Boolean(nullable: false),
                        IsHasAdditionalInfo = c.Boolean(nullable: false),
                        IsTransferHospital = c.Boolean(nullable: false),
                        IsNeedProfessional = c.Boolean(nullable: false),
                        IsTransferRoom = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DestinationId)
                .Index(t => t.DestinationName, unique: true);
            
            CreateTable(
                "dbo.GeneralRoomInfos",
                c => new
                    {
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        RoomId = c.Guid(nullable: false),
                        PreGeneralRoomInfoId = c.Guid(),
                        PatientName = c.String(),
                        OutPatientNumber = c.String(nullable: false),
                        Sex = c.String(),
                        BirthDate = c.DateTime(),
                        DiagnosisNameOrigin = c.String(),
                        ReceiveTime = c.DateTime(),
                        FirstDoctorName = c.String(),
                        InDepartmentTime = c.DateTime(nullable: false),
                        BedNumber = c.String(),
                        BedId = c.Guid(),
                        FirstNurseName = c.String(),
                        InRoomWayId = c.Guid(),
                        InRoomWayRemarks = c.String(),
                        AdditionalDiagnosis = c.String(),
                        CriticalLevelId = c.Guid(),
                        IsRescue = c.Boolean(nullable: false),
                        RescueResultId = c.Guid(),
                        GreenPathCategoryId = c.Guid(),
                        GreenPathCategoryRemarks = c.String(),
                        Antibiotic = c.String(),
                        Remarks = c.String(),
                        DestinationFirstId = c.Guid(),
                        DestinationFirstTime = c.DateTime(),
                        DestinationFirstContact = c.String(),
                        DestinationSecondId = c.Guid(),
                        OutDepartmentTime = c.DateTime(),
                        DestinationId = c.Guid(),
                        DestinationRemarks = c.String(),
                        HandleNurse = c.String(),
                        DiagnosisName = c.String(),
                        TransferReasonId = c.Guid(),
                        TransferTarget = c.String(),
                        ProfessionalTarget = c.String(),
                        KDJID = c.Guid(),
                        BRXXID = c.Guid(),
                        GHXXID = c.Guid(),
                        JZID = c.Guid(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GeneralRoomInfoId)
                .ForeignKey("dbo.Beds", t => t.BedId)
                .ForeignKey("dbo.CriticalLevels", t => t.CriticalLevelId)
                .ForeignKey("dbo.Destinations", t => t.DestinationId)
                .ForeignKey("dbo.Destinations", t => t.DestinationFirstId)
                .ForeignKey("dbo.Destinations", t => t.DestinationSecondId)
                .ForeignKey("dbo.GreenPathCategories", t => t.GreenPathCategoryId)
                .ForeignKey("dbo.InRoomWays", t => t.InRoomWayId)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.PreGeneralRoomInfoId)
                .ForeignKey("dbo.RescueResults", t => t.RescueResultId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.TransferReasons", t => t.TransferReasonId)
                .Index(t => t.RoomId)
                .Index(t => t.PreGeneralRoomInfoId)
                .Index(t => t.BedId)
                .Index(t => t.InRoomWayId)
                .Index(t => t.CriticalLevelId)
                .Index(t => t.RescueResultId)
                .Index(t => t.GreenPathCategoryId)
                .Index(t => t.DestinationFirstId)
                .Index(t => t.DestinationSecondId)
                .Index(t => t.DestinationId)
                .Index(t => t.TransferReasonId)
                .Index(t => t.JZID, unique: true);
            
            CreateTable(
                "dbo.GreenPathCategories",
                c => new
                    {
                        GreenPathCategoryId = c.Guid(nullable: false),
                        GreenPathCategoryName = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        IsHasAdditionalInfo = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GreenPathCategoryId)
                .Index(t => t.GreenPathCategoryName, unique: true);
            
            CreateTable(
                "dbo.InRoomWays",
                c => new
                    {
                        InRoomWayId = c.Guid(nullable: false),
                        InRoomWayName = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        IsUseForRescueRoom = c.Boolean(nullable: false),
                        IsUseForObserveRoom = c.Boolean(nullable: false),
                        IsUseForResuscitateRoom = c.Boolean(nullable: false),
                        IsTransferRoom = c.Boolean(nullable: false),
                        IsHasAdditionalInfo = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InRoomWayId)
                .Index(t => t.InRoomWayName, unique: true);
            
            CreateTable(
                "dbo.RescueResults",
                c => new
                    {
                        RescueResultId = c.Guid(nullable: false),
                        RescueResultName = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RescueResultId)
                .Index(t => t.RescueResultName, unique: true);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Guid(nullable: false),
                        RoomName = c.String(nullable: false, maxLength: 30),
                        ControllerName = c.String(),
                        IsRescueRoom = c.Boolean(nullable: false),
                        IsObserveRoom = c.Boolean(nullable: false),
                        IsResuscitateRoom = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .Index(t => t.RoomName, unique: true);
            
            CreateTable(
                "dbo.TransferReasons",
                c => new
                    {
                        TransferReasonId = c.Guid(nullable: false),
                        TransferReasonName = c.String(nullable: false, maxLength: 30),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransferReasonId)
                .Index(t => t.TransferReasonName, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralRoomInfos", "TransferReasonId", "dbo.TransferReasons");
            DropForeignKey("dbo.GeneralRoomInfos", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.GeneralRoomInfos", "RescueResultId", "dbo.RescueResults");
            DropForeignKey("dbo.GeneralRoomInfos", "PreGeneralRoomInfoId", "dbo.GeneralRoomInfos");
            DropForeignKey("dbo.GeneralRoomInfos", "InRoomWayId", "dbo.InRoomWays");
            DropForeignKey("dbo.GeneralRoomInfos", "GreenPathCategoryId", "dbo.GreenPathCategories");
            DropForeignKey("dbo.GeneralRoomInfos", "DestinationSecondId", "dbo.Destinations");
            DropForeignKey("dbo.GeneralRoomInfos", "DestinationFirstId", "dbo.Destinations");
            DropForeignKey("dbo.GeneralRoomInfos", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.GeneralRoomInfos", "CriticalLevelId", "dbo.CriticalLevels");
            DropForeignKey("dbo.GeneralRoomInfos", "BedId", "dbo.Beds");
            DropIndex("dbo.TransferReasons", new[] { "TransferReasonName" });
            DropIndex("dbo.Rooms", new[] { "RoomName" });
            DropIndex("dbo.RescueResults", new[] { "RescueResultName" });
            DropIndex("dbo.InRoomWays", new[] { "InRoomWayName" });
            DropIndex("dbo.GreenPathCategories", new[] { "GreenPathCategoryName" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "JZID" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "TransferReasonId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "DestinationId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "DestinationSecondId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "DestinationFirstId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "GreenPathCategoryId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "RescueResultId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "CriticalLevelId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "InRoomWayId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "BedId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "PreGeneralRoomInfoId" });
            DropIndex("dbo.GeneralRoomInfos", new[] { "RoomId" });
            DropIndex("dbo.Destinations", new[] { "DestinationName" });
            DropIndex("dbo.CriticalLevels", new[] { "CriticalLevelName" });
            DropIndex("dbo.Beds", new[] { "BedName" });
            DropTable("dbo.TransferReasons");
            DropTable("dbo.Rooms");
            DropTable("dbo.RescueResults");
            DropTable("dbo.InRoomWays");
            DropTable("dbo.GreenPathCategories");
            DropTable("dbo.GeneralRoomInfos");
            DropTable("dbo.Destinations");
            DropTable("dbo.CriticalLevels");
            DropTable("dbo.Beds");
        }
    }
}
