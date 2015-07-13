using Flashcards.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Flashcards.DAL
{
    public class WordsContext : DbContext
    {
        public WordsContext()
            : base("WordsContext")
        { }

        public DbSet<Language> Language { get; set; }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Translation> Translations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<CategoryGroup>().HasMany(g => g.Categories)
                .WithMany(c => c.Groups)
                .Map(t => t.MapLeftKey("GroupId")
                    .MapRightKey("CategoryId")
                    .ToTable("CategoryGroupCategory"));

            
            modelBuilder.Entity<Word>().HasMany(g => g.Categories)
                .WithMany(c => c.Words)
                .Map(t => t.MapLeftKey("WordId")
                    .MapRightKey("CategoryId")
                    .ToTable("WordCategory"));
        }
    }
}