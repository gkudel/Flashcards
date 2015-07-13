namespace Flashcards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Word : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordCategory",
                c => new
                    {
                        WordId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WordId, t.CategoryId })
                .ForeignKey("dbo.Word", t => t.WordId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.WordId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordCategory", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.WordCategory", "WordId", "dbo.Word");
            DropIndex("dbo.WordCategory", new[] { "CategoryId" });
            DropIndex("dbo.WordCategory", new[] { "WordId" });
            DropTable("dbo.WordCategory");
            DropTable("dbo.Word");
        }
    }
}
