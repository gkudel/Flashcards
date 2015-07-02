using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashcards.Areas.Admin.DAL
{
    public class WordsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AdminContext>
    {
        protected override void Seed(AdminContext context)
        { }
    }
}