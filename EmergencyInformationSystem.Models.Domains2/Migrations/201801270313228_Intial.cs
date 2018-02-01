namespace EmergencyInformationSystem.Models.Domains2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
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
                        Code = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BedId)
                .Index(t => t.BedName, unique: true);
            
            CreateTable(
                "dbo.Consultation",
                c => new
                    {
                        ConsultationId = c.Guid(nullable: false),
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                        ArriveTime = c.DateTime(),
                        ConsultationDoctorName = c.String(nullable: false),
                        ConsultationDepartmentId = c.Guid(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConsultationId)
                .ForeignKey("dbo.Destinations", t => t.ConsultationDepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.GeneralRoomInfoId, cascadeDelete: true)
                .Index(t => t.GeneralRoomInfoId)
                .Index(t => t.ConsultationDepartmentId);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Guid(nullable: false),
                        DestinationName = c.String(nullable: false, maxLength: 30),
                        Priority2 = c.Int(nullable: false),
                        DestinationCode = c.Int(nullable: false),
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
                "dbo.GreenPathCategories",
                c => new
                    {
                        GreenPathCategoryId = c.Guid(nullable: false),
                        GreenPathCategoryName = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        GreenPathCategoryCode = c.Int(nullable: false),
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
                        InRoomWayCode = c.Int(nullable: false),
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
                        RoomCode = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.DrugRecordDefinitions",
                c => new
                    {
                        DrugRecordDefinitionId = c.Guid(nullable: false),
                        GreenPathCategoryId = c.Guid(nullable: false),
                        DrugCode = c.String(),
                        DrugName = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DrugRecordDefinitionId)
                .ForeignKey("dbo.GreenPathCategories", t => t.GreenPathCategoryId, cascadeDelete: true)
                .Index(t => t.GreenPathCategoryId);
            
            CreateTable(
                "dbo.DrugRecords",
                c => new
                    {
                        DrugRecordId = c.Guid(nullable: false),
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        GoodsName = c.String(),
                        DosageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DosageUnit = c.String(),
                        PrescriptionTime = c.DateTime(),
                        Usage = c.String(),
                        CFMXID = c.Guid(nullable: false),
                        CFID = c.Guid(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DrugRecordId)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.GeneralRoomInfoId, cascadeDelete: true)
                .Index(t => t.GeneralRoomInfoId)
                .Index(t => t.CFMXID, unique: true);
            
            CreateTable(
                "dbo.GreenPathAmiInfoes",
                c => new
                    {
                        GreenPathAmiId = c.Guid(nullable: false),
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        OccurrenceTime = c.DateTime(),
                        EcgFirstTime = c.DateTime(),
                        EcgSecondTime = c.DateTime(),
                        Remarks = c.String(),
                        FinishPathTime = c.DateTime(),
                        IsHeldUp = c.Boolean(nullable: false),
                        Problem = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GreenPathAmiId)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.GeneralRoomInfoId, cascadeDelete: true)
                .Index(t => t.GeneralRoomInfoId, unique: true);
            
            CreateTable(
                "dbo.ImageCategories",
                c => new
                    {
                        ImageCategoryId = c.Guid(nullable: false),
                        ImageCategoryName = c.String(nullable: false, maxLength: 30),
                        OriginCode = c.String(maxLength: 30),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ImageCategoryId)
                .Index(t => t.ImageCategoryName, unique: true)
                .Index(t => t.OriginCode, unique: true);
            
            CreateTable(
                "dbo.ImageRecords",
                c => new
                    {
                        ImageRecordId = c.Guid(nullable: false),
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        ImageCategoryId = c.Guid(nullable: false),
                        BookTime = c.DateTime(),
                        CheckTime = c.DateTime(),
                        ReportTime = c.DateTime(),
                        Part = c.String(),
                        Category = c.String(),
                        BOOKID = c.String(maxLength: 30),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ImageRecordId)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.GeneralRoomInfoId, cascadeDelete: true)
                .ForeignKey("dbo.ImageCategories", t => t.ImageCategoryId, cascadeDelete: true)
                .Index(t => t.GeneralRoomInfoId)
                .Index(t => t.ImageCategoryId)
                .Index(t => t.BOOKID, unique: true);
            
            CreateTable(
                "dbo.TreatmentRecords",
                c => new
                    {
                        TreatmentRecordId = c.Guid(nullable: false),
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        ProductCode = c.String(),
                        ProductName = c.String(),
                        GoodsName = c.String(),
                        DosageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DosageUnit = c.String(),
                        PrescriptionTime = c.DateTime(),
                        Usage = c.String(),
                        CFMXID = c.Guid(nullable: false),
                        CFID = c.Guid(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TreatmentRecordId)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.GeneralRoomInfoId, cascadeDelete: true)
                .Index(t => t.GeneralRoomInfoId)
                .Index(t => t.CFMXID, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreatmentRecords", "GeneralRoomInfoId", "dbo.GeneralRoomInfos");
            DropForeignKey("dbo.ImageRecords", "ImageCategoryId", "dbo.ImageCategories");
            DropForeignKey("dbo.ImageRecords", "GeneralRoomInfoId", "dbo.GeneralRoomInfos");
            DropForeignKey("dbo.GreenPathAmiInfoes", "GeneralRoomInfoId", "dbo.GeneralRoomInfos");
            DropForeignKey("dbo.DrugRecords", "GeneralRoomInfoId", "dbo.GeneralRoomInfos");
            DropForeignKey("dbo.DrugRecordDefinitions", "GreenPathCategoryId", "dbo.GreenPathCategories");
            DropForeignKey("dbo.Consultation", "GeneralRoomInfoId", "dbo.GeneralRoomInfos");
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
            DropForeignKey("dbo.Consultation", "ConsultationDepartmentId", "dbo.Destinations");
            DropIndex("dbo.TreatmentRecords", new[] { "CFMXID" });
            DropIndex("dbo.TreatmentRecords", new[] { "GeneralRoomInfoId" });
            DropIndex("dbo.ImageRecords", new[] { "BOOKID" });
            DropIndex("dbo.ImageRecords", new[] { "ImageCategoryId" });
            DropIndex("dbo.ImageRecords", new[] { "GeneralRoomInfoId" });
            DropIndex("dbo.ImageCategories", new[] { "OriginCode" });
            DropIndex("dbo.ImageCategories", new[] { "ImageCategoryName" });
            DropIndex("dbo.GreenPathAmiInfoes", new[] { "GeneralRoomInfoId" });
            DropIndex("dbo.DrugRecords", new[] { "CFMXID" });
            DropIndex("dbo.DrugRecords", new[] { "GeneralRoomInfoId" });
            DropIndex("dbo.DrugRecordDefinitions", new[] { "GreenPathCategoryId" });
            DropIndex("dbo.TransferReasons", new[] { "TransferReasonName" });
            DropIndex("dbo.Rooms", new[] { "RoomName" });
            DropIndex("dbo.RescueResults", new[] { "RescueResultName" });
            DropIndex("dbo.InRoomWays", new[] { "InRoomWayName" });
            DropIndex("dbo.GreenPathCategories", new[] { "GreenPathCategoryName" });
            DropIndex("dbo.CriticalLevels", new[] { "CriticalLevelName" });
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
            DropIndex("dbo.Consultation", new[] { "ConsultationDepartmentId" });
            DropIndex("dbo.Consultation", new[] { "GeneralRoomInfoId" });
            DropIndex("dbo.Beds", new[] { "BedName" });
            DropTable("dbo.TreatmentRecords");
            DropTable("dbo.ImageRecords");
            DropTable("dbo.ImageCategories");
            DropTable("dbo.GreenPathAmiInfoes");
            DropTable("dbo.DrugRecords");
            DropTable("dbo.DrugRecordDefinitions");
            DropTable("dbo.TransferReasons");
            DropTable("dbo.Rooms");
            DropTable("dbo.RescueResults");
            DropTable("dbo.InRoomWays");
            DropTable("dbo.GreenPathCategories");
            DropTable("dbo.CriticalLevels");
            DropTable("dbo.GeneralRoomInfos");
            DropTable("dbo.Destinations");
            DropTable("dbo.Consultation");
            DropTable("dbo.Beds");
        }
    }
}
