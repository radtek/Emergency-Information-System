namespace EmergencyInformationSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beds",
                c => new
                {
                    BedId = c.Int(nullable: false, identity: true),
                    BedName = c.String(),
                    IsUseForRescueRoom = c.Boolean(nullable: false),
                    IsUseForObserveRoom = c.Boolean(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.BedId);

            CreateTable(
                "dbo.CriticalLevels",
                c => new
                {
                    CriticalLevelId = c.Int(nullable: false, identity: true),
                    CriticalLevelName = c.String(),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CriticalLevelId);

            CreateTable(
                "dbo.Destinations",
                c => new
                {
                    DestinationId = c.Int(nullable: false, identity: true),
                    DestinationName = c.String(),
                    IsUseForRescueRoom = c.Boolean(nullable: false),
                    IsUseForObserveRoom = c.Boolean(nullable: false),
                    IsUseForConsultation = c.Boolean(nullable: false),
                    IsBelongToInDepartment = c.Boolean(nullable: false),
                    IsBelongToOutDepartment = c.Boolean(nullable: false),
                    IsLeave = c.Boolean(nullable: false),
                    IsBelongToOther = c.Boolean(nullable: false),
                    IsUseForEmpty = c.Boolean(nullable: false),
                    IsHasAdditionalInfo = c.Boolean(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.DestinationId);

            CreateTable(
                "dbo.GreenPathAmis",
                c => new
                {
                    GreenPathAmiId = c.Guid(nullable: false),
                    RescueRoomInfoId = c.Int(nullable: false),
                    OccurrenceTime = c.DateTime(),
                    EcgFirstTime = c.DateTime(),
                    EcgSecondTime = c.DateTime(),
                    Remarks = c.String(),
                    FinishPathTime = c.DateTime(),
                    Problem = c.String(),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.GreenPathAmiId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId);

            CreateTable(
                "dbo.RescueRoomInfos",
                c => new
                {
                    RescueRoomInfoId = c.Int(nullable: false, identity: true),
                    PatientName = c.String(),
                    OutPatientNumber = c.String(nullable: false),
                    Sex = c.String(),
                    BirthDate = c.DateTime(),
                    DiagnosisNameOrigin = c.String(),
                    ReceiveTime = c.DateTime(),
                    FirstDoctorName = c.String(),
                    InDepartmentTime = c.DateTime(nullable: false),
                    BedNumber = c.String(),
                    BedId = c.Int(nullable: false),
                    FirstNurseName = c.String(),
                    InRescueRoomWayId = c.Int(nullable: false),
                    InRescueRoomWayRemarks = c.String(),
                    CriticalLevelId = c.Int(nullable: false),
                    IsRescue = c.Boolean(nullable: false),
                    RescueResultId = c.Int(nullable: false),
                    GreenPathCategoryId = c.Int(nullable: false),
                    GreenPathCategoryRemarks = c.String(),
                    Antibiotic = c.String(),
                    Remarks = c.String(),
                    DestinationFirstId = c.Int(nullable: false),
                    DestinationFirstTime = c.DateTime(),
                    DestinationFirstContact = c.String(),
                    DestinationSecondId = c.Int(nullable: false),
                    OutDepartmentTime = c.DateTime(),
                    DestinationId = c.Int(nullable: false),
                    DestinationRemarks = c.String(),
                    HandleNurse = c.String(),
                    DiagnosisName = c.String(),
                    KDJID = c.Guid(),
                    BRXXID = c.Guid(),
                    GHXXID = c.Guid(),
                    JZID = c.Guid(),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.RescueRoomInfoId)
                .ForeignKey("dbo.Beds", t => t.BedId, cascadeDelete: true)
                .ForeignKey("dbo.CriticalLevels", t => t.CriticalLevelId, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.DestinationFirstId, cascadeDelete: false)
                .ForeignKey("dbo.Destinations", t => t.DestinationSecondId, cascadeDelete: false)
                .ForeignKey("dbo.GreenPathCategories", t => t.GreenPathCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.InRescueRoomWays", t => t.InRescueRoomWayId, cascadeDelete: true)
                .ForeignKey("dbo.RescueResults", t => t.RescueResultId, cascadeDelete: true)
                .Index(t => t.BedId)
                .Index(t => t.InRescueRoomWayId)
                .Index(t => t.CriticalLevelId)
                .Index(t => t.RescueResultId)
                .Index(t => t.GreenPathCategoryId)
                .Index(t => t.DestinationFirstId)
                .Index(t => t.DestinationSecondId)
                .Index(t => t.DestinationId);

            CreateTable(
                "dbo.GreenPathCategories",
                c => new
                {
                    GreenPathCategoryId = c.Int(nullable: false, identity: true),
                    GreenPathCategoryName = c.String(),
                    IsHasAdditionalInfo = c.Boolean(nullable: false),
                    IsUseForEmpty = c.Boolean(nullable: false),
                    CodeName = c.String(),
                })
                .PrimaryKey(t => t.GreenPathCategoryId);

            CreateTable(
                "dbo.GreenPathStks",
                c => new
                {
                    GreenPathStkId = c.Guid(nullable: false),
                    RescueRoomInfoId = c.Int(nullable: false),
                    OccurrenceTime = c.DateTime(),
                    Remarks = c.String(),
                    FinishPathTime = c.DateTime(),
                    Problem = c.String(),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.GreenPathStkId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId);

            CreateTable(
                "dbo.InRescueRoomWays",
                c => new
                {
                    InRescueRoomWayId = c.Int(nullable: false, identity: true),
                    InRescueRoomWayName = c.String(),
                    IsHasAdditionalInfo = c.Boolean(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.InRescueRoomWayId);

            CreateTable(
                "dbo.RescueResults",
                c => new
                {
                    RescueResultId = c.Int(nullable: false, identity: true),
                    RescueResultName = c.String(),
                    IsUseForEmpty = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.RescueResultId);

            CreateTable(
                "dbo.RescueRoomConsultations",
                c => new
                {
                    ConsultationInfoId = c.Guid(nullable: false),
                    RescueRoomInfoId = c.Int(nullable: false),
                    RequestTime = c.DateTime(nullable: false),
                    ArriveTime = c.DateTime(),
                    ConsultationDoctorName = c.String(nullable: false),
                    ConsultationDepartmentId = c.Int(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ConsultationInfoId)
                .ForeignKey("dbo.Destinations", t => t.ConsultationDepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId)
                .Index(t => t.ConsultationDepartmentId);

            CreateTable(
                "dbo.RescueRoomDrugRecords",
                c => new
                {
                    RescueRoomDrugRecordId = c.Guid(nullable: false),
                    RescueRoomInfoId = c.Int(nullable: false),
                    ProductCode = c.String(),
                    ProductName = c.String(),
                    GoodsName = c.String(),
                    DosageQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    DosageUnit = c.String(),
                    PrescriptionTime = c.DateTime(),
                    CFMXID = c.Guid(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.RescueRoomDrugRecordId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId);

            CreateTable(
                "dbo.RescueRoomImageRecords",
                c => new
                {
                    RescueRoomImageRecordId = c.Guid(nullable: false),
                    RescueRoomInfoId = c.Int(nullable: false),
                    BookTime = c.DateTime(),
                    CheckTime = c.DateTime(),
                    ReportTime = c.DateTime(),
                    Part = c.String(),
                    Category = c.String(),
                    ImageCategoryId = c.Int(nullable: false),
                    BOOKID = c.String(),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.RescueRoomImageRecordId)
                .ForeignKey("dbo.ImageCategories", t => t.ImageCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId)
                .Index(t => t.ImageCategoryId);

            CreateTable(
                "dbo.ImageCategories",
                c => new
                {
                    ImageCategoryId = c.Int(nullable: false, identity: true),
                    ImageCategoryName = c.String(),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ImageCategoryId);

            CreateTable(
                "dbo.InObserveRoomWays",
                c => new
                {
                    InObserveRoomWayId = c.Int(nullable: false, identity: true),
                    InObserveRoomWayName = c.String(),
                    IsHasAdditionalInfo = c.Boolean(nullable: false),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.InObserveRoomWayId);

            CreateTable(
                "dbo.ObserveRoomInfos",
                c => new
                {
                    ObserveRoomInfoId = c.Guid(nullable: false),
                    PatientName = c.String(),
                    OutPatientNumber = c.String(nullable: false),
                    Sex = c.String(),
                    BirthDate = c.DateTime(),
                    DiagnosisNameOrigin = c.String(),
                    ReceiveTime = c.DateTime(),
                    FirstDoctorName = c.String(),
                    InDepartmentTime = c.DateTime(nullable: false),
                    BedNumber = c.String(),
                    BedId = c.Int(nullable: false),
                    FirstNurseName = c.String(),
                    InObserveRoomWayId = c.Int(nullable: false),
                    InObserveRoomWayRemarks = c.String(),
                    DestinationFirstId = c.Int(nullable: false),
                    DestinationFirstTime = c.DateTime(),
                    DestinationFirstContact = c.String(),
                    DestinationSecondId = c.Int(nullable: false),
                    OutDepartmentTime = c.DateTime(),
                    DestinationId = c.Int(nullable: false),
                    DestinationRemarks = c.String(),
                    HandleNurse = c.String(),
                    DiagnosisName = c.String(),
                    KDJID = c.Guid(),
                    BRXXID = c.Guid(),
                    GHXXID = c.Guid(),
                    JZID = c.Guid(),
                    TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    UpdateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ObserveRoomInfoId)
                .ForeignKey("dbo.Beds", t => t.BedId, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .ForeignKey("dbo.Destinations", t => t.DestinationFirstId, cascadeDelete: false)
                .ForeignKey("dbo.Destinations", t => t.DestinationSecondId, cascadeDelete: false)
                .ForeignKey("dbo.InObserveRoomWays", t => t.InObserveRoomWayId, cascadeDelete: true)
                .Index(t => t.BedId)
                .Index(t => t.InObserveRoomWayId)
                .Index(t => t.DestinationFirstId)
                .Index(t => t.DestinationSecondId)
                .Index(t => t.DestinationId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ObserveRoomInfos", "InObserveRoomWayId", "dbo.InObserveRoomWays");
            DropForeignKey("dbo.ObserveRoomInfos", "DestinationSecondId", "dbo.Destinations");
            DropForeignKey("dbo.ObserveRoomInfos", "DestinationFirstId", "dbo.Destinations");
            DropForeignKey("dbo.ObserveRoomInfos", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.ObserveRoomInfos", "BedId", "dbo.Beds");
            DropForeignKey("dbo.GreenPathAmis", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomImageRecords", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomImageRecords", "ImageCategoryId", "dbo.ImageCategories");
            DropForeignKey("dbo.RescueRoomDrugRecords", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomConsultations", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomConsultations", "ConsultationDepartmentId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "RescueResultId", "dbo.RescueResults");
            DropForeignKey("dbo.RescueRoomInfos", "InRescueRoomWayId", "dbo.InRescueRoomWays");
            DropForeignKey("dbo.GreenPathStks", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomInfos", "GreenPathCategoryId", "dbo.GreenPathCategories");
            DropForeignKey("dbo.RescueRoomInfos", "DestinationSecondId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "DestinationFirstId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "CriticalLevelId", "dbo.CriticalLevels");
            DropForeignKey("dbo.RescueRoomInfos", "BedId", "dbo.Beds");
            DropIndex("dbo.ObserveRoomInfos", new[] { "DestinationId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "DestinationSecondId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "DestinationFirstId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "InObserveRoomWayId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "BedId" });
            DropIndex("dbo.RescueRoomImageRecords", new[] { "ImageCategoryId" });
            DropIndex("dbo.RescueRoomImageRecords", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.RescueRoomDrugRecords", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.RescueRoomConsultations", new[] { "ConsultationDepartmentId" });
            DropIndex("dbo.RescueRoomConsultations", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.GreenPathStks", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "DestinationId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "DestinationSecondId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "DestinationFirstId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "GreenPathCategoryId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "RescueResultId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "CriticalLevelId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "InRescueRoomWayId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "BedId" });
            DropIndex("dbo.GreenPathAmis", new[] { "RescueRoomInfoId" });
            DropTable("dbo.ObserveRoomInfos");
            DropTable("dbo.InObserveRoomWays");
            DropTable("dbo.ImageCategories");
            DropTable("dbo.RescueRoomImageRecords");
            DropTable("dbo.RescueRoomDrugRecords");
            DropTable("dbo.RescueRoomConsultations");
            DropTable("dbo.RescueResults");
            DropTable("dbo.InRescueRoomWays");
            DropTable("dbo.GreenPathStks");
            DropTable("dbo.GreenPathCategories");
            DropTable("dbo.RescueRoomInfos");
            DropTable("dbo.GreenPathAmis");
            DropTable("dbo.Destinations");
            DropTable("dbo.CriticalLevels");
            DropTable("dbo.Beds");
        }
    }
}
