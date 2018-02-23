namespace EmergencyInformationSystem.Models.Domains3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GreenPathCategoryAddField : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GreenPathInfos",
                c => new
                    {
                        GreenPathInfoId = c.Guid(nullable: false),
                        GeneralRoomInfoId = c.Guid(nullable: false),
                        GrennPathId = c.Guid(nullable: false),
                        GreenPathCategoryId = c.Guid(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        UpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GreenPathInfoId)
                .ForeignKey("dbo.GeneralRoomInfos", t => t.GeneralRoomInfoId, cascadeDelete: true)
                .ForeignKey("dbo.GreenPathCategories", t => t.GreenPathCategoryId, cascadeDelete: true)
                .Index(t => t.GeneralRoomInfoId, unique: true)
                .Index(t => t.GrennPathId, unique: true)
                .Index(t => t.GreenPathCategoryId);
            
            AddColumn("dbo.GreenPathCategories", "IsHasForm", c => c.Boolean(nullable: false));
            AddColumn("dbo.GreenPathCategories", "CodeName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GreenPathInfos", "GreenPathCategoryId", "dbo.GreenPathCategories");
            DropForeignKey("dbo.GreenPathInfos", "GeneralRoomInfoId", "dbo.GeneralRoomInfos");
            DropIndex("dbo.GreenPathInfos", new[] { "GreenPathCategoryId" });
            DropIndex("dbo.GreenPathInfos", new[] { "GrennPathId" });
            DropIndex("dbo.GreenPathInfos", new[] { "GeneralRoomInfoId" });
            DropColumn("dbo.GreenPathCategories", "CodeName");
            DropColumn("dbo.GreenPathCategories", "IsHasForm");
            DropTable("dbo.GreenPathInfos");
        }
    }
}
