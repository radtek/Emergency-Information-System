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
                        BedId = c.Guid(nullable: false),
                        BedName = c.String(nullable: false, maxLength: 30),
                        IsUseForRescueRoom = c.Boolean(nullable: false),
                        IsUseForObserveRoom = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
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
                        IsUseForRescueRoom = c.Boolean(nullable: false),
                        IsUseForObserveRoom = c.Boolean(nullable: false),
                        IsUseForSubscription = c.Boolean(nullable: false),
                        IsUseForConsultation = c.Boolean(nullable: false),
                        IsClassifiedToInDepartment = c.Boolean(nullable: false),
                        IsClassifiedToOutDepartment = c.Boolean(nullable: false),
                        IsClassifiedLeave = c.Boolean(nullable: false),
                        IsClassifiedToOther = c.Boolean(nullable: false),
                        Priority2 = c.Int(nullable: false),
                        IsHasAdditionalInfo = c.Boolean(nullable: false),
                        IsGotoRescueRoom = c.Boolean(nullable: false),
                        IsGotoObserveRoom = c.Boolean(nullable: false),
                        IsTransfer = c.Boolean(nullable: false),
                        IsProfessional = c.Boolean(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DestinationId)
                .Index(t => t.DestinationName, unique: true);
            
            CreateTable(
                "dbo.GreenPathAmis",
                c => new
                    {
                        GreenPathAmiId = c.Guid(nullable: false),
                        RescueRoomInfoId = c.Guid(nullable: false),
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
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId, unique: true);
            
            CreateTable(
                "dbo.RescueRoomInfos",
                c => new
                    {
                        RescueRoomInfoId = c.Guid(nullable: false),
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
                        InRescueRoomWayId = c.Guid(),
                        InRescueRoomWayRemarks = c.String(),
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
                        NextObserveRoomInfo_ObserveRoomInfoId = c.Guid(),
                    })
                .PrimaryKey(t => t.RescueRoomInfoId)
                .ForeignKey("dbo.Beds", t => t.BedId)
                .ForeignKey("dbo.CriticalLevels", t => t.CriticalLevelId)
                .ForeignKey("dbo.Destinations", t => t.DestinationId)
                .ForeignKey("dbo.Destinations", t => t.DestinationFirstId)
                .ForeignKey("dbo.Destinations", t => t.DestinationSecondId)
                .ForeignKey("dbo.GreenPathCategories", t => t.GreenPathCategoryId)
                .ForeignKey("dbo.InRescueRoomWays", t => t.InRescueRoomWayId)
                .ForeignKey("dbo.ObserveRoomInfos", t => t.NextObserveRoomInfo_ObserveRoomInfoId)
                .ForeignKey("dbo.RescueResults", t => t.RescueResultId)
                .ForeignKey("dbo.TransferReasons", t => t.TransferReasonId)
                .Index(t => t.BedId)
                .Index(t => t.InRescueRoomWayId)
                .Index(t => t.CriticalLevelId)
                .Index(t => t.RescueResultId)
                .Index(t => t.GreenPathCategoryId)
                .Index(t => t.DestinationFirstId)
                .Index(t => t.DestinationSecondId)
                .Index(t => t.DestinationId)
                .Index(t => t.TransferReasonId)
                .Index(t => t.JZID, unique: true)
                .Index(t => t.NextObserveRoomInfo_ObserveRoomInfoId);
            
            CreateTable(
                "dbo.GreenPathCategories",
                c => new
                    {
                        GreenPathCategoryId = c.Guid(nullable: false),
                        GreenPathCategoryName = c.String(nullable: false, maxLength: 30),
                        IsHasAdditionalInfo = c.Boolean(nullable: false),
                        CodeName = c.String(nullable: false, maxLength: 30),
                        Priority = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GreenPathCategoryId)
                .Index(t => t.GreenPathCategoryName, unique: true)
                .Index(t => t.CodeName, unique: true);
            
            CreateTable(
                "dbo.GreenPathStks",
                c => new
                    {
                        GreenPathStkId = c.Guid(nullable: false),
                        RescueRoomInfoId = c.Guid(nullable: false),
                        OccurrenceTime = c.DateTime(),
                        Remarks = c.String(),
                        FinishPathTime = c.DateTime(),
                        Problem = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GreenPathStkId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId, unique: true);
            
            CreateTable(
                "dbo.InRescueRoomWays",
                c => new
                    {
                        InRescueRoomWayId = c.Guid(nullable: false),
                        InRescueRoomWayName = c.String(nullable: false, maxLength: 30),
                        IsHasAdditionalInfo = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InRescueRoomWayId)
                .Index(t => t.InRescueRoomWayName, unique: true);
            
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
                        BedId = c.Guid(),
                        FirstNurseName = c.String(),
                        InObserveRoomWayId = c.Guid(),
                        InObserveRoomWayRemarks = c.String(),
                        AdditionalDiagnosis = c.String(),
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
                        NextRescueRoomInfo_RescueRoomInfoId = c.Guid(),
                    })
                .PrimaryKey(t => t.ObserveRoomInfoId)
                .ForeignKey("dbo.Beds", t => t.BedId)
                .ForeignKey("dbo.Destinations", t => t.DestinationId)
                .ForeignKey("dbo.Destinations", t => t.DestinationFirstId)
                .ForeignKey("dbo.Destinations", t => t.DestinationSecondId)
                .ForeignKey("dbo.InObserveRoomWays", t => t.InObserveRoomWayId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.NextRescueRoomInfo_RescueRoomInfoId)
                .ForeignKey("dbo.TransferReasons", t => t.TransferReasonId)
                .Index(t => t.BedId)
                .Index(t => t.InObserveRoomWayId)
                .Index(t => t.DestinationFirstId)
                .Index(t => t.DestinationSecondId)
                .Index(t => t.DestinationId)
                .Index(t => t.TransferReasonId)
                .Index(t => t.JZID, unique: true)
                .Index(t => t.NextRescueRoomInfo_RescueRoomInfoId);
            
            CreateTable(
                "dbo.InObserveRoomWays",
                c => new
                    {
                        InObserveRoomWayId = c.Guid(nullable: false),
                        InObserveRoomWayName = c.String(nullable: false, maxLength: 30),
                        IsHasAdditionalInfo = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InObserveRoomWayId)
                .Index(t => t.InObserveRoomWayName, unique: true);
            
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
                "dbo.RescueRoomConsultations",
                c => new
                    {
                        RescueRoomConsultationId = c.Guid(nullable: false),
                        RescueRoomInfoId = c.Guid(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                        ArriveTime = c.DateTime(),
                        ConsultationDoctorName = c.String(nullable: false),
                        ConsultationDepartmentId = c.Guid(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RescueRoomConsultationId)
                .ForeignKey("dbo.Destinations", t => t.ConsultationDepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId)
                .Index(t => t.ConsultationDepartmentId);
            
            CreateTable(
                "dbo.RescueRoomDrugRecords",
                c => new
                    {
                        RescueRoomDrugRecordId = c.Guid(nullable: false),
                        RescueRoomInfoId = c.Guid(nullable: false),
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
                .PrimaryKey(t => t.RescueRoomDrugRecordId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId)
                .Index(t => t.CFMXID, unique: true);
            
            CreateTable(
                "dbo.RescueRoomImageRecords",
                c => new
                    {
                        RescueRoomImageRecordId = c.Guid(nullable: false),
                        RescueRoomInfoId = c.Guid(nullable: false),
                        BookTime = c.DateTime(),
                        CheckTime = c.DateTime(),
                        ReportTime = c.DateTime(),
                        Part = c.String(),
                        Category = c.String(),
                        ImageCategoryId = c.Guid(nullable: false),
                        BOOKID = c.String(maxLength: 30),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RescueRoomImageRecordId)
                .ForeignKey("dbo.ImageCategories", t => t.ImageCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId)
                .Index(t => t.ImageCategoryId)
                .Index(t => t.BOOKID, unique: true);
            
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
                "dbo.RescueRoomTreatmentRecords",
                c => new
                    {
                        RescueRoomTreatmentRecordId = c.Guid(nullable: false),
                        RescueRoomInfoId = c.Guid(nullable: false),
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
                .PrimaryKey(t => t.RescueRoomTreatmentRecordId)
                .ForeignKey("dbo.RescueRoomInfos", t => t.RescueRoomInfoId, cascadeDelete: true)
                .Index(t => t.RescueRoomInfoId)
                .Index(t => t.CFMXID, unique: true);
            
            CreateTable(
                "dbo.RescueRoomDrugRecordDefinitions",
                c => new
                    {
                        RescueRoomDrugRecordDefinitionId = c.Guid(nullable: false),
                        DrugCode = c.String(maxLength: 30),
                        DrugName = c.String(),
                        GreenPathCode = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RescueRoomDrugRecordDefinitionId)
                .Index(t => t.DrugCode, unique: true);
            
            CreateTable(
                "dbo.RescueRoomTreatmentRecordDefinitions",
                c => new
                    {
                        RescueRoomTreatmentRecordDefinitionId = c.Guid(nullable: false),
                        TreatmentCode = c.String(maxLength: 30),
                        TreatmentName = c.String(),
                        GreenPathCode = c.String(),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RescueRoomTreatmentRecordDefinitionId)
                .Index(t => t.TreatmentCode, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GreenPathAmis", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomInfos", "TransferReasonId", "dbo.TransferReasons");
            DropForeignKey("dbo.RescueRoomTreatmentRecords", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomImageRecords", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomImageRecords", "ImageCategoryId", "dbo.ImageCategories");
            DropForeignKey("dbo.RescueRoomDrugRecords", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomConsultations", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomConsultations", "ConsultationDepartmentId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "RescueResultId", "dbo.RescueResults");
            DropForeignKey("dbo.RescueRoomInfos", "NextObserveRoomInfo_ObserveRoomInfoId", "dbo.ObserveRoomInfos");
            DropForeignKey("dbo.ObserveRoomInfos", "TransferReasonId", "dbo.TransferReasons");
            DropForeignKey("dbo.ObserveRoomInfos", "NextRescueRoomInfo_RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.ObserveRoomInfos", "InObserveRoomWayId", "dbo.InObserveRoomWays");
            DropForeignKey("dbo.ObserveRoomInfos", "DestinationSecondId", "dbo.Destinations");
            DropForeignKey("dbo.ObserveRoomInfos", "DestinationFirstId", "dbo.Destinations");
            DropForeignKey("dbo.ObserveRoomInfos", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.ObserveRoomInfos", "BedId", "dbo.Beds");
            DropForeignKey("dbo.RescueRoomInfos", "InRescueRoomWayId", "dbo.InRescueRoomWays");
            DropForeignKey("dbo.GreenPathStks", "RescueRoomInfoId", "dbo.RescueRoomInfos");
            DropForeignKey("dbo.RescueRoomInfos", "GreenPathCategoryId", "dbo.GreenPathCategories");
            DropForeignKey("dbo.RescueRoomInfos", "DestinationSecondId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "DestinationFirstId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "DestinationId", "dbo.Destinations");
            DropForeignKey("dbo.RescueRoomInfos", "CriticalLevelId", "dbo.CriticalLevels");
            DropForeignKey("dbo.RescueRoomInfos", "BedId", "dbo.Beds");
            DropIndex("dbo.RescueRoomTreatmentRecordDefinitions", new[] { "TreatmentCode" });
            DropIndex("dbo.RescueRoomDrugRecordDefinitions", new[] { "DrugCode" });
            DropIndex("dbo.RescueRoomTreatmentRecords", new[] { "CFMXID" });
            DropIndex("dbo.RescueRoomTreatmentRecords", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.ImageCategories", new[] { "OriginCode" });
            DropIndex("dbo.ImageCategories", new[] { "ImageCategoryName" });
            DropIndex("dbo.RescueRoomImageRecords", new[] { "BOOKID" });
            DropIndex("dbo.RescueRoomImageRecords", new[] { "ImageCategoryId" });
            DropIndex("dbo.RescueRoomImageRecords", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.RescueRoomDrugRecords", new[] { "CFMXID" });
            DropIndex("dbo.RescueRoomDrugRecords", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.RescueRoomConsultations", new[] { "ConsultationDepartmentId" });
            DropIndex("dbo.RescueRoomConsultations", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.RescueResults", new[] { "RescueResultName" });
            DropIndex("dbo.TransferReasons", new[] { "TransferReasonName" });
            DropIndex("dbo.InObserveRoomWays", new[] { "InObserveRoomWayName" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "NextRescueRoomInfo_RescueRoomInfoId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "JZID" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "TransferReasonId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "DestinationId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "DestinationSecondId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "DestinationFirstId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "InObserveRoomWayId" });
            DropIndex("dbo.ObserveRoomInfos", new[] { "BedId" });
            DropIndex("dbo.InRescueRoomWays", new[] { "InRescueRoomWayName" });
            DropIndex("dbo.GreenPathStks", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.GreenPathCategories", new[] { "CodeName" });
            DropIndex("dbo.GreenPathCategories", new[] { "GreenPathCategoryName" });
            DropIndex("dbo.RescueRoomInfos", new[] { "NextObserveRoomInfo_ObserveRoomInfoId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "JZID" });
            DropIndex("dbo.RescueRoomInfos", new[] { "TransferReasonId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "DestinationId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "DestinationSecondId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "DestinationFirstId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "GreenPathCategoryId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "RescueResultId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "CriticalLevelId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "InRescueRoomWayId" });
            DropIndex("dbo.RescueRoomInfos", new[] { "BedId" });
            DropIndex("dbo.GreenPathAmis", new[] { "RescueRoomInfoId" });
            DropIndex("dbo.Destinations", new[] { "DestinationName" });
            DropIndex("dbo.CriticalLevels", new[] { "CriticalLevelName" });
            DropIndex("dbo.Beds", new[] { "BedName" });
            DropTable("dbo.RescueRoomTreatmentRecordDefinitions");
            DropTable("dbo.RescueRoomDrugRecordDefinitions");
            DropTable("dbo.RescueRoomTreatmentRecords");
            DropTable("dbo.ImageCategories");
            DropTable("dbo.RescueRoomImageRecords");
            DropTable("dbo.RescueRoomDrugRecords");
            DropTable("dbo.RescueRoomConsultations");
            DropTable("dbo.RescueResults");
            DropTable("dbo.TransferReasons");
            DropTable("dbo.InObserveRoomWays");
            DropTable("dbo.ObserveRoomInfos");
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
