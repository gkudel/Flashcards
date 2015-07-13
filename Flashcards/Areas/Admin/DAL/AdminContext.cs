using Flashcards.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Flashcards.Areas.Admin.DAL
{
    public class AdminContext : DbContext
    {
        public AdminContext()
            : base("AdminContext")
        { }

        public DbSet<Language> Language { get; set; }
        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Translation> Translations { get; set; }
    }
}