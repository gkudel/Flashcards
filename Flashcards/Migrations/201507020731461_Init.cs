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
                        CategoryGroup_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryGroup_Id, t.Category_Id })
                .ForeignKey("dbo.CategoryGroup", t => t.CategoryGroup_Id, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.CategoryGroup_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryGroupCategory", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.CategoryGroupCategory", "CategoryGroup_Id", "dbo.CategoryGroup");
            DropIndex("dbo.CategoryGroupCategory", new[] { "Category_Id" });
            DropIndex("dbo.CategoryGroupCategory", new[] { "CategoryGroup_Id" });
            DropTable("dbo.CategoryGroupCategory");
            DropTable("dbo.Language");
            DropTable("dbo.CategoryGroup");
            DropTable("dbo.Category");
        }
    }
}
