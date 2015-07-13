namespace Flashcards.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Translation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Translation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageId = c.Int(nullable: false),
                        WordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Word", t => t.WordId, cascadeDelete: true)
                .Index(t => t.LanguageId)
                .Index(t => t.WordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Translation", "WordId", "dbo.Word");
            DropForeignKey("dbo.Translation", "LanguageId", "dbo.Language");
            DropIndex("dbo.Translation", new[] { "WordId" });
            DropIndex("dbo.Translation", new[] { "LanguageId" });
            DropTable("dbo.Translation");
        }
    }
}
