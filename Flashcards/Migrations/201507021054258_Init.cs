namespace Flashcards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 3),
                        Description = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryGroupCategory",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupId, t.CategoryId })
                .ForeignKey("dbo.CategoryGroup", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryGroupCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CategoryGroupCategory", "GroupId", "dbo.CategoryGroup");
            DropIndex("dbo.CategoryGroupCategory", new[] { "CategoryId" });
            DropIndex("dbo.CategoryGroupCategory", new[] { "GroupId" });
            DropTable("dbo.CategoryGroupCategory");
            DropTable("dbo.Language");
            DropTable("dbo.CategoryGroup");
            DropTable("dbo.Category");
        }
    }
}
